using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Eva.Core.Models;
using Eva.Core.Repositories;
using System.Linq;

namespace Eva.Persistence.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        private readonly IApplicationDbContext _context;
        public IssueRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Issue issue)
        {
            _context.Issues.Add(issue);
        }

        public IEnumerable<Issue> Get(Expression<Func<Issue, bool>> expr)
        {
            return _context.Issues.Where(expr);

        }
    }
}
