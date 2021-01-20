// запрос 1
// 1.Фамилия, имя, отчество и адрес владельца автомобиля с данным номером государственной регистрации?
function GetQuery1(data) {
    $("#GetQuery1").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr>
                <td>${elem.id}</td>
                <td>${elem.surnamePerson}</td>
                <td>${elem.titleAddress}</td>
               </tr>`,
            ""
        )
    );
}

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Query/Query1/DT43DK",
        type: 'GET',
        success: (response) => GetQuery1(response)
    })
})

// запросы 2
// 2.Марка и год выпуска автомобиля данного владельца?
function GetQuery2(data) {
    $("#GetQuery2").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr>
                <td>${elem.id}</td>
                <td>${elem.brand}</td>
                <td>${elem.dateStart}</td>
               </tr>`,
            ""
        )
    );
}

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Query/Query2/Стеблева Агафья Юлиевна",
        type: 'GET',
        success: (response) => GetQuery2(response)
    })
})


// запросы 3
// 3.Перечень устраненных неисправностей в автомобиле данного владельца?
function GetQuery3(data) {
    $("#GetQuery3").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr>
                <td>${elem.id}</td>
                <td>${elem.person}</td>
                <td>${elem.breaks}</td>
               </tr>`,
            ""
        )
    );
}

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Query/Query3/Венедиктов Артём Леонидович",
        type: 'GET',
        success: (response) => GetQuery3(response)
    })
})

// запросы 4
// 4.Фамилия, имя, отчество работника станции, устранявшего данную неисправность в автомобиле данного клиента, и время ее устранения?
function GetQuery4(data) {
    $("#GetQuery4").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr>
                <td>${elem.id}</td>
                <td>${elem.enroller}</td>
                <td>${elem.dateStart}</td>
                <td>${elem.dateEnd}</td>
               </tr>`,
            ""
        )
    );
}

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Query/Query4/Пробито колесо",
        type: 'GET',
        success: (response) => GetQuery4(response)
    })
})

// запросы 5
// 5.Фамилия, имя, отчество клиентов, сдавших в ремонт автомобили с указанным типом неисправности?
function GetQuery5(data) {
    $("#GetQuery5").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr>
                <td>${elem.id}</td>
                <td>${elem.client}</td>
                <td>${elem.breaks}</td>
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

// запросы 6
// 6.Самая распространенная неисправность в автомобилях указанной марки?
function GetQuery6(data) {
    $("#GetQuery6").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr>
                <td>${elem.id}</td>
                <td>${elem.brand}</td>
                <td>${elem.breaks}</td>
               </tr>`,
            ""
        )
    );
}

$(function () {
    $.ajax({
        url: "https://localhost:44354/api/Query/Query6/Поломан Двигатель",
        type: 'GET',
        success: (response) => GetQuery6(response)
    })
})

// запросы 7
// 7.Количество рабочих каждой специальности на станции?
function GetQuery7(data) {
    $("#GetQuery7").html(
        data.reduce(
            (ans, elem) =>
                ans +
                `<tr>
                <td>${elem.id}</td>
                <td>${elem.enroller}</td>
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