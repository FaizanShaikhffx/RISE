class Book1 {

String title;
String author;
int copiesAvailable;

Book1(String bookTitle, String bookAuthor, int bookCopiesAvailable){
  title = bookTitle; 
  author = bookAuthor; 
  copiesAvailable = bookCopiesAvailable; 
}

void issueBook(){
  if(copiesAvailable > 0){
    System.out.println("1 book issued"); 
    copiesAvailable = copiesAvailable - 1; 
    System.out.println("Now available books are : "+copiesAvailable); 
  }else{
    System.out.println("Not available"); 
  }
}

void diplayInfo(){
    System.out.println(title+ " "+author+" "+copiesAvailable); 
}

  public static void main(String args[]){
    Book1[] books = new Book1[4];
    books[0] = new Book1("Do Epic Shit" , "Ankur Wareeku", 5);
    books[1] = new Book1("Atomic Habits" , "James Clear", 3);
    books[2] = new Book1("IKIGAI" , "Hector Garcia", 2);
    books[3] = new Book1("IKIGAI" , "Hector Garcia", 2);


    System.out.println("All books details:"); 
    for(int i = 0; i<books.length; i++){
      books[i].diplayInfo(); 
    }
    
  }
}