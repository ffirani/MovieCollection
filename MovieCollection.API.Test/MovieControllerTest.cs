using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieCollection.API.Commands;
using MovieCollection.API.Controllers;
using MovieCollection.Domain.Models;
using NSubstitute;

namespace MovieCollection.API.Test
{
    public class MovieControllerTest
    {
        [Fact]
        public async void CreateMovie_valid_input_successful()
        {
            IMediator mediator = Substitute.For<IMediator>();
            mediator.Send(Arg.Any<CreateEntityCommand<Movie>>()).Returns(new CreateEntityResponse(Guid.NewGuid()) );

            var movieController = new MovieController(mediator);
            var movie = new Movie()
            {
                Title = "The Shawshank Redemption",
                //Genres = new[] { Genres.Commedy, Genres.Romance },
                ProductionYear = new DateTime(2022, 6, 1),
                //CastAndCrews = new List<CastAndCrews>()
                //{
                //    new { }
                //},

            };
            var command = new CreateEntityCommand<Movie>()
            {
                Data = movie
            };

            var response = await movieController.CreateMovie(command);
            Assert.Equal((response.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
        }
    }
}