using Cadmus.Core;
using Cadmus.Itinera.Parts.Codicology;
using Cadmus.Seed.Itinera.Parts.Codicology;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cadmus.Itinera.Parts.Test.Codicology
{
    public sealed class CodLociPartTest
    {
        private static CodLociPart GetPart()
        {
            CodLociPartSeeder seeder = new();
            IItem item = new Item
            {
                FacetId = "default",
                CreatorId = "zeus",
                UserId = "zeus",
                Description = "Test item",
                Title = "Test Item",
                SortKey = ""
            };
            return (CodLociPart)seeder.GetPart(item, null, null);
        }

        private static CodLociPart GetEmptyPart()
        {
            return new CodLociPart
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
            CodLociPart part = GetPart();

            string json = TestHelper.SerializePart(part);
            CodLociPart part2 =
                TestHelper.DeserializePart<CodLociPart>(json)!;

            Assert.Equal(part.Id, part2.Id);
            Assert.Equal(part.TypeId, part2.TypeId);
            Assert.Equal(part.ItemId, part2.ItemId);
            Assert.Equal(part.RoleId, part2.RoleId);
            Assert.Equal(part.CreatorId, part2.CreatorId);
            Assert.Equal(part.UserId, part2.UserId);

            Assert.Equal(part.Loci.Count, part2.Loci.Count);
        }

        [Fact]
        public void GetDataPins_NoEntries_Ok()
        {
            CodLociPart part = GetPart();
            part.Loci.Clear();

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
            CodLociPart part = GetEmptyPart();

            for (int n = 1; n <= 3; n++)
            {
                part.Loci.Add(new CodLocus
                {
                    Citation = "c" + n
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
                pin = pins.Find(p => p.Name == "citation" && p.Value == "c" + n);
                Assert.NotNull(pin);
                TestHelper.AssertPinIds(part, pin!);
            }
        }
    }
}
