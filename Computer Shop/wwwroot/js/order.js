$(document).ready(function () {
    $('#add-btn').click(AddNewOrder)
    LoadOrder();
})



function AddNewOrder() {
    var OrderDate = $('#order-date').val();
    var Quantity = $('#quantity').val();
    var TotalPrice = $('#total-price').val();
    var CustomerId = $('#customerid').val();
    var id = $('#order-id').val();
    

    const order = {
        id: id,
        OrderDate: OrderDate,
        Quantity: Quantity,
        TotalPrice: TotalPrice,
        CustomerId: CustomerId

    };
    $.ajax({
        async: true,
        type: "POST",
        url: "/Order/AddOrder",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(order),
        success: function (response) {
            console.log(response);
            Swal.fire({
                position: "center",
                icon: "success",
                title: "Order added successfully",
                showConfirmButton: false,
                timer: 1500
            }).then(() => {
                window.location.href = "/order/order";
            });
        },
        error: function (xhr, status, error) {
            Swal.fire({
                position: "center",
                icon: "error",
                title: "Error adding order",
                text: xhr.responseText,
                showConfirmButton: true
            });
        }
    });
