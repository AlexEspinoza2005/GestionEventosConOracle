using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEventos.Modelos
{
    public class Certificado
    {
        [Key]
        public int Codigo { get; set; }
        public bool PagoRealizado { get; set; }
        public bool AsistenciaCompleta { get; set; }

        public int InscripcionCodigo { get; set; }
        public Inscripcion? Inscripcion { get; set; }
        public List<Informacion>? Informaciones { get; set; }
    }
}
