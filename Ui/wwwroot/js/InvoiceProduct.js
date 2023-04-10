//const { Alert } = require("../lib/bootstrap/dist/js/bootstrap");
//const { Alert } = require("../lib/bootstrap/dist/js/bootstrap");

$(document).ready(function () {

    /* Set rates + misc */
    var taxRate = 0;
    var shippingRate = 0;
    var fadeTime = 50;


    /* Assign actions */
    $('.product-quantity input').change(function () {
        updateQuantity(this);
    });

    $('.product-removal button').click(function () {
        removeItem(this);
    });


    /* Recalculate cart */
    function recalculateCart() {
        var subtotal = 0;

        /* Sum up row totals */
        $('.product').each(function () {
            subtotal += parseFloat($(this).children('.product-line-price').text());
        });

        /* Calculate totals */
        var tax = subtotal * taxRate;
        var shipping = (subtotal > 0 ? shippingRate : 0);
        var total = subtotal + tax + shipping;

        /* Update totals display */
        $('.totals-value').fadeOut(fadeTime, function () {
            $('#cart-subtotal').html(subtotal.toFixed(0));
            $('#cart-tax').html(tax.toFixed(0));
            $('#cart-shipping').html(shipping.toFixed(0));
            $('#cart-total').html(total.toFixed(0));
            if (total == 0) {
                $('.checkout').fadeOut(fadeTime);
            } else {
                $('.checkout').fadeIn(fadeTime);
            }
            $('.totals-value').fadeIn(fadeTime);
        });
    }


    /* Update quantity */
    function updateQuantity(quantityInput) {
        /* Calculate line price */
        var productRow = $(quantityInput).parent().parent();
        var price = parseFloat(productRow.children('.product-price').text());
        var quantity = $(quantityInput).val();
        var linePrice = price * quantity;

        /* Update line price display and recalc cart totals */
        productRow.children('.product-line-price').each(function () {
            $(this).fadeOut(fadeTime, function () {
                $(this).text(linePrice.toFixed(0));
                recalculateCart();
                $(this).fadeIn(fadeTime);
            });
        });
    }


    /* Remove item from cart */
    function removeItem(removeButton) {
        /* Remove row from DOM and recalc cart total */
        var productRow = $(removeButton).parent().parent();
        productRow.slideUp(fadeTime, function () {
            productRow.remove();
            recalculateCart();
        });
    }

});


//-----------------send data ---------------------
//-----------------send data ---------------------
//-----------------send data ---------------------
//-----------------send data ---------------------


// ارسال به سرور برای ثبت سفارش و درگاه پرداخت
function SubmitInvoiceClick(e) {
    // 1. send data for save and Get response(IdOrder)
    // 2. View Payment by 'IdOrder'
    debugger;
    var products = []
    var list_product_id = []
    var list_product_quantity = []

    var list_product_id_temp = $('.product-id')
    var list_product_quantity_temp = $('.product-quantity').children('input');

    for (var i = 0; i < list_product_id_temp.length; i++)
        list_product_id.push(Number(list_product_id_temp[i].value));

    for (var j = 0; j < list_product_quantity_temp.length; j++)
        list_product_quantity.push(Number(list_product_quantity_temp[j].value));

    for (var k = 0; k < list_product_id.length; k++)
        products.push(
            {
                Id: list_product_id[k],
                Quantity: list_product_quantity[k]
            }
        )

    //var products = [
    //    { IdProduct: 111, CountOfProduct: 1 },
    //    { IdProduct: 222, CountOfProduct: 2 },
    //    { IdProduct: 333, CountOfProduct: 3 },
    //];
    var listProduct = JSON.stringify(products);
    console.log(listProduct);
    debugger;
    
    $.ajax(
        {
            contentType: "application/json",
            dataType: 'json',
            type: "POST",
            url: '/Payment/GetDataCart',
            data: listProduct,
            success: function (data) {
                //debugger;

                if (!data.success) {
                    // error acurre
                    window.alert(data.message)
                    //console.log(data);
                    //if ($("#errorInvoice").hasClass("close")) {
                    //    $("#errorInvoice").removeClass("close");
                    //    $("#errorInvoice").addClass("show");
                    //    $("#errorInvoiceMessage").text(data.message);
                    //}


                }
                else {
                    // successfully pass
                    //if ($("#errorInvoice").hasClass("show")) {
                    //    $("#errorInvoice").removeClass("show");
                    //    $("#errorInvoice").addClass("close");
                    //}

                    var url = '/Payment/Payment/' + data.idOrder;
                    //window.alert(window.location.host + url);
                    window.location.href = window.location.origin + url;
                }


                // go to View Payment by IdOrder


                //window.alert("successfully change view?");

            },
            error: function (data) {
                debugger;
                window.alert("Error accurre")
                console.log("error accure");
            }
        });
}


// درخواست چک کردن فاکتور و موجودی کالا
// در لحظه که آماده ارسال به صفحه پرداخت شود
function SubmitInvoiceUserPanelClick(e) {

    debugger;
    var IdOrder = $("#IdOrderUserPanel").val();
    $.ajax(
        {
            contentType: "application/json",
            dataType: 'json',
            type: "POST",
            //url: '/Product/GetDataCart',
            url: '/Payment/CheckStockOfInvice/' + IdOrder,
            data: IdOrder,
            success: function (data) {
                //debugger;
                
                if (!data.success) {
                    // error acurre
                    window.alert("error accurre" + data.message)
                    //console.log(data);
                    if ($("#errorInvoiceUserPanel").hasClass("close")) {
                        $("#errorInvoiceUserPanel").removeClass("close");
                        $("#errorInvoiceUserPanel").addClass("show");
                        $("#errorInvoiceUserPanelMessage").text(data.message);
                    }


                }
                else {
                    // successfully pass
                    if ($("#errorInvoiceUserPanel").hasClass("show")) {
                        $("#errorInvoiceUserPanel").removeClass("show");
                        $("#errorInvoiceUserPanel").addClass("close");
                    }

                    var url = '/Payment/Payment/' + IdOrder;
                    //window.alert(window.location.host + url);
                    window.location.href = window.location.origin + url;
                }


                // go to View Payment by IdOrder


                //window.alert("successfully change view?");

            },
            error: function (data) {
                debugger;
                window.alert("Error accurre")
                console.log("error accure");
            }
        });
}


//-----------------send data ---------------------
//-----------------send data ---------------------
//-----------------send data ---------------------



//         Invoice
function updateTotal() {

    var price = document.getElementsByClassName('price')
    var count = document.getElementsByClassName('quantity');
    //var result = document.getElementsByTagName('h4')
    var result = document.getElementsByClassName('result-total-price')
    // price
    var total = 0;
    for (var i = 0; i < price.length; i++)
        total = ((price[i].value * 1) * (count[i].value) * 1) + total;
    result[0].innerText = total; // جمع کل
    result[1].innerText = total // قابل پرداخت
}


function textQuantitychange() {
    debugger;
    // change input of quantity of invoice,
    // it will be change the Total Price
    updateTotal()
}

