using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ProjectEulerProblems
{
    
    
    /// <summary>
    ///This is a test class for FibonacciNumberTest and is intended
    ///to contain all FibonacciNumberTest Unit Tests
    ///</summary>
    [TestClass()]
    public class One
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


        /// <summary>
        /// SumUpToExcept3and5Multiples test
        ///</summary>
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
