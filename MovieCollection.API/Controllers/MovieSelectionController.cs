using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieCollection.API.Commands;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Controllers.Base;
using MovieCollection.API.Error;
using MovieCollection.API.Query;
using MovieCollection.Domain.Models;
using MovieCollection.Query.View;


namespace MovieCollection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieSelectionController : CrudController<MovieSelectionDto, MovieSelectionView>
    {

        public MovieSelectionController(IMediator mediator):base(mediator) 
        { 
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [Route("associate")]
        [HttpPost]
        public async Task<ActionResult> AssociateToSelection(AssociateToSelectionCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [Route("disassociate")]
        [HttpPost]
        public async Task<ActionResult> DisassociateFromSelection(DisassociateFromSelectionCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
