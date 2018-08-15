using ExamAdmV23.BaseClasses;

namespace ExamAdmV23.DomainClasses
{
    public class StudentCatalog : CatalogBase<Student>
    {
        #region Constructor
        public StudentCatalog()
        {
            Add(new Student("Ann", 1988, "Canada", "..\\Assets\\ann.jpg"));
            Add(new Student("Benny", 1982, "England", "..\\Assets\\benny.jpg"));
            Add(new Student("Carol", 1993, "USA", "..\\Assets\\carol.jpg"));
            Add(new Student("Daniel", 1990, "Denmark", "..\\Assets\\daniel.jpg"));
            Add(new Student("Eliza", 1974, "Australia", "..\\Assets\\eliza.jpg"));
        }
        #endregion
    }
}