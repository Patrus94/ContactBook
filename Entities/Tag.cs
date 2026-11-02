namespace ContactBook.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<ContactTag> ContactTags { get; set; } = new List<ContactTag>();

    }
}
