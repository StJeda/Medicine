using CourseWorkWeb.Models.Entity.Medicines;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWorkWeb.Models.Entity.Relations
{
    public record PharmaciesMedicines()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey(nameof(Pharmacy))]
        public long Pharmacy_Id { get; set;}
        [ForeignKey(nameof(Medicine))]
        public long Medicine_Id { get;set;}
        [Range(0,99999)]
        public int Quantity { get; set; }
    }
}
