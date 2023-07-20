-- Trigger 1, 2 y 3
-- Cuando se inserta un ID de producto, ese ID no puede existir en las otras tablas de producto
-- Trigger 4
-- Chequeo de cantidad de stock con cantidad en la linea de factura si la diferencia da negativo o no
-- Trigger 5
-- Si el ID del producto no es un auto, entonces el numero serial queda en default.
-- Trigger 6
-- Si el ID de producto es de auto, el numero de serie debe existir para ese ID y que no se haya vendido, al insertarlo setear dicho auto en SOLD = 'Y'.
-- Trigger 7
-- Al eliminar una linea de la factura, se debe devolver el stock al producto.
-- Trigger 8
-- Al agregar un producto a un invoice, se debe actualizar el total con el subtotal de la linea agregada.
-- Trigger 9 
-- Al modificar una linea de factura, se debe actualizar el stock
-- Trigger 10
-- Al eliminar una fila de producto de auto, se debe poner el SOLD como 'N' en ese numero de serie.
-- Trigger 11
--Al insertar o modificar un PRODUCTBELONGSTOINVOICE se debe comprobar que el IDP existe en la tabla del type correspondiente
-- Trigger 12
-- Al insertar o actualizar un payment method, dependiendo del tipo elegido, ciertos atributos no pueden ser NULL,
-- Trigger 13
-- Al insertar o actualizar un usuario, el pais ingresado debe corresopnder con el idioma seleccionado sengun la tabla LANGUAGES
-- Trigger 14
-- Al agregar o modificar un INVOICE, el payment method debe pertenecer al usuario del INVOICE.
-- Trigger 15
-- Al agregar una linea de factura, se debe calcular el subtotal (quantity * price)


ALTER SESSION SET NLS_DATE_FORMAT = 'DD-MM-YYYY';

DROP TABLE PRODUCTBELONGSTOINVOICE;
DROP TABLE CARINVENTORY;
DROP TABLE INVOICE;
DROP TABLE SOLARPANEL;
DROP TABLE WARDROBE;
DROP TABLE CAR;
DROP TABLE TELEPHONE;
DROP TABLE TUSER;
DROP TABLE PAYMENTMETHOD;
DROP TABLE LANGUAGE;




CREATE TABLE LANGUAGE(
    IDCOUNTRY NUMBER,
    IDLANGUAGE NUMBER,
    PRIMARY KEY (IDCOUNTRY, IDLANGUAGE),
    COUNTRYNAME VARCHAR(20) NOT NULL,
    LANGUAGENAME VARCHAR(20) NOT NULL
);

CREATE TABLE PAYMENTMETHOD
(
    ID_PAYMENT_METHOD NUMBER PRIMARY KEY,
    PAYMENTTYPE VARCHAR2(6) NOT NULL CHECK(PAYMENTTYPE IN ('Card','Crypto')),
    CARDNUMBER VARCHAR2(25),
    CRYPTOWALLETADDRESS VARCHAR2(25)
);
CREATE TABLE TUSER 
(
    
 IDCOUNTRY NUMBER(3) NOT NULL, 
 IDLANGUAGE NUMBER(3) NOT NULL ,
 FIRSTNAME VARCHAR2(30) NOT NULL,
 SURNAME VARCHAR2(30) NOT NULL,
 MAIL VARCHAR2(30) NOT NULL,
 BIRTHDATE DATE NOT NULL,
 CREATIONDATE DATE NOT NULL,
 ID_PAYMENT_METHOD NUMBER NOT NULL REFERENCES PAYMENTMETHOD,
 IDUSER NUMBER PRIMARY KEY,
 RECOVERYISEMAIL VARCHAR(1) DEFAULT 'Y',
 
 FOREIGN KEY(IDCOUNTRY, IDLANGUAGE) references LANGUAGE (IDCOUNTRY, IDLANGUAGE) 
 
);

CREATE TABLE TELEPHONE
(
    IDUSER NUMBER REFERENCES TUSER,
    TELEPHONE VARCHAR2(10),
    PRIMARY KEY(IDUSER,TELEPHONE)
);

CREATE TABLE WARDROBE(
    IDPV NUMBER PRIMARY KEY,
    NAME VARCHAR2(20) NOT NULL,
    PRICE NUMBER NOT NULL,
    TYPE VARCHAR2(7) NOT NULL CHECK(TYPE IN ('Pants','T-Shirt','Jacket')),
    COLOR VARCHAR2(15) NOT NULL,
    CLOTHSIZE VARCHAR2(3) NOT NULL CHECK(CLOTHSIZE IN ('S','M','XL','XXL')),
    STOCK NUMBER NOT NULL
);


CREATE TABLE CAR(
    IDPA NUMBER PRIMARY KEY,
    NAME VARCHAR2(20) NOT NULL,
    PRICE NUMBER NOT NULL,
    MODEL VARCHAR2(20) NOT NULL,
    LYEAR VARCHAR2(5) NOT NULL,
    COLOR VARCHAR2(10) NOT NULL,
    RANGE VARCHAR2(8) NOT NULL,
    POWER VARCHAR2(4) NOT NULL,
    STOCK NUMBER NOT NULL
);

CREATE TABLE SOLARPANEL(
    IDPP NUMBER PRIMARY KEY,
    NAME VARCHAR2(20) NOT NULL,
    PRICE NUMBER NOT NULL,
    WIDTH VARCHAR2(3) NOT NULL,
    HEIGHT VARCHAR2(3) NOT NULL,
    VOLTAGE VARCHAR2(4)NOT NULL CHECK(VOLTAGE IN ('12v','14v','110v','230v')),
    STOCK NUMBER NOT NULL
);

CREATE TABLE INVOICE(
    IDINVOICE NUMBER(10) PRIMARY KEY,
    IDUSER NUMBER NOT NULL REFERENCES TUSER,
    ID_PAYMENT_METHOD NUMBER NOT NULL REFERENCES PAYMENTMETHOD (ID_PAYMENT_METHOD),
    INVOICEDATE DATE NOT NULL,
    TOTAL NUMBER(10) NOT NULL
);

CREATE TABLE CARINVENTORY (
    IDPA NUMBER NOT NULL REFERENCES CAR,
    SERIALNUMBER VARCHAR(20) PRIMARY KEY,
    SOLD VARCHAR(1) DEFAULT 'N'
);


CREATE TABLE PRODUCTBELONGSTOINVOICE(
    IDINVOICE NUMBER(10) REFERENCES INVOICE (IDINVOICE),
    UNITPRICE NUMBER(10) NOT NULL,
    QUANTITY  NUMBER(3) NOT NULL,
    SUBTOTAL NUMBER(10) NOT NULL,
    SERIALNUMBER VARCHAR(20) DEFAULT '00000000000000000000', 
    IDP NUMBER,
    TYPE VARCHAR2(10) NOT NULL CHECK(TYPE IN ('SolarPanel','Car','Wardrobe')),
    PRIMARY KEY (IDINVOICE, IDP, SERIALNUMBER)
);



