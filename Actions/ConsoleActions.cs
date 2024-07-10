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
                Console.Write("Enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                int? limit = 0;
                int? offset = 0;
                switch (choice)
                {
                    case 1:
                        while (true)
                        {
                            Console.Write("How many pokemon would you like to view? Leave blank for 20: ");
                            string userInput = Console.ReadLine();
                            if (userInput != null) {
                                try
                                {
                                    limit = Convert.ToInt32(userInput);
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Please input a whole number or press enter.");
                                    continue;
                                }
                            }
                            pokemonList = service.GetAllPokemon(offset, limit);
                            currentPosition = 20;
                            break;
                        }
                }
                PrintPokemon(pokemonList);
                continue;

                    case 2:
                    while (true)
                    {
                        Console.Write("How many pokemon would you like to view? Leave blank for 20: ");
                        string userInput = Console.ReadLine();
                        if (userInput == "")
                        {
                            pokemonList = service.GetPokemonOffset(currentPosition, 20);
                            break;
                        }

                        else
                        {
                            int limit = 0;
                            try
                            {
                                limit = Convert.ToInt32(userInput);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Please input a whole number or press enter.");
                                continue;
                            }
                            pokemonList = service.GetPokemonOffset(currentPosition, limit);
                            currentPosition += limit;
                            break;
                        }
                    }
                    PrintPokemon(pokemonList);
                    continue;

                case 3:
                    while (true)
                    {
                        Console.Write("How many pokemon would you like to view? Leave blank for 20: ");
                        string userInput = Console.ReadLine();
                        if (userInput == "")
                        {
                            pokemonList = service.GetPokemonOffset(currentPosition - 20, 20);
                            break;
                        }

                        else
                        {
                            int limit = 0;
                            try
                            {
                                limit = Convert.ToInt32(userInput);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Please input a whole number or press enter.");
                                continue;
                            }
                            pokemonList = service.GetPokemonOffset(currentPosition - limit, limit);
                            currentPosition -= limit;
                            break;
                        }
                    }
                    PrintPokemon(pokemonList);
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
                    Pokemon pokemon = service.GetPokemonById(pokemonId);
                    currentPosition = pokemonId;
                    Console.WriteLine(pokemon);
                    break;

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
    }
}
