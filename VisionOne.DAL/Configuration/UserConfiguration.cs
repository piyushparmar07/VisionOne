using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionOne.BAL.Domain;

namespace VisionOne.DAL.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.FirstName).IsRequired();
            entityBuilder.Property(t => t.LastName).IsRequired();
            entityBuilder.Property(t => t.Email).IsRequired();
            entityBuilder.Property(t => t.Password).IsRequired();
            entityBuilder.HasOne(x => x.Role)
             .WithMany()
            .HasForeignKey(x => x.RoleId);
        }
    }
}
