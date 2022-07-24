using Bogus;
using Cadmus.Codicology.Parts;
using Cadmus.Core;
using Cadmus.Itinera.Parts.Epistolography;
using Fusi.Tools.Config;
using System;
using System.Collections.Generic;

namespace Cadmus.Seed.Itinera.Parts.Epistolography
{
    /// <summary>
    /// Seeder for <see cref="WitnessesPart"/>.
    /// Tag: <c>seed.it.vedph.itinera.witnesses</c>.
    /// </summary>
    /// <seealso cref="PartSeederBase" />
    [Tag("seed.it.vedph.itinera.witnesses")]
    public sealed class WitnessesPartSeeder : PartSeederBase
    {
        public List<Witness> GetWitnesses(int count)
        {
            List<Witness> witnesses = new();
            for (int n = 1; n <= count; n++)
            {
                int start = Randomizer.Seed.Next(1, 51);
                witnesses.Add(new Faker<Witness>()
                    .RuleFor(w => w.Id, f => f.Lorem.Word() + n)
                    .RuleFor(w => w.Ranges, new List<CodLocationRange>(
                        new[]
                        {
                            new CodLocationRange
                            {
                                Start = new CodLocation { N = start },
                                End = new CodLocation { N = start }
                            }
                        }))
                    .Generate());
            }
            return witnesses;
        }

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

            WitnessesPart part = new Faker<WitnessesPart>()
               .RuleFor(p => p.Witnesses, f => GetWitnesses(f.Random.Number(1, 3)))
               .Generate();
            SetPartMetadata(part, roleId, item);

            return part;
        }
    }
}
