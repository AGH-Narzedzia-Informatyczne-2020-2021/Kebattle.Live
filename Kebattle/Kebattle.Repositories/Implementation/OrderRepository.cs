using Kebattle.DomainModel;
using Kebattle.Interfaces.Generics;
using Kebattle.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kebattle.Repositories.Implementation
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly MyDbContext db;
        public OrderRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
            db = (DataContext) as MyDbContext;
        }

        public List<Order> GetByCompanyID(int companyID)
        {
            return GetAll().ToList();
        }
    }
}
