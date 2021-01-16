function GetPersonOption(data) {
    $("#clients").html(
        data.reduce(
            (ans, elem) =>
            ans +
            `<option name=${elem.id}>${elem.surnameNP}</option>`,
            ""
        )
    );
}


function GetBreaks(data) {
    $("#breaks").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<option name=${elem.id}>${elem.breakName}</option>`,
            ""
        )
    );
}
$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Client/Person",
        type: 'GET',
        success: (response) => GetPersonOption(response)
    })

    $.ajax({
        url: "https://localhost:44354/api/Auto/Break",
        type: 'GET',
        success: (response) => GetBreaks(response)
    })
})


//добавление автомобиля
function AddAuto() {
    var mark = document.getElementById("mark").value;
    var model = document.getElementById("model").value;
    var regNumber = document.getElementById("regNumber").value;
    var color = document.getElementById("color").value;
    var yearOfIssue = document.getElementById("yearOfIssue").value;
    var breaks=$('#breaks option:selected').val();

    var clients = $('#clients option:selected').attr('name');

    $.ajax({
        url: "https://localhost:44354/api/Auto",
        type: 'POST',
        data: { titlebrand: mark, model: model, idperson:+clients, regNumber: regNumber, color: color, dateStart: yearOfIssue, breaks:breaks },
        success: (response) => alert("Автомобиль добавлен")
    })
}

$(function () {
    $("#append").click(AddAuto);
})


//получение автомобиля









