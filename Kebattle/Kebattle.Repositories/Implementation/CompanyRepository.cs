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
        public CompanyRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
            db = (DataContext) as MyDbContext;
        }


    }
}
