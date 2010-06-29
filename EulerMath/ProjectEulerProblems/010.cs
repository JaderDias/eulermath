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
using EulerMath;

namespace ProjectEulerProblems
{
    //Slow: about 2 minutes
    //[TestClass()]
    public class Ten
    {
        public long SumAllPrimesBelow(long boundary)
        {
            var primes = new PrimeNumber();
            var prime = 0L;
            var sum = 0L;
            while ((prime = primes.NextNumber()) < boundary)
            {
                sum += prime;
            }
            return sum;
        }

        [TestMethod()]
        public void SumAllPrimesBelowTenTest()
        {
            var expected = 17;
            var actual = SumAllPrimesBelow(10L);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Find the sum of all the primes below two million.
        ///</summary>
        [TestMethod()]
        public void TenTest()
        {
            var expected = 142913828922;
            var actual = SumAllPrimesBelow(Convert.ToInt64(2e6));
            Assert.AreEqual(expected, actual);
        }
    }
}
