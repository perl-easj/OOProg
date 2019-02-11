using System;
using System.Collections.Generic;
using System.Linq;

namespace ASWCClassroomDay2
{
    public class LINQSetDemo
    {
        public void Run()
        {
            #region Set-difference without LINQ

            List<int> setA = new List<int> { 2, 6, 12, 9, 3, 7 };
            List<int> setB = new List<int> { 12, 8, 3, 71, 13 };
            List<int> setDiff = new List<int>();

            foreach (int val in setA)
            {
                if (!setB.Contains(val))
                {
                    setDiff.Add(val);
                }
            }

            Console.WriteLine("[without LINQ] In A but not in B: ");
            foreach (int val in setDiff)
            {
                Console.WriteLine(val);
            }
            Console.WriteLine();

            #endregion


            #region Set-difference with LINQ

            Console.WriteLine("[with LINQ] In A but not in B: ");
            foreach (int val in setA.Except(setB))
            {
                Console.WriteLine(val);
            }
            Console.WriteLine();

            #endregion


            #region Set-difference, default comparison

            Car carA = new Car("AA 111", 10000, "Car A");
            Car carB = new Car("BB 222", 20000, "Car B");
            Car carC = new Car("AA 111", 10000, "Car A");
            Car carD = new Car("DD 444", 40000, "Car D");
            Car carE = new Car("EE 555", 50000, "Car E");

            List<Car> carSetA = new List<Car> { carA, carB, carD, carE };
            List<Car> carSetB = new List<Car> { carB, carC, carE };

            Console.WriteLine("[default comparison] Car diff.: ");
            foreach (Car val in carSetA.Except(carSetB))
            {
                Console.WriteLine(val);
            }
            Console.WriteLine();

            #endregion


            #region Set-difference, custom comparison

            Console.WriteLine("[custom comparison] Car diff.: ");
            foreach (Car val in carSetA.Except(carSetB, new CarComparer()))
            {
                Console.WriteLine(val);
            }
            Console.WriteLine();

            #endregion
        }
    }
}