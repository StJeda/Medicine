using CourseWorkWeb.Models.Entity.Photos;
using CourseWorkWeb.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWorkWeb.Models.Entity.Medicines
{
    public record Medicine()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        public string Photo { get; set; }
        public MedicineStatus Status = MedicineStatus.Available;
        public decimal Cost { get; set; } = decimal.Zero;
        [StringLength(50)]
        public string Country { get; set; } = string.Empty;
        public virtual ICollection<Substance> Substances { get; set; } = new List<Substance>();
        public int Quantity { get; set; }
        public string Type { get; set; } = string.Empty;
        public double Discount { get; set; } = 0.00d;
    }
}
