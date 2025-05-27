using BL.Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBlReport:IBlCrud<BlReport,Report>
    {
        Task<List<BlReport>> GetByActivityId(int activityId);
        Task<BlReport> GetByOrderId(int oid);
        Task<List<BlReport>> GetByCustomerId(int cid);
        Task<List<BlReport>> GetByManagerId(int mid);

    }
}
