function GetClientsOption(data) {

    $("#clientsoptions").html(
        data.reduce(
            (ans, elem) =>
            ans +
            `<option name=${elem.id}>${elem.surnamePerson}</option>`,
            ""
        )
    );
}

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Client",
        type: 'GET',

        success: (response) => GetClientsOption(response)

    })
})



function AddAuto() {
    var mark = document.getElementById("mark").value;
    var model = document.getElementById("model").value;
    var regNumber = document.getElementById("regNumber").value;
    var color = document.getElementById("color").value;
    var yearOfIssue = document.getElementById("yearOfIssue").value;

    let clients = $('#specialty option:selected').name;

    $.ajax({
        url: "https://localhost:44354/api/Auto",
        type: 'POST',
        data: { titlebrand: mark, model: model, idperson:+clients, regNumber: regNumber, color: color, dateStart: +yearOfIssue },
        success: (response) => alert("Автомобиль добавлен")

    })
}
$(function () {
    $("#append").click(AddAuto);
})

function GetAutos(data) {
    $("#GetAutos").html(
        data.reduce(
            (ans, elem) =>
            ans +
            `<tr>
                <td>${elem.id}</td>
                <td>${elem.brand}</td>
                <td>${elem.person}</td>
                <td>${elem.regNumer}</td>
                <td>${elem.color}</td>
                <td>${elem.dateStart}</td>
               </tr>`,
            ""
        )
    );
}

$(function () {

    $.ajax({
        url: "https://localhost:44354/api/Client",
        type: 'GET',
        success: (response) => GetClients(response)

        // success.
    }) // ajax.
    $.ajax({
        url: "https://localhost:44354/api/Auto",
        type: 'GET',
        success: (response) => GetAutos(response)

        // success.
    }) // ajax.
}) // jQuery.

function GetClients(data) {

    $("#clients").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<option name=${elem.id}>${elem.surnamePerson}</option>`,
            ""
        )
    );
}

