using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SchoolManagement.API.Models;

namespace SchoolManagement.API.Data {
    public interface IRepo<T> where T : AbstractEntity  {
        void SaveChanges();
        Task<T> GetById(int id);
        List<T> GetByPredicate(Expression<System.Func<T, bool>> predicate);
        Task<List<T>> GetAll();
        Task<List<T>> List(Expression<System.Func<T, bool>> predicate);
        void Add(T data);
        Task<T> Update(T data);
        Task<bool> Delete(T data);
    }
}