namespace Cadmus.Itinera.Parts.Codicology;

/// <summary>
/// The layout of a single range of poems used in <see cref="CodPoemRangesPart"/>.
/// </summary>
public class CodPoemLayout
{
    /// <summary>
    /// Gets or sets the range.
    /// </summary>
    public AlnumRange? Range { get; set; }

    /// <summary>
    /// Gets or sets the layout.
    /// </summary>
    public string? Layout { get; set; }

    /// <summary>
    /// Gets or sets an optional note.
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        return $"{Range}: {Layout}";
    }
}
