using System;
using System.Collections.Generic;

namespace CorrectChangeAutomat
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            int originalAmountToPayBack = 234;


            #region Solution #1 (using while-loops)

            int amountToPayBack = originalAmountToPayBack;
            int kr100 = 0;
            int kr10 = 0;
            int kr1 = 0;

            while (amountToPayBack >= 100)
            {
                kr100 = kr100 + 1;
                amountToPayBack = amountToPayBack - 100;
            }

            while (amountToPayBack >= 10)
            {
                kr10 = kr10 + 1;
                amountToPayBack = amountToPayBack - 10;
            }

            while (amountToPayBack >= 1)
            {
                kr1 = kr1 + 1;
                amountToPayBack = amountToPayBack - 1;
            }

            Console.WriteLine($"(Solution #1) 100-kr bills: {kr100}   10-kr coins: {kr10}   1-kr coins: {kr1}");
            Console.WriteLine();

            #endregion

            #region Solution #2 (without using loops)

            amountToPayBack = originalAmountToPayBack;
            kr100 = amountToPayBack / 100;
            amountToPayBack = amountToPayBack - kr100 * 100;
            kr10 = amountToPayBack / 10;
            kr1 = amountToPayBack - kr10 * 10;

            Console.WriteLine($"(Solution #2) 100-kr bills: {kr100}   10-kr coins: {kr10}   1-kr coins: {kr1}"); 

            #endregion

            // The LAST line of code should be ABOVE this line

        }
    }
}