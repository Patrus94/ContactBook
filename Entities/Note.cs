namespace ContactBook.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int ContactId { get; set; }

        public Contact Contact { get; set; }
    }
}
