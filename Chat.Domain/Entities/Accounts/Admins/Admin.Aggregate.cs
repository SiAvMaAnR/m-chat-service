namespace Chat.Domain.Entities.Accounts.Admins;

public partial class Admin : IAggregateRoot
{
    public void UpdateActive(bool isActive)
    {
        IsActive = isActive;
    }
}
