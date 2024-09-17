$(document).ready(function () {
    LoadOrder();



});
function LoadOrder() {

    $("#order-data").dataTable({
        autoWidth: false,
        pageLength: 5,
        lengthMenu: [[5], [10], [15]],
        ajax: {
            url: "/Order/Order/AddOrder",
            dataSrc: ""
        },
        columns: [
            { data: 'id' },
            { data: 'order-date' },
            { data: 'quantity' },
            { data: 'total-price' },
            { data: 'customerid' },
      


        ]
    })
}