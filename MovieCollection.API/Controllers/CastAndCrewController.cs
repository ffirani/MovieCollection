using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Controllers.Base;
using MovieCollection.Domain.Models;
using MovieCollection.Query.View;

namespace MovieCollection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastAndCrewController : CrudController<CastAndCrewDto, CastAndCrewView>
    {
        public CastAndCrewController(IMediator mediator) : base(mediator)
        {
        }
    }
}
