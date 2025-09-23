let arr = [10, 20, 30, 40];

// arr.unshift(5); 

// console.log(arr.includes(40)); 

// arr.forEach((item)=>(
//   console.log(item * 2)
// ))





let reducedArray = arr.reduce((acc, curr) => acc + curr, 0); 

console.log(reducedArray);