using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cadmus.Core;
using Fusi.Tools.Config;

namespace Cadmus.Itinera.Parts.Codicology
{
    /// <summary>
    /// Manuscript's loci critici.
    /// <para>Tag: <c>it.vedph.itinera.cod-loci</c>.</para>
    /// </summary>
    [Tag("it.vedph.itinera.cod-loci")]
    public sealed class CodLociPart : PartBase
    {
        /// <summary>
        /// Gets or sets the entries.
        /// </summary>
        public List<CodLocus> Loci { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodLociPart"/> class.
        /// </summary>
        public CodLociPart()
        {
            Loci = new List<CodLocus>();
        }

        /// <summary>
        /// Get all the key=value pairs (pins) exposed by the implementor.
        /// </summary>
        /// <param name="item">The optional item. The item with its parts
        /// can optionally be passed to this method for those parts requiring
        /// to access further data.</param>
        /// <returns>The pins: <c>tot-count</c> and a collection of pins with
        /// these keys: ....</returns>
        public override IEnumerable<DataPin> GetDataPins(IItem? item = null)
        {
            DataPinBuilder builder = new();

            builder.Set("tot", Loci?.Count ?? 0, false);

            if (Loci?.Count > 0)
                builder.AddValues("citation", Loci.Select(l => l.Citation));

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
                   "The total count of entries."),
                new DataPinDefinition(DataPinValueType.String,
                   "citation",
                   "The list of loci citations.",
                   "M"),
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

            sb.Append("[CodLoci]");

            if (Loci?.Count > 0)
            {
                sb.Append(' ');
                int n = 0;
                foreach (var entry in Loci)
                {
                    if (++n > 3) break;
                    if (n > 1) sb.Append("; ");
                    sb.Append(entry);
                }
                if (Loci.Count > 3)
                    sb.Append("...(").Append(Loci.Count).Append(')');
            }

            return sb.ToString();
        }
    }
}
