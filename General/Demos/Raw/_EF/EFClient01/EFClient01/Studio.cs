namespace EFClient01
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Studio")]
    public partial class Studio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Studio()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string HQCity { get; set; }

        public int? NoOfEmployees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movie> Movies { get; set; }

        public override string ToString()
        {
            string result = $"{Name.TrimEnd(' ')} in {HQCity.TrimEnd(' ')} ({NoOfEmployees} employees)\n";

            foreach (var movie in Movies)
            {
                result += $"  {movie}\n";
            }

            return result;
        }
    }
}
