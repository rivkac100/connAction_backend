//בס"ד

using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBlTask:IBlCrud<Models.BlTask,MyTask>
    {
    }
}
