using Cadmus.Core;
using Cadmus.Itinera.Parts.Epistolography;
using Cadmus.Refs.Bricks;
using Cadmus.Seed.Itinera.Parts.Epistolography;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cadmus.Itinera.Parts.Test.Epistolography;

public sealed class ReferencedTextsPartTest
{
    private static ReferencedTextsPart GetPart()
    {
        ReferencedTextsPartSeeder seeder = new();
        IItem item = new Item
        {
            FacetId = "default",
            CreatorId = "zeus",
            UserId = "zeus",
            Description = "Test item",
            Title = "Test Item",
            SortKey = ""
        };
        return (ReferencedTextsPart)seeder.GetPart(item, null, null);
    }

    private static ReferencedTextsPart GetEmptyPart()
    {
        return new ReferencedTextsPart
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
        ReferencedTextsPart part = GetPart();

        string json = TestHelper.SerializePart(part);
        ReferencedTextsPart part2 =
            TestHelper.DeserializePart<ReferencedTextsPart>(json)!;

        Assert.Equal(part.Id, part2.Id);
        Assert.Equal(part.TypeId, part2.TypeId);
        Assert.Equal(part.ItemId, part2.ItemId);
        Assert.Equal(part.RoleId, part2.RoleId);
        Assert.Equal(part.CreatorId, part2.CreatorId);
        Assert.Equal(part.UserId, part2.UserId);

        Assert.Equal(part.Texts.Count, part2.Texts.Count);
    }

    [Fact]
    public void GetDataPins_NoEntries_Ok()
    {
        ReferencedTextsPart part = GetPart();
        part.Texts.Clear();

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
        ReferencedTextsPart part = GetEmptyPart();

        for (int n = 1; n <= 3; n++)
        {
            part.Texts.Add(new ReferencedText
            {
                Type = "type" + n,
                TargetId = new AssertedCompositeId
                {
                    Target = new PinTarget
                    {
                        Gid = "target" + n,
                        Label = "target" + n
                    }
                }
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
            // type
            pin = pins.Find(p => p.Name == "type" && p.Value == "type" + n);
            Assert.NotNull(pin);
            TestHelper.AssertPinIds(part, pin!);

            // target-id
            pin = pins.Find(p => p.Name == "target-id" && p.Value == "target" + n);
            Assert.NotNull(pin);
            TestHelper.AssertPinIds(part, pin!);
        }
    }
}
