using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Account
{
    public int Id { get; set; }

    public string? AccountNumber { get; set; }

    public decimal? Balance { get; set; }

    public int? AccountTypeId { get; set; }

    public int? UserId { get; set; }

    public virtual AccountType? AccountType { get; set; }

    public virtual User? User { get; set; }
}
