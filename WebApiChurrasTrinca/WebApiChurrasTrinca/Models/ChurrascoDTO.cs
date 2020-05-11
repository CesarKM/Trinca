using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiChurrasTrinca.Models
{
    public class ChurrascoDTO
    {
        public Churrasco churrasco { get; set; }
        public int QuantidadePessoas { get; set; }
        public decimal ValorComBebida { get; set; }
        public decimal ValorSemBebida { get; set; }
    }

    public class DetalheChurrascoDTO
    {
        public ChurrascoDTO DetalhesPrincipal { get; set; }
        public Churrasco_Usuario DetalhesParticipantes { get; set; }

    }
}
