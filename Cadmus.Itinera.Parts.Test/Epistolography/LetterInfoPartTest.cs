﻿using System;
using Xunit;
using Cadmus.Core;
using Cadmus.Itinera.Parts.Epistolography;
using Cadmus.Seed.Itinera.Parts.Epistolography;
using System.Collections.Generic;
using System.Linq;

namespace Cadmus.Itinera.Parts.Test.Epistolography;

public sealed class LetterInfoPartTest
{
    private static LetterInfoPart GetPart()
    {
        LetterInfoPartSeeder seeder = new();
        IItem item = new Item
        {
            FacetId = "default",
            CreatorId = "zeus",
            UserId = "zeus",
            Description = "Test item",
            Title = "Test Item",
            SortKey = ""
        };
        return (LetterInfoPart)seeder.GetPart(item, null, null);
    }

    private static LetterInfoPart GetEmptyPart()
    {
        return new LetterInfoPart
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
        LetterInfoPart part = GetPart();

        string json = TestHelper.SerializePart(part);
        LetterInfoPart part2 = TestHelper.DeserializePart<LetterInfoPart>(json)!;

        Assert.Equal(part.Id, part2.Id);
        Assert.Equal(part.TypeId, part2.TypeId);
        Assert.Equal(part.ItemId, part2.ItemId);
        Assert.Equal(part.RoleId, part2.RoleId);
        Assert.Equal(part.CreatorId, part2.CreatorId);
        Assert.Equal(part.UserId, part2.UserId);
    }

    [Fact]
    public void GetDataPins_Tag_1()
    {
        LetterInfoPart part = GetEmptyPart();
        part.Subject = "The subject";
        part.Header = "Franciscus Marco salutem";

        List<DataPin> pins = part.GetDataPins(null).ToList();
        Assert.Equal(2, pins.Count);

        DataPin? pin = pins.Find(p => p.Name == "subject" && p.Value == "the subject");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "header" && p.Value == "franciscus marco salutem");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
    }
}
