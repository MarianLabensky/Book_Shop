using Book_Shop.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Shop.Data.interfaces
{
    public interface IAllOrders
    {
        void CreateOrder(Order order);
    }
}
