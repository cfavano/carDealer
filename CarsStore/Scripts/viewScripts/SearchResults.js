(function () {
    $(document).ready(function () {
        $(".search-title").hide();
        $("#search-btn").on('click', showResults);
    });

    function showResults() {
        var search = $('#search').val();
        var minDate = $('#minYear').val();
        var maxDate = $('#maxYear').val();
        var minPrice = $('#minPrice').val();
        var maxPrice = $('#maxPrice').val();
        var button = $("#search-btn").val();

        $(".search-title").show();

        var resultsContainer = $('.search-results');
        var newActionLink = "";
        resultsContainer.empty();

        $.ajax({
            type: 'GET',
            url: '/' + button + '?minPrice=' + minPrice + '&maxPrice=' + maxPrice + '&minYear=' + minDate + '&maxYear=' + maxDate + '&search=' + search,
            success: function (result) {
                $("#search-results").show();
                var info = "";

                if (result.length === 0) {
                    info = "<div class='col-sm-12'><h4>No matching cars found</h4></div>";
                    resultsContainer.append(info);
                }
                else {
                    $.each(result, function (index, car) {

                        switch (button) {
                            case "Admin/SearchCars":
                                newActionLink = "<a class='btn btn-primary float-right col-6' href='/Admin/EditVehicle/" + car.CarID + "'>Edit</a>";
                                break;
                            case "Inventory/SearchUsedCars" :
                                newActionLink = "<a class='btn btn-primary float-right col-6' href='/Inventory/Details/" + car.CarID + "'>Details</a>";
                                break;

                            case "Inventory/SearchNewCars":
                                newActionLink = "<a class='btn btn-primary float-right col-6' href='/Inventory/Details/" + car.CarID + "'>Details</a>";
                                break;
                            case "Sales/SearchCars":
                                newActionLink = "<a class='btn btn-primary float-right col-6' href='/Sales/Purchase/" + car.CarID + "'>Purchase</a>";
                                break;
                        }

                        if (car.Mileage <= 1000) {
                            car.Mileage = "New";
                        }

                        info = "<div class='col-sm-12 outline'>";
                        info += "<div class='row'><div class='col-sm-12'><h4>" + car.Year + " " + car.Models.Makes.MakeName + " " + car.Models.ModelName + "</h4></div></div>";
                        info += "<div class='row detail-columns'>";
                        info += "<div class='col-sm-3'><img src='/Images/Inventory/" + car.Picture +"' class='img-fluid'/></div>";
                        info += "<div class='col-sm-3'><p class='row'><span class='col-6 text-right font-weight-bold'>Body Style: </span><span class='col-6'>" + car.BodyStyles.BodyStyleName + "</span></p>                  <p class='row'><span class='col-6 text-right font-weight-bold'>Trans:</span>                                <span class='col-6'> " + car.Transmissions.TransmissionType + "</span></p><p class='row'> <span class='col-6 text-right font-weight-bold'>Color:</span><span class='col-6'> " + car.Colors.ColorName + "</span></p></div >";
                        info += "<div class='col-sm-3'><p class='row'><span class='col-6 text-right font-weight-bold'>Interior:   </span><span class='col-6'>" + car.Interiors.InteriorColor + "</span></p>                   <p class='row'><span class='col-6 text-right font-weight-bold'>Mileage: </span>                             <span class='col-6'>" + car.Mileage + "                      </span></p><p class='row'>   <span class='col-6 text-right font-weight-bold'>VIN #:</span><span class='col-6'> " + car.VinID + "</span></p></div>";
                        info += "<div class='col-sm-3'><p class='row'><span class='col-6 text-right font-weight-bold'>Sale Price: </span><span class='col-6'> $" + Number(car.SalesPrice).toLocaleString('en') + "</span></p> <p class='row'><span class='col-6 text-right font-weight-bold'>MSRP: </span>                             <span class='col-6'> $" + Number(car.MSRP).toLocaleString('en') + "</span></p>" + newActionLink + "</div>";
                        info += "</div ></div>";

                        resultsContainer.append(info);
                    });
                }
            },
            error: function (resposnse) {
                console.log(response.status + ' ' + response.error);
            }
        });
    }

})();