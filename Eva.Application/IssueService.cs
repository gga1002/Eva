using Eva.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eva.Application
{
    public class IssueService : IIssueService
    {
        IUnitOfWork _unitOfWork;
        public IssueService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void checkOut(int bookId, string memberId)
        {
            var book = _unitOfWork.Books.GetById(bookId);
            if (book == null)
            {
                throw new Exception("Not Found.");
            }
            if (book.Quantity == 0)
            {
                throw new Exception("Book is not available.");
            }
            var issue = book.CheckOut(memberId);
            _unitOfWork.Issues.Add(issue);

        }

        public void checkin(int bookId, string memberId)
        {
            var issue = _unitOfWork.Issues
                            .Get(i => i.BookId == bookId
                                    && i.MemberId == memberId).SingleOrDefault();
            if (issue == null)
            {
                throw new Exception("Not Found.");
            }
            var book = _unitOfWork.Books.GetById(bookId);
            if (book == null)
            {
                throw new Exception("Not Found.");
            }
            book.CheckIn();
            issue.ReturnDate = DateTime.Now;
            _unitOfWork.Complete();
        }

    }
}
