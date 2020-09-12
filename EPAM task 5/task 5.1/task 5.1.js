let inputString = "У попа была собака";

function isLetter(c) {
    if (c)
        return c.toLowerCase() !== c.toUpperCase();
}

function deleteSameChars(inputStr) {
    let arrayOfSameWords = findSameChars(inputStr);
    let outputString = "";

    console.log(arrayOfSameWords);

    for (let i = 0; i < inputStr.length; ++i) {
        if (!arrayOfSameWords.includes(inputStr[i].toLowerCase())) {
            outputString += inputStr[i];
        }
    }
    return outputString;
}

function findSameChars(inputString) {
    let arrayOfSameWords = [];
    for (let i = 0; i < inputString.length - 1; ++i) {
        let symbol = inputString[i].toLowerCase();
        if (isLetter(inputString[i]) && !(arrayOfSameWords.includes(symbol))) {
            let counter = 1;
            let nextSymbol = inputString[i + counter].toLowerCase();

            while (isLetter(nextSymbol)) {
                if (symbol == nextSymbol) {
                    arrayOfSameWords.push(symbol);
                    break;
                }
                counter++;
                nextSymbol = inputString[i + counter];
            }
        }
    }
    return arrayOfSameWords;
}

console.log(deleteSameChars(inputString));