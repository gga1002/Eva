using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eva.Core;
using Eva.Core.Models;
using Eva.Core.Repositories;
using System.Linq.Expressions;

namespace Eva.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IApplicationDbContext _context;
        public BookRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
        }
        
        public Book GetById(int id) {

            return _context.Books.SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetAll(Expression<Func<Book, bool>> expr = null)
        {
            if (expr != null)
                return _context.Books.Where(expr);
            return _context.Books;
        }
    }
}
