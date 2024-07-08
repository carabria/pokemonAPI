using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Result[] GetAllPokemon()
        {
            RestRequest request = new RestRequest($"{API_URL}");
            RestResponse<PokemonObject> response = client.Execute<PokemonObject>(request);
            return response.Data.Results;
        }
    }
}