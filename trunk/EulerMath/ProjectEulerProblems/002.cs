using System.Diagnostics;
using EulerMath.Integer.Sequence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ProjectEulerProblems
{
    [TestClass()]
    public class Two
    {
        public long GetEven(long limit)
        {
            var fib = new FibonacciNumber();
            var sum = 0L;
            for (var i = 0L; i < limit; i = fib.Next())
            {
                if (i % 2 == 0)
                    sum += i;
            }
            return sum;
        }

        [TestMethod()]
        public void GetEvenTest()
        {
            Assert.AreEqual(44, GetEven(100));
        }

        /// <summary>
        /// Find the sum of all the even-valued terms in the sequence which do not exceed four million.
        ///</summary>
        [TestMethod()]
        public void TwoTest()
        {
            long expected = 4613732;
            var sw = Stopwatch.StartNew();
            var actual = GetEven((long)4e6);
            sw.Stop();
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(sw.ElapsedMilliseconds < 6e4);
        }
    }
}
