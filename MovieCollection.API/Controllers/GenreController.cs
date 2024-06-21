using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Controllers.Base;
using MovieCollection.Infrastructure.Repositories;

namespace MovieCollection.API.Controllers
{
    public class GenreController : CrudController<GenreDto>
    {
        public GenreController(IMediator mediator) : base(mediator)
        {
        }
    }
}
