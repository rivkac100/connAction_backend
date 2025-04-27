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
        List<T> Get();
        T GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);

        T fromDalToBl(S item);
        S fromBlToDal(T item);
        List<T> listFromDalToBl(List<S> item);
        List<S> listFromBlToDal(List<T> item);
    }
}
