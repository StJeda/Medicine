using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWorkWeb.Models.Entity.Orders
{
    public record DeadLine()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public DateTime Start { get; set; } = DateTime.Now;
        [Required]
        public DateTime End { get; set; } = DateTime.Now.AddDays(5);
        public TimeSpan Remainder()
           => End - Start;
    }
}
