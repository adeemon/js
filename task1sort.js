let arrNumber=[1,5,7,1111,5332,712,231321,51331,777,8,9,0];
//метод массивов .sort() помог бы в решении этой задачи

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

console.log(arrNumber);