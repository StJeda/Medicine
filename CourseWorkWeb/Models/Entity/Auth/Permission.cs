using CourseWorkWeb.Models.Entity.Relations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWorkWeb.Models.Entity.Auth
{
    public class Permission()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Action { get; set; } = null!;
        public virtual ICollection<RolesPermissions> RolesPermissions { get; set; } = new List<RolesPermissions>();
    }
}
