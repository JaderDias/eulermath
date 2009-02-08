using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EulerMath
{
    abstract class Constant
    {
        /// <summary>
        /// Square root of the number five
        /// </summary>
        public static readonly double Sqrt5 = Math.Sqrt(5);
        /// <summary>
        /// Square root of the number five conjugate
        /// </summary>
        public static readonly double Sqrt5Conjugate = 1 / Sqrt5;
        /// <summary>
        /// Golden Ratio
        /// </summary>
        public static readonly double GoldenRatio = (1 + Sqrt5) / 2;
        /// <summary>
        /// Golden Ration Conjugate
        /// </summary>
        public static readonly double GoldenRatioConjugate = 1 / GoldenRatio;
    }
}
