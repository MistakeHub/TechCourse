// Получение данных для заявки
function GetApplications(data) {
    $("#GetApplications").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr>
                <td>${elem.id}</td>
                <td>${elem.dateOfApplication}</td>
                <td>${elem.completionDate}</td>
                <td>${elem.clients}</td>
                <td>${elem.worker}</td>
                <td>${elem.auto}</td>
                <td>${elem.repairPrice}</td>
                <td>${elem.readinessStatus}</td>
               </tr>`,
            ""
        )
    );
}

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/",
        type: 'GET',
        success: (response) => GetApplications(response)
    })
})
