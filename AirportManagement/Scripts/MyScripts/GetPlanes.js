$(function () {


    //Detect changes in the email field
    $("#GetAvailablePlanes").click(function () {
        var selectedRadio = $("input[name='Book']:checked");

        if (selectedRadio.length > 0) {
            var HangerId = selectedRadio.val();
            //alert(email);
            // Perform validation or other checks if needed
            // Then send the email value to the controller using AJAX
            /*alert(HangerId);*/
            var fromdate = $("input[name='fromdate']").val();
            var todate = $("input[name='todate']").val();
            
            if (todate == "") {
                todate = fromdate
            }

            document.querySelector('.spinner-container').style.display = 'flex';
            document.querySelector('.center-content').style.display = 'none';
           
            var dateObject = {
                "FromDate": fromdate,
                "ToDate": todate,
                
            };
            $.ajax({
                url: "https://localhost:44328/Hanger/GetPlanes?FromDate=" + fromdate + "&ToDate=" + todate,
                type: 'GET',
                data: JSON.stringify(dateObject),

                dataType: "json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    var successModel = $("#successModal");
                    var modalBody = $('#successModal .modal-body');
                    modalBody.empty();
                    document.querySelector('.spinner-container').style.display = 'none';
                    document.querySelector('.center-content').style.display = 'flex';
                    if (data != null && data.length > 0) {
                        var location = "<p><span class=label>Hanger Location: </span>" + $("input[name='L" + HangerId + "']").val() + "</p>";
                        var capacity = "<p><span class=label>Hanger Id: </span> " + HangerId + "</p>";

                        modalBody.append(location);
                        modalBody.append(capacity);

                        modalBody.append("<p class='d-none text-danger'id='selectPlane'>Required</p>");
                        var select = $("<select name='SelectedPlaneId' class='form-control' id='selectPlaneId'><option value=' '>Select a plane</option></select>");

                        for (var i = 0; i < data.length; i++) {
                            select.append("<option value='" + data[i].PlaneId + "'>" + data[i].PlaneId + "</option>");
                        }

                        modalBody.append(select);
                        $('#errorModal').modal('hide');
                        $('#successModal').modal('show');
                    }
                    else {
                        document.querySelector('.spinner-container').style.display = 'none';
                        document.querySelector('.center-content').style.display = 'flex';
                        var modalBody = $('#errorModal .modal-body');
                        modalBody.empty();
                        modalBody.append("No Plane Available between " + fromdate + " to " + todate);
                        $('#successModal').modal('hide');
                        $('#errorModal').modal('show');
                    }
                },
                error: function (x, err) {
                    document.querySelector('.spinner-container').style.display = 'none';
                    document.querySelector('.center-content').style.display = 'flex';
                    var modalBody = $('#errorModal .modal-body');
                    modalBody.empty();
                    modalBody.append("No Planes available between selected dates");
                    $('#successModal').modal('hide');
                    $('#errorModal').modal('show');
                    alert(x.readyState);
                    alert(x.responseText);



                }

            });
        }
        else {
            var modalBody = $('#errorModal .modal-body');
            modalBody.empty();
            modalBody.append("please select a hanger");
            $('#successModal').modal('hide');
            $('#errorModal').modal('show');
        }
    });
    $("#BookHanger").click(function () {
        /*alert("hiii");*/
        if ($("#selectPlaneId").val() == " ") {
            $("#selectPlane").removeClass("d-none");
        }
        else {
            $("#selectPlane").addClass("d-none");
            var fromdate = $("input[name='fromdate']").val();
            var todate = $("input[name='todate']").val();
            var planeId = $("#selectPlaneId").val()
            if (todate == "") {
                todate = fromdate
            }
            var selectedRadio = $("input[name='Book']:checked");
            var hangerId = selectedRadio.val();
            var jsonObject = {
                "fromdate": fromdate,
                "todate": todate,
                "planeId": planeId,
                "hangerId": hangerId
            };
            document.querySelector('.spinner-container').style.display = 'flex';
            document.querySelector('.center-content').style.display = 'none';
            $.ajax({
                url: "/Hanger/BookHanger",
                type: 'Post',
                dataType: "json",
                data: JSON.stringify(jsonObject),
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    /*alert("sucess");*/
                    
                    var modalBody = $('#errorModal .modal-body');
                    modalBody.empty();
                    modalBody.append("<p>" + data + "</p>");
                    $('#successModal').modal('hide');
                    $("#errorModal").modal('show');

                },
                error: function (x, err) {
                    document.querySelector('.spinner-container').style.display = 'none';
                    document.querySelector('.center-content').style.display = 'flex';
                    var modalBody = $('#errorModel .modal-body');
                    modalBody.empty();
                    modalBody.append("<p>unable to book</p>")
                    $('#successModal').modal('hide');
                    $("#errorModal").modal('show');
                }
            });
            
            setTimeout(function () {
                var fromdate = $("input[name='fromdate']").val();
                var todate = $("input[name='todate']").val();
                if (todate == "") {
                    todate = fromdate
                }
                alert(fromdate + todate);
                $.ajax({
                    url: "/Hanger/ReloadHangers?fromdate=" + fromdate + "&todate=" + todate,
                    type: 'GET',
                    dataType: "json",
                    contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        
                        alert(data.length);
                        if (data.length > 0) {
                            document.querySelector('.spinner-container').style.display = 'none';
                            document.querySelector('.center-content').style.display = 'flex';
                            $("#AvailableHangers").empty();
                            $("#AvailableHangers").append("<div class='table-header'><div class='table-cell'>" +
                                "Hanger Location</div ><div class='table-cell'>Hanger Id</div><div class='table-cell'>Manager Name</div>"
                                + "<div class='table-cell'>Social Security Number</div><div class='table-cell'>Book</div></div > ")
                            for (i = 0; i < data.length; i++) {
                                var newRow = `
                                        <div class="table-row">
                                            <div class="table-cell">${data[i].HangerLocation}</div>
                                            <div class="table-cell">${data[i].HangerId}</div>
                                            <div class="table-cell">${data[i].ManagerName}</div>
                                            <div class="table-cell">${data[i].SSNo}</div>
                                            <div class="table-cell"><input type='radio' name='Book' value='${data[i].HangerId}' id='Book'/></div>
                                                            <input type="hidden" name="fromdate" value='${fromdate}' />
                                                    <input type="hidden" name="todate" value='${todate}' />
                                                    <input type="hidden" name="L${data[i].HangerId}" value='${data[i].HangerLocation}' />
                                                    <input type="hidden" name="I${data[i].HangerId}" value='${data[i].HangerId}' />

                                            </div>
                                    `;
                                $("#AvailableHangers").append(newRow);
                            }
                        }
                        
                        
                    },
                    error: function (x, err) {
                        
                        var modalBody = $('#errorModal .modal-body');
                        modalBody.empty();
                        modalBody.append("<p>All Hangers are full</p>")
                        $('#successModal').modal('hide');
                        $("#errorModal").modal('show');
                        setTimeout(function () {
                            window.location.href = "/hanger/Gethangers";
                        }, 4000);
                    }
                })
            },4000)
        }
    })
})

function CheckDates() {
    var fromdate = $("#GetFromDate");
    var selectedFromDate = new Date(fromdate.val());
    selectedFromDate.setHours(0, 0, 0, 0);
    var todate = $("#GetToDate");
    var modal = $("#DateErrorModal");
    var modalBody = modal.find('.modal-body');
    var currentDate = new Date();
    currentDate.setHours(0, 0, 0, 0);
    /*alert(fromdate.val() + " " + currentDate);*/
    if (fromdate.val() === "") {
        modal.modal('show');
        modalBody.html("<p>Please select a From Date.</p>");
        return false;
    }
    else if (selectedFromDate < currentDate)
    {
        modal.modal('show');
        modalBody.html("<p>FromDate cannot be less than today's date</p>");
        return false;
    }
    else if (todate.val() != "") {
        if (todate.val() < fromdate.val()) {
            modal.modal('show');
            modalBody.html("<p>ToDate should not be less than  fromdate</p>");
            return false;
        }
    }
    else {
        modal.modal('hide');
        modalBody.html("");
        return true;
    }
}