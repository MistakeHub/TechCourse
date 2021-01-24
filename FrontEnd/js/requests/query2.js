
// запросы 2
// 2.Марка и год выпуска автомобиля данного владельца?
function GetQuery2(data) {
    $("#GetQuery2").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr>
                <td>${elem.id}</td>
                <td>${elem.brand}</td>
                <td>${elem.dateStart}</td>
               </tr>`,
            ""
        )
    );
}

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Query/Query2/Стеблева Агафья Юлиевна",
        type: 'GET',
        success: (response) => GetQuery2(response)
    })
})