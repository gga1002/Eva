using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eva.Core.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public Book Book { get; set; }
        public ApplicationUser Member { get; set; }

    }
}
