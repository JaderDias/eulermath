// <copyright file="Rational.cs" company="Company">
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

namespace EulerMath
{
    using System;
    using EulerMath;

    /// <summary>
    /// Represents a rational number
    /// </summary>
    public class Rational
    {
        /// <summary>
        /// The maximum difference to consider two doubles as absolutely equals
        /// </summary>
        private const double AbsoluteDifferenceEpsilon = 1e-15d;

        /// <summary>
        /// The maximum difference to consider two doubles as relatively equals
        /// </summary>
        private const double RelativeDifferenceEpsilon = 1d + 1e-15d;

        /// <summary>
        /// 10 ^ decimal places of the maximum mantissa integer
        /// </summary>
        private const double MantissaSizeOrder = 1e15;

        /// <summary>
        /// Private collecion of prime numbers
        /// </summary>
        private static PrimeNumber primes = new PrimeNumber();

        /// <summary>
        /// Initializes a new instance of the <see cref="Rational"/> class.
        /// </summary>
        /// <param name="numerator">The numerator.</param>
        /// <param name="denominator">The denominator.</param>
        /// <param name="floatingPointValue">The floating point value.</param>
        public Rational(long numerator, long denominator, double floatingPointValue)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
            this.FPValue = floatingPointValue;
            this.Simplify();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rational"/> class.
        /// </summary>
        /// <param name="numerator">The numerator.</param>
        /// <param name="denominator">The denominator.</param>
        public Rational(long numerator, long denominator)
            : this(numerator, denominator, ((double)numerator) / ((double)denominator))
        {
        }

        /// <summary>
        /// Gets the numerator.
        /// </summary>
        /// <value>The numerator.</value>
        public long Numerator { get; private set; }

        /// <summary>
        /// Gets the denominator.
        /// </summary>
        /// <value>The denominator.</value>
        public long Denominator { get; private set; }

        /// <summary>
        /// Gets the floating point value.
        /// </summary>
        /// <value>The floating point value.</value>
        public double FPValue { get; private set; }

        /// <summary>
        /// Creates a rational number from his floating point value. 
        /// </summary>
        /// <param name="number">The floating point value.</param>
        /// <returns>The rational number</returns>
        public static Rational CreateFrom(double number)
        {
            if (number >= MantissaSizeOrder)
            {
                return new Rational((long)number, 1L);
            }
            else
            {
                var denominator = MantissaSizeOrder * Math.Pow(10, -1 * Math.Floor(Math.Log10(number)));
                var numerator = (long)(number * denominator);
                return new Rational(numerator, (long)denominator);
            }
        }

        /// <summary>
        /// Verifies if two doubles are relatively approximately equal.
        /// </summary>
        /// <param name="oneValue">The first double to compare.</param>
        /// <param name="anotherValue">The second double to compare.</param>
        /// <returns>
        ///     <c>true</c> if the double numbers are aproximately equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool AreRelativelyApproximatelyEqual(double oneValue, double anotherValue)
        {
            if (oneValue == 0 || anotherValue == 0)
            {
                return oneValue == anotherValue;
            }
            else
            {
                var relativeDifference = oneValue / anotherValue;
                return relativeDifference < RelativeDifferenceEpsilon;
            }
        }

        /// <summary>
        /// Verifies if two doubles are absolutely approximately equal.
        /// </summary>
        /// <param name="oneValue">The first double to compare.</param>
        /// <param name="anotherValue">The second double to compare.</param>
        /// <returns>
        ///    <c>true</c> if the double numbers are aproximately equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool AreAbsolutelyApproximatelyEqual(double oneValue, double anotherValue)
        {
            var absoluteDifference = Math.Abs(oneValue - anotherValue);
            return absoluteDifference < AbsoluteDifferenceEpsilon;
        }

        /// <summary>
        /// Simplifies this instance to the minimum denominator.
        /// </summary>
        public void Simplify()
        {
            var numeratorFactors = primes.Factorize(this.Numerator);
            var denominatorFactors = primes.Factorize(this.Denominator);
            foreach (var factor in numeratorFactors)
            {
                if (denominatorFactors.Contains(factor))
                {
                    this.Numerator /= factor;
                    this.Denominator /= factor;
                    denominatorFactors.Remove(factor);
                }
            }
        }

        /// <summary>
        /// Simplifies this rational number to a another rational number with a denominator lower or equal to the specified max denominator.
        /// </summary>
        /// <param name="maxDenominator">The max denominator.</param>
        /// <param name="avoidedDenominator">A denominator to avoid, otherwise must be minor or equal to zero.</param>
        /// <returns>The difference between the new number and the older one.</returns>
        public double Simplify(long maxDenominator, long avoidedDenominator)
        {
            if (maxDenominator >= this.Denominator && avoidedDenominator != this.Denominator)
            {
                return 0;
            }
            else
            {
                var lowestDifference = this.FPValue + 1d;
                for (var denominator = 1d; denominator <= maxDenominator; denominator++)
                {
                    var numerator = this.FPValue * denominator;
                    var doubleNumerator = numerator * 2;
                    if (denominator == avoidedDenominator)
                    {
                        if (AreRelativelyApproximatelyEqual(doubleNumerator, Math.Truncate(doubleNumerator)))
                        {
                            numerator = Math.Ceiling(numerator);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        numerator = Math.Round(numerator);
                    }

                    var floatingPoingValue = numerator / denominator;
                    var difference = Math.Abs(floatingPoingValue - this.FPValue);
                    if (difference < lowestDifference)
                    {
                        this.Numerator = (long)numerator;
                        this.Denominator = (long)denominator;
                        lowestDifference = difference;
                    }
                }

                return lowestDifference;
            }
        }

        /// <summary>
        /// Simplifies this rational number to a another rational number with a denominator lower or equal to the specified max denominator.
        /// </summary>
        /// <param name="maxDenominator">The max denominator.</param>
        /// <returns>The difference between the new number and the older one.</returns>
        public double Simplify(long maxDenominator)
        {
            return this.Simplify(maxDenominator, 0);
        }

        /// <summary>
        /// Determines whether this rational number is ambiguous.
        /// </summary>
        /// <param name="maxDenominator">The max denominator.</param>
        /// <returns>
        ///     <c>true</c> if the this rational number is ambiguous; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAmbiguous(long maxDenominator)
        {
            var simplifiedRational1 = new Rational(this.Numerator, this.Denominator);
            var simplifiedRational2 = new Rational(this.Numerator, this.Denominator);
            var difference1 = simplifiedRational1.Simplify(maxDenominator);
            var difference2 = simplifiedRational2.Simplify(maxDenominator, simplifiedRational1.Denominator);
            return difference1 == difference2;
        }
    }
}
