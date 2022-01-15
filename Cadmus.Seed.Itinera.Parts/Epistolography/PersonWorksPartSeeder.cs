using Bogus;
using Cadmus.Core;
using Cadmus.Itinera.Parts.Epistolography;
using Fusi.Tools.Config;
using System;
using System.Collections.Generic;

namespace Cadmus.Seed.Itinera.Parts.Epistolography
{
    /// <summary>
    /// Seeder for PersonWorks part.
    /// Tag: <c>seed.it.vedph.itinera.person-works</c>.
    /// </summary>
    /// <seealso cref="PartSeederBase" />
    [Tag("seed.it.vedph.itinera.person-works")]
    public sealed class PersonWorksPartSeeder : PartSeederBase
    {
        private static List<PersonWork> GetWorks(int count)
        {
            List<PersonWork> works = new List<PersonWork>();
            for (int n = 1; n <= count; n++)
            {
                works.Add(new Faker<PersonWork>()
                    .RuleFor(w => w.Eid, f => f.Random.Word() + n)
                    .RuleFor(w => w.Title, f => f.Lorem.Sentence())
                    .RuleFor(w => w.Assertion, SeederHelper.GetAssertion())
                    .Generate());
            }
            return works;
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

            PersonWorksPart part = new Faker<PersonWorksPart>()
               .RuleFor(p => p.Works, f => GetWorks(f.Random.Number(1, 3)))
               .Generate();
            SetPartMetadata(part, roleId, item);

            return part;
        }
    }
}
