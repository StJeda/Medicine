using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Azure.Identity;
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
        public virtual UserPhoto UserPhoto { get; set; } = new UserPhoto();
        [StringLength(15)]
        [NotMapped]
        public string userPh { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Verify { get; set; } = false;
        [Required]
        public virtual Password Password { get; set; } = new Password();
        [ForeignKey(nameof(Role))]
        public long RoleId { get; set; }
        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public static Account Create(string username, string email, string password)
            => new Account
            {
                Username = username,
                Email = email,
                Password = new Password()
                {
                    PasswordValue = password
                }
            };
    }
}
