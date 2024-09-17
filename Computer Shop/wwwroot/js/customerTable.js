$(document).ready(function () {
    LoadCustomer();



});
function LoadCustomer() {

    $("#customerdata").dataTable({
        autoWidth: false,
        pageLength: 5,
        lengthMenu: [[5], [10], [15]],
        ajax: {
            url: "/Customer/Customer/AddCustomer",
            dataSrc: ""
        },
        columns: [
            { data: 'Id' },
            { data: 'FirstName' },
            { data: 'LastName' },
            { data: 'Email' },
            { data: 'Phone' },
            { data: 'Address' }


        ]
    })
}