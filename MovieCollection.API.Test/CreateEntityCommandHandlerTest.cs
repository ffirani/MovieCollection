using AutoMapper;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MovieCollection.API.Commands;
using MovieCollection.API.Commands.Base;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Core;
using MovieCollection.API.Core.Authentication;
using MovieCollection.Domain.Models;
using MovieCollection.Domain.Models.Base;
using MovieCollection.Domain.Repository;
using MovieCollection.Infrastructure.Repositories;
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
    public class CreateEntityCommandHandlerTest
    {
        [Fact]
        public async void Handle_CreateEntityCommand_for_movie_successful_CreateEntityResponse_with_id()
        {
            var movieId = Guid.NewGuid();
            var context = CreateExecutionContextForMovie(movieId);
            var command = new CreateEntityCommand<MovieDto>() { Data = new MovieDto() };
            command.Data = new MovieDto() { Title = "The Shawshank Redemption", ReleaseData = new DateTime(1994,6,10) };
            var handler = new CreateEntityCommandHandler(context);

            var response = await handler.Handle(command, CancellationToken.None);

            Assert.Equal(response.Id, movieId);
        }

        [Fact]
        public async void Handle_invalid_request_type_throw_ArgumentException()
        {

            var movieId = Guid.NewGuid();
            var context = CreateExecutionContextForMovie(movieId);
            var command = Substitute.For<ICreateEntityCommand>();
            var handler = new CreateEntityCommandHandler(context);

            var exception = await Record.ExceptionAsync(async () => await handler.Handle(command, CancellationToken.None));

            Assert.IsType<ArgumentException>(exception);
            Assert.Equal("Invalid request type", exception.Message);
        }

        private IExecutionContext CreateExecutionContextForMovie(Guid movieId)

        {
            var userId = Guid.NewGuid();
            var movieRepository = Substitute.For<IMovieRepository>();
            movieRepository.Create(Arg.Any<Movie>()).Returns(movieId);
            var logger = Substitute.For<ILogger>();
            var repositoryFactory = Substitute.For<IRepositoryFactory>();
            repositoryFactory.GetRepository(Arg.Any<Type>()).Returns(movieRepository);
            var context = Substitute.For<IExecutionContext>();

            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(new[] {typeof(Program)}));
            context.Mapper.Returns(new AutoMapper.Mapper(configuration));
            context.Logger.Returns(logger);
            context.RepositoryFactory.Returns(repositoryFactory);
            context.UserId.Returns(userId);
            return context;
        }

    }
}
