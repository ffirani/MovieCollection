using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCollection.API.Commands;
using MovieCollection.API.Commands.Base;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Controllers.Base;
using MovieCollection.API.Error;
using MovieCollection.API.Query;
using MovieCollection.Domain.Models;
using MovieCollection.Domain.Models.Base;
using System.Runtime.CompilerServices;

namespace MovieCollection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : CrudController<MovieDto>
    {
        public MovieController(IMediator mediator) : base(mediator)
        {
        }
    }
}
