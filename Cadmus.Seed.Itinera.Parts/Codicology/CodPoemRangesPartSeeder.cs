using Bogus;
using Cadmus.Core;
using Cadmus.Itinera.Parts.Codicology;
using Fusi.Tools.Config;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Cadmus.Seed.Itinera.Parts.Codicology
{
    /// <summary>
    /// Seeder for <see cref="CodPoemRangesPart"/>.
    /// Tag: <c>seed.it.vedph.itinera.cod-poem-ranges</c>.
    /// </summary>
    /// <seealso cref="PartSeederBase" />
    [Tag("seed.it.vedph.itinera.cod-poem-ranges")]
    public sealed class CodPoemRangesPartSeeder : PartSeederBase
    {
        private static List<CodPoemLayout> GetLayouts(Faker f)
        {
            List<CodPoemLayout> layouts = new List<CodPoemLayout>();
            for (int n = 1; n <= 10; n++)
            {
                layouts.Add(new CodPoemLayout
                {
                    Range = new AlnumRange
                    {
                        A = n.ToString(CultureInfo.InvariantCulture)
                    },
                    Layout = f.Random.Number(0, 3)
                        .ToString(CultureInfo.InvariantCulture)
                });
            }
            return layouts;
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

            AlnumRange[] ranges = Enumerable.Range(1, 10)
                .Select(n => new AlnumRange
                {
                    A = n.ToString(CultureInfo.InvariantCulture)
                })
                .ToArray();

            CodPoemRangesPart part = new Faker<CodPoemRangesPart>()
               .RuleFor(p => p.Ranges,
                    f => new List<AlnumRange>(f.Random.Shuffle(ranges)))
               // TODO: use thesaurus
               .RuleFor(p => p.SortType, f => f.PickRandom("alpha", "beta"))
               .RuleFor(p => p.Layouts, f => GetLayouts(f))
               .Generate();
            SetPartMetadata(part, roleId, item);

            return part;
        }
    }
}
