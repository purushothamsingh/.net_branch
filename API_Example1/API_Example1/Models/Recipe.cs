namespace API_Example1.Models
{
    public class Recipe
    {

        public string   Title { get; init; }

        public string Description { get; init; }

        public IEnumerable<string> Directions { get; init; }

        public IEnumerable<string> Ingredients { get; init; }

        public DateTime Update { get; init; }
    }
}
