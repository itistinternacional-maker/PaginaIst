// Variable para almacenar la instancia de DataTables
var dataTable;

// ✅ Se ejecuta cuando el DOM está completamente cargado
$(document).ready(function () {
    cargarDatatable();  // Llama a la función que carga los datos en la tabla
});

// ✅ Función que inicializa el DataTable
function cargarDatatable() {
    dataTable = $("#tblEquipos").DataTable({
        // 🔹 Permite el desplazamiento horizontal si hay muchas columnas
        "scrollX": true,

        // 🔹 Configuración de la fuente de datos AJAX
        "ajax": {
            "url": "/equiposist/equipoit/GetAll",  // Ruta del endpoint que retorna los datos
            "type": "GET",                        // Método HTTP para obtener los datos
            "datatype": "json"                   // 🔎 IMPORTANTE: 'dataSrc' indica que los datos se encuentran en la clave `data` del JSON
        },

        // 🔹 Configuración de las columnas que se mostrarán en la tabla
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "placa", "width": "5%" },
            { "data": "id_Empleado", "width": "5%" },
            { "data": "hostname", "width": "5%" },

            // 🔹 Formato para las fechas (Verifica que el formato sea correcto)
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


            // 🔹 Botones de acciones (Editar/Borrar) con eventos personalizados
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/EquiposIst/EquipoIT/Edit/${data}" class="btn btn-success text-white">
                                <i class="far fa-edit"></i> Editar
                            </a>
                            &nbsp;
                            <a href="javascript:void(0);" onclick="Delete('/EquiposIst/EquipoIT/Delete/${data}')" 
                                class="btn btn-danger text-white">
                                <i class="far fa-trash-alt"></i> Borrar
                            </a>
                        </div>`;
                },
                "width": "10%"
            }
        ],

        // 🔹 Configuración de textos en español
        "language": {
            "emptyTable": "No hay registros",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 a 0 de 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },

        // 🔹 Configura el ancho total de la tabla al 100%
        "width": "100%"
    });
}

