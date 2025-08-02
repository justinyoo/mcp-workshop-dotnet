namespace MyMonkeyApp.Helpers;

/// <summary>
/// Provides ASCII art and visual elements for the console application.
/// </summary>
public static class AsciiArt
{
    private static readonly string[] _monkeyArt = {
        @"
      🐵
   .-""""""-.
  /          \
 |  o      o  |
 |     <>     |
 |   \____/   |
  \          /
   '-.____.-'
",
        @"
    🐒
  .-.   .-.
 /   \ /   \
|  o   o   |
|     <    |
|   \___/  |
 \         /
  '~~~~~'
",
        @"
      🙊
    .-----.
   /       \
  | ^     ^ |
  |    o    |
  |   ___   |
   \       /
    '-----'
",
        @"
      🙈
   ,-.___,-.
  /  (   )  \
 |  o \-/ o  |
 |     V     |
  \  \___/  /
   '-......-'
",
        @"
      🙉
    .------.
   /        \
  | ()    () |
  |     ><   |
  |   \__/   |
   \        /
    '------'
"
    };

    private static readonly string[] _bannerArt = {
        @"
╔═══════════════════════════════════════╗
║          🐵 MONKEY EXPLORER 🐵          ║
║      Discover Amazing Primates!      ║
╚═══════════════════════════════════════╝
",
        @"
████████████████████████████████████████
█          🐒 MONKEY WORLD 🐒           █
█        Your Primate Adventure!       █
████████████████████████████████████████
"
    };

    /// <summary>
    /// Gets a random monkey ASCII art.
    /// </summary>
    /// <returns>A random monkey ASCII art string.</returns>
    public static string GetRandomMonkeyArt()
    {
        var random = new Random();
        return _monkeyArt[random.Next(_monkeyArt.Length)];
    }

    /// <summary>
    /// Gets a random banner ASCII art.
    /// </summary>
    /// <returns>A random banner ASCII art string.</returns>
    public static string GetRandomBanner()
    {
        var random = new Random();
        return _bannerArt[random.Next(_bannerArt.Length)];
    }

    /// <summary>
    /// Gets a simple separator line for the console.
    /// </summary>
    /// <returns>A separator line string.</returns>
    public static string GetSeparator()
    {
        return new string('=', 50);
    }

    /// <summary>
    /// Gets a menu decoration line.
    /// </summary>
    /// <returns>A decorative line string for menus.</returns>
    public static string GetMenuDecoration()
    {
        return "🌿🌿🌿🌿🌿🌿🌿🌿🌿🌿🌿🌿🌿🌿🌿🌿🌿🌿🌿🌿🌿🌿🌿🌿🌿";
    }
}