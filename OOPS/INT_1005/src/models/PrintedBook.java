package models;

public class PrintedBook extends Book implements Discountable{

	int pages; 
	
	public PrintedBook(String title, String author, double price, int pages){
		super(title, author, price); 
		this.pages = pages; 
	}
	
	public void getDetails(){
		System.out.println(Colors.BLUE +"Title : "+Colors.RESET + Colors.GREEN+ title + Colors.RESET  );
		System.out.println(Colors.BLUE +"Author : "+Colors.RESET +Colors.GREEN+ author + Colors.RESET );
		System.out.println(Colors.BLUE +"Price : "+Colors.RESET + Colors.GREEN+ price + Colors.RESET );
		System.out.println(Colors.BLUE +"Book Pages : "+Colors.RESET +Colors.GREEN+ pages + Colors.RESET );
	}
	
	public void applyDiscount(double percent) {
		double actualPercent = percent * 100;
		double finalPrice = price * percent; 
		System.out.println(Colors.BLUE +"Before Discount Price : "+Colors.RESET +Colors.GREEN+ price + Colors.RESET );
		System.out.println(Colors.BLUE +actualPercent +"% Discount applied Successfully");
		System.out.println(Colors.BLUE +"The Final price of the Book is : "+Colors.RESET + Colors.GREEN+(price - finalPrice)  + Colors.RESET );
		System.out.println(); 
	}
	
}
