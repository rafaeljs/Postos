namespace Contexto.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Contexto.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Contexto.Context context)
        {
            context.Combustivel.AddOrUpdate(x => x.CombustivelId,
                new Combustivel() { CombustivelId = 1, Nome = "Gasolina Comum", DataInclusao = DateTime.Now },
                new Combustivel() { CombustivelId = 2, Nome = "Gasolina Aditivada", DataInclusao = DateTime.Now },
                new Combustivel() { CombustivelId = 3, Nome = "Etanol Comum", DataInclusao = DateTime.Now },
                new Combustivel() { CombustivelId = 4, Nome = "Etanol aditivado", DataInclusao = DateTime.Now }
                );
        }
    }
}
