$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Enroller",
        type: 'GET',
        success: (response) => GetWorkers(response)

        // success.
    }) // ajax.
}) // jQuery.

//получение работника


function GetSpeciality(data) {
    $("#specialty").html(
        data.reduce(
            (ans, elem) =>
            ans +
            `<option name=${elem.id}>${elem.titleSpec}</option>`,
            ""
        )
    );
}

//добавление работника
function AddWorker() {
    var surnamenp = document.getElementById("surnameNP").value;
    var passport = document.getElementById("passport").value;
    var specialty = $('#specialty option:selected').val();
    let discharge = $('#discharge option:selected').val();

    var experience = document.getElementById("experience").value;
    $.ajax({
        url: "https://localhost:44354/api/Enroller",
        type: 'POST',
        data: {surnameNP:surnamenp, passport:passport, speciality:specialty, level:discharge, periodWork:experience},
        success: (response) => alert("Работник добавлен"),
    })
}


$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Enroller/Speciality",
        type: 'GET',
        success: (response) => GetSpeciality(response)
    })

    $.ajax({
        url: "https://localhost:44354/api/Enroller",
        type: 'GET',
        success: (response) => GetLevel(response)
    })


})


function GetLevel(data) {
    $("#discharge").html(
        data.reduce(
            (ans, elem) =>
            ans +
            `<option name=${elem.id}>${elem.level}</option>`,
            ""
        )
    );
}

$(function (){
    $('#appendEnroller').click(AddWorker);
})