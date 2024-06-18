using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Commands;
using MovieCollection.API.Controllers;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.API.Test
{
    public class MovieCollectionControllerTest
    {
        [Fact]
        public async void CreateMovie_valid_input_successful()
        {
            IMediator mediator = Substitute.For<IMediator>();
            mediator.Send(Arg.Any<CreateEntityCommand<MovieDto>>()).Returns(new CreateEntityResponse(Guid.NewGuid()));

            var movieController = new MovieController(mediator);
            var movie = new MovieDto()
            {
                Title = "The Shawshank Redemption",
                Genres = new List<GenreDto>() { new GenreDto() { }, new GenreDto() { } },
                ReleaseData = new DateTime(2022, 6, 1),

            };
            var command = new CreateEntityCommand<MovieDto>()
            {
                Data = movie
            };

            var response = await movieController.Create(command);
            Assert.Equal((response.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
        }
    }
}
