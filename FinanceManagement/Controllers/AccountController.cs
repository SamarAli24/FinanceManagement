using Application.Command.Accounts;
using Application.Query.Accounts;
using Domain.Interfaces;
using Domain.Models;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FinanceManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Account> _validator;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IMediator mediator, IValidator<Account> validator)
        {
            this.mediator = mediator;
            _validator = validator;

        }
        [HttpGet]
        public async Task<List<Account>> GetAccountList()
        {
            var accountList = await mediator.Send(new GetAccountList());
            return accountList;

        }
        [HttpGet("{id}")]
        public async Task<Account> GetAccountById(int id)
        {
            var account = await mediator.Send(new GetAccountById() { Id = id });
            return account;

        }
        [HttpPost]
        public async Task<Account> AddAccount(Account account)
        {
            var validationResult = await _validator.ValidateAsync(account);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException("Validation failed: " + string.Join(", ", validationResult.Errors));
            }

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                _logger.LogInformation("Account Creation .");

                var acc = await mediator.Send(new CreateAccountCommand(
                    account.AccountNumber, account.Balance ?? 0, account.AccountTypeId ?? 0, account.UserId ?? 0));

                await _unitOfWork.CommitTransactionAsync();
                _logger.LogInformation("Account Created successfully.");

                return acc;
            }
            catch
            {
                // Rollback the transaction in case of an exception
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }


        [HttpPut]
        public async Task<int> UpdateAccount(Account account)
        {

            var validationResult = await _validator.ValidateAsync(account);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException("Validation failed: " + string.Join(", ", validationResult.Errors));
            }

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                _logger.LogInformation("Updating account =" , account.AccountNumber);
                var acc = await mediator.Send(new UpdateAccountCommand(account.Id,
    account.AccountNumber, account.Balance ?? 0, account.AccountTypeId ?? 0, account.UserId ?? 0));

                await _unitOfWork.CommitTransactionAsync();
                _logger.LogInformation("Account updated successfully.");
                return acc;

            }
            catch
            {
                // Rollback the transaction in case of an exception
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }

        }


        [HttpDelete("{id}")]
        public async Task<int> DeleteAccount(int id)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var deletedAccountId = await mediator.Send(new DeleteAccountCommand() { Id = id });
                await _unitOfWork.CommitTransactionAsync();
                return deletedAccountId;
            }
            catch
            {
                // Rollback the transaction in case of an exception
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

    }
}
