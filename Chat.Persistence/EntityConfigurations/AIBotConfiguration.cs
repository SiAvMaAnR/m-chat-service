using Chat.Domain.Entities.Accounts.AIBots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Persistence.EntityConfigurations;

internal class AIBotConfiguration : IEntityTypeConfiguration<AIBot>
{
    public void Configure(EntityTypeBuilder<AIBot> builder) { }
}
