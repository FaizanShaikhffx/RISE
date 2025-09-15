CREATE DATABASE TriggerDB
USE TriggerDB
------------------------------------------------------------
-- 1. CREATE MAIN TABLE
------------------------------------------------------------
CREATE TABLE employee (
    eid INT PRIMARY KEY IDENTITY(1,1),
    ename VARCHAR(50),
    dept VARCHAR(50),
    esalary DECIMAL(10,2)
);

------------------------------------------------------------
-- 2. INSERT SAMPLE DATA
------------------------------------------------------------
INSERT INTO employee (ename, dept, esalary) VALUES
('Faizan', 'IT', 40000),
('Krupal', 'HR', 35000),
('Ketan', 'Teaching', 50000),
('Mihir', 'Finance', 60000),
('Kush', 'IT', 70000);



-------------------------------------
-- 1. BASIC TRIGGER SYNTAX
-------------------------------------
CREATE TRIGGER TriggerName
ON employee
FOR INSERT, UPDATE, DELETE
AS
BEGIN
    print 'it will run on insert, update and delete'
END

SELECT * FROM employee;

disable trigger TriggerName on employee
INSERT INTO employee (ename, dept, esalary) VALUES
('Rohan', 'IT', 10000)



-------------------------------------
-- 2. UPDATE TRIGGER
-------------------------------------
CREATE TRIGGER tr_tableEmployee_forupdate
ON employee
FOR UPDATE
AS
BEGIN
    SELECT * FROM deleted;  -- Old values
    SELECT * FROM inserted; -- New values
END;

UPDATE employee
SET esalary = 50000
WHERE eid = 5;



-------------------------------------
-- 3. INSERT TRIGGER
-------------------------------------
CREATE TRIGGER tr_insert_emplTabel
ON employee
FOR INSERT
AS
BEGIN
    PRINT 'New employee inserted';
    SELECT * FROM inserted;
END;

-- Test Insert
INSERT employee VALUES ('Mohan','da',8000);




-------------------------------------
-- 4. DELETE TRIGGER
-------------------------------------
CREATE TRIGGER tr_delete_emplTable
ON employee
FOR DELETE
AS
BEGIN
    PRINT 'Employee has been removed';
    SELECT * FROM deleted;
END;

-- Test Delete
DELETE FROM employee
WHERE eid = 7;



-------------------------------------
-- 5. SALARY AUDIT TRIGGER
-------------------------------------
-- Step 1: Create Audit Table
CREATE TABLE emplAudit (
    AuditID INT IDENTITY,
    empid INT,
    oldSalary DECIMAL(10,2),
    NewSalary DECIMAL(10,2),
    changeDate DATETIME DEFAULT GETDATE()
);

-- Step 2: Create Audit Trigger
CREATE TRIGGER trg_auditeSAlaryChange
ON employee
AFTER UPDATE
AS
BEGIN
    INSERT INTO emplAudit (empid, oldSalary, NewSalary)
    SELECT d.eid, d.esalary AS oldSalary, i.esalary AS NewSalary
    FROM deleted d
    JOIN inserted i ON d.eid = i.eid
    WHERE d.esalary <> i.esalary;
END;

SELECT * FROM employee;
SELECT * FROM emplAudit;

UPDATE employee
SET esalary = 50000
WHERE eid = 6;



-------------------------------------
-- 6. DROP TRIGGERS
-------------------------------------
DROP TRIGGER trg_auditeSAlaryChange;
DROP TRIGGER tr_delete_emplTable;
DROP TRIGGER tr_insert_emplTabel;
DROP TRIGGER tr_tableEmployee_forupdate;



-------------------------------------
-- 7. DELETE AUDIT TRIGGER
-------------------------------------
CREATE TRIGGER Delete_Audit_empl
ON empl
FOR DELETE
AS
BEGIN
    INSERT INTO emplAudit (empid, oldSalary, changeDate)
    SELECT eid, esalary, GETDATE()
    FROM deleted;
END;

SELECT * FROM employee;
SELECT * FROM emplAudit;

DELETE FROM employee
WHERE eid = 6;



-------------------------------------
-- 8. ALTER TRIGGER
-------------------------------------
ALTER TRIGGER Delete_Audit_empl
ON empl
AFTER DELETE
AS
BEGIN
    INSERT INTO emplAudit (empid, oldSalary, changeDate)
    SELECT eid, esalary, GETDATE()
    FROM deleted;
END;



-------------------------------------
-- 9. PREVENT NEGATIVE SALARY
-------------------------------------
CREATE TRIGGER tr_prventNagativeSalary
ON empl
FOR INSERT, UPDATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE esalary < 0)
    BEGIN
        ROLLBACK TRANSACTION;
        PRINT 'You are not allowed to enter negative salary';
    END
END;

-- Test it
UPDATE empl
SET esalary = -255
WHERE eid = 1;



-------------------------------------
-- 10. AUTO UPDATE LASTMODIFIED COLUMN
-------------------------------------
ALTER TABLE empl
ADD LastModified DATE;

CREATE TRIGGER tr_updatelastmodified
ON employee
FOR UPDATE
AS
BEGIN
    UPDATE employee
    SET LastModified = GETDATE()
    WHERE eid IN (SELECT eid FROM inserted);
END

select * from employee

-------------------------------------
-- 11. ENABLE & DISABLE TRIGGERS
-------------------------------------
-- Disable a trigger
DISABLE TRIGGER tr_updatelastmodified ON empl;

-- Enable a trigger
ENABLE TRIGGER tr_updatelastmodified ON empl;



-------------------------------------
-- 12. INSTEAD OF TRIGGER (Salary Cannot Be Reduced)
-------------------------------------
CREATE TRIGGER tr_InsteadOfupdateSalary
ON empl
INSTEAD OF UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM inserted i
        JOIN deleted d ON i.eid = d.eid
        WHERE i.esalary < d.esalary
    )
    BEGIN
        RAISERROR('Error: Salary cannot be reduced', 16, 1);
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        -- Allow normal update
        UPDATE empl
        SET ename = i.ename,
            esalary = i.esalary
        FROM inserted i
        WHERE empl.eid = i.eid;
    END
END;

create trigger trgInsteadOfUpdateSalary
on employee
instead of update
as
begin
    if exists(select 1 from inserted i join deleted d on i.eid = d.eid where i.esalary < d.esalary)
    begin
        raiserror('Error: Salary cannot be negative', 16, 1);
        rollback transaction;
    end
    else
    begin
        update employee
        set esalary = i.esalary from inserted i
        where employee.eid = i.eid
    end
end

update employee
set esalary = 50000
where eid = 4


select * from employee

-------------------------------------
-- 13. VIEW & INSTEAD OF TRIGGERS
-------------------------------------
-- Create Dept Table
CREATE TABLE dept (
    did INT,
    dname VARCHAR(255)
);

INSERT dept VALUES (101,'it'), (102,'cs');

-- Create Employee Table
CREATE TABLE employee (
    eid INT,
    ename VARCHAR(255),
    did INT
);

INSERT employee VALUES (1,'mihir',101),(2,'faizan',102);

-- Create View
CREATE VIEW vwEmployeeDetails
AS
SELECT e.eid, e.ename, d.dname
FROM employee e
JOIN dept d ON e.did = d.did;

SELECT * FROM vwEmployeeDetails;

-- Instead Of Insert Trigger on View
CREATE TRIGGER tr_InsteadOfInsertOnView
ON vwEmployeeDetails
INSTEAD OF INSERT
AS
BEGIN
    INSERT INTO employee (eid, eName, did)
    SELECT i.eid, i.eName, d.did
    FROM inserted i
    JOIN Dept d ON i.dname = d.dname;
END;

INSERT vwEmployeeDetails(eid, ename, dname)
VALUES (3,'kush','cs');

-- Instead Of Update Trigger on View
CREATE TRIGGER tr_updateOfOnView
ON vwEmployeeDetails
INSTEAD OF UPDATE
AS
BEGIN
    INSERT INTO employee (eid, eName, did)
    SELECT i.eid, i.eName, d.did
    FROM inserted i
    JOIN dept d ON i.dname = d.dname;
END;



-------------------------------------
-- 14. DATABASE-LEVEL TRIGGERS
-------------------------------------
-- Prevent Creating New Tables
CREATE TRIGGER tr_blocktocreateNewtable
ON DATABASE
FOR CREATE_TABLE
AS
BEGIN
    PRINT 'You cannot create a new table';
    ROLLBACK TRANSACTION;
END;

-- Drop Database-Level Trigger
DROP TRIGGER tr_blocktocreateNewtable ON DATABASE;

-- Prevent Dropping Tables
CREATE TRIGGER tr_blocktodropNewtable
ON DATABASE
FOR DROP_TABLE
AS
BEGIN
    PRINT 'You cannot drop a table';
    ROLLBACK TRANSACTION;
END;

DROP TRIGGER tr_blocktodropNewtable ON DATABASE;

-- Disable Database Trigger
DISABLE TRIGGER tr_blocktodropNewtable ON DATABASE;



-------------------------------------
-- 15. SERVER-LEVEL TRIGGERS
-------------------------------------
CREATE TRIGGER tr_blocktocreateNewtableAndDropTable
ON ALL SERVER
FOR CREATE_TABLE
AS
BEGIN
    PRINT 'You cannot create a new table';
    ROLLBACK TRANSACTION;
END;

DROP TRIGGER tr_blocktocreateNewtableAndDropTable ON ALL SERVER;
DISABLE TRIGGER tr_blocktocreateNewtableAndDropTable ON ALL SERVER;
ENABLE TRIGGER tr_blocktocreateNewtableAndDropTable ON ALL SERVER;



-------------------------------------
-- 16. CHECK ALL TRIGGERS IN DATABASE
-------------------------------------
SELECT * FROM sys.triggers;




