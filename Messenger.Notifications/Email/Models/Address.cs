﻿namespace MessengerX.Notifications.Email.Models;

public class EmailAddress
{
    public string? Name { get; set; }
    public string Email { get; set; } = null!;

    public EmailAddress(string name, string email)
    {
        Name = name;
        Email = email;
    }
}
