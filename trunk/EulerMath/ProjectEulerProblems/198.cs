// <copyright file="198.cs" company="Company">
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
using System.Collections.Generic;
using System;
namespace ProjectEulerProblems
{
    public class Ambiguosity
    {
        public static bool IsAmbiguous(double number, double denominatorBound)
        {
            return false;
        }
    }

    [TestClass()]
    public class AHundredAndNinetyEight
    {
        [TestMethod()]
        public void AmbiguosityTest()
        {
            var expected = true;
            var actual = Ambiguosity.IsAmbiguous(9d/40d, 6);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// How many ambiguous numbers x = p/q, 0 < x < 1/100, are there whose denominator q does not exceed 10^(8)?
        ///</summary>
        [TestMethod()]
        public void TwoHundredAndThirtyTest()
        {
            var expected = "850481152593119296";
            string actual = "";
            var target = new FibonacciString(
                 "1415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679"
                , "8214808651328230664709384460955058223172535940812848111745028410270193852110555964462294895493038196"
            );
            var ds = new List<long>();
            for (long n = 0; n <= 17; n++)
            {
                long d = (127 + 19 * n) * (long)Math.Pow(7, n);
                ds.Add(d);
            }
            foreach (var d in ds)
            {
                var operand = target.D(d);
                actual = operand + actual;
            }
            Assert.AreEqual(expected, actual);
        }
    }
}
