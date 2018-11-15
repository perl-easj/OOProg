namespace SimpleRPGDemo.Model.Interfaces
{
    public interface IValidate<T>
    {
        bool Validate(T obj);
        string ValidationErrorString(T obj);
    }
}