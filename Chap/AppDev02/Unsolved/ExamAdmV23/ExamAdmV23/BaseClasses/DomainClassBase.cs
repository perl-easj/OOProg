namespace ExamAdmV23.BaseClasses
{
    /// <summary>
    /// A domain class must inherit from this class,
    /// and implement the Key property
    /// </summary>
    public abstract class DomainClassBase
    {
        public abstract int Key { get; set; }
    }
}
