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
















// Write your JavaScript code.

$('#save').click(function () {
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

            alert(output);
           
           

        },
        error: function (output) {
            alert("Result is = " + output);

        }

    });

});




