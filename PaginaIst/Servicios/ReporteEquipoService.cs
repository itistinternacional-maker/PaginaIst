using System;
using System.Collections.Generic;
using System.Linq;
using PaginaIst.Models;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace PaginaIst.Services
{
    /// <summary>
    /// Implementación del servicio de reportes usando QuestPDF.
    /// </summary>
    public class ReporteEquipoService : IReporteEquipoService
    {
        // 🔹 PDF de un solo equipo (ficha detallada + firma)
        public byte[] GenerarPdfEquipo(EquiposIst equipo)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);

                    // Encabezado
                    page.Header()
                        .Text($"Ficha de Equipo - {equipo.Placa}")
                        .FontSize(18)
                        .SemiBold()
                        .AlignCenter();

                    // Contenido detallado del equipo
                    page.Content().PaddingVertical(10).Column(col =>
                    {
                        col.Item().Text($"ID: {equipo.id}");
                        col.Item().Text($"PLACA: {equipo.Placa}");
                        col.Item().Text($"ID_EMPLEADO: {equipo.Id_Empleado}");
                        col.Item().Text($"HOSTNAME: {equipo.Hostname}");
                        col.Item().Text($"FECHA_INICIAL: {equipo.Fecha_Inicial:dd/MM/yyyy}");
                        col.Item().Text($"FECHA_FINAL: {equipo.Fecha_Final:dd/MM/yyyy}");
                        col.Item().Text($"TIPO EQUIPO: {equipo.Id_Tipoequipo}");
                        col.Item().Text($"MARCA: {equipo.Marca}");
                        col.Item().Text($"MODELO: {equipo.Modelo}");
                        col.Item().Text($"SERIAL: {equipo.Serial}");
                        col.Item().Text($"NIT PROVEEDOR: {equipo.Nit_Proveedor}");
                        col.Item().Text($"GARANTÍA (años): {equipo.Garantia}");
                        col.Item().Text($"FUENTE/CARGADOR: {equipo.Fuente}");
                        col.Item().Text($"CAPACIDAD FUENTE: {equipo.Capacidad_Fuente}");
                        col.Item().Text($"PROCESADOR: {equipo.Procesador}");
                        col.Item().Text($"CLASE DISCO N°1: {equipo.Clase_DiscoN1}");
                        col.Item().Text($"CAPACIDAD DISCO N°1: {equipo.Capacidad_Disco_N1} GB");
                        col.Item().Text($"CLASE DISCO N°2: {equipo.Clase_Disco_N2}");
                        col.Item().Text($"CAPACIDAD DISCO N°2: {equipo.Capacidad_Disco_N2} GB");
                        col.Item().Text($"RAM N°1: {equipo.MEMORIA_RAM_N1} GB");
                        col.Item().Text($"RAM N°2: {equipo.MEMORIA_RAM_N2} GB");

                        // 🔹 Espacio para firma de recibido
                        col.Item().PaddingTop(30).Text(
                            "Dejo constancia de la recepción del equipo descrito anteriormente:")
                            .Italic();

                        col.Item().PaddingTop(20).Text("__________________________________________");
                        col.Item().Text("Firma del funcionario que recibe")
                                .FontSize(10);

                        col.Item().PaddingTop(10).Text("Nombre: ________________________________");
                        col.Item().Text("Fecha: ____ / ____ / ______");
                    });

                    // Pie de página
                    page.Footer()
                        .AlignRight()
                        .Text($"Generado el {DateTime.Now:dd/MM/yyyy HH:mm}");
                });
            });

            return document.GeneratePdf();
        }

        // 🔹 PDF del listado filtrado (todos los campos + aclaración + firma)
        public byte[] GenerarPdfListado(IEnumerable<EquiposIst> equipos)
        {
            var lista = equipos.ToList();

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);

                    // Usamos una columna para poner título, aclaración, tabla y firma
                    page.Content().Column(col =>
                    {
                        // 🔹 Título
                        col.Item()
                           .PaddingBottom(10)
                           .Text("Lista de Equipos")
                               .FontSize(16)
                               .SemiBold()
                               .AlignCenter();

                        // 🔹 Aclaración de campos (igual que en la vista HTML)
                        col.Item().PaddingBottom(10).Column(ac =>
                        {
                            ac.Item().Text("Aclaración de campos:")
                                     .FontSize(12);

                            ac.Item().Table(t =>
                            {
                                t.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(); // Tipo Disco
                                    columns.RelativeColumn(); // Tipo Equipo
                                    columns.RelativeColumn(); // Tipo Memoria RAM
                                });

                                // Encabezados
                                t.Header(h =>
                                {
                                    h.Cell().Text("TIPO DISCO").SemiBold();
                                    h.Cell().Text("TIPO EQUIPO").SemiBold();
                                    h.Cell().Text("TIPO MEMORIA RAM").SemiBold();
                                });

                                // Fila 1
                                t.Cell().Text("1. Mecánico");
                                t.Cell().Text("1. Desktop");
                                t.Cell().Text("1. 8Gb");

                                // Fila 2
                                t.Cell().Text("2. Sólido");
                                t.Cell().Text("2. Laptop");
                                t.Cell().Text("2. 12Gb");

                                // Fila 3
                                t.Cell().Text("3. M.2");
                                t.Cell().Text("");          // sin valor para tipo equipo 3
                                t.Cell().Text("3. 16Gb");

                                // Fila 4
                                t.Cell().Text("");
                                t.Cell().Text("");
                                t.Cell().Text("4. 20Gb");

                                // Fila 5
                                t.Cell().Text("");
                                t.Cell().Text("");
                                t.Cell().Text("5. 24Gb");

                                // Fila 6
                                t.Cell().Text("");
                                t.Cell().Text("");
                                t.Cell().Text("6. 32Gb");

                                // Fila 7
                                t.Cell().Text("");
                                t.Cell().Text("");
                                t.Cell().Text("7. 64Gb");
                            });
                        });

                        // 🔹 Tabla: ID | Placa | Detalle
                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(40);  // ID
                                columns.ConstantColumn(60);  // Placa
                                columns.RelativeColumn();    // Detalle (todo lo demás)
                            });

                            // Encabezados
                            table.Header(header =>
                            {
                                header.Cell().Text("ID").SemiBold();
                                header.Cell().Text("Placa").SemiBold();
                                header.Cell().Text("Detalle").SemiBold();
                            });

                            // Filas
                            foreach (var e in lista)
                            {
                                table.Cell().Text(e.id.ToString());
                                table.Cell().Text(e.Placa.ToString());

                                var detalle =
                                    $"Hostname: {e.Hostname ?? ""}\n" +
                                    $"Empleado: {e.Id_Empleado}\n" +
                                    $"Marca / Modelo: {e.Marca ?? ""} {e.Modelo ?? ""}\n" +
                                    $"Serial: {e.Serial ?? ""}\n" +
                                    $"Nit Proveedor: {e.Nit_Proveedor}\n" +
                                    $"Garantía (años): {e.Garantia}\n" +
                                    $"Fuente: {e.Fuente ?? ""}  |  Capacidad Fuente: {e.Capacidad_Fuente ?? ""}\n" +
                                    $"Procesador: {e.Procesador ?? ""}\n" +
                                    $"Disco 1: {e.Clase_DiscoN1 ?? ""} {e.Capacidad_Disco_N1} GB\n" +
                                    $"Disco 2: {e.Clase_Disco_N2 ?? ""} {e.Capacidad_Disco_N2} GB\n" +
                                    $"RAM 1: {e.MEMORIA_RAM_N1} GB  |  RAM 2: {e.MEMORIA_RAM_N2} GB\n" +
                                    $"Fecha Inicial: {e.Fecha_Inicial:dd/MM/yyyy}  |  Fecha Final: {e.Fecha_Final:dd/MM/yyyy}";

                                table.Cell().Text(detalle);
                            }
                        });

                        // 🔹 Texto con total de equipos
                        col.Item().PaddingTop(10)
                            .AlignRight()
                            .Text($"Total equipos: {lista.Count}");

                        // 🔹 Bloque de firma general
                        col.Item().PaddingTop(40).Column(firma =>
                        {
                            firma.Item().Text(
                                "Dejo constancia de que recibo la totalidad de los equipos relacionados en el presente listado:")
                                  .Italic();

                            firma.Item().PaddingTop(20).Text("__________________________________________");
                            firma.Item().Text("Firma del funcionario que recibe")
                                      .FontSize(10);

                            firma.Item().PaddingTop(10).Text("Nombre: ________________________________");
                            firma.Item().Text("Fecha: ____ / ____ / ______");
                        });
                    });

                    // Pie de página
                    page.Footer()
                        .AlignRight()
                        .Text($"Reporte generado el {DateTime.Now:dd/MM/yyyy HH:mm}");
                });
            });

            return document.GeneratePdf();
        }
    }
}
