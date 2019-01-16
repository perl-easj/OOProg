using System.Collections.Generic;

namespace ReportTool.NewClasses.Formatters.Interfaces
{
    /// <summary>
    /// An ItemFormatter should - by implementing this interface - implement
    /// a specific formatting strategy for formatting items of type T.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IItemFormatter<in T>
    {
        /// <summary>
        /// Returns a general description of an item, e.g. like "PRODUCT". 
        /// </summary>
        string CreateDescription();

        /// <summary>
        /// Returns a string containing (properly formatted) names for the "columns" for an item, e.g. like:
        /// "DESCRIPTION         COST       WEIGHT          MEASUREMENTS"
        /// </summary>
        string CreateColumnHeader();

        /// <summary>
        /// Returns a string containing (properly formatted) details for a single item, e.g. like:
        /// "Sports Jacket      499,95       1,3 kgs.       60x40x12 cm"
        /// </summary>
        string CreateItemText(T item);


        /// <summary>
        /// Returns a string which will be the "footer" of a report, e.g. like:
        /// "Total items for shipping: 13. Total weight: 48,8 kgs."
        /// </summary>
        string CreateFooter(IEnumerable<T> collection);
    }
}