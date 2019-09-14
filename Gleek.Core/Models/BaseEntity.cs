using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gleek.Core.Models
{
    public class BaseEntity: IEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy_Id { get; set; }
        [ForeignKey(nameof(CreatedBy_Id))]
        public GleekUser CreatedBy { get; set; }
    }
}
