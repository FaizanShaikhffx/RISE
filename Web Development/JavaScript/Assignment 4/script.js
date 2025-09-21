
let DolphinScore = [96, 108, 89];
let KoalasScore = [88, 91, 110];

let averageDolphinScore = 0; 
let averageKoalasScore = 0;

let sum = 0; 
let sum2 = 0; 

function calculateDolphinsScore(DolphinScore){

  for(let i = 0; i<DolphinScore.length; i++){
    sum = sum + DolphinScore[i]; 
  }

  averageDolphinScore = (sum / (DolphinScore.length)); 
  
  return averageDolphinScore
}


function calculateKoalaScore(KoalasScore){


  for(let i = 0; i<KoalasScore.length; i++){
    sum2 = sum2 + KoalasScore[i];
  }
  
  averageKoalasScore = sum2 / KoalasScore.length;

  console.log(averageKoalasScore);

}

function checkHighScore(averageDolphinScore, averageKoalasScore){
  if(averageDolphinScore > averageKoalasScore){
    console.log("The winner is Dolphins with "+averageDolphinScore+" score");
  }else if(averageDolphinScore > averageKoalasScore){
    console.log("The winner is Koalas with "+averageKoalasScore+" score");
  }else if(averageDolphinScore == averageKoalasScore){
    console.log("The match is draw");
  }
}


calculateDolphinsScore(DolphinScore);



let result =  calculateDolphinsScore(DolphinScore);
console.log(result); 



























































































