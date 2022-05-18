using System;
using Xunit;
using Cadmus.Core;
using System.Collections.Generic;
using System.Linq;
using Cadmus.Itinera.Parts.Codicology;
using Cadmus.Seed.Itinera.Parts.Codicology;
using System.Globalization;

namespace Cadmus.Itinera.Parts.Test.Codicology
{
    public sealed class CodPoemRangesPartTest
    {
        private static CodPoemRangesPart GetPart()
        {
            CodPoemRangesPartSeeder seeder = new();
            IItem item = new Item
            {
                FacetId = "default",
                CreatorId = "zeus",
                UserId = "zeus",
                Description = "Test item",
                Title = "Test Item",
                SortKey = ""
            };
            return (CodPoemRangesPart)seeder.GetPart(item, null, null);
        }

        private static CodPoemRangesPart GetEmptyPart()
        {
            return new CodPoemRangesPart
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
            CodPoemRangesPart part = GetPart();

            string json = TestHelper.SerializePart(part);
            CodPoemRangesPart part2 =
                TestHelper.DeserializePart<CodPoemRangesPart>(json)!;

            Assert.Equal(part.Id, part2.Id);
            Assert.Equal(part.TypeId, part2.TypeId);
            Assert.Equal(part.ItemId, part2.ItemId);
            Assert.Equal(part.RoleId, part2.RoleId);
            Assert.Equal(part.CreatorId, part2.CreatorId);
            Assert.Equal(part.UserId, part2.UserId);
        }

        [Fact]
        public void GetDataPins_Ok()
        {
            CodPoemRangesPart part = GetEmptyPart();

            for (int n = 1; n <= 3; n++)
            {
                part.Ranges.Add(new AlnumRange
                {
                    A = n.ToString(CultureInfo.InvariantCulture)
                });
                part.Layouts.Add(new CodPoemLayout
                {
                    Range = new AlnumRange
                        { A = n.ToString(CultureInfo.InvariantCulture) },
                    Layout = n % 2 == 0 ? "l2" : "l1",
                    SortType = "t"
                });
            }

            List<DataPin> pins = part.GetDataPins(null).ToList();
            Assert.Equal(3, pins.Count);

            // type
            DataPin? pin = pins.Find(p => p.Name == "sort-type" && p.Value == "t");
            Assert.NotNull(pin);
            TestHelper.AssertPinIds(part, pin!);

            // layout-X-count
            pin = pins.Find(p => p.Name == "layout-l1-count" && p.Value == "2");
            Assert.NotNull(pin);
            TestHelper.AssertPinIds(part, pin!);

            pin = pins.Find(p => p.Name == "layout-l2-count" && p.Value == "1");
            Assert.NotNull(pin);
            TestHelper.AssertPinIds(part, pin!);
        }
    }
}
