namespace BehavioralDessignPatternApp.Model
{
    public class Book : Entity
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }

        public Book(int id, string title, string author, string genre) :base(id)
        {
            Title = title;
            Author = author;
            Genre = genre;
        }
        public Book() { }

        public override string? ToString()
        {
            return $"Id: {Id} Title: {Title}, Author: {Author}, Genre: {Genre}";
        }
    }
}
