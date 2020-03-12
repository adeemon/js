let number=0; //Input number
number = prompt ('Ввод данных:','Введите число, для которого нужно вычислить факториал')
function factorial(n) {
if (n!==0) {
  return n != 1 ? n * factorial(n - 1) : 1;
  } else {
    return 0;
  }
}
let result=factorial(number);
console.log (result);