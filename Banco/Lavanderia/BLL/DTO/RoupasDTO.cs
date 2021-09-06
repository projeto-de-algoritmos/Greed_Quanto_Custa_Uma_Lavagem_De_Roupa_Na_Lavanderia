using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lavanderia.BLL.DTO
{
    [Table("Roupas")]
    public class RoupasDTO
    {
        [Dapper.Contrib.Extensions.Key]
        public int RoupasId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int quantidadeRoupas { get; set; }

        public DateTime horaEntrada { get; set; }
        
        public string cpf { get; set; }
    }
}
