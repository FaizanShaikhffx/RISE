create database triggerPractice
use triggerPractice

CREATE TABLE EMPLOYEE (
    EID INT PRIMARY KEY,
    ENAME VARCHAR(100),
    EAGE INT,
    ESALARY MONEY,
    EMAIL VARCHAR(100),
    EDEPARTMENT VARCHAR(50),
    LOCATION VARCHAR(50)
);

INSERT INTO EMPLOYEE VALUES
(101, 'Faizan', 23, 50000, 'faizan@gmail.com', 'FS', 'India'),
(102, 'Ayaan', 25, 60000, 'ayaan@gmail.com', 'HR', 'India'),
(103, 'Priya', 27, 45000, 'priya@gmail.com', 'IT', 'India'),
(104, 'Rohan', 24, 70000, 'rohan@gmail.com', 'Finance', 'India'),
(105, 'Sneha', 28, 80000, 'sneha@gmail.com', 'FS', 'India'),
(106, 'Vraj', 26, 30000, 'vraj@gmail.com', 'IT', 'India');

select * from employee

/* Q1. Create a trigger to display a message whenever an employee's details are updated. */

    create trigger trgDisplayUpdateMessage
    on employee
    for update
    as
    begin
        print 'Employee data is updated'
    end

    disable trigger trgDisplayUpdateMessage on employee
    
    

/* Q2. Create a trigger that shows inserted employee records whenever a new employee joins. */

    create trigger trgShowNewEmployee
    on employee
    for insert
    as
    begin
        select * from inserted
    end



    insert into employee values
    (107, 'Mohan', 23, 12000, 'mohan@gmail.com', 'hr', 'india')

    select * from employee

/* Q3. Create a trigger that prints deleted employee details whenever someone is removed from the company. */
    
    create trigger trgShowDeletedEmployee
    on employee
    for delete
    as
    begin   
        select * from deleted 
    end

    delete from employee
    where eid = 107

/* Q4. Create an audit table and a trigger that stores old salary, new salary, and EID whenever salary changes. */

    create table auditEmployee(
    EId int primary key, 
    oldSalary MONEY, 
    newSalary Money, 
    changedate date default getDate()
    )

    drop table auditSalary
    
    alter trigger trgShowSalaryChanges
    on employee
    for update
    as
    begin
        insert into auditEmployee(Eid, oldSalary, newSalary)
        select 
            d.Eid,
            d.esalary,
            i.esalary
        from deleted d
        join inserted i
        on d.eid = i.eid
        where d.esalary <> i.esalary
    end

    disable trigger trgShowSalaryChanges on employee

    update employee
    set esalary = 26000
    where eid = 101

    select * from employee
    select * from auditEmployee 
    
/* Q5. Create a trigger to record details of employees when they are deleted into the EMPLOYEE_AUDIT table. */
    
    create table auditEmployeeDelete
    (
    EID INT PRIMARY KEY,
    ENAME VARCHAR(100),
    EAGE INT,
    ESALARY MONEY,
    EMAIL VARCHAR(100),
    EDEPARTMENT VARCHAR(50),
    LOCATION VARCHAR(50),
    DeletedDate date default getDate()
    )

    disable trigger trgRecordDeletedEmployee on employee

    alter trigger trgRecordDeletedEmployee
    on employee
    for delete
    as
    begin
        insert into auditEmployeeDelete(eid, ename, eage, esalary, email, edepartment, location, deletedDate)
        select 
            d.eid,
            d.ename,
            d.eage,
            d.esalary, 
            d.email, 
            d.edepartment, 
            d.location, 
            getDate()
        from deleted d
    end
    select * from auditEmployeeDelete

    delete from employee
    where eid = 105

    select * from employee
    select * from auditEmployee

/* Q6. Create a trigger that prevents inserting or updating negative salary values. */

    alter trigger trgPrevetNegativeSalary
    on employee
    for insert, update
    as 
    begin
        if exists(select 1 from inserted where esalary < 0)
        begin
            raiserror('you can not enter negative salary', 16, 1)
            rollback transaction
        end
    end
    select * from employee
    
    disable trigger trgPrevetNegativeSalary on employee 

    update employee
    set esalary = -200 
    where eid = 104

/* Q7. Create a trigger that automatically updates the LAST_MODIFIED date whenever employee details are updated. */

    alter table employee
    add lastModified date default getDate()

    alter trigger trgupdateLastModifiedDate
    on employee
    for update
    as
    begin
       update employee
       set lastModified = getDate()
       from employee e
       join inserted i on e.eid = i.eid
    end

    disable trigger trgupdateLastModifiedDate on employee 

    update employee
    set esalary = 45000
    where eid = 101 

    select * from employee
    select * from employeeAudit

/* Q8. Create an INSTEAD OF trigger that prevents salary reduction — 
       salary can only be increased or remain the same. */

       create trigger trgPreventSalaryReduction
       on employee
       instead of update, insert
       as
       begin
            if exists(select 1 from inserted i where esalary < 0)
            begin
                raiserror('You cannot enter negative salary', 16, 1)
                rollback transaction 
                return
            end
            if exists (select 1 from inserted i 
                       join deleted d 
                       on i.eid = d.eid 
                       where d.esalary > i.esalary
                       )
            begin
                raiserror('You can not decrease salary', 16, 1)
                rollback transaction
                return
            end

            update employee
            set
                ename = i.ename,
                eage = i.eage, 
                esalary = i.esalary, 
                email = i.email, 
                edepartment = i.edepartment,
                location = i.location, 
             from inserted i 
             where employee.eid = i.eid

            INSERT INTO EMPLOYEE (EID, ENAME, EAGE, ESALARY, EMAIL, EDEPARTMENT, LOCATION)
            SELECT EID, ENAME, EAGE, ESALARY, EMAIL, EDEPARTMENT, LOCATION
            FROM inserted
            WHERE EID NOT IN (SELECT EID FROM EMPLOYEE)
       end

       disable trigger trgPreventSalaryReduction on employee 
       

/* Q9. Create a trigger to display both old and new salary values whenever an employee's salary is updated. */

    create trigger trgShowOldAndNewSalary
    on employee
    for update
    as
    begin
        select * from inserted
        select * from deleted
    end 

    disable trigger trgShowOldAndNewSalary on employee 

    select * from employee

    update employee 
    set location = 'us'
    where eid = 103

/* Q10. Create a trigger to track the number of employees inserted per day and store that info in a log table. */
    
CREATE TABLE EmployeeInsertLog (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    InsertedDate DATE,
    TotalInserted INT
);


    
/* Q11. Create a trigger on a VIEW (VW_EMPLOYEE_DEPT) that automatically inserts employee details 
        into EMPLOYEE_DETAIL and updates DEPARTMENT_ID based on department name. */
    CREATE VIEW VW_EMPLOYEE_DEPT
    AS
    SELECT EID, ENAME, EDEPARTMENT, ESALARY
    FROM EMPLOYEE;

    insert into VW_EMPLOYEE_DEPT (eid, ename, edepartment, esalary)
    values(105, 'Mohan', 'IT', 15000)

        drop trigger trgInsertEmployeeThroughView


    create trigger trgInsertEmployeeThroughView
    on VW_EMPLOYEE_DEPT
    instead of insert
    as
    begin
        insert into employee(eid, ename, eage, esalary, email, edepartment, location)
        select 
            i.eid, 
            i.ename, 
                
        from inserted i
    end

    select * from employee 
    select * from VW_EMPLOYEE_DEPT
    select * from department

/* Q12. Create an INSTEAD OF DELETE trigger on VW_EMPLOYEE_DEPT that deletes data from EMPLOYEE_DETAIL 
        when deleted from the view. */
        
        create trigger trgDeleteEmployeeThroughView
        on VW_EMPLOYEE_DEPT
        instead of delete
        as
        begin
            delete from employee
            where eid in(select eid from deleted)
        end

        delete from VW_EMPLOYEE_DEPT
        where eid = 105 

        select * from employee
        select * from VW_EMPLOYEE_DEPT



/* Q13. Create an INSTEAD OF UPDATE trigger on VW_EMPLOYEE_DEPT that updates department name for an employee. */

    drop trigger trgupdateDepartmentForEmployee
    create trigger trgupdateDepartmentForEmployee
    on VW_EMPLOYEE_DEPT
    instead of update
    as
    begin
       update employee
       set edepartment = i.edepartment
       from employee e
       join inserted i on e.eid = i.eid
    end

    select * from employee
/* Q14. Create a trigger to block salary updates for employees working in the 'Finance' department. */
    
    create trigger trgBlockToUpdateSalaryByDepartment
    on employee
    for update
    as
    begin
        if exists(select 1 from inserted i
        join deleted d
        on i.eid = d.eid
        where d.esalary <> i.esalary and i.edepartment = 'finance')
        begin
            print 'You are in finance department and you cannot update salary'
            rollback transaction
        end
    end

    select * from employee

    disable trigger trgBlockToUpdateSalaryByDepartment on employee 
/* Q15. Create a trigger that automatically copies deleted employee details into a backup table before deletion. */

    

/* Q16. Create a trigger that prevents employees from being deleted if their salary is above 80,000. */

    create trigger trgPreventEmpForDeleted
    on employee
    for delete
    as
    begin
        if exists(select * from deleted d where d.esalary > 80000)
        begin
            print 'You can not delete employee whose salary is greater than 80K'
            rollback transaction
        end
    end

    update employee
    set esalary = 85000
    where eid = 104

    delete from employee
    where eid = 104

    disable trigger trgPreventEmpForDeleted on employee

/* Q17. Create a database-level trigger that restricts users from creating new tables in the database. */

    create trigger trgToRestrictCreatetable
    on database
    for create_table
    as
    begin
        print 'You cannot create table on database'
        rollback transaction
    end

    disable trigger trgToRestrictCreatetable on database


/* Q18. Create a server-level trigger that blocks table creation on the entire SQL Server instance. */

    create trigger trgBlockToCreateOnServer
    on all server
    for create_table
    as
    begin
        print 'You can not create table on all servers'
        rollback transaction
    end

    create table std(stdid int)
    disable trigger trgBlockToCreateOnServer on all server


/* Q19. Create a trigger that prevents dropping any table from the database. */

    create trigger trgPreventDropTableAcrossDatabase
    on database
    for drop_table
    as
    begin
        print 'You can not drop any table on this database'
        rollback transaction
    end

    drop table employee

/* Q20. Write commands to: 
        - Disable a trigger 
        - Enable a trigger 
        - Drop a trigger 
        (Use TR_EMPLOYEE_UPDATE for testing)
*/



select * from employee
select * from 

create trigger trgPreventReduceSalary
on employee
instead of update
as
begin
    if exists( select * from inserted i
                join deleted d
                on i.eid = d.eid
                where d.esalary > i.esalary)
    begin
        print 'YOu can not reduce salary'
        rollback transaction
    end
    update employee
    set esalary = i.esalary
    from employee e
    join inserted i
    on e.eid = i.eid
    where e.esalary <> i.esalary
end



