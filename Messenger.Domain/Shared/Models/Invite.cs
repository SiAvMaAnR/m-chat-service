namespace MessengerX.Domain.Shared.Models;

public class Invite
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string Email { get; set; } = null!;

    public Invite() { }

    public Invite(int id, string email, int companyId)
    {
        this.Id = id;
        this.Email = email;
        this.CompanyId = companyId;
    }
}
