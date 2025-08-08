class Book{

  String title;
  String author; 
  int price;

  Book(String bookTitle, String bookAuthor, int bookPrice){
    title = bookTitle; 
    author = bookAuthor; 
    price = bookPrice; 
  }

  void getInfo(){
    System.out.println(title + " "+author+ " "+price); 
  }

  public static void main(String args[]){
    Book bk = new Book("Get Epic Shit", "Ankur Warikoo", 300); 
    bk.getInfo(); 
  }
}