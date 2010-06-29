using EulerMath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace EulerMath.test
{
    
    
    /// <summary>
    ///This is a test class for RationalTest and is intended
    ///to contain all RationalTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RationalTest
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
        ///A test for Numerator
        ///</summary>
        [TestMethod()]
        public void NumeratorTest()
        {
            long expected = 9;
            Rational target = Rational.FromFraction(expected, 1);
            long actual;
            actual = target.Numerator;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Denominator
        ///</summary>
        [TestMethod()]
        public void DenominatorTest()
        {
            long expected = 9;
            Rational target = Rational.FromFraction(1, expected);
            long actual;
            actual = target.Denominator;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FromFloatingPointValue
        ///</summary>
        [TestMethod()]
        public void FromFloatingPointValueTest()
        {
            var expectedNumerator = 9L;
            var expectedDenominator = 40L;
            var factor = 2d;
            var number = ((double)expectedNumerator * factor) / ((double)expectedDenominator * factor);
            Rational actual = Rational.FromFloatingPointValue(number);
            Assert.AreEqual(expectedNumerator, actual.Numerator);
            Assert.AreEqual(expectedDenominator, actual.Denominator);
            expectedNumerator = 1234567890123456L;
            expectedDenominator = 1L;
            number = ((double)expectedNumerator * factor) / ((double)expectedDenominator * factor);
            actual = Rational.FromFloatingPointValue(number);
            Assert.AreEqual(expectedNumerator, actual.Numerator);
            Assert.AreEqual(expectedDenominator, actual.Denominator);
            expectedNumerator = 1L;
            expectedDenominator = 1L << 9; //if 10 crashes
            number = ((double)expectedNumerator * factor) / ((double)expectedDenominator * factor);
            actual = Rational.FromFloatingPointValue(number);
            Assert.AreEqual(expectedNumerator, actual.Numerator);
            Assert.AreEqual(expectedDenominator, actual.Denominator);
        }

        /// <summary>
        ///A test for FromFraction
        ///</summary>
        [TestMethod()]
        public void FromFractionTest()
        {
            long numerator = 9;
            long denominator = 40;
            var factor = 2L;
            Rational target = Rational.FromFraction(numerator * factor, denominator * factor);
            Assert.AreEqual(numerator, target.Numerator);
            Assert.AreEqual(denominator, target.Denominator);
        }

        /// <summary>
        ///A test for Simplify
        ///</summary>
        [TestMethod()]
        public void SimplifyTest()
        {
            var expectedNumerator = 1L;
            var expectedDenominator = 4L;
            var numerator = 9L;
            var denominator = 40L;
            double expected = 1d / denominator;
            Rational target = Rational.FromFraction(numerator, denominator);
            long maxDenominator = 5;
            var actual = target.Simplify(maxDenominator);
            Assert.IsTrue(Rational.AreRelativelyApproximatelyEqual(expected, actual));
            Assert.AreEqual(expectedNumerator, target.Numerator);
            Assert.AreEqual(expectedDenominator, target.Denominator);
        }

        /// <summary>
        ///A test for SimplifyWithAvoidedDenominator
        ///</summary>
        [TestMethod()]
        public void SimplifyWithAvoidedDenominatorTest()
        {
            {
                long numerator = 9L;
                long denominator = 40L;
                Rational target = Rational.FromFraction(numerator, denominator);
                long maxDenominator = 5L;
                long avoidedDenominator = 4L;
                double expectedNumerator = 1L;
                double expectedDenominator = 5L;
                double expected = 1d / denominator;
                double actual;
                actual = target.Simplify(maxDenominator, avoidedDenominator);
                Assert.IsTrue(Rational.AreRelativelyApproximatelyEqual(expected, actual));
                Assert.AreEqual(expectedDenominator, target.Denominator);
                Assert.AreEqual(expectedNumerator, target.Numerator);
            }
            {
                long numerator = 1L;
                long denominator = 2L;
                Rational target = Rational.FromFraction(numerator, denominator);
                long maxDenominator = 1L;
                long avoidedDenominator = 1L;
                double expectedNumerator = 1L;
                double expectedDenominator = 1L;
                double expected = 1d / denominator;
                double actual;
                actual = target.Simplify(maxDenominator, avoidedDenominator);
                Assert.IsTrue(Rational.AreRelativelyApproximatelyEqual(expected, actual));
                Assert.AreEqual(expectedDenominator, target.Denominator);
                Assert.AreEqual(expectedNumerator, target.Numerator);
            }
            {
                long numerator = 1L;
                long denominator = 2L;
                Rational target = Rational.FromFraction(numerator, denominator);
                long maxDenominator = 2L;
                long avoidedDenominator = 1L;
                double expectedNumerator = 1L;
                double expectedDenominator = 2L;
                double expected = 0d / denominator;
                double actual;
                actual = target.Simplify(maxDenominator, avoidedDenominator);
                Assert.IsTrue(Rational.AreRelativelyApproximatelyEqual(expected, actual));
                Assert.AreEqual(expectedDenominator, target.Denominator);
                Assert.AreEqual(expectedNumerator, target.Numerator);
            }
        }

        /// <summary>
        ///A test for IsAmbiguous
        ///</summary>
        [TestMethod()]
        public void IsAmbiguousTest()
        {
            long numerator = 9L;
            long denominator = 40L;
            Rational target = Rational.FromFraction(numerator, denominator);
            bool expected = true;
            bool actual;
            actual = target.IsAmbiguous();
            Assert.AreEqual(expected, actual);
            numerator = 9L;
            denominator = 31L;
            target = Rational.FromFraction(numerator, denominator);
            expected = false;
            actual = target.IsAmbiguous();
            Assert.AreEqual(expected, actual);
            numerator = 4L;
            denominator = 2L;
            target = Rational.FromFraction(numerator, denominator);
            expected = false;
            actual = target.IsAmbiguous();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AreRelativelyApproximatelyEqual
        ///</summary>
        [TestMethod()]
        public void AreRelativelyApproximatelyEqualTest()
        {
            double a = 1d/3d;
            double b = a * 1.000000000002d;
            bool expected = true;
            bool actual;
            actual = Rational.AreRelativelyApproximatelyEqual(a, b);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AreAbsolutelyApproximatelyEqual
        ///</summary>
        [TestMethod()]
        public void AreAbsolutelyApproximatelyEqualTest()
        {
            {
                double a = 0d;
                double b = a + double.Epsilon;
                bool expected = true;
                bool actual;
                actual = Rational.AreAbsolutelyApproximatelyEqual(a, b);
                Assert.AreEqual(expected, actual);
            }
            {
                double a = 0d;
                double b = a + 10e-14;
                bool expected = false;
                bool actual;
                actual = Rational.AreAbsolutelyApproximatelyEqual(a, b);
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
