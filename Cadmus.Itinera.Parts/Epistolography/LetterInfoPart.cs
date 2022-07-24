using System.Collections.Generic;
using Cadmus.Core;
using Fusi.Tools.Config;

namespace Cadmus.Itinera.Parts.Epistolography
{
    /// <summary>
    /// Supplementary work information about a letter.
    /// <para>Tag: <c>it.vedph.itinera.letter-info</c>.</para>
    /// </summary>
    [Tag("it.vedph.itinera.letter-info")]
    public sealed class LetterInfoPart : PartBase
    {
        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        public string? Subject { get; set; }

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        public string? Header { get; set; }

        /// <summary>
        /// Gets or sets the date as reported in the text.
        /// </summary>
        public string? TextDate { get; set; }

        /// <summary>
        /// Get all the key=value pairs (pins) exposed by the implementor.
        /// </summary>
        /// <param name="item">The optional item. The item with its parts
        /// can optionally be passed to this method for those parts requiring
        /// to access further data.</param>
        /// <returns>The pins.</returns>
        public override IEnumerable<DataPin> GetDataPins(IItem? item = null)
        {
            DataPinBuilder builder = new(
                new StandardDataPinTextFilter());

            builder.AddValue("subject", Subject, filter: true);
            builder.AddValue("header", Header, filter: true);

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
                new DataPinDefinition(DataPinValueType.String,
                   "subject",
                   "The subject.",
                   "f"),
                new DataPinDefinition(DataPinValueType.String,
                   "header",
                   "The header.",
                   "f")
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
            return $"[LetterInfo]: [{Subject}] {Header}";
        }
    }
}
