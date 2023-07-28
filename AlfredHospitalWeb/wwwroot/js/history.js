var dataTableHistory;

$(document).ready(function ()
{
    loadDataTable();

});

function loadDataTable() {
    dataTableHistory = $('#tblDataHistory').DataTable(
        {
            
            "ajax": {
                "url": "/Admin/History/GetAll"
            },
            "columns": [
                { "data": "patient.id", "width": "10%" },
                { "data": "patient.firstName", "width": "10%" },
                { "data": "patient.lastName", "width": "10%" },
                { "data": "physician.firstName", "width": "10%" },
                { "data": "physician.lastName", "width": "10%" },
                { "data": "appointment.reason", "width": "5%" },
                { "data": "treatment", "width": "10%" },
                { "data": "appointment.appointmentDate", "width": "5%" },
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
                
            ]
        }
    );
}
