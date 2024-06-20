using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieCollection.API.Commands;
using MovieCollection.API.Commands.Base;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Controllers;
using MovieCollection.API.Query;
using MovieCollection.Domain.Models;
using NSubstitute;

namespace MovieCollection.API.Test
{
    public class MovieControllerTest
    {
        [Fact]
        public async void CreateMovie_valid_input_return_CreateEntityResponse_with_valid_id()
        {
            //Arange
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
            //Action
            var response = await movieController.Create(command);

            //Assert
            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.IsType<CreateEntityResponse>(((OkObjectResult)response.Result).Value);
            CreateEntityResponse? responseValue = ((OkObjectResult)response.Result).Value as CreateEntityResponse;
            Assert.NotNull(responseValue);
            Assert.NotEqual(responseValue.Id , Guid.Empty);
        }

        [Fact]
        public async void UpdateMovie_change_movie_title_valid_value_response_code_204()
        {
            //Arange
            IMediator mediator = Substitute.For<IMediator>();
            mediator.Send(Arg.Any<UpdateEntityCommand<MovieDto>>()).Returns(Task.CompletedTask);
            var movieController = new MovieController(mediator);
            var movie = new MovieDto()
            {
                Title = "The Shawshank Redemption 2",
            };
            var command = new UpdateEntityCommand<MovieDto>()
            {
                Data = movie
            };

            //Action
            var response = await movieController.Update(command);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NoContentResult>(response);
            Assert.Equal((int)System.Net.HttpStatusCode.NoContent, ((NoContentResult)response).StatusCode);

        }

        [Fact]
        public async void DeleteMovie_delete_movie_valid_id_response_code_204()
        {
            //Arange
            var movieId = new Guid("2D625F09-5807-4FB7-86B3-08DC8D7E586E");
            IMediator mediator = Substitute.For<IMediator>();
            mediator.Send(Arg.Any<DeleteEntityCommand<MovieDto>>()).Returns(Task.CompletedTask);
            var movieController = new MovieController(mediator);
            var command = new DeleteEntityCommand<MovieDto>()
            {
                Id = movieId
            };

            //Action
            var response = await movieController.Delete(command);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NoContentResult>(response);
            Assert.Equal((int)System.Net.HttpStatusCode.NoContent, ((NoContentResult)response).StatusCode);

        }

        [Fact]
        public async void RetrieveMovie_retrieve_movie_valid_id_return_RetrieveEntityResponse_same_id()
        {
            //Arange
            var movieId = new Guid("2D625F09-5807-4FB7-86B3-08DC8D7E586E");
            var movie = new MovieDto
            {
                Id = new Guid("2D625F09-5807-4FB7-86B3-08DC8D7E586E"),
                Title = "Movie 1",
                ReleaseData = new DateTime(2020, 11, 1),
            };
            IMediator mediator = Substitute.For<IMediator>();
            mediator.Send(Arg.Any<RetrieveEntityQuery<MovieDto>>())
                .Returns(Task.FromResult(new RetrieveEntityResponse<MovieDto>() { Entity = movie }));
            var movieController = new MovieController(mediator);
            var command = new RetrieveEntityQuery<MovieDto>()
            {
                Id = movieId
            };

            //Action
            var response = await movieController.Retrieve(command);

            //Assert
            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.Equal((int)System.Net.HttpStatusCode.OK,((OkObjectResult)response.Result).StatusCode);
            var retrieveResult = ((OkObjectResult)response.Result).Value;
            Assert.IsType<RetrieveEntityResponse<MovieDto>>(retrieveResult);
            Assert.Equal(movieId, ((RetrieveEntityResponse<MovieDto>)retrieveResult).Entity.Id);
        }
        [Fact]
        public async void RetrieveMultipleMovie_retrieve_movie_with_specific_name_successful()
        {
            //Arange
            var movieId = new Guid("2D625F09-5807-4FB7-86B3-08DC8D7E586E");
            var movie = new MovieDto
            {
                Id = new Guid("2D625F09-5807-4FB7-86B3-08DC8D7E586E"),
                Title = "Movie 1",
                ReleaseData = new DateTime(2020, 11, 1),
            };
            IMediator mediator = Substitute.For<IMediator>();
            mediator.Send(Arg.Any<RetrieveMultipleEntityQuery<MovieDto>>())
                .Returns(Task.FromResult(new RetrieveMultipleEntityResponse<MovieDto>() 
                { 
                    Entities= new List<MovieDto> { movie} 
                }));
            var movieController = new MovieController(mediator);
            var command = new RetrieveMultipleEntityQuery<MovieDto>()
            {
                
            };

            //Action
            var response = await movieController.RetrieveMultiple(command);

            //Assert
            Assert.Equal((response.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
        }
    }
}