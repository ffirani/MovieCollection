using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Expressions;
using MovieCollection.API.Commands;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Query;
using MovieCollection.API.Test.Integration.Auth;
using MovieCollection.API.Test.Integration.Db;
using MovieCollection.Domain.Models;
using MovieCollection.Infrastructure.Db;
using MovieCollection.Query.Parser;
using MovieCollection.Query.View;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;

namespace MovieCollection.API.Test.Integration
{
    public class MovieControllerTest:IClassFixture<WebApplicationFactory<Program>>,IClassFixture<DatabaseFixture>
    {
        private Guid _userId = new Guid("2DA93C56-0722-4772-BCB3-2CB11B694ADC");
        private WebApplicationFactory<Program> _apiFactory;
        private AppDbContext _dbContext;

        public MovieControllerTest(WebApplicationFactory<Program> apiFactory, DatabaseFixture dbFixture)
        {
            _apiFactory = apiFactory;
            _dbContext = dbFixture.Db;
        }
        [Fact]
        public async void CreateMovie_valid_movie_dto_created_in_db()
        {
            //Arange
            var movie = new MovieDto { Title = "Test Movie 15",ReleaseData=new DateTime(2012,1,1) };
            var createMovieCommand = new CreateEntityCommand<MovieDto>() { Data = movie };
            var commandSerialized = JsonConvert.SerializeObject(createMovieCommand);
            var content = new StringContent(commandSerialized,UTF8Encoding.UTF8, "application/json");
            var client = _apiFactory.CreateClient();
            var token = TokenHelper.GenerateJwtToken(_userId.ToString(), "Admin");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //Act
            var response = await client.PostAsync("/api/movie/create",content);

            //Assert
            response.EnsureSuccessStatusCode();
            var commandResponse = await response.Content.ReadFromJsonAsync<CreateEntityResponse>();
            Assert.NotNull(commandResponse);
            Assert.NotEqual(commandResponse?.Id, Guid.Empty);
        }

        [Theory]
        [MemberData(nameof(Movies))]
        public async void UpdateMovie_change_movie_dto_properties_applied_in_db(string title, decimal imdbRate, DateTime releaseDate)
        {
            //Arange
            Movie movie = CreateMovieEntityInDb(title, imdbRate, releaseDate);

            var movieDto = new MovieDto
            {
                Id = movie.Id,
                Title = "Test Movie 15",
                ImdbRate = 7.0m,
                ReleaseData = new DateTime(2021, 2, 11)
            };
            var updateMovieCommand = new UpdateEntityCommand<MovieDto>() { Data = movieDto };
            var commandSerialized = JsonConvert.SerializeObject(updateMovieCommand);
            var content = new StringContent(commandSerialized, UTF8Encoding.UTF8, "application/json");
            var client = _apiFactory.CreateClient();
            var token = TokenHelper.GenerateJwtToken(_userId.ToString(), "Admin");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //Act
            var response = await client.PutAsync("/api/movie/update", content);

            //Assert
            response.EnsureSuccessStatusCode();
            _dbContext.Entry<Movie>(movie).Reload();
            Assert.True(movie.Title == movieDto.Title && movie.ImdbRate == movieDto.ImdbRate);
        }

        [Theory]
        [MemberData(nameof(Movies))]
        public async void DeleteMovie_movie_dto_no_exception(string title, decimal imdbRate, DateTime releaseDate)
        {
            //Arange
            var movie = CreateMovieEntityInDb(title, imdbRate, releaseDate);

            var deleteMovieCommand = new DeleteEntityCommand<MovieDto>() { Id = movie.Id };
            var commandSerialized = JsonConvert.SerializeObject(deleteMovieCommand);
            var content = new StringContent(commandSerialized, UTF8Encoding.UTF8, "application/json");
            var client = _apiFactory.CreateClient();
            var token = TokenHelper.GenerateJwtToken(_userId.ToString(), "Admin");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = content,
                Method = HttpMethod.Delete,
                RequestUri = new Uri("/api/movie/delete", UriKind.Relative)
            };
            //Act
            var response = await client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            var testEntity = _dbContext.Movies.FirstOrDefault(m=>m.Id == movie.Id);
            Assert.Null(testEntity);
        }

        [Theory]
        [MemberData(nameof(Movies))]
        public async void RetrieveMovie_movie_view_no_exception(string title, decimal imdbRate, DateTime releaseDate)
        {
            //Arange
            var movie = CreateMovieEntityInDb(title, imdbRate, releaseDate);

            var retrieveEntityQuery = new RetrieveEntityQuery<MovieView>() { Id = movie.Id };
            var commandSerialized = JsonConvert.SerializeObject(retrieveEntityQuery);
            var content = new StringContent(commandSerialized, UTF8Encoding.UTF8, "application/json");
            var client = _apiFactory.CreateClient();
            var token = TokenHelper.GenerateJwtToken(_userId.ToString(), "Admin");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = content,
                Method = HttpMethod.Post,
                RequestUri = new Uri("/api/movie/retrieve", UriKind.Relative)
            };
            //Act
            var response = await client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            var retrieveEntity = await response.Content.ReadFromJsonAsync<RetrieveEntityResponse<MovieView>>();
            Assert.NotNull(retrieveEntity);
            Assert.NotNull(retrieveEntity.View);
            Assert.True(retrieveEntity.View.Id == movie.Id && 
                        retrieveEntity.View.Title == title &&
                        retrieveEntity.View.ImdbRate == imdbRate &&
                        retrieveEntity.View.ReleaseData == releaseDate) ;
        }

        [Theory]
        [MemberData(nameof(Movies))]
        public async void RetrieveMultiple_search_movie_wih_specific_title_return_one_movie(string title, decimal imdbRate, DateTime releaseDate)
        {
            //Arange
            var movie = CreateMovieEntityInDb(title, imdbRate, releaseDate);

            var query = new MovieCollection.Query.Parser.QueryExpression
            {
                Filter = new QueryFilter(LogicalOperator.And)
                {
                    Conditions = new[]
                    {
                        new QueryCondition(nameof(MovieView.Title),ConditionOperator.Contain,title),
                        new QueryCondition(nameof(MovieView.ImdbRate),ConditionOperator.GreateThan,5)
                    }
                }
            };
            var retrieveEntityQuery = new RetrieveMultipleEntityQuery<MovieView>() 
            {
                Expression = query,
                PageIndex = 1,
                PageSize = 10
            };
            var commandSerialized = JsonConvert.SerializeObject(retrieveEntityQuery);
            var content = new StringContent(commandSerialized, UTF8Encoding.UTF8, "application/json");
            var client = _apiFactory.CreateClient();
            var token = TokenHelper.GenerateJwtToken(_userId.ToString(), "Admin");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = content,
                Method = HttpMethod.Post,
                RequestUri = new Uri("/api/movie/retrieve-multiple", UriKind.Relative)
            };
            //Act
            var response = await client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            var retrieveEntity = await response.Content.ReadFromJsonAsync<RetrieveMultipleEntityResponse<MovieView>>();
            Assert.NotNull(retrieveEntity);
            Assert.NotNull(retrieveEntity.Entities);
            Assert.Single(retrieveEntity.Entities);
        }

        private Movie CreateMovieEntityInDb(string title,decimal imdbRate,DateTime datetime)
        {
            var movie = new Movie()
            {
                Title = title,
                ImdbRate = imdbRate,
                ReleaseData = datetime
            };

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
            return movie;
        }

        public static IEnumerable<object[]> Movies =>
        new List<object[]>
        {
            new object[] { "Test Movie 15", 6, new DateTime(2022,6,30)}
        };

    }
}