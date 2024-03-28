using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console;
using Alura.Adopet.Console.Commands;
using Alura.Adopet.Console.Services;

var httpPetClient = new HttpPetClient(new AdopetAPIClientFactory().CreateClient("adopet"));

Dictionary<string, ICommand> systemCommands = new()
{
    {"help",new Help()},
    {"import",new Import(httpPetClient)},
    {"list",new List(httpPetClient)},
    {"show",new Show()},
};

Console.ForegroundColor = ConsoleColor.Green;

try
{
    string command = args[0].Trim();
    if (systemCommands.ContainsKey(command))
    {
        ICommand? cmd = systemCommands[command];
        await cmd.ExecuteAsync(args);
    } else
    {
        Console.WriteLine("Invalid command");
    }
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}