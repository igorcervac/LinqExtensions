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

        [DataRow(100, 50)]
        [DataRow(25, 75)]
        [DataRow(-25, -75)]
        [TestMethod]
        public void MinBy(int arg, int arg2)
        {
            var values = new[] { new { Temperature = arg }, new { Temperature = arg2 } };
            var actual = values.MinBy(x => x.Temperature);
            Assert.AreEqual(values.OrderBy(x => x.Temperature).First(), actual);
        }

        [DataRow(100, 50)]
        [DataRow(25, 75)]
        [DataRow(-25, -75)]
        [TestMethod]
        public void MaxBy(int arg, int arg2)
        {
            var values = new[] { new { Temperature = arg }, new { Temperature = arg2 } };
            var actual = values.MaxBy(x => x.Temperature);
            Assert.AreEqual(values.OrderByDescending(x => x.Temperature).First(), actual);
        }
    }
}
