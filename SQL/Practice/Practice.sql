-- Create a new database
CREATE DATABASE CompanyDB;
USE CompanyDB;

-- Create Departments Table
CREATE TABLE Departments (
    DeptID INT PRIMARY KEY,
    DeptName VARCHAR(100) UNIQUE NOT NULL,
    Location VARCHAR(100)
);

-- Insert Sample Departments
INSERT INTO Departments (DeptID, DeptName, Location) VALUES
(1, 'IT', 'Mumbai'),
(2, 'HR', 'Pune'),
(3, 'Finance', 'Delhi'),
(4, 'Sales', 'Bangalore');

-- Create Employees Table (Foreign Key → Departments)
CREATE TABLE Employees (
    EmpID INT PRIMARY KEY,
    EmpName VARCHAR(100) NOT NULL,
    DeptID INT FOREIGN KEY REFERENCES Departments(DeptID),
    Salary DECIMAL(10,2),
    JoiningDate DATE,
    JobTitle VARCHAR(50)
);

-- Insert Sample Employees
INSERT INTO Employees (EmpID, EmpName, DeptID, Salary, JoiningDate, JobTitle) VALUES
(101, 'Rahul Sharma', 1, 60000, '2020-01-15', 'Software Engineer'),
(102, 'Priya Mehta', 2, 45000, '2021-03-10', 'HR Manager'),
(103, 'Amit Verma', 3, 70000, '2019-07-23', 'Financial Analyst'),
(104, 'Neha Singh', 1, 55000, '2022-06-05', 'Full Stack Developer'),
(105, 'Rohit Kumar', 4, 40000, '2023-01-17', 'Sales Executive'),
(106, 'Anjali Gupta', 3, 80000, '2018-04-12', 'Finance Lead'),
(107, 'Vikram Sinha', 4, 42000, '2021-09-09', 'Sales Manager');

/* Q1. Create a stored procedure that accepts Department Name as INPUT 
        and returns the total number of employees in that department using an OUTPUT parameter. */


        alter procedure spGetTotalEmployee
        @department varchar(255),
        @totalEmployee int output
        as
        begin
            select @totalEmployee = count(e.empID) from employees e
            join departments d
            on e.deptId = d.deptID
            where d.deptName = @department
        end

        declare @res int
        exec spGetTotalEmployee 'it', @totalEmployee = @res output
        select @res as totalEmployee

    
/* Q2. Create a stored procedure that accepts EmpID as INPUT 
        and returns the Employee Name, Job Title, Department Name, and Salary using OUTPUT parameters. */

        create procedure getEmpDetails
        @EmpID int,
        @EmpName varchar(255) output, 
        @jobTitle varchar(255) output, 
        @department varchar(255) output, 
        @Esalary decimal(8, 2) output
        as
        begin
            select @EmpName = e.EmpName, @jobTitle = e.jobTitle, @department = d.DeptName, @Esalary = e.salary
            from employees e
            join departments d
            on e.deptID = d.deptID
            where empID = @EmpID
        end

        declare @res1 varchar(255), @res2 varchar(255), @res3 varchar(255), @res4 decimal(8, 2)
        exec getEmpDetails 101, @EmpName = @res1 output, @jobTitle = @res2 output, @department = @res3 output, @Esalary = @res4 output
        select @res1, @res2, @res3, @res4


/* Q3. Create a stored procedure that accepts Department Name and Minimum Salary as INPUT, 
        and returns the number of employees in that department whose salary is above the minimum salary using OUTPUT. */

        create procedure spGetNumEmployee
        @department varchar(255), 
        @minSalary decimal(8, 2),
        @noOfEmployee int output
        as
        begin
            select @noOfEmployee = count(e.EmpID) from employees e
            join departments d
            on e.deptID = d.deptID
            where d.deptName = @department and e.salary > @minSalary
        end 

        declare @res1 int
        exec spGetNumEmployee 'it', 50000, @noOfEmployee = @res1 output
        select @res1

/* Q4. Create a stored procedure that accepts two INPUT parameters: 
        - Job Title
        - Salary Hike Percentage  
        The procedure should increase the salary for all employees with that job title 
        and return the total number of employees affected using an OUTPUT parameter. */

        alter procedure spGetTotalEmp
        @jobTitle varchar(255),
        @hike int,
        @totalEmployee int output
        as
        begin
            update employees
            set salary = salary + (salary * @hike / 100)
            where jobTitle = @jobTitle

            select @totalEmployee = count(e.empId) from employees e
            where e.jobTitle = @jobTitle
        end

        declare @res int
        exec spGetTotalEmp 'Software Engineer', 10, @totalEmployee = @res output
        select @res as totalEmployee

        
        select * from employees
        select * from departments
/* Q5. Create a stored procedure that accepts an Employee Joining Date Range as INPUT 
        and returns the total salary paid to employees who joined within that range using an OUTPUT parameter. */

        alter procedure spGetTotalSalaryPaid
        @startDate date,
        @endDate date,
        @totalSalary decimal(8, 2) output
        as
        begin
            select @totalSalary = sum(salary)  from employees 
            where joiningDate between @startDate and @endDate
        end

        
  



/* Q6. Create a stored procedure that accepts EmpID as INPUT 
        and returns the total number of years the employee has worked in the company using an OUTPUT parameter. */

        create procedure spGetNumberOfYearsWork
        @EmpID int, 
        @totalNumberOfYears int output
        as
        begin
            select @totalNumberOfYears = DATEDIFF(year, joiningDate, getDate()) from employees
        end

        DECLARE @RES1 int
        exec spGetNumberOfYearsWork 101, @totalNumberOfYears = @RES1 output
        select @res1


/* Q7. Create a stored procedure that accepts Department Name as INPUT 
        and returns the **highest-paid employee name and salary** in that department using OUTPUT parameters. */

        create procedure spGetHighestPaidEmployee
        @department varchar(255),
        @HighPaidEmpName varchar(255) output, 
        @HighPaidEmpSalary decimal(8, 2) output
        as
        begin
            select @HighPaidEmpName = e.empName, @HighPaidEmpSalary = max(e.salary) from employees e
            join departments d
            on e.deptID = d.deptID
            where d.deptName = @department 
            group by e.empName
        end

         DECLARE @RES1 varchar(255), @res2 decimal(8, 2)
        exec spGetHighestPaidEmployee 'it', @HighPaidEmpName = @RES1 output, @HighPaidEmpSalary = @res2 output
        select @res1 as EmpName, @res2 as ESalary


        select * from departments

        
        select * from employees

/* Q8. Create a stored procedure that accepts Location as INPUT 
        and returns the total number of employees working in all departments within that location using an OUTPUT parameter. */



/* Q9. Create a stored procedure that accepts Department Name as INPUT, 
        deletes all employees in that department, 
        and returns the total number of rows deleted using an OUTPUT parameter. */

        create procedure spGetNumberOfRows
        @departmentName varchar(255), 
        @totalRowDeleted int output
        as
        begin
           delete from employees e
           join departments d
           on e.deptID = d.deptID 
           where d.deptName = @departmentName
        end

/* Q10. Create a stored procedure that accepts EmpID and New Job Title as INPUT, 
         updates the employee's job title, and returns the updated title and salary using OUTPUT parameters. */


         create procedure spGetUpdateTitleAndSalary
         @EmpID int, 
         @newTitle varchar(255)
         as
         begin
            
         end

