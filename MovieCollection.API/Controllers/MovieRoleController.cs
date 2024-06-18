using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Commands;
using MovieCollection.API.Query;

namespace MovieCollection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieRoleController:ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieRoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<CreateEntityResponse>> Create([FromBody] CreateEntityCommand<MovieRoleDto> command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [Route("update")]
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateEntityCommand<MovieRoleDto> command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [Route("delete")]
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DeleteEntityCommand<MovieRoleDto> command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [Authorize]
        [Route("retrieve")]
        [HttpGet]
        public async Task<ActionResult<RetrieveEntityResponse<MovieRoleDto>>> Retrieve([FromBody] RetrieveEntityQuery<MovieRoleDto> command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [Authorize]
        [Route("retrieve-multiple")]
        [HttpGet]
        public async Task<ActionResult<RetrieveMultipleEntityResponse<MovieRoleDto>>> RetrieveMultiple([FromBody] RetrieveMultipleEntityQuery<MovieRoleDto> command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
