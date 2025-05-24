using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEventos.Modelos
{
    public class Sesion
    {
        [Key]
        public int Codigo { get; set; }
        public DateTime Horario { get; set; }
        public string Sala { get; set; }

        public int EventoCodigo { get; set; }
        public Evento? Evento { get; set; }
    }
}
