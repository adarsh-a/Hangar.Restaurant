$(document).ready(function() {

    if ($('#submitReservation').length) {

        $("#submitReservation").prop("disabled", true);

        //dropdown
        $("#input_date").on("change", function() {
            checkForm($("#input_date"));
        });
        $("#input_time").on("change", function() {
            checkForm($("#input_time"));
        });
        $("#person").on("change", function() {
            checkForm($("#person"));
        });

        // textbox
        $("#name").on("input", function() {
            checkForm($("#name"));
        });
        $("#email").on("input", function() {
            checkForm($("#email"));
        });
        $("#phone").on("input", function() {
            checkForm($("#phone"));
        });
    }

});

function checkForm(field) {

    var submit = $("#submitReservation");
    var form = $("#reservationForm");
    field.parsley().validate();
    if (form.parsley().isValid()) {
        submit.prop('disabled', false);
    } else {
        field.parent().find("li").addClass("text-danger");
        submit.prop('disabled', true);
    }
}

function sendReservation() {
    var form = $("#reservationForm").serializeArray();
    var formData = [];
    for (i = 0; i < form.length; i++) {
        formData[form[i].name] = form[i].value
    }
    // Serialize form
    formData = JSON.stringify(Object.assign({}, formData));

    $.ajax({
        type: "POST",
        url: "Reservation/reservation",
        data: { reservationForm: formData },
        success: function(response) {
            displayMessage(response.color, response.msg)
        },
        failure: function(response) {
            alert("fail" + response);
        },
        beforeSend: function() {
            // Show loading image
            $("#imgLoading").css("display", "block");
        }
    })
}

function displayMessage(color, message) {
    var msgDiv = $("#reserveMessage")
    msgDiv.attr("class", "h3 text-center hidden " + color);
    msgDiv.html(message);

    // Hide loading image
    $("#imgLoading").css("display", "none");
}