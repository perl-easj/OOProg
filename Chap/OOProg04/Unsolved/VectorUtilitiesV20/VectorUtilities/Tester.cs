using System;
using System.Collections.Generic;
using System.Linq;

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
            #endregion

            #region Test of Vector sums
            List<Vector> vectors = new List<Vector> { vA, vB, vC, vD };

            // TODO - Implement Vector sum by loop
            Vector vSumLoop = null;

            // TODO - Implement Vector sum by LINQ
            Vector vSumLINQ = null;

            // TODO - Implement Vector sum by extension method
            Vector vSumExt = null;

            Console.WriteLine("Testing vector sums...");
            Console.WriteLine($"Vector vSumLoop = {vSumLoop}");
            Console.WriteLine($"Vector vSumLINQ = {vSumLINQ}");
            Console.WriteLine($"Vector vSumExt = {vSumExt}");
            Console.WriteLine();
            #endregion

            #region Test of == operator...
            Vector vE = new Vector(0, 5); // I.e. same values as in vD
            Vector vF = vD; // vF refers to same object as vD
            Console.WriteLine("Testing operator == ...");
            Console.WriteLine($"vA == vB is {vA == vB}"); // Different objects, different values
            Console.WriteLine($"vD == vE is {vD == vE}"); // Different objects, same values
            Console.WriteLine($"vD == vF is {vD == vF}"); // Same object, same values
            Console.WriteLine($"vSumLINQ == vSumExt is {vSumLINQ == vSumExt}"); // Should be the same, yes...?
            #endregion
        }
    }
}