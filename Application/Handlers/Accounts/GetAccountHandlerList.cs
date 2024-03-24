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
    public class GetAccountHandlerList : IRequestHandler<GetAccountList , List<Account>>
    {
        public readonly IAccountRepository accountRepository;


        public GetAccountHandlerList(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }


        public async Task<List<Account>> Handle(GetAccountList request , CancellationToken cancellationToken)
        {
            return await accountRepository.GetAccountListAsync();
        }

    }
}
