let tempMessage = "3.5 +4*10-5.3 /5 ="


function calculateString (inputString) 
{
  if (inputString.length<2)
  {
    console.log("Wrong input string");
    return;
  }

  let arrayOfNumbers = breakToNumbers(inputString);
  let arrayOfActions = breakToActions(inputString);

  let startAmount=arrayOfNumbers[0];
  let totalAmount=arrayOfNumbers[0];

  for (let i = 0; i < arrayOfActions.length; ++i)
  {
    if (arrayOfActions[i] === "=")
    {
      console.log(tempMessage, totalAmount.toFixed(2));
      return totalAmount.toFixed(2);
    }
    else
    {
      console.log(totalAmount, arrayOfActions[i], arrayOfNumbers[i+1]);
      totalAmount = doCalculate(arrayOfActions[i], totalAmount, arrayOfNumbers[i+1]);
    }
  }
}

calculateString(tempMessage);

function breakToNumbers (inputString)
{
  let regFloatNumber = new RegExp ("[0-9.]");
  let arrayOfNumbers = [];

  let newNumber = "";
  for (let i = 0; i < inputString.length; ++i)
  {
    if (regFloatNumber.exec(inputString[i]))
    {
      newNumber+=inputString[i];
    }
    else
    {
      if (newNumber.length > 0)
      {
        arrayOfNumbers.push(parseFloat(newNumber));
        newNumber="";
      }
    }
  }
  return arrayOfNumbers;
}

function breakToActions (inputString)
{
  let regMathAcctions = new RegExp ("[*+-/=]");
  let arrayOfActions = [];

  for (let i = 0; i < inputString.length; ++i)
  {
    if (regMathAcctions.exec(inputString[i]))
    {
      if (inputString[i]!=='.')
      {
        arrayOfActions.push(inputString[i]);
      }
    }
  }
  return arrayOfActions;
}

function doCalculate(action, firstNumber, secondNumber)
{
  switch (action)
  {
    case '+':
    {
       return firstNumber+secondNumber;
    }
    case '-':
    {
       return firstNumber-secondNumber;
    }
    case '*':
    {
       return firstNumber*secondNumber;
    }
    case '/':
    {
       return firstNumber/secondNumber;
    }
    default:
    {
      console.log("Wrong action");
    }
  }
}

