using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionOne.BAL.Domain;

namespace VisionOne.DAL.Configuration
{
    public class RoleConfiguration
    {
        public RoleConfiguration(EntityTypeBuilder<Role> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
        }
    }
}
