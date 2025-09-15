/* Create Database and Tables for Practice */
CREATE DATABASE triggerAssignmentPractice;
USE triggerAssignmentPractice;

-- Creating PRODUCT Table
CREATE TABLE PRODUCT (
    PID INT PRIMARY KEY,
    PNAME VARCHAR(100),
    CATEGORY VARCHAR(50),
    PRICE MONEY,
    STOCK INT,
    SUPPLIER VARCHAR(100),
    LOCATION VARCHAR(50)
);

-- Insert sample data into PRODUCT
INSERT INTO PRODUCT VALUES
(201, 'Laptop', 'Electronics', 55000, 10, 'TechWorld', 'Mumbai'),
(202, 'Mobile', 'Electronics', 25000, 15, 'GadgetHub', 'Delhi'),
(203, 'Table', 'Furniture', 7000, 20, 'HomeDecors', 'Pune'),
(204, 'Chair', 'Furniture', 3000, 50, 'FurniKart', 'Chennai'),
(205, 'Shoes', 'Fashion', 4000, 25, 'StyleMart', 'Bangalore'),
(206, 'Watch', 'Fashion', 8000, 30, 'TrendyTime', 'Kolkata');

SELECT * FROM PRODUCT;

/* Q1. Create a trigger to display a message whenever a product's details are updated. */

    create trigger trgProductDetailsUpdated
    on product
    for update
    as
    begin
        print 'Products details are updated'
    end

    select * from product

    drop trigger trgProductDetailsUpdated

/* Q2. Create a trigger that shows newly inserted product records whenever a new product is added. */

    create trigger trgProductinserted
    on product
    for insert
    as
    begin
        print 'Products details are updated'
    end


insert into product values
(207)
  select * from product
/* Q3. Create a trigger that prints deleted product details whenever a product is removed from the inventory. */

/* Q4. Create an AUDIT table and a trigger that stores old price, new price, and PID whenever price changes. */

/* Q5. Create a trigger to record details of deleted products into the PRODUCT_AUDIT table. */

/* Q6. Create a trigger that prevents inserting or updating products with a negative price. */

/* Q7. Create a trigger that automatically updates the LAST_UPDATED date whenever product details are modified. */

/* Q8. Create an INSTEAD OF trigger that prevents price reduction — price can only increase or remain the same. */

/* Q9. Create a trigger to display both old and new stock values whenever a product's stock is updated. */

/* Q10. Create a trigger to track the number of products inserted per day and store that info in a PRODUCT_LOG table. */

/* Q11. Create a trigger on a VIEW (VW_PRODUCT_CATEGORY) that automatically inserts product details 
        into PRODUCT table when inserting via the view. */

/* Q12. Create an INSTEAD OF DELETE trigger on VW_PRODUCT_CATEGORY that deletes data from PRODUCT 
        when deleted from the view. */

/* Q13. Create an INSTEAD OF UPDATE trigger on VW_PRODUCT_CATEGORY that updates product category for a given product. */

/* Q14. Create a trigger to block price updates for products under the 'Electronics' category. */

/* Q15. Create a trigger that automatically copies deleted product details into a PRODUCT_BACKUP table before deletion. */

/* Q16. Create a trigger that prevents deleting any product whose price is above 50,000. */

/* Q17. Create a database-level trigger that restricts users from creating new tables in the database. */

/* Q18. Create a server-level trigger that blocks table creation on the entire SQL Server instance. */

/* Q19. Create a trigger that prevents dropping any table from the database. */

/* Q20. Create a trigger that automatically logs all inserted, updated, and deleted product details into a PRODUCT_HISTORY table. */
