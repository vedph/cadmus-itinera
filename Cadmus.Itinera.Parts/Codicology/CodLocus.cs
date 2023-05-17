using Cadmus.Codicology.Parts;
using System.Collections.Generic;

namespace Cadmus.Itinera.Parts.Codicology;

/// <summary>
/// A locus criticus in a manuscript.
/// </summary>
public class CodLocus
{
    /// <summary>
    /// Gets or sets the passage citation.
    /// </summary>
    public string? Citation { get; set; }

    /// <summary>
    /// Gets or sets the range covered by this passage in the manuscript.
    /// </summary>
    public CodLocationRange? Range { get; set; }

    /// <summary>
    /// Gets or sets the text.
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// Gets or sets an optional note.
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// Gets or sets the images.
    /// </summary>
    public List<CodImage> Images { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CodLocus"/> class.
    /// </summary>
    public CodLocus()
    {
        Images = new List<CodImage>();
    }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        return $"{Citation}: {Range}";
    }
}
