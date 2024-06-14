using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using MovieCollection.API.Commands;
using MovieCollection.API.Dto;
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
            var movie = new MovieDto { Title = "Test Movie",ReleaseData=new DateTime(2024,1,1) };
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

        
    }
}