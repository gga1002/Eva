using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Eva.Core.Models;

namespace Eva.Core.Repositories
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> Get(Expression<Func<Genre, bool>> expr = null);
    }
}