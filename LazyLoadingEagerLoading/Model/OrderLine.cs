using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LazyLoadingEagerLoading.Model
{
    class OrderLine
    {
        public virtual Guid Id { get; set; }
        public virtual int Amount { get; set; }
        public virtual String ProductName { get; set; }
    }
}
