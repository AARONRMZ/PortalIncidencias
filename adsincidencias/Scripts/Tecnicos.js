var jquey = jQuery.noConflict();
jquey(document).ready(function () {
    jquey('#dataTableTecnicos').dataTable({
        "bServerSide": true,
        "sAjaxSource": "DataTableTecnicos",
        "bProcessing": true,
        "aoColumns": [{
            "sName": "tecID",
            "bSearchable": false,
            "bSortable": false,
            "mRender": function (data) {
                return '<a href="/Tecnicos/Editar/?IdTecnico=' + data + '">Editar</a>';
            }
        },
        { "sName": "tecNombre" },
        { "sName": "tecNombreUsusario" },
        { "sName": "tecCorreo" },
        { "sName": "tipoProdDescripcion" }


        ]
    });
});