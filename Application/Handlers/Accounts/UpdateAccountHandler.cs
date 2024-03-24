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
    public class UpdateAccountHandler : IRequestHandler<UpdateAccountCommand, int>
    {
        private readonly IAccountRepository _accountRepository;
        public UpdateAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;

        }

        public async Task<int> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var checkAcc = await _accountRepository.GetAccountByIdAsync(request.Id);
            if (checkAcc == null) 
            {
                return default;
            }
            Account account = new Account
            {
                AccountNumber = request.AccountNumber,
                Balance = request.Balance,
                UserId = request.UserId,
                AccountTypeId = request.AccountTypeId,
            };

            return await _accountRepository.UpdateAccountAsync(account);


        }
         
    }
}
