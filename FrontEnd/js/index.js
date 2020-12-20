// получить данные о клиентах
function GetClients(data) {
    $("#GetClients").html(
        data.reduce(
            (ans, elem) =>
                ans +
               `<tr>
                <td>${elem.id}</td>
                <td>${elem.title}</td>
                <td>${elem.index}</td>
                <td>${elem.price}</td>
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
                <td>${elem.title}</td>
                <td>${elem.index}</td>
                <td>${elem.price}</td>
               </tr>`,
            ""
        )
    );
}
$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Client",
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
                <td>${elem.title}</td>
                <td>${elem.index}</td>
                <td>${elem.price}</td>
               </tr>`,
            ""
        )
    );
}
$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Client",
        type: 'GET',
        success: (response) => GetAutos(response)

        // success.
    }) // ajax.
}) // jQuery.

//получение дынных адресса в консоль
/*
function getAdressData() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44354/api/Client",
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',

        success: (response) => console.log(response),
    });
};
$(function () {
<<<<<<< HEAD
    document.getElementById("getAdressData").click(getAdressData());
});
 */
=======
    getAdressData();
});
>>>>>>> 18ca6d7c4705eaac70915364e648077f17d672de
