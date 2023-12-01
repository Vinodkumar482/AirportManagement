$(function () {

    //Detect changes in the email field
    $("#Email").blur(function () {
        var email = $("#Email").val();
        document.querySelector('.spinner-container').style.display = 'flex';
        document.querySelector('.form-card').style.display = 'none';
        //alert(email);
        // Perform validation or other checks if needed
        // Then send the email value to the controller using AJAX
        $.ajax({
            url: "/Plane/CheckingMail/",
            type: 'POST',
            dataType: "json",
            data: JSON.stringify({ "email": email }),
            contentType: "application/json;charset=utf-8",
            success: function (data) {
                if (data != null) {
                    document.querySelector('.spinner-container').style.display = 'none';
                    document.querySelector('.form-card').style.display = 'flex';
                   
                    $('#OwnerName').val(data.OwnerName);
                    $('#HouseNo').val(data.HouseNo);
                    $('#City').val(data.City);
                    $('#State').val(data.State);
                    $('#Country').val(data.Country);
                    $('#PinNo').val(data.PinNo);
                    $('#AddressLine').val(data.AddressLine);
                    $("#HouseNo").removeAttr("disabled");
                    $("#City").removeAttr("disabled");
                    $("#State").removeAttr("disabled");
                    $("#Country").removeAttr("disabled");
                    $("#PinNo").removeAttr("disabled");
                    $("#AddressLine").removeAttr("disabled");
                    $("#OwnerName").removeAttr("disabled");
                }
            },
            error: function (x, err) {
                //alert(x.readyState);
                //alert(x.responseText);
                document.querySelector('.spinner-container').style.display = 'none';
                document.querySelector('.form-card').style.display = 'flex';
                $('#OwnerName').val("");
                $('#HouseNo').val("");
                $('#City').val("");
                $('#State').val("");
                $('#Country').val("");
                $('#PinNo').val("");
                $('#AddressLine').val("");
                $('#ownerNotFoundModal').modal('show');
                $("#HouseNo").removeAttr("disabled");
                $("#City").removeAttr("disabled");
                $("#State").removeAttr("disabled");
                $("#Country").removeAttr("disabled");
                $("#PinNo").removeAttr("disabled");
                $("#AddressLine").removeAttr("disabled");
                $("#OwnerName").removeAttr("disabled");
            }

        });
    });

})