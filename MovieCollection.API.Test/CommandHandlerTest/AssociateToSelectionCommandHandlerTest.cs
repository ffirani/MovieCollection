using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Commands;
using MovieCollection.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCollection.API.Core;
using Castle.Components.DictionaryAdapter;
using AutoMapper;
using MovieCollection.Domain.Repository;
using MovieCollection.Infrastructure.Repositories.Base;
using NSubstitute;
using Serilog;
using NSubstitute.ReturnsExtensions;
using MovieCollection.Infrastructure.Error;

namespace MovieCollection.API.Test.CommandHandlerTest
{
    public class AssociateToSelectionCommandHandlerTest
    {
        private IMovieSelectionRepository movieSelectionRepository;

        [Fact]
        public async void Handle_AssociateToSelectionCommand_valid_movieid_and_selectionid_no_exception()
        {
            //Arange
            var movieId = Guid.NewGuid();
            var selectionId = Guid.NewGuid();
            var context = CreateExecutionContextForAssociate();
            var command = new AssociateToSelectionCommand() { MovieId = movieId, SelectionId = selectionId };
            var handler = new AssociateToSelectionCommandHandler(context);

            //Action
            var exception = await Record.ExceptionAsync(async () => await handler.Handle(command, CancellationToken.None));

            //Assert
            Assert.Null(exception);
        }

        [Fact]
        public async void Handle_AssociateToSelectionCommand_valid_movieid_and_selectionid_repository_AssociateMovieAsync_called()
        {
            //Arange
            var movieId = Guid.NewGuid();
            var selectionId = Guid.NewGuid();
            var context = CreateExecutionContextForAssociate();
            var command = new AssociateToSelectionCommand() { MovieId = movieId, SelectionId = selectionId };
            var handler = new AssociateToSelectionCommandHandler(context);

            //Action
            await handler.Handle(command, CancellationToken.None);

            //Assert
            await movieSelectionRepository.Received().AssociateMovieAsync(selectionId,movieId);
        }

        [Fact]
        public async void Handle_AssociateToSelectionCommand_repository_not_found_throw_AppException()
        {
            //Arange
            var movieId = Guid.NewGuid();
            var selectionId = Guid.NewGuid();
            var context = CreateExecutionContextNullValueRepository();
            var command = new AssociateToSelectionCommand() { MovieId = movieId, SelectionId = selectionId };
            var handler = new AssociateToSelectionCommandHandler(context);

            //Action
            var exception = await Record.ExceptionAsync(async () => await handler.Handle(command, CancellationToken.None));

            //Assert
            Assert.IsType<AppException>(exception);
            Assert.Equal("ERR3004", ((AppException)exception).ErrorCode);
            Assert.Equal($"Repository not found for type {typeof(MovieSelection).Name}", exception.Message);
        }

        private IExecutionContext CreateExecutionContextNullValueRepository()
        {
            var userId = Guid.NewGuid();
            var logger = Substitute.For<ILogger>();
            var repositoryFactory = Substitute.For<IRepositoryFactory>();
            repositoryFactory.GetRepository<MovieSelection>().ReturnsNull();
            var context = Substitute.For<IExecutionContext>();

            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(new[] { typeof(Program) }));
            context.Mapper.Returns(new AutoMapper.Mapper(configuration));
            context.Logger.Returns(logger);
            context.RepositoryFactory.Returns(repositoryFactory);
            context.UserId.Returns(userId);
            return context;
        }

        private IExecutionContext CreateExecutionContextForAssociate()
        {
            var userId = Guid.NewGuid();
            movieSelectionRepository = Substitute.For<IMovieSelectionRepository>();
            movieSelectionRepository.AssociateMovieAsync(Arg.Any<Guid>(), Arg.Any<Guid>());
            var logger = Substitute.For<ILogger>();
            var repositoryFactory = Substitute.For<IRepositoryFactory>();
            repositoryFactory.GetRepository<MovieSelection>().Returns(movieSelectionRepository);
            var context = Substitute.For<IExecutionContext>();

            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(new[] { typeof(Program) }));
            context.Mapper.Returns(new AutoMapper.Mapper(configuration));
            context.Logger.Returns(logger);
            context.RepositoryFactory.Returns(repositoryFactory);
            context.UserId.Returns(userId);
            return context;
        }
    }
}
