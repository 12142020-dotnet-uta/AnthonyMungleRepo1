"use strict";
function convert() {
    // resetting the html
    document.getElementById("result").innerHTML = '';
    // default variables
    var remainder;
    var dimes;
    var nickels;
    var pennies;
    var userInput = document.getElementById("numberInput").value;
    // setting the number we will test equal to the input * 100
    var input = Math.round(userInput * 100);
    // doing math to get number of dimes nickels and pennies
    dimes = Math.floor(input / 10);
    remainder = input % 10;
    nickels = Math.floor(remainder / 5);
    pennies = remainder % 5;
    // updaing DOM
    //updating header
    var headerHtml = document.createElement('h3');
    var headerText = document.createTextNode("$" + userInput + " broken down:");
    headerHtml.appendChild(headerText);
    document.getElementById("result").appendChild(headerHtml);
    // updateing dime
    var dimeHtml = document.createElement('p');
    var dimeText = document.createTextNode(dimes.toString() + " dimes");
    dimeHtml.appendChild(dimeText);
    document.getElementById("result").appendChild(dimeHtml);
    // updatiing nickel
    var nickelsHtml = document.createElement('p');
    var nickelText = document.createTextNode(nickels.toString() + " nickels");
    nickelsHtml.appendChild(nickelText);
    document.getElementById("result").appendChild(nickelsHtml);
    // updating penny
    var penniesHtml = document.createElement('p');
    var pennyText = document.createTextNode(pennies.toString() + " pennies");
    penniesHtml.appendChild(pennyText);
    document.getElementById("result").appendChild(penniesHtml);
    // setting the input box to blank
    document.getElementById("numberInput").value = '';
}
