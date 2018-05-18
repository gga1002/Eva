using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eva.Core.Models
{
     public class Payment
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime paymentDate { get; set; }

        public Book Book { get; set; }
        public ApplicationUser Member { get; set; }
    }
}
