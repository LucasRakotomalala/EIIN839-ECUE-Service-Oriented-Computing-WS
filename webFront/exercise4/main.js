function retrieveAllContracts() {
    const targetUrl = "https://api.jcdecaux.com/vls/v3/contracts?apiKey=" + document.getElementById("apiKey").value;
    const requestType = "GET";

    const caller = new XMLHttpRequest();
    caller.open(requestType, targetUrl, true);
    caller.setRequestHeader("Accept", "application/json");
    caller.onload = contractsRetrieved;

    caller.send();

    // Make impossible another retrieve of all contrats
    const retrieveContractsButton = document.getElementById("retrieveContractsButton");
    retrieveContractsButton.setAttribute("disabled", "");
}

function contractsRetrieved() {
    const response = JSON.parse(this.responseText);
    response.forEach(contract => addOption(contract.name.capitalize()));
}

String.prototype.capitalize = function () {
    return this.charAt(0).toUpperCase() + this.slice(1);
}

function retrieveContractStations() {
    const contract = document.getElementById("contracts-choice").value.toLowerCase();

    const targetUrl = "https://api.jcdecaux.com/vls/v3/stations?apiKey=" + document.getElementById("apiKey").value + "&contract=" + contract;
    const requestType = "GET";

    const caller = new XMLHttpRequest();
    caller.open(requestType, targetUrl, true);
    caller.setRequestHeader("Accept", "application/json");
    caller.onload = stationsRetrieved;

    caller.send();
}

let stations;

function stationsRetrieved() {
    stations = JSON.parse(this.responseText);
}

function addOption(contractName) {
    const newOption = document.createElement("option");
    newOption.setAttribute("value", contractName);

    const currentDiv = document.getElementById("contracts");
    currentDiv.appendChild(newOption);
}

function retrieveClosestStation() {
    const latitude = document.getElementById("latitude").value;
    const longitude = document.getElementById("longitude").value;

    let closestDistance = 0;
    let closestStation = null;
    let stationLatitude;
    let stationLongitude;

    stations.forEach((station) => {

        stationLatitude = station.position.latitude;
        stationLongitude = station.position.longitude;

        if (getDistanceFrom2GpsCoordinates(latitude, longitude, stationLatitude, stationLongitude) < closestDistance || closestDistance === 0) {
            closestStation = station;
            closestDistance = getDistanceFrom2GpsCoordinates(latitude, longitude, stationLatitude, stationLongitude);
        }
    });

    console.log(`Closest location of latitude ${latitude} and longitude ${longitude} is: ${closestStation.name}"`);
}


function getDistanceFrom2GpsCoordinates(lat1, lon1, lat2, lon2) {
    const earthRadius = 6371;
    const dLat = deg2rad(lat2 - lat1);
    const dLon = deg2rad(lon2 - lon1);
    const a =
        Math.sin(dLat / 2) * Math.sin(dLat / 2) +
        Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) *
        Math.sin(dLon / 2) * Math.sin(dLon / 2)
    ;
    const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    return earthRadius * c;
}

function deg2rad(deg) {
    return deg * (Math.PI / 180)
}
