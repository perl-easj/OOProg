using System;

namespace ReFac.Simple.ExtractMethod.After
{
    public class Transform
    {
        public Tuple<int, int, int> TransformNumbers(int a, int b, int c)
        {
            int aT = TransformNumber(a);
            int bT = TransformNumber(b);
            int cT = TransformNumber(c);

            return new Tuple<int, int, int>(aT, bT, cT);
        }

        private int TransformNumber(int number)
        {
            // Square the number, then add 17
            int numberT = number;
            numberT = numberT * numberT;
            numberT = numberT + 17;

            return numberT;
        }
    }
}