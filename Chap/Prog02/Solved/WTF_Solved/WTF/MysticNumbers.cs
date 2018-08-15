namespace WTF
{
    public class MysticNumbers
    {
        #region Methods
        public static int ThreeNumbers(int a, int b, int c)
        {
            int result;

            if (b > a)
            {
                result = b;
                if (c > b)
                {
                    result = c;
                }
            }
            else
            {
                result = a;
                if (c > a)
                {
                    result = c;
                }
            }

            return result;
        }

        public static int TwoNumbers(int a, int b)
        {
            int result;

            if (b > a)
            {
                result = b;
            }
            else
            {
                result = a;
            }

            return result;
        }

        public static int FourNumbers(int a, int b, int c, int d)
        {
            return TwoNumbers(TwoNumbers(a,b),TwoNumbers(c,d));
        } 
        #endregion
    }
}