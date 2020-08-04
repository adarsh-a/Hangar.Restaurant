$(document).ready(function() {

    if ($('#submitReservation').length) {
        disableOption();
        checkForm();

        $("#input_date").on("change", function() {
            checkForm();
        });
        $("#input_time").on("change", function() {
            checkForm();
        });
        $("#person").on("change", function() {
            checkForm();
        });
        $("#name").on("change", function() {
            checkForm();
        });
        $("#email").on("change", function() {
            checkForm();
        });
        $("#phone").on("change", function() {
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