namespace Pokemon_CLI.Models
{
    public class PokemonDetail
    {
        public Dictionary<string, string> species { get; set; }

        public Dictionary<string, string> sprites { get; set; }

        public override string ToString()
        {
            string backDefault = sprites["back_default"];
            string frontDefault = sprites["front_default"];

            return $"name={species["name"]} }}\n\tback picture={backDefault}\n\tfront picture={frontDefault}";
        }
    }
}