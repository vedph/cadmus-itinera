using System;
using Xunit;
using Cadmus.Core;
using System.Collections.Generic;
using System.Linq;
using Cadmus.Itinera.Parts.Epistolography;
using Cadmus.Seed.Itinera.Parts.Epistolography;

namespace Cadmus.Itinera.Parts.Test.Epistolography
{
    public sealed class LiteraryWorkInfoPartTest
    {
        private static LiteraryWorkInfoPart GetPart()
        {
            LiteraryWorkInfoPartSeeder seeder = new();
            IItem item = new Item
            {
                FacetId = "default",
                CreatorId = "zeus",
                UserId = "zeus",
                Description = "Test item",
                Title = "Test Item",
                SortKey = ""
            };
            return (LiteraryWorkInfoPart)seeder.GetPart(item, null, null);
        }

        private static LiteraryWorkInfoPart GetEmptyPart()
        {
            return new LiteraryWorkInfoPart
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
            LiteraryWorkInfoPart part = GetPart();

            string json = TestHelper.SerializePart(part);
            LiteraryWorkInfoPart part2 =
                TestHelper.DeserializePart<LiteraryWorkInfoPart>(json)!;

            Assert.Equal(part.Id, part2.Id);
            Assert.Equal(part.TypeId, part2.TypeId);
            Assert.Equal(part.ItemId, part2.ItemId);
            Assert.Equal(part.RoleId, part2.RoleId);
            Assert.Equal(part.CreatorId, part2.CreatorId);
            Assert.Equal(part.UserId, part2.UserId);
        }

        [Fact]
        public void GetDataPins_NoTag_Empty()
        {
            LiteraryWorkInfoPart part = new();
            Assert.Empty(part.GetDataPins());
        }

        [Fact]
        public void GetDataPins_NotEmpty_Ok()
        {
            LiteraryWorkInfoPart part = GetEmptyPart();

            part.Languages.Add("grc");
            part.Genres.Add("comedy");
            part.Metres.Add("3ia");
            part.Titles.Add(new AssertedTitle { Value = "The title" });

            List<DataPin> pins = part.GetDataPins(null).ToList();
            TestHelper.AssertValidDataPinNames(pins);
            Assert.Equal(4, pins.Count);

            Assert.NotNull(pins.Find(p => p.Name == "language" && p.Value == "grc"));
            Assert.NotNull(pins.Find(p => p.Name == "genre" && p.Value == "comedy"));
            Assert.NotNull(pins.Find(p => p.Name == "metre" && p.Value == "3ia"));
            Assert.NotNull(pins.Find(p => p.Name == "title" && p.Value == "the title"));
        }
    }
}
