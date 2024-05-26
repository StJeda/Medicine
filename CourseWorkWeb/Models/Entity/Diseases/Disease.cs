using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWorkWeb.Models.Entity.Diseases
{
    public class Disease()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty!;
        public virtual ICollection<Symptom> Symptoms { get; set; } = new List<Symptom>();
    }
}
