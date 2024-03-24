using Application.Command.Accounts;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Accounts
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand  , Account>
    {
        private readonly IAccountRepository _accountRepository;
        public CreateAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;

        }

        public async Task<Account> Handle(CreateAccountCommand  request, CancellationToken cancellationToken)
        {
            Account account = new Account
            {
                AccountNumber = request.AccountNumber,
                Balance = request.Balance,
                UserId = request.UserId,
                AccountTypeId = request.AccountTypeId,
            };
           
            return await _accountRepository.AddAccountAsync(account);
              

        }


    }
}
