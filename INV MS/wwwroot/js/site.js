// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
////Account Code Start
//Submit the Form
$('#save').click(function () {
    var AccountHeadName = $('.acchl').val();
    var AccountCode = $('.accc').val();
    var AccountTitle = $('.acct').val();
    var PhoneNo = $('.pn').val();
    var MobileNo = $('.mn').val();
    var Email = $('.em').val();
    var Address = $('.add').val();

    $.ajax({
        url: "/Accounts/Create",
        type: "POST",
        dataType: 'json',
        data: {
            "accountHeadId": AccountHeadName,
            "accountCode": AccountCode,
            "accountTitle": AccountTitle,
            "PhoneNo": PhoneNo,
            "MobileNo": MobileNo,
            "Email": Email,
            "Address": Address
        }, success: function (output) {


            $("#table_id").load(window.location.href + " #tableid");
            //location.reload();

        },
        error: function () {
            alert("Result is = " + data);

        }

    });

});
//Toggle Account Detail Form
function ShowAccDetail() {
    $('#content').toggle('show');

}
function refresh() {
    Location.refresh();
}


function deletes(Id) {
    $.ajax({
        type: "POST",
        url: "/Accounts/Delete/?" + Id,
        dataType: "json",
        data: { Id: Id },
        success: (function (res) {
            alert("hy=" + data);

        }),
        error: (function () { alert("Error") })
    });
}



////Account Code End


///Item Code  START




$("#addcat").click(function () {
    $("#categoryModal").modal('show');

});
$(".addUnit").on("click", function () {
    $("#unitModal").modal('show');


});

$("#addCategory").click(function (e) {
    e.preventDefault();
    e.stopImmediatePropagation();
    let catName = $("#categoryName").val();
    let Description = $("#catDescription").val();
    var postData = { catName: catName, catDescription: Description };
    $.ajax({
        type: "POST",
        url: "/Item/createCategory",
        data: postData,
        success: function (result) {
            
            if (result != "Category Saved Successfully") {
                $('#categoryName').val('');
                $('#Description').val('');
                $('#catValidation').html(result);

            }
            else {
                $("#categoryModal").modal('hide');
               
            }
        },
        error: function () {
            alert("Error");
        }

    });
});
$("#addUnit").click(function (e) {
    e.preventDefault();
    e.stopImmediatePropagation();
    let UnitName = $("#UnitName").val();
    
   
    var postData = { unitName: UnitName };
    $.ajax({
        type: "POST",
        url: "/Item/createUnit",
        data: postData,
        success: function (result) {
           
            if (result != "Unit Saved Successfully") {
                $('#UnitName').val('');
             
                $('#unitValidation').html(result);

            }
            else {
                $("#unitModal").modal('hide');
               
            }
        },
        error: function () {
            alert("Error");
        }

    });
});


$("#Refresh").click(function () {
    window.location.reload();
});
///Item Code END













// Write your JavaScript code.

$('#save').click(function (e) {
    e.preventDefault();
    e.stopImmediatePropagation();
    var Category = $('.cat').val();
    var itmcode = $('.itmcode').val();
    var itemName = $('.itemName').val();
    var unit = $('.unit').val();
    var Description = $('.Description').val();
    var purchase_Price = $('.purchase_Price').val();
    var sale_Price = $('.sale_Price').val();

    $.ajax({
        url: "/Item/Item",
        type: "POST",
        dataType: 'json',
        data: {
            "catId": Category,
            "ItemCode": itmcode,
            "itemName": itemName,
            "UnitId": unit,
            "Description": Description,
            "purchase_Price": purchase_Price,
            "sale_Price": sale_Price
        }, success: function (output) {


            alert("Saved Successfully");
            window.location.reload();

        },
        error: function (output) {
            alert("Result is = " + output);

        }

    });

});




