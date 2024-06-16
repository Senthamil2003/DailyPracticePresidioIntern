// // function checkingEvenNumbers(num)
// // {
// //     return num%2==0//boolean
// // }
// // function checkPositive(num){
// //     return num>=0
// // }

// // function filteringEvenNumbers(numbers,callbackFunc)
// // {
// //     let numberArray=[]
// //     for(let value of numbers)
// //     {
// //         if(callbackFunc(value))
// //             numberArray.push(value)
// //     }
// //     return (data)=> console.log(data,numberArray)
// // }

// // let arrayOfNumbers=[22,45,99,3,8,44,-2,-4,-9]
// // filteringEvenNumbers(arrayOfNumbers,checkingEvenNumbers)("sentha")
// // let result=filteringEvenNumbers(arrayOfNumbers,checkPositive)
// // result("hi")

// // const cart = [
// //     { name: 'Apple', quantity: 2, pricePerUnit: 3 },
// //     { name: 'Banana', quantity: 5, pricePerUnit: 1 },
// //     { name: 'Cherry', quantity: 10, pricePerUnit: 0.5 }
// //   ];

// //   // Step 1: Use map to calculate total price for each item
// //   const itemTotals = cart.map(item => item.quantity * item.pricePerUnit);
// //   console.log(itemTotals)

// //   // Step 2: Use reduce to sum up the total prices
// //   const totalPrice = itemTotals.reduce((accumulator, currentValue) => accumulator + currentValue);

// //   console.log(totalPrice); // Output: 16
// const people = [
//   { name: "Alice", age: 17 },
//   { name: "Bob", age: 22 },
//   { name: "Charlie", age: 15 },
//   { name: "David", age: 19 },
//   { name: "Eve", age: 30 },
// ];

// // Step 1: Use filter to get an array of adults
// const adults = people.filter((person) => person.age >= 18);

// // Step 2: Use map to create a message for each adult
// const adultMessages = adults.map(
//   (adult) => `${adult.name} is ${adult.age} years old`
// );

// console.log(adultMessages);
// // Output: ["Bob is 22 years old", "David is 19 years old", "Eve is 30 years old"]
// const result1 = people.map((sample) => {
//   if (sample.age > 18) return sample.age + 100;
// });
// console.log(result1);

// let arrayOfNumbers = [22, 45, 99, 3, 8, 44];
// arrayOfNumbers.sort((numOne, numTwo) => numOne - numTwo);
// console.log(arrayOfNumbers);

// function checkmod(num1,num2){
//     return num1>num2;
// }

// let arrayOfNumbers=[22,45,99,3,8,44]

// let newArray = arrayOfNumbers.map(checkmod)

// console.log(newArray)
const accessingParaElement=()=>{
    let para=document.getElementById('para1')
    console.log(para)
}

const nodeList=document.getElementsByName('gen')
console.log(nodeList)

const tagList=document.getElementsByTagName('P')
console.log(tagList)

const classList=document.getElementsByClassName('demo')
console.log(classList)

const paraId=document.querySelectorAll('.para1')
console.log(paraId)