// <copyright file="002.cs" company="Company">
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
    public class Two
    {
        public long GetEven(long limit)
        {
            var fib = new FibonacciNumber();
            var sum = 0L;
            for (var i = 0L; i < limit; i = fib.NextNumber())
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
