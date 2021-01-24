// запросы 7
// 7.Количество рабочих каждой специальности на станции?
function GetQuery7(data) {
    $("#GetQuery7").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr>    
                <td>${elem.titleSpec}</td>
                <td>${elem.count}</td>
               </tr>`,
            ""
        )
    );
}

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Query/Query7/",
        type: 'GET',
        success: (response) => GetQuery7(response)
    })
})