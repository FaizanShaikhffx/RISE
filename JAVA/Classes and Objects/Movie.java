class Movie {

  String title; 
  String director; 
  float rating; 

  Movie(String movieTitle, String movieDirector, int movieRating){
    title = movieTitle; 
    director = movieDirector;
    rating = movieRating;
  }

  void getInfo(){
    if(rating > 8){
      System.out.println("Highly rated"); 
    }else{
      System.out.println("Average"); 
    }

  }

  public static void main(String args[]){
    Movie m1 = new Movie("Dune", "pata nahi", 8);
    m1.getInfo(); 
  }

}