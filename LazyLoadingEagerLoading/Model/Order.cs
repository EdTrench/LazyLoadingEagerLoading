using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace LazyLoadingEagerLoading.Model
{
    class Order
    {
        List<OrderLine> _orderLine = new List<OrderLine>();

        public virtual Guid Id { get; set; }
        public virtual List<OrderLine> OrderLines {
            get {return _orderLine;}
            set { _orderLine = value;}
        }
        public virtual Customer Customer { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual String OrderNumber { get; set; }
    }
}
