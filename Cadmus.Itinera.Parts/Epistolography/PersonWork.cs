using Cadmus.Refs.Bricks;

namespace Cadmus.Itinera.Parts.Epistolography;

/// <summary>
/// A person's work.
/// </summary>
public class PersonWork
{
    /// <summary>
    /// Gets or sets the entity ID for this work.
    /// </summary>
    public string? Eid { get; set; }

    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the assertion.
    /// </summary>
    public Assertion? Assertion { get; set; }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        return $"#{Eid}: {Title}";
    }
}
