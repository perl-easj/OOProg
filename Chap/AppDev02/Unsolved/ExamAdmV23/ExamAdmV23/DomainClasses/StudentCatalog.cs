using System.Collections.Generic;
using System.Linq;

namespace ExamAdmV23.DomainClasses
{
    public class StudentCatalog
    {
        private static int _keyCount = 1;
        private Dictionary<int, Student> _students;

        #region Constructor
        public StudentCatalog()
        {
            _students = new Dictionary<int, Student>();

            Create(new Student("Ann", 1988, "Canada", "..\\Assets\\ann.jpg"));
            Create(new Student("Benny", 1982, "England", "..\\Assets\\benny.jpg"));
            Create(new Student("Carol", 1993, "USA", "..\\Assets\\carol.jpg"));
            Create(new Student("Daniel", 1990, "Denmark", "..\\Assets\\daniel.jpg"));
            Create(new Student("Eliza", 1974, "Australia", "..\\Assets\\eliza.jpg"));
        }
        #endregion

        #region Properties
        public List<Student> Students
        {
            get { return _students.Values.ToList(); }
        }
        #endregion

        #region Methods
        public void Create(Student s)
        {
            s.Key = _keyCount++;
            _students.Add(s.Key, s);
        }

        public void Delete(int key)
        {
            _students.Remove(key);
        }
        #endregion
    }
}