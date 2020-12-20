function Adresses(data) {
    $("#Adresses").html(
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
        url: 'http://localhost:51483/api/SubEdition',
        type: 'GET',
        success: (response) => SubEdition(response)

         // success.
    }) // ajax.
}) // jQuery.



//получение дынных адресса
function getAdressData() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44354/api/Client",
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',

        success: (response) => console.log(response),
    });
};
$(function () {
    getAdressData();
});