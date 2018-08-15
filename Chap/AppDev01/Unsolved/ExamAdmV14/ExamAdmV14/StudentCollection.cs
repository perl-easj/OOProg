using System.Collections.Generic;

namespace ExamAdmV14
{
    public class StudentCollection
    {
        private List<Student> _students;

        public StudentCollection()
        {
            _students = new List<Student>();

            _students.Add(new Student("Ann", 1988, "Canada", "Assets\\ann.jpg"));
            _students.Add(new Student("Benny", 1982, "England", "Assets\\benny.jpg"));
            _students.Add(new Student("Carol", 1993, "USA", "Assets\\carol.jpg"));
            _students.Add(new Student("Daniel", 1990, "Denmark", "Assets\\daniel.jpg"));
            _students.Add(new Student("Eliza", 1974, "Australia", "Assets\\eliza.jpg"));
        }

        public List<Student> Students
        {
            get { return _students; }
        }
    }
}