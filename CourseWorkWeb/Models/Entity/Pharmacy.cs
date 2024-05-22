using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CourseWorkWeb.Models.Entity.Medicines;
using CourseWorkWeb.Models.Entity.Orders;

namespace CourseWorkWeb.Models.Entity
{
    public record Pharmacy()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(255)]
        public string Location { get; set; } = null!;
        [StringLength(15)]
        public string PhoneHotline { get; set; } = string.Empty!;
        public ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
