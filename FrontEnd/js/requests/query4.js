// запросы 4
// 4.Фамилия, имя, отчество работника станции, устранявшего данную неисправность в автомобиле данного клиента, и время ее устранения?
function GetQuery4(data) {
    $("#GetQuery4").html(


        `<tr>
                <td>${data.id}</td>
                <td>${data.enroller}</td>
                <td>${data.daterequest}</td>
                <td>${data.dateEnd}</td>
               </tr>`,
        ""

    );
}

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Query/Query4/Углицкий Вацлав Прохорович/Пробито колесо",
        type: 'GET',
        success: (response) => GetQuery4(response)
    })
})