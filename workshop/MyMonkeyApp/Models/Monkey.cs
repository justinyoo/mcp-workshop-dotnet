namespace MyMonkeyApp.Models;

/// <summary>
/// Represents a monkey with its characteristics and information.
/// </summary>
public class Monkey
{
    /// <summary>
    /// Gets or sets the unique name of the monkey.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the location where the monkey can be found.
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets additional details about the monkey.
    /// </summary>
    public string Details { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the URL to an image of the monkey.
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the population size of this monkey species.
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// Gets or sets the latitude coordinate of the monkey's location.
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// Gets or sets the longitude coordinate of the monkey's location.
    /// </summary>
    public double Longitude { get; set; }
}