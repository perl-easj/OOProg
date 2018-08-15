namespace DBEFandWSMovieServer
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Studio")]
    public partial class Studio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(30)]
        public string HQCity { get; set; }

        public int NoOfEmployees { get; set; }

        public override string ToString()
        {
            return $"{Name.TrimEnd(' ')}, HQ in {HQCity.TrimEnd(' ')} ({NoOfEmployees} employees)";
        }
    }
}
