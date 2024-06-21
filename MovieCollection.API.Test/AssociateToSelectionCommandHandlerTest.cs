using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Commands;
using MovieCollection.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCollection.API.Core;

namespace MovieCollection.API.Test
{
    public class AssociateToSelectionCommandHandlerTest
    {
        [Fact]
        public async void Handle_CreateEntityCommand_for_movie_successful_CreateEntityResponse_with_id()
        {
            //Arange
            var movieId = Guid.NewGuid();
            var selectionId = Guid.NewGuid();
            var context = CreateExecutionContextForMovie(movieId);
            var command = new AssociateToSelectionCommand() { MovieId= movieId, SelectionId=selectionId };
            var handler = new AssociateToSelectionCommandHandler(context);

            //Action
            await handler.Handle(command, CancellationToken.None);

            //Assert
            //Assert.
        }

        private IExecutionContext CreateExecutionContextForMovie(Guid movieId)
        {
            throw new NotImplementedException();
        }
    }
}
