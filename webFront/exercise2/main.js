document.getElementById("workingTest").innerHTML = "It works";

function retrieveAllContracts() {
    const targetUrl = "https://api.jcdecaux.com/vls/v3/contracts?apiKey=" + document.getElementById("apiKey").value;
    const requestType = "GET";

    const caller = new XMLHttpRequest();
    caller.open(requestType, targetUrl, true);
    caller.setRequestHeader("Accept", "application/json");
    caller.onload = contractsRetrieved;

    caller.send();
}

function contractsRetrieved() {
    const response = JSON.parse(this.responseText);
    console.log(response);
}
