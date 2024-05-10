using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWorkWeb.Models.Entity.Auth
{
    public record Password()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long Account_Id { get; set; }
        [Required]
        public string PasswordValue { get; set; } = null!;
    }
}
