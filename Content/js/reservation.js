window.onload = function() {
    var reservationBtn = document.getElementById('submitReservation');
    console.log('here');

    if (document.contains(reservationBtn)) {
        disableOption();
        checkInputs();
    }
}

function checkInputs() {
    var input1 = document.getElementById('input_date');
    var input2 = document.getElementById('input_time');
    var input3 = document.getElementById('person');
    var input4 = document.getElementById('name');
    var input5 = document.getElementById('email');
    var input6 = document.getElementById('phone');
}

//disable "Select Person*"
function disableOption() {
    var dropdown = document.getElementById('person');
    var option = dropdown.getElementsByTagName('option')[0];
    option.disabled = true;
}