using System;

namespace EulerMath.Integer.Sequence
{
    public class FibonacciNumber:ISequence
    {
        private long present = 1;
        private long future = 0;

        public long Next()
        {
            var aux = present + future;
            present = future;
            future = aux;
            return present;
        }

        public long Calc(int index)
        {
            return (long)Math.Round(Math.Pow(Constant.GoldenRatio, (double)index) * Constant.Sqrt5Conjugate);
        }
    }
}
