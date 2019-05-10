using System;
// ReSharper disable UnusedParameter.Local

namespace UnitTest01
{
    class Program
    {
        static void Main(string[] args)
        {
            MediCare mCare = new MediCare(new SubsidyTable());

            for (int amount = 0; amount <= 20000; amount = amount + 100)
            {
                Console.WriteLine($"Subsidised expense for {amount:0.00}  kr. is {mCare.SubsidisedExpense(amount):0.00}");
            }

            Console.ReadKey();
        }
    }
}
