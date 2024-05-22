using CourseWorkWeb.Models.Entity.Relations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWorkWeb.Models.Entity.Auth
{
    public record Role()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        public ICollection<Account> Accounts { get; set; } = new List<Account>();
        public ICollection<RolesPermissions> RolesPermissions { get; set; } = new List<RolesPermissions>();
    }
}
