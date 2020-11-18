using Kebattle.DomainModel;
using Kebattle.Interfaces.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kebattle.Repositories
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private bool _disposed;
        private MyDbContext dataContext;
        public MyDbContext GetContext()
        {
            return dataContext ?? (dataContext = new MyDbContext());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (dataContext != null)
                        dataContext.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
