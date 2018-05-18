using System.Data.Entity;
using Eva.Core.Models;

namespace Eva.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Book> Books { get; set; }
    }
}