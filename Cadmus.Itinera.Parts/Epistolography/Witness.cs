using Cadmus.Codicology.Parts;

namespace Cadmus.Itinera.Parts.Epistolography
{
    /// <summary>
    /// A witness in the <see cref="WitnessesPart"/>.
    /// </summary>
    public class Witness
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the range covered by this witness in its manuscript.
        /// </summary>
        public CodLocationRange Range { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{Id}: {Range}";
        }
    }
}
