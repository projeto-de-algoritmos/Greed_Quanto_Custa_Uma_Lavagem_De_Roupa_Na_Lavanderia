using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lavanderia.BLL.DTO
{
    public class RoupasDTO
    {
        [Key]
        public int RoupasId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int quantidadeRoupas { get; set; }

        public DateTime horaEntrada { get; set; }
        
        public ClienteDTO cliente { get; set; }
    }
}
