using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEventos.Modelos
{
    public class Participante
    {
        [Key]
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public List<Inscripcion>? Inscripciones { get; set; }
        public List<Informacion>? Informaciones { get; set; }
    }
}
