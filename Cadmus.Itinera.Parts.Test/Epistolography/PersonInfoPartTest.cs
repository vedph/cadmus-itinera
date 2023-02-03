using System;
using Xunit;
using Cadmus.Core;
using System.Collections.Generic;
using System.Linq;
using Cadmus.Itinera.Parts.Epistolography;
using Cadmus.Seed.Itinera.Parts.Epistolography;

namespace Cadmus.Itinera.Parts.Test.Epistolography;

public sealed class PersonInfoPartTest
{
    private static PersonInfoPart GetPart()
    {
        PersonInfoPartSeeder seeder = new();
        IItem item = new Item
        {
            FacetId = "default",
            CreatorId = "zeus",
            UserId = "zeus",
            Description = "Test item",
            Title = "Test Item",
            SortKey = ""
        };
        return (PersonInfoPart)seeder.GetPart(item, null, null);
    }

    private static PersonInfoPart GetEmptyPart()
    {
        return new PersonInfoPart
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
        PersonInfoPart part = GetPart();

        string json = TestHelper.SerializePart(part);
        PersonInfoPart part2 = TestHelper.DeserializePart<PersonInfoPart>(json)!;

        Assert.Equal(part.Id, part2.Id);
        Assert.Equal(part.TypeId, part2.TypeId);
        Assert.Equal(part.ItemId, part2.ItemId);
        Assert.Equal(part.RoleId, part2.RoleId);
        Assert.Equal(part.CreatorId, part2.CreatorId);
        Assert.Equal(part.UserId, part2.UserId);
        // TODO: check parts data here...
    }

    [Fact]
    public void GetDataPins_Tag_1()
    {
        PersonInfoPart part = GetEmptyPart();
        part.Sex = 'M';
        part.Bio = "The bio here.";

        List<DataPin> pins = part.GetDataPins(null).ToList();
        Assert.Single(pins);

        DataPin? pin = pins.Find(p => p.Name == "sex" && p.Value == "M");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
    }
}
