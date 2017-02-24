$(function () {
    $("#btnSubmit").click(function () {
        //Recibe un numero desde el input
        var Number = $("#txtNumber").val();

        //Comprobamos si el numero es par
        var Result = Number % 2;

        if (Result == 0) {
            alert("El numero: " + Number + " es par.")
        } else {
            alert("El numero: " + Number + " es impar.")
        }
    });
});