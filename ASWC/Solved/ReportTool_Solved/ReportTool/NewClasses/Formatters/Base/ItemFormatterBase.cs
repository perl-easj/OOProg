using System;
using System.Collections.Generic;
using System.Linq;
using ReportTool.NewClasses.Formatters.Interfaces;

namespace ReportTool.NewClasses.Formatters.Base
{
    /// <summary>
    /// Base class for item formatter implementations.
    /// </summary>
    /// <typeparam name="T">Type of item for which to apply formatting.</typeparam>
    public abstract class ItemFormatterBase<T> : IItemFormatter<T>
    {
        #region Properties and Constructor
        protected List<int> ElementWidths { get; set; }

        protected ItemFormatterBase(int totalWidth)
        {
            TotalWidth = totalWidth;
            SetElementWidths();
            CheckElementWidth();
        }
        #endregion

        #region Public methods
        public string CreateColumnHeader()
        {
            return CreateTextLine(ColumnHeaderTextElements());
        }

        public string CreateItemText(T item)
        {
            return CreateTextLine(RowTextElements(item));
        }
        #endregion

        #region Abstract properties and methods
        /// <summary>
        /// Returns the total width of a text line, i.e. a row in the report.
        /// </summary>
        protected int TotalWidth { get; }

        /// <inheritdoc />
        /// <summary>
        /// (cannot be implemented in base class)
        /// </summary>
        public abstract string CreateDescription();

        /// <inheritdoc />
        /// <summary>
        /// (cannot be implemented in base class)
        /// </summary>
        public abstract string CreateFooter(IEnumerable<T> collection);

        /// <summary>
        /// Returns all the text elements in the column header, in the
        /// form of a collection of ITextElementFormatter objects.
        /// </summary>
        protected abstract List<ITextElementFormatter> ColumnHeaderTextElements();

        /// <summary>
        /// Returns all the text elements in a row for a single object of type T,
        /// in the form of a collection of ITextElementFormatter objects.
        /// </summary>
        protected abstract List<ITextElementFormatter> RowTextElements(T item);

        /// <summary>
        /// Set up the widths of all text elements in a text line
        /// </summary>
        protected abstract void SetElementWidths();
        #endregion

        #region Private helper methods
        /// <summary>
        /// Creates a text line (i.e. a string) from the given collection
        /// of ITextElementFormatter objects.
        /// </summary>
        private string CreateTextLine(List<ITextElementFormatter> textElements)
        {
            return textElements.Aggregate("", (text, tE) => text + tE.FormattedText);
        }

        /// <summary>
        /// Checks that the sum of the element widths add up to TotalWidth.
        /// Is invoked from the constructor.
        /// </summary>
        private void CheckElementWidth()
        {
            if (ElementWidths != null && ElementWidths.Sum() == TotalWidth) return;
            throw new ArgumentException($"Width of elements does not add up to {TotalWidth}");
        } 
        #endregion
    }
}