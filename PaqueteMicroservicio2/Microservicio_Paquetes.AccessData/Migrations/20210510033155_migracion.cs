using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservicio_Paquete.AccessData.Migrations
{
    public partial class migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destino",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lugar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    atractivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    historia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destino", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Excursion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precio = table.Column<int>(type: "int", nullable: false),
                    bloqueada = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excursion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FormaPago",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPago", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sucursal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estrellas = table.Column<int>(type: "int", nullable: false),
                    bloqueado = table.Column<bool>(type: "bit", nullable: false),
                    idDireccion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "HotelPension",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelPension", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PaqueteEstado",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaqueteEstado", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoHabitacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    plazas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoHabitacion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mensaje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idDestino = table.Column<int>(type: "int", nullable: false),
                    Destinoid = table.Column<int>(type: "int", nullable: true),
                    idPasajero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comentario_Destino_Destinoid",
                        column: x => x.Destinoid,
                        principalTable: "Destino",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DestinoExcursion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idDestino = table.Column<int>(type: "int", nullable: false),
                    Destinoid = table.Column<int>(type: "int", nullable: true),
                    idExcursion = table.Column<int>(type: "int", nullable: false),
                    Excursionid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinoExcursion", x => x.id);
                    table.ForeignKey(
                        name: "FK_DestinoExcursion_Destino_Destinoid",
                        column: x => x.Destinoid,
                        principalTable: "Destino",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DestinoExcursion_Excursion_Excursionid",
                        column: x => x.Excursionid,
                        principalTable: "Excursion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DestinoHotel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idDestino = table.Column<int>(type: "int", nullable: false),
                    idHotel = table.Column<int>(type: "int", nullable: false),
                    Destinoid = table.Column<int>(type: "int", nullable: true),
                    Hotelid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinoHotel", x => x.id);
                    table.ForeignKey(
                        name: "FK_DestinoHotel_Destino_Destinoid",
                        column: x => x.Destinoid,
                        principalTable: "Destino",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DestinoHotel_Hotel_Hotelid",
                        column: x => x.Hotelid,
                        principalTable: "Hotel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HabitacionHotel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idTipoHabitacion = table.Column<int>(type: "int", nullable: false),
                    disponibles = table.Column<int>(type: "int", nullable: false),
                    idHotel = table.Column<int>(type: "int", nullable: false),
                    Hotelid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitacionHotel", x => x.id);
                    table.ForeignKey(
                        name: "FK_HabitacionHotel_Hotel_Hotelid",
                        column: x => x.Hotelid,
                        principalTable: "Hotel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paquetes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechasalida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechavuelta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totalnoches = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<int>(type: "int", nullable: false),
                    descuento = table.Column<int>(type: "int", nullable: false),
                    idPaqueteEstado = table.Column<int>(type: "int", nullable: false),
                    PaqueteEstadoid = table.Column<int>(type: "int", nullable: true),
                    idEmpleado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquetes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Paquetes_PaqueteEstado_PaqueteEstadoid",
                        column: x => x.PaqueteEstadoid,
                        principalTable: "PaqueteEstado",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaqueteDestino",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaquete = table.Column<int>(type: "int", nullable: false),
                    Paqueteid = table.Column<int>(type: "int", nullable: true),
                    idDestino = table.Column<int>(type: "int", nullable: false),
                    Destinoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaqueteDestino", x => x.id);
                    table.ForeignKey(
                        name: "FK_PaqueteDestino_Destino_Destinoid",
                        column: x => x.Destinoid,
                        principalTable: "Destino",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaqueteDestino_Paquetes_Paqueteid",
                        column: x => x.Paqueteid,
                        principalTable: "Paquetes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaqueteHotel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    noches = table.Column<int>(type: "int", nullable: false),
                    idPaquete = table.Column<int>(type: "int", nullable: false),
                    Paqueteid = table.Column<int>(type: "int", nullable: true),
                    idHotel = table.Column<int>(type: "int", nullable: false),
                    Hotelid = table.Column<int>(type: "int", nullable: true),
                    idHotelPension = table.Column<int>(type: "int", nullable: false),
                    HotelPensionid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaqueteHotel", x => x.id);
                    table.ForeignKey(
                        name: "FK_PaqueteHotel_Hotel_Hotelid",
                        column: x => x.Hotelid,
                        principalTable: "Hotel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaqueteHotel_HotelPension_HotelPensionid",
                        column: x => x.HotelPensionid,
                        principalTable: "HotelPension",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaqueteHotel_Paquetes_Paqueteid",
                        column: x => x.Paqueteid,
                        principalTable: "Paquetes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaqueteViaje",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaquete = table.Column<int>(type: "int", nullable: false),
                    Paqueteid = table.Column<int>(type: "int", nullable: true),
                    idViaje = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaqueteViaje", x => x.id);
                    table.ForeignKey(
                        name: "FK_PaqueteViaje_Paquetes_Paqueteid",
                        column: x => x.Paqueteid,
                        principalTable: "Paquetes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    preciototal = table.Column<int>(type: "int", nullable: false),
                    pasajeros = table.Column<int>(type: "int", nullable: false),
                    pagado = table.Column<bool>(type: "bit", nullable: false),
                    idPasajero = table.Column<int>(type: "int", nullable: false),
                    idFormaPago = table.Column<int>(type: "int", nullable: false),
                    FormaPagoid = table.Column<int>(type: "int", nullable: true),
                    idPaquete = table.Column<int>(type: "int", nullable: false),
                    Paqueteid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reserva_FormaPago_FormaPagoid",
                        column: x => x.FormaPagoid,
                        principalTable: "FormaPago",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserva_Paquetes_Paqueteid",
                        column: x => x.Paqueteid,
                        principalTable: "Paquetes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservaExcursion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idReserva = table.Column<int>(type: "int", nullable: false),
                    Reservaid = table.Column<int>(type: "int", nullable: true),
                    idExcursion = table.Column<int>(type: "int", nullable: false),
                    Excursionid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaExcursion", x => x.id);
                    table.ForeignKey(
                        name: "FK_ReservaExcursion_Excursion_Excursionid",
                        column: x => x.Excursionid,
                        principalTable: "Excursion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservaExcursion_Reserva_Reservaid",
                        column: x => x.Reservaid,
                        principalTable: "Reserva",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservaHabitacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    idReserva = table.Column<int>(type: "int", nullable: false),
                    Reservaid = table.Column<int>(type: "int", nullable: true),
                    idHotel = table.Column<int>(type: "int", nullable: false),
                    Hotelid = table.Column<int>(type: "int", nullable: true),
                    idTipoHabitacion = table.Column<int>(type: "int", nullable: false),
                    TipoHabitacionid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaHabitacion", x => x.id);
                    table.ForeignKey(
                        name: "FK_ReservaHabitacion_Hotel_Hotelid",
                        column: x => x.Hotelid,
                        principalTable: "Hotel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservaHabitacion_Reserva_Reservaid",
                        column: x => x.Reservaid,
                        principalTable: "Reserva",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservaHabitacion_TipoHabitacion_TipoHabitacionid",
                        column: x => x.TipoHabitacionid,
                        principalTable: "TipoHabitacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_Destinoid",
                table: "Comentario",
                column: "Destinoid");

            migrationBuilder.CreateIndex(
                name: "IX_DestinoExcursion_Destinoid",
                table: "DestinoExcursion",
                column: "Destinoid");

            migrationBuilder.CreateIndex(
                name: "IX_DestinoExcursion_Excursionid",
                table: "DestinoExcursion",
                column: "Excursionid");

            migrationBuilder.CreateIndex(
                name: "IX_DestinoHotel_Destinoid",
                table: "DestinoHotel",
                column: "Destinoid");

            migrationBuilder.CreateIndex(
                name: "IX_DestinoHotel_Hotelid",
                table: "DestinoHotel",
                column: "Hotelid");

            migrationBuilder.CreateIndex(
                name: "IX_HabitacionHotel_Hotelid",
                table: "HabitacionHotel",
                column: "Hotelid");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteDestino_Destinoid",
                table: "PaqueteDestino",
                column: "Destinoid");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteDestino_Paqueteid",
                table: "PaqueteDestino",
                column: "Paqueteid");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteHotel_Hotelid",
                table: "PaqueteHotel",
                column: "Hotelid");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteHotel_HotelPensionid",
                table: "PaqueteHotel",
                column: "HotelPensionid");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteHotel_Paqueteid",
                table: "PaqueteHotel",
                column: "Paqueteid");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_PaqueteEstadoid",
                table: "Paquetes",
                column: "PaqueteEstadoid");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteViaje_Paqueteid",
                table: "PaqueteViaje",
                column: "Paqueteid");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_FormaPagoid",
                table: "Reserva",
                column: "FormaPagoid");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_Paqueteid",
                table: "Reserva",
                column: "Paqueteid");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaExcursion_Excursionid",
                table: "ReservaExcursion",
                column: "Excursionid");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaExcursion_Reservaid",
                table: "ReservaExcursion",
                column: "Reservaid");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHabitacion_Hotelid",
                table: "ReservaHabitacion",
                column: "Hotelid");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHabitacion_Reservaid",
                table: "ReservaHabitacion",
                column: "Reservaid");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHabitacion_TipoHabitacionid",
                table: "ReservaHabitacion",
                column: "TipoHabitacionid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "DestinoExcursion");

            migrationBuilder.DropTable(
                name: "DestinoHotel");

            migrationBuilder.DropTable(
                name: "HabitacionHotel");

            migrationBuilder.DropTable(
                name: "PaqueteDestino");

            migrationBuilder.DropTable(
                name: "PaqueteHotel");

            migrationBuilder.DropTable(
                name: "PaqueteViaje");

            migrationBuilder.DropTable(
                name: "ReservaExcursion");

            migrationBuilder.DropTable(
                name: "ReservaHabitacion");

            migrationBuilder.DropTable(
                name: "Destino");

            migrationBuilder.DropTable(
                name: "HotelPension");

            migrationBuilder.DropTable(
                name: "Excursion");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "TipoHabitacion");

            migrationBuilder.DropTable(
                name: "FormaPago");

            migrationBuilder.DropTable(
                name: "Paquetes");

            migrationBuilder.DropTable(
                name: "PaqueteEstado");
        }
    }
}
