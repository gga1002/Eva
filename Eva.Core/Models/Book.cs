using System;
using System.ComponentModel.DataAnnotations;
namespace Eva.Core.Models
{
    

    public class Book
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(155)]
        public string Name { get; set; }

        [Required]
        [StringLength(25)]
        public string ISBN { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public int Quantity { get; set; }

        public bool removed { get; set; }

        public void Remove()
        {
            Quantity = 0;
            removed = true;
        }

        public Issue CheckOut(string userId)
        {
            Quantity += -1;
            return new Issue()
            {
                BookId = Id,
                MemberId = userId,
                IssueDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddDays(10)
            };
        }

        public void CheckIn()
        {
            Quantity += 1;
        }

    }
}