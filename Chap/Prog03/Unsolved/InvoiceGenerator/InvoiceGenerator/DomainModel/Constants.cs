using System.Collections.Generic;

namespace InvoiceGenerator.DomainModel
{
    /// <summary>
    /// This class contains data which is considered constant,
    /// and not related to an individual order
    /// </summary>
    public class Constants
    {
        public const int TaxPercentage = 25;

        public static readonly Dictionary<int, string> ZipCodes = new Dictionary<int, string>
        {
            { 2750, "Ballerup" },
            { 3520, "Farum" },
            { 4000, "Roskilde" },
            { 4600, "Køge" },
            { 4720, "Præstø" }
        };
    }
}