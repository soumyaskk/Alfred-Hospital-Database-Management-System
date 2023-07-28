var dataTableRoom;

$(document).ready(function ()
{
    loadDataTable();

});

function loadDataTable() {
    dataTableRoom = $('#tblDataRoom').DataTable(
        {
            
            "ajax": {
                "url": "/Admin/Room/GetAll"
            },
            "columns": [
                { "data": "roomType", "width": "10%" },
                { "data": "capacity", "width": "10%" },
                { "data": "status", "width": "10%" },
                { "data": "nurse.firstName", "width": "10%" },
                { "data": "nurse.lastName", "width": "10%" },
                { "data": "nurse.role", "width": "10%" },
               

            ]
        }
    );
}