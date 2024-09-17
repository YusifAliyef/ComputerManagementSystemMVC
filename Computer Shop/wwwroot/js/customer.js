$(document).ready(function () {
    $('#add-btn').click(AddNewCustomer)
    LoadBook();
})



function AddNewCustomer() {
    var FirstName = $('#first-name').val();
    var LastName = $('#last-name').val();
    var Email = $('#email').val();
    var Phone = $('#phone').val();
    var Address = $('#address').val();

    const customer = {
        id: id,
        FirstName: FirstName,
        LastName: LastName,
        Email: Email,
        Phone: Phone,
        Address: Address

    };
    $.ajax({
        async: true,
        type: "POST",
        url: "/Customer/AddCustomer", 
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(customer),
        success: function (response) {
            console.log(response);
            Swal.fire({
                position: "center",
                icon: "success",
                title: "Customer added successfully",
                showConfirmButton: false,
                timer: 1500
            }).then(() => {
                window.location.href = "/customer/customer"; 
            });
        },
        error: function (xhr, status, error) {
            Swal.fire({
                position: "center",
                icon: "error",
                title: "Error adding customer",
                text: xhr.responseText,
                showConfirmButton: true
            });
        }
    });
