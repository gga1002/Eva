using Eva.Core.Repositories;

namespace Eva.Core
{
    public interface IUnitOfWork
    {
        IBookRepository Books { get; }
        void Complete();
    }
}
