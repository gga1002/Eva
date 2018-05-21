using Eva.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Eva.Core.Repositories
{
    public interface IIssueRepository
    {
        void Add(Issue issue);
        IEnumerable<Issue> Get(Expression<Func<Issue, bool>> expr);
    }
}