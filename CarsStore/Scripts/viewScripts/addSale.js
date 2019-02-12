(function () {
    $(document).ready(function () {
        $('#submit-sale').on('click', submitSale);

      
        
    });

    function submitSale() {
        $('.field-validation-error')
            .empty();

        $('.field-validation-error')
            .addClass('field-validation-valid')
            .removeClass('field-validation-error');


        var name = $('#Sale_CustomerName').val();
        var phone = $('#Sale_Phone').val();
        var email = $('#Sale_Email').val();
        var street1 = $('#Sale_Street1').val();
        var street2 = $('#Sale_Street2').val();
        var city = $('#Sale_City').val();
        var state = $('#Sale_States_StateID :selected').val();
        var zip = $('#Sale_Zip').val();
        var purchasePrice = $('#Sale_PurchasePrice').val();
        var purchaseType = $('#Sale_Purchases_PurchaseTypeID :selected').val();
        var vin = $('#vin').text();
        var carID = $('#Car_CarID').val();

        var Sale = {
            CustomerName: name,
            Phone: phone,
            Email: email,
            Street1: street1,
            Street2: street2,
            City: city,
            StateID: state,
            Zip: zip,
            PurchasePrice: purchasePrice,
            PurchaseTypeID: purchaseType,
            VinID: vin,
            CarID: carID
        };
        $.ajax({
            type: 'POST',
            url: '/Sales/Purchase',
            data: JSON.stringify(Sale),
            dataType: "json",
            contentType: "application/json; charset=utf-8",

            success: function (data) {
                if (!data.success) {

                    $(data.errors).each(function (index,value) {

                        var field = value.Key.charAt(0).toUpperCase() + value.Key.slice(1);
                       
                        $('span[data-valmsg-for="' + field + '"]')
                            .removeClass('field-validation-valid')
                            .addClass('field-validation-error')
                            .text(value.Value);
                    });
                }

                else {
                    alert("successfully purchased car");
                    window.location.replace("/sales/index");
                }
            },

            error: function (error) {
                console.log(error);
            }
        });
    }
})();