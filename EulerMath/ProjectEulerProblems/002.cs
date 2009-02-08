using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using EulerMath.Integer.Sequence;
namespace ProjectEulerProblems
{
    
    
    /// <summary>
    ///This is a test class for FibonacciNumberTest and is intended
    ///to contain all FibonacciNumberTest Unit Tests
    ///</summary>
    [TestClass()]
    public class Two
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
