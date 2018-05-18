using System;
using Eva.Core.Models;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Eva.Application
{
    public interface IBookService
    {
        void Add(Book book);

        IEnumerable<Book> GetAll(string filterBy =null, string orderBy = null);

        void Update(Book book);

        void Remove(int id);

    }
}