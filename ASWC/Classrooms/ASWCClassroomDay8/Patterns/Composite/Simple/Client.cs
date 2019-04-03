using System;
using System.Collections.Generic;

namespace Patterns.Composite.Simple
{
    public class Client
    {
        public void PlayWithLego()
        {
            ILegoStructure blockA = new LegoBlock(3, "6-dot");
            ILegoStructure blockB = new LegoBlock(3, "6-dot");
            ILegoStructure blockC = new LegoBlock(4, "8-dot");

            List<ILegoStructure> listA = new List<ILegoStructure>
            {
                blockA, blockB, blockC
            };
            ILegoStructure structA = new LegoStructure(listA);

            ILegoStructure blockD = new LegoBlock(8, "16-dot");
            ILegoStructure blockE = new LegoBlock(4, "8-dot");
            List<ILegoStructure> listB = new List<ILegoStructure>
            {
                blockD, blockE, structA
            };
            ILegoStructure structB = new LegoStructure(listB);

            Console.WriteLine($"Structure A {structA.TotalWeight} gr., {structA.noOfBlocks} blocks" );
            Console.WriteLine($"Structure B {structB.TotalWeight} gr., {structB.noOfBlocks} blocks");

            Console.ReadKey();
        }
    }
}