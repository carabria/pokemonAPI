using Pokemon_CLI.Models;
using RestSharp;

namespace Pokemon_CLI.Services
{
    public class PokemonServices
    {
        private static RestClient client = null;
        private const string API_URL = "https://pokeapi.co/api/v2/pokemon";

        public PokemonServices()
        {
            if (client == null)
            {
                client = new RestClient();
            }
        }

        public List<Pokemon> GetAllPokemon(int? offset, int? limit) {
            string requestString = API_URL;
            if (offset != 0) {
                requestString += $"?offset={offset}";
            }
            RestRequest request = new RestRequest(requestString);
            if (limit != 0) {
                request.AddQueryParameter("limit", limit.ToString());
            }
            RestResponse<ListPokemon> response = client.Execute<ListPokemon>(request);
            ListPokemon pokemonObject = response.Data;
            List<Pokemon> pokemonList = generatePokemonList(pokemonObject);
            return pokemonList;
        }


        private List<Pokemon> generatePokemonList(ListPokemon pokemonObject)
        {
            List<Pokemon> pokemonList = new List<Pokemon>();
            foreach (Result result in pokemonObject.results) {
                Pokemon pokemon = new Pokemon {
                    name = result.name,
                    url = result.url
                };
                string url = result.url;
                int pokemonIndex = url.IndexOf("pokemon");
                string pokemonString = url.Substring(pokemonIndex);
                int slashIndex = pokemonString.IndexOf("/");
                string numberPlusSlash = pokemonString.Substring(slashIndex + 1);
                string number = numberPlusSlash.Remove(numberPlusSlash.Length - 1, 1);
                pokemon.id = int.Parse(number);
                pokemonList.Add(pokemon);
            }
            return pokemonList;
        }

        public PokemonDetail GetPokemonById(int id) {
            RestRequest request = new RestRequest($"{API_URL}/{id}");
            RestResponse<PokemonDetail> response = client.Execute<PokemonDetail>(request);
            return response.Data;
        }
    }
}