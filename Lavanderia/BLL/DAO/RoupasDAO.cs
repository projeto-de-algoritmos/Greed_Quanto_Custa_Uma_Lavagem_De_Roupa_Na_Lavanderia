using Dapper.Contrib.Extensions;
using Lavanderia.BLL.DTO;
using Lavanderia.Config.DBConfig;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lavanderia.BLL.DAO
{
    public class RoupasDAO
    {
        //Inserir um cliente!
        public void InserirRoupa(RoupasDTO cliente)
        {
            using (var conn = new MySqlConnection(DBConection.Conexao))
            {
                conn.Open();
                conn.Insert<RoupasDTO>(cliente);
            }
        }
    }
}
