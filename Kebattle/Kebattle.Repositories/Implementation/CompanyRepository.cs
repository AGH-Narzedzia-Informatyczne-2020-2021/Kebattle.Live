using Kebattle.DomainModel;
using Kebattle.Interfaces.Generics;
using Kebattle.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Kebattle.Repositories.Implementation
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly MyDbContext db;
        private readonly IOrderRepository _orderRepository;
        public CompanyRepository(IDatabaseFactory databaseFactory, IOrderRepository orderRepository) : base(databaseFactory)
        {
            db = (DataContext) as MyDbContext;
            _orderRepository = orderRepository;
        }

        public List<CompaniesPrice> GetCompaniesPriceByCompanyId(int companyId)
        {
            var companiesPrice = new List<CompaniesPrice>();
            foreach(var type in _orderRepository.GetKebabTypes())
            {
                foreach(var size in _orderRepository.GetKebabSizes())
                {
                    var current = db.CompaniesPrices.Where(a => a.CompanyId == companyId && a.KebabTypeId == type.Id && a.KebabSizeId == size.Id).FirstOrDefault();
                    if(current != null)
                    {
                        companiesPrice.Add(current);
                    }
                    else
                    {
                        companiesPrice.Add(new CompaniesPrice()
                        {
                            CompanyId = companyId,
                            IsActive = false,
                            KebabSizeId = size.Id,
                            KebabTypeId = type.Id,
                            Price = 0
                        });
                    }
                }
            }
            return companiesPrice;
        }

        public void AddOrUpdateCompaniesPrice(List<CompaniesPrice> prices)
        {
            foreach(var price in prices)
            {
                if(price.Id == 0)
                {
                    db.CompaniesPrices.Add(price);
                }
                else
                {
                    var entity = db.CompaniesPrices.Where(a => a.Id == price.Id).FirstOrDefault();
                    entity.Price = price.Price;
                    entity.IsActive = price.IsActive;
                }
            }
            SaveChanges();
        }

        public void CreateFirmAccount(string email)
        {
            var user = db.AspNetUsers.Where(a => a.Email == email).FirstOrDefault();
            Add(new Company()
            {
                Name = "Firma " + user.Email,
                OwnerId = user.Id
            });
            SaveChanges();
        }

        public void UpdateCompanyName(int companyId, string name, string url)
        {
            var company = GetById(companyId);
            company.Name = name;
            company.Url = url;
            SaveChanges();
        }
    }
}
