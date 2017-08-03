using System;
using System.Collections.Generic;
using CQRSDemoApp.Dtos;

namespace CQRSDemoApp
{
    public class Repository<T> where T : IIdentity, IRepository<T>
    {
        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Add(T obj)
        {
            throw new NotImplementedException();
        }
    }

    public interface IRepository<T> where T: IIdentity
    {
        List<T> GetAll();
        T GetById(Guid id);
        void Add(T obj);
    }
}