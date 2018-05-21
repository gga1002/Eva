using System.Data.Entity;
using Eva.Core.Models;

namespace Eva.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Issue> Issues { get; set; }
        DbSet<Payment> Payments { get; set; }
        
    }
}