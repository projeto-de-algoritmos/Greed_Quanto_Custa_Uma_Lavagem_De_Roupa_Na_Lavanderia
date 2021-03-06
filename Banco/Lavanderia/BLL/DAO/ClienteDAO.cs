using Lavanderia.BLL.DTO;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Lavanderia.Config.DBConfig;

namespace Lavanderia.BLL.DAO
{
    public class ClienteDAO
    {
        //Inserir um cliente!
        public void InserirCliente(ClienteDTO cliente)
        {
            using (var conn = new MySqlConnection(DBConection.Conexao))
            {
                conn.Open();
                conn.Insert<ClienteDTO>(cliente);
            }
        }

        public ClienteDTO buscaCPF(string cpf)
        {
            using (var conn = new MySqlConnection(DBConection.Conexao))
            {
                conn.Open();
                try
                {
                    return conn.Get<ClienteDTO>(new ClienteDTO { cpf = cpf });
                }
                catch(Exception ex)
                {
                    return null;
                }

                
            }
        }
    }
}
