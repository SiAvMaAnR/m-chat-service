﻿using System.ComponentModel.DataAnnotations.Schema;
using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Shared.Constants.Common;

namespace MessengerX.Domain.Entities.Admins;

[Table("Admins")]
public partial class Admin : Account
{
    public bool IsActive { get; set; } = true;

    public Admin()
    {
        Role = AccountRole.Admin;
    }
}