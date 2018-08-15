using System;

namespace SchoolAdministrationV15
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Create Student objects and StudentCatalog object
            StudentCatalog students = new StudentCatalog();

            Student anna = new Student(12, "Anna");
            Student betty = new Student(338, "Betty");
            Student carl = new Student(92, "Carl");
            Student david = new Student(602, "David");
            #endregion

            #region Add scores to Student objects
            anna.AddTestResult("English", 85);
            anna.AddTestResult("Math", 70);
            anna.AddTestResult("Biology", 90);
            anna.AddTestResult("French", 52);

            betty.AddTestResult("English", 77);
            betty.AddTestResult("Math", 82);
            betty.AddTestResult("Chemistry", 65);
            betty.AddTestResult("French", 41);

            carl.AddTestResult("English", 55);
            carl.AddTestResult("Math", 48);
            carl.AddTestResult("Biology", 70);
            carl.AddTestResult("French", 38);
            #endregion

            #region Add Student objects to StudentCatalog object
            students.AddStudent(anna);
            students.AddStudent(betty);
            students.AddStudent(carl);
            students.AddStudent(david);
            #endregion

            #region Test code
            Console.WriteLine($"Total number of students: {students.Count}");
            Console.WriteLine($"Average for {students.GetStudent(12)}: {students.GetAverageForStudent(12):F}");
            Console.WriteLine($"Average for {students.GetStudent(338)}: {students.GetAverageForStudent(338):F}");
            Console.WriteLine($"Average for {students.GetStudent(92)}: {students.GetAverageForStudent(92):F}");
            Console.WriteLine($"Average for {students.GetStudent(120)}: {students.GetAverageForStudent(120):F}");
            Console.WriteLine($"Average for {students.GetStudent(602)}: {students.GetAverageForStudent(602):F}");
            Console.WriteLine($"Average for all students: {students.TotalAverage:F}"); 
            #endregion

            KeepConsoleWindowOpen();
        }

        private static void KeepConsoleWindowOpen()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
