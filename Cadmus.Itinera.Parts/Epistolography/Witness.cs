using Cadmus.Codicology.Parts;
using System.Collections.Generic;

namespace Cadmus.Itinera.Parts.Epistolography;

/// <summary>
/// A witness in the <see cref="WitnessesPart"/>.
/// </summary>
public class Witness
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the range(s) covered by this witness in its manuscript.
    /// </summary>
    public List<CodLocationRange> Ranges { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Witness"/> class.
    /// </summary>
    public Witness()
    {
        Ranges = new();
    }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        return Id ?? base.ToString()!;
    }
}
