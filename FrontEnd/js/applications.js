// Получение данных для заявки
function GetApplications(data) {
    $("#GetApplications").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr id="${elem.id}">
                <td id="idRequest">${elem.id}</td>
                <td>${elem.client}</td>
                <td>${elem.enroller}</td>
                <td>${elem.auto}</td>
                <td>${elem.daterequest}</td>
                <td>${elem.statusReady}</td>
                <td>${elem.priceBreak}</td>
                <td>${elem.dateEnd}</td>
               </tr>`,
            ""
        )
    );
}

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/FixRequest",
        type: 'GET',
        success: (response) => GetApplications(response)
    })
})


function GetClientOption(data) {
    $("#clients").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<option name=${elem.id}>${elem.surnameNP}</option>`,
            ""
        )
    );
}

function GetWorkerOption(data) {
    $("#worker").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<option name=${elem.id}>${elem.person}</option>`,
            ""
        )
    );
}

function GetAutoOption(data) {
    $("#auto").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<option name=${elem.id}>${elem.brand}</option>`,
            ""
        )
    );
}

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Client/Person",
        type: 'GET',
        success: (response) => GetClientOption(response)
    })

    $.ajax({
        url: "https://localhost:44354/api/Enroller",
        type: 'GET',
        success: (response) => GetWorkerOption(response)
    })

    $.ajax({
        url: "https://localhost:44354/api/Auto",
        type: 'GET',
        success: (response) => GetAutoOption(response)
    })
})

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/FixRequest",
        type: 'GET',
        success: (response) => GetApplications(response)
        // success.
    }) // ajax.

    // listen for a click
    clickApplicationsTable();

    $("#buttonApplication").click(confirmationApplication)
}) // jQuery.

function clickApplicationsTable() {
    $("#GetApplications").on('click','tr', function(){
        // get the event targets ID
        var tds = document.getElementById(this.id);
         console.log(this.id)

        $("#idReq").val(tds.getElementsByTagName('td').namedItem('idRequest').innerHTML);
    })
}

function confirmationApplication() {

    var id=document.getElementById('idReq').value;

    $.ajax({
        url:"https://localhost:44354/api/FixRequest/"+id,
        type:'DELETE',
        success:(response)=> open('http://localhost:63342/FrontEnd/doc/application.html')


    })
}