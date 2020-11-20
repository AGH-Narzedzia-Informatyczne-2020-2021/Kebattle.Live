using Kebattle.DomainModel;
using Kebattle.Interfaces.Generics;
using Kebattle.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Kebattle.Repositories.Implementation
{
    public class AspNetUserRepository : Repository<AspNetUser>, IAspNetUserRepository
    {
        private readonly MyDbContext db;
        public AspNetUserRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
            db = (DataContext) as MyDbContext;
        }

        public AspNetUser GetUserByEmail(string email)
        {
            return Get(p => p.UserName == email);
        }
    }
}
