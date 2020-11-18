using Kebattle.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kebattle.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetByCompanyID(int companyID);
    }
}
