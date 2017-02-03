function parkCar() {
    $.ajax({
        url: "../Vehicles/Create",
        type: 'GET',
        success: function (data) {
            var div = document.getElementById('popup');
            div.innerHTML(data);
            $('#popup').toggle();
        }
    });
}

function closeParkCar() {
    $('#popup').toggle();
}