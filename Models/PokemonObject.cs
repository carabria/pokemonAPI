namespace Pokemon_CLI.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Cries[] Cries { get; set; }
        public Species[] Species { get; set; }
        public Sprites[] Sprites { get; set; }
    }

    public class Species
    {
        public string Name { get; set; }
        public Uri Url { get; set; }
    }

    public class Cries
    {
        public Uri Latest { get; set; }
        public Uri Legacy { get; set; }
    }

    public class Sprites
    {
        public Uri BackDefault { get; set; }
        public object BackFemale { get; set; }
        public Uri BackShiny { get; set; }
        public object BackShinyFemale { get; set; }
        public Uri FrontDefault { get; set; }
        public object FrontFemale { get; set; }
        public Uri FrontShiny { get; set; }
        public object FrontShinyFemale { get; set; }
        public Sprites Animated { get; set; }
    }
}