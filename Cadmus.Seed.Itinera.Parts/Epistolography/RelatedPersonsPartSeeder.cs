using Bogus;
using Cadmus.Core;
using Cadmus.Itinera.Parts.Epistolography;
using Cadmus.Refs.Bricks;
using Fusi.Tools.Config;
using System;
using System.Collections.Generic;

namespace Cadmus.Seed.Itinera.Parts.Epistolography
{
    /// <summary>
    /// Seeder for RelatedPersons part.
    /// Tag: <c>seed.it.vedph.itinera.related-persons</c>.
    /// </summary>
    /// <seealso cref="PartSeederBase" />
    [Tag("seed.it.vedph.itinera.related-persons")]
    public sealed class RelatedPersonsPartSeeder : PartSeederBase
    {
        private static List<RelatedPerson> GetPersons(int count)
        {
            List<RelatedPerson> persons = new List<RelatedPerson>();
            for (int n = 1; n <= count; n++)
            {
                persons.Add(new Faker<RelatedPerson>()
                    .RuleFor(p => p.Type, f => f.PickRandom("alpha", "beta"))
                    .RuleFor(p => p.Ids, f => new List<AssertedId>
                    {
                        new AssertedId
                        {
                            Value = f.Lorem.Word() + n
                        }
                    })
                    .RuleFor(p => p.Name, f => f.Person.FullName)
                    .Generate());
            }
            return persons;
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

            RelatedPersonsPart part = new Faker<RelatedPersonsPart>()
               .RuleFor(p => p.Persons, f => GetPersons(f.Random.Number(1, 3)))
               .Generate();
            SetPartMetadata(part, roleId, item);

            return part;
        }
    }
}
