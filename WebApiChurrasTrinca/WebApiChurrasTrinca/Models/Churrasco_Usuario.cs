using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiChurrasTrinca.Models
{
    public class Churrasco_Usuario
    {
        public long Id { get; set; }
        public long ID_Churrasco { get; set; }
        public long ID_Usuario { get; set; }
        public decimal Valor_sugerido_ComBebida { get; set; }
        public decimal Valor_sugerido_SemBebida { get; set; }
    }
}
