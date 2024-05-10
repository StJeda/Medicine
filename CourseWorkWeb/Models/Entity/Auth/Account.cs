using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CourseWorkWeb.Models.Entity.Orders;
using CourseWorkWeb.Models.Entity.Photos;

namespace CourseWorkWeb.Models.Entity.Auth
{
    public record Account()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Username { get; set; } = null!;
        public long Password_Id { get; set; }
        public long Photo_Id { get; set; }
        public UserPhoto UserPhoto { get; set; } = new UserPhoto();
        [StringLength(15)]
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Verify { get; set; } = false;
        [Required]
        public Password Password { get; set; } = new Password();
        public Role Role { get; set; } = null!;
        public ICollection<Order> Orders = new List<Order>();
    }
}
