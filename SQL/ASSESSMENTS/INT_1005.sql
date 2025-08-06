--CreateDBwith“YourName”

CREATE DATABASE FAIZAN
USE FAIZAN

▪ Savethefilewith“YourName_ID”.sqlextension
▪ Mentionthequerybeforeexecuting


CreateatablenamedEmployeewiththefollowingcolumns, ignoreifalreadyhaving:
• EmployeeID
• EmployeeName
• Department
• DOJ
• ProjectName
• ProjectID

CREATE TABLE EMPLOYEE(
EmployeeID int, 
EmployeeName varchar(255),
Department varchar(255),
DOJ DATE DEFAULT GETDATE(),
ProjectName varchar(255),
ProjectID int
)

--1. Insert at least 6 records in employee table.
INSERT INTO EMPLOYEE VALUES
(2, 'ROHAN', 'AI','2025-06-04', 'REACT', 102),
(3, 'MIHIR', 'CLOUD','2025-02-25', 'REACT', 103),
(4, 'MOHAN', 'FULL-STACK','2025-03-22', 'REACT', 104),
(5, 'SAHIL', 'DEVOPS','2025-04-15', 'REACT', 105),
(6, 'SURESH', 'FLUTTER','2025-05-18', 'REACT', 106),
(7, 'FARHAN', 'AI','2025-11-12', 'REACT', 107)

SELECT * FROM EmployeeDetails

--2. How can you modify the column EmployeeName to increase its length from 100 to 150 characters.

--ANSWER : WE CAN MODIFY THE NAME OF THE COLUMN USING STORED PROCEDURE, 
-- SYNTAX :    SP_RENAME 'TABLENAME.COLUMNNAME' 'COLUMN NAME'
			SP_RENAME 'EMPLOYEE.EmployeeName' 'NameOfEmployee'
			--it will change the name of the column
			--to increase leangth 
			EmployeeName varchar(100) to 
			EmployeeName varchar(150),
	

	ALTER TABLE EMPLOYEEDETAILS
	MODIFY COLUMN EmployeeName VARCHAR(105)

--3. Write a query to rename the table Employee to EmployeeDetails.
SP_RENAME 'Employee', 'EmployeeDetails'



--4. Write a query to update the Department of an employee whose EmployeeID is 101 to ‘HR’.

SELECT * FROM EmployeeDetails

update EmployeeDetails
set Department = 'HR'
where EmployeeID = 101


select * from EmployeeDetails


--5. Write a query to delete all employees who joined before '2022-01-01'.

DELETE FROM EmployeeDetails
WHERE DOJ < '2022-01-01'


--6. Find the Department and the number of employees in each department.

	SELECT DEPARTMENT, COUNT(EMPLOYEENAME) AS NUMBER_OF_EMPLOYEES FROM EMPLOYEEDETAILS
	GROUP BY DEPARTMENT

	SELECT * FROM EMPLOYEEDETAILS


--7. Write a query to get employees who are either in the ‘IT’ or ‘HR’ department.
	
	SELECT EMPLOYEENAME, DEPARTMENT FROM EMPLOYEEDETAILS
	WHERE DEPARTMENT IN('IT', 'HR')



--8. Write a query to get employees who are NOT in the ‘Marketing’ department.

SELECT EMPLOYEENAME, DEPARTMENT FROM EMPLOYEEDETAILS
WHERE DEPARTMENT NOT IN('MARKETING')


--9. Write a query to get all employees who joined between '2022-01-01' and '2023-01-01'.

SELECT * FROM EMPLOYEEDETAILS
WHERE DOJ > '2022-01-01' AND DOJ < '2023-01-01' 


--10. Find pairs of employees who work in the same Department but on different ProjectName.

SELECT EMPLOYEENAME, DEPARTMENT, PROJECTNAME FROM EMPLOYEEDETAILS
WHERE COUNT(DEPARTMENT) > 2
GROUP BY EMPLOYEENAME

--11. Write a query to retrieve all employees who do not have an assigned ProjectID.


SELECT * FROM EMPLOYEEDETAILS

SELECT EMPLOYEENAME, PROJECTNAME  FROM EMPLOYEEDETAILS
WHERE PROJECTNAME IS NULL


--12. For each ProjectName, count the number of employees assigned to it.

SELECT PROJECTNAME, COUNT(EMPLOYEENAME) AS NO_OF_EMPLOYEES FROM EMPLOYEEDETAILS
GROUP BY PROJECTNAME

SELECT * FROM EMPLOYEEDETAILS


--13. For each Department, find the earliest and most recent joining dates.

	SELECT DEPARTMENT, DOJ FROM EMPLOYEEDETAILS
	ORDER BY DOJ DESC, DEPARTMENT ASC 
	

--14. List all Departments that have more than 2 employees.


SELECT DEPARTMENT, COUNT(EMPLOYEENAME) AS NO_OF_EMPLOYEES FROM EMPLOYEEDETAILS
GROUP BY DEPARTMENT
HAVING COUNT(EMPLOYEENAME)  >2


--15. For each ProjectName, count the number of employees assigned to it.


SELECT PROJECTNAME, COUNT(EMPLOYEENAME) AS NO_OF_EMPLOYEES FROM EMPLOYEEDETAILS
GROUP BY PROJECTNAME

SELECT * FROM EMPLOYEEDETAILS