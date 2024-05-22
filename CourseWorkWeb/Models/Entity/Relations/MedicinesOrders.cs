using CourseWorkWeb.Models.Entity.Medicines;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CourseWorkWeb.Models.Entity.Orders;

namespace CourseWorkWeb.Models.Entity.Relations
{
    public record MedicinesOrders()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey(nameof(Medicine))]
        public long Medicine_Id { get; set; }
        [ForeignKey(nameof(Order))]
        public long Order_Id { get; set; }
    }
}
