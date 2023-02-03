﻿using Cadmus.Core;
using Cadmus.Itinera.Parts.Epistolography;
using Cadmus.Seed.Itinera.Parts.Epistolography;
using Fusi.Tools.Configuration;
using System;
using System.Reflection;
using Xunit;

namespace Cadmus.Seed.Itinera.Parts.Test.Epistolography;

public sealed class LiteraryWorkInfoPartSeederTest
{
    private static readonly PartSeederFactory _factory =
            TestHelper.GetFactory();
    private static readonly SeedOptions _seedOptions =
        _factory.GetSeedOptions();
    private static readonly IItem _item =
        _factory.GetItemSeeder().GetItem(1, "facet");

    [Fact]
    public void TypeHasTagAttribute()
    {
        Type t = typeof(LiteraryWorkInfoPartSeeder);
        TagAttribute? attr = t.GetTypeInfo().GetCustomAttribute<TagAttribute>();
        Assert.NotNull(attr);
        Assert.Equal("seed.it.vedph.itinera.literary-work-info", attr!.Tag);
    }

    [Fact]
    public void Seed_Ok()
    {
        LiteraryWorkInfoPartSeeder seeder = new();
        seeder.SetSeedOptions(_seedOptions);

        IPart part = seeder.GetPart(_item, null, _factory);

        Assert.NotNull(part);

        LiteraryWorkInfoPart? p = part as LiteraryWorkInfoPart;
        Assert.NotNull(p);

        TestHelper.AssertPartMetadata(p!);
        Assert.NotEmpty(p!.Titles);
    }
}
