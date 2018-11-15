using ViewModel.Data.Implementation;

namespace SimpleRPGDemo.ViewModel.Base
{
    public abstract class DataViewModelAppBase<T> : DataViewModelBase<T>
        where T : class
    {

        protected DataViewModelAppBase(T obj) : base(obj)
        {
        }

        public virtual string HeaderText
        {
            get { return "Override HeaderText..."; }
        }

        public virtual string ContentText
        {
            get { return "Override ContentText..."; }
        }
    }
}