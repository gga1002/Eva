using Eva.Core;
using Eva.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Eva.Application
{
    public class GenreService : IGenreService
    {
        IUnitOfWork _unitOfWork;
        public GenreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Genre> Get(string filter = null)
        {
            Expression<Func<Genre, bool>> expr = null;
            if (!string.IsNullOrEmpty(filter))
            {
                expr = (b => b.Name.Contains(filter));
            }

            return _unitOfWork.Genres.Get(expr);
        }
    }
}
