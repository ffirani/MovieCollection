using AutoMapper;
using MovieCollection.API.Commands;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Core;
using MovieCollection.Domain.Models;
using MovieCollection.Domain.Repository;
using MovieCollection.Infrastructure.Repositories.Base;
using NSubstitute;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.API.Test
{

    public class DeleteEntityCommandHandlerTest
    {
        private IMovieRepository _movieRepository;

        [Fact]
        public async Task Handle_valid_delete_command_no_exception()
        {
            var movieId = Guid.NewGuid();
            var context = CreateExecutionContextForMovie(movieId);
            var command = new DeleteEntityCommand<MovieDto>();
            command.Id = movieId;
            var handler = new DeleteEntityCommandHandler<MovieDto,Movie>(context);

            await handler.Handle(command, CancellationToken.None);

            await _movieRepository.Received().DeleteAsync(movieId);
        }

        [Fact]
        public async Task Handle_empty_entity_id_delete_command_throw_exception()
        {
            var movieId = Guid.Empty;
            var context = CreateExecutionContextForMovie(movieId);
            var command = new DeleteEntityCommand<MovieDto>();
            command.Id = movieId;
            var handler = new DeleteEntityCommandHandler<MovieDto,Movie>(context);

            var exception = await Record.ExceptionAsync(async () => await handler.Handle(command, CancellationToken.None));

            Assert.IsType<Exception>(exception);
            Assert.Equal("Invalid entity id value", exception.Message);

        }
        private IExecutionContext CreateExecutionContextForMovie(Guid movieId)
        {
            var userId = Guid.NewGuid();
            _movieRepository = Substitute.For<IMovieRepository>();
            _movieRepository.DeleteAsync(userId);
            var logger = Substitute.For<ILogger>();
            var repositoryFactory = Substitute.For<IRepositoryFactory>();
            repositoryFactory.GetRepository(Arg.Any<Type>()).Returns(_movieRepository);

            var context = Substitute.For<IExecutionContext>();
            context.Logger.Returns(logger);
            context.RepositoryFactory.Returns(repositoryFactory);
            context.UserId.Returns(userId);
            return context;
        }
    }
}
