using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEventos.Modelos
{
    public class PonenteEvento
    {
        [Key]
        public int Codigo { get; set; }

        public int EventoCodigo { get; set; }
        public Evento? Evento { get; set; }

        public int PonenteCodigo { get; set; }
        public Ponente? Ponente { get; set; }
    }
}
