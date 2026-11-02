namespace ContactBook.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
   

        public List<Note> Notes { get; set; } = new List<Note>();
        public List<ContactTag> ContactTags { get; set; } = new List<ContactTag>();

    }
}

