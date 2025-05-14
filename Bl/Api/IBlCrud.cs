//בס"ד

using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBlCrud<T,S>
    {
        Task<List<T>> Get();
        Task<T> GetById(int id);
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);

        Task<T> fromDalToBl(S item);
        Task<S> fromBlToDal(T item);
        List<T> listFromDalToBl(List<S> item);
        List<S> listFromBlToDal(List<T> item);
    }
}
