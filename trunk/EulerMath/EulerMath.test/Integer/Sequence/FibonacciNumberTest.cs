using EulerMath.Integer.Sequence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace EulerMath.test
{
    
    
    /// <summary>
    ///This is a test class for FibonnaciTest and is intended
    ///to contain all FibonnaciTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FibonacciNumberTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Fibonnaci Constructor
        ///</summary>
        [TestMethod()]
        public void FibonnaciConstructorTest()
        {
            var target = new FibonacciNumber();
        }

        //http://www.research.att.com/~njas/sequences/A000045
        int[] expected = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 39088169 };

        /// <summary>
        ///A test for Next
        ///</summary>
        [TestMethod()]
        public void NextTest()
        {
            var target = new FibonacciNumber();
            for (var i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], target.Next());
            }
        }

        /// <summary>
        ///A test for Calc
        ///</summary>
        [TestMethod()]
        public void CalcTest()
        {
            var target = new FibonacciNumber();
            var actual = new List<int>();
            for (var i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], target.Calc(i));
            }
        }

        /// <summary>
        ///A performance test for Calc
        ///</summary>
        [TestMethod()]
        public void CalcPerformanceTest()
        {
            var operationsPerSecond = 1e6;
            var target = new FibonacciNumber();
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < operationsPerSecond; i++)
            {
                target.Calc(i);
            }
            sw.Stop();
        }

        /// <summary>
        ///A performance test for NextInt32
        ///</summary>
        public void NextInt32PerformanceTest()
        {
            var operationsPerSecond = 4e7;
            var target = new FibonacciNumber();
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < operationsPerSecond; i++)
            {
                target.Next();
            }
            sw.Stop();
        }
    }
}
