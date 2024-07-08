// See https://aka.ms/new-console-template for more information
using Pokemon_CLI.Services;
using Pokemon_CLI.Models;

public class Menu
{
    public static void Main() {
        Result[] pokemonList = new Result[20];
        PokemonServices service = new PokemonServices();

        while (true) {
            Console.WriteLine("Let's catch some pokemon!");
            Console.WriteLine("1: get first group of Pokemon");
            Console.WriteLine("2: get previous group of 20");
            Console.WriteLine("3: get next group of 20");
            Console.WriteLine("4: quit");
            Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice) { 
                case 1:
                    while (true) {
                        Console.Write("How many pokemon would you like to view? Leave blank for 20: ");
                        string userInput = Console.ReadLine();
                        if (userInput == "") {
                            pokemonList = service.GetAllPokemon(null);
                            break;
                        }
                        else {
                            int limit = 0;
                            try {
                                limit = Convert.ToInt32(userInput);
                            }
                            catch (FormatException) {
                                Console.WriteLine("Please input a whole number or press enter.");
                                continue;
                            }
                            pokemonList = service.GetAllPokemon(limit);
                            break;
                        }
                    }
                    foreach (Result pokemon in pokemonList) {
                        Console.WriteLine($"{pokemon.Name} {pokemon.Url}");
                    }
                    continue;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }
    }
}