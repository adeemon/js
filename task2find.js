let arrNumber=[1,5,7,1111,5332,712,231321,51331,777,8,9,0];
//метод массивов js .includes() вернул бы true, если элемент принадлежит, и false, если нет

const sortBubble = (arr, arrLength) => {
  for (let i=0;i<arrLength;++i) {
  	for (let j=arrLength-1;j>i;--j) {
    	if (arr[j-1]>arr[j]) {
      	let buf;
      	buf=arr[j-1];
        arr[j-1]=arr[j];
        arr[j]=buf;
      }
    }
  }
}
sortBubble(arrNumber, arrNumber.length);

const isExists = (arr, numberForFind) => {
	let flag=false;
	arr.forEach(arrElement => {
  	if (arrElement===numberForFind) flag=true; 
  })
  if (flag) {console.log(`Искомое число есть в массиве`);
  } else {
  	console.log(`Искомое число в массиве отсутствует`);
  }
}

isExists(arrNumber,1);