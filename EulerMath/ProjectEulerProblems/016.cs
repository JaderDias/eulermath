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

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oyster.Math;

namespace ProjectEulerProblems
{
    //Solution With the help of a bigint library
    //[TestClass()]
    public class Sixteen
    {
        public long DigitsSum(string integer)
        {
            var sum = 0L;
            foreach (var digit in integer)
            {
                sum += Convert.ToInt64(digit.ToString());
            }
            return sum;
        }

        [TestMethod()]
        public void DigitsSumTest()
        {
            var expected = 26;
            var target = Math.Pow(2, 15);
            var actual = DigitsSum(target.ToString());
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// What is the sum of the digits of the number 2^(1000)?
        ///</summary>
        [TestMethod()]
        public void SixteenTest()
        {
            long expected = 1366;
            var target = new IntX(2);
            target <<= (int)1e3 - 1;
            var actual = DigitsSum(target.ToString());
            Assert.AreEqual(expected, actual);
        }
    }
}
