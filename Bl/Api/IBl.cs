//בס"ד
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBl
    {
        public IBlCustomer Customer { get; }
        public IBlOrder Order { get; }
        public IBlTask Task { get; }
        public IBlActivity Activity { get; }
        public IBlEvent Event { get; }
        public IBlManager Manager { get; }
        public IBlUser User { get; }

    }
}
