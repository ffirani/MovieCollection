using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Controllers.Base;

namespace MovieCollection.API.Controllers
{
    public class CastAndCrewController : CrudController<CastAndCrewDto>
    {
        public CastAndCrewController(IMediator mediator) : base(mediator)
        {
        }
    }
}
