// Variable global para guardar la instancia de DataTables
var dataTable;

// ✅ Se ejecuta cuando el DOM está listo
$(document).ready(function () {
    cargarDatatable();

    // Botón "Exportar listado PDF"
    $('#btnExportarPdf').on('click', function () {
        // Texto actual del buscador de DataTables
        var searchText = dataTable.search();

        // Llamamos al endpoint de exportación con ese filtro
        var url = '/EquiposIst/EquipoIT/ExportarPdf?search=' + encodeURIComponent(searchText);
        window.location.href = url; // El navegador descargará el PDF
    });
});

// ✅ Inicialización del DataTable
function cargarDatatable() {
    dataTable = $("#tblEquipos").DataTable({
        scrollX: true, // Scroll horizontal para muchas columnas

        ajax: {
            url: "/EquiposIst/EquipoIT/GetAll", // Endpoint que devuelve JSON { data: [...] }
            type: "GET",
            datatype: "json"
        },

        // Columnas: deben coincidir EXACTO con las propiedades del modelo EquiposIst
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "placa", "width": "5%" },
            { "data": "id_Empleado", "width": "5%" },
            { "data": "hostname", "width": "5%" },

            {
                "data": "fecha_Inicial",
                "render": function (data) {
                    return data ? new Date(data).toLocaleDateString() : 'Sin fecha';
                },
                "width": "5%"
            },
            {
                "data": "fecha_Final",
                "render": function (data) {
                    return data ? new Date(data).toLocaleDateString() : 'Sin fecha';
                },
                "width": "5%"
            },

            { "data": "id_Tipoequipo", "width": "5%" },
            { "data": "marca", "width": "10%" },
            { "data": "modelo", "width": "10%" },
            { "data": "serial", "width": "10%" },
            { "data": "nit_Proveedor", "width": "10%" },
            { "data": "garantia", "width": "5%" },
            { "data": "fuente", "width": "5%" },
            { "data": "capacidad_Fuente", "width": "5%" },
            { "data": "procesador", "width": "5%" },
            { "data": "clase_DiscoN1", "width": "5%" },
            { "data": "capacidad_Disco_N1", "width": "5%" },
            { "data": "clase_Disco_N2", "width": "5%" },
            { "data": "capacidad_Disco_N2", "width": "5%" },
            { "data": "memoriA_RAM_N1", "width": "5%" },
            { "data": "memoriA_RAM_N2", "width": "5%" },
            // Columna de acciones (editar, borrar, PDF)
            {
                data: "id",
                render: function (data) {
                    return `
                        <div class="text-center">
                            <a href="/EquiposIst/EquipoIT/Edit/${data}" class="btn btn-success text-white">
                                <i class="far fa-edit"></i> Editar
                            </a>

                            &nbsp;
                            &nbsp;
                            <a href="/EquiposIst/EquipoIT/DetallePdf/${data}"
                               class="btn btn-outline-danger">
                                <i class="far fa-file-pdf"></i> PDF
                            </a>
                        </div>`;
                },
                width: "15%"
            }
        ],

        language: {
            emptyTable: "No hay registros",
            info: "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            infoEmpty: "Mostrando 0 a 0 de 0 Entradas",
            infoFiltered: "(Filtrado de _MAX_ total entradas)",
            loadingRecords: "Cargando...",
            processing: "Procesando...",
            search: "Buscar:",
            zeroRecords: "Sin resultados encontrados",
            paginate: {
                first: "Primero",
                last: "Último",
                next: "Siguiente",
                previous: "Anterior"
            }
        },

        width: "100%"
    });
}


