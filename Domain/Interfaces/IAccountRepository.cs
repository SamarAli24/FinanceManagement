using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAccountRepository  
    {
        public Task<List<Account>> GetAccountListAsync();
        public Task<Account> GetAccountByIdAsync(int Id);
        public Task<Account> AddAccountAsync(Account account);
        public Task<int> UpdateAccountAsync(Account account);
        public Task<int> DeleteAccountAsync(int Id);

    }
}
