using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LinqExtensions.Tests
{
    [TestClass]
    public class LinqExtensionsTests
    {
        [DataRow(false, false, false)]
        [DataRow(false, true, true)]
        [DataRow(true, false, true)]
        [DataRow(true, true, true)]
        [TestMethod]
        public void LogicalOr(bool arg, bool arg2, bool expected)
        {
            var values = new[] { arg, arg2 };
            var actual = values.LogicalOr();
            Assert.AreEqual(expected, actual);
        }

        [DataRow(false, false, false)]
        [DataRow(false, true, false)]
        [DataRow(true, false, false)]
        [DataRow(true, true, true)]
        [TestMethod]
        public void LogicalAnd(bool arg, bool arg2, bool expected)
        {
            var values = new[] { arg, arg2 };
            var actual = values.LogicalAnd();
            Assert.AreEqual(expected, actual);
        }

        [DataRow(100, 50, 50)]
        [DataRow(25, 75, 25)]
        [DataRow(-25, -75, -75)]
        [TestMethod]
        public void MinBy(int arg, int arg2, int expected)
        {
            var values = new[] { new { Temperature = arg }, new { Temperature = arg2 } };
            var actual = values.MinBy(x => x.Temperature);
            Assert.AreEqual(values.FirstOrDefault(x => x.Temperature == expected), actual);
        }

        [DataRow(100, 50, 100)]
        [DataRow(25, 75, 75)]
        [DataRow(-25, -75, -25)]
        [TestMethod]
        public void MaxBy(int arg, int arg2, int expected)
        {
            var values = new[] { new { Temperature = arg }, new { Temperature = arg2 } };
            var actual = values.MaxBy(x => x.Temperature);
            Assert.AreEqual(values.FirstOrDefault(x => x.Temperature == expected), actual);
        }

        [DataRow(10, 100, 10, 10)]
        [DataRow(100, 100, 10, 100)]
        [DataRow(10, 1000, 1000, 1000)]
        [TestMethod]
        public void DistinctBy(int arg, int arg2, int arg3, int expected)
        {
            var values = new[]
            {
                new
                {
                    Id = arg,
                },
                new
                {
                    Id = arg2
                },
                new
                {
                    Id = arg3
                }
            };
            var distinctValues = values.DistinctBy(x => x.Id);
            Assert.AreEqual(1, distinctValues.Count(x => x.Id == expected));
        }

        [DataRow(50, 50, 50, 50, 3)]
        [DataRow(100, 50, 50, 50, 2)]
        [DataRow(100, 50, 0, 50, 1)]
        [TestMethod]
        public void CountBy(int arg, int arg2, int arg3, int valueToCount, int expected)
        {
            var values = new[] 
            { 
                new 
                { 
                    Temperature = arg 
                }, 
                new 
                { 
                    Temperature = arg2 
                }, 
                new 
                { 
                    Temperature = arg3 
                }
            };
            var actual = values.CountBy(x => x.Temperature);
            Assert.AreEqual(expected, actual[valueToCount]);
        }

        [DataRow(50, 100, 80, 100, 1)]
        [DataRow(50, 0, 80, 50, 2)]
        [DataRow(50, 70, 80, 50, 3)]
        [TestMethod]
        public void RankBy(int value, int value2, int value3, int valueToRank, int expectedRank)
        {
            var values = new[]
            {
                new { Points = value },
                new { Points = value2 },
                new { Points = value3 }
            };
            var clubRankings = values.RankBy(x => x.Points);
            var clubRanking = values.First(x => x.Points == valueToRank);
            Assert.AreEqual(clubRankings[clubRanking], expectedRank);
        }

        [DataRow(10, 20, 30, 3)]
        [DataRow(10, 20, null, 2)]
        [DataRow(10, null, null, 1)]
        [DataRow(null, null, null, 0)]
        [TestMethod]
        public void TrySelect(int? arg, int? arg2, int? arg3, int expectedCount)
        {
            var values = new[] { arg, arg2, arg3 };

            var forecasts = values
                .Select(x => x != null ? (dynamic) new { Temperature = arg } : null)
                .ToList();

            var validForecast = forecasts.TrySelect(x => x.Temperature).ToList();

            Assert.AreEqual(expectedCount, validForecast.Count);
        }
    }
}
