create database AdvanceSQL
use AdvanceSQL

create table employee
(
	EID int primary key identity, 
	fullname varchar(255),
	Eage int,
	salary money, 
	department varchar(255)
)

insert into employee (fullname, eage, salary, department) 
values
('faizan', 23, 25000, 'it'),
('rohan', 24, 35000, 'hr'),
('sahil', 25, 15000, 'finance'),
('mihir', 22, 62000, 'it'),
('salman', 23, 34000, 'hr'),
('aakash', 24, 22000, 'finance')

--Stored Procedure 

--1. Create a Stored Procedure to get all employees from a specific department.

	create procedure spGetAllEmployee
	@deptName varchar(255)
	as
	begin
		select * from employee
		where department = @deptName
	end

	spGetAllEmployee 'it'

--2. Create a Stored Procedure to insert a new employee record. 
	
	create procedure spInsertNewEmployee
	@fullname varchar(255),
	@age int, 
	@salary money,
	@deptName varchar(255)
	as
	begin
		insert into employee (fullname, eage, salary, department) values
		(@fullname, @age,@salary, @deptName)
	end

	spInsertNewEmployee 'Ram', 25, 45000, 'it'


--3. Create a Stored Procedure to update an employee's salary. 
	
	create procedure spUpdateEmployeeSalary
	@eid int, 
	@salary money
	as
	begin
		update employee
		set salary = @salary
		where eid = @eid
	end

	spUpdateEmployeeSalary 7, 10000


	
--4. Create a Stored Procedure that takes an EmployeeID and returns the full name of the employee. 

	create procedure spGetFullNameOfEmployee
	@EmployeeID int
	as
	begin
		select fullname from employee
		where eid = @EmployeeID
	end

	spGetFullNameOfEmployee 6

	

--5. Create a Stored Procedure to delete an employee record by their ID. 

	create procedure spDeleteEmployee
	@EmpID int
	as
	begin
		delete from employee
		where eid = @EmpID
	end

	spDeleteEmployee 7

	
	select * from employee

--6. Create a Stored Procedure that returns an OUTPUT parameter for the total number 
--of employees in a given department. 

	create procedure spGetTotalEmployee
	@deptName varchar(255),
	@totalEmployee int output
	as
	begin
		select @totalEmployee = count(eid) from employee
		where department = @deptName
	end

	declare @res int
	exec spGetTotalEmployee 'it', @totalEmployee = @res output
	select @res as totalEmployee




Triggers  
--1. Create a trigger that inserts a log entry on employee salary updates. 
	create table logEmployee(
	eid int,
	fullName varchar(255), 
	oldSalary money, 
	newSalary money, 
	)

	drop table logEmployee
	
	create trigger trgInsertLogWhenSalaryChanges
	on employee
	for update
	as
	begin 
		insert into logEmployee(eid, fullName, oldSalary, newSalary)
		select 
			d.eid, 
			d.fullName,
			d.salary, 
			i.salary
		from deleted d
		join inserted i
		on d.eid = i.eid
		where d.salary <> i.salary
	end

	update employee
	set salary = 30000
	where eid = 1
	
	
--2. Create a trigger that prevents a record from being deleted.

	create trigger trgPreventRecordFromDeleted
	on employee
	instead of delete
	as
	begin
		print 'You are not allowed to delete record'
	end

	delete from employee 
	where eid = 5



--3. Create a trigger that automatically updates a timestamp of column 
--LastModifiedDate on a record change. 
	
	alter table employee
	add LastModifiedDate date default getDate()

	create trigger trgUpdateTimestamps
	on employee
	for update
	as
	begin
		update employee
		set LastModifiedDate = getDate()
		where eid in(select eid from inserted)
	end

	select * from employee

	update employee
	set salary = 25000
	where fullname = 'rohan'

--4. Create a trigger that inserdts a log entry when a new employee is added. 
	
	create table LogNewEmployee
	(
		EID int primary key, 
		fullname varchar(255),
		Eage int,
		salary money, 
		department varchar(255)
	)
	drop table LogNewEmployee

	alter trigger trgWhenNewEmployeeAdded
	on employee
	for insert
	as
	begin
		insert into LogNewEmployee(eid, fullName, Eage, salary, department)
		select 
			e.eid,
			i.fullName,
			i.eage,
			i.salary, 
			i.department
		from inserted i
		join employee e
		on i.eid = e.eid
	end

	insert into employee(fullname, eage, salary, department) values
	('Hardik', 23, 45000, 'it')



--5. Create a trigger that prevents a DDL operation from running. 
	
	create trigger trgPreventFromDDLOperation
	on employee
	instead of insert, update, delete
	as
	begin
		raiserror('You are not allowed to perform DDL Operation', 16, 1)
	end

	delete from employee
	where eid = 3

	disable trigger trgPreventFromDDLOperation on employee

	


--6. Create a trigger to prevent negative amount on the Salary column. 

	alter  trigger trgPreventNegativeSalary
	on employee
	for update, insert
	as
	begin
		if exists(select 1 from inserted where salary < 0)
		begin
			print 'You are not allowed to enter negative salary'
		end
	end

    select * from employee
	select * from LogNewEmployee