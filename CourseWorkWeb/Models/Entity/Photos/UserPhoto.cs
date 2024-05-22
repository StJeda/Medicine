using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CourseWorkWeb.Models.Entity.Photos
{
    public record UserPhoto()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public byte[] bytes { get; set; } = [];
        public long Medicine_Id { get; set; }
    }
}
