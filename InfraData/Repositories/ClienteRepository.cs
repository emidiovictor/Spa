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
    public class ClienteRepository : Repository<Clientes>, IClienteRepository
    {
        public ClienteRepository(Context context) : base(context)
        {

        }

        public Endereco GetEndereco(Guid id)
        {
            var cliente = GetClienteEndereco(id);
            return _dbContext.Set<Endereco>().FirstOrDefault(x => x.Id == cliente.Endereco.Id);
        }

        public Clientes GetClienteEndereco(Guid? id)
        {
            return _dbContext.Set<Clientes>().Include(x => x.Endereco).FirstOrDefault(x => x.Id == id);
        }

    }
}
