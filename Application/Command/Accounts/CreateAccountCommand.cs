using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.Accounts
{
    public class CreateAccountCommand : IRequest<Account>
    {
        public CreateAccountCommand(string accountNumber, decimal balance, int userId, int accountTypeId)
        {

            AccountNumber = accountNumber;
            Balance = balance;
            UserId = userId;
            AccountTypeId = accountTypeId;
        }

        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public int UserId { get; set; }
        public int AccountTypeId { get; set; }
    }
}
