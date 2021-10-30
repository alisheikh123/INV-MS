
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
    let Email = $("#Email").val();
    let Contact = $("#Contact").val();
    let Address = $("#Address").val();

    var postData = { Name: CompanyNm, CompanyrCode: CompanyCode, Email: Email, Contact: Contact, Address: Address };
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


//if ($("#payForm").length) {
//    debugger;
//    $(".TotalAmount").keyup(function () {
//        $.subtract();
//    });
//    $(".PaidAmount").keyup(function () {

//        $.subtract();
//    });
//}
$(".PaidAmount").keyup(function () {
   
    $.subtract();
});
$.subtract = function () {
    /*alert(parseInt($(".PaidAmount").val()));*/
    $(".RemainingAmount").val(parseInt($("#totalAmount").text()) - parseInt($("#totalamountReceived").val()) - parseInt($(".PaidAmount").val()));
}
$('.comp').select2();
$('.veh').select2();
$('.driv').select2();
$('.productNm').select2();








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
    let PhoneNo = $('.PhoneNo').val();
    var TotalAmount = $('.TotalAmount').val();
    var dateoforder = $('.dateoforder').val();
    var dateofpayment = $('.dateofpayment').val();
    var url = $("#RedirectTo").val();

    if (comp == 0) {

        toastr.error('* Please select the company name !');
    }
    else if (ProductName == "") {
        toastr.error('* Please add the Product Name !');
    }
    else if (TotalAmount == 0 || TotalAmount == 0.0) {
        toastr.error('* Please add the Total Amount !');
    }
    else if (dateoforder == null || dateoforder == "") {
        toastr.error('* Please add the the date of Order!');
    }
    else if (dateofpayment == null || dateofpayment == "") {
        toastr.error('* Please add the Date of Payment !');
    }

    else {
        var postData = {
            companyId: comp,
            ProductName: ProductName,
            Description: Description,
            PhoneNo: PhoneNo,
            TotalAmount: TotalAmount,
            dateoforder: dateoforder,
            dateofpayment: dateofpayment,


        };
        $.ajax({
            url: "/CompanyDetails/CompDetailCreate",
            type: "POST",
            dataType: 'json',
            data: postData,
            success: function (output) {

                if (output != "Record Successfully Saved!") {

                    $("#PhoneNoValidation").html(output);
                }
                else {
                    toastr.success(output);
                    location.href = url;
                }
            },
            error: function (output) {

                toastr.error(output)
            }

        });
    }
});


//Drodown Selection of Payable and Receivable in CompanyDetails
$("[name='selection']").change(function () {
    debugger;
    //var result = "";
    $("#tableid").val("");
    var selectionsvalue = $("#selectType option:selected").attr('value');
    $.ajax({

        method: "GET",
        url: "/CompanyDetails/Lists",
        data: { values: selectionsvalue },
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            
            debugger;
            //$.each(response[], function (index, value) {
               
            //    result +=
            //       // '<b>Company ID : </b>' + Index.companyId + '<br/>' +
            //        '<b> ProductName :</b>' + value + '<br/>' +
            //        '<b> TotalAmount :</lb>' + value.TotalAmount + '<br/>' +
            //        '<b> PaidAmount :</b>' + value.PaidAmount + '<hr/>';
            //        '<b> Remaining Amount :</b>' + value.RemainingAmount + '<hr/>';
            //        '<b> Date of Order :</b>' + value.dateoforder + '<hr/>';
            //    '<b> Date of Payment :</b>' + value.dateofpayment + '<hr/>';


            //});
            for (var i in response) {
                console.log(response[i].value);
            }
            $("#tableid tbody").html(response)
            $("#results").append(response);
            console.log(response);
        },
        error: function (response) {
            alert("Error");
        }

    });
});



$('#payForm').submit((e)=>{
    e.preventDefault();
    e.stopImmediatePropagation();
    debugger;
    var CompDetailId = $(".compId").text();
    var CompanyName = $("#companyName").text();
    var ProductName = $("#productName").text();
    var Description = $("#description").val();
    let PhoneNo = $("#phone").val();
    var TotalAmount = $("#totalAmount").text();
    let PaidAmount = $("#paidAmount").val();
    var RemaingBalance = $("#remaingBalance").val();
    var totalAmountReceived = $("#totalamountReceived").val();
    var DateofOrder = $("#dateofOrder").text();
    var DateRemaingPayment = $("#dateremaingPayment").val();
    var DateOfPayment = $("#dateofPayment").text();
    var url = $("#RedirectTo").val();
   
    


  
        var paymentData = {
            companyDetailId: CompDetailId,
            companyName: CompanyName,
            ProductName: ProductName,
            description: Description,
            PhoneNo: PhoneNo,
            TotalAmount: TotalAmount,
            dateoforder: DateofOrder,
            dateofpayment: DateOfPayment,
            PaidAmount: PaidAmount,
            RemainingAmount: RemaingBalance,
            TotalAmountReceived: totalAmountReceived,
            dateofremainpayment: DateRemaingPayment,
           


        };
        $.ajax({
            url: "/CompanyDetails/PaymentDetail",
            type: "POST",
            dataType: 'json',
            data: paymentData,
            success: (output) => {
                alert(output);
              
                location.href = url;
            },
            error: function (output) {

                toastr.error(output)
            }

        });
    
});



$('#savetransportDetail').click(function (e) {
    e.preventDefault();
    e.stopImmediatePropagation();

    debugger;
    var comp = $('.comp').val();
    var vehic = $('.veh').val();
    var drver = $('.driv').val();
    var productNm = $('.productNm').val();
    var fromLoc = $('.fromLocation').val();
    let toLoc = $('.toLocation').val();
    var TotalAmount = $('.TotalAmount').val();
    var dateofdispatch = $('.dateofdispatch').val();
    var dateofdelivery = $('.dateofdelivery').val();
    var brokerName = $('.brokerNm').val();
    var dateofpayment = $('.dateofpayment').val();
    var url = $("#RedirectTo").val();

    if (comp == 0) {

        toastr.error('* Please select the company name !');
    }
    if (productNm == 0) {

        toastr.error('* Please select the productName !');
    }
    if (vehic == 0) {

        toastr.error('* Please select the Vehicle No !');
    }
    if (drver == 0) {

        toastr.error('* Please select the Driver name !');
    }
    
    else if (TotalAmount == 0 || TotalAmount == 0.0) {
        toastr.error('* Please add the Total Amount !');
    }
  
    else if (dateofpayment == null || dateofpayment == "") {
        toastr.error('* Please add the Date of Payment !');
    }

    else {
        var postData = {
            companyId: comp,
            vehicleId: vehic,
            driverId: drver,
            productId: productNm,
            FromLocation: fromLoc,
            ToLocation: toLoc,
            TotalAmount: TotalAmount,
            dispatchDate: dateofdispatch,
            deliveryDate: dateofdelivery,
            BrokerName: brokerName,
            DateofPayment: dateofpayment,


        };
        $.ajax({
            url: "/TransportDetail/TransDetailCreate",
            type: "POST",
            dataType: 'json',
            data: postData,
            success: function (output) {

       
                    toastr.success(output);
                    /*location.href = url;*/
                
            },
            error: function (output) {

                toastr.error(output)
            }

        });
    }
});




/* Transport Payment Form Submission*/

$('#TranspayForm').submit((e) => {
    e.preventDefault();
    e.stopImmediatePropagation();
    debugger;
    var TranspDetailId = $(".transportId").text();
    var CompanyName = $("#companyName").text();
    var ProductName = $("#productName").text();
    var TotalAmount = $("#totalAmount").text();
    var Dateofdispatch = $("#dateofdispatch").text();
    let DeliveryDate = $("#deliveryDate").text();
    let BrokerName = $("#brokerName").text();
    let DateofPayment = $("#dateofPayment").text();
    let DriverNm = $("#driverNm").text();
    let VehicleNo = $("#vehicleNo").text();
    var totalAmountReceived = $("#totalamountReceived").val();
    let PaidAmount = $("#paidAmount").val();
    var RemaingBalance = $("#remaingBalance").val();
    var DateRemaingPayment = $("#dateremaingPayment").val();
    var description = $("#description").val();
   
    var url = $("#RedirectTo").val();





    var paymentData = {
        TranspDetailId: TranspDetailId,
        companyName: CompanyName,
        ProductName: ProductName,
        TotalAmount: TotalAmount,
        Dateofdispatch: Dateofdispatch,
        DeliveryDate: DeliveryDate,
        BrokerName: BrokerName,
        dateofpayment: DateofPayment,
        DriverName: DriverNm,
        VehicleNo: VehicleNo,
        TotalAmountReceived: totalAmountReceived,
        PaidAmount: PaidAmount,
        RemainingAmount: RemaingBalance,
        dateofremainpayment: DateRemaingPayment,
        description: description
    };
    $.ajax({
        url: "/TransportDetail/TranspPaymentDetail",
        type: "POST",
        dataType: 'json',
        data: paymentData,
        success: (output) => {
            alert(output);

            location.href = url;
        },
        error: function (output) {

            toastr.error(output)
        }

    });

});




$('#ExpensepayForm').submit((e) => {
    //alert("hy");
    e.preventDefault();
    e.stopImmediatePropagation();
    debugger;
    var transportId = $(".TransportId").text();
    var VehicleNo = $("#VehicleNo").text();
    var driverNm = $("#driverNm").text();
    var TotalAmount = $("#totalAmount").text();
    var deliverydate = $("#deliverydate").text();
    var dispatchDate = $("#dispatchDate").text();
    var totalProfit = $("#totalProfit").val();
    let fuel = $("#fuel").val();
    let Maintenance = $("#Maintenance").val();
    let Commission = $("#Commisscost").val();
    let Description = $("#description").val();
    let Challan = $("#Challan").val();
    let driverFoodCost = $("#driverFoodCost").val();
    let tooltaxcost = $("#tooltaxcost").val();
 

    var url = $("#RedirectTo").val();



    var expenseData = {
        TransportId: transportId,
        vehicleNo: VehicleNo,
        driverName: driverNm,
        TotalAmount: TotalAmount,
        CommissionAmount: Commission,
        Description: Description,
        DispatchDate: dispatchDate,
        Deliverydate: deliverydate,
        TotalProfit: totalProfit,
        FuelAmount: fuel,
        MaintenanceAmount: Maintenance,
        ChallanAmount: Challan,
        DriverFoodAmount: driverFoodCost,
        ToolTaxAmount: tooltaxcost
      
    };
    $.ajax({
        url: "/TransportDetail/ExpenseDetail",
        type: "POST",
        dataType: 'json',
        data: expenseData,
        success: (output) => {
            alert(output);

            location.href = url;
        },
        error: function (output) {

            toastr.error(output)
        }

    });

});
