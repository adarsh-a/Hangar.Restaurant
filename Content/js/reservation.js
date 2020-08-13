$(document).ready(function() {

    if ($('#submitReservation').length) {
        disableOption();
        checkForm();

        //dropdown
        $("#input_date").on("change", function() {
            checkForm();
        });
        $("#input_time").on("change", function() {
            checkForm();
        });
        $("#person").on("change", function() {
            checkForm();
        });

        // textbox
        $("#name").on("input", function() {
            checkForm();
        });
        $("#email").on("input", function() {
            checkForm();
        });
        $("#phone").on("input", function() {
            checkForm();
        });
    }
});

function checkForm() {

    var submit = $("#submitReservation");
    var form = $("#reservationForm");
    form.parsley();
    if (form.parsley().isValid()) {
        submit.prop('disabled', false);
    } else {
        submit.prop('disabled', true);
    }
}

//disable "Select Person*"
function disableOption() {
    var dropdownOption = $('#person option:first-child');
    dropdownOption.prop('disabled', true);
}