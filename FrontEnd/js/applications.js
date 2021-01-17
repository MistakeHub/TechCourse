// Получение данных для заявки
function GetApplications(data) {
    $("#GetApplications").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr>
                <td>${elem.id}</td>
                <td>${elem.client}</td>
                <td>${elem.enroller}</td>
                <td>${elem.auto}</td>
                <td>${elem.daterequest}</td>
                <td>${elem.statusReady}</td>
                <td>${elem.priceBreak}</td>
                <td>${elem.dateEnd}</td>
               </tr>`,
            ""
        )
    );
}

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/FixRequest",
        type: 'GET',
        success: (response) => GetApplications(response)
    })
})
