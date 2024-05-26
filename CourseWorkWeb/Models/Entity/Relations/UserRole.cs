﻿using CourseWorkWeb.Models.Entity.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWorkWeb.Models.Entity.Relations
{
    public class UserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey(nameof(Account))]
        public long Account_Id { get; set; }
        
        [ForeignKey(nameof(Role))]
        public long Role_Id { get; set; }
    }
}
