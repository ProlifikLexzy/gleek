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

        public bool CreateAccount(Guid customerId, string accountNo)
        {
            var account = new Account();
            account.CustomerId = customerId;
            account.AccountNumber = accountNo;

            this.Create(account);
            return true;
        }
    }
}
