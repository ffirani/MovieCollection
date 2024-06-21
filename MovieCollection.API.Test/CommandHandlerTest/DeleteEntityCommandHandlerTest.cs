using AutoMapper;
using MovieCollection.API.Commands;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Core;
using MovieCollection.Domain.Models;
using MovieCollection.Domain.Repository;
using MovieCollection.Infrastructure.Error;
using MovieCollection.Infrastructure.Repositories.Base;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.API.Test.CommandHandlerTest
{

    public class DeleteEntityCommandHandlerTest
    {
        private IMovieRepository _movieRepository;

        [Fact]
        public async Task Handle_valid_delete_command_no_exception()
        {
            //Assert
            var movieId = Guid.NewGuid();
            var context = CreateExecutionContext();
            var command = new DeleteEntityCommand<MovieDto>();
            command.Id = movieId;
            var handler = new DeleteEntityCommandHandler<MovieDto,Movie>(context);

            //Action
            await handler.Handle(command, CancellationToken.None);

            //Assert
            await _movieRepository.Received().DeleteAsync(movieId);
        }

        [Fact]
        public async Task Handle_valid_entity_id_repository_not_found_throw_AppException()
        {
            //Arange
            var movieId = Guid.Empty;
            var context = CreateExecutionContextNullRepository();
            var command = new DeleteEntityCommand<MovieDto>();
            command.Id = movieId;
            var handler = new DeleteEntityCommandHandler<MovieDto, Movie>(context);

            //Action
            var exception = await Record.ExceptionAsync(async () => await handler.Handle(command, CancellationToken.None));

            //Assert
            Assert.IsType<AppException>(exception);
            Assert.Equal("ERR3003", ((AppException)exception).ErrorCode);
            Assert.Equal($"Repository not found for type {typeof(Movie).Name}", exception.Message);

        }
        private IExecutionContext CreateExecutionContext()
        {
            var userId = Guid.NewGuid();
            _movieRepository = Substitute.For<IMovieRepository>();
            _movieRepository.DeleteAsync(Arg.Any<Guid>());
            var logger = Substitute.For<ILogger>();
            var repositoryFactory = Substitute.For<IRepositoryFactory>();
            repositoryFactory.GetRepository<Movie>().Returns(_movieRepository);

            var context = Substitute.For<IExecutionContext>();
            context.Logger.Returns(logger);
            context.RepositoryFactory.Returns(repositoryFactory);
            context.UserId.Returns(userId);
            return context;
        }

        private IExecutionContext CreateExecutionContextNullRepository()
        {
            var userId = Guid.NewGuid();
            var logger = Substitute.For<ILogger>();
            var repositoryFactory = Substitute.For<IRepositoryFactory>();
            repositoryFactory.GetRepository<Movie>().ReturnsNull();

            var context = Substitute.For<IExecutionContext>();
            context.Logger.Returns(logger);
            context.RepositoryFactory.Returns(repositoryFactory);
            context.UserId.Returns(userId);
            return context;
        }
    }
}
