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

namespace MovieCollection.API.Test.ControllerTest
{
    public class MovieSelectionControllerTest
    {
        [Fact]
        public async void AssociateToCollection_valid_input_response_code_204()
        {
            //Arange
            IMediator mediator = Substitute.For<IMediator>();
            mediator.Send(Arg.Any<AssociateToSelectionCommand>()).Returns(Task.CompletedTask);
            var movieId = new Guid("ED5B4174-DEE4-4A57-89BB-7360AD346146");
            var selectionId = new Guid("BDDD38A9-F27A-4963-8B00-FF61B39AEF6C");
            var command = new AssociateToSelectionCommand()
            {
                MovieId = movieId,
                SelectionId = selectionId
            };
            var movieSelectionController = new MovieSelectionController(mediator);

            //Action
            var response = await movieSelectionController.AssociateToSelection(command);

            //Assert
            Assert.Equal((int)System.Net.HttpStatusCode.NoContent, ((NoContentResult)response).StatusCode);
        }
    }
}
