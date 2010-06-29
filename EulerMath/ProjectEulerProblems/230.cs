// <copyright file="230.cs" company="Company">
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
    public class Pair
    {
        private string s;
        private bool leafness = true;
        private Pair p1;
        private Pair p2;
        public readonly long length = 0;

        public Pair(string s)
        {
            this.s = s;
            this.length = s.Length;
        }

        public Pair(Pair p1, Pair p2)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.leafness = false;
            this.length = p1.length + p2.length;
        }

        public char D(long index)
        {
            if (leafness)
            {
                return s[(int)index - 1];
            }
            else
            {
                if (index < p1.length)
                {
                    return p1.D(index);
                }
                return p2.D(index - p1.length);
            }
        }
    }

    public class FibonacciString
    {
        private Pair a;
        private Pair b;

        public FibonacciString(string previous, string current)
        {
            this.a = new Pair(previous);
            this.b = new Pair(current);
        }

        public long Next()
        {
            var p = new Pair(a, b);
            a = b;
            b = p;
            return p.length;
        }

        /// <summary>
        /// Get Nth digit in the first term of F_(A,B) that contains at least n digits.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public char D(long index)
        {
            while (Next() < index)
                ;

            return b.D(index);
        }
    }
    
//    [TestClass()]
    public class TwoHundredAndThirty
    {
        [TestMethod()]
        public void GetNthDigitTest()
        {
            var expected = '9';
            var target = new FibonacciString("1415926535", "8979323846");
            var actual = target.D(35);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// For any two strings of digits, A and B, we define F_(A,B) to be the sequence (A,B,AB,BAB,ABBAB,...) in which each term is the concatenation of the previous two.
        /// Further, we define D_(A,B)(n) to be the n^(th) digit in the first term of F_(A,B) that contains at least n digits.
        /// Find Σ_(n=0,1,...,17) 10^(n)× D_(A,B)((127+19n)×7^(n))
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
