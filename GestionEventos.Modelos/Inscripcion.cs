using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEventos.Modelos
{
    public class Inscripcion
    {
        [Key]
        public int Codigo { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }

        public int ParticipanteCodigo { get; set; }
        public Participante? Participante { get; set; }

        public int EventoCodigo { get; set; }
        public Evento? Evento { get; set; }

        public Pago? Pago { get; set; }
        public Certificado? Certificado { get; set; }
    }
}
