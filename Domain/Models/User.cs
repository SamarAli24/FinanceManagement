using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class User
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
