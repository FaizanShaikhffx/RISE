package models;

public abstract class Book {
	String title; 
	String author; 
	double price; 
	
	Book(String title, String author, double price){
		this.title = title; 
		this.author = author;
		this.price = price; 
	}
	
	public abstract void getDetails(); 

}

