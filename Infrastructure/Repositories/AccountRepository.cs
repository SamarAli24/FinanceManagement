using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
  
        private readonly FinanceDbContext _context;

        public AccountRepository(FinanceDbContext context)
        {

            _context = context;
        }

        public async Task<Account> GetAccountByIdAsync(int Id)
        {
            var data = await _context.Accounts.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<List<Account>> GetAccountListAsync()
        {
            var data = await _context.Accounts.ToListAsync();
            return data;

        }
        public async Task<Account> AddAccountAsync(Account account)
        {
            var result =  _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<int> UpdateAccountAsync(Account account)
        {
            _context.Accounts.Update(account);  
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAccountAsync(int Id)
        {
            var data= _context.Accounts.Where(x=> x.Id == Id).FirstOrDefault();
            _context.Accounts.Remove(data); 
            return data.Id;
        }

         

    }
}
