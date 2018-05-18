using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eva.Core.Models;
using System.Linq.Expressions;

namespace Eva.Core.Repositories
{
    public interface IBookRepository
    {
        void Add(Book book);
        Book GetById(int id);
        IEnumerable<Book> GetAll(Expression<Func<Book, bool>> expr = null);
    }
}
