

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
    })


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


$.ajax({
    url: "https://localhost:44354/api/Auto",
    type: 'GET',
    success: (response) => GetAutos(response)

    // success.
}) // ajax.