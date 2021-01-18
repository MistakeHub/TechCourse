// Получение данных для заявки
function GetApplications(data) {
    $("#GetApplications").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr>
                <td id="${elem.id}">${elem.id}</td>
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
                `<option name=${elem.id}>${elem.client}</option>`,
            ""
        )
    );
}

function GetWorkerOption(data) {
    $("#worker").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<option name=${elem.id}>${elem.enroller}</option>`,
            ""
        )
    );
}

function GetAutoOption(data) {
    $("#auto").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<option name=${elem.id}>${elem.auto}</option>`,
            ""
        )
    );
}

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Client",
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

    $("#butonApplication").click(confirmationApplication)
}) // jQuery.

function clickApplicationsTable() {
    $("#GetApplications").on('click','tr', function(){
        // get the event targets ID
        var tds = document.getElementById(this.id);

        $("#butonApplication").val(tds.getElementsByTagName('td').namedItem('id').innerHTML);
    })
}

function confirmationApplication() {

    var id=document.getElementById('butonApplication').value;

    $.ajax({
        url:"https://localhost:44354/api/FixRequest/"+id,
        type:'DELETE',
        success:(response)=> open('http://localhost:63342/FrontEnd/doc/application.html')


    })
}