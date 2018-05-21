using System.Collections.Generic;
using Eva.Core.Models;

namespace Eva.Application
{
    public interface IGenreService
    {
        IEnumerable<Genre> Get(string filter = null);
    }
}