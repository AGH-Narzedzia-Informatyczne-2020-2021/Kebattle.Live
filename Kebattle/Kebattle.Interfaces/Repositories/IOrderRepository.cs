using Kebattle.DomainModel;
using System.Collections.Generic;

namespace Kebattle.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetByCompanyId(int companyId);
        Order GetOrder(int orderId);
        void SaveOrder(Order order);
    }
}
