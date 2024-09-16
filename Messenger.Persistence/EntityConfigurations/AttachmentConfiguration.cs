﻿using Messenger.Domain.Entities.Attachments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Persistence.EntityConfigurations;

internal class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
{
    public void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.HasIndex(attachment => attachment.UniqueId).IsUnique();
        builder.Property(attachment => attachment.UniqueId).IsRequired();
        builder.Property(attachment => attachment.Content).IsRequired();
        builder.HasIndex(attachment => attachment.Type);
        builder.Property(attachment => attachment.Type).IsRequired();
    }
}
