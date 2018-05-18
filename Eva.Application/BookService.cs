using Eva.Core;
using Eva.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.ComponentModel;

namespace Eva.Application
{
    public class BookService : IBookService
    {
        IUnitOfWork _unitOfWork;
        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Book book)
        {
            _unitOfWork.Books.Add(book);
            _unitOfWork.Complete();
        }

        public IEnumerable<Book> GetAll(string filterBy = null, string orderBy = null)
        {
            Expression<Func<Book, bool>> expr = null;
            if (string.IsNullOrEmpty(filterBy))
                expr = (b => b.ISBN.Contains(filterBy) || b.Name.Contains(filterBy));

            var propertyName = TypeDescriptor
                                        .GetProperties(typeof(Book))
                                        .Find(orderBy, true);

            var result = _unitOfWork.Books
                                    .GetAll(expr)
                                    .OrderBy(b => propertyName.GetValue(b));
            return result;
        }

        public void Remove(int id)
        {
            var book = _unitOfWork.Books.GetById(id);
            book.Remove();
            _unitOfWork.Complete();
        }

        public void Update(Book book)
        {
            var result = _unitOfWork.Books.GetById(book.Id);
            result = book;
            _unitOfWork.Complete();
        }
    }
}
