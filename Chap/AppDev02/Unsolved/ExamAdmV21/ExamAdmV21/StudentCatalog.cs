using System.Collections.Generic;

namespace ExamAdmV21
{
    public class StudentCatalog
    {
        private List<Student> _students;

        #region Constructor
        public StudentCatalog()
        {
            _students = new List<Student>();

            _students.Add(new Student("Ann", 1988, "Canada", "Assets\\ann.jpg"));
            _students.Add(new Student("Benny", 1982, "England", "Assets\\benny.jpg"));
            _students.Add(new Student("Carol", 1993, "USA", "Assets\\carol.jpg"));
            _students.Add(new Student("Daniel", 1990, "Denmark", "Assets\\daniel.jpg"));
            _students.Add(new Student("Eliza", 1974, "Australia", "Assets\\eliza.jpg"));
        }
        #endregion

        #region Properties
        public List<Student> Students
        {
            get { return _students; }
        } 
        #endregion
    }
}