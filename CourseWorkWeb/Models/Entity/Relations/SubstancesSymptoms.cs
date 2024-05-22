using CourseWorkWeb.Models.Entity.Diseases;
using CourseWorkWeb.Models.Entity.Medicines;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWorkWeb.Models.Entity.Relations
{
    public record SubstancesSymptoms()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey(nameof(Substance))]
        public long Substance_Id { get; set; }
        [ForeignKey(nameof(Symptom))]
        public long Symptom_Id { get; set; }
    }
}
