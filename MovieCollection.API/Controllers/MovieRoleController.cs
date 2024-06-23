﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Commands;
using MovieCollection.API.Query;
using MovieCollection.API.Controllers.Base;
using MovieCollection.Query.View;

namespace MovieCollection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieRoleController : CrudController<MovieRoleDto, MovieRoleView>
    {
        public MovieRoleController(IMediator mediator) : base(mediator)
        {
        }
    }
}
