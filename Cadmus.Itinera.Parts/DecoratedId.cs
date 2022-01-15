using Cadmus.Refs.Bricks;
using System.Collections.Generic;

namespace Cadmus.Itinera.Parts
{
    /// <summary>
    /// Decorated ID.
    /// </summary>
    public class DecoratedId
    {
        /// <summary>
        /// ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Tag.
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// Rank.
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// Sources.
        /// </summary>
        public List<DocReference> Sources { get; set; }

        /// <summary>
        /// Create a new instance of <see cref="DecoratedId"/>.
        /// </summary>
        public DecoratedId()
        {
            Sources = new List<DocReference>();
        }
    }
}
