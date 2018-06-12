using System;
using System.Linq;
using Domain.Entity;
using Domain.Interfaces;
using InfraData.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UoW;

namespace Poo3.Tests.EntityTest
{


    [TestClass]
    public class ClienteTeste
    {
        private readonly IClienteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Context _context;
        public ClienteTeste()
        {
            _context = new Context();
            _repository = new ClienteRepository(_context);
            _unitOfWork = new UnitOfWork(_context);
        }


        [TestMethod]
        public void Adicionar()
        {
            var cliente = new Domain.Entity.Clientes()
            {
                Id = Guid.NewGuid(),
                Nome = "Núbia",
                CPF = "07986401621",
                DataCadastro = DateTime.Now,
                DataNascimento = DateTime.Now,
                Email = "victor@dasd.com",
                Endereco = new Domain.Entity.Endereco
                {
                    Bairro = "Sao Mateus",
                    CEP = "36680000",
                    Cidade = "Juiz de Fora",
                    Complemento = "nao tem",
                    Estado = "MG",
                    Logradouro = "Rua engenheiro bicalho",
                    Numero = "25",

                }
            };
            _repository.Add(cliente);
            _unitOfWork.Commit();

        }

        public void Editar()
        {
            var cliente = _repository.GetAll().FirstOrDefault(x=> x.Nome == "Núbia");
            cliente.Nome = "Victor";
            var entry = _context.Entry(cliente);
            entry.State = System.Data.Entity.EntityState.Modified;
            _unitOfWork.Commit();

        }
    }
}



