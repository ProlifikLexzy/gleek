using Gleek.Core.Models;
using Gleek.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gleek.Core.Services
{
    public class AccountService : Service<Account>
    {
        public AccountService(IRepository<Account> repository) : base(repository)
        {
        }

        public bool CreateAccount(Account account)
        {
            return CreateAccount(account.CustomerId, account.AccountNumber, account.CreatedBy_Id);
        }

        public bool CreateAccount(Guid customerId, string accountNo, Guid createdby)
        {
            if (string.IsNullOrEmpty(accountNo))
            {
                Errors.Add("AccountNo", "Account number is required");
                return false;
            }
            var account = new Account();
            account.CustomerId = customerId;
            account.AccountNumber = accountNo;
            account.CreatedBy_Id = createdby;

            this.Create(account);
            return true;
        }
    }
}
