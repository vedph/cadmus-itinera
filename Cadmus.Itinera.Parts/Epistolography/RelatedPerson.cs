using Cadmus.Refs.Bricks;

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
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the target identifier.
        /// </summary>
        public string TargetId { get; set; }

        /// <summary>
        /// Gets or sets the person name in this relation.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the assertion.
        /// </summary>
        public Assertion Assertion { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"[{Type}] {TargetId}: {Name}";
        }
    }
}
