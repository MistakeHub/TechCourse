// получить данные о клиентах
function GetClients(data) {
    $("#GetClients").html(
        data.reduce(
            (ans, elem) =>
                ans +
               `<tr>
                <td>${elem.id}</td>
                <td>${elem.idPerson}</td>
                <td>${elem.idAddress}</td>
                <td>${elem.dateBirth}</td>
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
                <td>${elem.idPerson}</td>
                <td>${elem.idSpecialty}</td>
                <td>${elem.level}</td>
                <td>${elem.periodWork}</td>
                <td>${elem.idStatus}</td>
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
                <td>${elem.idBrand}</td>
                <td>${elem.idPerson}</td>
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

