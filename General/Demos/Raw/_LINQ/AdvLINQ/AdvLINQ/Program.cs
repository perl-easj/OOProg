using System;
using System.Collections.Generic;
using Systen.Linq;
// using System.Linq;

namespace AdvLINQ
{
    class Program
    {
        private static Rectangle theRect;

        private static bool Inside(Rectangle aRect, Point p)
        {
            return p.X >= aRect.TopLeft.X &&
                   p.X <= aRect.BotRight.X &&
                   p.Y <= aRect.TopLeft.Y &&
                   p.Y >= aRect.BotRight.Y;
        }

        private static Func<Point, bool> InsideFuncFac()
        {
            Rectangle aRect = theRect;
            return aPoint => { return Inside(aRect, aPoint); };
        }

        private static void InsideFuncFacTest(bool useNewObject)
        {
            Point p_3_3 = new Point(3,3);
            Point p_12_12 = new Point(12,12);

            theRect = new Rectangle(new Point(2, 10), new Point(10, 2));
            var insideFunc = InsideFuncFac();

            Console.WriteLine("First call:");
            Console.WriteLine($"(3,3) is inside : {insideFunc(p_3_3)}");
            Console.WriteLine($"(12,12) is inside : {insideFunc(p_12_12)}");

            if (useNewObject)
            {
                // Approach A: theRect refers to completely new object.
                theRect = new Rectangle(new Point(20, 30), new Point(30, 20));
            }
            else
            {
                // Approach B: theRect refers to same object with new values.
                theRect.TopLeft.X = 20;
                theRect.TopLeft.Y = 30;
                theRect.BotRight.X = 30;
                theRect.BotRight.Y = 20;
            }

            Console.WriteLine("Second call:");
            Console.WriteLine($"(3,3) is inside : {insideFunc(p_3_3)}");
            Console.WriteLine($"(12,12) is inside : {insideFunc(p_12_12)}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("let theRect refer to new object...");
            InsideFuncFacTest(true);
            Console.WriteLine();

            Console.WriteLine("change values in theRect...");
            InsideFuncFacTest(false);
            Console.WriteLine();




            //Profile pA = new Profile("Alice", 14);

            //ProfileFactory pFac = new ProfileFactory();
            //ProfileV2 pB = pFac.Create("Alice", 14);

            //List<int> numbers = new List<int> {1, 2, 7};

            //for (int i = 0; i < 20; i++)
            //{
            //    Console.WriteLine(numbers.Sum());
            //}

            //List<Car> cars = new List<Car>();
            //cars.Add(new Car("AB 12345", 60000, "A fine Blue car"));
            //cars.Add(new Car("CD 23456", 80000, "A cute Red car"));
            //cars.Add(new Car("EF 34567", 70000, "A sensible Grey car"));

            //Dictionary<string, Car> carDict = cars.ToDictionary<Car, string>(c => c.Plate);



            //List<Movie> movies = new List<Movie>();

            //List<MovieInfo> miListA = movies
            //    .Select(m => new MovieInfo(
            //        m.Title, 
            //        m.Year - 1900, 
            //        m.DurationInMins / 60.0))
            //    .ToList();


            //List<MovieInfo> miList = 
            //    Transformer.TransformItems<Movie, MovieInfo>(movies,
            //        m => new MovieInfo(
            //            m.Title,
            //            m.Year - 1900,
            //            m.DurationInMins / 60.0));

            //Dictionary<string, Movie> movieDict = movies.ToDictionary(m => m.Title);

            //foreach (Movie m in movies)
            //{
            //    Console.WriteLine(m);
            //}

            //movies
            //  .Select(m => $"{m.Title}, made in {m.Year}")
            //  .ToList()
            //  .ForEach(Console.WriteLine);




            //ProductCalculator prodCalc = new ProductCalculator();
            // Console.WriteLine($"Product is {prodCalc.Aggregate(numbers)}");


            //List<int> numbers = new List<int> { 21, 8, 14, 45 };

            //int sosA = AggregateCalculator<int, int>.Aggregate(
            //    numbers,
            //    () => 0,
            //    (val, item) => val + (item * item));
            //Console.WriteLine($"Sum-of-squares is {sosA}");

            //int sosB = numbers.Aggregate(
            //    (val, item) => val + (item * item)); // Accumulator function
            //Console.WriteLine($"Sum-of-squares is {sosB}");

            //int sosC = numbers.Aggregate(
            //    0, // Seed value
            //    (val, item) => val + (item * item)); // Accumulator function
            //Console.WriteLine($"Sum-of-squares is {sosC}");

            //double sosAverage = numbers.Aggregate(
            //    0, // Seed value
            //    (val, item) => val + (item * item), // Accumulator function
            //    val => (val * 1.0)/numbers.Count); // Result selector function
            //Console.WriteLine($"Sum-of-squares average is {sosAverage}");

            //List<string> words = new List<string>{ "This ", "is ", " Sparta!"};
            //string concatStr = AggregateCalculator<string, string>.Aggregate(
            //    words,
            //    () => "",
            //    (val, item) => val + item);
            //Console.WriteLine(concatStr);


            //Person a = new Person("Allan");
            //Person b = new Person("Bente");
            //Person c = new Person("Carl");
            //Person d = new Person("Dan");
            //Person e = new Person("Ellen");
            //Person f = new Person("Fie");

            //a.Contacts = new List<Person> { b, c };
            //b.Contacts = new List<Person> { a };
            //c.Contacts = new List<Person> { a, d, e, f };
            //d.Contacts = new List<Person> { a, b, c };
            //e.Contacts = new List<Person> { b, c, f };
            //f.Contacts = new List<Person> { c, e };

            //List<Person> allPersons = new List<Person> { a, b, c, d, e, f };
            //List<Person> selectedPersons = new List<Person> { a, d, e };


            //// All persons which are Contacts to Selected Persons.
            //IEnumerable<Person> allContactsForSelected = 
            //    allPersons
            //    .Where(p => selectedPersons
            //        .Select(sp => sp.Name)
            //        .Contains(p.Name))
            //    .SelectMany(p => p.Contacts)
            //    .Distinct();

            //foreach (Person p in allContactsForSelected)
            //{
            //    Console.WriteLine(p.Name);
            //}

            //List<int> setA = new List<int> { 2, 6, 12, 9, 3, 7, 7, 12, 9, 7 };
            //List<int> setB = new List<int> { /*12, 8, 3, 71, 13*/ };
            //List<int> setResult = new List<int>();

            //foreach (int val in setA)
            //{
            //    if (!setB.Contains(val))
            //    {
            //        setResult.Add(val);
            //    }
            //}

            //Console.WriteLine("In A but not in B: ");
            //foreach (int val in setA.Except(setB))
            //{
            //    Console.WriteLine(val);
            //}

            //Car carA = new Car("AA 111", 10000, "Car A");
            //Car carB = new Car("BB 222", 20000, "Car B");
            //Car carC = new Car("AA 111", 10000, "Car A");
            //Car carD = new Car("DD 444", 40000, "Car D");
            //Car carE = new Car("EE 555", 50000, "Car E");

            //List<Car> carSetA = new List<Car> {carA, carB, carD, carE };
            //List<Car> carSetB = new List<Car> {carB, carC, carE};
            //foreach (Car val in carSetA.Except(carSetB, new CarComparer()))
            //{
            //    Console.WriteLine(val);
            //}

            // int upperLimit = 1000000;
            // IEnumerable<int> numbers = Enumerable.Range(2, upperLimit);

            //Stopwatch watch = new Stopwatch();
            //watch.Restart();
            //IEnumerable<int> primes = Enumerable.Range(2, 1000000).AsParallel().Where(IsPrime);
            //int primesCount = primes.Count();
            //watch.Stop();
            //Console.WriteLine($"Primes up to 1,000,000: {primesCount}");
            //Console.WriteLine($"Time spent: {watch.ElapsedMilliseconds} ms");

            //ConcurrentBag<int> primeList = new ConcurrentBag<int>();
            //Enumerable.Range(2, 1000000).AsParallel().Where(IsPrime).ForAll(primeList.Add);
            //Console.WriteLine($"No. of items in primesList : {primeList.Count}");


            // int pCount = 0;
            // int primesCount = numbers.AsParallel().Where(IsPrime).Count();
            // ConcurrentBag<int> primes = new ConcurrentBag<int>();
            //foreach (var i in numbers.AsParallel().Where(IsPrime))
            //{
            //    primes.Add(i);
            //}

            //numbers.AsParallel().Where(IsPrime).ForAll(primes.Add);


            //Console.WriteLine($"The number of primes between 1 and {upperLimit} is {primes.Count()}");
            //Console.WriteLine($"Calculation took {watch.ElapsedMilliseconds} ms");

            //List<int> primeList = numbers.AsParallel().AsOrdered().Where(IsPrime).ToList();
            //int outOfOrder = 0;
            //for (int i = 0; i < (primeList.Count - 1); i++)
            //{
            //    if (primeList[i] > primeList[i + 1])
            //    {
            //        outOfOrder++;
            //        for (int j = -5; j < 5; j++)
            //        {
            //            if ((i + j) >= 0 && ((i + j) < primeList.Count))
            //            {
            //                Console.WriteLine(primeList[i + j]);
            //            }
            //        }

            //    }
            //}
            //Console.WriteLine($"Out of order :  {outOfOrder}");



            //Vector v1 = new Vector(2, 5);
            //Vector v2 = new Vector(-1, 4);
            //Vector v3 = new Vector(7, -3);

            //Vector vSum = v1 + v2 + v3;
            //Console.WriteLine(vSum);

            //List<Vector> vectors = new List<Vector> {v1, v2, v3};
            //List<int> ints = new List<int>();
            //Console.WriteLine(vectors.Sum());


            // CarCatalog cars = new SelectedCarCatalog(c => c.Price > 35000,  true);

            //Console.WriteLine(cars["BB 222"]);

            //foreach (Car c in cars)
            //{
            //    Console.WriteLine(c);
            //}


            //CarCatalog carCat = new CarCatalog(c => c.Price > 35000, true);
            //foreach (Car c in carCat)
            //{
            //    Console.WriteLine(c);
            //}

            Wait();
        }

        //private static int Product(IEnumerable<int> numbers)
        //{
        //    int product = 1;
        //    foreach (int value in numbers)
        //    {
        //        product = product * value;
        //    }
        //    return product;
        //}

        //private static bool IsPrime(int number)
        //{
        //    int limit = Convert.ToInt32(Math.Sqrt(number));
        //    bool isPrime = true;

        //    for (int i = 2; i <= limit && isPrime; i++)
        //    {
        //        isPrime = number % i != 0;
        //    }

        //    return isPrime;
        //}

        private static void Wait()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Done, press any key to close application");
            Console.ReadKey();
        }
    }
}
