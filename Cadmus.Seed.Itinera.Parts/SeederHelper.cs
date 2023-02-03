using Bogus;
using Cadmus.Codicology.Parts;
using Cadmus.Itinera.Parts;
using Cadmus.Refs.Bricks;
using Fusi.Antiquity.Chronology;
using System;
using System.Collections.Generic;

namespace Cadmus.Seed.Itinera.Parts;

internal static class SeederHelper
{
    /// <summary>
    /// Truncates the specified value to the specified number of decimals.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="decimals">The decimals.</param>
    /// <returns>Truncated value.</returns>
    public static double Truncate(double value, int decimals)
    {
        double factor = Math.Pow(10, decimals);
        return Math.Truncate(factor * value) / factor;
    }

    /// <summary>
    /// Gets a random number of document references.
    /// </summary>
    /// <param name="min">The min number of references to get.</param>
    /// <param name="max">The max number of references to get.</param>
    /// <returns>References.</returns>
    public static List<DocReference> GetDocReferences(int min, int max)
    {
        List<DocReference> refs = new();

        for (int n = 1; n <= Randomizer.Seed.Next(min, max + 1); n++)
        {
            refs.Add(new Faker<DocReference>()
                .RuleFor(r => r.Tag, f => f.PickRandom(null, "tag"))
                .RuleFor(r => r.Citation,
                    f => f.Lorem.Word() + " " + f.Lorem.Random.Number(1, 100))
                .RuleFor(r => r.Note, f => f.Lorem.Sentence())
                .Generate());
        }

        return refs;
    }

    /// <summary>
    /// Gets a chronotope.
    /// </summary>
    /// <param name="tag">The tag.</param>
    /// <param name="year">The year.</param>
    /// <returns>The chronotope.</returns>
    public static Chronotope GetChronotope(string tag, int year)
    {
        return new Faker<Chronotope>()
            .RuleFor(c => c.Tag, tag)
            .RuleFor(c => c.Place, f => f.Address.City())
            .RuleFor(c => c.Date, HistoricalDate.Parse($"{year} AD"))
            .Generate();
    }

    /// <summary>
    /// Gets a random number of chronotopes.
    /// </summary>
    /// <param name="min">The min number of chronotopes to get.</param>
    /// <param name="max">The max number of chronotopes to get.</param>
    /// <returns>References.</returns>
    public static List<Chronotope> GetChronotopes(int min, int max)
    {
        List<Chronotope> refs = new();

        for (int n = 1; n <= Randomizer.Seed.Next(min, max + 1); n++)
        {
            refs.Add(new Faker<Chronotope>()
                .RuleFor(r => r.Tag, f => f.PickRandom(null, "tag"))
                .RuleFor(r => r.Place, f => f.Address.City())
                .RuleFor(r => r.Date, HistoricalDate.Parse($"{1300 + n} AD"))
                .Generate());
        }

        return refs;
    }

    public static List<DecoratedId> GetDecoratedIds(int min, int max)
    {
        List<DecoratedId> ids = new();

        for (int n = 1; n <= Randomizer.Seed.Next(min, max + 1); n++)
        {
            ids.Add(new Faker<DecoratedId>()
                .RuleFor(i => i.Id, f => f.Lorem.Word())
                .RuleFor(i => i.Rank, f => f.Random.Short(1, 3))
                .RuleFor(i => i.Tag, f => f.PickRandom(null, f.Lorem.Word()))
                .RuleFor(i => i.Sources, GetDocReferences(min, max))
                .Generate());
        }

        return ids;
    }

    public static List<string> GetExternalIds(int min, int max)
    {
        List<string> ids = new();

        Faker faker = new();
        for (int n = 1; n <= Randomizer.Seed.Next(min, max + 1); n++)
            ids.Add(faker.Lorem.Word() + n);

        return ids;
    }

    public static Assertion GetAssertion()
    {
        return new Faker<Assertion>()
            .RuleFor(a => a.Tag, f => f.PickRandom("a", "b", null))
            .RuleFor(a => a.Rank, f => f.Random.Short(1, 3))
            .RuleFor(a => a.References, GetDocReferences(1, 2))
            .RuleFor(a => a.Note, f => f.Lorem.Sentence().OrNull(f))
            .Generate();
    }

    public static List<CodImage> GetCodImages(int count)
    {
        List<CodImage> images = new();
        for (int n = 1; n <= count; n++)
        {
            images.Add(new Faker<CodImage>()
                .RuleFor(i => i.Id, f => f.Lorem.Word() + n)
                .RuleFor(i => i.Type, f => f.PickRandom("photo", "drawing"))
                .RuleFor(i => i.SourceId, f => f.Lorem.Word())
                .RuleFor(i => i.Label, f => f.Lorem.Sentence())
                .RuleFor(i => i.Copyright, f => f.Person.FullName)
                .Generate());
        }
        return images;
    }
}
