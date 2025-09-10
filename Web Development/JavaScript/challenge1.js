// Data 1------------------------------
let mark = {
  mass: 78,
  height: 1.69
}
let john = {
  mass: 92,
  height: 1.95
}

function calculateBMI(mass, height){
  return mass / (height * height)
}

let res = calculateBMI(mark.mass, mark.height);
console.log(res);
let res2 = calculateBMI(john.mass, john.height);
console.log(res2);

let markHigherBMI = res > res2
markHigherBMI ? console.log("Mark Is Higher") : console.log("John Is Higher");


// Data 2------------------------------

let marks = {
  mass: 95,
  height: 1.88
}
let johns = {
  mass: 85,
  height: 1.76
}

function calculateBMI(mass, height){
  return mass / (height * height)
}

let res3 = calculateBMI(marks.mass, marks.height);
console.log(res);
let res4 = calculateBMI(johns.mass, johns.height);
console.log(res2);

let markHigherBMI2 = res3 > res4
markHigherBMI ? console.log("Marks Is Higher") : console.log("Johns Is Higher");

