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

        public Result[] GetAllPokemon(int? limit)
        {
            RestRequest request = new RestRequest($"{API_URL}");
            if (limit.HasValue) {
                request.AddQueryParameter("limit", limit.ToString());
            }
            RestResponse<PokemonObject> response = client.Execute<PokemonObject>(request);
            return response.Data.Results;
        }

        public Result[] GetNextPokemon(int offset, int? limit) 
        {
            RestRequest request = new RestRequest($"{API_URL}");
            request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue) {
                request.AddQueryParameter("limit", limit.ToString());
            }
            RestResponse<PokemonObject> response = client.Execute<PokemonObject>(request);
            return response.Data.Results;
        }
        
        public Result[] GetPreviousPokemon(int offset, int? limit) 
        {
            RestRequest request = new RestRequest($"{API_URL}");
            request.AddQueryParameter("offset", offset.ToString());
            if (limit.HasValue) {
                request.AddQueryParameter("limit", limit.ToString());
            }
            RestResponse<PokemonObject> response = client.Execute<PokemonObject>(request);
            return response.Data.Results;
        }
    }
}