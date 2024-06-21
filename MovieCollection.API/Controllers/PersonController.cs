using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Commands;
using MovieCollection.API.Query;
using MovieCollection.API.Controllers.Base;

namespace MovieCollection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController:CrudController<PersonDto>
    {
        public PersonController(IMediator mediator):base(mediator)
        {
        }
    }
}
