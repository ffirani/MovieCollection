using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieCollection.API.Commands;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Query;


namespace MovieCollection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieSelectionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieSelectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<CreateEntityResponse>> Create([FromBody] CreateEntityCommand<MovieSelectionDto> command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [Authorize]
        [Route("update")]
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateEntityCommand<MovieSelectionDto> command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [Authorize]
        [Route("delete")]
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DeleteEntityCommand<MovieSelectionDto> command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [Authorize]
        [Route("retrieve")]
        [HttpGet]
        public async Task<ActionResult<RetrieveEntityResponse<MovieSelectionDto>>> Retrieve([FromBody] RetrieveEntityQuery<MovieSelectionDto> command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [Authorize]
        [Route("retrieve-multiple")]
        [HttpGet]
        public async Task<ActionResult<RetrieveMultipleEntityResponse<MovieSelectionDto>>> RetrieveMultiple([FromBody] RetrieveMultipleEntityQuery<MovieSelectionDto> command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [Route("associate")]
        [HttpPost]
        public Task<ActionResult> AssociateToCollection(AssociateToSelectioCommand command)
        {
            throw new NotImplementedException();
        }

        [Route("disassociate")]
        [HttpPost]
        public Task<ActionResult> DisassociateFromCollection(DisassociateFromSelectionCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
