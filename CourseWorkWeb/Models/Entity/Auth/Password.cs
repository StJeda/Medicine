using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWorkWeb.Models.Entity.Auth
{
    public class Password()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey(nameof(Account))]
        public long Account_Id { get; set; }
        public virtual Account User { get; set; }
        [Required]
        public string PasswordValue { get; set; } = null!;

    }
}
