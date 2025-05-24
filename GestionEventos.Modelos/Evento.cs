using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEventos.Modelos
{
    public class Evento
    {
        [Key] public int Codigo { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public string Tipo { get; set; }

        public List<Sesion>? Sesiones { get; set; }
        public List<PonenteEvento>? PonenteEventos { get; set; }
        public List<Inscripcion>? Inscripciones { get; set; }
        public List<Informacion>? Informaciones { get;set; }
    }
}
