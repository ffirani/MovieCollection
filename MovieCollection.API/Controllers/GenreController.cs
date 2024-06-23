using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Controllers.Base;
using MovieCollection.Infrastructure.Repositories;
using MovieCollection.Query.View;

namespace MovieCollection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : CrudController<GenreDto,GenreView>
    {
        public GenreController(IMediator mediator) : base(mediator)
        {
        }
    }
}
