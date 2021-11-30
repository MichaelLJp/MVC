CREATE PROCEDURE SP_Prueba1
AS
PRINT 'HOLA MUNDO'

CREATE PROC SP_CONSULTA 
AS 
SELECT * FROM productos
WHERE cod_prod= 'A005'

EXEC SP_CONSULTA

CREATE PROC SP_RestarExistencia
@CodProd as varchar(4),
@Cantidad as int 
AS 
UPDATE productos SET existencia= existencia -@Cantidad
WHERE cod_prod=@CodProd

SELECT * FROM productos

EXEC SP_RestarExistencia 'A003',45

CREATE PROC SP_SumarExistencia
@CodProd as varchar(4),
@Cantidad as int 
AS 
UPDATE productos SET existencia= existencia + @Cantidad
WHERE cod_prod=@CodProd

EXEC SP_SumarExistencia 'A009', 100


CREATE PROC SP_createClients
@ID_cli int, 
@Name_cli varchar(20),
@Document_type varchar (20),
@Document_number varchar (20),
@Address_place varchar (50),
@Phone varchar (20),
@Email varchar(20),
@Date_create varchar(30)
AS BEGIN
	INSERT INTO clients(
	id, nameClient, documentType, documentNumber, addressPlace, phone, email, dateCreate) 
	VALUES (
	@ID_cli,@Name_cli,@Document_type,@Document_number,@Address_place,@Phone,@Email,@Date_create)
	END
GO

SELECT * FROM clients;



ALTER PROC SP_clientUpdate 
@idClient varchar(20),
@Name_cli varchar(20),
@Document_type varchar (20),
@Document_number varchar (20),
@Address_place varchar (50),
@Phone varchar (20),
@Email varchar(20)
AS BEGIN
	SET NOCOUNT ON;
		UPDATE clients
		SET nameClient=@Name_cli, documentType=@Document_type, documentNumber=@Document_number, 
		addressPlace=@Address_place, phone=@Phone, email=@Email
		WHERE id = @idClient
	END
GO
EXEC SP_clientUpdate  2,'LEO ', 'C.C', '1022434316', 'Calle8', '555', 'email@mail.com'


CREATE PROC SP_clientCreate
@Name_cli varchar(20),
@Document_type varchar (20),
@Document_number varchar (20),
@Address_place varchar (50),
@Phone varchar (20),
@Email varchar(20),
@Date_create varchar(20)
AS BEGIN
	INSERT INTO clients(
	nameClient, documentType, documentNumber, addressPlace, phone, email, dateCreate) 
	VALUES (
	@Name_cli,@Document_type,@Document_number,@Address_place,@Phone,@Email,@Date_create)
	END
GO

SELECT * FROM clients
EXEC SP_clientCreate  'LEO ', 'C.C', '1022434316', 'Calle8', '555', 'email@mail.com', '24-08' 

CREATE PROCEDURE SP_clientDelete
	@idClient int
	AS 
		BEGIN
		SET NOCOUNT ON;
			DELETE FROM clients
			WHERE id = @idClient
		END
	GO

CREATE PROCEDURE SP_clientList
	AS
		BEGIN
		SET NOCOUNT ON;
			SELECT * FROM clients
		END
	GO