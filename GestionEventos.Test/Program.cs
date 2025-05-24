using GestionEventos.API.Consumer;
using GestionEventos.Modelos;

namespace GestionEventos.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ProbarParticipantes();
           //ProbarPonentes();
           // ProbarEventos();
            //ProbarSesiones();
            //ProbarInscripcion();
            //ProbarPagos();
            //ProbarCertificados();
            ProbarInformaciones();
            //ProbarPonenteEventos();


            Console.ReadLine();
        }

        private static void ProbarParticipantes()
        {
            Crud<Participante>.EndPoint = "http://localhost:5136/api/Participantes";

            var participantesAntes = Crud<Participante>.GetAll();
            Console.WriteLine("Tabla original:");
            foreach (var p in participantesAntes)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, Nombre: {p.Nombre}, Apellido: {p.Apellido}, Cedula: {p.Cedula}, FechaNacimiento: {p.FechaNacimiento.ToShortDateString()}");
            }

            Console.WriteLine();
            Console.WriteLine("Eliminando participante...");

            try
            {
                Crud<Participante>.Delete(30);
                Console.WriteLine("Participante eliminado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar: {ex.Message}");
            }

            var participantesDespues = Crud<Participante>.GetAll();
            Console.WriteLine();
            Console.WriteLine("Tabla actualizada:");
            foreach (var p in participantesDespues)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, Nombre: {p.Nombre}, Apellido: {p.Apellido}, Cedula: {p.Cedula}, FechaNacimiento: {p.FechaNacimiento.ToShortDateString()}");
            }



        }



        private static void ProbarPonentes()
        {
            Crud<Ponente>.EndPoint = "http://localhost:5136/api/Ponentes";

            var ponente = Crud<Ponente>.Create(new Ponente
            {
                Codigo = 0,
                Nombre = "Alex",
                Apellido = "Espinoza",
                FechaNacimiento = new DateTime(2005, 5, 1)
            });

            Console.WriteLine("Después de crear:");
            var ponentes = Crud<Ponente>.GetAll();
            foreach (var p in ponentes)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, Nombre: {p.Nombre}, Apellido: {p.Apellido}, FechaNacimiento: {p.FechaNacimiento.ToShortDateString()}");
            }

            ponente.Nombre = "Alex Act";
            Crud<Ponente>.Update(ponente.Codigo, ponente);

            Console.WriteLine("\nDespués de actualizar:");
            var ponentesActualizados = Crud<Ponente>.GetAll();
            foreach (var p in ponentesActualizados)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, Nombre: {p.Nombre}, Apellido: {p.Apellido}, FechaNacimiento: {p.FechaNacimiento.ToShortDateString()}");
            }

            Crud<Ponente>.Delete(ponente.Codigo);

            Console.WriteLine("\nDespués de eliminar:");
            var ponentesFinales = Crud<Ponente>.GetAll();
            foreach (var p in ponentesFinales)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, Nombre: {p.Nombre}, Apellido: {p.Apellido}, FechaNacimiento: {p.FechaNacimiento.ToShortDateString()}");
            }


        }


        private static void ProbarEventos()
        {
            Crud<Evento>.EndPoint = "http://localhost:5136/api/Eventos";

            var evento = Crud<Evento>.Create(new Evento
            {
                Codigo = 0,
                Nombre = "Supletorios ",
                Fecha = new DateTime(2010, 1, 2),
                Lugar = "FICA",
                Tipo = "Estudio"
            });

            Console.WriteLine("Después de crear:");
            var eventos = Crud<Evento>.GetAll();
            foreach (var e in eventos)
            {
                Console.WriteLine($"Codigo: {e.Codigo}, Nombre: {e.Nombre}, Fecha: {e.Fecha.ToShortDateString()}, Lugar: {e.Lugar}, Tipo: {e.Tipo}");
            }

            evento.Nombre = "Supletorios";
            Crud<Evento>.Update(evento.Codigo, evento);

            Console.WriteLine("\nDespués de actualizar:");
            var eventosActualizados = Crud<Evento>.GetAll();
            foreach (var e in eventosActualizados)
            {
                Console.WriteLine($"Codigo: {e.Codigo}, Nombre: {e.Nombre}, Fecha: {e.Fecha.ToShortDateString()}, Lugar: {e.Lugar}, Tipo: {e.Tipo}");
            }

            Crud<Evento>.Delete(evento.Codigo);

            Console.WriteLine("\nDespués de eliminar:");
            var eventosFinales = Crud<Evento>.GetAll();
            foreach (var e in eventosFinales)
            {
                Console.WriteLine($"Codigo: {e.Codigo}, Nombre: {e.Nombre}, Fecha: {e.Fecha.ToShortDateString()}, Lugar: {e.Lugar}, Tipo: {e.Tipo}");
            }


        }


        private static void ProbarSesiones()
        {
            Crud<Sesion>.EndPoint = "http://localhost:5136/api/Sesiones";

            Console.WriteLine("Antes de eliminar:");
            var sesionesAntes = Crud<Sesion>.GetAll();
            foreach (var s in sesionesAntes)
            {
                Console.WriteLine($"Codigo: {s.Codigo}, Horario: {s.Horario}, Sala: {s.Sala}, Evento: {s.Evento?.Nombre}");
            }

            Crud<Sesion>.Delete(21);

            Console.WriteLine("\nDespués de eliminar:");
            var sesionesDespues = Crud<Sesion>.GetAll();
            foreach (var s in sesionesDespues)
            {
                Console.WriteLine($"Codigo: {s.Codigo}, Horario: {s.Horario}, Sala: {s.Sala}, Evento: {s.Evento?.Nombre}");
            }


        }

        private static void ProbarInscripcion()
        {
            Crud<Inscripcion>.EndPoint = "http://localhost:5136/api/Inscripciones";

            Console.WriteLine("Antes de eliminar:");
            var inscripcionesAntes = Crud<Inscripcion>.GetAll();
            foreach (var p in inscripcionesAntes)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, Estado: {p.Estado}, Fecha: {p.Fecha.ToShortDateString()}, Participante: {p.Participante?.Nombre}, Evento: {p.Evento?.Nombre}");
            }

            Crud<Inscripcion>.Delete(23);

            Console.WriteLine("\nDespués de eliminar:");
            var inscripcionesDespues = Crud<Inscripcion>.GetAll();
            foreach (var p in inscripcionesDespues)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, Estado: {p.Estado}, Fecha: {p.Fecha.ToShortDateString()}, Participante: {p.Participante?.Nombre}, Evento: {p.Evento?.Nombre}");
            }


        }

        private static void ProbarPagos()
        {
            Crud<Pago>.EndPoint = "http://localhost:5136/api/Pagos";

            Console.WriteLine("Antes de eliminar:");
            var pagosAntes = Crud<Pago>.GetAll();
            foreach (var p in pagosAntes)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, MetodoPago: {p.MetodoPago}, InscripcionEstado: {p.Inscripcion?.Estado}");
            }

            Crud<Pago>.Delete(61);

            Console.WriteLine("\nDespués de eliminar:");
            var pagosDespues = Crud<Pago>.GetAll();
            foreach (var p in pagosDespues)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, MetodoPago: {p.MetodoPago}, InscripcionEstado: {p.Inscripcion?.Estado}");
            }


        }


        private static void ProbarCertificados()
        {
            Crud<Certificado>.EndPoint = "http://localhost:5136/api/Certificados";

            var certificado = Crud<Certificado>.Create(new Certificado
            {
                Codigo = 0,
                PagoRealizado = true,
                AsistenciaCompleta = true,
                InscripcionCodigo = 22
            });

            var certificados = Crud<Certificado>.GetAll();
            foreach (var c in certificados)
            {
                Console.WriteLine($"Codigo: {c.Codigo}, PagoRealizado: {c.PagoRealizado}, AsistenciaCompleta: {c.AsistenciaCompleta}, InscripcionEstado: {c.Inscripcion?.Estado}");
            }

            certificado.PagoRealizado = true;
            certificado.AsistenciaCompleta = true;
            Crud<Certificado>.Update(certificado.Codigo, certificado);

            var certificadosActualizados = Crud<Certificado>.GetAll();
            foreach (var c in certificadosActualizados)
            {
                Console.WriteLine($"Codigo: {c.Codigo}, PagoRealizado: {c.PagoRealizado}, AsistenciaCompleta: {c.AsistenciaCompleta}, InscripcionEstado: {c.Inscripcion?.Estado}");
            }

            Crud<Certificado>.Delete(32);

            var certificadosFinales = Crud<Certificado>.GetAll();
            foreach (var c in certificadosFinales)
            {
                Console.WriteLine($"Codigo: {c.Codigo}, PagoRealizado: {c.PagoRealizado}, AsistenciaCompleta: {c.AsistenciaCompleta}, InscripcionEstado: {c.Inscripcion?.Estado}");
            }



        }



        private static void ProbarInformaciones()
        {
            Crud<Informacion>.EndPoint = "http://localhost:5136/api/Informaciones";

            Console.WriteLine("Antes de eliminar:");
            var informacionesAntes = Crud<Informacion>.GetAll();
            foreach (var i in informacionesAntes)
            {
                Console.WriteLine($"Codigo: {i.Codigo}, Participante: {i.Participante?.Nombre}, Evento: {i.Evento?.Nombre}, Pago: {(i.Pago != null ? "Sí" : "No")}, Certificado: {(i.Certificado != null ? "Sí" : "No")}");
            }

            Crud<Informacion>.Delete(29);

            Console.WriteLine("\nDespués de eliminar:");
            var informacionesDespues = Crud<Informacion>.GetAll();
            foreach (var i in informacionesDespues)
            {
                Console.WriteLine($"Codigo: {i.Codigo}, Participante: {i.Participante?.Nombre}, Evento: {i.Evento?.Nombre}, Pago: {(i.Pago != null ? "Sí" : "No")}, Certificado: {(i.Certificado != null ? "Sí" : "No")}");
            }


        }


        private static void ProbarPonenteEventos()
        {
            Crud<PonenteEvento>.EndPoint = "http://localhost:5136/api/PonenteEventos";

            Console.WriteLine("Antes de eliminar:");
            var listaAntes = Crud<PonenteEvento>.GetAll();
            foreach (var p in listaAntes)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, Evento: {p.Evento?.Nombre}, Ponente: {p.Ponente?.Nombre} {p.Ponente?.Apellido}");
            }

            Crud<PonenteEvento>.Delete(23);

            Console.WriteLine("\nDespués de eliminar:");
            var listaDespues = Crud<PonenteEvento>.GetAll();
            foreach (var p in listaDespues)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, Evento: {p.Evento?.Nombre}, Ponente: {p.Ponente?.Nombre} {p.Ponente?.Apellido}");
            }
        }




    }
}
