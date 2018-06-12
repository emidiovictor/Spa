using Domain.Entity;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraData.Repositories
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(Context context):base(context)
        {

        }

        public Fornecedor GetFornecedorEndereco(Guid? id)
        {
            return _dbContext.Set<Fornecedor>().Include(x => x.Endereco).FirstOrDefault(x => x.Id == id);
        }
    }
        
}
