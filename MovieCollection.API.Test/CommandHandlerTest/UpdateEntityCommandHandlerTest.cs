using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Commands;
using MovieCollection.API.Core;
using MovieCollection.Domain.Models;
using MovieCollection.Domain.Repository;
using MovieCollection.Infrastructure.Error;
using MovieCollection.Infrastructure.Repositories.Base;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Serilog;
using NSubstitute.ReturnsExtensions;

namespace MovieCollection.API.Test.CommandHandlerTest
{
    public class UpdateEntityCommandHandlerTest
    {
        private IMovieRepository _movieRepository;

        [Fact]
        public async Task Handle_valid_update_command_no_exception()
        {
            //Assert
            var movieId = Guid.NewGuid();
            var context = CreateExecutionContextForMovie();
            var command = new UpdateEntityCommand<MovieDto>()
            {
                Data = new MovieDto() { Id = movieId, Title = "Changed Title" }
            };
            var handler = new UpdateEntityCommandHandler<MovieDto, Movie>(context);

            //Action
            await handler.Handle(command, CancellationToken.None);

            //Assert
            await _movieRepository.Received().UpdateAsync(Arg.Any<Movie>());
        }

        [Fact]
        public async Task Handle_valid_update_command_repository_not_found_throw_AppException()
        {
            //Arange
            var movieId = Guid.Empty;
            var context = CreateExecutionContextNullRepository();
            var command = new UpdateEntityCommand<MovieDto>()
            {
                Data = new MovieDto() { Id = movieId, Title = "Changed Title" }
            };
            var handler = new UpdateEntityCommandHandler<MovieDto, Movie>(context);

            //Action
            var exception = await Record.ExceptionAsync(async () => await handler.Handle(command, CancellationToken.None));

            //Assert
            Assert.IsType<AppException>(exception);
            Assert.Equal("ERR3002", ((AppException)exception).ErrorCode);
            Assert.Equal($"Repository not found for type {typeof(Movie).Name}", exception.Message);

        }
        private IExecutionContext CreateExecutionContextForMovie()
        {
            var userId = Guid.NewGuid();
            _movieRepository = Substitute.For<IMovieRepository>();
            _movieRepository.UpdateAsync(Arg.Any<Movie>());
            var logger = Substitute.For<ILogger>();
            var repositoryFactory = Substitute.For<IRepositoryFactory>();
            repositoryFactory.GetRepository<Movie>().Returns(_movieRepository);
            var context = Substitute.For<IExecutionContext>();

            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(new[] { typeof(Program) }));
            context.Mapper.Returns(new AutoMapper.Mapper(configuration));
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
