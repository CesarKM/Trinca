using System;

namespace WebApiChurrasTrinca.Models
{
    public class Churrasco
    {
        public long Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }

    }
}
