(function () {
    $(document).ready(function () {
        $('#Car_Models_MakeID').on('change', getModels);
        $('#update-car').on('click', updateCar);
        $('#delete-car').on('click', deleteCar);
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

    function updateCar() {
        var carID = window.location.pathname.toLocaleUpperCase().replace('/ADMIN/EDITVEHICLE/','');


        var makeID = $('#Car_Models_MakeID :selected').val();
        var modelID = $('#Car_Models_ModelID :selected').val();
        var isNew = $('#Car_IsNew :selected').val();
        var year = $('#Car_Year').val();
        var transmissionID = $('#Car_TransmissionID :selected').val();
        var colorID = $('#Car_ColorID :selected').val();
        var interiorID = $('#Car_InteriorID :selected').val();
        var mileage = $('#Car_Mileage').val();
        var vinID = $('#Car_VinID').val();
        var msrp = $('#Car_MSRP').val();
        var salesPrice = $('#Car_SalesPrice').val();
        var description = $('#Car_Description').val();
        var picture = $('#picture-input').val();
        var bodyStyleID = $('#Car_BodyStyleID').val();
        var isFeatured;

        if (picture !== undefined) {
            var extension = picture.split('.').pop();

            submitUpdateImage(carID);
        }
     

        if ($('#Car_IsFeatured:checked').is(":checked")) {
            isFeatured = true;
        }
        else {
            isFeatured = false;
        }
        var model = {
            car : {
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
                BodyStyleID: bodyStyleID,
                IsFeatured: isFeatured,
                CarID: carID
            }
        };


        $.ajax({
            type: 'PUT',
            url: '/Admin/EditVehicle',
            data: JSON.stringify(model),
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
                    alert("successfully updated car");
                    window.location.href = '/Inventory/Details/' + carID;
                }
            },
            error: function (error) {
                console.log(error);
            }
        });
    }

    function deleteCar() {
        var carID = window.location.pathname.toLocaleUpperCase().replace('/ADMIN/EDITVEHICLE/', '');

        $.ajax({
            
            url: '/Admin/DeleteCar/' + carID,
            type: 'DELETE',
            success: function () {
                window.location.href = '/Admin/Vehicles';
            }
        });
    }
})();