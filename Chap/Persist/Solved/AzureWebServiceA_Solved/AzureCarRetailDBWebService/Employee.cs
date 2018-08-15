namespace AzureCarRetailDBWebService
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Employee")]
    public partial class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        [StringLength(30)]
        public string Title { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        public DateTime EmployedDate { get; set; }

        public int ImageKey { get; set; }

        public int CarsSold { get; set; }

        public override string ToString()
        {
            return $"{FullName.TrimEnd(' ')}, employed {EmployedDate.ToShortDateString()}";
        }
    }
}
