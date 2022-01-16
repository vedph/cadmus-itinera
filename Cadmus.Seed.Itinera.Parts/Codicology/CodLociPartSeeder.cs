using Bogus;
using Cadmus.Codicology.Parts;
using Cadmus.Core;
using Cadmus.Itinera.Parts.Codicology;
using Fusi.Tools.Config;
using System;
using System.Collections.Generic;

namespace Cadmus.Seed.Itinera.Parts.Codicology
{
    /// <summary>
    /// Seeder for <see cref="CodLociPart"/>.
    /// Tag: <c>seed.it.vedph.itinera.cod-loci</c>.
    /// </summary>
    /// <seealso cref="PartSeederBase" />
    [Tag("seed.it.vedph.itinera.cod-loci")]
    public sealed class CodLociPartSeeder : PartSeederBase
    {
        private static List<CodLocus> GetLoci(int count)
        {
            List<CodLocus> loci = new List<CodLocus>();
            for (int n = 1; n <= count; n++)
            {
                loci.Add(new Faker<CodLocus>()
                    .RuleFor(l => l.Citation, f => $"{n}.{f.Random.Number(1, 100)}")
                    .RuleFor(l => l.Range,
                        new CodLocationRange
                        {
                            Start = new CodLocation { N = n * 2 }
                        })
                    .RuleFor(l => l.Text, f => f.Lorem.Sentence())
                    .RuleFor(l => l.Images,
                        f => SeederHelper.GetCodImages(f.Random.Number(1, 3)))
                    .Generate());
            }
            return loci;
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
        public override IPart GetPart(IItem item, string roleId,
            PartSeederFactory factory)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            CodLociPart part = new Faker<CodLociPart>()
                .RuleFor(p => p.Loci, f => GetLoci(f.Random.Number(1, 3)))
                .Generate();
            SetPartMetadata(part, roleId, item);

            return part;
        }
    }
}
