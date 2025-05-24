using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionEventos.API.Migrations
{
    /// <inheritdoc />
    public partial class PruebaDeDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Lugar = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Apellido = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cedula = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Ponentes",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Apellido = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponentes", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Sesiones",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Horario = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Sala = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EventoCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiones", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Sesiones_Eventos_EventoCodigo",
                        column: x => x.EventoCodigo,
                        principalTable: "Eventos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ParticipanteCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EventoCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Eventos_EventoCodigo",
                        column: x => x.EventoCodigo,
                        principalTable: "Eventos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Participantes_ParticipanteCodigo",
                        column: x => x.ParticipanteCodigo,
                        principalTable: "Participantes",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PonenteEventos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EventoCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PonenteCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PonenteEventos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_PonenteEventos_Eventos_EventoCodigo",
                        column: x => x.EventoCodigo,
                        principalTable: "Eventos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PonenteEventos_Ponentes_PonenteCodigo",
                        column: x => x.PonenteCodigo,
                        principalTable: "Ponentes",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificado",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PagoRealizado = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    AsistenciaCompleta = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    InscripcionCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificado", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Certificado_Inscripciones_InscripcionCodigo",
                        column: x => x.InscripcionCodigo,
                        principalTable: "Inscripciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MetodoPago = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    InscripcionCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Pagos_Inscripciones_InscripcionCodigo",
                        column: x => x.InscripcionCodigo,
                        principalTable: "Inscripciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Informaciones",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ParticipanteCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EventoCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PagoCodigo = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    CertificadoCodigo = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informaciones", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Informaciones_Certificado_CertificadoCodigo",
                        column: x => x.CertificadoCodigo,
                        principalTable: "Certificado",
                        principalColumn: "Codigo");
                    table.ForeignKey(
                        name: "FK_Informaciones_Eventos_EventoCodigo",
                        column: x => x.EventoCodigo,
                        principalTable: "Eventos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Informaciones_Pagos_PagoCodigo",
                        column: x => x.PagoCodigo,
                        principalTable: "Pagos",
                        principalColumn: "Codigo");
                    table.ForeignKey(
                        name: "FK_Informaciones_Participantes_ParticipanteCodigo",
                        column: x => x.ParticipanteCodigo,
                        principalTable: "Participantes",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificado_InscripcionCodigo",
                table: "Certificado",
                column: "InscripcionCodigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Informaciones_CertificadoCodigo",
                table: "Informaciones",
                column: "CertificadoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Informaciones_EventoCodigo",
                table: "Informaciones",
                column: "EventoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Informaciones_PagoCodigo",
                table: "Informaciones",
                column: "PagoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Informaciones_ParticipanteCodigo",
                table: "Informaciones",
                column: "ParticipanteCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_EventoCodigo",
                table: "Inscripciones",
                column: "EventoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_ParticipanteCodigo",
                table: "Inscripciones",
                column: "ParticipanteCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_InscripcionCodigo",
                table: "Pagos",
                column: "InscripcionCodigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PonenteEventos_EventoCodigo",
                table: "PonenteEventos",
                column: "EventoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_PonenteEventos_PonenteCodigo",
                table: "PonenteEventos",
                column: "PonenteCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_EventoCodigo",
                table: "Sesiones",
                column: "EventoCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Informaciones");

            migrationBuilder.DropTable(
                name: "PonenteEventos");

            migrationBuilder.DropTable(
                name: "Sesiones");

            migrationBuilder.DropTable(
                name: "Certificado");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Ponentes");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Participantes");
        }
    }
}
