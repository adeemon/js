let number=10; //Input number
function factorial(n) {
if (n!==0) {
  return n != 1 ? n * factorial(n - 1) : 1;
  } else {
    return 0;
  }
}
let result=factorial(number);
console.log (result);