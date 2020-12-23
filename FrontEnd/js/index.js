// получить данные о клиентах
function GetClients(data) {
    $("#GetClients").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr>
                <td>${elem.id}</td>
                <td>${elem.surnamePerson}</td>
                <td>${elem.titleAddress}</td>
                <td>${elem.date}</td>
                <td>${elem.phoneNumber}</td>
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
}) // jQuery.


//получить данные о работниках
function GetWorkers(data) {
    $("#GetWorkers").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr>
                <td>${elem.id}</td>
                <td>${elem.person}</td>
                <td>${elem.specialty}</td>
                <td>${elem.level}</td>
                <td>${elem.periodWork}</td>
                <td>${elem.status}</td>
               </tr>`,
            ""
        )
    );
}
$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Enroller",
        type: 'GET',
        success: (response) => GetWorkers(response)

        // success.
    }) // ajax.
}) // jQuery.

//получить данные о автомобилях
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
        url: "https://localhost:44354/api/Auto",
        type: 'GET',
        success: (response) => GetAutos(response)

        // success.
    }) // ajax.
}) // jQuery.

//-------------------------------------------------------------------------------------------

//Добавление клиента
function AddClient() {
    var surnamenp = document.getElementById("surnameNP").value;
    var phonenumber = document.getElementById("phoneNumber").value;
    var passport = document.getElementById("passport").value;
    var year = document.getElementById("year").value;
    var mounth = document.getElementById("mounth").value;
    var day = document.getElementById("day").value;
    var street = document.getElementById("street").value;
    var home = document.getElementById("home").value;
    var apartment = document.getElementById("apartment").value;

    $.ajax({
        url: "https://localhost:44354/api/Client",
        type: 'POST',
        data: {surname:surnamenp, passport:passport, street:street, home:home, apartament:apartment, year:+year, mounth:+mounth, day:+day, phonenumber:phonenumber},
        success: (response) => alert("Клиент добавлен")

    })
}
$(function () {
    $("#append").click(AddClient);
})


//Добавление работника
function AddWorker() {
    var surnamenp = document.getElementById("surnameNP").value;
    var passport = document.getElementById("passport").value;
    var specialty = document.getElementById("specialty").value;
    var discharge = document.getElementById("discharge").value;
    var experience = document.getElementById("experience").value;

    $.ajax({
        url: "https://localhost:44354/api/Worker",
        type: 'POST',
        data: {surname:surnamenp, passport:passport, street:street, specialty:+specialty, discharge:discharge, experience:experience},
        success: (response) => alert("Работник добавлен")

    })
}
$(function () {
    $("#append").click(AddWorker);
})


//Добавление автомобиля
function AddAuto() {
    var mark = document.getElementById("mark").value;
    var model = document.getElementById("model").value;
    var regNumber = document.getElementById("regNumber").value;
    var color = document.getElementById("color").value;
    var yearOfIssue = document.getElementById("yearOfIssue").value;
    var clients = document.getElementById("clients").value;

    $.ajax({
        url: "https://localhost:44354/api/Worker",
        type: 'POST',
        data: {mark:mark, model:model, street:street, regNumber:regNumber, color:color, yearOfIssue:+yearOfIssue, clients:clients},
        success: (response) => alert("Автомобиль добавлен")

    })
}
$(function () {
    $("#append").click(AddAuto);
})