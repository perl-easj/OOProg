namespace AzureCarRetailDBWebService
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Sale")]
    public partial class Sale
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int CarKey { get; set; }

        public int CustomerKey { get; set; }

        public int EmployeeKey { get; set; }

        public DateTime SalesDate { get; set; }

        public int FinalPrice { get; set; }

        public override string ToString()
        {
            return $"Sale done {SalesDate.ToShortDateString()}, price was {FinalPrice}";
        }
    }
}
