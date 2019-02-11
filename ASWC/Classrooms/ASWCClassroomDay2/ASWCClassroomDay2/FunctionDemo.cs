using System;
using System.Collections.Generic;
using System.Linq;

namespace ASWCClassroomDay2
{
    public class FunctionDemo
    {
        public void Run()
        {
            #region Init

            List<int> numbers = new List<int> { 17, 88, 8, 23, 71, 33, 15 };

            List<int> numbersMult2 = null;
            List<int> numbersSquared = null;
            List<bool> AreNumbersSmallerThan20 = null;
            List<bool> AreNumbersSmallerThan40 = null;

            #endregion


            #region Types

            int varA = MultiplyBy2(10);
            Func<int, int> varB = MultiplyBy2;

            #endregion


            #region Try #1

            List<int> resultListA = new List<int>();
            foreach (int n in numbers)
            {
                resultListA.Add(n * 2);
            }
            numbersMult2 = resultListA;

            List<int> resultListB = new List<int>();
            foreach (int n in numbers)
            {
                resultListB.Add(n * n);
            }
            numbersSquared = resultListB;

            List<bool> resultListC = new List<bool>();
            foreach (int n in numbers)
            {
                resultListC.Add(n < 20);
            }
            AreNumbersSmallerThan20 = resultListC;

            List<bool> resultListD = new List<bool>();
            foreach (int n in numbers)
            {
                resultListD.Add(n < 40);
            }
            AreNumbersSmallerThan40 = resultListD;

            #endregion


            #region Try #2

            numbersMult2 = Transform(numbers, MultiplyBy2);
            numbersSquared = Transform(numbers, Square);
            AreNumbersSmallerThan20 = Transform(numbers, SmallerThan20);
            AreNumbersSmallerThan40 = Transform(numbers, SmallerThan40);

            #endregion


            #region Try #3

            numbersMult2 = Transform(numbers, n => n * 2);
            numbersSquared = Transform(numbers, n => n * n);
            AreNumbersSmallerThan20 = Transform(numbers, n => n < 20);
            AreNumbersSmallerThan40 = Transform(numbers, n => n < 40);

            #endregion


            #region Try #4

            numbersMult2 = numbers.Select(n => n * 2).ToList();
            numbersSquared = numbers.Select(n => n * n).ToList();
            AreNumbersSmallerThan20 = numbers.Select(n => n < 20).ToList();
            AreNumbersSmallerThan40 = numbers.Select(n => n < 40).ToList();

            #endregion


            #region Try #5

            numbersMult2 = numbers.Select(MultiplyBy2).ToList();
            numbersSquared = numbers.Select(Square).ToList();
            AreNumbersSmallerThan20 = numbers.Select(SmallerThan20).ToList();
            AreNumbersSmallerThan40 = numbers.Select(SmallerThan40).ToList();

            #endregion


            #region Try #6

            AreNumbersSmallerThan20 = numbers.Select(n => SmallerThanLimit(n, 20)).ToList();
            AreNumbersSmallerThan40 = numbers.Select(n => SmallerThanLimit(n, 40)).ToList();

            #endregion


            #region Try #7

            AreNumbersSmallerThan20 = numbers.Select(STLFunctionFactory(20)).ToList();
            AreNumbersSmallerThan40 = numbers.Select(STLFunctionFactory(40)).ToList();

            #endregion


            #region Try #8

            AreNumbersSmallerThan20 = numbers.Select(CASTLFunctionFactory(600)).ToList();
            AreNumbersSmallerThan40 = numbers.Select(CASTLFunctionFactory(2000)).ToList();

            #endregion


            #region Print

            PrintList("Numbers multiplied by 2", numbersMult2);
            PrintList("Numbers squared", numbersSquared);
            PrintList("Are numbers smaller than 20?", AreNumbersSmallerThan20);
            PrintList("Are numbers smaller than 40?", AreNumbersSmallerThan40);

            #endregion
        }

        #region Simple functions (one parameter)

        private int MultiplyBy2(int n) { return n * 2; }
        private int MultiplyBy7(int n) { return n * 7; }
        private int Square(int n) { return n * n; }
        private bool SmallerThan20(int n) { return n < 20; }
        private bool SmallerThan40(int n) { return n < 40; }

        #endregion

        #region General functions (two parameters)

        private bool SmallerThanLimit(int n, int limit)
        {
            return n < limit;
        }

        private bool CircleAreaSmallerThanLimit(double radius, double limit)
        {
            return Math.PI * radius * radius < limit;
        }

        #endregion

        #region Function Factories

        private Func<int, bool> STLFunctionFactory(int limit)
        {
            return (n => SmallerThanLimit(n, limit));
        }

        private Func<int, bool> CASTLFunctionFactory(double limit)
        {
            return (r => CircleAreaSmallerThanLimit(r, limit));
        } 

        #endregion

        private List<Tout> Transform<Tin, Tout>(IEnumerable<Tin> items, Func<Tin, Tout> transformer)
        {
            List<Tout> transformedItems = new List<Tout>();

            foreach (Tin item in items)
            {
                transformedItems.Add(transformer(item));
            }

            return transformedItems;
        }

        private void PrintList<T>(string header, List<T> items)
        {
            Console.WriteLine($"{header} : ");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}