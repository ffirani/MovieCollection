using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using MovieCollection.API.Commands;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Test.Integration.Auth;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;

namespace MovieCollection.API.Test.Integration
{
    public class MovieControllerTest:IClassFixture<WebApplicationFactory<Program>>
    {
        private Guid _userId = new Guid("2DA93C56-0722-4772-BCB3-2CB11B694ADC");
        private WebApplicationFactory<Program> _apiFactory;

        public MovieControllerTest(WebApplicationFactory<Program> apiFactory)
        {
            _apiFactory = apiFactory;
        }
        [Fact]
        public async void CreateMovie_valid_movie_dto_return_id()
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

        [Fact]
        public async void UpdateMovie_change_movie_dto_title_no_exception()
        {
            //Arange
            var movie = new MovieDto 
            {
                Id =  new Guid("7f8a3f25-cc8f-45c1-f337-08dc8d6f54fe"),
                Title = "Test Movie 12", 
            };
            var updateMovieCommand = new UpdateEntityCommand<MovieDto>() { Data = movie };
            var commandSerialized = JsonConvert.SerializeObject(updateMovieCommand);
            var content = new StringContent(commandSerialized, UTF8Encoding.UTF8, "application/json");
            var client = _apiFactory.CreateClient();
            var token = TokenHelper.GenerateJwtToken(_userId.ToString(), "Admin");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //Act
            var response = await client.PutAsync("/api/movie/update", content);

            //Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async void DeleteMovie_movie_dto_no_exception()
        {
            //Arange
            var movieId = new Guid("F9186B5F-75B7-497C-F1DD-08DC8CAFF2A3");
            var deleteMovieCommand = new DeleteEntityCommand<MovieDto>() { Id = movieId };
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
        }

    }
}