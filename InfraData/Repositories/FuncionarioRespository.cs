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
    public class FuncionarioRespository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRespository(Context context) : base(context)
        {

        }
        public Funcionario GetFuncionarioEndereco(Guid? id)

        {
            return _dbContext.Set<Funcionario>().Include(x => x.Endereco).FirstOrDefault(x => x.Id == id);

        }
    }
}
