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
    public class DeleteAccountHandler : IRequestHandler<DeleteAccountCommand, int>
    {
        private readonly IAccountRepository _accountRepository;
        public DeleteAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;

        }


        public async Task<int> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var checkAcc = await _accountRepository.GetAccountByIdAsync(request.Id);
            if (checkAcc == null)
            {
                return default;
            }
 
            return await _accountRepository.DeleteAccountAsync(request.Id);


        }
    }
}
