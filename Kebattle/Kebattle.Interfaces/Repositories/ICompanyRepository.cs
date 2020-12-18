using Kebattle.DomainModel;
using Kebattle.Interfaces.Generic;
using System.Collections.Generic;

namespace Kebattle.Interfaces.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        List<CompaniesPrice> GetCompaniesPriceByCompanyId(int companyId);
        void AddOrUpdateCompaniesPrice(List<CompaniesPrice> prices);
        void CreateFirmAccount(string email);
        void UpdateCompanyName(int companyId, string name, string url);
    }
}
