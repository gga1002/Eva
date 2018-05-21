using System;

namespace Eva.Core.Models
{
     public class Payment
    {
        public int Id { get; set; }

        public Book Book { get; set; }
        public int BookId { get; set; }

        public ApplicationUser Member { get; set; }
        public int MemberId { get; set; }

        public DateTime paymentDate { get; set; }       
        
    }
}
