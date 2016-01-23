CREATE TABLE CUSTOMERTYPE(
TYPEID INT IDENTITY(1,1), 
TYPENAME VARCHAR(MAX),
CONSTRAINT PK_CUSTOMERTYPE_TYPEID PRIMARY KEY CLUSTERED (TYPEID));

--DROP TABLE CUSTOMERTYPE
--ALTER TABLE CUSTOMERTYPE ALTER COLUMN TYPENAME VARCHAR(MAX) NOT NULL;

INSERT INTO CUSTOMERTYPE (TYPENAME) VALUES ('BAKERY');
INSERT INTO CUSTOMERTYPE (TYPENAME) VALUES ('GENERAL STORES');
INSERT INTO CUSTOMERTYPE (TYPENAME) VALUES ('KIRANA MERCHANT');
INSERT INTO CUSTOMERTYPE (TYPENAME) VALUES ('MEDICAL STORES');

SELECT * FROM CUSTOMERTYPE;