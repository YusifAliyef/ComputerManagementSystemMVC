$(document).ready(function () {
    LoadComputer();



});
function LoadComputer() {

    $("#comp-data").dataTable({
        autoWidth: false,
        pageLength: 5,
        lengthMenu: [[5], [10], [15]],
        ajax: {
            url: "/Computer/Computer/AddComputer",
            dataSrc: ""
        },
        columns: [
            { data: 'id' },
            { data: 'name' },
            { data: 'brand' },
            { data: 'inStock' },
            { data: 'price' },
            { data: 'processor' },
            { data: 'storageType' },
            { data: 'categoryId' }
             { data: 'ram' }
              { data: 'storage' }
               { data: 'screensize' }


        ]
    })
}