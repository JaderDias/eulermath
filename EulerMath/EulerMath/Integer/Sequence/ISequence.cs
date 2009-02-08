using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EulerMath.Integer.Sequence
{
    interface ISequence
    {
        long Next();
        long Calc(int index);
    }
}
