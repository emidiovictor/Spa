using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoW
{
    public class UnitOfWork :IUnitOfWork
    {
        protected readonly Context _dbContext;

        public UnitOfWork(Context dbContext)
        {   
            _dbContext = dbContext;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();

        }

        public void Dispose() => _dbContext.Dispose();
    }
}

