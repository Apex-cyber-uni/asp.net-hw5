namespace less5.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int Rating { get; set; }
        public bool IsCompleted { get; set; }
    }
}
