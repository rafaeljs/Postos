$(document).ready(function () {
    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution:
            '&copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors' +
            ', Tiles courtesy of <a href="https://geo6.be/">GEO-6</a>',
        maxZoom: 18
    }).addTo(map);
    map.on('click', onMapClick);
    $(".combustiveis").inputmask('decimal', {
        'alias': 'numeric',
        'groupSeparator': '.',
        'autoGroup': true,
        'digits': 4,
        'radixPoint': ",",
        'digitsOptional': false,
        'allowMinus': false,
        'prefix': 'R$ ',
        'placeholder': ''
    });
});
var map = L.map('map').setView([-20.467524, -54.615538], 11);

var popup = L.popup();

function onMapClick(e) {
    popup
        .setLatLng(e.latlng)
        .setContent("Coordenadas " + e.latlng.toString())
        .openOn(map);
    $("#latlong").val(e.latlng.lat + "," + e.latlng.lng);
    $("#latlong").removeClass("is-invalid");
}

function setMarker() {
    var latLong = $("#latlong").val().split(',');
    if (!isNaN(latLong[0]) && !isNaN(latLong[1])) {
        popup
            .setLatLng({
                lat: parseFloat(latLong[0]),
                lng: parseFloat(latLong[1])
            })
            .setContent("Coordenadas LatLng(" + latLong[0] + "," + latLong[1] + ")")
            .openOn(map);
        $("#latlong").removeClass("is-invalid");
    }
    else {
        $("#latlong").addClass("is-invalid");
    }
}

function CadastrarPosto() {
    if (validarCampos()) {
        $('#modalCarregando').modal("show");
        var latLong = $("#latlong").val().split(',');
        $("#alertE").hide();
        $.ajax({
            type: "POST",
            url: "CadastrarPosto",
            data: {
                Nome: $("#nome").val(),
                gasComum: $("#gasComum").val().replace("R$",""),
                gasAdit: $("#gasAdit").val().replace("R$", ""),
                etanolComum: $("#etanolComum").val().replace("R$", ""),
                etanolAdit: $("#etanolAdit").val().replace("R$", ""),
                latitude: parseFloat(latLong[0]),
                longitude: parseFloat(latLong[1])
            },
            success: function (data) {
                $('#modalCarregando').modal("hide");
                if (data.Status == "Ok") {
                    $("#alertS").show();
                    setTimeout(function () { window.location.reload() }, 2000);
                }
                else {
                    $("#alertE").show();
                    $("#msgErro").text(data.Mensagem);
                }
            },
            error: function (data) {
                $("#alertE").show();
                $("#msgErro").text(data.Mensagem);
                $('#modalCarregando').modal("hide");
            }
        });
    }
    else {
        $("#alertE").show();
        $("#msgErro").text(" Um campo ou mais não esta preenchido corretamente!");
    }
}

function validarCampos() {
    var retorno = true;
    if ($("#nome").val() == "") {
        retorno = false;
        $("#nome").addClass("is-invalid");
    }
    else {
        $("#nome").removeClass("is-invalid");
    }

    if ($("#gasComum").val() == "" || $("#gasComum").val() == "R$ ,") {
        retorno = false;
        $("#gasComum").addClass("is-invalid");
    }
    else {
        $("#gasComum").removeClass("is-invalid");
    }

    if ($("#gasAdit").val() == "" || $("#gasAdit").val() == "R$ ,") {
        retorno = false;
        $("#gasAdit").addClass("is-invalid");
    }
    else {
        $("#gasAdit").removeClass("is-invalid");
    }

    if ($("#etanolComum").val() == "" || $("#etanolComum").val() == "R$ ,") {
        retorno = false;
        $("#etanolComum").addClass("is-invalid");
    }
    else {
        $("#etanolComum").removeClass("is-invalid");
    }

    if ($("#etanolAdit").val() == "" || $("#etanolAdit").val() == "R$ ,") {
        retorno = false;
        $("#etanolAdit").addClass("is-invalid");
    }
    else {
        $("#etanolAdit").removeClass("is-invalid");
    }
    if ($("#latlong").hasClass("is-invalid")) {
        retorno = false;
    }
    if ($("#latlong").val() == "") {
        retorno = false;
        $("#latlong").addClass("is-invalid");
    }
    return retorno;
}

function preencherCampos() {
    if ($("#select").val() != 0) {
        var split = $("#select").val().split('|');
        $("#nome").val(split[1]);
        $("#gasComum").val(split[2]);
        $("#gasAdit").val(split[3]);
        $("#etanolComum").val(split[4]);
        $("#etanolAdit").val(split[5]);
        $("#latlong").val(split[6].replace(',', '.') + "," + split[7].replace(',', '.'));
        setMarker();
    }
}

function EditarPosto() {
    if ($("#select").val() != 0) {
        if (validarCampos()) {
            $('#modalCarregando').modal("show");
            var latLong = $("#latlong").val().split(',');
            $("#alertE").hide();
            $.ajax({
                type: "POST",
                url: "SalvarEditarPosto",
                data: {
                    PostoId: $("#select").val().split('|')[0],
                    Nome: $("#nome").val(),
                    gasComum: $("#gasComum").val().replace("R$", ""),
                    gasAdit: $("#gasAdit").val().replace("R$", ""),
                    etanolComum: $("#etanolComum").val().replace("R$", ""),
                    etanolAdit: $("#etanolAdit").val().replace("R$", ""),
                    latitude: parseFloat(latLong[0]),
                    longitude: parseFloat(latLong[1])
                },
                success: function (data) {
                    $('#modalCarregando').modal("hide");
                    if (data.Status == "Ok") {
                        $("#alertS").show();
                        $("#msgSucesso").text(" Posto editado com sucesso!");
                        setTimeout(function () { window.location.reload() }, 2000);
                    }
                    else {
                        $("#alertE").show();
                        $("#msgErro").text(data.Mensagem);
                    }
                },
                error: function (data) {
                    $("#alertE").show();
                    $("#msgErro").text(data.Mensagem);
                    $('#modalCarregando').modal("hide");
                }
            });
        }
        else {
            $("#alertE").show();
            $("#msgErro").text(" Um campo ou mais não esta preenchido corretamente!");
        }
    }
    else {
        $("#alertE").show();
        $("#msgErro").text(" Selecione um registro para editar!");
    }
}

function ExcluirPosto() {
    if ($("#select").val() != 0) {
        $('#modalCarregando').modal("show");
        $.ajax({
            type: "POST",
            url: "ExcluirPosto",
            data: {
                PostoId: $("#select").val().split('|')[0]
            },
            success: function (data) {
                $('#modalCarregando').modal("hide");
                if (data.Status == "Ok") {
                    $("#alertS").show();
                    $("#msgSucesso").text(" Posto excluido com sucesso!");
                    setTimeout(function () { window.location.reload() }, 2000);
                }
                else {
                    $("#alertE").show();
                    $("#msgErro").text(data.Mensagem);
                }
            },
            error: function (data) {
                $("#alertE").show();
                $("#msgErro").text(data.Mensagem);
                $('#modalCarregando').modal("hide");
            }
        });
    }
    else {
        $("#alertE").show();
        $("#msgErro").text(" Selecione um registro para excluir!");
    }
}