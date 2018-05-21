using System;
using Eva.Core;
using Eva.Core.Repositories;
using Eva.Persistence.Repositories;

namespace Eva.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Books = new BookRepository(_context);
            Genres = new GenreRepository(_context);
            Issues = new IssueRepository(_context);
            Payments = new PaymentRepository(_context);
        }

        public IBookRepository Books { get; private set; }

        public IGenreRepository Genres { get; private set; }

        public IIssueRepository Issues {get; private set; }

        public IPaymentRepository Payments { get; private set; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
