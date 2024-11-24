using System.Security.Claims;

namespace Chat.Application.Common;

public class UserIdentity
{
    public int? Id { get; private set; } = null;
    public string? Role { get; private set; } = null;
    public ClaimsPrincipal? ClaimsPrincipal { get; private set; }

    public UserIdentity(ClaimsPrincipal? claimsPrincipal)
    {
        Update(claimsPrincipal);
    }

    public void Update(ClaimsPrincipal? claimsPrincipal)
    {
        if (int.TryParse(claimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id))
        {
            Id = id;
        }

        Role = claimsPrincipal?.FindFirst(ClaimTypes.Role)?.Value;
    }
}
