// ОТЧЕТ
// Получение отчета
function GetReport(data) {
    $("#GetReport").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr>
                <td>${elem.countCompleted}</td>
                <td>${elem.sum}</td>
                <td>${elem.autoCompleted}</td>
                <td>${elem.autoNotCompleted}</td>
               </tr>`,
            ""
        )
    );
}

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Query/Receipt",
        type: 'GET',
        success: (response) => GetReport(response)
    })
})