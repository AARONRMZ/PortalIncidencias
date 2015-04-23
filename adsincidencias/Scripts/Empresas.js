
var jquery = jQuery.noConflict();
jquery(document).ready(function () {
    jquery('#dataTableEmpresas').dataTable({
        "bServerSide": true,
        "sAjaxSource": "DataTableEmpresas",
        "bProcessing": true,
        "aoColumns": [{
            "sName": "empID",
            "bSearchable": false,
            "bSortable": false,
            "mRender": function (data) {
                return '<a href="/Empresas/Editar/?IdEmpresa=' + data + '">Editar</a>';
            }
        },
        { "sName": "empNombre"}

        ]
    });
});