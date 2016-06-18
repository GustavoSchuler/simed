using SisMed.Domain.Interfaces.Repositories;
using SisMed.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> mRepository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            mRepository = repository;
        }

        public void Add(TEntity obj)
        {
            mRepository.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return mRepository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return mRepository.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            mRepository.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            mRepository.Update(obj);
        }

        public void Dispose()
        {
            mRepository.Dispose();
        }
    }
}
