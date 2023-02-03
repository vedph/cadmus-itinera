using Cadmus.Refs.Bricks;
using System.Collections.Generic;

namespace Cadmus.Itinera.Parts.Epistolography;

/// <summary>
/// A related text used in <see cref="ReferencedTextsPart"/>.
/// </summary>
public class ReferencedText
{
    /// <summary>
    /// Gets or sets the reference type.
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets the target identifier.
    /// </summary>
    public string? TargetId { get; set; }

    /// <summary>
    /// Gets or sets the target citation.
    /// </summary>
    public string? TargetCitation { get; set; }

    /// <summary>
    /// Gets or sets the source citations.
    /// </summary>
    public List<string> SourceCitations { get; set; }

    /// <summary>
    /// Gets or sets the assertion.
    /// </summary>
    public Assertion? Assertion { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ReferencedText"/> class.
    /// </summary>
    public ReferencedText()
    {
        SourceCitations = new();
    }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        return $"[{Type}] {TargetId}";
    }
}
