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
    /// <summary>
    /// Currently too slow = 183 years
    /// </summary>
//[TestClass()]
    public class AHundredAndNinetyEight
    {
        public long CountNotZero(double maxValue, long maxDenominator)
        {
            var count = 0L;
            for (var denominator = 2L; denominator <= maxDenominator; denominator++)
            {
                count += ((long)(Math.Ceiling(((double)denominator) * maxValue))) - 1;
            }
            return count;
        }

        public long Count(double maxValue, long maxDenominator)
        {
            var count = 0L;
            for (var denominator = 2L; denominator <= maxDenominator; denominator++)
            {
                var maxNumerator = (long)Math.Ceiling(((double)denominator) * maxValue);
                for (var numerator = 1L; numerator < maxNumerator; numerator++)
                {
                    if (Rational.FromFraction(numerator, denominator).IsAmbiguous())
                        count++;
                }
            }
            return count;
        }

        [TestMethod()]
        public void CountTest()
        {
            var expected = 1f;
            var actual = Count(.1d, 11);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// How many ambiguous numbers x = p/q, 0 < x < 1/100, are there whose denominator q does not exceed 10^(8)?
        ///</summary>
        [TestMethod()]
        public void AHundredAndNinetyEightTest()
        {
            var sw = Stopwatch.StartNew();
            var actual = Count(.1d, (long)1e4);
            sw.Stop();
        }
        //1e3 {00:00:00.3477140}
        //1e4 {00:00:38.5011444}
        //1e8 183 years
    }
}
