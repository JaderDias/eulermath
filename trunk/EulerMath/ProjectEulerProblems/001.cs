using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ProjectEulerProblems
{
    [TestClass()]
    public class One
    {
        public long SumUpToExcept3and5Multiples(long max)
        {
            var sum = 0;
            for (var i = 1; i < max; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
            }
            return sum;
        }

        [TestMethod()]
        public void SumUpToExcept3and5MultiplesTest()
        {
            Assert.AreEqual(23, SumUpToExcept3and5Multiples(10));
        }
        /// <summary>
        /// Add all the natural numbers below one thousand that are multiples of 3 or 5.
        ///</summary>
        [TestMethod()]
        public void OneTest()
        {
            long expected = 233168;
            var sw = Stopwatch.StartNew();
            var actual = SumUpToExcept3and5Multiples(1000);
            sw.Stop();
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(sw.ElapsedMilliseconds < 6e4);
        }
    }
}
