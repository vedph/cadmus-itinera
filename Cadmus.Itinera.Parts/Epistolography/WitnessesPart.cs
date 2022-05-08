using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cadmus.Core;
using Fusi.Tools.Config;

namespace Cadmus.Itinera.Parts.Epistolography
{
    /// <summary>
    /// Witnesses part.
    /// <para>Tag: <c>it.vedph.itinera.witnesses</c>.</para>
    /// </summary>
    [Tag("it.vedph.itinera.witnesses")]
    public sealed class WitnessesPart : PartBase
    {
        /// <summary>
        /// Gets or sets the entries.
        /// </summary>
        public List<Witness> Witnesses { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WitnessesPart"/> class.
        /// </summary>
        public WitnessesPart()
        {
            Witnesses = new List<Witness>();
        }

        /// <summary>
        /// Get all the key=value pairs (pins) exposed by the implementor.
        /// </summary>
        /// <param name="item">The optional item. The item with its parts
        /// can optionally be passed to this method for those parts requiring
        /// to access further data.</param>
        /// <returns>The pins: <c>tot-count</c> and a collection of pins with
        /// these keys: <c>id</c>.</returns>
        public override IEnumerable<DataPin> GetDataPins(IItem item = null)
        {
            DataPinBuilder builder = new();

            builder.Set("tot", Witnesses?.Count ?? 0, false);

            if (Witnesses?.Count > 0)
                builder.AddValues("id", Witnesses.Select(w => w.Id));

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
                   "The total count of witnesses."),
                new DataPinDefinition(DataPinValueType.String,
                   "id",
                   "The list of witnesses IDs.",
                   "M")
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

            sb.Append("[Witnesses]");

            if (Witnesses?.Count > 0)
            {
                sb.Append(' ');
                int n = 0;
                foreach (var entry in Witnesses)
                {
                    if (++n > 3) break;
                    if (n > 1) sb.Append("; ");
                    sb.Append(entry);
                }
                if (Witnesses.Count > 3)
                    sb.Append("...(").Append(Witnesses.Count).Append(')');
            }

            return sb.ToString();
        }
    }
}
