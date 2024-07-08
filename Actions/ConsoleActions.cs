using Pokemon_CLI.Services;
using Pokemon_CLI.Models;

namespace Pokemon_CLI.Actions
{
    //TODO: make the -/+ to for next/previous methods be inclusive
    public class ConsoleActions
    {
        public void DisplayMenu(PokemonServices service)
        {
            Result[] pokemonList = new Result[20];
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
                switch (choice)
                {
                    case 1:
                        while (true)
                        {
                            Console.Write("How many pokemon would you like to view? Leave blank for 20: ");
                            string userInput = Console.ReadLine();
                            if (userInput == "")
                            {
                                pokemonList = service.GetAllPokemon();
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
                                pokemonList = service.GetPokemonLimit(limit);
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
                                pokemonList = service.GetPokemonOffset(currentPosition-20, 20);
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
                                pokemonList = service.GetPokemonOffset(currentPosition-limit, limit);
                                currentPosition -= limit;
                                break;
                            }
                        }
                        PrintPokemon(pokemonList);
                        continue;

                    case 4:
                    int pokemonId;
                        while (true) {
                            Console.WriteLine("Which pokemon would you like to view?");
                            try {
                            pokemonId = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException) {
                                Console.WriteLine("Please input a whole number.");
                                continue;
                            }
                            break;
                        }
                        Console.WriteLine(service.GetPokemonByID(pokemonId));
                        currentPosition = pokemonId;
                        break;
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
