using System;
using System.Collections.Generic;

namespace VectorUtilities
{
    public class Tester
    {
        public void Run()
        {
            #region Vector creation
            Vector vA = new Vector(2, 4);
            Vector vB = new Vector(6, 1);
            Vector vC = new Vector(-3, 6);
            Vector vD = new Vector(0, 5);

            Console.WriteLine("Testing Vector creation...");
            Console.WriteLine($"Vector vA = {vA}");
            Console.WriteLine($"Vector vB = {vB}");
            Console.WriteLine($"Vector vC = {vC}");
            Console.WriteLine($"Vector vD = {vD}");
            Console.WriteLine();
            #endregion


            #region Use operators + and -
            Vector vAB = vA + vB;
            Vector vCD = vC + vD;
            Vector vSum = vAB + vCD;
            Vector vDiff = vD - vC;

            Console.WriteLine("Testing Vector addition and subtraction...");
            Console.WriteLine($"Vector vAB = {vAB}");
            Console.WriteLine($"Vector vCD = {vCD}");
            Console.WriteLine($"Vector vSum = {vSum}");
            Console.WriteLine($"Vector vDiff = {vDiff}");
            Console.WriteLine();
            #endregion


            #region Use operator * (dot-product)
            double dotProdAB = vA * vB;
            double dotProdCD = vC * vD;

            Console.WriteLine("Testing Vector dot-product...");
            Console.WriteLine($"vA * vB = {dotProdAB}");
            Console.WriteLine($"vC * vD = {dotProdCD}");
            Console.WriteLine();
            #endregion


            #region Use operators <= and >=
            Console.WriteLine("Testing operators <= and >= ...");
            Console.WriteLine($"vA >= vB is {vA >= vB}");
            Console.WriteLine($"vA <= vB is {vA <= vB}");
            Console.WriteLine($"vC <= vSum is {vC <= vSum}");
            Console.WriteLine($"(vA + vB + vC + vD) >= (vSum - vDiff) is {(vA + vB + vC + vD) >= (vSum - vDiff)}");
            Console.WriteLine();
            #endregion


            #region See how == works at this point...
            Vector vE = new Vector(0, 5); // I.e. same values as in vD
            Vector vF = vD; // vF refers to same object as vD
            Console.WriteLine("Testing operator == ...");
            Console.WriteLine($"vA == vB is {vA == vB}"); // Different objects, different values
            Console.WriteLine($"vD == vE is {vD == vE}"); // Different objects, same values
            Console.WriteLine($"vD == vF is {vD == vF}"); // Same object, same values
            #endregion
        }
    }
}