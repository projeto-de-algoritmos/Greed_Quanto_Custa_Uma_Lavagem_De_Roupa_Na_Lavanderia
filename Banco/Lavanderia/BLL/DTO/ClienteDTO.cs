using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lavanderia.BLL.DTO
{
    [Table("Cliente")]
    public class ClienteDTO
    {
        [Dapper.Contrib.Extensions.Key]
        public int ClienteId { get; set; }

        public string email { get; set; }

        public string nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string cpf { get; set; }
    }
}
