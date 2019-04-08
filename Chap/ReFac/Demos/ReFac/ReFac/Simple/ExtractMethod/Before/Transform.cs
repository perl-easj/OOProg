using System;

namespace ReFac.Simple.ExtractMethod.Before
{
    public class Transform
    {
        public Tuple<int,int,int> TransformNumbers(int a, int b, int c)
        {
            // Square the number, then add 17
            int aT = a;
            aT = aT * aT;
            aT = aT + 17;

            // Square the number, then add 17
            int bT = b;
            bT = bT * bT;
            bT = bT + 17;

            // Square the number, then add 17
            int cT = c;
            cT = cT * cT;
            cT = cT + 17;

            return new Tuple<int, int, int>(aT, bT, cT);
        }
    }
}