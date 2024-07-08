using Pokemon_CLI.Services;
using Pokemon_CLI.Models;

namespace Pokemon_CLI.Actions
{
    public class ConsoleActions
    {
        public void DisplayMenu(PokemonServices service)
        {
            Result[] pokemonList = new Result[20];
            int currentPosition = 0;
            while (true)
            {
                Console.WriteLine("Let's catch some pokemon!");
                Console.WriteLine("1: View Pokemon starting from the first");
                Console.WriteLine($"2: View Next Pokemon from current position ({currentPosition})");
                Console.WriteLine($"3: View Previous Pokemon from current position ({currentPosition})");
                Console.WriteLine("4: View a specific Pokemon");
                Console.Write("Enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        while (true)
                        {
                            Console.Write("How many pokemon would you like to view? Leave blank for 20: ");
                            string userInput = Console.ReadLine();
                            if (userInput == "")
                            {
                                pokemonList = service.GetAllPokemon(null);
                                currentPosition = 20;
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
                                pokemonList = service.GetAllPokemon(limit);
                                currentPosition = limit;
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
                                pokemonList = service.GetNextPokemon(currentPosition, null);
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
                                pokemonList = service.GetNextPokemon(currentPosition, limit);
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
                                pokemonList = service.GetNextPokemon(currentPosition, null);
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
                                pokemonList = service.GetNextPokemon(currentPosition, limit);
                                currentPosition += limit;
                                break;
                            }
                        }
                        PrintPokemon(pokemonList);
                        continue;

                    case 4:
                        Console.WriteLine("Which pokemon would you like to view?");
                        int pokemonId = Convert.ToInt32(Console.ReadLine());
                        continue;

                    case 5:
                        break;
                }
            }
        }

        public void PrintPokemon(Result[] pokemonList) {
            foreach (Result pokemon in pokemonList)
            {
                Console.WriteLine($"{pokemon.Name} {pokemon.Url}");
            }
        }
    }
}
