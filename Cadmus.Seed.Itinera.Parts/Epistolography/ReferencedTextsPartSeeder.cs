﻿using Bogus;
using Cadmus.Core;
using Cadmus.Itinera.Parts.Epistolography;
using Cadmus.Refs.Bricks;
using Fusi.Tools.Configuration;
using System;
using System.Collections.Generic;

namespace Cadmus.Seed.Itinera.Parts.Epistolography;

/// <summary>
/// Seeder for <see cref="ReferencedTextsPart"/>.
/// Tag: <c>seed.it.vedph.itinera.referenced-texts</c>.
/// </summary>
/// <seealso cref="PartSeederBase" />
[Tag("seed.it.vedph.itinera.referenced-texts")]
public sealed class ReferencedTextsPartSeeder : PartSeederBase
{
    private static List<ReferencedText> GetTexts(int count)
    {
        List<ReferencedText> texts = new();
        for (int n = 1; n <= count; n++)
        {
            texts.Add(new Faker<ReferencedText>()
                .RuleFor(t => t.Type, f => f.PickRandom("reply-to", "quotation-of"))
                .RuleFor(t => t.TargetId, f => new AssertedCompositeId
                {
                    Target = new PinTarget
                    {
                        Gid = f.Internet.Url() + "/" + n,
                        Label = f.Lorem.Word() + n
                    }
                })
                .RuleFor(t => t.TargetCitation,
                    f => $"{n}." + f.Random.Number(1, 100))
                .RuleFor(t => t.SourceCitations,
                    f => new List<string> { $"{n}." + f.Random.Number(1, 100) })
                .Generate());
        }
        return texts;
    }

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

        ReferencedTextsPart part = new Faker<ReferencedTextsPart>()
           .RuleFor(p => p.Texts, f => GetTexts(f.Random.Number(1, 2)))
           .Generate();
        SetPartMetadata(part, roleId, item);

        return part;
    }
}
