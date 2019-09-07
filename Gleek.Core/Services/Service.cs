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

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        protected void Create(TEntity entity)
        {
            _repository.Create(entity);
        }
    }
}
