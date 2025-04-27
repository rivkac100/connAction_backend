//בס"ד

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBlActivity: IBlCrud<BL.Models.BlActivity,Dal.Models.Activity>
    {
    }
}
