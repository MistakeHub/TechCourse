

function GetClients(data) {
    $("#GetClients").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr id=${elem.id}>
                <td id="id">${elem.id}</td>
                <td id="surnamePerson">${elem.surnamePerson}</td>
                <td id="titleaddress">${elem.titleAddress}</td>
                <td id="date">${elem.date}</td>
                <td id="phoneNumber">${elem.phoneNumber}</td>
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

    var table = document.querySelector('table');

    // listen for a click
    $("#GetClients").on('click','tr', function(){
        // get the event targets ID
        var serviceID = $(this).attr('id');
       var data=document.getElementById(serviceID);
       var name=data.children.namedItem('phoneNumber').valueOf();
       $('phoneNumber').value=name;
        console.log(name)

    })

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