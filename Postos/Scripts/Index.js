$(document).ready(function () {
    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution:
            '&copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors' +
            ', Tiles courtesy of <a href="https://geo6.be/">GEO-6</a>',
        maxZoom: 18
    }).addTo(map);
    cor($("#GC").val());
    cor($("#GA").val());
    cor($("#EC").val());
    cor($("#EA").val());

});
var azul = false;
var verde = false;
var laranja = false;
var vermelho = false;
var map = L.map('map').setView([-20.467524, -54.615538], 11);

function cor(texto) {
    var split = texto.split('|');
    if (split[2] == "azul" && !azul)
        blueMarker(split[0].replace(',', '.'), split[1].replace(',', '.'))
    if (split[2] == "verde" && !verde)
        greenMarker(split[0].replace(',', '.'), split[1].replace(',', '.'))
    if (split[2] == "vermelho" && !vermelho)
        redMarker(split[0].replace(',', '.'), split[1].replace(',', '.'))
    if (split[2] == "laranja" && !laranja)
        orangeMarker(split[0].replace(',', '.'), split[1].replace(',', '.'))
}

function greenMarker(lat,lng) {
    var greenIcon = new L.Icon({
        iconUrl: 'https://cdn.rawgit.com/pointhi/leaflet-color-markers/master/img/marker-icon-green.png',
        shadowUrl: 'https://cdnjs.cloudflare.com/ajax/libs/leaflet/0.7.7/images/marker-shadow.png',
        iconSize: [25, 41],
        iconAnchor: [12, 41],
        popupAnchor: [1, -34],
        shadowSize: [41, 41]
    });
    verde = true;
    L.marker([lat, lng], { icon: greenIcon }).addTo(map);
}
function redMarker(lat, lng) {
    var redIcon = new L.Icon({
        iconUrl: 'https://cdn.rawgit.com/pointhi/leaflet-color-markers/master/img/marker-icon-red.png',
        shadowUrl: 'https://cdnjs.cloudflare.com/ajax/libs/leaflet/0.7.7/images/marker-shadow.png',
        iconSize: [25, 41],
        iconAnchor: [12, 41],
        popupAnchor: [1, -34],
        shadowSize: [41, 41]
    });
    vermelho = true;
    L.marker([lat, lng], { icon: redIcon }).addTo(map);
}
function blueMarker(lat, lng) {
    var blueIcon = new L.Icon({
        iconUrl: 'https://cdn.rawgit.com/pointhi/leaflet-color-markers/master/img/marker-icon-blue.png',
        shadowUrl: 'https://cdnjs.cloudflare.com/ajax/libs/leaflet/0.7.7/images/marker-shadow.png',
        iconSize: [25, 41],
        iconAnchor: [12, 41],
        popupAnchor: [1, -34],
        shadowSize: [41, 41]
    });
    azul = true;
    L.marker([lat, lng], { icon: blueIcon }).addTo(map);
}
function orangeMarker(lat, lng) {
    var orangeIcon = new L.Icon({
        iconUrl: 'https://cdn.rawgit.com/pointhi/leaflet-color-markers/master/img/marker-icon-orange.png',
        shadowUrl: 'https://cdnjs.cloudflare.com/ajax/libs/leaflet/0.7.7/images/marker-shadow.png',
        iconSize: [25, 41],
        iconAnchor: [12, 41],
        popupAnchor: [1, -34],
        shadowSize: [41, 41]
    });
    laranja = true;
    L.marker([lat, lng], { icon: orangeIcon }).addTo(map);
}