let inputString='(){}[{}])';

const checkParentheses = inputString => {
  let flag=true;
  let arrPar=[];
  let openPar=['(','[','{'];
  let closePar=[')',']','}'];
  if (inputString.length>0) {
		for (let i=0;i<inputString.length;++i){
    	if (openPar.includes(inputString[i])) {
      	arrPar.push(inputString[i]);
      } else {
      	if (closePar.includes(inputString[i])) {
          if (openPar.indexOf(arrPar.pop())!==closePar.indexOf(inputString[i])) {
          	flag=false;
          }
      	}
      }
    }
  }
  if (flag) {
  	console.log(`Последовательность скобок верна`);
  } else {
  	console.log(`Последовательность скобок неверна`);
  }
}
checkParentheses(inputString);