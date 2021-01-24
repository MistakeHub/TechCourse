// СПРАВКА
// Получение справки
function GetReference(data) {
    $("#GetReference").html(
       
                `<tr>
                <td>${data.countauto}</td>
                <td>${data.notBusyEnroller}</td>
               </tr>`,
            ""
        )
    
}

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Query/Reference",
        type: 'GET',
        success: (response) => GetReference(response)
    })
})