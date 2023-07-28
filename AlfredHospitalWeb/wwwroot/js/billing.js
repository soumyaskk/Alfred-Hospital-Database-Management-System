var dataTableBilling;

$(document).ready(function ()
{
    loadDataTable();

});

function loadDataTable() {
    dataTableBilling = $('#tblDataBilling').DataTable(
        {
            
            "ajax": {
                "url": "/Admin/Billing/GetAll"
            },
            "columns": [
                { "data": "billingCounter", "width": "10%" },
                { "data": "firstName", "width": "10%" },
                { "data": "lastName", "width": "10%" },
                { "data": "billingDate", "width": "10%" },
                { "data": "billingAmount", "width": "10%" },
                { "data": "patient.firstName", "width": "10%" },
                { "data": "patient.lastName", "width": "10%" },


            ]
        }
    );
}