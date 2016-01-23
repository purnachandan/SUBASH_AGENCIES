CREATE TABLE CUSTOMER_MASTER
(ID INT IDENTITY(1,1), 
CUSTOMER_NAME VARCHAR(100) NOT NULL, 
OUTLET_NAME VARCHAR(100) NOT NULL, 
CATEGORYID INT, 
TYPEID INT, 
BEATID INT, 
ADDRESS1 VARCHAR(80), 
ADDRESS2 VARCHAR(80), 
LANDLINE VARCHAR(15), 
MOBILE VARCHAR(10), 
EMAIL_ADDRESS VARCHAR(80), 
OTHER_DETAILS VARCHAR(80), 
CITYID INT, 
STATUSID INT, 
UPDATED_ON DATE, 
CONSTRAINT PK_CUSTOMER_MASTER_ID PRIMARY KEY CLUSTERED (ID))

DROP TABLE CUSTOMER_MASTER

SELECT * FROM CUSTOMER_MASTER
