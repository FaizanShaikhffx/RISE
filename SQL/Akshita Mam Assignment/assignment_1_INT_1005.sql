CREATE DATABASE assignment_1

USE assignment_1

CREATE TABLE UnnormalizedOrderProduct (
    Order_No INT,
    Prod_No VARCHAR(10),
    Cust_No INT,
    Name VARCHAR(255),
    Addr VARCHAR(255),
    City VARCHAR(100),
    St VARCHAR(50),
    Zip INT,
    Order_Date DATE,
    Promised_Date DATE,
    Desc VARCHAR(100),
    Qty_Ord INT,
    Unit_Price MONEY
)

INSERT INTO UnnormalizedOrderProduct VALUES
(10001, 'P101', 501, 'Raj Traders', '12 MG Road', 'Mumbai', 'MH', 400001, '2025-07-01', '2025-07-05', 'Wooden Shelf', 4, 1500),
(10001, 'P102', 501, 'Raj Traders', '12 MG Road', 'Mumbai', 'MH', 400001, '2025-07-01', '2025-07-05', 'Steel Cabinet', 2, 2200),
(10001, 'P103', 501, 'Raj Traders', '12 MG Road', 'Mumbai', 'MH', 400001, '2025-07-01', '2025-07-05', 'Dining Table', 1, 7500),
(10002, 'P104', 502, 'Kumar Enterprises', '88 Nehru Street', 'Delhi', 'DL', 110001, '2025-07-03', '2025-07-08', 'Office Chair', 2, 3200),
(10002, 'P101', 502, 'Kumar Enterprises', '88 Nehru Street', 'Delhi', 'DL', 110001, '2025-07-03', '2025-07-08', 'Wooden Shelf', 8, 1500),
(10003, 'P104', 501, 'Raj Traders', '12 MG Road', 'Mumbai', 'MH', 400001, '2025-07-05', '2025-07-10', 'Office Chair', 6, 3200),
(10004, 'P102', 503, 'Sharma & Sons', '45 Residency Road', 'Bengaluru', 'KA', 560025, '2025-07-10', '2025-07-15', 'Steel Cabinet', 1, 2200),
(10004, 'P101', 503, 'Sharma & Sons', '45 Residency Road', 'Bengaluru', 'KA', 560025, '2025-07-10', '2025-07-15', 'Wooden Shelf', 1, 1500)


CREATE TABLE Customers (
    Cust_No INT PRIMARY KEY,
    Name VARCHAR(255),
    Addr VARCHAR(255),
    City VARCHAR(100),
    St VARCHAR(50),
    Zip INT
)

INSERT INTO Customers VALUES
(501, 'Raj Traders', '12 MG Road', 'Mumbai', 'MH', 400001),
(502, 'Kumar Enterprises', '88 Nehru Street', 'Delhi', 'DL', 110001),
(503, 'Sharma & Sons', '45 Residency Road', 'Bengaluru', 'KA', 560025)

CREATE TABLE Products (
    Prod_No VARCHAR(10) PRIMARY KEY,
    Desc VARCHAR(100)
)

INSERT INTO Products VALUES
('P101', 'Wooden Shelf'),
('P102', 'Steel Cabinet'),
('P103', 'Dining Table'),
('P104', 'Office Chair')

CREATE TABLE Orders (
    Order_No INT PRIMARY KEY,
    Cust_No INT,
    Order_Date DATE,
    Promised_Date DATE,
    FOREIGN KEY (Cust_No) REFERENCES Customers(Cust_No)
)

INSERT INTO Orders VALUES
(10001, 501, '2025-07-01', '2025-07-05'),
(10002, 502, '2025-07-03', '2025-07-08'),
(10003, 501, '2025-07-05', '2025-07-10'),
(10004, 503, '2025-07-10', '2025-07-15')

CREATE TABLE OrderDetails (
    Order_No INT,
    Prod_No VARCHAR(10),
    Qty_Ord INT,
    Unit_Price MONEY,
    PRIMARY KEY (Order_No, Prod_No),
    FOREIGN KEY (Order_No) REFERENCES Orders(Order_No),
    FOREIGN KEY (Prod_No) REFERENCES Products(Prod_No)
)

INSERT INTO OrderDetails VALUES
(10001, 'P101', 4, 1500),
(10001, 'P102', 2, 2200),
(10001, 'P103', 1, 7500),
(10002, 'P104', 2, 3200),
(10002, 'P101', 8, 1500),
(10003, 'P104', 6, 3200),
(10004, 'P102', 1, 2200),
(10004, 'P101', 1, 1500)

SELECT * FROM Customers
SELECT * FROM Products
SELECT * FROM Orders
SELECT * FROM OrderDetails