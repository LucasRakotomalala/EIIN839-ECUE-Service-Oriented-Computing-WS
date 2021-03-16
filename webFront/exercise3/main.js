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

String.prototype.capitalize = function() {
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

function stationsRetrieved() {
    const response = JSON.parse(this.responseText);
    console.log(response);
}

function addOption(option) {
    const newOption = document.createElement("option");
    newOption.setAttribute("value", option);

    const currentDiv = document.getElementById("contracts");
    currentDiv.appendChild(newOption);
}
