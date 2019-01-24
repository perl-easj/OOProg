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

            // Find the type which matches "BankAccount" by name.
            Type baType = self.GetTypes().FirstOrDefault(t => t.Name.Contains("BankAccount"));
            if (baType == null) throw new Exception("Could not find BankAccount type");

            // Create an object of the retrieved type.
            object baObject = Activator.CreateInstance(baType, "Per");
            if (baObject == null) throw new Exception("Could not find create BankAccount object");

            // Find the methods which match "Deposit" and "Withdraw" by name.
            MethodInfo miDeposit = baType.GetMethods().FirstOrDefault(mi => mi.Name.Contains("Deposit"));
            MethodInfo miWithdraw = baType.GetMethods().FirstOrDefault(mi => mi.Name.Contains("Withdraw"));
            if (miDeposit == null) throw new Exception("Could not find find Deposit method");
            if (miWithdraw == null) throw new Exception("Could not find find Withdraw method");

            // Print object in its initial state.
            Console.WriteLine(baObject);

            // Invoke Deposit method (no return value).
            miDeposit.Invoke(baObject, new object[] {2545.60});
            Console.WriteLine(baObject);

            // Invoke Withdraw method (with return value).
            object tryWithdrawObject = miWithdraw.Invoke(baObject, new object[] { 4500 });
            Console.WriteLine($"{baObject}  (withdraw successul: {tryWithdrawObject})");

            // Invoke Withdraw method again (with return value).
            tryWithdrawObject = miWithdraw.Invoke(baObject, new object[] { 1780 });
            Console.WriteLine($"{baObject}  (withdraw successul: {tryWithdrawObject})");
        }
    }
}