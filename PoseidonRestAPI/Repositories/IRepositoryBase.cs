using System.Collections.Generic;

namespace PoseidonRestAPI.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        void DeleteAll();
        void DeleteById(int Id);
        IEnumerable<T> GetAll();
        T GetById(int Id);
        void Insert(T entity);
        void Update(T entity);
    }
}