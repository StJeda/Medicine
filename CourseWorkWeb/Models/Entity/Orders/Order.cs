using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CourseWorkWeb.Models.Entity.Medicines;
using CourseWorkWeb.Models.Enums;

namespace CourseWorkWeb.Models.Entity.Orders
{
    public record Order()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = null!;
        public ICollection<Medicine> Medicines = new List<Medicine>();
        [Required]
        public DeadLine DeadLine { get; set; } = new DeadLine();
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
    }
}
