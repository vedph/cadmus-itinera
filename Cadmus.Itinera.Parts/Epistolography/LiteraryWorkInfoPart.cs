using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cadmus.Core;
using Fusi.Tools.Config;

namespace Cadmus.Itinera.Parts.Epistolography
{
    /// <summary>
    /// Essential information about a literary work.
    /// <para>Tag: <c>it.vedph.itinera.literary-work-info</c>.</para>
    /// </summary>
    [Tag("it.vedph.itinera.literary-work-info")]
    public sealed class LiteraryWorkInfoPart : PartBase
    {
        /// <summary>
        /// Gets or sets the language(s) used in the work.
        /// </summary>
        public List<string> Languages { get; set; }

        /// <summary>
        /// Gets or sets the genre(s) the work belongs to.
        /// </summary>
        public List<string> Genres { get; set; }

        /// <summary>
        /// Gets or sets the metre(s) used in the work.
        /// </summary>
        public List<string> Metres { get; set; }

        /// <summary>
        /// Gets or sets the strophic structure(s) used in the work.
        /// </summary>
        public List<string> Strophes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this work is lost.
        /// </summary>
        public bool IsLost { get; set; }

        /// <summary>
        /// Gets or sets the work's title(s).
        /// </summary>
        public List<AssertedTitle> Titles { get; set; }

        /// <summary>
        /// Gets or sets an optional note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LiteraryWorkInfoPart"/>
        /// class.
        /// </summary>
        public LiteraryWorkInfoPart()
        {
            Languages = new List<string>();
            Genres = new List<string>();
            Metres = new List<string>();
            Strophes = new List<string>();
            Titles = new List<AssertedTitle>();
        }

        /// <summary>
        /// Get all the key=value pairs (pins) exposed by the implementor.
        /// </summary>
        /// <param name="item">The optional item. The item with its parts
        /// can optionally be passed to this method for those parts requiring
        /// to access further data.</param>
        /// <returns>The pins.</returns>
        public override IEnumerable<DataPin> GetDataPins(IItem item = null)
        {
            DataPinBuilder builder = new DataPinBuilder(
                new StandardDataPinTextFilter());

            builder.AddValues("language", Languages);
            builder.AddValues("genre", Genres);
            builder.AddValues("metre", Metres);
            builder.AddValues("title", Titles.Select(t => t.Value),
                filter: true, filterOptions: true);

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
                    "language",
                    "The list of work's languages.",
                    "M"),
                 new DataPinDefinition(DataPinValueType.String,
                    "genre",
                    "The list of work's genres.",
                    "M"),
                 new DataPinDefinition(DataPinValueType.String,
                    "metre",
                    "The list of work's metres.",
                    "M"),
                 new DataPinDefinition(DataPinValueType.String,
                    "title",
                    "The list of work's titles.",
                    "Mf")
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

            sb.Append("[LiteraryWorkInfo]");

            if (Titles?.Count > 0) sb.Append(Titles[0].Value);

            return sb.ToString();
        }
    }
}
