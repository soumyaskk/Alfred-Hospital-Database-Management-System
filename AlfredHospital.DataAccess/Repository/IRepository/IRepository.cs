using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlfredHospital.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T: class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null);
        IEnumerable<T> GetAll(string? includeProperties = null);
        void Add(T entity);
        // Update would not be consistent with all classes 
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);



    }
}
