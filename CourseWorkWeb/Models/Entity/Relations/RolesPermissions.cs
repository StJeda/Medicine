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
        public int Role_Id { get; set; }
        [ForeignKey(nameof(Permission))]
        public int Permission_Id { get; set;}
    }
}
