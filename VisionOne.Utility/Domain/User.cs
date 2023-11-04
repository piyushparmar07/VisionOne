using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionOne.Core.Domain
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }
        [Required]
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
