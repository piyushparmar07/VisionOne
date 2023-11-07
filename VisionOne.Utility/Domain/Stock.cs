using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionOne.Core.Domain
{
    public class Stock:BaseEntity
    {
        [Required]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string Code { get; set; }
        [Required]
        [MaxLength(250)]
        [Column(TypeName = "nvarchar(250)")]
        public string Location { get; set; }
        [Required]
        [MaxLength(150)]
        [Column(TypeName = "nvarchar(150)")]
        public string ContainerNumber { get; set; }
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string GroupName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public int Rate { get; set; }
        //[Required]
        //public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
