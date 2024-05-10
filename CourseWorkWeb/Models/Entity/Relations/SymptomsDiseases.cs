using CourseWorkWeb.Models.Entity.Diseases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWorkWeb.Models.Entity.Relations
{
    public class SymptomsDiseases
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey(nameof(Disease))]
        public int Disease_Id {  get; set; }
        [ForeignKey(nameof(Symptom))]
        public int Symptom_Id { get; set; }
    }
}
