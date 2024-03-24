using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class AccountType
{
    public int Id { get; set; }

    public string? AccountType1 { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
