using Kebattle.DomainModel;
using Kebattle.Interfaces.Generic;
using System.Collections.Generic;

namespace Kebattle.Interfaces.Repositories
{
    public interface IAspNetUserRepository : IRepository<AspNetUser>
    {
        AspNetUser GetUserByEmail(string email);
    }
}
