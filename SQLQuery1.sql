CREATE TABLE COMPANY_MASTER(ID INTEGER PRIMARY KEY IDENTITY(1,1), NAME VARCHAR(MAX))

CREATE TABLE CUSTOMER_MASTER(ID INTEGER PRIMARY KEY IDENTITY(1,1), 
							NAME VARCHAR(MAX), 
							OUTLET_NAME VARCHAR(MAX), 
							CUSTOMER_CATEGORY INTEGER FOREIGN KEY REFERENCES ADDRESS_MASTER(ID),
							CUSTOMER_TYPE INTEGER FOREIGN KEY REFERENCES ADDRESS_MASTER(ID),
							CUSTOMER_BEAT INTEGER FOREIGN KEY REFERENCES ADDRESS_MASTER(ID),
							ADDRESS1 VARCHAR(MAX),
							ADDRESS2 VARCHAR(MAX),
							LANDLINE BIGINT,
							MOBILE INTEGER,
							EMAIL_ADDRESS VARCHAR(MAX),
							OTHER_DETAILS VARCHAR(MAX), 
							LOCATION_ID INTEGER FOREIGN KEY REFERENCES ADDRESS_MASTER(ID),
							ACCOUNT_STATUS INTEGER FOREIGN KEY REFERENCES ADDRESS_MASTER(ID))
DROP TABLE CUSTOMER_MASTER
CREATE TABLE ADDRESS_MASTER(ID INTEGER PRIMARY KEY IDENTITY(1,1), CATEGORY VARCHAR(MAX), CATEGORY_VALUE VARCHAR(MAX))

CREATE TABLE SALESMAN_MASTER(ID INTEGER PRIMARY KEY IDENTITY(1,1), NAME VARCHAR(MAX) NOT NULL)

INSERT INTO ADDRESS_MASTER(CATEGORY, CATEGORY_VALUE) VALUES ('CUSTOMER_TYPE','--Select--')
INSERT INTO ADDRESS_MASTER(CATEGORY, CATEGORY_VALUE) VALUES ('CUSTOMER_TYPE','Kirana Merchant')
INSERT INTO ADDRESS_MASTER(CATEGORY, CATEGORY_VALUE) VALUES ('CUSTOMER_TYPE','Medical')
INSERT INTO ADDRESS_MASTER(CATEGORY, CATEGORY_VALUE) VALUES ('CUSTOMER_TYPE','Genaral Stores')
INSERT INTO ADDRESS_MASTER(CATEGORY, CATEGORY_VALUE) VALUES ('CUSTOMER_TYPE','Bakery')
INSERT INTO ADDRESS_MASTER(CATEGORY, CATEGORY_VALUE) VALUES ('CUSTOMER_CATEGORY','--Select--')
INSERT INTO ADDRESS_MASTER(CATEGORY, CATEGORY_VALUE) VALUES ('CUSTOMER_CATEGORY','WholSsale')
INSERT INTO ADDRESS_MASTER(CATEGORY, CATEGORY_VALUE) VALUES ('CUSTOMER_CATEGORY','Retail')
INSERT INTO ADDRESS_MASTER(CATEGORY, CATEGORY_VALUE) VALUES ('BEAT','--Select--')
INSERT INTO ADDRESS_MASTER(CATEGORY, CATEGORY_VALUE) VALUES ('BEAT','Beat1')
INSERT INTO ADDRESS_MASTER(CATEGORY, CATEGORY_VALUE) VALUES ('BEAT','Beat2')
INSERT INTO ADDRESS_MASTER(CATEGORY, CATEGORY_VALUE) VALUES ('BEAT','Beat3')
INSERT INTO ADDRESS_MASTER(CATEGORY, CATEGORY_VALUE) VALUES ('LOCATION','--Select--')
INSERT INTO ADDRESS_MASTER(CATEGORY, CATEGORY_VALUE) VALUES ('LOCATION','Town1')
INSERT INTO ADDRESS_MASTER(CATEGORY, CATEGORY_VALUE) VALUES ('LOCATION','Town2')
INSERT INTO ADDRESS_MASTER(CATEGORY, CATEGORY_VALUE) VALUES ('LOCATION','Village1')
INSERT INTO ADDRESS_MASTER(CATEGORY, CATEGORY_VALUE) VALUES ('LOCATION','Village2')
INSERT INTO ADDRESS_MASTER(CATEGORY, CATEGORY_VALUE) VALUES ('LOCATION','Village3')
INSERT INTO ADDRESS_MASTER(CATEGORY, CATEGORY_VALUE) VALUES ('STATUS','--Select--')
INSERT INTO ADDRESS_MASTER(CATEGORY, CATEGORY_VALUE) VALUES ('STATUS','Active')
INSERT INTO ADDRESS_MASTER(CATEGORY, CATEGORY_VALUE) VALUES ('STATUS','InActive')
DELETE FROM ADDRESS_MASTER

select * from CUSTOMER_MASTER
select * from ADDRESS_MASTER