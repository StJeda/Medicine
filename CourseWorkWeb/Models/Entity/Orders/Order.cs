using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CourseWorkWeb.Models.Entity.Auth;
using CourseWorkWeb.Models.Entity.Medicines;
using CourseWorkWeb.Models.Enums;

namespace CourseWorkWeb.Models.Entity.Orders
{
    public class Order()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey(nameof(Account))]
        public long Account_Id { get; set; }
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = null!;
        public virtual ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
        [Required]
        public virtual DeadLine DeadLine { get; set; } = new DeadLine();
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
    }
}
