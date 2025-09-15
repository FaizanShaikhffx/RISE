package models;

public class EBook extends Book implements Discountable {
	
	double fileSize; 
	
	public EBook(String title, String author, double price, double fileSize){
		super(title, author, price); 
		this.fileSize = fileSize; 
	}
	
	public void getDetails(){
		
		System.out.println(Colors.BLUE+"Title : " +Colors.RESET + Colors.GREEN+ title + Colors.RESET );
		System.out.println(Colors.BLUE+ "Author : " +Colors.RESET+ Colors.GREEN+ author + Colors.RESET);
		System.out.println(Colors.BLUE+ "File Size in MB : "+Colors.RESET+Colors.GREEN+ fileSize + Colors.RESET);
	}
	
	public void applyDiscount(double percent) {
		double actualPercent = percent * 100;
		double finalPrice = price * percent; 
		System.out.println(Colors.BLUE+ "Before Discount Price : "+Colors.RESET+Colors.GREEN+ price + Colors.RESET);
		System.out.println(Colors.BLUE+ actualPercent +"% Discount applied Successfully");
		System.out.println(Colors.BLUE+"The Final price of the Book is : "+Colors.RESET+ Colors.GREEN +(price - finalPrice)+Colors.RESET);
		System.out.println(); 
		
	}
	
}
