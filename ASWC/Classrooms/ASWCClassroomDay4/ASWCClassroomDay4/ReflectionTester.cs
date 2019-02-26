using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ASWCClassroomDay4
{
    public class ReflectionTester
    {
        public static void Run()
        {
            Assembly anAssembly = Assembly.GetExecutingAssembly();

            Console.WriteLine();
            Console.WriteLine("All types in self");
            foreach (Type aType in anAssembly.GetTypes())
            {
                Console.WriteLine(aType.FullName);
            }

            Type timeType = anAssembly.GetTypes().First(m => m.Name == "Time");
            Console.WriteLine();
            Console.WriteLine("Dynamically obtained Time type");
            Console.WriteLine(timeType);


            Console.WriteLine();
            Console.WriteLine("All methods in Time");
            foreach (MethodInfo mi in timeType.GetMethods())
            {
                Console.WriteLine(mi);
            }

            // MethodInfo miResetA = typeof(Time).GetMethods().First(m => m.Name == "Reset");

            MethodInfo miResetB = anAssembly
                .GetTypes()
                .SelectMany(t => t.GetMethods())
                .First(m => m.Name == "Reset");

            MethodInfo miResetC = timeType.GetMethods().First(m => m.Name == "Reset");

            //Console.WriteLine();
            //Console.WriteLine("MethodInfo about Reset (A)");
            //Console.WriteLine(miResetA);
            Console.WriteLine("MethodInfo about Reset (B)");
            Console.WriteLine(miResetB);
            Console.WriteLine("MethodInfo about Reset (C)");
            Console.WriteLine(miResetC);

            IEnumerable<ConstructorInfo> ciTime = timeType.GetConstructors();

            Console.WriteLine();
            Console.WriteLine("All constructors in Time");
            foreach (ConstructorInfo ci in ciTime)
            {
                Console.WriteLine(ci);
            }

            // object anObject = Activator.CreateInstance(miResetB.DeclaringType);
            object anObject = Activator.CreateInstance(miResetB.DeclaringType, 11, 20);


            Console.WriteLine();
            Console.WriteLine("Time object BEFORE Invoke");
            Console.WriteLine(anObject);

            miResetB.Invoke(anObject, new object[] { 14 });


            Console.WriteLine();
            Console.WriteLine("Time object AFTER Invoke");
            Console.WriteLine(anObject);

        }
    }
}