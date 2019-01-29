using System;

namespace Part3
{
    class Program
    {
        static void Main(string[] args)
        {
            WizardRepository wizardRep = new WizardRepository();

            // 1) Add a method (e.g. an anonymous method) which prints out some
            //    information when the Wizard repository is changed, and look
            //    for an event in the WizardRepository class, that you can hook
            //    your method up to.

            wizardRep.Insert(new Wizard("Alif", 250, 1.0, 55));
            wizardRep.Insert(new Wizard("Bezulia", 320, 0.9, 50));
            wizardRep.Insert(new Wizard("Clarissian", 210, 1.1, 65));
            wizardRep.Insert(new Wizard("Daria", 180, 1.3, 30));

            wizardRep.Remove(wizardRep.Read("Alif"));
            wizardRep.Remove(wizardRep.Read("Daria"));

            // 2) Finish (and test) the implementation of the method ReadWhere in
            //    WizardRepository, such that you can include a selection criterion
            //    to the method. The method should then only return those objects
            //    which match the criterion.

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
