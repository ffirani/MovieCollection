﻿using MovieCollection.Domain.Models;
using MovieCollection.Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Domain.Repository
{
    public interface IMovieSelectionRepository : IRepository<MovieSelection>
    {
        Task AssociateMovieAsync(Guid selectionId, Guid movieId);
        Task DisassociateMovieAsync(Guid selectionId, Guid movieId);
    }
}
