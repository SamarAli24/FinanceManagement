using Application.Query.Accounts;
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
    public class GetAccountByIdHandler : IRequestHandler<GetAccountById, Account>
    {

        public readonly IAccountRepository accountRepository;


        public GetAccountByIdHandler(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }


        public async Task<Account> Handle(GetAccountById request, CancellationToken cancellationToken)
        {
            return await accountRepository.GetAccountByIdAsync(request.Id);
        }



    }
}
