using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWorkWeb.Models.Entity.Medicines
{
    public class Substance()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Active { get; set; } = null!;
        [Range(0.01d, 1000.0d)]
        public double Mass { get; set; } = 0.0d;
        [ForeignKey(nameof(Medicine))]
        public long Medicine_Id { get; set; }
    }
}
