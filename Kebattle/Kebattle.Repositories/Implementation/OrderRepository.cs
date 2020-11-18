using Kebattle.DomainModel;
using Kebattle.Interfaces.Generics;
using Kebattle.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Kebattle.Repositories.Implementation
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly MyDbContext db;
        public OrderRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
            db = (DataContext) as MyDbContext;
        }

        public List<Order> GetByCompanyId(int companyId)
        {
            return GetMany(a => a.CompanyId == companyId).ToList();
        }

        public Order GetOrder(int orderId)
        {
            return GetById(orderId);
        }

        public void SaveOrder(Order order)
        {
            if(order.Id == 0)
                Add(order);
            else
                Update(order);

            SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = GetById(id);

            Delete(order);
        }

        public List<SauceType> GetSauceTypes()
        {
            return db.SauceTypes.ToList();
        }

        public List<KebabType> GetKebabTypes()
        {
            return db.KebabTypes.ToList();
        }

        public List<MeatType> GetMeatTypes()
        {
            return db.MeatTypes.ToList();
        }
    }
}
