using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cadmus.Core;
using Fusi.Tools.Config;

namespace Cadmus.Itinera.Parts.Epistolography
{
    /// <summary>
    /// Minimalist information about a person. This just includes the sex
    /// and a short human-friendly bio summary, as all the relevant biographic
    /// events are rather in an events part, and all the names assigned to the
    /// person in a names part.
    /// <para>Tag: <c>it.vedph.itinera.person-info</c>.</para>
    /// </summary>
    /// <seealso cref="PartBase" />
    [Tag("it.vedph.itinera.person-info")]
    public sealed class PersonInfoPart : PartBase
    {
        /// <summary>
        /// Gets or sets the sex (<c>M</c>=male, <c>F</c>=female, etc.).
        /// </summary>
        public char Sex { get; set; }

        /// <summary>
        /// Gets or sets a bio summary.
        /// </summary>
        public string? Bio { get; set; }

        /// <summary>
        /// Get all the key=value pairs (pins) exposed by the implementor.
        /// </summary>
        /// <param name="item">The optional item. The item with its parts
        /// can optionally be passed to this method for those parts requiring
        /// to access further data.</param>
        /// <returns>The pins.</returns>
        public override IEnumerable<DataPin> GetDataPins(IItem? item)
        {
            return Sex != '\0'
               ? new[]
               {
                    CreateDataPin("sex", new string(Sex, 1))
               }
               : Enumerable.Empty<DataPin>();
        }

        /// <summary>
        /// Gets the definitions of data pins used by the implementor.
        /// </summary>
        /// <returns>Data pins definitions.</returns>
        public override IList<DataPinDefinition> GetDataPinDefinitions()
        {
            return new List<DataPinDefinition>(new[]
            {
                new DataPinDefinition(DataPinValueType.String,
                    "sex",
                    "The person's sex.")
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

            sb.Append("[PersonInfo]");

            if (Sex != '\0') sb.Append('[').Append(Sex).Append(']');
            if (!string.IsNullOrEmpty(Bio))
                sb.Append(Bio.Length > 80 ? Bio.Substring(0, 80) + "..." : Bio);

            return sb.ToString();
        }
    }
}
