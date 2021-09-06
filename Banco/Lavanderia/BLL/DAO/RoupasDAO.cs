using Dapper.Contrib.Extensions;
using Lavanderia.BLL.DTO;
using Lavanderia.Config.DBConfig;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using Newtonsoft.Json;

namespace Lavanderia.BLL.DAO
{
    public class RoupasDAO
    {
        //Inserir um cliente!


        public class request
        {
            public decimal[] inicios = new decimal[0];
            public decimal[] duracoes = new decimal[0];
        }
        public void InserirRoupa(RoupasDTO cliente)
        {
            using (var conn = new MySqlConnection(DBConection.Conexao))
            {
                conn.Open();
                conn.Insert<RoupasDTO>(cliente);
            }
        }

        public IList<RoupasDTO> getAll()
        {
            using (var conn = new MySqlConnection(DBConection.Conexao))
            {
                conn.Open();
                return (List<RoupasDTO>)conn.GetAll<RoupasDTO>();
            }
        }

        private List<RoupasDTO> getDay(DateTime dia)
        {
            List<RoupasDTO> roupas = new List<RoupasDTO>();

            using (var conn = new MySqlConnection(DBConection.Conexao))
            {
                conn.Open();

                string _query = "SELECT * FROM Roupas where horaEntrada BETWEEN '" + dia.ToString("yyyy-MM-dd 00:00:00") + "' AND '";

                dia = dia.AddDays(1);

                _query += dia.ToString("yyyy-MM-dd 00:00:00") + "'";

                MySqlCommand cmd = new MySqlCommand(_query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    RoupasDTO auxiliar = new RoupasDTO();
                    auxiliar.RoupasId = Convert.ToInt32(rdr[0]);
                    auxiliar.quantidadeRoupas = Convert.ToInt32(rdr[1]);
                    auxiliar.horaEntrada = Convert.ToDateTime(rdr[2]);
                    auxiliar.cpf = Convert.ToString(rdr[3]);

                    roupas.Add(auxiliar);
                }
                rdr.Close();
            }

            return roupas;
        }

        public int compare(RoupasDTO a, RoupasDTO b)
        {
            DateTime saidaA = a.horaEntrada.AddMinutes(a.quantidadeRoupas);
            DateTime saidaB = b.horaEntrada.AddMinutes(b.quantidadeRoupas);
            return saidaA.CompareTo(saidaB);
        }

        public async void getDayFinal(DateTime dia)
        {
            List<RoupasDTO> provisoria = getDay(dia);

            List<RoupasDTO> lavagensFinal = new List<RoupasDTO>();

            provisoria.Sort(compare);

            List<Decimal> iniciosEnd = new List<decimal>();
            List<Decimal> DuracoesEnd = new List<decimal>();

            request auxiliar = new request();

            foreach (var item in provisoria)
            {
                if (item == provisoria[0] || item.horaEntrada.TimeOfDay >= lavagensFinal[lavagensFinal.Count - 1].horaEntrada.AddMinutes(lavagensFinal[lavagensFinal.Count - 1].quantidadeRoupas).TimeOfDay)
                {
                    lavagensFinal.Add(item);
                    auxiliar.inicios.Append(item.horaEntrada.Hour + item.horaEntrada.Minute / 60);
                    auxiliar.duracoes.Append(item.quantidadeRoupas / 60);

                }
            }
            string output = JsonConvert.SerializeObject(auxiliar);
            var responseString = await "https://cck3xm.deta.dev/Agenda/"
            .PostUrlEncodedAsync(new { inicios = auxiliar.inicios, duracoes = auxiliar.duracoes })
            .ReceiveString();



        }
    }
}
