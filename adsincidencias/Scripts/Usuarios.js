
var jquey = jQuery.noConflict();
    jquey(document).ready(function () {
        jquey('#dataTableUsuarios').dataTable({
            "bServerSide": true,
            "sAjaxSource": "RegUsuarios/DataTableUsuarios",
            "bProcessing": true,
            "aoColumns": [{
                "sName": "Id",
                "bSearchable": false,
                "bSortable": false,
                "mRender": function (data) {
                    return '<a href="/RegUsuarios/EditarUsuarios/?IdUsuario='+data+'">Editar</a>';
                }
            },
            { "sName": "usrNombre" },
            { "sName": "usrNombreUsusario" },
            { "sName": "usrCorreo" },
            { "sName": "usrRol" },
            { "sName": "usrEmpresaID" }
            

            ]
        });
    });

