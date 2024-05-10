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
        public long MedicinePhoto_Id { get; set; }
        public MedicinePhoto Photo = new MedicinePhoto();
        public MedicineStatus Status = MedicineStatus.Available;
        public decimal Cost { get; set; } = decimal.Zero;
        [StringLength(50)]
        public string Country { get; set; } = string.Empty;
        public long Substance_Id { get; set; }
        public ICollection<Substance> Substances = new List<Substance>();
        public int Quantity { get; set; }

    }
}
