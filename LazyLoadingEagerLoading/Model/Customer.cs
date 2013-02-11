using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LazyLoadingEagerLoading.Model
{
    class Customer
    {
        public virtual Guid Id { get; set; }
        public virtual String CompanyName { get; set; }
    }
}
