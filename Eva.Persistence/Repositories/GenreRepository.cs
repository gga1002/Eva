using System.Collections.Generic;
using Eva.Core.Models;
using Eva.Core.Repositories;
using System.Linq.Expressions;
using System;
using System.Linq;

namespace Eva.Persistence.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly IApplicationDbContext _context;
        public GenreRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> Get(Expression<Func<Genre, bool>> expr = null)
        {
            if(expr != null)
            {
                return _context.Genres.Where(expr);
            }
            return _context.Genres;
        }
    }
}
