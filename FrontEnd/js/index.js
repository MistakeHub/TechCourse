

function GetClients(data) {
    $("#GetClients").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr id=${elem.id}>
                <td id="id">${elem.id}</td>
                <td id="surnamePerson">${elem.surnamePerson}</td>
                <td id="address">${elem.titleAddress}</td>
                <td id="dateClient">${elem.date}</td>
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



    // listen for a click
   clickClientsTable();



    $("#ChangeClient").click(ChangeClient)

}) // jQuery.


function clickClientsTable() {
    $("#GetClients").on('click','tr', function(){
        // get the event targets ID

        var tds = document.getElementById(this.id);

        $("#idClient").val(tds.getElementsByTagName('td').namedItem('id').innerHTML);

        $("#surnameNPClient").val(tds.getElementsByTagName('td').namedItem('surnamePerson').innerHTML);
        $("#phoneNumberClient").val(tds.getElementsByTagName('td').namedItem('phoneNumber').innerHTML)

        $("#yearClient").val(tds.getElementsByTagName('td').namedItem('dateClient').innerHTML)

        $("#streetClient").val(tds.getElementsByTagName('td').namedItem('address').innerHTML)


    })
}



function ChangeClient() {

    var idClient=document.getElementById('idClient').value;
    var SurnameClient=document.getElementById('surnameNPClient').value;
    var PhoneNumber=document.getElementById('phoneNumberClient').value;
    var DateBirth=document.getElementById('yearClient').value;
    var Address=document.getElementById('streetClient').value;

    $.ajax({
        url:"https://localhost:44354/api/Client/"+idClient,
        type:'PUT',
        data:{surname:SurnameClient, phonenumber:+PhoneNumber,dateofbirth:DateBirth,address:Address },
        success:(response)=> open('http://localhost:63342/FrontEnd/doc/tables.html')


    })
}

function GetWorkers(data) {
    $("#GetWorkers").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr id=${elem.id}>
                <td id="iDEnroller">${elem.id}</td>
                <td id="surnameEnroller">${elem.person}</td>
                <td id="specialityEnroller">${elem.specialty}</td>
                <td id="statusEnroller">${elem.status}</td>
                <td id="levelEnroller">${elem.level}</td>
                <td id="periodWorkEnroller">${elem.periodWork}</td>
               </tr>`,
            ""
        )
    );
}

function clickEnrollersTable() {

    $("#GetWorkers").on('click','tr',function () {

        var tds=document.getElementById(this.id);
        $("#idEnroller").val(tds.getElementsByTagName('td').namedItem('iDEnroller').innerHTML);
        $("#surnameNPWorker").val(tds.getElementsByTagName('td').namedItem('surnameEnroller').innerHTML);

        $("#experienceWorker").val(tds.getElementsByTagName('td').namedItem('periodWorkEnroller').innerHTML);
        $("#dischargeWorker").val(tds.getElementsByTagName('td').namedItem('levelEnroller').innerHTML);

    })


}

function GetSpeciality(data) {
    $("#specialtyWorker").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<option name=${elem.id}>${elem.titleSpec}</option>`,
            ""
        )
    );
}

function GetStatus(data) {
    $("#statusWorker").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<option name=${elem.id}>${elem.status}</option>`,
            ""
        )
    );
}

function ChangeEnroller() {

    var id=document.getElementById('idEnroller').value;
   var surnameEnrol= document.getElementById('surnameNPWorker').value;
    var specialty = $('#specialtyWorker option:selected').val();
    var status = $('#statusWorker option:selected').val();
   var periodWork= document.getElementById('experienceWorker').value;
    var level=document.getElementById('dischargeWorker').value;

    $.ajax({
        url:"https://localhost:44354/api/Enroller/"+id,
        type:'PUT',
        data:{speciality:specialty, person:surnameEnrol, level:level, periodwork:periodWork, status:status },
        success:(response)=> open('http://localhost:63342/FrontEnd/doc/tables.html')


    })
}

$(function () {


    $.ajax({
        url: "https://localhost:44354/api/Enroller",
        type: 'GET',
        success: (response) => GetWorkers(response)
    })


clickEnrollersTable();

    $.ajax({
        url: "https://localhost:44354/api/Enroller/Speciality",
        type: 'GET',
        success: (response) => GetSpeciality(response)
    })
    $.ajax({
        url: "https://localhost:44354/api/Enroller/Status",
        type: 'GET',
        success: (response) => GetStatus(response)
    })

    $("#ChangeEnroller").click(ChangeEnroller)


})

function GetAutos(data) {
    $("#GetAutos").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr id=${elem.id}>
                <td id="iDAuto">${elem.id}</td>
                <td id="brand">${elem.brand}</td>
                <td id="person">${elem.person}</td>
                <td id="regnumber">${elem.regNumer}</td>
                <td id="colorAuto">${elem.color}</td>
                <td id="DateStart">${elem.dateStart}</td>
               </tr>`,
            ""
        )
    );
}


function clickAutosTable() {
    $("#GetAutos").on('click','tr', function(){
        // get the event targets ID

        var tds = document.getElementById(this.id);

        $("#idAuto").val(tds.getElementsByTagName('td').namedItem('iDAuto').innerHTML);

        $("#markAuto").val(tds.getElementsByTagName('td').namedItem('brand').innerHTML);


        $("#regNumberAuto").val(tds.getElementsByTagName('td').namedItem('regnumber').innerHTML)

        $("#colorAuto").val(tds.getElementsByTagName('td').namedItem('colorAuto').innerHTML)
        $("#yearOfIssueAuto").val(tds.getElementsByTagName('td').namedItem('DateStart').innerHTML)
        $("#clientsAuto").val(tds.getElementsByTagName('td').namedItem('person').innerHTML)


    })
}



function ChangeAuto() {

    var id=document.getElementById('idAuto').value;
    var mark=document.getElementById('markAuto').value;
    var regnumber=document.getElementById('regNumberAuto').value;
    var Color=document.getElementById('colorAuto').value;
    var DateStart=document.getElementById('yearOfIssueAuto').value;
    var Client=document.getElementById('clientsAuto').value;


    $.ajax({
        url:"https://localhost:44354/api/Auto/"+id,
        type:'PUT',
        data:{brand:mark, person:Client,regnumber:regnumber,color:Color, datestart:+DateStart },
        success:(response)=> open('http://localhost:63342/FrontEnd/doc/tables.html')


    })
}

$(function () {

    $.ajax({
        url: "https://localhost:44354/api/Auto",
        type: 'GET',
        success: (response) => GetAutos(response)



        // success.
    }) // ajax.

    clickAutosTable();
    $("#ChangeAuto").click(ChangeAuto)
})




