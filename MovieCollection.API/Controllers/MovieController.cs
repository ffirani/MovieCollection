using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCollection.API.Commands;
using MovieCollection.API.Commands.Base;
using MovieCollection.Domain.Models;
using MovieCollection.Domain.Models.Base;
using System.Runtime.CompilerServices;

namespace MovieCollection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<CreateEntityResponse>> CreateMovie([FromBody] CreateEntityCommand<Movie> command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
