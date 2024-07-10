namespace Pokemon_CLI.Models
{
    public class ListPokemon
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<Result> results { get; set; }
    }

    public class Result
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}
