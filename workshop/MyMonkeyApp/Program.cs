
using MyMonkeyApp;

namespace MyMonkeyApp;

internal class Program
{
    private static readonly string[] asciiArts = new[]
    {
        "  (\\__/)",
        "  (o.o )",
        "  (> < ) Monkey!",
        "  /\\_/\\  ((\'\'\'))",
        " (='.'=) ( o.o )",
        " (\"_\") ( > < )"
    };

    private static void ShowRandomAsciiArt()
    {
        var random = new Random();
        var art = asciiArts[random.Next(asciiArts.Length)];
        Console.WriteLine(art);
    }

    public static async Task Main()
    {
        while (true)
        {
            Console.WriteLine("\nMonkey App Menu:");
            Console.WriteLine("1. List all monkeys");
            Console.WriteLine("2. Get details for a specific monkey by name");
            Console.WriteLine("3. Get a random monkey");
            Console.WriteLine("4. Exit app");
            Console.Write("Select an option (1-4): ");

            var userInput = Console.ReadLine();
            Console.WriteLine();

            switch (userInput)
            {
                case "1":
                    var monkeys = await MonkeyHelper.GetMonkeysAsync();
                    ShowRandomAsciiArt();
                    Console.WriteLine("| Name                 | Location                        | Population |");
                    Console.WriteLine("|----------------------|---------------------------------|------------|");
                    foreach (var monkey in monkeys)
                    {
                        Console.WriteLine($"| {monkey.Name,-20} | {monkey.Location,-31} | {monkey.Population,10} |");
                    }
                    break;
                case "2":
                    Console.Write("Enter monkey name: ");
                    var name = Console.ReadLine();
                    var foundMonkey = await MonkeyHelper.GetMonkeyByNameAsync(name ?? string.Empty);
                    ShowRandomAsciiArt();
                    if (foundMonkey is not null)
                    {
                        Console.WriteLine($"Name: {foundMonkey.Name}");
                        Console.WriteLine($"Location: {foundMonkey.Location}");
                        Console.WriteLine($"Population: {foundMonkey.Population}");
                        Console.WriteLine($"Details: {foundMonkey.Details}");
                        Console.WriteLine($"Image: {foundMonkey.Image}");
                    }
                    else
                    {
                        Console.WriteLine("Monkey not found.");
                    }
                    break;
                case "3":
                    var randomMonkey = await MonkeyHelper.GetRandomMonkeyAsync();
                    ShowRandomAsciiArt();
                    if (randomMonkey is not null)
                    {
                        Console.WriteLine($"Name: {randomMonkey.Name}");
                        Console.WriteLine($"Location: {randomMonkey.Location}");
                        Console.WriteLine($"Population: {randomMonkey.Population}");
                        Console.WriteLine($"Details: {randomMonkey.Details}");
                        Console.WriteLine($"Image: {randomMonkey.Image}");
                        Console.WriteLine($"Random monkey accessed {MonkeyHelper.GetRandomMonkeyAccessCount()} times.");
                    }
                    else
                    {
                        Console.WriteLine("No monkeys available.");
                    }
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
