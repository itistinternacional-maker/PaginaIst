// ✅ Variable global para almacenar la instancia del DataTable
var dataTable;

$(document).ready(function () {
    cargarDatatable();  // ✅ Llama a la función para inicializar el DataTable cuando se cargue la página
});

// ✅ Función para inicializar el DataTable
function cargarDatatable() {
    $("#tblPaginasIsts").DataTable({ // 🔹 Asocia el DataTable al elemento con el ID `tblPaginasIsts`
        "ajax": {  // 🔹 Configuración para obtener datos vía AJAX
            "url": "/admin/Contrasena/GetAll",  // ✅ Endpoint que retorna los datos en formato JSON
            "type": "GET",                     // ✅ Método GET para solicitar datos
            "datatype": "json"                
        },

        // ✅ Definición de columnas que se mostrarán en el DataTable
        "columns": [
            { "data": "id", "width": "5%" },          // 
            { "data": "url", "width": "20%" },        
            { "data": "descripcion", "width": "20%" }, 
            { "data": "observacion", "width": "20%" }, 
            { "data": "usuario", "width": "15%" },     
            { "data": "contraseña", "width": "15%" },  

            // ✅ Botones de "Editar" y "Eliminar"
            {
                "data": "id",  // 🔹 Se usa el ID del registro para armar las URLs
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Admin/Contrasena/Edit/${data}" class="btn btn-success text-white">
                                <i class="far fa-edit"></i> Editar
                            </a>
                            &nbsp;
                 
                        </div>`;
                },
                "width": "15%"  // ✅ Espacio asignado a esta columna en la tabla
            }
        ],

        // ✅ Personalización del texto y mensajes del DataTable
        "language": {
            "decimal": "",
            "emptyTable": "No hay registros",  
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "lengthMenu": "Mostrar _MENU_ Entradas",
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
        "width": "100%"  // ✅ La tabla se expandirá al 100% del contenedor
    });
}

// ✅ Función para eliminar registros
function Delete(url) {
    // 🔹 Muestra un cuadro de confirmación con SweetAlert
    swal({
        title: "¿Está seguro de borrar?",
        text: "Este contenido no se puede recuperar!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Sí, borrar!",
        closeOnConfirm: true
    }, function () {  // 🔹 Si el usuario confirma la eliminación
        $.ajax({
            type: 'DELETE',   // ✅ Método DELETE para enviar la solicitud de eliminación
            url: url,         // 🔹 URL del endpoint que elimina el registro
            success: function (data) {
                if (data.success) {  // ✅ Si la eliminación es exitosa
                    toastr.success(data.message);  // 🔹 Muestra notificación de éxito con Toastr
                    dataTable.ajax.reload();       // 🔹 Recarga los datos del DataTable
                }
                else {
                    toastr.error(data.message);  // ❌ Muestra notificación de error
                }
            }
        });
    });
}
