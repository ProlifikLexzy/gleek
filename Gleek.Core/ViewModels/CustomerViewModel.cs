using Gleek.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gleek.Core.ViewModels
{
    public class CustomerViewModel
    {
        public string FullName { get; set; }

        public string[] Accounts { get; set; }

        public static explicit operator Customer(CustomerViewModel source)
        {
            var customer = new Customer();
            var names = source.FullName.Split(" ");
            customer.FirstName = names.FirstOrDefault();
            customer.LastName = names.LastOrDefault();

            Func<string, Account> predicate = accountNo =>  new Account(){AccountNumber = accountNo};

            customer.AccountList = source.Accounts.Select(predicate);
            return customer;
        }

        private static Account ConvertAccountName(string accountNo)
        {
            return new Account()
            {
                AccountNumber = accountNo
            };

        }

        public static implicit operator CustomerViewModel(Customer source)
        {
            var customerVM = new CustomerViewModel();
            customerVM.FullName = $"{source.FirstName} {source.LastName}";
            customerVM.Accounts = source.AccountList.Select(a => a.AccountNumber).ToArray();

            return customerVM;
        }
    }
}
