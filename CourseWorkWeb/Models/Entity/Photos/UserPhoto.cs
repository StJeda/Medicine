using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CourseWorkWeb.Models.Entity.Auth;

namespace CourseWorkWeb.Models.Entity.Photos
{
    public record UserPhoto()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public byte[] Photo { get; set; } = [];
        [ForeignKey(nameof(Account))]
        public long Account_Id { get; set; }
    }
}
