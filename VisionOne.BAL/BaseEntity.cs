﻿using System.ComponentModel.DataAnnotations;

namespace VisionOne.BAL
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}