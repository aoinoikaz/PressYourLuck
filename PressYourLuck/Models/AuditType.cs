using System.ComponentModel.DataAnnotations;

namespace PressYourLuck.Models
{
    public class AuditType
    {
        [Required]
        public int AuditTypeId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
