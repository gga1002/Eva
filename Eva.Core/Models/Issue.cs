using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eva.Core.Models
{
    public class Issue
    {
        public int Id { get; set; }

        public Book Book { get; set; }
        [Required]
        public int BookId { get; set; }

        public ApplicationUser Member { get; set; }
        [Required]
        public string MemberId { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        
        

    }
}
