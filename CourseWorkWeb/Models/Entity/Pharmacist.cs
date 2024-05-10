using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWorkWeb.Models.Entity
{
    public record Pharmacist()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        public long Grade_Id { get; set; }
        public long Account_Id { get; set; }
        public long Pharmacy_Id { get; set; }
        public long Salary_Id { get; set; }
    }
}
