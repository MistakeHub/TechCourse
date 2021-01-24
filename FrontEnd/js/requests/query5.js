// запросы 5
// 5.Фамилия, имя, отчество клиентов, сдавших в ремонт автомобили с указанным типом неисправности?
function GetQuery5(data) {
    $("#GetQuery5").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr>
                <td>${elem.id}</td>
                <td>${elem.surnamePerson}</td>
               
               </tr>`,
            ""
        )
    );
}

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Query/Query5/Поломан Двигатель",
        type: 'GET',
        success: (response) => GetQuery5(response)
    })
})