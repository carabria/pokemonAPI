// See https://aka.ms/new-console-template for more information
using Pokemon_CLI.Services;
using Pokemon_CLI.Actions;

public class Pokemon
{
    public static void Main()
    {
        ConsoleActions actions = new ConsoleActions();
        PokemonServices service = new PokemonServices();
        actions.DisplayMenu(service);
    }
}