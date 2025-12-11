var dataTable;

$(document).ready(function () {
    cargarDatatable();
});
function cargarDatatable() {
    $("#tblMantenimiento").DataTable({
        "ajax": {
            "url": "/admin/Mantenimientos/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "fecha", "width": "15%" },
            { "data": "placa", "width": "10%" },
            { "data": "tipo_mantto", "width": "5%" },
            { "data": "comentario", "width": "30%" },
            { "data": "ruta_evidencias", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="d-flex justify-content-center">
                            <a href="/Admin/Mantenimientos/Edit/${data}" class="btn btn-success text-white">
                                <i class="far fa-edit"></i> Editar
                            </a>
                     
                        </div>`;
                },
                "width": "10%"
            }
        ],
        "language": {
            "decimal": "",
            "emptyTable": "No hay registros",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Esta seguro de borrar?",
        text: "Este contenido no se puede recuperar!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, borrar!",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}
