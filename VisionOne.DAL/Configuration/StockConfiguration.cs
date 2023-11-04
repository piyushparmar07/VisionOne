using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionOne.Core.Domain;

namespace VisionOne.DAL.Configuration
{
    public class StockConfiguration
    {
        public StockConfiguration(EntityTypeBuilder<Stock> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Code).IsRequired();
            entityBuilder.Property(t => t.Location).IsRequired();
            entityBuilder.Property(t => t.ContainerNumber).IsRequired();
            entityBuilder.Property(t => t.GroupName).IsRequired();
            entityBuilder.Property(t => t.Quantity).IsRequired();
            entityBuilder.Property(t => t.Rate).IsRequired();
        }
    }
}
