using System;

namespace Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            HunterRepository hunterRep = new HunterRepository();
            WizardRepository wizardRep = new WizardRepository();

            // The above is a bit clumsy. Instead, I would like to be able to:
            // 1) Create a Repository object in which I can store Wizard objects only.
            // 2) Create another Repository object in which I can store Hunter objects only.
            // 3) Do 1) and 2) using the SAME class in both cases
            // The new class must therefore:
            // A) Be flexible w.r.t. what type of objects you can store in the repository.
            // B) Be type-safe, i.e. one and only one type of objects in a repository.


            WaitForKey();
        }

        private static void WaitForKey()
        {
            Console.WriteLine();
            Console.WriteLine("Done, press any key to close Application...");
            Console.ReadKey();
        }
    }
}
