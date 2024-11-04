using Chat.Domain.Entities.Accounts.AIBots;
using Chat.Domain.Services.AuthService;
using Chat.Domain.Shared.Models;
using Chat.Persistence.DBContext;

namespace Chat.Persistence.Seeds.DefaultUsers;

internal static partial class DefaultUsersSeed
{
    public static void CreateAIBots(EFContext eFContext)
    {
        if (!eFContext.AIBots.Any())
        {
            var aiBots = new[]
            {
                new
                {
                    Email = "ai.bot@bot.com",
                    Login = "AIBot",
                    Password = "Sosnova61S"
                }
            };

            IEnumerable<AIBot> aiBotList = aiBots.Select(bot =>
            {
                Password password = AuthBS.CreatePasswordHash(bot.Password);

                return new AIBot(bot.Email, bot.Login, password.Hash, password.Salt);
            });

            eFContext.AIBots.AddRange(aiBotList);
            eFContext.SaveChanges();
        }
    }
}
