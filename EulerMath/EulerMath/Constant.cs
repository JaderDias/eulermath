// <copyright file="Constant.cs" company="Company">
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

    /// <summary>
    /// Collection of useful number constants
    /// </summary>
    public abstract class Constant
    {
        /// <summary>
        /// Square root of the number five
        /// </summary>
        public static readonly double SquareRootOf5 = Math.Sqrt(5);

        /// <summary>
        /// Square root of the number five conjugate
        /// </summary>
        public static readonly double SquareRootOf5Conjugate = 1 / SquareRootOf5;
        
        /// <summary>
        /// Golden Ratio
        /// </summary>
        public static readonly double GoldenRatio = (1 + SquareRootOf5) / 2;
        
        /// <summary>
        /// Golden Ration Conjugate
        /// </summary>
        public static readonly double GoldenRatioConjugate = 1 / GoldenRatio;
    }
}
