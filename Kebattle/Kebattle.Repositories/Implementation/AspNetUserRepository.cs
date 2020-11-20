using Kebattle.DomainModel;
using Kebattle.Interfaces.Generics;
using Kebattle.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

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

        public AspNetUser GetUserByEmailForSession(string email)
        {
            return db.AspNetUsers.Include(a => a.Companies).FirstOrDefault(a => a.UserName == email);
        }
    }
}
