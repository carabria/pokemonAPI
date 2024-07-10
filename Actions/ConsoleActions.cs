using Pokemon_CLI.Services;
using Pokemon_CLI.Models;

namespace Pokemon_CLI.Actions
{
    public class ConsoleActions
    {
        public void DisplayMenu(PokemonServices service)
        {
            List<Pokemon> pokemonList = new List<Pokemon>();
            int currentPosition = 0;
            while (true)
            {
                Console.WriteLine("Let's catch some pokemon!");
                Console.WriteLine("1: View Pokemon starting from 0");
                Console.WriteLine($"2: View Next Pokemon from current position ({currentPosition})");
                Console.WriteLine($"3: View Previous Pokemon from current position ({currentPosition})");
                Console.WriteLine("4: View a specific Pokemon by ID");
                Console.WriteLine("5: Exit program");
                Console.Write("Enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                int limit = 0;
                int offset = 0;
                switch (choice)
                {
                    case 1:
                        limit = this.InputLimit();
                        offset = 0; // this action starts exclusively from 0
                        pokemonList = service.GetAllPokemon(offset, limit);
                        currentPosition = limit;
                        this.PrintPokemon(pokemonList);
                        continue;

                    case 2:
                        limit = this.InputLimit();
                        offset = currentPosition;
                        currentPosition += limit;
                        pokemonList = service.GetAllPokemon(offset, limit);
                        this.PrintPokemon(pokemonList);
                        continue;

                    case 3:
                        limit = this.InputLimit();
                        offset = currentPosition - limit;
                        currentPosition -= limit;
                        pokemonList = service.GetAllPokemon(offset, limit);
                        this.PrintPokemon(pokemonList);
                        continue;

                    case 4:
                        int pokemonId;
                        while (true)
                        {
                            Console.WriteLine("Which pokemon would you like to view?");
                            try
                            {
                                pokemonId = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Please input a whole number.");
                                continue;
                            }
                            break;
                        }
                        PokemonDetail pokemon = service.GetPokemonById(pokemonId);
                        currentPosition = pokemonId;
                        Console.WriteLine(pokemon.ToString());
                        continue;

                    case 5:
                        break;
                }
            }
        }
        public void PrintPokemon(List<Pokemon> pokemonList)
        {
            foreach (Pokemon pokemon in pokemonList)
            {
                Console.WriteLine($"{pokemon.name} {pokemon.url}");
            }
        }

        public int InputLimit()
        {
            int limit = 0;
            while (true)
            {
                Console.Write("How many pokemon would you like to view? Leave blank for 20: ");
                string userInput = Console.ReadLine();
                if (userInput != "")
                {
                    try
                    {
                        limit = Convert.ToInt32(userInput);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please input a whole number or press enter.");
                        continue;
                    }
                    break;
                }
                else
                {
                    limit = 20;
                    break;
                }
            }
            return limit;
        }
    }
}
