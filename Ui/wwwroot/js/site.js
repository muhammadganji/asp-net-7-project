// Write your JavaScript code.

//import { computeStyles } from "@popperjs/core";

//*************** admin menu panel ********************
    //$(".first-li").addClass("openul").children('ul').show();
$(document).ready(function () {

    $(".main-li > a").on('click', function () {
        var getli = $(this).parent('li');
        if (getli.hasClass('openul')) {
            getli.removeClass('openul');
            getli.find('ul').slideUp(200);
        }
        else {
            getli.addClass('openul');
            getli.children('ul').slideDown(200);
        }
    });
})
//*****************************************************

//-----------------slider same product-------
$('.ov1').owlCarousel({
    rtl: true,
    loop: true,
    margin: 10,
    nav: true,
    autoplay: true,
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 3
        },
        1000: {
            items: 3
        }
    }
});




// test data cart------------------------------
// test data cart------------------------------
// test data cart------------------------------
// test data cart------------------------------
// test data cart------------------------------
// test data cart------------------------------
// test data cart------------------------------

// ثبت فاکتور نهایی
/*
function SubmitInvoiceClick(e) {
    debugger
    var list_product = []
    var list_product_id = []
    var list_product_quantity = []

    var list_product_id_temp = $('.product-id')
    var list_product_quantity_temp = $('.product-quantity').children('input');

    for (var i = 0; i < list_product_id_temp.length; i++)
        list_product_id.push(list_product_id_temp[i].value);

    for (var j = 0; j < list_product_quantity_temp.length; j++)
        list_product_quantity.push(list_product_quantity_temp[j].value);

    for (var k = 0; k < list_product_id.length; k++)
        list_product.push(
            {
                IdProduct: list_product_id[k],
                QuantityProduct: list_product_quantity[k]
            }
        )

    var listProduct = JSON.stringify(list_product);
    console.log(listProduct);
    $.ajax(
        {
            contentType: "application/json",
            dataType: 'json',
            type: "POST",
            url: '/Account/GetDataCart',
            data: listProduct,
            success: function (data) {
                console.log(data.message);
            },
            error: function (data) {
                console.log(data.error);
            }
        })
}
*/
async function postData(url = '', data) {
    // Default options are marked with *
    const response = await fetch(url, {
        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data)
    });
    return response.json(); // parses JSON response into native JavaScript objects
}

// دریافت داده از سرور
function getItems(url = '') {
    fetch(url)//baseURL + action
        .then(response => response.json())
        .then(data => console.log(data))
        //.then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}



//-----------------------invoice print -----------
//var doc = new jsPDF();
var specialElementHandlers = {
    //'#editor': function (element, renderer) {
    //    return true;
    //}
};

$('#invoice-print').click(function () {
    //doc.fromHTML($('.shopping-cart').html(), 15, 15, {
    //    'width': 170,
    //    'elementHandlers': specialElementHandlers
    //});
    //doc.save('پیش نویس فاکتور.pdf');


});
$("#invoice-payment-save").click(function () {
    // complate payment------------------
    // complate payment------------------
    // complate payment------------------
    // complate payment------------------
    // complate payment------------------
    // complate payment------------------
    // complate payment------------------
    // complate payment------------------
    // complate payment------------------
    // complate payment------------------
    // complate payment------------------
    // complate payment------------------
    debugger;
    SubmitInvoiceClick()

}
);


$("#invoice-payment-save-Panel").click(function () {
    // use in payment at invoice as USER Panel
    debugger;
    SubmitInvoiceUserPanelClick()
}
);




//--------------GetOTP-------------
var checTwiceRequest = true;
$("#GetOTP").click(function (e) {
    e.preventDefault();
    // prevent two request
    debugger;
    if (checTwiceRequest) {
        checTwiceRequest = false;
    }
    else {
        return;
    }
    $.ajax({
        type: "post",
        dataType: "json",
        //url: "/Account/PostRegisterOTP",
        url: "/user/UserProfile/PostRegisterOTP",
        ////data: { PhoneNumber: $("#UserName")[0].value },
        data: { PhoneNumber: "GoGoli magoli ♥" },
        success: function (data) {
            console.log(data.message);
        },
        error: function (data) {
            console.log(data.error);
        },
    });
    /*
    if (checTwiceRequest) {
        var phonenumber = $("#UserName")[0].value;
        if (phonenumber == null || phonenumber.length != 11) {
            // prevent request

        }
        //var PhoneNumber = phonenumber;// JSON.stringify(phonenumber);

        $.ajax({
            contentType: "application/json",
            type: "POST",
            dataType: "json",
            url: "/Account/PostRegisterOTP",
            data: { PhoneNumber: phonenumber },
            success: function (data) {
                console.log(data.message);
            },
            error: function (data) {
                console.log(data.error);
            }
        });
        //$.ajax(
        //    {
        //        contentType: "application/json",
        //        dataType: 'json',
        //        type: "POST",
        //        url: '/Account/GetRegisterOTP',
        //        data: PhoneNumber,
        //        success: function (data) {
        //            console.log(data.message);
        //        },
        //        error: function (data) {
        //            console.log(data.error);
        //        }
        //    });

        // prevent to twice request
        checTwiceRequest = false;

        // show message
        // Do it
        // Do it
        // Do it
    }

    */
});



