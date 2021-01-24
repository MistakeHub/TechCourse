// запросы 6
// 6.Самая распространенная неисправность в автомобилях указанной марки?
function GetQuery6(data) {
    $("#GetQuery6").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr>
               
                <td>${elem.breaks}</td>
                <td>${elem.count}</td>
               </tr>`,
            ""
        )
    );
}

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Query/Query6/Audi",
        type: 'GET',
        success: (response) => GetQuery6(response)
    })
})