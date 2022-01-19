using Cadmus.Core;
using Cadmus.Itinera.Parts.Epistolography;
using Cadmus.Seed.Itinera.Parts.Epistolography;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cadmus.Itinera.Parts.Test.Epistolography
{
    public sealed class WitnessesPartTest
    {
        private static WitnessesPart GetPart()
        {
            WitnessesPartSeeder seeder = new();
            IItem item = new Item
            {
                FacetId = "default",
                CreatorId = "zeus",
                UserId = "zeus",
                Description = "Test item",
                Title = "Test Item",
                SortKey = ""
            };
            return (WitnessesPart)seeder.GetPart(item, null, null);
        }

        private static WitnessesPart GetEmptyPart()
        {
            return new WitnessesPart
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
            WitnessesPart part = GetPart();

            string json = TestHelper.SerializePart(part);
            WitnessesPart part2 =
                TestHelper.DeserializePart<WitnessesPart>(json)!;

            Assert.Equal(part.Id, part2.Id);
            Assert.Equal(part.TypeId, part2.TypeId);
            Assert.Equal(part.ItemId, part2.ItemId);
            Assert.Equal(part.RoleId, part2.RoleId);
            Assert.Equal(part.CreatorId, part2.CreatorId);
            Assert.Equal(part.UserId, part2.UserId);

            Assert.Equal(part.Witnesses.Count, part2.Witnesses.Count);
        }

        [Fact]
        public void GetDataPins_NoEntries_Ok()
        {
            WitnessesPart part = GetPart();
            part.Witnesses.Clear();

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
            WitnessesPart part = GetEmptyPart();

            for (int n = 1; n <= 3; n++)
            {
                part.Witnesses.Add(new Witness
                {
                    Id = "w" + n
                });
            }

            List<DataPin> pins = part.GetDataPins(null).ToList();

            Assert.Equal(4, pins.Count);

            DataPin? pin = pins.Find(p => p.Name == "tot-count");
            Assert.NotNull(pin);
            TestHelper.AssertPinIds(part, pin!);
            Assert.Equal("3", pin!.Value);

            for (int n = 1; n <= 3; n++)
            {
                pin = pins.Find(p => p.Name == "id" && p.Value == "w" + n);
                Assert.NotNull(pin);
                TestHelper.AssertPinIds(part, pin!);
            }
        }
    }
}
