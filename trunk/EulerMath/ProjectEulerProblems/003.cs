// <copyright file="003.cs" company="Company">
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

using System.Diagnostics;
using EulerMath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ProjectEulerProblems
{
    [TestClass()]
    public class Three
    {
        [TestMethod()]
        public void LargestFactorTest()
        {
            var expected = 29;
            var target = new PrimeNumber();
            var actual = target.Factorize(13195);
            Assert.AreEqual(expected, actual[actual.Count - 1]);
        }

        /// <summary>
        /// What is the largest prime factor of the number 600851475143 ?
        ///</summary>
        [TestMethod()]
        public void ThreeTest()
        {
            long expected = 6857;
            var sw = Stopwatch.StartNew();
            var target = new PrimeNumber();
            var actual = target.Factorize(600851475143);
            sw.Stop();
            Assert.AreEqual(expected, actual[actual.Count - 1]);
            Assert.IsTrue(sw.ElapsedMilliseconds < 10);
        }
    }
}
