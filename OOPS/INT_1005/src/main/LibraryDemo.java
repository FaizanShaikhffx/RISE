package main;

import models.*; 

public class LibraryDemo {

	public static void main(String args[]) {
		
		System.out.println(Colors.YELLOW+"========================================="+Colors.RESET);
		System.out.println(Colors.RED+ "        Library Management System       " + Colors.RESET);
		System.out.println(Colors.YELLOW+"========================================="+ Colors.RESET);
		
		Book b1 = new EBook("Do Epic Shit", "Ankur Wareeku", 400, 20); 
		Book b2 = new EBook("EKIGAI", "Anonymous", 500, 15); 
		
		Book p1 = new PrintedBook("Do Epic Shit", "Ankur Wareeku", 400, 250);
		Book p2 = new PrintedBook("EKIGAI", "Anonymous", 300, 270);
		
		Book arr[] = {b1, b2, p1, p2}; 
		
		for(int i = 0; i<arr.length; i++) {
			arr[i].getDetails();
			
			if(arr[i] instanceof Discountable) {
				((Discountable)  arr[i]).applyDiscount(0.1); 
			}
		}
	}
}
