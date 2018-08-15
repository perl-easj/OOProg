using System;

namespace EmployeesV10
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            Teacher theTeacher = new Teacher("Anna", 37, 6);
            ITSupporter theItSupporter = new ITSupporter("Petra", 30, "MS Office support");

            Console.WriteLine(theTeacher.AllInformation);
            Console.WriteLine(theItSupporter.AllInformation);

            // The LAST line of code should be ABOVE this line
        }
    }
}