using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBlUser
    {
        Task<List<BlUser>> GetAll();
        Task<BlUser> GetById(string pass);
        Task<BlUser> GetById(string userType, int id);
    }
}
