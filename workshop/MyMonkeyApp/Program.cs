using MyMonkeyApp.Helpers;
using MyMonkeyApp.Models;

namespace MyMonkeyApp;

/// <summary>
/// Main program class for the Monkey Console Application.
/// </summary>
public class Program
{
    /// <summary>
    /// Main entry point of the application.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task Main(string[] args)
    {
        Console.Clear();
        ShowWelcome();

        bool running = true;
        while (running)
        {
            DisplayMenu();
            var choice = Console.ReadLine();

            switch (choice?.Trim().ToUpper())
            {
                case "1":
                    await ListAllMonkeysAsync();
                    break;
                case "2":
                    await GetMonkeyByNameAsync();
                    break;
                case "3":
                    await GetRandomMonkeyAsync();
                    break;
                case "4":
                case "EXIT":
                case "QUIT":
                    running = false;
                    ShowGoodbye();
                    break;
                default:
                    Console.WriteLine("\n❌ Invalid option. Please try again.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\n🎯 Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    /// <summary>
    /// Displays the welcome message and banner.
    /// </summary>
    private static void ShowWelcome()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(AsciiArt.GetRandomBanner());
        Console.ResetColor();
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Welcome to the Monkey Explorer Console App!");
        Console.WriteLine("Discover fascinating primates from around the world! 🌍");
        Console.ResetColor();
        
        Console.WriteLine(AsciiArt.GetRandomMonkeyArt());
        Console.WriteLine(AsciiArt.GetSeparator());
    }

    /// <summary>
    /// Displays the main menu options.
    /// </summary>
    private static void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine(AsciiArt.GetMenuDecoration());
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("🍌 MONKEY MENU 🍌");
        Console.ResetColor();
        Console.WriteLine("1. 📋 List all monkeys");
        Console.WriteLine("2. 🔍 Get details for a specific monkey by name");
        Console.WriteLine("3. 🎲 Get a random monkey");
        Console.WriteLine("4. 🚪 Exit app");
        Console.WriteLine(AsciiArt.GetMenuDecoration());
        Console.Write("\n🤔 Please select an option (1-4): ");
    }

    /// <summary>
    /// Lists all available monkeys asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    private static async Task ListAllMonkeysAsync()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("📋 ALL AVAILABLE MONKEYS");
        Console.ResetColor();
        Console.WriteLine(AsciiArt.GetSeparator());

        await Task.Run(() =>
        {
            var monkeys = MonkeyHelper.GetAllMonkeys();
            var index = 1;

            foreach (var monkey in monkeys)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{index}. {monkey.Name}");
                Console.ResetColor();
                Console.WriteLine($"   📍 Location: {monkey.Location}");
                Console.WriteLine($"   👥 Population: {monkey.Population:N0}");
                Console.WriteLine($"   📝 Details: {monkey.Details}");
                index++;
            }
        });

        Console.WriteLine($"\n🎯 Total monkeys: {MonkeyHelper.GetAllMonkeys().Count()}");
        Console.WriteLine($"🎲 Random monkey selections: {MonkeyHelper.GetRandomAccessCount()}");
    }

    /// <summary>
    /// Gets details for a specific monkey by name asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    private static async Task GetMonkeyByNameAsync()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("🔍 FIND MONKEY BY NAME");
        Console.ResetColor();
        Console.WriteLine(AsciiArt.GetSeparator());

        Console.Write("\n🐵 Enter monkey name: ");
        var name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("❌ Please enter a valid monkey name.");
            return;
        }

        await Task.Run(() =>
        {
            var monkey = MonkeyHelper.FindMonkeyByName(name);

            if (monkey != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n✅ Found: {monkey.Name}!");
                Console.ResetColor();
                DisplayMonkeyDetails(monkey);
            }
            else
            {
                Console.WriteLine($"\n❌ No monkey found with the name '{name}'.");
                Console.WriteLine("\n🔍 Available monkeys:");
                var allMonkeys = MonkeyHelper.GetAllMonkeys();
                foreach (var m in allMonkeys)
                {
                    Console.WriteLine($"   • {m.Name}");
                }
            }
        });
    }

    /// <summary>
    /// Gets a random monkey asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    private static async Task GetRandomMonkeyAsync()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("🎲 RANDOM MONKEY GENERATOR");
        Console.ResetColor();
        Console.WriteLine(AsciiArt.GetSeparator());

        Console.WriteLine("\n🎪 Selecting a random monkey for you...");
        
        // Add a small delay for dramatic effect
        await Task.Delay(1000);

        var randomMonkey = await Task.Run(() => MonkeyHelper.GetRandomMonkey());

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"\n🎉 You got: {randomMonkey.Name}!");
        Console.ResetColor();
        
        Console.WriteLine(AsciiArt.GetRandomMonkeyArt());
        DisplayMonkeyDetails(randomMonkey);
        
        Console.WriteLine($"\n📊 This is random selection #{MonkeyHelper.GetRandomAccessCount()}");
    }

    /// <summary>
    /// Displays detailed information about a monkey.
    /// </summary>
    /// <param name="monkey">The monkey to display details for.</param>
    private static void DisplayMonkeyDetails(Monkey monkey)
    {
        Console.WriteLine($"\n📍 Location: {monkey.Location}");
        Console.WriteLine($"👥 Population: {monkey.Population:N0}");
        Console.WriteLine($"🌍 Coordinates: {monkey.Latitude:F1}°, {monkey.Longitude:F1}°");
        Console.WriteLine($"📝 Details: {monkey.Details}");
        if (!string.IsNullOrEmpty(monkey.Image))
        {
            Console.WriteLine($"🖼️  Image: {monkey.Image}");
        }
    }

    /// <summary>
    /// Displays the goodbye message.
    /// </summary>
    private static void ShowGoodbye()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(AsciiArt.GetRandomMonkeyArt());
        Console.WriteLine("🍌 Thanks for exploring the monkey world! 🍌");
        Console.WriteLine("🌿 See you next time, fellow primate enthusiast! 🌿");
        Console.ResetColor();
        Console.WriteLine(AsciiArt.GetSeparator());
    }
}
