using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEventos.Modelos
{
    public class Pago
    {
        [Key]
        public int Codigo { get; set; }
        public string MetodoPago { get; set; }

        public int InscripcionCodigo { get; set; }
        public Inscripcion? Inscripcion { get; set; }
        public List<Informacion>? Informaciones { get; set; }
    }
}
