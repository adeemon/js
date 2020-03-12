let inputString='Любви любви надежды тихой СЛАВЫ СлавЫ';

const findAloneWords = inputString => {
  inputString=inputString.toLowerCase();
  let arrString=inputString.split(' ');
  let arrOutput=[];
  if (arrString.length>0) {
   arrString.forEach(arrElement => {
     let indexOne=arrString.indexOf(arrElement);
     let indexTwo=arrString.lastIndexOf(arrElement);
     if (indexOne===indexTwo) {
         arrOutput.push(arrElement);
     }
   })
   console.log(arrOutput);
  }
}
findAloneWords(inputString);