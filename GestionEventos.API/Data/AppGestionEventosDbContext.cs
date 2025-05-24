using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestionEventos.Modelos;

    public class AppGestionEventosDbContext : DbContext
    {
        public AppGestionEventosDbContext (DbContextOptions<AppGestionEventosDbContext> options)
            : base(options)
        {
        }

        public DbSet<GestionEventos.Modelos.Certificado> Certificado { get; set; } = default!;

        public DbSet<GestionEventos.Modelos.Evento> Eventos { get; set; } = default!;

        public DbSet<GestionEventos.Modelos.Informacion> Informaciones { get; set; } = default!;

        public DbSet<GestionEventos.Modelos.Inscripcion> Inscripciones { get; set; } = default!;

        public DbSet<GestionEventos.Modelos.Pago> Pagos { get; set; } = default!;

        public DbSet<GestionEventos.Modelos.Participante> Participantes { get; set; } = default!;

        public DbSet<GestionEventos.Modelos.Ponente> Ponentes { get; set; } = default!;

        public DbSet<GestionEventos.Modelos.PonenteEvento> PonenteEventos { get; set; } = default!;

        public DbSet<GestionEventos.Modelos.Sesion> Sesiones { get; set; } = default!;
    }
