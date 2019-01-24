using System;
using System.Linq;
using System.Reflection;

namespace ReflectionExample
{
    public class Tester
    {
        public void Run()
        {
            RunTest("Test of normal invocation:", TestNormal);
            RunTest("Test of invocation by reflection:", TestReflection);
        }

        private void RunTest(string desc, Action testMethod)
        {
            Console.WriteLine(desc);
            testMethod();
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Simple test of BankAccount, using normal method invocation.
        /// </summary>
        private void TestNormal()
        {
            BankAccount acc = new BankAccount("Per");
            Console.WriteLine(acc);

            acc.Deposit(2545.60);
            Console.WriteLine(acc);

            bool tryWithdraw = acc.Withdraw(4500);
            Console.WriteLine($"{acc}  (withdraw successul: {tryWithdraw})");

            tryWithdraw = acc.Withdraw(1780);
            Console.WriteLine($"{acc}  (withdraw successul: {tryWithdraw})");
        }

        /// <summary>
        /// Test of BankAccount, using constructor and method invocation
        /// by reflection. Your starting point is the "self" reference,
        /// which refers to the application itself, seen as an assembly.
        /// </summary>
        private void TestReflection()
        {
            Assembly self = Assembly.GetExecutingAssembly();

            // TODO - your code goes here
        }
    }
}