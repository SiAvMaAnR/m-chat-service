using ChatService.Domain.Entities.Accounts;
using ChatService.Domain.Entities.Admins;
using ChatService.Domain.Entities.Attachments;
using ChatService.Domain.Entities.Channels;
using ChatService.Domain.Entities.Messages;
using ChatService.Domain.Entities.RefreshTokens;
using ChatService.Domain.Entities.Users;
using ChatService.Persistence.EntityConfigurations;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatService.Persistence.DBContext;

public class EFContext : DbContext, IDataProtectionKeyContext
{
    public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Channel> Channels { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Attachment> Attachments { get; set; }

    public EFContext(DbContextOptions<EFContext> options)
        : base(options)
    {
        // Database.EnsureDeleted();
        // Database.EnsureCreated();
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new AdminConfiguration());
        modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
        modelBuilder.ApplyConfiguration(new ChannelConfiguration());
        modelBuilder.ApplyConfiguration(new MessageConfiguration());
        modelBuilder.ApplyConfiguration(new AttachmentConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
}
