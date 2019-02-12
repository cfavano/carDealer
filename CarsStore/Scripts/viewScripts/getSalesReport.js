(function () {
    $(document).ready(
        function () {
            $('.table').hide();
            $('.btn-primary').on('click', showReport);

        });

    function showReport() {
        var name = $('#salesName').val();
        var minDate = $('#minDate').val();
        var maxDate = $('#maxDate').val();

        var tbody = $('tbody');
        tbody.empty();

        $.ajax({
            type: 'GET',
            url: '/Reports/GetSales?name=' + name + '&min=' + minDate + '&max=' + maxDate,
            success: function (report) {

                $('.table').show();

                if (report.length <= 0) {
                    
                    var info = "<tr >";
                    info += "<td colspan='3'> Data not available</td>";
                    info += "</tr>";
                    tbody.append(info);
                }
                else {
                    $.each(report, function (index, person) {



                        var info = "<tr class='row-'" + index + ">";
                        info += "<td>" + person.SalesPersonName + "</td>";
                        info += "<td>$" + person.TotalSales.toLocaleString() + "</td>";
                        info += "<td>" + person.TotalCars + "</td>";
                        info += "</tr>";
                        tbody.append(info);
                    });
                }
            },

            error: function (response) {
                console.log(response.status + ' ' + response.error);
            }
        });
    }


})();