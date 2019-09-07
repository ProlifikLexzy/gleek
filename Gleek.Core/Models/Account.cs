using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gleek.Core.Models
{
    public class Account : IEntity
    {
        public string AccountNumber { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CustomerId { get; set; }
    }
}
