using ReportTool.NewClasses.Formatters.Interfaces;

namespace ReportTool.NewClasses.Formatters.Base
{
    /// <inheritdoc />
    /// <summary>
    /// Application-wide base class for item formatter implementations.
    /// </summary>
    public abstract class ItemFormatterAppBase<T> : ItemFormatterBase<T>
    {
        #region Properties
        protected ITextElementFormatterFactory FormatterFactory { get; }
        #endregion

        #region Constructor
        protected ItemFormatterAppBase(ITextElementFormatterFactory formatterFactory, int totalWidth) 
            : base(totalWidth)
        {
            FormatterFactory = formatterFactory;
        } 
        #endregion

        #region Methods
        /// <summary>
        /// Default plural description for items of type T.
        /// </summary>
        public override string CreateDescription()
        {
            return typeof(T).Name.ToUpper() + "S";
        } 
        #endregion
    }
}