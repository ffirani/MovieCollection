﻿using MediatR;

namespace MovieCollection.API.Commands
{
    public class DisassociateFromSelectionCommand:IRequest
    {
        public Guid MovieId { get; set; }
        public Guid SelectionId { get; set; }
    }
}
