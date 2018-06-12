using Domain.Entity;
using InfraData.EnityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;

public class Context : DbContext
{
    public Context() : base("DefaultConnection")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        modelBuilder.Properties<string>()
            .Configure(p => p.HasColumnType("varchar"));

        modelBuilder.Properties<string>()
            .Configure(p => p.HasMaxLength(100));

        //Registrar FLUET API
        modelBuilder.Configurations.Add(new AgendaConfig());
        modelBuilder.Configurations.Add(new ClienteConfig());
        modelBuilder.Configurations.Add(new EnderecoConfig());
        modelBuilder.Configurations.Add(new FornecedorConfig());
        modelBuilder.Configurations.Add(new FuncionarioConfig());
        modelBuilder.Configurations.Add(new ProdutoConfig());
        modelBuilder.Configurations.Add(new ProdutoFornecedorConfig());
        modelBuilder.Configurations.Add(new SalaoConfig());
        modelBuilder.Configurations.Add(new ServicoConfig());
        modelBuilder.Configurations.Add(new ServicoRealizadoConfig());
        modelBuilder.Configurations.Add(new ServicoRealizadoFuncionarioConfing());




        base.OnModelCreating(modelBuilder);

    }
    public override int SaveChanges()
    {
        // Validação ao salvar!

        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("DataCadastro").CurrentValue = DateTime.Now;
            }
            if (entry.State == EntityState.Modified)
            {
                entry.Property("DataCadastro").IsModified = false;
            }
        }

        return base.SaveChanges();


    }
}