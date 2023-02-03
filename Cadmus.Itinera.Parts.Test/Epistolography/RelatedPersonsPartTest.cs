using Cadmus.Core;
using Cadmus.Itinera.Parts.Epistolography;
using Cadmus.Refs.Bricks;
using Cadmus.Seed.Itinera.Parts.Epistolography;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cadmus.Itinera.Parts.Test.Epistolography;

public sealed class RelatedPersonsPartTest
{
    private static RelatedPersonsPart GetPart()
    {
        RelatedPersonsPartSeeder seeder = new();
        IItem item = new Item
        {
            FacetId = "default",
            CreatorId = "zeus",
            UserId = "zeus",
            Description = "Test item",
            Title = "Test Item",
            SortKey = ""
        };
        return (RelatedPersonsPart)seeder.GetPart(item, null, null);
    }

    private static RelatedPersonsPart GetEmptyPart()
    {
        return new RelatedPersonsPart
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
        RelatedPersonsPart part = GetPart();

        string json = TestHelper.SerializePart(part);
        RelatedPersonsPart part2 =
            TestHelper.DeserializePart<RelatedPersonsPart>(json)!;

        Assert.Equal(part.Id, part2.Id);
        Assert.Equal(part.TypeId, part2.TypeId);
        Assert.Equal(part.ItemId, part2.ItemId);
        Assert.Equal(part.RoleId, part2.RoleId);
        Assert.Equal(part.CreatorId, part2.CreatorId);
        Assert.Equal(part.UserId, part2.UserId);

        Assert.Equal(part.Persons.Count, part2.Persons.Count);
    }

    [Fact]
    public void GetDataPins_NoEntries_Ok()
    {
        RelatedPersonsPart part = GetPart();
        part.Persons.Clear();

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
        RelatedPersonsPart part = GetEmptyPart();

        for (int n = 1; n <= 3; n++)
        {
            part.Persons.Add(new RelatedPerson
            {
                Type = n % 2 == 0 ? "even" : "odd",
                Ids = new List<AssertedId>
                {
                    new AssertedId
                    {
                        Value = "target" + n
                    }
                },
                Name = "name" + n
            });
        }

        List<DataPin> pins = part.GetDataPins(null).ToList();

        Assert.Equal(9, pins.Count);

        DataPin? pin = pins.Find(p => p.Name == "tot-count");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
        Assert.Equal("3", pin!.Value);

        pin = pins.Find(p => p.Name == "type" && p.Value == "even");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "type" && p.Value == "odd");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        for (int n = 1; n <= 3; n++)
        {
            // target
            pin = pins.Find(p => p.Name == "target-id" && p.Value == "target" + n);
            Assert.NotNull(pin);
            TestHelper.AssertPinIds(part, pin!);

            // name
            pin = pins.Find(p => p.Name == "name" && p.Value == "name" + n);
            Assert.NotNull(pin);
            TestHelper.AssertPinIds(part, pin!);
        }
    }
}
