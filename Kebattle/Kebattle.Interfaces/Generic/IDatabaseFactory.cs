using Kebattle.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kebattle.Interfaces.Generics
{
    public interface IDatabaseFactory : IDisposable
    {
        MyDbContext GetContext();
    }
}
