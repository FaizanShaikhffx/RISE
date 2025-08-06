CREATE DATABASE normf_3

USE normf_3

CREATE TABLE AppointmentTable (
    Appt_No INT,
    Appt_Date DATE,
    Appt_Time TIME,
    Planned_Duration FLOAT,
    Appt_Type VARCHAR(255),
    Patient_ID INT,
    First_Nm VARCHAR(255),
    Last_Nm VARCHAR(255),
    Phone VARCHAR(255),
    Doctor_ID VARCHAR(255),
    Doctor_Nm VARCHAR(255)
)

INSERT INTO AppointmentTable VALUES
(1, '2025-07-28', '09:00:00', 1.00, 'General Checkup', 1001, 'Aarav', 'Sharma', '9876543210', 'D101', 'Dr. Mehta'),
(2, '2025-07-28', '09:30:00', 0.25, 'Vaccination', 1002, 'Priya', 'Patel', '9123456789', 'D102', 'Dr. Iyer'),
(3, '2025-07-28', '10:00:00', 0.50, 'Flu Symptoms', 1003, 'Rohan', 'Verma', '9988776655', 'D103', 'Dr. Kapoor'),
(4, '2025-07-29', '11:00:00', 0.50, 'Migraine', 1004, 'Sneha', 'Joshi', '9345678901', 'D102', 'Dr. Iyer'),
(5, '2025-07-29', '11:30:00', 0.25, 'Vaccination', 1005, 'Kunal', 'Singh', '9001234567', 'D104', 'Dr. Rao'),
(6, '2025-07-29', '12:00:00', 0.25, 'Vaccination', 1006, 'Neha', 'Desai', '9870012345', 'D103', 'Dr. Kapoor'),
(7, '2025-07-29', '12:30:00', 0.50, 'Cold & Cough', 1007, 'Ishaan', 'Bose', '9765432109', 'D101', 'Dr. Mehta'),
(8, '2025-07-30', '09:00:00', 1.00, 'General Checkup', 1008, 'Meera', 'Reddy', '9654321098', 'D102', 'Dr. Iyer'),
(9, '2025-07-30', '10:00:00', 1.00, 'General Checkup', 1001, 'Aarav', 'Sharma', '9876543210', 'D101', 'Dr. Mehta'),
(10, '2025-07-30', '10:30:00', 0.50, 'Migraine', 1008, 'Meera', 'Reddy', '9654321098', 'D101', 'Dr. Mehta')

SELECT * FROM AppointmentTable