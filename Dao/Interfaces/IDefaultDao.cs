using System.Collections.Generic;

namespace VistoriasProjeto.Dao.Interfaces
{
    public interface IDefaultDao<T>
    {
        string EntityName { get; }
        T GetById(int id);
        List<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
