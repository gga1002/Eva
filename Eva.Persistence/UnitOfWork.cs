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
        }

        public IBookRepository Books { get; private set; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
