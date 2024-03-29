﻿using Bogus;
using Cadmus.Core;
using Cadmus.Itinera.Parts.Epistolography;
using Cadmus.Refs.Bricks;
using Fusi.Tools.Configuration;
using System;
using System.Collections.Generic;

namespace Cadmus.Seed.Itinera.Parts.Epistolography;

/// <summary>
/// Seeder for <see cref="LiteraryWorkInfoPart"/>.
/// Tag: <c>seed.it.vedph.itinera.literary-work-info</c>.
/// </summary>
/// <seealso cref="PartSeederBase" />
[Tag("seed.it.vedph.itinera.literary-work-info")]
public sealed class LiteraryWorkInfoPartSeeder : PartSeederBase
{
    /// <summary>
    /// Creates and seeds a new part.
    /// </summary>
    /// <param name="item">The item this part should belong to.</param>
    /// <param name="roleId">The optional part role ID.</param>
    /// <param name="factory">The part seeder factory. This is used
    /// for layer parts, which need to seed a set of fragments.</param>
    /// <returns>A new part.</returns>
    /// <exception cref="ArgumentNullException">item or factory</exception>
    public override IPart GetPart(IItem item, string? roleId,
        PartSeederFactory? factory)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        LiteraryWorkInfoPart part = new Faker<LiteraryWorkInfoPart>()
           .RuleFor(p => p.Languages,
                f => new List<string> { f.PickRandom("lat", "grc") })
           .RuleFor(p => p.Genre, f => f.PickRandom("prose.-", "poetry.-"))
           .RuleFor(p => p.Metres,
                f => new List<string> { f.PickRandom("11s", "7s") })
           .RuleFor(p => p.Strophes,
                f => new List<string> { f.PickRandom("s1", "s2") })
           .RuleFor(p => p.AuthorIds, f => new List<AssertedCompositeId>
           {
               new AssertedCompositeId
               {
                   Target = new PinTarget
                   {
                       Gid = f.Internet.UserName().ToLower(),
                       Label = "target"
                   }
               }
           })
           .RuleFor(p => p.Titles, f => new List<AssertedTitle>
           {
               new AssertedTitle
               {
                   Value = f.Lorem.Sentence(),
                   Assertion = SeederHelper.GetAssertion()
               }
           })
           .RuleFor(p => p.IsLost, f => f.Random.Bool())
           .RuleFor(p => p.Note, f => f.Lorem.Sentence().OrNull(f))
           .Generate();
        SetPartMetadata(part, roleId, item);

        return part;
    }
}
