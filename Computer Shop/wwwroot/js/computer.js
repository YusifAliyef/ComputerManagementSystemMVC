$(document).ready(function () {
    $('#add-btn').click(AddNewComputer)
    LoadComputer();
})



function AddNewComputer() {
    var Name = $('#name').val();
    var Brand = $('#brand').val();
    var InStock = $('#instock').val();
    var Price = $('#price').val();
    var Processor = $('#processor').val();
    var StorageType = $('#storageType').val();
    var CategoryId = $('#categoryId').val();
    var Ram = $('#ram').val();
    var Storage = $('#storage').val();
    var ScreenSize = $('#screensize').val();

    const computer = {

        id: id,
        Name: Name,
        Brand: Brand,
        InStock: InStock,
        Price: Price,
        Processor: Processor,
        StorageType: StorageType
        CategoryId: CategoryId,
        Ram: Ram,
        Storage: Storage,
        ScreenSize: ScreenSize

    };
    $.ajax({
        async: true,
        type: "POST",
        url: "/Computer/AddComputer",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(customer),
        success: function (response) {
            console.log(response);
            Swal.fire({
                position: "center",
                icon: "success",
                title: "Computer added successfully",
                showConfirmButton: false,
                timer: 1500
            }).then(() => {
                window.location.href = "/computer/computer";
            });
        },
        error: function (xhr, status, error) {
            Swal.fire({
                position: "center",
                icon: "error",
                title: "Error adding computer",
                text: xhr.responseText,
                showConfirmButton: true
            });
        }
    });
