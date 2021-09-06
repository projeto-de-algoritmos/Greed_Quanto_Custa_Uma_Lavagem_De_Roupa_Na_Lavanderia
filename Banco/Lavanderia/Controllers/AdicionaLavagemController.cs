using Lavanderia.BLL.DTO;
using Lavanderia.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lavanderia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdicionaLavagemController : ControllerBase
    {
        [HttpPost]
        public void Post(RoupasDTO roupas)
        {
            Lavagem lavagem = new Lavagem(roupas);
            if (lavagem.InserirRoupas())
            {
                // retorna o resultado
            };
        }

        [HttpGet]
        public IList<RoupasDTO> GetAll()
        {
            return new Lavagem().getAllRoupas();
        }

        [HttpGet("{dia}")]
        public string getDay(DateTime dia)
        {
            return new Lavagem().getDay(dia);
        }
    }
}
