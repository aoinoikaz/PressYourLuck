using System;
using System.ComponentModel.DataAnnotations;

namespace PressYourLuck.Models
{
    public class Audit
    {
        [Display(Name ="Audit Type")]
        public AuditType AuditType { get; set; }
        public int AuditTypeId { get; set; }
        public int AuditId { get; set; }

        [Display(Name = "Username")]
        public string PlayerName { get; set; }
        [Display(Name ="Date Created")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [DataType(DataType.Currency)]
        public double Amount { get; set; }
    }
}
