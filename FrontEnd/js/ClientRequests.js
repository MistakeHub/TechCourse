

// получить данные о клиентах


//добрвление клиента
function AddClient() {
    var surnamenp = document.getElementById("surnameNP").value;
    var phonenumber = document.getElementById("phoneNumber").value;
    var passport = document.getElementById("passport").value;
    var year = document.getElementById("year").value;
    var mounth = document.getElementById("mounth").value;
    var day = document.getElementById("day").value;
    var street = document.getElementById("street").value;
    var home = document.getElementById("home").value;
    var apartment = document.getElementById("apartment").value;

    $.ajax({
        url: "https://localhost:44354/api/Client",
        type: 'POST',
        data: {surnameNp:surnamenp, passport:passport, street:street, home:home,
               apartament:apartment,
               year:+year,
               mounth:+mounth,
               day:+day,
               phonenumber:phonenumber},
        success: (response) => alert("Добавлен")
    })
}

$(function () {
    $("#append").click(AddClient);
})

