using Eva.Core.Models;
using Eva.Core.Repositories;

namespace Eva.Persistence.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IApplicationDbContext _context;
        public PaymentRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Issue issue)
        {
            _context.Issues.Add(issue);
        }
    }
}
