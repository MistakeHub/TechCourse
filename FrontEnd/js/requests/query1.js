// запрос 1
// 1.Фамилия, имя, отчество и адрес владельца автомобиля с данным номером государственной регистрации?
function GetQuery1(data) {
    $("#GetQuery1").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr>
                <td>${elem.id}</td>
                <td>${elem.surnamePerson}</td>
                <td>${elem.titleAddress}</td>
               </tr>`,
            ""
        )
    );
}

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Query/Query1/DT43DK",
        type: 'GET',
        success: (response) => GetQuery1(response)
    })
})
