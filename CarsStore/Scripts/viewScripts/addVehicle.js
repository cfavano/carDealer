(function () {

    $(document).ready(function () {
        $('#Car_Models_MakeID').on('change', getModels);
        $('#submit-car').on('click', submitCar);
 
    });

    function getModels() {
        var id = $('#Car_Models_MakeID').val();

        $('#Car_Models_ModelID').empty();

        $.ajax({
            type: 'GET',
            url: '/Admin/GetModelByID?makeID=' + id,
            success: function (result) {
                var info = '';

                $.each(result, function (index, modelList) {
                    $('<option />', { text: modelList.Text, value: modelList.Value }).appendTo('#Car_Models_ModelID');
                });
            }
        });
    }

    function submitCar() {
        $('.field-validation-error')
            .empty();

        $('.field-validation-error')
            .addClass('field-validation-valid')
            .removeClass('field-validation-error');


        var makeID = $('#Car_Models_MakeID :selected').val();
        var modelID = $('#Car_Models_ModelID :selected').val();
        var isNew = $('#Car_IsNew :selected').val();
        var year = $('#Car_Year').val();
        var transmissionID = $('#Car_TransmissionID :selected').val();
        var colorID = $('#Car_ColorID :selected').val();
        var interiorID = $('#Car_InteriorID :selected').val();
        var bodyStyleID = $('#Car_BodyStyleID :selected').val();
        var mileage = $('#Car_Mileage').val();
        var vinID = $('#Car_VinID').val();
        var msrp = $('#Car_MSRP').val();
        var salesPrice = $('#Car_SalesPrice').val();
        var description = $('#Car_Description').val();

        var picture = $('#picture-input').val();
        var extension = picture.split('.').pop();

        submitImage();

        var car = {
            MakeID: makeID,
            ModelID: modelID,
            IsNew: isNew,
            Year: year,
            TransmissionID: transmissionID,
            ColorID: colorID,
            InteriorID: interiorID,
            Mileage: mileage,
            VinID: vinID,
            MSRP: msrp,
            SalesPrice: salesPrice,
            Description: description,
            Picture: extension,
            BodyStyleID: bodyStyleID

        };
        console.log(car);
        $.ajax({
            type: 'POST',
            url: '/Admin/AddVehicle',
            data: JSON.stringify(car),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {

                if (!data.success) {

                    $(data.errors).each(function (index, value) {

                        var field = value.Key.charAt(0).toUpperCase() + value.Key.slice(1);

                        $('span[data-valmsg-for="' + field + '"]')
                            .removeClass('field-validation-valid')
                            .addClass('field-validation-error')
                            .text(value.Value);
                    });
                }

                else {

                    alert("successfully added car");
                    window.location.href = "/Admin/EditVehicle/" + data.id;
                }
            },
            error: function (error) {
                console.log(error);
            }
        });
    }

   
})();