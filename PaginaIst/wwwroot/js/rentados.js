// ✅ DataTable específico para Rentados (para no pisar otros datatables)
window.dataTableRentados = null;

// ✅ Función global para el onclick del botón verde
window.exportarExcelDT = function (e) {
    if (e) {
        e.preventDefault();
        e.stopPropagation();
    }

    if (!window.dataTableRentados) {
        console.warn("DataTable Rentados aún no está inicializado");
        return;
    }

    // ✅ dispara el botón excel real de DataTables
    window.dataTableRentados.button(".buttons-excel").trigger();
};

$(document).ready(function () {
    cargarDatatableRentados();
});

function cargarDatatableRentados() {
    window.dataTableRentados = $("#tblRentado").DataTable({
        ajax: {
            url: "/Admin/Rentados/GetAll",
            type: "GET",
            datatype: "json",
            // Si tu endpoint devuelve un array puro: [...]
            // dataSrc: ""
        },
        columns: [
            { data: "id", width: "5%" },
            { data: "fecha", width: "15%" },
            { data: "placa", width: "10%" },
            { data: "tipo_mantto", width: "5%" },
            { data: "comentario", width: "30%" },
            { data: "ruta_evidencias", width: "20%" },
            {
                data: "id",
                render: function (data) {
                    // ✅ usa la misma variable que defines en el Index
                    if (!window.canEditRentados) return "";
                    return `
                        <div class="d-flex justify-content-center">
                            <a href="/Admin/Rentados/Edit/${data}" class="btn btn-success text-white">
                                <i class="far fa-edit"></i> Editar
                            </a>
                        </div>`;
                },
                width: "10%"
            }
        ],

        dom: "Bfrtip",
        buttons: [
            {
                extend: "excelHtml5",
                text: "EXPORTAR A EXCEL",
                title: "Mantenimientos_Rentados",
                filename: "Mantenimientos_Rentados",
                exportOptions: { columns: [0, 1, 2, 3, 4, 5] }
            }
        ],

        initComplete: function () {
            // ✅ oculta el botón “transparente” original (pero el excel sigue existiendo)
            $(".dt-buttons").hide();
        },

        language: {
            decimal: "",
            emptyTable: "No hay registros",
            info: "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            infoEmpty: "Mostrando 0 to 0 of 0 Entradas",
            infoFiltered: "(Filtrado de _MAX_ total entradas)",
            lengthMenu: "Mostrar _MENU_ Entradas",
            loadingRecords: "Cargando...",
            processing: "Procesando...",
            search: "Buscar:",
            zeroRecords: "Sin resultados encontrados",
            paginate: {
                first: "Primero",
                last: "Ultimo",
                next: "Siguiente",
                previous: "Anterior"
            }
        },

        width: "100%"
    });
}
