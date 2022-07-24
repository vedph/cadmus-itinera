using Cadmus.Itinera.Parts.Codicology;
using Xunit;

namespace Cadmus.Itinera.Parts.Test.Epistolography
{
    public sealed class AlnumRangeTest
    {
        [Theory]
        [InlineData("12", 12, null)]
        [InlineData("12a", 12, "a")]
        [InlineData("12ab34", 12, "ab34")]
        public void ParseAlnum_Ok(string text, int n, string a)
        {
            var t = AlnumRange.ParseAlnum(text);
            Assert.NotNull(t);
            Assert.Equal(t!.Item1, n);
            Assert.Equal(t!.Item2, a);
        }

        [Theory]
        [InlineData("12", "12", 1)]
        [InlineData("12a", "12a", 1)]
        [InlineData("12", "18", 7)]
        [InlineData("12a", "12b", 2)]
        public void CountInterpolatedAlnums_Ok(string start, string end,
            int expected)
        {
            int actual = AlnumRange.CountInterpolatedAlnums(start, end);
            Assert.Equal(expected, actual);
        }
    }
}
