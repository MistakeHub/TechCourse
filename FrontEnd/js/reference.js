// СПРАВКА
// Получение справки
function GetReference(data) {
    $("#GetReference").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr>
                <td>${elem.countauto}</td>
                <td>${elem.notBusyEnroller}</td>
               </tr>`,
            ""
        )
    );
}

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Query/Reference",
        type: 'GET',
        success: (response) => GetReference(response)
    })
})