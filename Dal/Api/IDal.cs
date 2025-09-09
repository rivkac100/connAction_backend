//בס"ד

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IDal
    {
        public IDalCustomer Customer { get; }
        public IDalOrder Order { get; }
        public IDalTask Task { get; }
        public IDalActivity Activity { get; }
        public IDalEvent Event { get; }
        public IDalManager Manager { get; }
        public IDalReport Report { get; }
    }
}
