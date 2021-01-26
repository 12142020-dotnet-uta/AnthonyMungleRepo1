function convert() {

    // resetting the html
    (<HTMLInputElement>document.getElementById("result")).innerHTML = '';
    
    // default variables
    let remainder:number;
    let dimes:number;
    let nickels:number;
    let pennies:number;
    let userInput:any = (<HTMLInputElement>document.getElementById("numberInput")).value;

    // setting the number we will test equal to the input * 100
    let input:number =  Math.round(userInput * 100);

    // doing math to get number of dimes nickels and pennies
    dimes = Math.floor(input / 10);
    remainder = input % 10;
    nickels = Math.floor(remainder / 5);
    pennies = remainder % 5;    

    // updaing DOM
    //updating header
    let headerHtml = document.createElement('h3');
    let headerText = document.createTextNode(`$${userInput} broken down:`);
    headerHtml.appendChild(headerText);
    (<HTMLInputElement>document.getElementById("result")).appendChild(headerHtml);
    // updateing dime
    let dimeHtml = document.createElement('p');
    let dimeText = document.createTextNode(`${dimes.toString()} dimes`);
    dimeHtml.appendChild(dimeText);
    (<HTMLInputElement>document.getElementById("result")).appendChild(dimeHtml);

    // updatiing nickel
    let nickelsHtml = document.createElement('p');
    let nickelText = document.createTextNode(`${nickels.toString()} nickels`);
    nickelsHtml.appendChild(nickelText);
    (<HTMLInputElement>document.getElementById("result")).appendChild(nickelsHtml);

    // updating penny
    let penniesHtml = document.createElement('p');
    let pennyText = document.createTextNode(`${pennies.toString()} pennies`);
    penniesHtml.appendChild(pennyText);
    (<HTMLInputElement>document.getElementById("result")).appendChild(penniesHtml);

    // setting the input box to blank
    (<HTMLInputElement>document.getElementById("numberInput")).value = '';

}

