using System.ComponentModel.DataAnnotations;

namespace VisionOne.Core
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}