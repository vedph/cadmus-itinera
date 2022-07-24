using Cadmus.Refs.Bricks;
using System.Collections.Generic;

namespace Cadmus.Itinera.Parts.Epistolography
{
    /// <summary>
    /// A related person in <see cref="RelatedPersonsPart"/>.
    /// </summary>
    public class RelatedPerson
    {
        /// <summary>
        /// Gets or sets the relation type.
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// Gets or sets the person name in this relation.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the identifications for this type.
        /// </summary>
        public IList<AssertedId> Ids { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelatedPerson"/> class.
        /// </summary>
        public RelatedPerson()
        {
            Ids = new List<AssertedId>();
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"[{Type}]: {Name}";
        }
    }
}
