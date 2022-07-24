using System.Collections.Generic;
using Cadmus.Core;
using Fusi.Tools.Config;

namespace Cadmus.Itinera.Parts.Codicology
{
    /// <summary>
    /// Poem ranges part.
    /// <para>Tag: <c>it.vedph.itinera.cod-poem-ranges</c>.</para>
    /// </summary>
    [Tag("it.vedph.itinera.cod-poem-ranges")]
    public sealed class CodPoemRangesPart : PartBase
    {
        /// <summary>
        /// Gets or sets the poems ranges, defining the order and list of
        /// poems included in the manuscript.
        /// </summary>
        public List<AlnumRange> Ranges { get; set; }

        /// <summary>
        /// Gets or sets the sort order type used in this manuscript.
        /// </summary>
        public string? SortType { get; set; }

        /// <summary>
        /// Gets or sets the text layouts for each poem included in this
        /// manuscript.
        /// </summary>
        public List<CodPoemLayout> Layouts { get; set; }

        /// <summary>
        /// Gets or sets an optional tag.
        /// </summary>
        public string? Tag { get; set; }

        /// <summary>
        /// Gets or sets an optional note.
        /// </summary>
        public string? Note { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodPoemRangesPart"/>
        /// class.
        /// </summary>
        public CodPoemRangesPart()
        {
            Ranges = new List<AlnumRange>();
            Layouts = new List<CodPoemLayout>();
        }

        /// <summary>
        /// Get all the key=value pairs (pins) exposed by the implementor.
        /// </summary>
        /// <param name="item">The optional item. The item with its parts
        /// can optionally be passed to this method for those parts requiring
        /// to access further data.</param>
        /// <returns>The pins.</returns>
        public override IEnumerable<DataPin> GetDataPins(IItem? item = null)
        {
            DataPinBuilder builder = new();

            builder.AddValue("sort-type", SortType);

            if (Layouts?.Count > 0)
            {
                Dictionary<string, int> counts = new();
                for (int i = 0; i < Layouts.Count; i++)
                {
                    string? key = Layouts[i].Layout;
                    if (key == null) continue;
                    if (!counts.ContainsKey(key)) counts[key] = 0;
                    counts[key] += Layouts[i].Range!.B != null
                        ? AlnumRange.CountInterpolatedAlnums(
                            Layouts[i].Range!.A, Layouts[i].Range!.B)
                        : 1;
                }

                foreach (string layout in counts.Keys)
                    builder.Set("layout-" + layout, counts[layout], false);
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
                new DataPinDefinition(DataPinValueType.String,
                   "sort-type",
                   "The sort type."),
                new DataPinDefinition(DataPinValueType.Integer,
                   "layout-<TYPE>-count",
                   "The total counts for each layout type.",
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
            return $"[CodPoemRanges]: {SortType}: {Layouts?.Count ?? 0}";
        }
    }
}
