
class Game{

  static String game = "GTA 5";
  String game1 = "San Andress"; 
 
  // static void play(){
  //   System.out.println("You are playing : "+game1); 
  // }

  void showArray(int ...arr){
    for(int i = 0; i<arr.length; i++){
      System.out.print(" "+arr[i]); 
    }
  }
 
  public static void main(String args[]){
    // Game.play(); 
    Game g1 = new Game(); 
    g1.showArray(0, 1, 2, 3, 4, 5); 
  }
}