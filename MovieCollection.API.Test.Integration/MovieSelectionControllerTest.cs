using Microsoft.AspNetCore.Mvc.Testing;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Commands;
using MovieCollection.API.Test.Integration.Auth;
using MovieCollection.API.Test.Integration.Db;
using MovieCollection.Infrastructure.Db;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using MovieCollection.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieCollection.API.Test.Integration
{
    public class MovieSelectionControllerTest : IClassFixture<WebApplicationFactory<Program>>, IClassFixture<DatabaseFixture>
    {
        private Guid _userId = new Guid("2DA93C56-0722-4772-BCB3-2CB11B694ADC");
        private WebApplicationFactory<Program> _apiFactory;
        private AppDbContext _dbContext;

        public MovieSelectionControllerTest(WebApplicationFactory<Program> apiFactory, DatabaseFixture dbFixture)
        {
            _apiFactory = apiFactory;
            _dbContext = dbFixture.Db;
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public async void AssociateToSelection_valid_movieid_selectionid_applied_in_db(Movie movie,MovieSelection selection)
        {
            //Arange
            CreateMovieAndSelectionEntitiesInDb(movie, selection);
            var createMovieCommand = new AssociateToSelectionCommand() { MovieId = movie.Id,SelectionId=selection.Id };
            var commandSerialized = JsonConvert.SerializeObject(createMovieCommand);
            var content = new StringContent(commandSerialized, UTF8Encoding.UTF8, "application/json");
            var client = _apiFactory.CreateClient();
            var token = TokenHelper.GenerateJwtToken(_userId.ToString(), "Admin");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //Act
            var response = await client.PostAsync("/api/movieselection/associate", content);

            //Assert
            response.EnsureSuccessStatusCode();
            var movieSelectionMovieIndb = 
                _dbContext.MovieSelectionMovies
                .Any(ms => ms.MovieId == movie.Id && 
                     ms.MovieSelectionId == selection.Id);
            Assert.True(movieSelectionMovieIndb);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public async void DisassociateToSelection_valid_movieid_selectionid_applied_in_db(Movie movie, MovieSelection selection)
        {
            //Arange
            CreateMovieAndSelectionEntitiesAndAssociateThemInDb(movie, selection);

            var createMovieCommand = new DisassociateFromSelectionCommand() { MovieId = movie.Id, SelectionId = selection.Id };
            var commandSerialized = JsonConvert.SerializeObject(createMovieCommand);
            var content = new StringContent(commandSerialized, UTF8Encoding.UTF8, "application/json");
            var client = _apiFactory.CreateClient();
            var token = TokenHelper.GenerateJwtToken(_userId.ToString(), "Admin");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //Act
            var response = await client.PostAsync("/api/movieselection/disassociate", content);

            //Assert
            response.EnsureSuccessStatusCode();
            var movieSelectionMovieIndb =
                _dbContext.MovieSelectionMovies
                .Any(ms => ms.MovieId == movie.Id &&
                     ms.MovieSelectionId == selection.Id);
            Assert.False(movieSelectionMovieIndb);
        }

        private void CreateMovieAndSelectionEntitiesAndAssociateThemInDb(Movie movie, MovieSelection selection)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.MovieSelections.Add(selection);
            _dbContext.SaveChanges();
            _dbContext.MovieSelectionMovies.Add(new MovieSelectionMovie()
            {
                MovieId = movie.Id,
                MovieSelectionId = selection.Id
            });
            _dbContext.SaveChanges();
        }

        private void CreateMovieAndSelectionEntitiesInDb(Movie movie, MovieSelection selection)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.MovieSelections.Add(selection);
            _dbContext.SaveChanges();
        }

        public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { new Movie()
            {
                Title = "Test Movie 15",
                ImdbRate = 6,
                ReleaseData = new DateTime(2022,6,30)
            },
            new MovieSelection
            {
                Name = "My Top 100 Movies",
                Description = "This is my list of top 100 best movie in my opinion"
            } }
        };
    }
}
