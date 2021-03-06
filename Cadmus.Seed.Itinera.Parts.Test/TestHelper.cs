using Cadmus.Core;
using Cadmus.Core.Config;
using Cadmus.Itinera.Parts.Epistolography;
using Cadmus.Seed.Itinera.Parts.Epistolography;
using Fusi.Microsoft.Extensions.Configuration.InMemoryJson;
using Microsoft.Extensions.Configuration;
using SimpleInjector;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using Xunit;

namespace Cadmus.Seed.Itinera.Parts.Test
{
    static internal class TestHelper
    {
        static public string LoadResourceText(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            using StreamReader reader = new(
                Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    $"Cadmus.Seed.Itinera.Parts.Test.Assets.{name}")!,
                Encoding.UTF8);
            return reader.ReadToEnd();
        }

        static public PartSeederFactory GetFactory()
        {
            // map
            TagAttributeToTypeMap map = new TagAttributeToTypeMap();
            map.Add(new[]
            {
                // Cadmus.Core
                typeof(StandardItemSortKeyBuilder).Assembly,
                // Cadmus.Itinera.Parts
                typeof(PersonInfoPart).Assembly
            });

            // container
            Container container = new Container();
            PartSeederFactory.ConfigureServices(
                container,
                new StandardPartTypeProvider(map),
                new[]
                {
                    // Cadmus.Seed.Itinera.Parts
                    typeof(PersonInfoPartSeeder).Assembly
                });

            // config
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddInMemoryJson(LoadResourceText("SeedConfig.json"));
            var configuration = builder.Build();

            return new PartSeederFactory(container, configuration);
        }

        static public void AssertPartMetadata(IPart part)
        {
            Assert.NotNull(part.Id);
            Assert.NotNull(part.ItemId);
            Assert.NotNull(part.UserId);
            Assert.NotNull(part.CreatorId);
        }
    }
}
