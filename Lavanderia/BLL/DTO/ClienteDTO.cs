using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lavanderia.BLL.DTO
{
    public class ClienteDTO
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string email { get; set; }

        public string nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string cpf { get; set; }
    }
}
