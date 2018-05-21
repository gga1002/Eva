using Eva.Core.Repositories;

namespace Eva.Core
{
    public interface IUnitOfWork
    {
        IIssueRepository Issues { get; }
        IBookRepository Books { get; }
        IGenreRepository Genres { get; }
        IPaymentRepository Payments { get;}

        void Complete();
    }
}
