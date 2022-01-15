using Cadmus.Core;
using Cadmus.Itinera.Parts.Epistolography;
using Cadmus.Seed.Itinera.Parts.Epistolography;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cadmus.Itinera.Parts.Test.Epistolography
{
    public sealed class PersonWorksPartTest
    {
        private static PersonWorksPart GetPart()
        {
            PersonWorksPartSeeder seeder = new();
            IItem item = new Item
            {
                FacetId = "default",
                CreatorId = "zeus",
                UserId = "zeus",
                Description = "Test item",
                Title = "Test Item",
                SortKey = ""
            };
            return (PersonWorksPart)seeder.GetPart(item, null, null);
        }

        private static PersonWorksPart GetEmptyPart()
        {
            return new PersonWorksPart
            {
                ItemId = Guid.NewGuid().ToString(),
                RoleId = "some-role",
                CreatorId = "zeus",
                UserId = "another",
            };
        }

        [Fact]
        public void Part_Is_Serializable()
        {
            PersonWorksPart part = GetPart();

            string json = TestHelper.SerializePart(part);
            PersonWorksPart part2 =
                TestHelper.DeserializePart<PersonWorksPart>(json)!;

            Assert.Equal(part.Id, part2.Id);
            Assert.Equal(part.TypeId, part2.TypeId);
            Assert.Equal(part.ItemId, part2.ItemId);
            Assert.Equal(part.RoleId, part2.RoleId);
            Assert.Equal(part.CreatorId, part2.CreatorId);
            Assert.Equal(part.UserId, part2.UserId);

            Assert.Equal(part.Works.Count, part2.Works.Count);
        }

        [Fact]
        public void GetDataPins_NoEntries_Ok()
        {
            PersonWorksPart part = GetPart();
            part.Works.Clear();

            List<DataPin> pins = part.GetDataPins(null).ToList();

            Assert.Single(pins);
            DataPin pin = pins[0];
            Assert.Equal("tot-count", pin.Name);
            TestHelper.AssertPinIds(part, pin);
            Assert.Equal("0", pin.Value);
        }

        [Fact]
        public void GetDataPins_Entries_Ok()
        {
            PersonWorksPart part = GetEmptyPart();

            for (int n = 1; n <= 3; n++)
            {
                part.Works.Add(new PersonWork
                {
                    Eid = "w" + n,
                    Title = "Title" + n
                });
            }

            List<DataPin> pins = part.GetDataPins(null).ToList();

            Assert.Equal(7, pins.Count);

            DataPin? pin = pins.Find(p => p.Name == "tot-count");
            Assert.NotNull(pin);
            TestHelper.AssertPinIds(part, pin!);
            Assert.Equal("3", pin!.Value);

            for (int n = 1; n <= 3; n++)
            {
                // eid
                pin = pins.Find(p => p.Name == "eid" && p.Value == "w" + n);
                Assert.NotNull(pin);
                TestHelper.AssertPinIds(part, pin!);

                // title
                pin = pins.Find(p => p.Name == "title" && p.Value == "title" + n);
                Assert.NotNull(pin);
                TestHelper.AssertPinIds(part, pin!);
            }
        }
    }
}
