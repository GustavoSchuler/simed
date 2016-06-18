using SisMed.Application.Interface;
using SisMed.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace SisMed.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> mServiceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            mServiceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            mServiceBase.Add(obj);
        }

        public void Dispose()
        {
            mServiceBase.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return mServiceBase.GetAll();
        }

        public TEntity GetById(int id)
        {
            return mServiceBase.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            mServiceBase.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            mServiceBase.Update(obj);
        }
    }
}
