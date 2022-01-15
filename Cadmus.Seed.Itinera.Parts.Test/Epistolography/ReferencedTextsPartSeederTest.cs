using Cadmus.Core;
using Cadmus.Itinera.Parts.Epistolography;
using Cadmus.Seed.Itinera.Parts.Epistolography;
using Fusi.Tools.Config;
using System;
using System.Reflection;
using Xunit;

namespace Cadmus.Seed.Itinera.Parts.Test.Epistolography
{
    public sealed class ReferencedTextsPartSeederTest
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
            Type t = typeof(ReferencedTextsPartSeeder);
            TagAttribute? attr = t.GetTypeInfo().GetCustomAttribute<TagAttribute>();
            Assert.NotNull(attr);
            Assert.Equal("seed.it.vedph.itinera.referenced-texts", attr!.Tag);
        }

        [Fact]
        public void Seed_Ok()
        {
            ReferencedTextsPartSeeder seeder = new();
            seeder.SetSeedOptions(_seedOptions);

            IPart part = seeder.GetPart(_item, null, _factory);

            Assert.NotNull(part);

            ReferencedTextsPart? p = part as ReferencedTextsPart;
            Assert.NotNull(p);

            TestHelper.AssertPartMetadata(p!);

            Assert.NotEmpty(p!.Texts);
        }
    }
}
