using Lavanderia.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lavanderia.BLL.DAO;

namespace Lavanderia.Services
{
    public class Lavagem
    {
        public RoupasDTO roupas { get; set; }

        public Lavagem(){}
        public Lavagem(RoupasDTO roupas)
        {
            this.roupas = roupas;
        }

        public bool InserirRoupas(){

            if(checkValidade())
            {
                RoupasDAO roupasDAO = new RoupasDAO();
                if (roupas.quantidadeRoupas == 0)
                    return false;
                roupasDAO.InserirRoupa(roupas);
            }
            else
            {
                return false;
            }


            return true;
        }

        public IList<RoupasDTO> getAllRoupas()
        {
            return new RoupasDAO().getAll();
        }

        public bool checkValidade()
        {
                
            // Método que checa se é possível agendar.
            roupas.horaEntrada.AddMinutes(roupas.quantidadeRoupas);

            if (roupas.horaEntrada.Hour >= 24 && roupas.horaEntrada.Minute > 0)
                return false;

            return true;
        }

        public IList<RoupasDTO> getDay(DateTime dia)
        {
            new RoupasDAO().getDayFinal(dia);
            return null;
        }

    }
}
