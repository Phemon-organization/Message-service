using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using phemon.Core.message.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phemon.Persistence.message.Configurations
{
    public class MessageConfigurations : IEntityTypeConfiguration<Messages>
    {
        public void Configure(EntityTypeBuilder<Messages> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("MessageId")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Message)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.UserId)
                .IsRequired()
                .IsUnicode();
        }
    }
}
