// запросы 3
// 3.Перечень устраненных неисправностей в автомобиле данного владельца?
function GetQuery3(data) {
    $("#GetQuery3").html(



        `<tr>
                <td>${data.id}</td>
                <td>${data.person}</td>
                <td>${data.breaks}</td>
               </tr>`,
        ""

    );
}

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Query/Query3/Клюкин Кирилл Глебович",
        type: 'GET',
        success: (response) => GetQuery3(response)
    })
})
