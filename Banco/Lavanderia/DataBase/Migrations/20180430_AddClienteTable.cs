using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lavanderia.DataBase.Migrations
{
    [Migration(20180430121800)]
    public class AddClienteTable : Migration
    {
        public override void Up()
        {
            Create.Table("Roupas")
                .WithColumn("RoupasId").AsInt64().PrimaryKey().Identity()
                .WithColumn("quantidadeRoupas").AsInt64()
                .WithColumn("horaEntrada").AsDateTime()
                .WithColumn("cpf").AsString();
        }
        
        public override void Down()
        {
            Delete.Table("Roupas");
        }
    }
}
