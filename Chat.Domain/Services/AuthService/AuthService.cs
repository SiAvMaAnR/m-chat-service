using System.Security.Cryptography;
using System.Text;
using Chat.Domain.Common;
using Chat.Domain.Exceptions;
using Chat.Domain.Shared.Models;

namespace Chat.Domain.Services.AuthService;

public class AuthBS : DomainService
{
    public AuthBS(IAppSettings appSettings, IUnitOfWork unitOfWork)
        : base(appSettings, unitOfWork) { }

    public static Password CreatePasswordHash(string password)
    {
        try
        {
            var hmac = new HMACSHA512();

            return new Password()
            {
                Salt = hmac.Key,
                Hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password))
            };
        }
        catch (Exception)
        {
            throw new FailedToCreatePasswordException();
        }
    }
}
