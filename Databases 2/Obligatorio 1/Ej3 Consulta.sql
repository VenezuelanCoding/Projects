--Seleccionar el precio unitario del producto, subtotal por producto, nombre y email de los clientes de
--México que hayan adquirido vehículos del modelo S de color azul en 2021

SELECT U.FIRSTNAME, U.SURNAME, U.MAIL,p.unitprice, p.subtotal FROM
TUSER U, LANGUAGE L, INVOICE I  , PRODUCTBELONGSTOINVOICE P, CAR C
WHERE u.idcountry = l.idcountry 
AND l.countryname='Mexico' 
AND U.iduser = I.iduser
AND P.IDINVOICE = I.IDINVOICE
AND p.idp = c.idpa
AND c.model='S'
AND c.color='BLUE'
AND extract(YEAR FROM i.invoicedate) IN (2021);