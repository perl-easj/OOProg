using System;

namespace Part4
{
    class Program
    {
        static void Main(string[] args)
        {
            WizardRepository wizardRep = new WizardRepository();

            wizardRep.Insert(new Wizard("Alif", 250, 1.0, 55));
            wizardRep.Insert(new Wizard("Bezulia", 320, 0.9, 50));
            wizardRep.Insert(new Wizard("Clarissian", 210, 1.1, 65));
            wizardRep.Insert(new Wizard("Daria", 180, 1.3, 30));
            wizardRep.Insert(new Wizard("Ezzirah", 330, 1.15, 70));
            wizardRep.Insert(new Wizard("Farzoor", 225, 0.95, 60));
            wizardRep.Insert(new Wizard("Gelandrina", 270, 1.1, 55));
            wizardRep.Insert(new Wizard("Holdthedoor", 345, 0.85, 75));

            // From the Wizard repository object, I would like to be able to:
            // 1) Retrieve the names of all Wizards with at least 260 health points.
            // 2) Retrieve the name and health points of all Wizards with a name
            //    longer than seven letters.
            // 3) Retrieve the name and magic power of all Wizards dealing at
            //    least 48,5 points of damage.
            // Implement the above in a way that utilizes LINQ, be it inside the
            // repository itself, or another place in the code.


            Console.WriteLine("Name of all Wizards with at least 260 health points:");
            foreach (Wizard w in wizardRep.AllWizards) // This is wrong, of course...
            {
                Console.WriteLine(w);
            }
            Console.WriteLine();

            Console.WriteLine("Name + HP of all Wizards with a name longer than seven letters:");
            foreach (Wizard w in wizardRep.AllWizards) // This is wrong, of course...
            {
                Console.WriteLine(w);
            }
            Console.WriteLine();

            Console.WriteLine("Name + Magic Power of all Wizards dealing at least 48,5 points of damage:");
            foreach (Wizard w in wizardRep.AllWizards) // This is wrong, of course...
            {
                Console.WriteLine(w);
            }
            Console.WriteLine();

            // BONUS QUESTION: How much damage can the entire group of Wizards deal
            // in one "round", i.e. each Wizard is allowed to deal damage once?

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
