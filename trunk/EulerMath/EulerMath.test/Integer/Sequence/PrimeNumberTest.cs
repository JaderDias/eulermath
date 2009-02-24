// <copyright file="PrimeNumberTest.cs" company="Company">
// Copyright (c) Jader Dias. All rights reserved.
// </copyright>
// <author>Jader Dias</author>
// <email>jaderd@gmail.com</email>
// <date>2009-02-23</date>

// This file is part of EulerMath.
//
// EulerMath is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// EulerMath is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with EulerMath.  If not, see <http://www.gnu.org/licenses/>.

using EulerMath.Integers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace EulerMath.test
{
    
    
    /// <summary>
    ///This is a test class for PrimeTest and is intended
    ///to contain all PrimeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PrimeNumberTest
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
        ///A test for Prime Constructor
        ///</summary>
        [TestMethod()]
        public void PrimeConstructorTest()
        {
            var target = new PrimeNumber();
        }

        //http://www.research.att.com/~njas/sequences/A000040
        int[] expected = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271 };

        /// <summary>
        ///A test for Next
        ///</summary>
        [TestMethod()]
        public void NextTest()
        {
            var target = new PrimeNumber();
            for (var i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], target.NextNumber());
            }
        }

        /// <summary>
        ///A test for Calc
        ///</summary>
        [TestMethod()]
        public void CalcTest()
        {
            var target = new PrimeNumber();
            var actual = new List<int>();
            for (var i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], target.Calc(i));
            }
        }

        /// <summary>
        ///A test for GetLowestFactor
        ///</summary>
        [TestMethod()]
        public void GetLowestFactor()
        {
            var expected = new long[] { 13, 17, 17 };
            var number = 1L;
            foreach (var prime in expected)
            {
                number *= prime;
            }
            var target = new PrimeNumber();
            var actual = target.GetLowestFactor(number);
            Assert.AreEqual(expected[0], actual);
        }

        /// <summary>
        ///A test for Factorize
        ///</summary>
        [TestMethod()]
        public void FactorizeTest()
        {
            var expected = new long[] { 2, 5, 7, 7, 13, 17, 17 };
            var target = new PrimeNumber();
            var number = 1L;
            foreach(var prime in expected)
            {
                number *= prime;
            }
            var actual = target.Factorize(number);
            Assert.AreEqual(expected.Length, actual.Count);
            for (var index = 0; index < expected.Length; index++)
            {
                Assert.AreEqual(expected[index], actual[index]);
            }
        }

        /// <summary>
        ///A performance test for Calc
        ///</summary>
        public void CalcPerformanceTest()
        {
            var operationsPerSecond = 1e4;
            var target = new PrimeNumber();
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
            var target = new PrimeNumber();
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < operationsPerSecond; i++)
            {
                target.NextNumber();
            }
            sw.Stop();
        }
    }
}
