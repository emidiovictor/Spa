using Domain.Entity;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace InfraData.Repositories
{
    public class SalaoRepository : Repository<Salao>, ISalaoRepository
    {
        public SalaoRepository(Context context) : base(context)
        {

        }

        public Salao GetSalaoEndereco(Guid? id) => _dbContext.Set<Salao>().Include(x => x.Endereco).FirstOrDefault(x => x.Id == id);
    }
}
