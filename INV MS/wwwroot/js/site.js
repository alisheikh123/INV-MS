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
        error: function (output) {
            alert("Result is = " + output);

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



////Account Code Endsave


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


$("#AddCompany").click(function (e) {
    e.preventDefault();
    e.stopImmediatePropagation();
    let CompanyNm = $("#CompanyNm").val();
    let CompanyCode = $("#CompanyCode").val();

    var postData = { Name: CompanyNm, CompanyrCode: CompanyCode, Email: "jshu@gmail.com", Contact: "98867689", Address: "ghqgtygq" };
    $.ajax({
        type: "POST",
        url: "/tblCompanies/CreateCompany",
        data: postData,
        success: function (result) {

            if (result != "Company Record Successfully Added!") {
                $('#CompanyNm').val('');
                $('#CompanyCode').val('');
                $('#compcodeValidation').html(result);

            }
            else {
                $("#categoryModal").modal('hide');
                window.location.reload();
            }
        },
        error: function () {
            alert("Error");
        }

    });
});


if ($("#log").length) {
    $(".TotalAmount").keyup(function () {
        $.subtract();
    });
    $(".PaidAmount").keyup(function () {
        $.subtract();
    });
}
$.subtract = function () {
    $(".RemainingAmount").val(parseInt($(".TotalAmount").val()) - parseInt($(".PaidAmount").val()));
}
//$(".comp").select2();









// Save Item Detail

$('#saveItems').click(function (e) {
    e.preventDefault();
    e.stopImmediatePropagation();
    var Category = $('.cat').val();
    var itmcode = $('.itmcode').val();
    var itemName = $('.itemName').val();
    var unit = $('.unit').val();
    var Description = $('.Description').val();
    var purchase_Price = $('.purchase_Price').val();
    var sale_Price = $('.sale_Price').val();

    if (Category == 0 || ItemCode == "" || itemName == "" || unit == 0
        || purchase_Price == "" || purchase_Price == 0.0 || purchase_Price == 0 ||
        sale_Price == "" || sale_Price == 0.0 || sale_Price == 0
    ) {
        //alert("Something is Missing in Input Box!");
        toastr.error('Something is Missing in Input Box!')
    }
    else {
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

                if (output != "Record is Saved Successfully") {

                    $("#itemcodeValidation").html(output);
                }
                else {
                    toastr.success(output);

                    window.location.reload();
                }
            },
            error: function (output) {

                toastr.error(output)
            }

        });
    }
});


//Delete the Item

function deleteItem(id) {
    if (id != null || id != 0 || id == 0 || id == "") {


        $.ajax({
            url: "/Item/Delete",
            type: "POST",
            dataType: 'json',
            data: {
                "id": id,

            }, success: function (output) {
                toastr.success(output);
                location.reload();


            },
            error: function (output) {

                toastr.error(output)
            }

        });
    }
    else {
        toastr.success(id);
    }
}



$('#savecompDetail').click(function (e) {
    e.preventDefault();
    e.stopImmediatePropagation();
    var comp = $('.comp').val();
    var ProductName = $('.ProductName').val();
    var Description = $('.Description').val();
    var PhoneNo = $('.PhoneNo').val();
    var TotalAmount = $('.TotalAmount').val();
    var PaidAmount = $('.PaidAmount').val();
    var RemainingAmount = $('.RemainingAmount').val();
    var dateoforder = $('.dateoforder').val();
    var dateofpayment = $('.dateofpayment').val();
    var dateofremainpayment = $('.dateofremainpayment').val();
  //  var dateofArrival = $('.dateofArrival').val();

    if (comp == 0 || ProductName == ""  || TotalAmount == 0
        || TotalAmount == 0.0 || PaidAmount == 0.0 || PaidAmount == 0 
        || dateoforder == "mm/dd/yyyy" || dateofpayment == "mm/dd/yyyy") {
        //alert("Something is Missing in Input Box!");
        toastr.error('Something is Missing in Input Box!');
    }
    else {
        var postData = {
            companyId: comp,
            ProductName: ProductName,
            Description: Description,
            PhoneNo: PhoneNo,
            TotalAmount: TotalAmount,
            PaidAmount: PaidAmount,
            RemainingAmount: RemainingAmount,
            dateoforder: dateoforder,
            dateofpayment: dateofpayment,
            dateofremainpayment: dateofremainpayment,
          

        };
        $.ajax({
            url: "/tblCompanyDetails/CompDetailCreate",
            type: "POST",
            dataType: 'json',
            data: postData,
            success: function (output) {

                if (output != "Record Successfully Saved!") {

                    $("#PhoneNoValidation").html(output);
                }
                else {
                    toastr.success(output);

                    window.location.reload();
                }
            },
            error: function (output) {

                toastr.error(output)
            }

        });
    }
});




