using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCollection.API.Commands;
using MovieCollection.API.Commands.Base;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Query;
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

        [Authorize]
        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<CreateEntityResponse>> Create([FromBody] CreateEntityCommand<MovieDto> command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [Authorize]
        [Route("update")]
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateEntityCommand<MovieDto> command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [Authorize]
        [Route("delete")]
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DeleteEntityCommand<MovieDto> command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [Authorize]
        [Route("retrieve")]
        [HttpGet]
        public async Task<ActionResult<RetrieveEntityResponse<MovieDto>>> Retrieve([FromBody] RetrieveEntityQuery<MovieDto> command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [Authorize]
        [Route("retrieve-multiple")]
        [HttpGet]
        public async Task<ActionResult<RetrieveMultipleEntityResponse<MovieDto>>> RetrieveMultiple([FromBody] RetrieveMultipleEntityQuery<MovieDto> command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
