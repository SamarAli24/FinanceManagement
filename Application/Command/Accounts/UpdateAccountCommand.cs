using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.Accounts
{
    public class UpdateAccountCommand : IRequest<int>
    {
        public UpdateAccountCommand(int id, string accountNumber, decimal balance, int userId, int accountTypeId)
        {
            Id = id;
            AccountNumber = accountNumber;
            Balance = balance;
            UserId = userId;
            AccountTypeId = accountTypeId;
        }

        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public int UserId { get; set; }
        public int AccountTypeId { get; set; }




    }
}
