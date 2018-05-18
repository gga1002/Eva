namespace Eva.Core.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public bool removed { get; set; }

        public void Remove()
        {
            removed = true;
        }
    }
}