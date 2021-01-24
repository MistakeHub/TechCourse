// ОТЧЕТ
// Получение отчета
function GetReport(data) {
    $("#GetReport").html(
       
                `<tr>
                <td>${data.countCompleted}</td>
                <td>${data.sum}</td>
                <td>${data.autoCompleted}</td>
                <td>${data.autoNotCompleted}</td>
               </tr>`,
            ""
        
    );
}

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Query/Receipt",
        type: 'GET',
        success: (response) => GetReport(response)
    })
})