$(function () {

    //Detect changes in the email field
    $("#Btnstatus").click(function () {

        var HangerId = $("#SelectedPlaneId").val();
        var fromdate = $("#fromdate").val();
        var todate = $("#todate").val();
        var modal = $("#StatusErrorModal");
        var modalBody = modal.find('.modal-body');
        
        var currentDate = new Date();
        if (HangerId == "" || fromdate == "" || todate == "") {
            modal.modal('show');
            modalBody.html("<p>Please enter all the details</p>");
        }
        else if (fromdate > todate) {
            modal.modal('show');
            modalBody.html("<p>Fromdate cannot be greater than todate</p>");
        }
        
        else {

            //alert(email);
            // Perform validation or other checks if needed
            // Then send the email value to the controller using AJAX
            $.ajax({
                url: "https://localhost:44338/api/HangerDetails/GetStatus?HangerId=" + HangerId + "&fromdate=" + fromdate + "&todate=" + todate,
                type: 'GET',
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    var location = $("#L" + HangerId).val();
                    var capacity = $("#C" + HangerId).val();
                    
                    $("#AvailableHangers").empty();
                    $("#AvailableHangers").append("<div class=table-header><div class=table-cell>HangerId</div><div class=table-cell>HangerLocation</div><div class=table-cell>PlaneId</div><div class=table-cell>FromDate</div><div class=table-cell>ToDate</div><div class=table-cell>Status</div></div>");
                    if (data != null) {
                        for (var i = 0; i < data.length; i++) {
                            $("#AvailableHangers").append("<div class=table-row><div class=table-cell>" + data[i].HangerId + "</div><div class=table-cell>" + data[i].HangerLocation + "</div><div class=table-cell>" + data[i].PlaneId + "</div><div class=table-cell>" + formatDate(data[i].FromDate) + "</div><div class=table-cell>" + formatDate( data[i].ToDate) + "</div><div class=table-cell>Booked</div></div>");
                        }

                    }
                   
                    for (var i = 0; i < capacity - data.length; i++) {

                        $("#AvailableHangers").append("<tr class=table-row><td class=table-cell>" + HangerId + "</td><td class=table-cell>" + location + "</td><td class=table-cell>No Plane </td><td class=table-cell>" + fromdate + "</td><td class=table-cell>" + todate + "</td><td class=table-cell>Available</td></tr>");
                    }
                },
                error: function (x, err) {
                    modal.modal('show');
                    modalBody.html("<p>Error occured try again later</p>");

                }

            });
        }
    });

})
function formatDate(dateString) {
    var parts = dateString.split('-');
    var year = parts[0];
    var month = parts[1];
    var day = parts[2].split('T')[0];
    return year + '-' + month + '-' + day;
}