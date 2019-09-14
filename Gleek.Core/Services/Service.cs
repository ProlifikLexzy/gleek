using Gleek.Core.Models;
using Gleek.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gleek.Core.Services
{
    public class Service<TEntity> where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> _repository;

        public IDictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();
        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        protected void Delete(Guid id)
        {
            _repository.Delete(id);
        }
        protected void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        protected void Create(TEntity entity)
        {
            _repository.Create(entity);
            _repository.SaveChanges();
        }
    }
}
