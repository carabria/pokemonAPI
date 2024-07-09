using Pokemon_CLI.Models;
using RestSharp;

namespace Pokemon_CLI.Services
{
    public class PokemonServices
    {
        private static RestClient client = null;
        private static string API_URL = "https://pokeapi.co/api/v2/pokemon";

        public PokemonServices()
        {
            if (client == null)
            {
                client = new RestClient();
            }
        }


        public Result [] GetAllPokemon() {
            RestRequest request = new RestRequest($"{API_URL}");
            RestResponse<ListPokemon> response = client.Execute<ListPokemon>(request);
            return response.Data.Results;

        }
        public Result[] GetPokemonLimit(int limit)
        {
            RestRequest request = new RestRequest($"{API_URL}");
            request.AddQueryParameter("limit", limit.ToString());
            RestResponse<ListPokemon> response = client.Execute<ListPokemon>(request);
            return response.Data.Results;
        }

        public Result[] GetPokemonOffset(int offset, int? limit) 
        {
            RestRequest request = new RestRequest($"{API_URL}");
            request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue) {
                request.AddQueryParameter("limit", limit.ToString());
            }
            RestResponse<ListPokemon> response = client.Execute<ListPokemon>(request);
            return response.Data.Results;
        }
        public Pokemon GetPokemonById(int id) {
            RestRequest request = new RestRequest($"{API_URL}/{id}");
            RestResponse<Pokemon> response = client.Execute<Pokemon>(request);
            return response.Data;
        }
    }
}