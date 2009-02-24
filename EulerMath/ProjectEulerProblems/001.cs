// <copyright file="001.cs" company="Company">
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
