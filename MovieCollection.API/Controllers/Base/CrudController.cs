using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Commands;
using MovieCollection.API.Error;
using MovieCollection.API.Query;
using MovieCollection.Query.View;
using MovieCollection.Query.View.Base;

namespace MovieCollection.API.Controllers.Base
{
    public class CrudController<T,TView> : Controller where TView : BaseView 
    {
        protected readonly IMediator _mediator;

        public CrudController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(CreateEntityResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [Authorize]
        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<CreateEntityResponse>> Create([FromBody] CreateEntityCommand<T> command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [Authorize]
        [Route("update")]
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateEntityCommand<T> command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [Authorize]
        [Route("delete")]
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DeleteEntityCommand<T> command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [Authorize]
        [Route("retrieve")]
        [HttpPost]
        public async Task<ActionResult<RetrieveEntityResponse<TView>>> Retrieve([FromBody] RetrieveEntityQuery<TView> command)
        {
            var reponse = await _mediator.Send(command);
            return Ok(reponse);
        }

        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [Authorize]
        [Route("retrieve-multiple")]
        [HttpPost]
        public async Task<ActionResult<RetrieveMultipleEntityResponse<TView>>> RetrieveMultiple([FromBody] RetrieveMultipleEntityQuery<TView> command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
