using Gleek.Core.Models;
using Gleek.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gleek.Core.Services
{
    public class CustomerService: Service<Customer>
    {
        private readonly AccountService accountService;

        public CustomerService(AccountService accountService,IRepository<Customer> repository): base(repository)
        {
            this.accountService = accountService;
        }

        public bool CreateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer cannot be null");


            if (string.IsNullOrEmpty(customer.FirstName) && string.IsNullOrEmpty(customer.LastName))
            {
                Errors.Add("FullName", "First and last name is required.");
                Errors["FullName"] = "First and last name is required.";
                return false;
            }

            if (customer.AccountList.Any(c => string.IsNullOrEmpty(c.AccountNumber) || string.IsNullOrWhiteSpace(c.AccountNumber)))
            {
                Errors["AccountList"] = "One or more account must assign to customer";
                return false;
            }

            this.Create(customer);

            try
            {
                foreach (var accountNo in customer.AccountList)
                {
                    this.accountService.CreateAccount(customer.Id, accountNo.AccountNumber, customer.CreatedBy_Id);
                }
            }
            catch (Exception)
            {
                this.Delete(customer.Id);
            }

            return true;
        }
    }
}
