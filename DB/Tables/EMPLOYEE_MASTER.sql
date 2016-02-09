--Start using SUBASHAGENCIES database
USE SUBASHAGENCIES;

--Drop EMPLOYEE_MASTER table to recreate it using new design
DROP TABLE EMPLOYEE_MASTER;

--Create EMPLOYEE_MASTER table.
CREATE TABLE EMPLOYEE_MASTER(
EMPLOYEEID INT IDENTITY(1,1),
EMPLOYEE_NAME VARCHAR(MAX) NOT NULL,
START_DATE DATE NOT NULL,
END_DATE DATE,
DESIGNATIONID INT NOT NULL,
SALARY INT NOT NULL DEFAULT(1),
STATUSID INT,
UPDATED_ON DATE,
CONSTRAINT PK_EMPLOYEE_MASTER_EMPLOYEEID PRIMARY KEY CLUSTERED (EMPLOYEEID));

--Insert records into it.

--Show inserted records.

