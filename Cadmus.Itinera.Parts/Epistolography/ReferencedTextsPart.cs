using System.Collections.Generic;
using System.Text;
using Cadmus.Core;
using Fusi.Tools.Config;

namespace Cadmus.Itinera.Parts.Epistolography
{
    /// <summary>
    /// Referenced texts part.
    /// <para>Tag: <c>it.vedph.itinera.referenced-texts</c>.</para>
    /// </summary>
    [Tag("it.vedph.itinera.referenced-texts")]
    public sealed class ReferencedTextsPart : PartBase
    {
        /// <summary>
        /// Gets or sets the texts.
        /// </summary>
        public List<ReferencedText> Texts { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferencedTextsPart"/>
        /// class.
        /// </summary>
        public ReferencedTextsPart()
        {
            Texts = new List<ReferencedText>();
        }

        /// <summary>
        /// Get all the key=value pairs (pins) exposed by the implementor.
        /// </summary>
        /// <param name="item">The optional item. The item with its parts
        /// can optionally be passed to this method for those parts requiring
        /// to access further data.</param>
        /// <returns>The pins: <c>tot-count</c> and a collection of pins with
        /// these keys: <c>type</c>, <c>target-id</c>.</returns>
        public override IEnumerable<DataPin> GetDataPins(IItem? item = null)
        {
            DataPinBuilder builder = new();

            builder.Set("tot", Texts?.Count ?? 0, false);

            if (Texts?.Count > 0)
            {
                foreach (ReferencedText text in Texts)
                {
                    builder.AddValue("type", text.Type);
                    builder.AddValue("target-id", text.TargetId);
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
                   "The total count of referenced texts."),
                new DataPinDefinition(DataPinValueType.String,
                   "type",
                   "The list of reference types.",
                   "M"),
                new DataPinDefinition(DataPinValueType.String,
                   "target-id",
                   "The list of reference target IDs.",
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

            sb.Append("[ReferencedTexts]");

            if (Texts?.Count > 0)
            {
                sb.Append(' ');
                int n = 0;
                foreach (var entry in Texts)
                {
                    if (++n > 3) break;
                    if (n > 1) sb.Append("; ");
                    sb.Append(entry);
                }
                if (Texts.Count > 3)
                    sb.Append("...(").Append(Texts.Count).Append(')');
            }

            return sb.ToString();
        }
    }
}
