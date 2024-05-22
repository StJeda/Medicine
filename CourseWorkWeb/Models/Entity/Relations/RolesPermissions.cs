using CourseWorkWeb.Models.Entity.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWorkWeb.Models.Entity.Relations
{
    public record RolesPermissions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey(nameof(Role))]
        public long RoleId { get; set; }
        public Role Role { get; set; }

        [ForeignKey(nameof(Permission))]
        public long PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
