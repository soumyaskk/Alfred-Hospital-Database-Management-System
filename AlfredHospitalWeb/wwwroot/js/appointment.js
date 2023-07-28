var dataTableApp;

$(document).ready(function ()
{
    loadDataTable();

});

function loadDataTable() {
    dataTableApp = $('#tblData').DataTable(
        {
            
            "ajax": {
                "url": "/Admin/Appointment/GetAll"
            },
            "columns": [
                { "data": "appointmentDate", "width": "10%" },
                { "data": "reason", "width": "10%" },
                { "data": "patient.firstName", "width": "10%" },
                { "data": "patient.lastName", "width": "10%" },
                { "data": "physician.firstName", "width": "10%" },
                { "data": "physician.lastName", "width": "10%" },
                { "data": "receptionist.receptionistCounter", "width": "5%" },
                { "data": "room.roomType", "width": "10%" },
                { "data": "room.status", "width": "5%" },
                {
                    "data": "id",
                    "render": function (data) {
                        return `
                             <div class="w-50 btn-group" role="group">
                            <a href="/Admin/Appointment/InsertUpdate?id=%{data}"
                           class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>
                        </div>
                   
                        `
                    },
                    "width": "10%"

                    }
                // include delete if needed
            ]
        }
    );
}
