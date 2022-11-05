using System.Collections.Generic;
using System.Linq;
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
        public List<RelatedPerson> Persons { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelatedPersonsPart"/> class.
        /// </summary>
        public RelatedPersonsPart()
        {
            Persons = new List<RelatedPerson>();
        }

        /// <summary>
        /// Get all the key=value pairs (pins) exposed by the implementor.
        /// </summary>
        /// <param name="item">The optional item. The item with its parts
        /// can optionally be passed to this method for those parts requiring
        /// to access further data.</param>
        /// <returns>The pins: <c>tot-count</c> and a collection of pins with
        /// these keys: <c>type</c>, <c>target-id</c>, <c>name</c>.</returns>
        public override IEnumerable<DataPin> GetDataPins(IItem? item = null)
        {
            DataPinBuilder builder = new(
                DataPinHelper.DefaultFilter);

            builder.Set("tot", Persons?.Count ?? 0, false);

            if (Persons?.Count > 0)
            {
                foreach (RelatedPerson person in Persons)
                {
                    builder.AddValue("type", person.Type);
                    if (person.Ids?.Count > 0)
                        builder.AddValues("target-id", person.Ids.Select(i => i.Value!));
                    builder.AddValue("name", person.Name,
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
                   "The total count of persons."),
                new DataPinDefinition(DataPinValueType.String,
                   "type",
                   "The list of relation types.",
                   "M"),
                new DataPinDefinition(DataPinValueType.String,
                   "target-id",
                   "The list of target person IDs.",
                   "M"),
                new DataPinDefinition(DataPinValueType.String,
                   "name",
                   "The list of persons names.",
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
            StringBuilder sb = new();

            sb.Append("[RelatedPersons]");

            if (Persons?.Count > 0)
            {
                sb.Append(' ');
                int n = 0;
                foreach (var entry in Persons)
                {
                    if (++n > 3) break;
                    if (n > 1) sb.Append("; ");
                    sb.Append(entry);
                }
                if (Persons.Count > 3)
                    sb.Append("...(").Append(Persons.Count).Append(')');
            }

            return sb.ToString();
        }
    }
}
