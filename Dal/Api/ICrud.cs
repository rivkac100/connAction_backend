//בס"ד

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface ICrud<T>
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(int id);
        Task Delete(int id);
        Task Create(T entity);
        Task Update(T entity);

    }
}
