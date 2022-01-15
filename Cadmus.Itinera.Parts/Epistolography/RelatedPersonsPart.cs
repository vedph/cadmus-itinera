using System;
using System.Collections.Generic;
using System.Text;
using Cadmus.Core;
using Fusi.Tools.Config;

namespace Cadmus.Itinera.Parts.Epistolography
{
    /// <summary>
    /// Related persons part.
    /// <para>Tag: <c>it.vedph.itinera.related-persons</c>.</para>
    /// </summary>
    [Tag("it.vedph.itinera.related-persons")]
    public sealed class RelatedPersonsPart : PartBase
    {
        /// <summary>
        /// Gets or sets the entries.
        /// </summary>
        public List<RelatedPerson> Entries { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelatedPersonsPart"/> class.
        /// </summary>
        public RelatedPersonsPart()
        {
            Entries = new List<RelatedPerson>();
        }

        /// <summary>
        /// Get all the key=value pairs (pins) exposed by the implementor.
        /// </summary>
        /// <param name="item">The optional item. The item with its parts
        /// can optionally be passed to this method for those parts requiring
        /// to access further data.</param>
        /// <returns>The pins: <c>tot-count</c> and a collection of pins with
        /// these keys: ....</returns>
        public override IEnumerable<DataPin> GetDataPins(IItem item = null)
        {
            DataPinBuilder builder = new DataPinBuilder();

            builder.Set("tot", Entries?.Count ?? 0, false);

            if (Entries?.Count > 0)
            {
                foreach (var entry in Entries)
                {
                    // TODO: add values or increase counts like:
                    // id unique values if not null:
                    // builder.AddValue("id", entry.Id);
                    // type-X-count counts if not null, unfiltered:
                    // builder.Increase(entry.Type, false, "type-");
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
            // TODO: add pins definitions...
            new DataPinDefinition(DataPinValueType.Integer,
               "tot-count",
               "The total count of entries.")
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
            StringBuilder sb = new StringBuilder();

            sb.Append("[RelatedPersons]");

            if (Entries?.Count > 0)
            {
                sb.Append(' ');
                int n = 0;
                foreach (var entry in Entries)
                {
                    if (++n > 3) break;
                    if (n > 1) sb.Append("; ");
                    sb.Append(entry);
                }
                if (Entries.Count > 3)
                    sb.Append("...(").Append(Entries.Count).Append(')');
            }

            return sb.ToString();
        }
    }
}
