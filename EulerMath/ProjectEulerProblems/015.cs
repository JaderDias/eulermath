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
using System.Collections.Generic;

namespace ProjectEulerProblems
{
    //Naive approach, with a dictionary for speed.
    //[TestClass()]
    public class Fifteen
    {
        Dictionary<long, long> dic = new Dictionary<long, long>();

        public long GetAllRoutes(int latitude, int longitude)
        {
            if (latitude == 0 && longitude == 0)
            {
                return 1L;
            }
            var key = (((long)Math.Min(latitude, longitude)) << 32) + Math.Max(latitude, longitude);
            if (dic.ContainsKey(key))
            {
                return dic[key];
            }
            else
            {
                var sum = 0L;
                if (latitude > 0)
                {
                    sum += GetAllRoutes(latitude - 1, longitude);
                }
                if (longitude > 0)
                {
                    sum += GetAllRoutes(latitude, longitude - 1);
                }
                dic.Add(key, sum);
                return sum;
            }
        }

        [TestMethod()]
        public void GetAllRoutes2x2()
        {
            var expected = 6;
            var actual = GetAllRoutes(2,2);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Find the sum of all the primes below two million.
        ///</summary>
        [TestMethod()]
        public void FifteenTest()
        {
            var expected = 137846528820L;
            var actual = GetAllRoutes(20, 20);
            Assert.AreEqual(expected, actual);
        }
    }
}
