using MyMonkeyApp.Models;

namespace MyMonkeyApp.Helpers;

/// <summary>
/// Static helper class for managing monkey data and operations.
/// </summary>
public static class MonkeyHelper
{
    private static readonly List<Monkey> _monkeys;
    private static int _randomAccessCount = 0;

    /// <summary>
    /// Static constructor to initialize the monkey data.
    /// </summary>
    static MonkeyHelper()
    {
        _monkeys = InitializeMonkeys();
    }

    /// <summary>
    /// Gets all available monkeys.
    /// </summary>
    /// <returns>A collection of all monkeys.</returns>
    public static IEnumerable<Monkey> GetAllMonkeys()
    {
        return _monkeys.AsReadOnly();
    }

    /// <summary>
    /// Gets a random monkey and increments the access count.
    /// </summary>
    /// <returns>A randomly selected monkey.</returns>
    public static Monkey GetRandomMonkey()
    {
        var random = new Random();
        var randomMonkey = _monkeys[random.Next(_monkeys.Count)];
        _randomAccessCount++;
        return randomMonkey;
    }

    /// <summary>
    /// Finds a monkey by name (case-insensitive search).
    /// </summary>
    /// <param name="name">The name of the monkey to find.</param>
    /// <returns>The monkey if found; otherwise, null.</returns>
    public static Monkey? FindMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        return _monkeys.FirstOrDefault(m => 
            string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets the count of times a random monkey has been accessed.
    /// </summary>
    /// <returns>The number of random monkey accesses.</returns>
    public static int GetRandomAccessCount()
    {
        return _randomAccessCount;
    }

    /// <summary>
    /// Initializes the collection of monkeys with sample data.
    /// </summary>
    /// <returns>A list of initialized monkeys.</returns>
    private static List<Monkey> InitializeMonkeys()
    {
        return new List<Monkey>
        {
            new Monkey
            {
                Name = "Baboon",
                Location = "Africa & Arabia",
                Details = "Highly social primates that live in troops and have complex social hierarchies.",
                Image = "https://example.com/baboon.jpg",
                Population = 200000,
                Latitude = 0.0,
                Longitude = 20.0
            },
            new Monkey
            {
                Name = "Capuchin",
                Location = "Central & South America",
                Details = "Intelligent monkeys known for their problem-solving abilities and tool use.",
                Image = "https://example.com/capuchin.jpg",
                Population = 150000,
                Latitude = -10.0,
                Longitude = -60.0
            },
            new Monkey
            {
                Name = "Howler Monkey",
                Location = "Central & South America",
                Details = "Known for their loud howls that can be heard up to 3 miles away.",
                Image = "https://example.com/howler.jpg",
                Population = 100000,
                Latitude = 10.0,
                Longitude = -80.0
            },
            new Monkey
            {
                Name = "Japanese Macaque",
                Location = "Japan",
                Details = "Also known as snow monkeys, famous for bathing in hot springs during winter.",
                Image = "https://example.com/macaque.jpg",
                Population = 50000,
                Latitude = 36.0,
                Longitude = 138.0
            },
            new Monkey
            {
                Name = "Proboscis Monkey",
                Location = "Borneo",
                Details = "Distinguished by their large noses and excellent swimming abilities.",
                Image = "https://example.com/proboscis.jpg",
                Population = 7000,
                Latitude = 1.0,
                Longitude = 114.0
            },
            new Monkey
            {
                Name = "Spider Monkey",
                Location = "Central & South America",
                Details = "Agile primates with long limbs and prehensile tails, excellent at swinging through trees.",
                Image = "https://example.com/spider.jpg",
                Population = 250000,
                Latitude = 5.0,
                Longitude = -70.0
            },
            new Monkey
            {
                Name = "Vervet Monkey",
                Location = "East Africa",
                Details = "Small monkeys with distinct alarm calls for different types of predators.",
                Image = "https://example.com/vervet.jpg",
                Population = 500000,
                Latitude = -1.0,
                Longitude = 37.0
            },
            new Monkey
            {
                Name = "Golden Lion Tamarin",
                Location = "Brazil",
                Details = "Endangered monkeys with striking golden manes, found in Atlantic coastal forests.",
                Image = "https://example.com/tamarin.jpg",
                Population = 3000,
                Latitude = -22.0,
                Longitude = -42.0
            }
        };
    }
}