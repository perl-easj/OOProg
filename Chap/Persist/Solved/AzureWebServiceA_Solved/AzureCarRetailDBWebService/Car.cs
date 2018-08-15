namespace AzureCarRetailDBWebService
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Car")]
    public partial class Car
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string LicensePlate { get; set; }

        [Required]
        [StringLength(30)]
        public string Brand { get; set; }

        [Required]
        [StringLength(30)]
        public string Model { get; set; }

        public int Year { get; set; }

        public int EngineSize { get; set; }

        public int HorsePower { get; set; }

        public int Seats { get; set; }

        public int Price { get; set; }

        public int ImageKey { get; set; }

        public override string ToString()
        {
            return $"{LicensePlate.TrimEnd(' ')} :  A {Brand.TrimEnd(' ')} {Model.TrimEnd(' ')}, costs {Price}";
        }
    }
}
