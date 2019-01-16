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

            // Vector sum by loop
            Vector vSumLoop = new Vector(0,0);
            foreach (Vector v in vectors)
            {
                vSumLoop += v;
            }

            // Vector sum by LINQ
            Vector vSumLINQ = vectors.Aggregate(new Vector(0, 0), (a, b) => a + b);

            // Vector sum by extension method
            Vector vSumExt = vectors.Sum();

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