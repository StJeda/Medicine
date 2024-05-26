using CourseWorkWeb.Models.Entity.Medicines;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWorkWeb.Models.Entity.Photos
{
    public record MedicinePhoto()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public byte[] bytes { get; set; } = [];
        [ForeignKey(nameof(Medicine))]
        public long Medicine_Id { get; set; }
    }
}
