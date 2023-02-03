using System.Collections.Generic;
using System.Text;
using Cadmus.Core;
using Fusi.Tools.Configuration;

namespace Cadmus.Itinera.Parts.Epistolography;

/// <summary>
/// Person's works list part.
/// <para>Tag: <c>it.vedph.itinera.person-works</c>.</para>
/// </summary>
[Tag("it.vedph.itinera.person-works")]
public sealed class PersonWorksPart : PartBase
{
    /// <summary>
    /// Gets or sets the works.
    /// </summary>
    public List<PersonWork> Works { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PersonWorksPart"/> class.
    /// </summary>
    public PersonWorksPart()
    {
        Works = new List<PersonWork>();
    }

    /// <summary>
    /// Get all the key=value pairs (pins) exposed by the implementor.
    /// </summary>
    /// <param name="item">The optional item. The item with its parts
    /// can optionally be passed to this method for those parts requiring
    /// to access further data.</param>
    /// <returns>The pins: <c>tot-count</c> and a collection of pins with
    /// these keys: <c>eid</c>, <c>title</c>.</returns>
    public override IEnumerable<DataPin> GetDataPins(IItem? item = null)
    {
        DataPinBuilder builder =
            new(DataPinHelper.DefaultFilter);

        builder.Set("tot", Works?.Count ?? 0, false);

        if (Works?.Count > 0)
        {
            foreach (PersonWork work in Works)
            {
                builder.AddValue("eid", work.Eid);
                builder.AddValue("title", work.Title,
                    filter: true, filterOptions: true);
            }
        }

        return builder.Build(this);
    }

    /// <summary>
    /// Gets the definitions of data pins used by the implementor.
    /// </summary>
    /// <returns>Data pins definitions.</returns>
    public override IList<DataPinDefinition> GetDataPinDefinitions()
    {
        return new List<DataPinDefinition>(new[]
        {
            new DataPinDefinition(DataPinValueType.Integer,
               "tot-count",
               "The total count of works."),
            new DataPinDefinition(DataPinValueType.String,
               "eid",
               "The list of works EIDs.",
               "M"),
            new DataPinDefinition(DataPinValueType.String,
               "title",
               "The list of works titles.",
               "Mf"),
        });
    }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        StringBuilder sb = new();

        sb.Append("[PersonWorks]");

        if (Works?.Count > 0)
        {
            sb.Append(' ');
            int n = 0;
            foreach (var entry in Works)
            {
                if (++n > 3) break;
                if (n > 1) sb.Append("; ");
                sb.Append(entry);
            }
            if (Works.Count > 3)
                sb.Append("...(").Append(Works.Count).Append(')');
        }

        return sb.ToString();
    }
}
