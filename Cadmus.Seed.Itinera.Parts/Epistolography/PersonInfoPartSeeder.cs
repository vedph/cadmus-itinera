using Bogus;
using Cadmus.Core;
using Cadmus.Itinera.Parts.Epistolography;
using Fusi.Tools.Config;
using System;

namespace Cadmus.Seed.Itinera.Parts.Epistolography
{
    /// <summary>
    /// Seeder for <see cref="PersonInfoPart"/>.
    /// Tag: <c>seed.it.vedph.itinera.person-info</c>.
    /// </summary>
    /// <seealso cref="PartSeederBase" />
    [Tag("seed.it.vedph.itinera.person-info")]
    public sealed class PersonInfoPartSeeder : PartSeederBase
    {
        /// <summary>
        /// Creates and seeds a new part.
        /// </summary>
        /// <param name="item">The item this part should belong to.</param>
        /// <param name="roleId">The optional part role ID.</param>
        /// <param name="factory">The part seeder factory. This is used
        /// for layer parts, which need to seed a set of fragments.</param>
        /// <returns>A new part.</returns>
        /// <exception cref="ArgumentNullException">item or factory</exception>
        public override IPart GetPart(IItem item, string? roleId,
            PartSeederFactory? factory)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            PersonInfoPart part = new Faker<PersonInfoPart>()
                .RuleFor(p => p.Sex, f => f.PickRandom('M', 'F'))
                .RuleFor(p => p.Bio, f => f.Lorem.Sentence())
                .Generate();
            SetPartMetadata(part, roleId, item);

            return part;
        }
    }
}
