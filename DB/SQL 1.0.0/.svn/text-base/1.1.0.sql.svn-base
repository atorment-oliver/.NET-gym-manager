-- =============================================
-- Autor:		Diego Zalles - Oliver Menacho
-- Fecha:		13/08/2012
-- Descripción:	Base de datos VIPCENTER
-- Versión:		1.1.0
-- =============================================

USE [VIPCENTER]
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SEC].[Privileges_TraerXRolName]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SEC].[Privileges_TraerXRolName]
END
GO

CREATE PROCEDURE [SEC].[Privileges_TraerXRolName]
    @rolName		nvarchar(256)
AS
BEGIN
	SELECT p.id, p.nombre, p.descripcion  
	FROM [SEC].[RolesInPrivileges] rp JOIN [SEC].[Privileges] p ON rp.privilegeId = p.id
	WHERE rp.roleName = @rolName;
END
GO

-- Cambie de nombre a este procedimiento por eso lo borro
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SEC].[Privileges_TraerXRolIdPrivilegeName]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SEC].[Privileges_TraerXRolIdPrivilegeName]
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SEC].[Privileges_TraerXRolPrivilege]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SEC].[Privileges_TraerXRolPrivilege]
END
GO

CREATE PROCEDURE [SEC].[Privileges_TraerXRolPrivilege]
    @rolName		varchar(256),  
    @privilegeName	varchar(100)
AS
BEGIN
	SELECT p.id, p.nombre, p.descripcion  
	FROM [SEC].[RolesInPrivileges] rp JOIN [SEC].[Privileges] p ON rp.privilegeId = p.id 
	WHERE p.nombre = @privilegeName  
	AND rp.RoleName = @rolName;
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SEC].[Privileges_TraerTodos]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SEC].[Privileges_TraerTodos]
END
GO

CREATE PROCEDURE [SEC].[Privileges_TraerTodos]
AS
BEGIN
	SELECT p.id, p.nombre, p.descripcion  
	FROM [SEC].[Privileges] p;
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SEC].[RolesInPrivileges_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SEC].[RolesInPrivileges_Insertar]
END
GO

CREATE PROCEDURE [SEC].[RolesInPrivileges_Insertar]
	@id				int OUTPUT,
	@roleName		nvarchar(256), 
	@privilegeId	int 
AS
BEGIN
	INSERT INTO [SEC].[RolesInPrivileges](roleName, privilegeId) 
	VALUES (@roleName, @privilegeId)
	SET @Id = SCOPE_IDENTITY() 
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SEC].[RolesInPrivileges_EliminarXRolName]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SEC].[RolesInPrivileges_EliminarXRolName]
END
GO

CREATE PROCEDURE [SEC].[RolesInPrivileges_EliminarXRolName]
	@roleName			nvarchar(256)
AS
BEGIN
	DECLARE @number int 	
	SET @number =	(	SELECT count(*) 
						FROM [SEC].[RolesInPrivileges] rp 
						WHERE rp.roleName = @roleName
					)

	DELETE FROM [SEC].[RolesInPrivileges]
	WHERE roleName = @roleName
	RETURN @number
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Empresa_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Empresa_Insertar]
END
GO

CREATE PROCEDURE [vip].[Empresa_Insertar]
	@id				int OUTPUT,
	@nombre	varchar(100),
	@descripcion	varchar(250),
	@nombrePersonaContacto	varchar(100),
	@telefono	varchar(10),
	@correo	varchar(150),
	@direccion	varchar(250),
	@fechaRegistro	datetime,
	@estado	bit,
	@usuarioId	uniqueidentifier,
	@fecha	datetime
AS
BEGIN
	INSERT INTO [vip].[Empresa](nombre, descripcion, nombrePersonaContacto, telefono, correo, direccion, fechaRegistro, estado, usuarioId, fecha) 
	VALUES (@nombre, @descripcion, @nombrePersonaContacto, @telefono, @correo, @direccion, @fechaRegistro, @estado, @usuarioId, @fecha) 
	SET @Id = SCOPE_IDENTITY() 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Empresa_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Empresa_Actualizar]
END
GO

create PROCEDURE [vip].[Empresa_Actualizar]
	@id				int,
	@nombre	varchar(100),
	@descripcion	varchar(250),
	@nombrePersonaContacto	varchar(100),
	@telefono	varchar(10),
	@correo	varchar(150),
	@direccion	varchar(250),
	@fechaRegistro	datetime,
	@estado	bit,
	@usuarioId	uniqueidentifier,
	@fecha	datetime
AS
BEGIN
	Update [vip].[Empresa]
	SET nombre = @nombre,
	descripcion = @descripcion,
	nombrePersonaContacto = @nombrePersonaContacto,
	telefono = @telefono,
	correo = @correo,
	direccion = @direccion,
	fechaRegistro = @fechaRegistro,
	estado = @estado,
	usuarioId = @usuarioId,
	fecha = @fecha
	WHERE Id = @Id
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Empresa_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Empresa_Eliminar]
END
GO

CREATE PROCEDURE [vip].[Empresa_Eliminar]
	@Id					int 
AS
BEGIN
    DELETE FROM [vip].[Empresa]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Empresa_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Empresa_TraerXCriterio]
END
GO

CREATE PROCEDURE [vip].[Empresa_TraerXCriterio] 
	@nombre	varchar(20) = '',
	@nombrePersonaContacto	varchar(100) = '',
	@correo		varchar(150) = '',
	@estado		varchar(10) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
	if(@estado='')
	BEGIN
		SELECT *
		FROM [vip].[Empresa]
		WHERE
		nombre like '%' + @nombre + '%' 
		/*and nombrePersonaContacto like '%' + @nombrePersonaContacto + '%'
		and correo like '%' + @correo + '%'*/
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'

		ORDER BY Id asc 
		RETURN
	END
	IF(@estado = 'True')
	BEGIN
		SELECT *
		FROM [vip].[Empresa]
		WHERE
		nombre like '%' + @nombre + '%' 
		/*and nombrePersonaContacto like '%' + @nombrePersonaContacto + '%'
		and correo like '%' + @correo + '%'*/
		and estado = 'true'

		ORDER BY Id asc 
	END
	IF(@estado = 'False')
	BEGIN
		SELECT *
		FROM [vip].[Empresa]
		WHERE
		nombre like '%' + @nombre + '%' 
		/*and nombrePersonaContacto like '%' + @nombrePersonaContacto + '%'
		and correo like '%' + @correo + '%'*/
		and estado = 'false'

		ORDER BY Id asc 
	END
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_Insertar]
END
GO
CREATE PROCEDURE [vip].[Cliente_Insertar]
	@id				int OUTPUT,
	@nombre	varchar(50),
	@apellidos	varchar(100),
	@direccion	varchar(250),
	@telefono	varchar(10),
	@celular	varchar(10),
	@celular2	varchar(10),
	@ci	varchar(15),
	@correo	varchar(150),
	@ocupacion	varchar(150),
	@lugarTrabajo	varchar(250),
	@telefonoTrabajo	varchar(10),
	@correoTrabajo	varchar(150),
	@fechaNacimiento	datetime,
	@genero	char(1),
	@estadoCivil	char(1),
	@tieneHijos	bit,
	@numeroHijos	int,
	@fechaIngreso	datetime,
	@numeroCliente	int,
	@estado	char(1),
	@recibirNotificaciones	bit,
	@empresaId	int,
	@usuarioId	uniqueidentifier,
	@fecha	datetime
AS
BEGIN
	INSERT INTO [vip].[Cliente_Insertar](nombre, apellidos, direccion, telefono, celular, celular2, ci, correo, ocupacion, lugarTrabajo, telefonoTrabajo, correoTrabajo, fechaNacimiento, genero, estadoCivil, tieneHijos, numeroHijos, fechaIngreso, numeroCliente, estado, recibirNotificaciones, empresaId, usuarioId, fecha) 
	VALUES (@nombre, @apellidos, @direccion, @telefono, @celular, @celular2, @ci, @correo, @ocupacion, @lugarTrabajo, @telefonoTrabajo, @correoTrabajo, @fechaNacimiento, @genero, @estadoCivil, @tieneHijos, @numeroHijos, @fechaIngreso, @numeroCliente, @estado, @recibirNotificaciones, @empresaId, @usuarioId, @fecha) 
	SET @Id = SCOPE_IDENTITY() 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_Actualizar]
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

create PROCEDURE [vip].[Cliente_Actualizar]
	@id				int,
	@nombre	varchar(50),
	@apellidos	varchar(100),
	@direccion	varchar(250),
	@telefono	varchar(10),
	@celular	varchar(10),
	@celular2	varchar(10),
	@ci	varchar(15),
	@correo	varchar(150),
	@ocupacion	varchar(150),
	@lugarTrabajo	varchar(250),
	@telefonoTrabajo	varchar(10),
	@correoTrabajo	varchar(150),
	@fechaNacimiento	datetime,
	@genero	char(1),
	@estadoCivil	char(1),
	@tieneHijos	bit,
	@numeroHijos	int,
	@fechaIngreso	datetime,
	@numeroCliente	int,
	@estado	char(1),
	@recibirNotificaciones	bit,
	@empresaId	int,
	@usuarioId	uniqueidentifier,
	@fecha	datetime
AS
BEGIN
	Update [vip].[Cliente]
	SET nombre = @nombre,
	apellidos = @apellidos,
	direccion = @direccion,
	telefono = @telefono,
	celular = @celular,
	celular2 = @celular2,
	ci = @ci,
	correo = @correo,
	ocupacion = @ocupacion,
	lugarTrabajo = @lugarTrabajo,
	telefonoTrabajo = @telefonoTrabajo,
	correoTrabajo = @correoTrabajo,
	fechaNacimiento = @fechaNacimiento,
	genero = @genero,
	estadoCivil = @estadoCivil,
	tieneHijos = @tieneHijos,
	numeroHijos = @numeroHijos,
	fechaIngreso = @fechaIngreso,
	numeroCliente = @numeroCliente,
	estado = @estado,
	recibirNotificaciones = @recibirNotificaciones,
	empresaId = @empresaId,
	usuarioId = @usuarioId,
	fecha = @fecha
	WHERE Id = @Id
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_Eliminar]
END
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [vip].[Cliente_Eliminar]
	@Id					int 
AS
BEGIN
    DELETE FROM [vip].[Cliente]
	WHERE Id = @Id 
END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Empresa_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Empresa_TraerXId] 
END
GO

create PROCEDURE [vip].[Empresa_TraerXId] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Empresa]
		WHERE id = @id
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[TipoPaquete_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[TipoPaquete_Insertar]
END
GO

CREATE PROCEDURE [vip].[TipoPaquete_Insertar]
	@id				int OUTPUT,
	@nombre	varchar(100),
	@limiteServicios	varchar(100),
	@estado	bit
AS
BEGIN
	if(@limiteServicios='')
	begin
		INSERT INTO [vip].[TipoPaquete](nombre, limiteServicios, estado) 
		VALUES (@nombre, null, @estado) 
		SET @Id = SCOPE_IDENTITY() 
	end
	else
	begin
		INSERT INTO [vip].[TipoPaquete](nombre, limiteServicios, estado) 
		VALUES (@nombre, @limiteServicios, @estado) 
		SET @Id = SCOPE_IDENTITY() 
	end
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[TipoPaquete_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[TipoPaquete_Actualizar]
END
GO

create PROCEDURE [vip].[TipoPaquete_Actualizar]
	@id				int,
	@nombre	varchar(100),
	@limiteServicios	varchar(100),
	@estado	bit
AS
BEGIN
	if(@limiteServicios = '')
	begin
		Update [vip].[TipoPaquete]
		SET nombre = @nombre,
		limiteServicios = null,
		estado = @estado
		WHERE Id = @Id
	end
	else
	begin
		Update [vip].[TipoPaquete]
		SET nombre = @nombre,
		limiteServicios = @limiteServicios,
		estado = @estado
		WHERE Id = @Id
	end
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[TipoPaquete_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[TipoPaquete_Eliminar]
END
GO

CREATE PROCEDURE [vip].[TipoPaquete_Eliminar]
	@Id					int 
AS
BEGIN
    DELETE FROM [vip].[TipoPaquete]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[TipoPaquete_TraerTodos]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[TipoPaquete_TraerTodos]  
END
GO

CREATE PROCEDURE [vip].[TipoPaquete_TraerTodos] 

AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT id, nombre, isnull(limiteServicios,'') limiteServicios, estado
		FROM [vip].[TipoPaquete]
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[TipoPaquete_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[TipoPaquete_TraerXId] 
END
GO

CREATE PROCEDURE [vip].[TipoPaquete_TraerXId] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT id, nombre, limiteServicios, estado
		FROM [vip].[TipoPaquete]
		WHERE id = @id
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[TipoPaquete_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[TipoPaquete_TraerXCriterio] 
END
GO

CREATE PROCEDURE [vip].[TipoPaquete_TraerXCriterio] 
	@nombre				varchar(100) = '',
	@limiteServicios	varchar(100) = '',
	@estado				varchar(10) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
	if(@estado='')
	BEGIN
		SELECT id, nombre, limiteServicios, estado
		FROM [vip].[TipoPaquete]
		WHERE
		nombre like '%' + @nombre + '%' 
		and (select CAST(isnull(limiteServicios,'') AS char(100))) like '%' + @limiteServicios + '%'
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		ORDER BY Id asc 
		RETURN
	END
	IF(@estado = 'True')
	BEGIN
		SELECT id, nombre, limiteServicios, estado
		FROM [vip].[TipoPaquete]
		WHERE
		nombre like '%' + @nombre + '%' 
		and (select CAST(isnull(limiteServicios,'') AS char(100))) like '%' + @limiteServicios + '%'
		and estado = 'true'

		ORDER BY Id asc 
	END
	IF(@estado = 'False')
	BEGIN
		SELECT id, nombre, limiteServicios, estado
		FROM [vip].[TipoPaquete]
		WHERE
		nombre like '%' + @nombre + '%' 
		and (select CAST(isnull(limiteServicios,'') AS char(100))) like '%' + @limiteServicios + '%'
		and estado = 'false'

		ORDER BY Id asc 
	END
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Paquete_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Paquete_Insertar]
END
GO

CREATE PROCEDURE [vip].[Paquete_Insertar]
	@id				int OUTPUT,
	@nombre			varchar(100),
	@unidadId		int,
	@tiempo			int,
	@tipoPaqueteId	int,
	@precio			decimal(8, 2),
	@diasValidez	varchar(100),
	@fechaRegistro	datetime,
	@estado			bit,
	@usuarioId		uniqueidentifier,
	@fecha			datetime
AS
BEGIN
	if(@diasValidez='')
	begin
		INSERT INTO [vip].[Paquete](nombre, unidadId, tiempo, tipoPaqueteId, precio, diasValidez, fechaRegistro, estado, usuarioId, fecha) 
		VALUES (@nombre, @unidadId, @tiempo, @tipoPaqueteId, @precio, null, @fechaRegistro, @estado, @usuarioId, @fecha) 
		SET @Id = SCOPE_IDENTITY() 
	end
	else
	begin
		INSERT INTO [vip].[Paquete](nombre, unidadId, tiempo, tipoPaqueteId, precio, diasValidez, fechaRegistro, estado, usuarioId, fecha) 
		VALUES (@nombre, @unidadId, @tiempo, @tipoPaqueteId, @precio, @diasValidez, @fechaRegistro, @estado, @usuarioId, @fecha) 
		SET @Id = SCOPE_IDENTITY() 
	end
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Paquete_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Paquete_Actualizar]
END
GO

create PROCEDURE [vip].[Paquete_Actualizar]
	@id				int,
	@nombre			varchar(100),
	@unidadId		int,
	@tiempo			int,
	@tipoPaqueteId	int,
	@precio			decimal(8, 2),
	@diasValidez	varchar(100),
	@fechaRegistro	datetime,
	@estado			bit,
	@usuarioId		uniqueidentifier,
	@fecha			datetime
AS
BEGIN

if(@diasValidez = '')
	begin
		Update [vip].[Paquete]
		SET nombre = @nombre,
		unidadId = @unidadId,
		tiempo = @tiempo,
		tipoPaqueteId = @tipoPaqueteId, 
		precio = @precio,
		diasValidez = null,
		fechaRegistro = @fechaRegistro,
		estado = @estado,
		usuarioId = @usuarioId,
		fecha = @fecha
		WHERE Id = @Id
	end
	else
	begin
		Update [vip].[Paquete]
		SET nombre = @nombre,
		unidadId = @unidadId,
		tiempo = @tiempo,
		tipoPaqueteId = @tipoPaqueteId, 
		precio = @precio,
		diasValidez = @diasValidez,
		fechaRegistro = @fechaRegistro,
		estado = @estado,
		usuarioId = @usuarioId,
		fecha = @fecha
		WHERE Id = @Id
	end
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Paquete_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Paquete_Eliminar]
END
GO

CREATE PROCEDURE [vip].[Paquete_Eliminar]
	@Id					int 
AS
BEGIN
    DELETE FROM [vip].[Paquete]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Paquete_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Paquete_TraerXId] 
END
GO

CREATE PROCEDURE [vip].[Paquete_TraerXId] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Paquete] p
		WHERE p.id = @id
		ORDER BY p.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Paquete_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Paquete_TraerXCriterio] 
END
GO

CREATE PROCEDURE [vip].[Paquete_TraerXCriterio] 
	@nombre				varchar(100) = '',
	@tipoPaqueteId		varchar(100) = '',
	@estado				varchar(10) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
	if(@estado='')
	BEGIN
		SELECT *
		FROM [vip].[Paquete]
		WHERE
		nombre like '%' + @nombre + '%' 
		and (select CAST(tipoPaqueteId AS char(100))) like '%' + @tipoPaqueteId + '%'
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		ORDER BY Id asc 
		RETURN
	END
	IF(@estado = 'True')
	BEGIN
		SELECT *
		FROM [vip].[Paquete]
		WHERE
		nombre like '%' + @nombre + '%' 
		and (select CAST(tipoPaqueteId AS char(100))) like '%' + @tipoPaqueteId + '%'
		and estado = 'true'

		ORDER BY Id asc 
	END
	IF(@estado = 'False')
	BEGIN
		SELECT *
		FROM [vip].[Paquete]
		WHERE
		nombre like '%' + @nombre + '%' 
		and (select CAST(tipoPaqueteId AS char(100))) like '%' + @tipoPaqueteId + '%'
		and estado = 'false'

		ORDER BY Id asc 
	END
	END
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Empresa' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[Empresa]
	ALTER COLUMN fechaRegistro datetime
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Unidad_TraerTodos]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Unidad_TraerTodos] 
END
GO

CREATE PROCEDURE [vip].[Unidad_TraerTodos] 
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Unidad]
		ORDER BY id asc 
		RETURN
	END
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Sala_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Sala_Insertar]
END
GO

CREATE PROCEDURE [vip].[Sala_Insertar]
	@id		int OUTPUT,
	@nombre	varchar(100),
	@estado	bit
AS
BEGIN
	INSERT INTO [vip].[Sala](nombre, estado) 
	VALUES (@nombre, @estado) 
	SET @Id = SCOPE_IDENTITY() 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Sala_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Sala_Actualizar]
END
GO

CREATE PROCEDURE [vip].[Sala_Actualizar]
	@id		int,
	@nombre	varchar(100),
	@estado	bit
AS
BEGIN
	Update [vip].[Sala]
	SET nombre = @nombre, 
	estado = @estado
	WHERE Id = @Id
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Sala_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Sala_Eliminar]
END
GO

CREATE PROCEDURE [vip].[Sala_Eliminar]
	@Id		int 
AS
BEGIN
    DELETE FROM [vip].[Sala]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Sala_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Sala_TraerXCriterio] 
END
GO

CREATE PROCEDURE [vip].[Sala_TraerXCriterio] 
	@nombre				varchar(100) = '' 
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT id, nombre, estado
		FROM [vip].[Sala]
		WHERE
		nombre like '%' + @nombre + '%' 
		ORDER BY Id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Sala_TraerXEstado]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Sala_TraerXEstado] 
END
GO

CREATE PROCEDURE [vip].[Sala_TraerXEstado] 
	@estado				varchar(100) = '' 
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT id, nombre, estado
		FROM [vip].[Sala]
		WHERE
		estado = @estado
		ORDER BY Id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Sala_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Sala_TraerXId] 
END
GO

CREATE PROCEDURE [vip].[Sala_TraerXId] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT id, nombre, estado
		FROM [vip].[Sala]
		WHERE id = @id
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS(SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'ck_TipoPaquete_Limite') AND parent_object_id = OBJECT_ID(N'Paquete'))
BEGIN
	ALTER TABLE [vip].[TipoPaquete] 
	DROP CONSTRAINT ck_TipoPaquete_Limite
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Paquete_AsignadoACliente]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Paquete_AsignadoACliente]
END
GO

CREATE PROCEDURE [vip].[Paquete_AsignadoACliente] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Paquete]
		WHERE id = @id
		and id in(select c.paqueteId from [vip].[ClientePaquete] c )
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Paquete' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[Paquete]
	ALTER COLUMN fechaRegistro datetime
END
GO

IF EXISTS(SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'ck_Paquete_Validez') AND parent_object_id = OBJECT_ID(N'Paquete'))
BEGIN
	ALTER TABLE [vip].[Paquete] 
	DROP CONSTRAINT ck_Paquete_Validez
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[TipoPaquete_AsignadoAPaquete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[TipoPaquete_AsignadoAPaquete]
END
GO

CREATE PROCEDURE [vip].[TipoPaquete_AsignadoAPaquete] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[TipoPaquete]
		WHERE id = @id
		and id in(select p.tipoPaqueteId from [vip].[Paquete] p )
		ORDER BY id asc 
		RETURN
	END
END
GO


-- MODIFICACION DE TABLAS

IF NOT EXISTS (SELECT * FROM   sys.columns WHERE  object_id = OBJECT_ID(N'[vip].[Horario]') AND name = 'finDeSemana')
BEGIN
    ALTER TABLE [vip].[Horario] 
	ADD finDeSemana bit not null default '0'
END
GO

/*IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Horario' AND xtype='U')
	ALTER TABLE [vip].[Horario] 
	ADD finDeSemana bit not null default '0'
GO
*/
-- CREACION DE STORED PROCEDURES



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Horario_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Horario_Insertar]
END
GO

CREATE PROCEDURE [vip].[Horario_Insertar]
	@id		int OUTPUT,
	@salaID	int, 
	@horaInicio varchar(5), 
	@horaFin varchar(5), 	
	@finDeSemana bit,
	@estado	bit
AS
BEGIN
	INSERT INTO [vip].[Horario](horaInicio, horaFin, salaId, estado, finDeSemana) 
	VALUES (@horaInicio, @horaFin, @salaID, @estado, @finDeSemana) 
	SET @Id = SCOPE_IDENTITY() 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Horario_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Horario_Actualizar]
END
GO

CREATE PROCEDURE [vip].[Horario_Actualizar]
	@id		int,
	@salaID	int, 
	@horaInicio varchar(5), 
	@horaFin varchar(5), 	
	@finDeSemana bit,
	@estado	bit
AS
BEGIN
	Update [vip].[Horario]
	SET salaID = @salaID, 
	horaInicio = @horaInicio, 
	horaFin = @horaFin, 
	finDeSemana = @finDeSemana, 
	estado = @estado
	WHERE Id = @Id
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Horario_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Horario_Eliminar]
END
GO

CREATE PROCEDURE [vip].[Horario_Eliminar]
	@Id		int 
AS
BEGIN
    DELETE FROM [vip].[Horario]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Horario_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Horario_TraerXCriterio] 
END
GO

CREATE PROCEDURE [vip].[Horario_TraerXCriterio] 
	@salaId			int, 
	@horaInicio		varchar(5) = '', 
	@horaFin		varchar(5) = '', 	
	@finDeSemana	bit = null  
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		DECLARE @HI varchar(40)
		SET @HI = convert(varchar(17), GETdate(), 101) + ' ' + @horaInicio
		SET @HI = convert(datetime,@HI,101)
		
		DECLARE @HF varchar(40)
		SET @HF = convert(varchar(17), GETdate(), 101) + ' ' + @horaFin
		SET @HF = convert(datetime,@HF,101)
	
		SELECT id, salaId, horaInicio, horaFin, finDeSemana, estado
		FROM [vip].[Horario]
		WHERE (salaId = @salaId or @salaId = 0 )
		AND @HI <= convert(datetime,convert(varchar(17), GETdate(), 101) + ' ' + horaInicio, 101)
		AND @HF >= convert(datetime,convert(varchar(17), GETdate(), 101) + ' ' + horaFin, 101) 
		AND (finDeSemana = @finDeSemana OR @finDeSemana is null) 
		ORDER BY Id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Horario_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Horario_TraerXId] 
END
GO

CREATE PROCEDURE [vip].[Horario_TraerXId] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT id, horaInicio, horaFin, salaId, estado, finDeSemana
		FROM [vip].[Horario]
		WHERE id = @id
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Horario_TraerXSala]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Horario_TraerXSala] 
END
GO

CREATE PROCEDURE [vip].[Horario_TraerXSala] 
	@salaId	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT id, horaInicio, horaFin, salaId, estado, finDeSemana
		FROM [vip].[Horario]
		WHERE salaId = @SalaId
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Horario_TraerXCriterioCruce]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Horario_TraerXCriterioCruce] 
END
GO

CREATE PROCEDURE [vip].[Horario_TraerXCriterioCruce] 
	@salaId			int, 
	@horaInicio		varchar(5) = '', 
	@horaFin		varchar(5) = '', 	
	@finDeSemana	bit, 
	@estado			bit
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		DECLARE @HI varchar(40)
		SET @HI = convert(varchar(17), GETdate(), 101) + ' ' + @horaInicio
		SET @HI = convert(datetime,@HI,101)
		
		DECLARE @HF varchar(40)
		SET @HF = convert(varchar(17), GETdate(), 101) + ' ' + @horaFin
		SET @HF = convert(datetime,@HF,101)
	
		SELECT id, salaId, horaInicio, horaFin, finDeSemana, estado
		FROM [vip].[Horario]
		WHERE (salaId = @salaId or @salaId = 0 )
		AND 
		(
			(	@HI >= convert(datetime,convert(varchar(17), GETdate(), 101) + ' ' + horaInicio, 101)
				AND
				@HI < convert(datetime,convert(varchar(17), GETdate(), 101) + ' ' + horaFin, 101)
			)
			OR 
			(
				@HF > convert(datetime,convert(varchar(17), GETdate(), 101) + ' ' + horaInicio, 101) 
				AND 
				@HF <= convert(datetime,convert(varchar(17), GETdate(), 101) + ' ' + horaFin, 101)
			)
		)
		AND estado = @estado 
		AND finDeSemana = @finDeSemana
		ORDER BY Id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_Insertar]
END
GO

CREATE PROCEDURE [vip].[Cliente_Insertar]
	@id				int OUTPUT,
	@nombre	varchar(50),
	@apellidos	varchar(100),
	@direccion	varchar(250)	,
	@telefono	varchar(10)	,
	@celular	varchar(10),
	@ci	varchar(15)	,
	@correo	varchar(150)	,
	@ocupacion	varchar(150)	,
	@lugarTrabajo	varchar(250)	,
	@telefonoTrabajo	varchar(10)	,
	@correoTrabajo	varchar(150)	,
	@fechaNacimiento	datetime	,
	@genero	char(1)	,
	@estadoCivil	char(1)	,
	@tieneHijos	bit	,
	@numeroHijos	int	,
	@fechaIngreso	datetime	,
	@numeroCliente	int	,
	@recibirNotificaciones	bit	,
	@empresaId	int	,
	@usuarioId	uniqueidentifier	,
	@fecha	datetime	,
	@estado	char(1)
AS
BEGIN
	DECLARE @num int;
	set @num = 0;
	set @num = (SELECT isnull(MAX(cc.numeroCliente),0)+1 from [vip].[Cliente] cc);
	if(@empresaId = '0')
	BEGIN
		INSERT INTO [vip].[Cliente](nombre, apellidos, direccion,telefono,celular,ci,correo,ocupacion,lugarTrabajo,telefonoTrabajo,correoTrabajo,fechaNacimiento,genero,estadoCivil,tieneHijos,numeroHijos,fechaIngreso,numeroCliente,recibirNotificaciones,empresaId,usuarioId,fecha,estado) 
		VALUES (@nombre, @apellidos, @direccion,@telefono,@celular,@ci,@correo,@ocupacion,@lugarTrabajo,@telefonoTrabajo,@correoTrabajo,@fechaNacimiento,@genero,@estadoCivil,@tieneHijos,@numeroHijos,@fechaIngreso,@num,@recibirNotificaciones,NULL,@usuarioId,@fecha,@estado) 
		SET @Id = SCOPE_IDENTITY() 
	END
	ELSE
	BEGIN
		INSERT INTO [vip].[Cliente](nombre, apellidos, direccion,telefono,celular,ci,correo,ocupacion,lugarTrabajo,telefonoTrabajo,correoTrabajo,fechaNacimiento,genero,estadoCivil,tieneHijos,numeroHijos,fechaIngreso,numeroCliente,recibirNotificaciones,empresaId,usuarioId,fecha,estado) 
		VALUES (@nombre, @apellidos, @direccion,@telefono,@celular,@ci,@correo,@ocupacion,@lugarTrabajo,@telefonoTrabajo,@correoTrabajo,@fechaNacimiento,@genero,@estadoCivil,@tieneHijos,@numeroHijos,@fechaIngreso,@num,@recibirNotificaciones,@empresaId,@usuarioId,@fecha,@estado) 
		SET @Id = SCOPE_IDENTITY() 
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_Actualizar]
END
GO

CREATE PROCEDURE [vip].[Cliente_Actualizar]
	@id				int,
	@nombre	varchar(50),
	@apellidos	varchar(100),
	@direccion	varchar(250)	,
	@telefono	varchar(10)	,
	@celular	varchar(10),
	@ci	varchar(15)	,
	@correo	varchar(150)	,
	@ocupacion	varchar(150)	,
	@lugarTrabajo	varchar(250)	,
	@telefonoTrabajo	varchar(10)	,
	@correoTrabajo	varchar(150)	,
	@fechaNacimiento	datetime	,
	@genero	char(1)	,
	@estadoCivil	char(1)	,
	@tieneHijos	bit	,
	@numeroHijos	int	,
	@fechaIngreso	datetime	,
	@numeroCliente	int	,
	@recibirNotificaciones	bit	,
	@empresaId	int	,
	@usuarioId	uniqueidentifier	,
	@fecha	datetime	,
	@estado	char(1)
AS
BEGIN
	if(@empresaId = '0')
	BEGIN
	Update [vip].[Cliente]
	SET nombre = @nombre,
	apellidos = @apellidos,
	direccion = @direccion,
	telefono = @telefono,
	celular = @celular,
	ci = @ci,
	correo = @correo,
	ocupacion = @ocupacion,
	lugarTrabajo = @lugarTrabajo,
	telefonoTrabajo = @telefonoTrabajo,
	correoTrabajo = @correoTrabajo,
	fechaNacimiento = @fechaNacimiento,
	genero = @genero,
	estadoCivil = @estadoCivil,
	tieneHijos = @tieneHijos,
	numeroHijos = @numeroHijos,
	fechaIngreso = @fechaIngreso,
	numeroCliente = @numeroCliente,
	recibirNotificaciones = @recibirNotificaciones,
	empresaId = NULL,
	usuarioId = @usuarioId,
	fecha = @fecha,
	estado = @estado
	WHERE Id = @id
	END
	else
	BEGIN
	Update [vip].[Cliente]
	SET nombre = @nombre,
	apellidos = @apellidos,
	direccion = @direccion,
	telefono = @telefono,
	celular = @celular,
	ci = @ci,
	correo = @correo,
	ocupacion = @ocupacion,
	lugarTrabajo = @lugarTrabajo,
	telefonoTrabajo = @telefonoTrabajo,
	correoTrabajo = @correoTrabajo,
	fechaNacimiento = @fechaNacimiento,
	genero = @genero,
	estadoCivil = @estadoCivil,
	tieneHijos = @tieneHijos,
	numeroHijos = @numeroHijos,
	fechaIngreso = @fechaIngreso,
	numeroCliente = @numeroCliente,
	recibirNotificaciones = @recibirNotificaciones,
	empresaId = @empresaId,
	usuarioId = @usuarioId,
	fecha = @fecha,
	estado = @estado
	WHERE Id = @id
	END
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_Eliminar]
END
GO

CREATE PROCEDURE [vip].[Cliente_Eliminar]
	@Id					int 
AS
BEGIN
    DELETE FROM [vip].[Cliente]
	WHERE Id = @Id 
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_Cerrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_Cerrar]
END
GO

CREATE PROCEDURE [vip].[Cliente_Cerrar]
	@id				int,
	@estado	bit
AS
BEGIN

	Update [vip].[Cliente]
	SET 
	estado = @estado
	WHERE Id = @id
	
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_TraerXId] 
END
GO

CREATE PROCEDURE [vip].[Cliente_TraerXId] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT c.apellidos,c.celular,c.correo,c.correoTrabajo,c.direccion,c.empresaId,c.estado,c.estadoCivil,c.fecha
		,c.fechaIngreso,c.fechaNacimiento,c.genero,c.id,c.lugarTrabajo,c.nombre,c.numeroCliente,c.numeroHijos,c.ocupacion
		,c.recibirNotificaciones,c.telefono,c.telefonoTrabajo,c.tieneHijos,c.usuarioId, ([VIP].[TraerTextoTexto] (c.ci)) ciCi,
		([VIP].[TraerNumeroTexto] (c.ci)) ci
		FROM [vip].[Cliente] c
		WHERE c.id = @id
		ORDER BY c.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_TraerSinCi]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_TraerSinCi] 
END
GO

CREATE PROCEDURE [vip].[Cliente_TraerSinCi] 

AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT c.nombre, c.apellidos,c.celular,c.correo,c.correoTrabajo,c.direccion,c.empresaId,c.estado,c.estadoCivil,c.fecha
		,c.fechaIngreso,c.fechaNacimiento,c.genero,c.id,c.lugarTrabajo,c.nombre,c.numeroCliente,c.numeroHijos,c.ocupacion
		,c.recibirNotificaciones,c.telefono,c.telefonoTrabajo,c.tieneHijos,c.usuarioId, ([VIP].[TraerTextoTexto] (c.ci)) ciCi,
		([VIP].[TraerNumeroTexto] (c.ci)) ci
		FROM [vip].[Cliente] c
		WHERE isnull(([VIP].[TraerNumeroTexto] (c.ci)),0) = 0
		ORDER BY c.id asc 
		RETURN
	END
END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_SinPagos]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_SinPagos] 
END
GO

CREATE PROCEDURE [vip].[Cliente_SinPagos] 

AS
BEGIN		
	SELECT * FROM [vip].[Cliente]
	WHERE id not in (select cp.clienteId from [vip].[ClientePaquete] cp
	)
	AND id not in (select d.clienteId from [vip].[DistribucionPago] d)
	and fechaingreso > '2013-02-02 12:00:00.000'
	
END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_TraerXCriterio] 
END
GO

CREATE PROCEDURE [vip].[Cliente_TraerXCriterio] 
	@nombre			varchar(100) = '',
	@correo				varchar(150) = '',
	@ci					varchar(15) = '',
	@estado				varchar(1) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
	IF(@nombre = '*')
	BEGIN
		SELECT c.apellidos,c.celular,c.correo,c.correoTrabajo,c.direccion,c.empresaId,c.estado,c.estadoCivil,c.fecha
		,c.fechaIngreso,c.fechaNacimiento,c.genero,c.id,c.lugarTrabajo,c.nombre,c.numeroCliente,c.numeroHijos,c.ocupacion
		,c.recibirNotificaciones,c.telefono,c.telefonoTrabajo,c.tieneHijos,c.usuarioId, ([VIP].[TraerTextoTexto] (c.ci)) ciCi,
		([VIP].[TraerNumeroTexto] (c.ci)) ci,isnull((select isnull(e.nombre,'-') from [vip].[Empresa] e where e.id = c.empresaId),'-') empresa, c.nombre + ' ' + c.apellidos nombreCompleto 
		FROM [vip].[Cliente] c
		WHERE
		c.correo like '%' + @correo + '%'
		and c.ci like '%' + @ci + '%'
		and c.estado like '%' + @estado + '%'
		ORDER BY c.nombre asc 
		RETURN
	END
	ELSE
	BEGIN
		SELECT c.apellidos,c.celular,c.correo,c.correoTrabajo,c.direccion,c.empresaId,c.estado,c.estadoCivil,c.fecha
		,c.fechaIngreso,c.fechaNacimiento,c.genero,c.id,c.lugarTrabajo,c.nombre,c.numeroCliente,c.numeroHijos,c.ocupacion
		,c.recibirNotificaciones,c.telefono,c.telefonoTrabajo,c.tieneHijos,c.usuarioId, ([VIP].[TraerTextoTexto] (c.ci)) ciCi,
		([VIP].[TraerNumeroTexto] (c.ci)) ci,isnull((select isnull(e.nombre,'-') from [vip].[Empresa] e where e.id = c.empresaId),'-') empresa, c.nombre + ' ' + c.apellidos nombreCompleto 
		FROM [vip].[Cliente] c
		WHERE
		c.apellidos + c.nombre like '%' + @nombre + '%' 
		
		and c.correo like '%' + @correo + '%'
		and c.ci like '%' + @ci + '%'
		and c.estado like '%' + @estado + '%'
		ORDER BY c.nombre asc 
		RETURN
	END
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_TraerXOrCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_TraerXOrCriterio] 
END
GO

CREATE PROCEDURE [vip].[Cliente_TraerXOrCriterio] 
	@nombre			varchar(100) = '',
	@correo				varchar(150) = '',
	@ci					varchar(15) = '',
	@estado				varchar(1) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
	IF(@nombre = '*')
	BEGIN
		SELECT c.apellidos,c.celular,c.correo,c.correoTrabajo,c.direccion,c.empresaId,c.estado,c.estadoCivil,c.fecha
		,c.fechaIngreso,c.fechaNacimiento,c.genero,c.id,c.lugarTrabajo,c.nombre,c.numeroCliente,c.numeroHijos,c.ocupacion
		,c.recibirNotificaciones,c.telefono,c.telefonoTrabajo,c.tieneHijos,c.usuarioId, ([VIP].[TraerTextoTexto] (c.ci)) ciCi,
		([VIP].[TraerNumeroTexto] (c.ci)) ci,isnull((select isnull(e.nombre,'-') from [vip].[Empresa] e where e.id = c.empresaId),'-') empresa, c.nombre + ' ' + c.apellidos nombreCompleto 
		FROM [vip].[Cliente] c
		WHERE
		c.correo like '%' + @correo + '%'
		and c.estado like '%' + @estado + '%'
		ORDER BY c.nombre asc 
		RETURN
	END
	ELSE
	BEGIN
		SELECT c.apellidos,c.celular,c.correo,c.correoTrabajo,c.direccion,c.empresaId,c.estado,c.estadoCivil,c.fecha
		,c.fechaIngreso,c.fechaNacimiento,c.genero,c.id,c.lugarTrabajo,c.nombre,c.numeroCliente,c.numeroHijos,c.ocupacion
		,c.recibirNotificaciones,c.telefono,c.telefonoTrabajo,c.tieneHijos,c.usuarioId, ([VIP].[TraerTextoTexto] (c.ci)) ciCi,
		([VIP].[TraerNumeroTexto] (c.ci)) ci,isnull((select isnull(e.nombre,'-') from [vip].[Empresa] e where e.id = c.empresaId),'-') empresa,c. nombre + ' ' + c.apellidos nombreCompleto
		FROM [vip].[Cliente] c
		WHERE
		c.apellidos + c.nombre like '%' + @nombre + '%' 
		
		and c.correo like '%' + @correo + '%'
		or c.ci like '%' + @ci + '%'
		and c.estado like '%' + @estado + '%'
		ORDER BY c.nombre asc 
		RETURN
	END
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_TraerMaximoNumero]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_TraerMaximoNumero] 
END
GO

CREATE PROCEDURE [vip].[Cliente_TraerMaximoNumero] 

AS
BEGIN		
	SELECT isnull(MAX(cc.numeroCliente),0)+1 
	FROM [vip].[Cliente] cc
END
GO


IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'ck_MovimientoCaja_MontoAdministracion' AND xtype='C')
BEGIN
	ALTER TABLE [vip].[MovimientoCaja] DROP CONSTRAINT ck_MovimientoCaja_MontoAdministracion
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'ck_MovimientoCaja_MontoApertura' AND xtype='C')
BEGIN
	ALTER TABLE [vip].[MovimientoCaja] DROP CONSTRAINT ck_MovimientoCaja_MontoApertura
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'ck_MovimientoCaja_MontoCierre' AND xtype='C')
BEGIN
	ALTER TABLE [vip].[MovimientoCaja] DROP CONSTRAINT ck_MovimientoCaja_MontoCierre
END
GO

IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MovimientoCaja' AND COLUMN_NAME = 'tipoCambio')
BEGIN
	ALTER TABLE [vip].[MovimientoCaja] 
	ADD tipoCambio decimal(8,2) not null default(6.96)
END
GO

IF EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MovimientoCaja' AND COLUMN_NAME = 'montoApertura')
BEGIN
	ALTER TABLE [vip].[MovimientoCaja] 
	DROP COLUMN montoApertura 
END
GO

IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MovimientoCaja' AND COLUMN_NAME = 'montoAperturaBob')
BEGIN
	ALTER TABLE [vip].[MovimientoCaja] 
	ADD montoAperturaBob decimal(8,2) not null default(0)
END
GO

IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MovimientoCaja' AND COLUMN_NAME = 'montoAperturaSus')
BEGIN
	ALTER TABLE [vip].[MovimientoCaja] 
	ADD montoAperturaSus decimal(8,2) not null default(0)
END
GO

IF EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MovimientoCaja' AND COLUMN_NAME = 'montoCierre')
BEGIN
	ALTER TABLE [vip].[MovimientoCaja] 
	DROP COLUMN montoCierre 
END
GO

IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MovimientoCaja' AND COLUMN_NAME = 'montoCierreBob')
BEGIN
	ALTER TABLE [vip].[MovimientoCaja] 
	ADD montoCierreBob decimal(8,2) not null default(0)
END
GO

IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MovimientoCaja' AND COLUMN_NAME = 'montoCierreSus')
BEGIN
	ALTER TABLE [vip].[MovimientoCaja] 
	ADD montoCierreSus decimal(8,2) not null default(0)
END
GO

IF EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MovimientoCaja' AND COLUMN_NAME = 'montoAdministracion')
BEGIN
	ALTER TABLE [vip].[MovimientoCaja] 
	DROP COLUMN montoAdministracion 
END
GO

IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MovimientoCaja' AND COLUMN_NAME = 'montoAdministracionBob')
BEGIN
	ALTER TABLE [vip].[MovimientoCaja] 
	ADD montoAdministracionBob decimal(8,2) not null default(0)
END
GO

IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MovimientoCaja' AND COLUMN_NAME = 'montoAdministracionSus')
BEGIN
	ALTER TABLE [vip].[MovimientoCaja] 
	ADD montoAdministracionSus decimal(8,2) not null default(0)
END
GO

IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MovimientoCaja' AND COLUMN_NAME = 'observacion')
BEGIN
	ALTER TABLE [vip].[MovimientoCaja] 
	ADD observacion varchar(500) null default('')
END
GO

IF NOT EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'ck_MovimientoCaja_MontoAperturaBob' AND xtype='C')
BEGIN
	ALTER TABLE [vip].[MovimientoCaja] ADD CONSTRAINT ck_MovimientoCaja_MontoAperturaBob CHECK (montoAperturaBob >= 0)
END
GO

IF NOT EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'ck_MovimientoCaja_MontoCierreBob' AND xtype='C')
BEGIN
	ALTER TABLE [vip].[MovimientoCaja] ADD CONSTRAINT ck_MovimientoCaja_MontoCierreBob CHECK (montoCierreBob >= 0)
END
GO

IF NOT EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'ck_MovimientoCaja_MontoAdministracionBob' AND xtype='C')
BEGIN
	ALTER TABLE [vip].[MovimientoCaja] ADD CONSTRAINT ck_MovimientoCaja_MontoAdministracionBob CHECK (montoAdministracionBob >= 0 AND montoAdministracionBob <= montoCierreBob)
END
GO

IF NOT EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'ck_MovimientoCaja_MontoAperturaSus' AND xtype='C')
BEGIN
	ALTER TABLE [vip].[MovimientoCaja] ADD CONSTRAINT ck_MovimientoCaja_MontoAperturaSus CHECK (montoAperturaSus >= 0)
END
GO

IF NOT EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'ck_MovimientoCaja_MontoCierreSus' AND xtype='C')
BEGIN
	ALTER TABLE [vip].[MovimientoCaja] ADD CONSTRAINT ck_MovimientoCaja_MontoCierreSus CHECK (montoCierreSus >= 0)
END
GO

IF NOT EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'ck_MovimientoCaja_MontoAdministracionSus' AND xtype='C')
BEGIN
	ALTER TABLE [vip].[MovimientoCaja] ADD CONSTRAINT ck_MovimientoCaja_MontoAdministracionSus CHECK (montoAdministracionSus >= 0 AND montoAdministracionSus <= montoCierreSus)
END
GO

IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'ClientePaquete' AND COLUMN_NAME = 'adicional')
	ALTER TABLE [vip].[ClientePaquete]
	ADD adicional int
GO

IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Horario' AND COLUMN_NAME = 'finDeSemana')
	ALTER TABLE [vip].[Horario]
	ADD finDeSemana bit not null
GO

IF EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Grupo' AND COLUMN_NAME = 'nombre')
	ALTER TABLE [vip].[Grupo]
	ALTER COLUMN nombre varchar(50) null
GO

IF EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Grupo')
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS  WHERE CONSTRAINT_NAME ='un_Grupo_Nombre')
	ALTER TABLE [vip].[Grupo]
	DROP CONSTRAINT un_Grupo_Nombre
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'GrupoDia' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[GrupoDia] DROP CONSTRAINT fk_GrupoDia_Grupo
	ALTER TABLE [vip].[GrupoDia] ADD CONSTRAINT fk_GrupoDia_Grupo FOREIGN KEY (grupoId) REFERENCES [VIP].[Grupo](id) ON DELETE CASCADE
END
GO

IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Promocion' AND COLUMN_NAME = 'nombre')
	ALTER TABLE [vip].[Promocion]
	ADD nombre varchar(100) not null
GO

IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Licencia' AND COLUMN_NAME = 'descripcion')
	ALTER TABLE [vip].[Licencia]
	ADD descripcion varchar(100) not null
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_Insertar]
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_Insertar]
	@id				int OUTPUT,
	@clienteId		int,
	@paqueteId			int,
	@fechaRegistro	datetime,
	@estado			bit,
	@usuarioId		uniqueidentifier,
	@fecha			datetime,
	@adicional		int
AS
BEGIN
		INSERT INTO [vip].[ClientePaquete](clienteId, paqueteId, fechaRegistro, estado, usuarioId, fecha, adicional) 
		VALUES (@clienteId, @paqueteId, @fechaRegistro, @estado, @usuarioId, @fecha, @adicional) 
		SET @Id = SCOPE_IDENTITY()
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_Actualizar]
END
GO

create PROCEDURE [vip].[ClientePaquete_Actualizar]
	@id				int,
	@clienteId		int,
	@paqueteId			int,
	@fechaRegistro	datetime,
	@estado			bit,
	@usuarioId		uniqueidentifier,
	@fecha			datetime
AS
BEGIN
		UPDATE [vip].[ClientePaquete]
		SET clienteId = @clienteId,
		paqueteId = @paqueteId,
		fechaRegistro = @fechaRegistro,
		estado = @estado,
		usuarioId = @usuarioId,
		fecha = @fecha
		WHERE Id = @Id
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_Eliminar]
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_Eliminar]
	@Id		int 
AS
BEGIN
    DELETE FROM [vip].[ClientePaquete]
	WHERE Id = @Id 
	
	DELETE FROM [vip].[ClientePaquete]
	WHERE adicional = @Id 	
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_TraerXId] 
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_TraerXId] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[ClientePaquete] p
		WHERE p.id = @id
		ORDER BY p.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_TraerXIdPrecioReal]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_TraerXIdPrecioReal] 
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_TraerXIdPrecioReal] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT isnull((((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = p.clienteId),100))*pa.precio)/(100)),0) Precio,
		isnull((((isnull((select d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = p.clienteId),100))*pa.precio)/(100)),0) PrecioEmpresa
		FROM [vip].[ClientePaquete] p,[vip].[Paquete] pa
		WHERE p.id = @id
		and pa.id = p.paqueteId
		ORDER BY p.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_TraerXCliente]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_TraerXCliente] 
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_TraerXCliente] 
	@clienteId	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[ClientePaquete] p
		WHERE p.clienteId = @clienteId
		and p.adicional = -1
		ORDER BY p.id desc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_TraerXClienteHabilitado]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_TraerXClienteHabilitado] 
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_TraerXClienteHabilitado] 
	@clienteId	int,
	@estado		bit
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[ClientePaquete] p
		WHERE p.clienteId = @clienteId
		and p.estado = @estado
		and p.adicional = -1
		ORDER BY p.id desc 
		RETURN
	END
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Grupo_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Grupo_Insertar]
END
GO

CREATE PROCEDURE [vip].[Grupo_Insertar]
	@id				int OUTPUT,
	@nombre			varchar(50),
	@horarioId		int,
	@servicioId		int,
	@estado			bit,
	@usuarioId		uniqueidentifier,
	@fecha			datetime
AS
BEGIN
		INSERT INTO [vip].[Grupo](nombre, horarioId, servicioId, estado, usuarioId, fecha) 
		VALUES (@nombre, @horarioId, @servicioId, @estado, @usuarioId, @fecha) 
		SET @Id = SCOPE_IDENTITY() 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Grupo_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Grupo_Actualizar]
END
GO

create PROCEDURE [vip].[Grupo_Actualizar]
	@id				int,
	@nombre			varchar(50),
	@horarioId		int,
	@servicioId		int,
	@estado			bit,
	@usuarioId		uniqueidentifier,
	@fecha			datetime
AS
BEGIN
		UPDATE [vip].[Grupo]
		SET nombre = @nombre,
		horarioId = @horarioId,
		servicioId = @servicioId,
		estado = @estado,
		usuarioId = @usuarioId,
		fecha = @fecha
		WHERE Id = @Id
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Grupo_ActualizarHorarioId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Grupo_ActualizarHorarioId]
END
GO

create PROCEDURE [vip].[Grupo_ActualizarHorarioId]
	@id				int,
	@horarioId		int
AS
BEGIN
		UPDATE [vip].[Grupo]
		SET 
		horarioId = @horarioId
		WHERE Id = @Id
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Grupo_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Grupo_Eliminar]
END
GO

CREATE PROCEDURE [vip].[Grupo_Eliminar]
	@Id					int 
AS
BEGIN
    DELETE FROM [vip].[Grupo]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Grupo_TraerTodos]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Grupo_TraerTodos] 
END
GO

CREATE PROCEDURE [vip].[Grupo_TraerTodos] 
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Grupo] p
		WHERE p.estado = 'true'
		ORDER BY p.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Grupo_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Grupo_TraerXId] 
END
GO

CREATE PROCEDURE [vip].[Grupo_TraerXId] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Grupo] p
		WHERE p.id = @id
		ORDER BY p.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Grupo_TraerServicioHorario]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Grupo_TraerServicioHorario] 
END
GO

CREATE PROCEDURE [vip].[Grupo_TraerServicioHorario] 
@grupoId	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT g.*, s.nombre nombreServicio, h.horaInicio+ ' - ' +h.horaFin hora
		FROM [vip].[Grupo] g, [vip].[Servicio] s, [vip].[Horario] h
		WHERE 
		g.id = @grupoId
		and g.servicioId = s.id
		and g.horarioId = h.id
		ORDER BY g.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Grupo_TraerServicioHorarioCliente]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Grupo_TraerServicioHorarioCliente] 
END
GO

CREATE PROCEDURE [vip].[Grupo_TraerServicioHorarioCliente] 
	@clientePaqueteId	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT g.nombre,g.servicioId, g.usuarioId, g.horarioId, g.fecha, g.estado, i.id,  s.nombre nombreServicio, h.horaInicio+ ' - ' +h.horaFin hora, h.finDeSemana, g.id GrupoId
		FROM [vip].[Grupo] g, [vip].[Servicio] s, [vip].[Horario] h, [vip].[Inscripcion] i, [vip].[ClientePaquete] cp
		WHERE g.id = i.grupoId
		and cp.id = i.clientePaqueteId
		and cp.id = @clientePaqueteId
		and g.servicioId = s.id
		and g.horarioId = h.id
		ORDER BY g.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Grupo_TraerXServicio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Grupo_TraerXServicio] 
END
GO

CREATE PROCEDURE [vip].[Grupo_TraerXServicio] 
	@servicioId	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Grupo] p
		WHERE p.servicioId = @servicioId
		ORDER BY p.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Grupo_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Grupo_TraerXCriterio] 
END
GO

CREATE PROCEDURE [vip].[Grupo_TraerXCriterio] 
	@nombre				varchar(100) = '',
	@servicioId			varchar(150) = '',
	@estado				varchar(10) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT g.*,(select h.horaInicio + '-' + h.horaFin  from [vip].[Horario] h where h.id = g.horarioId) horario, 
		(select h.finDeSemana  from [vip].[Horario] h where h.id = g.horarioId) finDeSemana, 
		(select s.nombre from [vip].[Servicio] s where s.id = g.servicioId ) nombreServicio,(select s.nombre from [vip].[Sala] s, [vip].[Horario] h where h.id = g.horarioId and s.id = h.salaId) sala
		FROM [vip].[Grupo] g
		WHERE
		g.nombre like '%' + @nombre + '%' 
		and g.servicioId like '%' + @servicioId + '%'
		and (select CAST(g.estado AS char(10))) like '%' + @estado + '%'
		ORDER BY Id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Servicio_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Servicio_Insertar]
END
GO

CREATE PROCEDURE [vip].[Servicio_Insertar]
	@id				int OUTPUT,
	@nombre			varchar(50),
	@restriccionHorario		bit,
	@cupo			int,
	@estado			bit,
	@usuarioId		uniqueidentifier,
	@fecha			datetime
AS
BEGIN
if(@cupo='0')
BEGIN
		INSERT INTO [vip].[Servicio](nombre, restriccionHorario, cupo, estado, usuarioId, fecha) 
		VALUES (@nombre, @restriccionHorario, null, @estado, @usuarioId, @fecha) 
		SET @Id = SCOPE_IDENTITY() 
END
ELSE
BEGIN
INSERT INTO [vip].[Servicio](nombre, restriccionHorario, cupo, estado, usuarioId, fecha) 
		VALUES (@nombre, @restriccionHorario, @cupo, @estado, @usuarioId, @fecha) 
		SET @Id = SCOPE_IDENTITY() 
END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Servicio_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Servicio_Actualizar]
END
GO

create PROCEDURE [vip].[Servicio_Actualizar]
	@id				int,
	@nombre			varchar(50),
	@restriccionHorario		bit,
	@cupo			int,
	@estado			bit,
	@usuarioId		uniqueidentifier,
	@fecha			datetime
AS
BEGIN

if(@cupo='0')
BEGIN
		UPDATE [vip].[Servicio]
		SET nombre = @nombre,
		restriccionHorario = @restriccionHorario,
		cupo = null,
		estado = @estado,
		usuarioId = @usuarioId,
		fecha = @fecha
		WHERE Id = @Id
END
ELSE
BEGIN
		UPDATE [vip].[Servicio]
		SET nombre = @nombre,
		restriccionHorario = @restriccionHorario,
		cupo = @cupo,
		estado = @estado,
		usuarioId = @usuarioId,
		fecha = @fecha
		WHERE Id = @Id
END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Servicio_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Servicio_Eliminar]
END
GO

CREATE PROCEDURE [vip].[Servicio_Eliminar]
	@Id					int 
AS
BEGIN
    DELETE FROM [vip].[Servicio]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Servicio_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Servicio_TraerXId] 
END
GO

CREATE PROCEDURE [vip].[Servicio_TraerXId] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Servicio] p
		WHERE p.id = @id
		ORDER BY p.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Servicio_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Servicio_TraerXCriterio] 
END
GO

CREATE PROCEDURE [vip].[Servicio_TraerXCriterio] 
	@nombre				varchar(100) = '',
	@restriccionHorario			varchar(10) = '',
	@estado				nvarchar(10) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		IF(@nombre = '*')
		BEGIN
		SELECT g.*
		FROM [vip].[Servicio] g
		WHERE

		(select CAST(g.restriccionHorario AS char(10)))  like '%' + @restriccionHorario + '%'
		and (select CAST(g.estado AS char(10))) like '%' + @estado + '%'
		ORDER BY g.nombre asc 
		RETURN
		END
		ELSE
		BEGIN
		SELECT g.*
		FROM [vip].[Servicio] g
		WHERE
		g.nombre like '%' + @nombre + '%' 
		and (select CAST(g.restriccionHorario AS char(10)))  like '%' + @restriccionHorario + '%'
		and (select CAST(g.estado AS char(10))) like '%' + @estado + '%'
		ORDER BY g.nombre asc 
		END
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Horario_TraerXCriterioValidando]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Horario_TraerXCriterioValidando] 
END
GO

CREATE PROCEDURE [vip].[Horario_TraerXCriterioValidando] 
	@salaId				varchar(10) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT h.*, h.horaInicio + '-' + h.horaFin Hora,(select s.nombre  from [vip].[Sala] s where s.id = h.salaId) nombreSala
		,(case(isnull((select count(*) from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 1 and gd.grupoId = g.id),'0'))
		when '0' then 'false' else 'true' end) Lunes,
		(isnull((select (select CAST(GD.id AS nvarchar(10))) +'='+(select CAST(GD.grupoId AS nvarchar(10)))  from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 1 and gd.grupoId = g.id),'0')) IdLunes,
		(select s.nombre from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 1 and g.servicioId = s.id and gd.grupoId = g.id) grupoLunes
		,(case(isnull((select count(*) from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 2 and gd.grupoId = g.id),'0'))
		when '0' then 'false' else 'true' end) Martes,
		(isnull((select (select CAST(GD.id AS nvarchar(10))) +'='+(select CAST(GD.grupoId AS nvarchar(10))) from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 2 and gd.grupoId = g.id),'0')) IdMartes,
		(select s.nombre from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 2 and g.servicioId = s.id and gd.grupoId = g.id) grupoMartes
		,(case(isnull((select count(*) from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 3 and gd.grupoId = g.id),'0'))
		when '0' then 'false' else 'true' end) Miercoles,
		(isnull((select (select CAST(GD.id AS nvarchar(10))) +'='+(select CAST(GD.grupoId AS nvarchar(10))) from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 3 and gd.grupoId = g.id),'0')) IdMiercoles,
		(select s.nombre from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 3 and g.servicioId = s.id and gd.grupoId = g.id) grupoMiercoles
		,(case(isnull((select count(*) from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 4 and gd.grupoId = g.id),'0'))
		when '0' then 'false' else 'true' end) Jueves,
		(isnull((select (select CAST(GD.id AS nvarchar(10))) +'='+(select CAST(GD.grupoId AS nvarchar(10))) from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 4 and gd.grupoId = g.id),'0')) IdJueves,
		(select s.nombre from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 4 and g.servicioId = s.id and gd.grupoId = g.id) grupoJueves
		,(case(isnull((select count(*) from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 5 and gd.grupoId = g.id),'0'))
		when '0' then 'false' else 'true' end) Viernes,
		(isnull((select (select CAST(GD.id AS nvarchar(10))) +'='+(select CAST(GD.grupoId AS nvarchar(10))) from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 5 and gd.grupoId = g.id),'0')) IdViernes,
		(select s.nombre from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 5 and g.servicioId = s.id and gd.grupoId = g.id) grupoViernes
		,(case(isnull((select count(*) from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 6 and gd.grupoId = g.id),'0'))
		when '0' then 'false' else 'true' end) Sabado,
		(isnull((select (select CAST(GD.id AS nvarchar(10))) +'='+(select CAST(GD.grupoId AS nvarchar(10))) from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 6 and gd.grupoId = g.id),'0')) IdSabado,
		(select s.nombre from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 6 and g.servicioId = s.id and gd.grupoId = g.id) grupoSabado
		,(case(isnull((select count(*) from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 7 and gd.grupoId = g.id),'0'))
		when '0' then 'false' else 'true' end) Domingo,
		(isnull((select (select CAST(GD.id AS nvarchar(10))) +'='+(select CAST(GD.grupoId AS nvarchar(10))) from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 7 and gd.grupoId = g.id),'0')) IdDomingo,
		(select s.nombre from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 7 and g.servicioId = s.id and gd.grupoId = g.id) grupoDomingo
		,h.finDeSemana
		FROM [vip].[Horario] h
		WHERE
		(select CAST(h.salaId AS char(10))) =  @salaId 
		ORDER BY h.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Horario_TraerXIdValidando]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Horario_TraerXIdValidando] 
END
GO

CREATE PROCEDURE [vip].[Horario_TraerXIdValidando] 
	@id				int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT h.*, h.horaInicio + '-' + h.horaFin Hora,(select s.nombre  from [vip].[Sala] s where s.id = h.salaId) nombreSala
		,(case(isnull((select count(*) from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 1 and gd.grupoId = g.id and g.id = gg.id),'0'))
		when '0' then 'false' else 'true' end) Lunes,
		(isnull((select gd.id from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 1 and gd.grupoId = g.id and g.id = gg.id),'0')) IdLunes,
		(select s.nombre from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 1 and g.servicioId = s.id and gd.grupoId = g.id and g.id = gg.id) grupoLunes
		,(case(isnull((select count(*) from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 2 and gd.grupoId = g.id and g.id = gg.id),'0'))
		when '0' then 'false' else 'true' end) Martes,
		(isnull((select gd.id from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 2 and gd.grupoId = g.id and g.id = gg.id),'0')) IdMartes,
		(select s.nombre from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 2 and g.servicioId = s.id and gd.grupoId = g.id and g.id = gg.id) grupoMartes
		,(case(isnull((select count(*) from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 3 and gd.grupoId = g.id and g.id = gg.id),'0'))
		when '0' then 'false' else 'true' end) Miercoles,
		(isnull((select gd.id from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 3 and gd.grupoId = g.id and g.id = gg.id),'0')) IdMiercoles,
		(select s.nombre from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 3 and g.servicioId = s.id and gd.grupoId = g.id and g.id = gg.id) grupoMiercoles
		,(case(isnull((select count(*) from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 4 and gd.grupoId = g.id and g.id = gg.id),'0'))
		when '0' then 'false' else 'true' end) Jueves,
		(isnull((select gd.id from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 4 and gd.grupoId = g.id and g.id = gg.id),'0')) IdJueves,
		(select s.nombre from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 4 and g.servicioId = s.id and gd.grupoId = g.id and g.id = gg.id) grupoJueves
		,(case(isnull((select count(*) from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 5 and gd.grupoId = g.id and g.id = gg.id),'0'))
		when '0' then 'false' else 'true' end) Viernes,
		(isnull((select gd.id from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 5 and gd.grupoId = g.id and g.id = gg.id),'0')) IdViernes,
		(select s.nombre from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 5 and g.servicioId = s.id and gd.grupoId = g.id and g.id = gg.id) grupoViernes
		,(case(isnull((select count(*) from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 6 and gd.grupoId = g.id and g.id = gg.id),'0'))
		when '0' then 'false' else 'true' end) Sabado,
		(isnull((select gd.id from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 6 and gd.grupoId = g.id and g.id = gg.id),'0')) IdSabado,
		(select s.nombre from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 6 and g.servicioId = s.id and gd.grupoId = g.id and g.id = gg.id) grupoSabado
		,(case(isnull((select count(*) from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 7 and gd.grupoId = g.id and g.id = gg.id),'0'))
		when '0' then 'false' else 'true' end) Domingo,
		(isnull((select gd.id from [vip].[GrupoDia] gd, [vip].[Grupo] g  where g.horarioId = h.id and  gd.diaId = 2 and gd.grupoId = g.id and g.id = gg.id),'0')) IdDomingo,
		(select s.nombre from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 7 and g.servicioId = s.id and gd.grupoId = g.id and g.id = gg.id) grupoDomingo
		,h.finDeSemana
		FROM [vip].[Horario] h, [vip].[Grupo] gg
		WHERE
		gg.horarioId = h.id
		and gg.id = @id
		ORDER BY h.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[GrupoDia_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[GrupoDia_Insertar]
END
GO

CREATE PROCEDURE [vip].[GrupoDia_Insertar]
	@id				int OUTPUT,
	@grupoId		int,
	@diaId			int
AS
BEGIN
		INSERT INTO [vip].[GrupoDia](grupoId, diaId) 
		VALUES (@grupoId, @diaId) 
		SET @Id = SCOPE_IDENTITY() 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[GrupoDia_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[GrupoDia_Actualizar]
END
GO

create PROCEDURE [vip].[GrupoDia_Actualizar]
	@id				int,
	@grupoId		int,
	@diaId			int
AS
BEGIN
		UPDATE [vip].[GrupoDia]
		SET grupoId = @grupoId,
		diaId = @diaId
		WHERE Id = @Id
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[GrupoDia_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[GrupoDia_Eliminar]
END
GO

CREATE PROCEDURE [vip].[GrupoDia_Eliminar]
	@Id					int 
AS
BEGIN
    DELETE FROM [vip].[GrupoDia]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[GrupoDia_EliminarXGrupoIdDiaId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[GrupoDia_EliminarXGrupoIdDiaId]
END
GO

CREATE PROCEDURE [vip].[GrupoDia_EliminarXGrupoIdDiaId]
	@grupoId		int,
	@diaId			int
AS
BEGIN
    DELETE FROM [vip].[GrupoDia]
	WHERE grupoId = @grupoId 
	and diaId = @diaId
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[GrupoDia_EliminarGrupoId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[GrupoDia_EliminarGrupoId]
END
GO

CREATE PROCEDURE [vip].[GrupoDia_EliminarGrupoId]
	@Id			int
AS
BEGIN
    DELETE FROM [vip].[GrupoDia]
	WHERE grupoId = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[GrupoDia_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[GrupoDia_TraerXId] 
END
GO

CREATE PROCEDURE [vip].[GrupoDia_TraerXId] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[GrupoDia] p
		WHERE p.id = @id
		ORDER BY p.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[GrupoDia_TraerXGrupoId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[GrupoDia_TraerXGrupoId] 
END
GO

CREATE PROCEDURE [vip].[GrupoDia_TraerXGrupoId] 
	@grupoId			int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[GrupoDia] p
		WHERE p.grupoId = @grupoId
		ORDER BY p.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[GrupoDia_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[GrupoDia_TraerXCriterio] 
END
GO

CREATE PROCEDURE [vip].[GrupoDia_TraerXCriterio] 
	@id				varchar(100) = '',
	@grupoId			varchar(150) = '',
	@diaId				varchar(10) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT g.*
		FROM [vip].[GrupoDia] g
		WHERE
		(select CAST(g.id AS char(10))) like '%' + @id + '%'
		and (select CAST(g.grupoId AS char(10))) like '%' + @grupoId + '%'
		and (select CAST(g.diaId AS char(10))) like '%' + @diaId + '%'
		
		ORDER BY g.Id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[GrupoDia_TraerXGrupoIdDiaId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[GrupoDia_TraerXGrupoIdDiaId] 
END
GO

CREATE PROCEDURE [vip].[GrupoDia_TraerXGrupoIdDiaId] 
	@grupoId			int,
	@diaId				int,
	@horarioId				int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT     vip.GrupoDia.*
		FROM         vip.Grupo INNER JOIN
                      vip.GrupoDia ON vip.Grupo.id = vip.GrupoDia.grupoId INNER JOIN
                      vip.Servicio ON vip.Grupo.servicioId = vip.Servicio.id
		WHERE     (vip.Grupo.id = @grupoId) AND (vip.GrupoDia.diaId = @diaId) AND (vip.Grupo.horarioId = @horarioId)
		
		ORDER BY vip.GrupoDia.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_TiempoPaquete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_TiempoPaquete] 
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_TiempoPaquete] 
	@clienteId			int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		
		if((SELECT top 1 isnull(P.diasValidez,0) valor
		from [vip].[ClientePaquete] c, [vip].[Paquete] p
		WHERE c.id = @clienteId
		and c.paqueteId = p.id
		and c.estado = 'true'
		order by c.id desc)=0)
		begin 
			SELECT 
			(case(p.unidadId) when '1 ' then (select dateadd(day,-1,(select dateadd(month,p.tiempo,c.fechaRegistro))))  else (cast(c.fechaRegistro as datetime) +(case(p.unidadId)
			when '2' then p.tiempo * 7 when '3' then p.tiempo end)) end) tiempo 
			from [vip].[ClientePaquete] c, [vip].[Paquete] p
			WHERE c.id = @clienteId
			and c.paqueteId = p.id
			and c.estado = 'true'
			order by c.id desc
		end
		else
		begin
			SELECT (cast(c.fechaRegistro as  datetime)+ p.diasValidez) tiempo
			from [vip].[ClientePaquete] c, [vip].[Paquete] p
			WHERE c.id = @clienteId
			and c.paqueteId = p.id
			and c.estado = 'true'
			order by c.id desc
		end
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_TraerHistorial]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_TraerHistorial] 
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_TraerHistorial] 
	@clienteId			int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT c.id, p.nombre, c.fechaRegistro, c.estado, p.precio, isnull((select top 1 cc.id  from [vip].[ClientePaquete] cc where cc.adicional = c.id),'-1') adicional,
		(case(p.unidadId) when '1 ' then (select dateadd(day,-1,(select dateadd(month,p.tiempo,c.fechaRegistro))))  else (cast(c.fechaRegistro as datetime) +(case(p.unidadId)
			when '2' then p.tiempo * 7 when '3' then p.tiempo end)) end) fechaFin
		
		from [vip].[ClientePaquete] c, [vip].[Paquete] p
		WHERE c.clienteId = @clienteId
		and c.paqueteId = p.id
		and c.adicional = -1
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_TraerHistorialAdicional]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_TraerHistorialAdicional] 
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_TraerHistorialAdicional] 
	@clienteId			int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT c.id, p.nombre, c.fechaRegistro, c.estado, p.precio, c.adicional
		from [vip].[ClientePaquete] c, [vip].[Paquete] p
		WHERE c.adicional = @clienteId
		and c.paqueteId = p.id
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_TieneAdicional]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_TieneAdicional] 
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_TieneAdicional] 
	@id			int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		from [vip].[ClientePaquete] c
		WHERE c.id = @id
		AND c.id in (select cc.adicional from [vip].[ClientePaquete] cc)
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_TieneAdicionalPadre]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_TieneAdicionalPadre] 
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_TieneAdicionalPadre] 
	@id			int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT c.id
		from [vip].[ClientePaquete] c
		WHERE c.id = @id
		AND c.adicional <> -1
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Horario_TraerReporte]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Horario_TraerReporte] 
END
GO

CREATE PROCEDURE [vip].[Horario_TraerReporte] 
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT s.nombre, h.horaInicio + '-' + h.horaFin Hora
		,isnull((select s.nombre from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 1 and g.servicioId = s.id and gd.grupoId = g.id),'-') grupoLunes
		,isnull((select s.nombre from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 2 and g.servicioId = s.id and gd.grupoId = g.id),'-') grupoMartes
		,isnull((select s.nombre from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 3 and g.servicioId = s.id and gd.grupoId = g.id),'-') grupoMiercoles
		,isnull((select s.nombre from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 4 and g.servicioId = s.id and gd.grupoId = g.id),'-') grupoJueves
		,isnull((select s.nombre from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 5 and g.servicioId = s.id and gd.grupoId = g.id),'-') grupoViernes
		,isnull((select s.nombre from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 6 and g.servicioId = s.id and gd.grupoId = g.id),'-') grupoSabado
		,isnull((select s.nombre from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 7 and g.servicioId = s.id and gd.grupoId = g.id),'-') grupoDomingo
		FROM [vip].[Horario] h, [vip].[Sala] s
		WHERE
		h.salaId = s.id
		ORDER BY h.id, s.nombre asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Grupo_TraerHorario]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Grupo_TraerHorario] 
END
GO

CREATE PROCEDURE [vip].[Grupo_TraerHorario] 
	@grupoId	int,
	@clientePaqueteId	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT g.id, ss.nombre nombreSala, h.horaInicio + '-' + h.horaFin Hora, se.nombre nombreServicio
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 1 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoLunes
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 2 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoMartes
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 3 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoMiercoles
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 4 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoJueves
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 5 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoViernes
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 6 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoSabado
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 7 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoDomingo
		, se.cupo - (select count(*) from [vip].[Inscripcion] i where i.grupoId = g.id and i.estado = 'true') cupo
		FROM [vip].[Horario] h, [vip].[Sala] ss, [vip].[Grupo] g, [vip].[Servicio] se
		WHERE se.id = @grupoId
		and g.servicioId = se.id
		and g.horarioId = h.id
		and h.salaId = ss.id
		and h.id not in (select hh.id 
		from [vip].[Horario] hh, [vip].[Grupo] gg, [vip].[Inscripcion] i
		where hh.id = gg.horarioId
		and i.grupoId = gg.id
		and i.clientePaqueteId = @clientePaqueteId
		)
		ORDER BY h.id, ss.nombre asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Grupo_TraerHorarioIn]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Grupo_TraerHorarioIn] 
END
GO

CREATE PROCEDURE [vip].[Grupo_TraerHorarioIn] 
	@grupoId	int,
	@clientePaqueteId	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT g.id, ss.nombre nombreSala, h.horaInicio + '-' + h.horaFin Hora, se.nombre nombreServicio
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 1 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoLunes
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 2 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoMartes
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 3 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoMiercoles
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 4 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoJueves
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 5 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoViernes
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 6 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoSabado
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 7 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoDomingo
		, se.cupo - (select count(*) from [vip].[Inscripcion] i where i.grupoId = g.id and i.estado = 'true') cupo
		FROM [vip].[Horario] h, [vip].[Sala] ss, [vip].[Grupo] g, [vip].[Servicio] se
		WHERE se.id = @grupoId
		and g.servicioId = se.id
		and g.horarioId = h.id
		and h.salaId = ss.id
		ORDER BY h.id, ss.nombre asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Inscripcion_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Inscripcion_Insertar]
END
GO

CREATE PROCEDURE [vip].[Inscripcion_Insertar]
	@id				int OUTPUT,
	@clientePaqueteId	int,
	@grupoId		int,
	@estado			bit,
	@usuarioId		uniqueidentifier,
	@fecha			datetime
AS
BEGIN
		INSERT INTO [vip].[Inscripcion](clientePaqueteId, grupoId, estado, usuarioId, fecha) 
		VALUES (@clientePaqueteId, @grupoId, @estado, @usuarioId, @fecha) 
		SET @Id = SCOPE_IDENTITY() 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Inscripcion_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Inscripcion_Actualizar]
END
GO

create PROCEDURE [vip].[Inscripcion_Actualizar]
	@id				int,
	@clientePaqueteId	int,
	@grupoId		int,
	@estado			bit,
	@usuarioId		uniqueidentifier,
	@fecha			datetime
AS
BEGIN
		UPDATE [vip].[Inscripcion]
		SET clientePaqueteId = @clientePaqueteId,
		grupoId = @grupoId,
		estado = @estado,
		usuarioId = @usuarioId,
		fecha = @fecha
		WHERE Id = @Id
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Inscripcion_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Inscripcion_Eliminar]
END
GO

CREATE PROCEDURE [vip].[Inscripcion_Eliminar]
	@Id					int 
AS
BEGIN
    DELETE FROM [vip].[Inscripcion]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Inscripcion_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Inscripcion_TraerXId] 
END
GO

CREATE PROCEDURE [vip].[Inscripcion_TraerXId] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Inscripcion] p
		WHERE p.id = @id
		ORDER BY p.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Inscripcion_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Inscripcion_TraerXCriterio] 
END
GO

CREATE PROCEDURE [vip].[Inscripcion_TraerXCriterio] 
	@clientePaqueteId	varchar(100) = '',
	@grupoId			varchar(150) = '',
	@estado				varchar(10) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Inscripcion] g
		WHERE
		g.clientePaqueteId like '%' + @clientePaqueteId + '%' 
		and g.grupoId like '%' + @grupoId + '%'
		and (select CAST(g.estado AS char(10))) like '%' + @estado + '%'
		ORDER BY Id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Inscripcion_TraerXClientePaqueteId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Inscripcion_TraerXClientePaqueteId] 
END
GO

CREATE PROCEDURE [vip].[Inscripcion_TraerXClientePaqueteId] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Inscripcion] p
		WHERE p.clientePaqueteId = @id
		ORDER BY p.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Inscripcion_TraerXGrupoId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Inscripcion_TraerXGrupoId] 
END
GO

CREATE PROCEDURE [vip].[Inscripcion_TraerXGrupoId] 
	@grupoId	int,
	@clientepaqueteId int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Inscripcion] p
		WHERE p.grupoId = @grupoId
		and p.clientePaqueteId = @clientepaqueteId
		ORDER BY p.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Inscripcion_TraerXSoloGrupoId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Inscripcion_TraerXSoloGrupoId] 
END
GO

CREATE PROCEDURE [vip].[Inscripcion_TraerXSoloGrupoId] 
	@grupoId	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Inscripcion] p
		WHERE p.grupoId = @grupoId
		ORDER BY p.id asc 
		RETURN
	END
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Caja_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Caja_Insertar]
END
GO

CREATE PROCEDURE [vip].[Caja_Insertar]
	@id				int OUTPUT,
	@numero			int,
	@cajeroId		varchar(100),
	@fechaCreacion	datetime,
	@estado	bit
AS
BEGIN

	INSERT INTO [vip].[Caja](numero, cajeroId, fechaCreacion,estado) 
	VALUES (@numero, @cajeroId, @fechaCreacion,@estado) 
	SET @Id = SCOPE_IDENTITY() 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Caja_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Caja_Actualizar]
END
GO

CREATE PROCEDURE [vip].[Caja_Actualizar]
	@id				int,
	@numero			int,
	@cajeroId		varchar(100),
	@fechaCreacion	datetime,
	@estado	bit
AS
BEGIN

	UPDATE [vip].[Caja]
	SET numero = @numero,
	cajeroId = @cajeroId,
	--fechaCreacion = @fechaCreacion,
	estado = @estado
	WHERE Id = @id	
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Caja_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Caja_Eliminar]
END
GO

CREATE PROCEDURE [vip].[Caja_Eliminar]
	@Id					int 
AS
BEGIN
    DELETE FROM [vip].[Caja]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Caja_Cerrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Caja_Cerrar]
END
GO

CREATE PROCEDURE [vip].[Caja_Cerrar]
	@id				int,
	@estado	bit
AS
BEGIN

	UPDATE [vip].[Caja]
	SET 
	estado = @estado
	WHERE Id = @id
	
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Caja' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[Caja]
	ALTER COLUMN fechaCreacion DateTime
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Caja_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Caja_TraerXId] 
END
GO

CREATE PROCEDURE [vip].[Caja_TraerXId] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Caja]
		WHERE id = @id
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Caja_EstaAbierto]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Caja_EstaAbierto] 
END
GO

CREATE PROCEDURE [vip].[Caja_EstaAbierto] 
	@cajeroId	varchar(100)
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Caja]
		WHERE cajeroId = @cajeroId
		and estado = 'true'
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Caja_EstaAsignada]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Caja_EstaAsignada] 
END
GO

CREATE PROCEDURE [vip].[Caja_EstaAsignada] 
	@cajeroId	varchar(100)
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Caja]
		WHERE cajeroId = @cajeroId
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Caja_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Caja_TraerXCriterio] 
END
GO

CREATE PROCEDURE [vip].[Caja_TraerXCriterio] 
	@numero				varchar(100) = '',
	@cajeroId	varchar(100) = '',
	@estado				varchar(10) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
	if(@estado='')
	BEGIN
		SELECT *
		FROM [vip].[Caja]
		WHERE
		numero like '%' + @numero + '%' 
		and (select CAST(isnull(cajeroId,'') AS char(100))) like '%' + @cajeroId + '%'
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		ORDER BY Id asc 
		RETURN
	END
	IF(@estado = 'True')
	BEGIN
		SELECT *
		FROM [vip].[Caja]
		WHERE
		numero like '%' + @numero + '%' 
		and (select CAST(isnull(cajeroId,'') AS char(100))) like '%' + @cajeroId + '%'
		and estado = 'true'

		ORDER BY Id asc 
	END
	IF(@estado = 'False')
	BEGIN
		SELECT *
		FROM [vip].[Caja]
		WHERE
		numero like '%' + @numero + '%' 
		and (select CAST(isnull(cajeroId,'') AS char(100))) like '%' + @cajeroId + '%'
		and estado = 'false'

		ORDER BY Id asc 
	END
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[MovimientoCaja_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[MovimientoCaja_Insertar]
END
GO

CREATE PROCEDURE [vip].[MovimientoCaja_Insertar]
	@id					int OUTPUT,
	@cajaId				int,
	@fechaHoraApertura	datetime,
	@montoAperturaBob	decimal(8,2),
	@montoAperturaSus	decimal(8,2),
	@tipoCambio			decimal(8,2),
	@usuarioId			varchar(100),
	@fecha				datetime,
	@estado				bit
AS
BEGIN

	INSERT INTO [vip].[MovimientoCaja](cajaId, fechaHoraApertura, 
	montoAperturaBob, montoAperturaSus, tipoCambio, usuarioId, fecha, estado) 
	VALUES (@cajaId, @fechaHoraApertura, @montoAperturaBob, 
	@montoAperturaSus, @tipoCambio, @usuarioId, @fecha, @estado) 
	SET @Id = SCOPE_IDENTITY() 

END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[MovimientoCaja_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[MovimientoCaja_Actualizar]
END
GO

CREATE PROCEDURE [vip].[MovimientoCaja_Actualizar]
	@id				int,
	@cajaId				int,
	@fechaHoraCierre	datetime,
	@montoCierreBob		decimal(8,2),
	@montoCierreSus		decimal(8,2),
	@montoAdministracionBob  decimal(8,2),
	@montoAdministracionSus  decimal(8,2),
	@observacion		varchar(500),
	@usuarioId			varchar(100),
	@fecha				datetime,
	@estado				bit
AS
BEGIN

	UPDATE [vip].[MovimientoCaja]
	SET cajaId = @cajaId,
	fechaHoraCierre = @fechaHoraCierre,
	montoCierreBob = @montoCierreBob,
	montoCierreSus = @montoCierreSus,
	montoAdministracionBob = @montoAdministracionBob,
	montoAdministracionSus = @montoAdministracionSus,
	observacion = @observacion, 
	usuarioId = @usuarioId,
	fecha = @fecha,
	estado = @estado
	WHERE Id = @id	
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[MovimientoCaja_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[MovimientoCaja_Eliminar]
END
GO

CREATE PROCEDURE [vip].[MovimientoCaja_Eliminar]
	@Id					int 
AS
BEGIN
    DELETE FROM [vip].[MovimientoCaja]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[MovimientoCaja_Cerrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[MovimientoCaja_Cerrar]
END
GO

CREATE PROCEDURE [vip].[MovimientoCaja_Cerrar]
	@id				int,
	@estado	bit
AS
BEGIN
	UPDATE [vip].[MovimientoCaja]
	SET 
	estado = @estado
	WHERE Id = @id	
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[MovimientoCaja_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[MovimientoCaja_TraerXId] 
END
GO

CREATE PROCEDURE [vip].[MovimientoCaja_TraerXId] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[MovimientoCaja]
		WHERE id = @id
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[MovimientoCaja_EstaAbierto]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[MovimientoCaja_EstaAbierto] 
END
GO

CREATE PROCEDURE [vip].[MovimientoCaja_EstaAbierto] 
	@cajaId	varchar(100)
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[MovimientoCaja]
		WHERE cajaId = @cajaId
		and estado = 'true'
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[MovimientoCaja_UltimoCierre]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[MovimientoCaja_UltimoCierre] 
END
GO

CREATE PROCEDURE [vip].[MovimientoCaja_UltimoCierre] 
	@cajaId	varchar(100)
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT top 1 m.*
		FROM [vip].[MovimientoCaja] m
		WHERE m.cajaId = @cajaId
		ORDER BY m.fechaHoraCierre desc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[MovimientoCaja_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[MovimientoCaja_TraerXCriterio] 
END
GO

CREATE PROCEDURE [vip].[MovimientoCaja_TraerXCriterio] 
	@usuarioId				varchar(100) = '',
	@cajaId	varchar(100) = '',
	@estado				varchar(10) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
	if(@estado='')
	BEGIN
		SELECT *
		FROM [vip].[MovimientoCaja]
		WHERE
		usuarioId like '%' + @usuarioId + '%' 
		and (select CAST(isnull(cajaId,'') AS char(100))) like '%' + @cajaId + '%'
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		ORDER BY Id asc 
		RETURN
	END
	IF(@estado = 'True')
	BEGIN
		SELECT *
		FROM [vip].[MovimientoCaja]
		WHERE
		usuarioId like '%' + @usuarioId + '%' 
		and (select CAST(isnull(cajaId,'') AS char(100))) like '%' + @cajaId + '%'
		and estado = 'true'

		ORDER BY Id asc 
	END
	IF(@estado = 'False')
	BEGIN
		SELECT *
		FROM [vip].[MovimientoCaja]
		WHERE
		usuarioId like '%' + @usuarioId + '%' 
		and (select CAST(isnull(cajaId,'') AS char(100))) like '%' + @cajaId + '%'
		and estado = 'false' 
		ORDER BY Id asc 
	END
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Unidad_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Unidad_TraerXId] 
END
GO

CREATE PROCEDURE [vip].[Unidad_TraerXId] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Unidad]
		WHERE id = @id
		ORDER BY id asc 
		RETURN
	END
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Paquete_TraerAdicional]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Paquete_TraerAdicional] 
END
GO

CREATE PROCEDURE [vip].[Paquete_TraerAdicional] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT p.id, p.nombre
		FROM [vip].[Paquete] p, [vip].[ClientePaquete] cp
		WHERE p.id = cp.paqueteId
		and cp.id = @id
		union
		SELECT p.id, p.nombre
		FROM [vip].[Paquete] p, [vip].[ClientePaquete] cp
		WHERE p.id = cp.paqueteId
		and cp.adicional = @id
		ORDER BY p.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Paquete_TraerAdicionalPadre]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Paquete_TraerAdicionalPadre] 
END
GO

CREATE PROCEDURE [vip].[Paquete_TraerAdicionalPadre] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT cp.id, p.nombre
		FROM [vip].[Paquete] p, [vip].[ClientePaquete] cp
		WHERE p.id = cp.paqueteId
		and cp.id = @id
		union
		SELECT cp.id, p.nombre
		FROM [vip].[Paquete] p, [vip].[ClientePaquete] cp
		WHERE p.id = cp.paqueteId
		and cp.adicional = @id
		ORDER BY cp.id desc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Promocion_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Promocion_Insertar]
END
GO

CREATE PROCEDURE [vip].[Promocion_Insertar]
	@id				int OUTPUT,
	@fechaInicio	datetime,
	@fechaFin	datetime,
	@montoDescuento	decimal(8, 2),
	@usuarioId	uniqueidentifier,
	@fecha		datetime,
	@estado	bit,
	@nombre		varchar(100)
AS
BEGIN

	INSERT INTO [vip].[Promocion](fechaInicio, fechaFin,montoDescuento,usuarioId,fecha,estado,nombre) 
	VALUES (@fechaInicio, @fechaFin, @montoDescuento,@usuarioId, @fecha,@estado,@nombre) 
	SET @Id = SCOPE_IDENTITY() 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Promocion_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Promocion_Actualizar]
END
GO

CREATE PROCEDURE [vip].[Promocion_Actualizar]
	@id				int,
	@fechaInicio	datetime,
	@fechaFin	datetime,
	@montoDescuento	decimal(8, 2),
	@usuarioId	uniqueidentifier,
	@fecha		datetime,
	@estado	bit,
	@nombre		varchar(100)
AS
BEGIN
	UPDATE [vip].[Promocion]
	SET fechaInicio = @fechaInicio,
	fechaFin = @fechaFin,
	montoDescuento = @montoDescuento,
	usuarioId = @usuarioId,
	fecha = @fecha,
	estado = @estado,
	nombre = @nombre
	WHERE Id = @id	
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Promocion_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Promocion_Eliminar]
END
GO

CREATE PROCEDURE [vip].[Promocion_Eliminar]
	@Id					int 
AS
BEGIN
    DELETE FROM [vip].[Promocion]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Promocion_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Promocion_TraerXCriterio] 
END
GO

CREATE PROCEDURE [vip].[Promocion_TraerXCriterio] 
	@fechaInicio				varchar(10) = '',
	@fechaFin					varchar(100) = '',
	@estado						varchar(10) = '',
	@nombre						varchar(100) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
	if(@fechaInicio='' and @fechaFin='')
	BEGIN
	if(@estado='')
	BEGIN
		SELECT *
		FROM [vip].[Promocion]
		WHERE
		nombre like '%' + @nombre + '%' 
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		ORDER BY Id asc 
		RETURN
	END
	IF(@estado = 'True')
	BEGIN
		SELECT *
		FROM [vip].[Promocion]
		WHERE
		nombre like '%' + @nombre + '%' 
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		and estado = 'true'

		ORDER BY Id asc 
	END
	IF(@estado = 'False')
	BEGIN
		SELECT *
		FROM [vip].[Promocion]
		WHERE
		nombre like '%' + @nombre + '%' 
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		and estado = 'false'

		ORDER BY Id asc 
	END
	END
	ELSE
	
	BEGIN
	if(@estado='')
	BEGIN
		SELECT *
		FROM [vip].[Promocion]
		WHERE
		fechaInicio BETWEEn @fechaInicio and @fechaFin 
		or fechaFin BETWEEn @fechaInicio and @fechaFin 
		and nombre like '%' + @nombre + '%' 
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		ORDER BY Id asc 
		RETURN
	END
	IF(@estado = 'True')
	BEGIN
		SELECT *
		FROM [vip].[Promocion]
		WHERE
		fechaInicio BETWEEn @fechaInicio and @fechaFin 
		or fechaFin BETWEEn @fechaInicio and @fechaFin 
		and nombre like '%' + @nombre + '%' 
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		and estado = 'true'

		ORDER BY Id asc 
	END
	IF(@estado = 'False')
	BEGIN
		SELECT *
		FROM [vip].[Promocion]
		WHERE
		fechaInicio BETWEEn @fechaInicio and @fechaFin 
		or fechaFin BETWEEn @fechaInicio and @fechaFin 
		and nombre like '%' + @nombre + '%' 
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		and estado = 'false'

		ORDER BY Id asc 
	END
	END
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Promocion_TraerHabilita]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Promocion_TraerHabilita] 
END
GO

CREATE PROCEDURE [vip].[Promocion_TraerHabilita] 
AS
BEGIN	
	SET NOCOUNT ON;
	select p.* 
	from [vip].[Promocion] p
	where GETDATE() between p.fechaInicio and p.fechaFin
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Promocion_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Promocion_TraerXId]
END
GO

CREATE PROCEDURE [vip].[Promocion_TraerXId]
	@Id					int 
AS
BEGIN
    SELECT * FROM [vip].[Promocion]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Licencia_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Licencia_Insertar]
END
GO

CREATE PROCEDURE [vip].[Licencia_Insertar]
	@id				int OUTPUT,
	@descripcion	varchar(100),
	@clientePaqueteId	int,
	@fechaSolicitud	datetime,
	@fechaInicioLicencia	datetime,
	@usuarioId	uniqueidentifier,
	@fecha		datetime,
	@estado	bit,
	@fechaFinLicencia	datetime
AS
BEGIN
	INSERT INTO [vip].[Licencia](descripcion,clientePaqueteId,fechaSolicitud,fechaInicioLicencia,fechaFinLicencia,usuarioId,fecha,estado) 
	VALUES (@descripcion,@clientePaqueteId,@fechaSolicitud, @fechaInicioLicencia, @fechaFinLicencia,@usuarioId, @fecha,@estado) 
	SET @Id = SCOPE_IDENTITY() 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Licencia_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Licencia_Actualizar]
END
GO

CREATE PROCEDURE [vip].[Licencia_Actualizar]
	@id				int,
	@descripcion	varchar(100),
	@clientePaqueteId	int,
	@fechaSolicitud	datetime,
	@fechaInicioLicencia	datetime,
	@usuarioId	uniqueidentifier,
	@fecha		datetime,
	@estado	bit,
	@fechaFinLicencia	datetime
AS
BEGIN

	UPDATE [vip].[Licencia]
	SET 
	descripcion = @descripcion,
	clientePaqueteId = @clientePaqueteId,
	fechaSolicitud = @fechaSolicitud,
	fechaInicioLicencia = @fechaInicioLicencia,
	usuarioId = @usuarioId,
	fecha = @fecha,
	estado = @estado,
	fechaFinLicencia = @fechaFinLicencia
	WHERE Id = @id	
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Licencia_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Licencia_Eliminar]
END
GO

CREATE PROCEDURE [vip].[Licencia_Eliminar]
	@Id					int 
AS
BEGIN
    DELETE FROM [vip].[Licencia]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Licencia_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Licencia_TraerXCriterio] 
END
GO

CREATE PROCEDURE [vip].[Licencia_TraerXCriterio] 
	@descripcion				varchar(100)='',
	@clientePaqueteId			int,
	@fechaInicioLicencia		varchar(10) = '',
	@estado						varchar(10) = '',
	@fechaFinLicencia			varchar(10) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	IF(@clientePaqueteId = 0)
	BEGIN
	if(@fechaInicioLicencia='' and @fechaFinLicencia='')
	BEGIN
		SELECT *, (select c.nombre +' '+ c.apellidos from [vip].[ClientePaquete] cp, [vip].[Cliente] c where c.id = cp.clienteId and cp.id = clientePaqueteId) NombreCliente
		,(SELECT DATEADD(DAY, 1, fechaFinLicencia)) fechaReincorporacion
		,(DATEDIFF(DAY,fechaInicioLicencia,fechaFinLicencia))+1 CantidadDias
		FROM [vip].[Licencia]
		WHERE
		descripcion like '%' +  @descripcion + '%'
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		ORDER BY Id asc 
		RETURN
	END
	ELSE
	
	BEGIN
		SELECT *, (select c.nombre +' '+ c.apellidos from [vip].[ClientePaquete] cp, [vip].[Cliente] c where c.id = cp.clienteId and cp.id = clientePaqueteId) NombreCliente
		,(SELECT DATEADD(DAY, 1, fechaFinLicencia)) fechaReincorporacion
		,(DATEDIFF(DAY,fechaInicioLicencia,fechaFinLicencia))+1 CantidadDias
		FROM [vip].[Licencia]
		WHERE
		fechaInicioLicencia BETWEEn @fechaInicioLicencia and @fechaFinLicencia 
		or fechaFinLicencia BETWEEn @fechaInicioLicencia and @fechaFinLicencia 
		and descripcion like '%' +  @descripcion + '%'
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		ORDER BY Id asc 
		RETURN
	END
	END
	ELSE
	BEGIN
	if(@fechaInicioLicencia='' and @fechaFinLicencia='')
	BEGIN
		SELECT *, (select c.nombre +' '+ c.apellidos from [vip].[ClientePaquete] cp, [vip].[Cliente] c where c.id = cp.clienteId and cp.id = clientePaqueteId) NombreCliente
		,(SELECT DATEADD(DAY, 1, fechaFinLicencia)) fechaReincorporacion
		,(DATEDIFF(DAY,fechaInicioLicencia,fechaFinLicencia))+1 CantidadDias
		FROM [vip].[Licencia]
		WHERE
		clientePaqueteId = @clientePaqueteId
		and descripcion like '%' +  @descripcion + '%'
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		ORDER BY Id asc 
		RETURN
	END
	ELSE
	
	BEGIN
		SELECT *, (select c.nombre +' '+ c.apellidos from [vip].[ClientePaquete] cp, [vip].[Cliente] c where c.id = cp.clienteId and cp.id = clientePaqueteId) NombreCliente
		,(SELECT DATEADD(DAY, 1, fechaFinLicencia)) fechaReincorporacion
		,(DATEDIFF(DAY,fechaInicioLicencia,fechaFinLicencia))+1 CantidadDias
		FROM [vip].[Licencia]
		WHERE
		fechaInicioLicencia BETWEEn @fechaInicioLicencia and @fechaFinLicencia 
		or fechaFinLicencia BETWEEn @fechaInicioLicencia and @fechaFinLicencia 
		and clientePaqueteId = @clientePaqueteId 
		and descripcion like '%' +  @descripcion + '%'
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		ORDER BY Id asc 
		RETURN
	END
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Licencia_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Licencia_TraerXId]
END
GO

CREATE PROCEDURE [vip].[Licencia_TraerXId]
	@Id					int 
AS
BEGIN
    SELECT * FROM [vip].[Licencia]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Licencia_TraerXClientePaqueteId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Licencia_TraerXClientePaqueteId]
END
GO

CREATE PROCEDURE [vip].[Licencia_TraerXClientePaqueteId]
	@Id					int 
AS
BEGIN
    SELECT l.id, l.clientePaqueteId, l.descripcion, l.estado, l.fecha, (SELECT CONVERT(VARCHAR(10), l.fechaFinLicencia,103)) fechaFinLicencia, (SELECT CONVERT(VARCHAR(10), l.fechaInicioLicencia,103)) fechaInicioLicencia, (SELECT CONVERT(VARCHAR(10), l.fechaSolicitud,103)) fechaSolicitud, l.usuarioId FROM [vip].[Licencia] l
	WHERE l.clientePaqueteId = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_DarLicencia]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_DarLicencia]
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_DarLicencia]
	@id					int,
	@fechaInicioLicencia	DATETIME,
	@fechaFinLicencia		DATETIME
AS
BEGIN
	DECLARE @FechaPaquete DATETIME
	
	DECLARE db_cursor CURSOR FOR  
	(SELECT id, fechaRegistro
	FROM [vip].[ClientePaquete]
	WHERE id = @id
	union
	SELECT id, fechaRegistro
	FROM [vip].[ClientePaquete]
	WHERE adicional = @id
	)
	
	OPEN db_cursor   
	FETCH NEXT FROM db_cursor INTO @id, @FechaPaquete

	WHILE @@FETCH_STATUS = 0   
	BEGIN   
		UPDATE [vip].[ClientePaquete]
		SET fechaRegistro = (SELECT DATEADD(day, DATEDIFF(day,@fechaInicioLicencia,@fechaFinLicencia), @FechaPaquete))
		WHERE id = @id
	
	FETCH NEXT FROM db_cursor INTO @id, @FechaPaquete   
	END   

	CLOSE db_cursor   
	DEALLOCATE db_cursor
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_DarLicencia]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_DarLicencia]
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_DarLicencia]
	@id					int,
	@fechaInicioLicencia	DATETIME,
	@fechaFinLicencia		DATETIME
AS
BEGIN
	DECLARE @FechaPaquete DATETIME
	
	DECLARE db_cursor CURSOR FOR  
	(SELECT id, fechaRegistro
	FROM [vip].[ClientePaquete]
	WHERE id = @id
	union
	SELECT id, fechaRegistro
	FROM [vip].[ClientePaquete]
	WHERE adicional = @id
	)
	
	OPEN db_cursor   
	FETCH NEXT FROM db_cursor INTO @id, @FechaPaquete

	WHILE @@FETCH_STATUS = 0   
	BEGIN   
		UPDATE [vip].[ClientePaquete]
		SET fechaRegistro = (SELECT DATEADD(day, DATEDIFF(day,@fechaInicioLicencia,@fechaFinLicencia), @FechaPaquete))
		WHERE id = @id
	
	FETCH NEXT FROM db_cursor INTO @id, @FechaPaquete   
	END   

	CLOSE db_cursor   
	DEALLOCATE db_cursor
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_QuitarLicencia]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_QuitarLicencia]
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_QuitarLicencia]
	@id					int
AS
BEGIN
	DECLARE @FechaPaquete DATETIME
	DECLARE @FechaInicioLicencia DATETIME
	DECLARE @FechaFinLicencia DATETIME
	DECLARE @dias			int
	DECLARE @clientePaqueteId			int
	BEGIN
		SELECT @FechaInicioLicencia = (SELECT l.fechaInicioLicencia
		FROM [vip].[Licencia] l
		WHERE l.id = @id)
		SELECT @FechaFinLicencia = (SELECT l.fechaFinLicencia
		FROM [vip].[Licencia] l
		WHERE l.id = @id)
		SELECT @clientePaqueteId = (SELECT l.clientePaqueteId
		FROM [vip].[Licencia] l
		WHERE l.id = @id)
	END
	DECLARE db_cursor CURSOR FOR  
	(SELECT id, fechaRegistro
	FROM [vip].[ClientePaquete]
	WHERE id = @clientePaqueteId
	union
	SELECT id, fechaRegistro
	FROM [vip].[ClientePaquete]
	WHERE adicional = @clientePaqueteId
	)
	
	OPEN db_cursor   
	FETCH NEXT FROM db_cursor INTO @id, @FechaPaquete

	WHILE @@FETCH_STATUS = 0   
	BEGIN   
		set @dias = (DATEDIFF(day,@fechaFinLicencia,@fechaInicioLicencia))
		if (@dias =0)
		begin
			set @dias = -1
		end 
		
		UPDATE [vip].[ClientePaquete]
		SET fechaRegistro = (SELECT DATEADD(day, @dias, @FechaPaquete))
		WHERE id = @id
	
	FETCH NEXT FROM db_cursor INTO @id, @FechaPaquete   
	END   

	CLOSE db_cursor   
	DEALLOCATE db_cursor
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_TraerXOrCriterioPaquetes]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_TraerXOrCriterioPaquetes] 
END
GO

CREATE PROCEDURE [vip].[Cliente_TraerXOrCriterioPaquetes] 
	@nombre			varchar(100) = '',
	@correo				varchar(150) = '',
	@ci					varchar(15) = '',
	@estado				varchar(1) = '',
	@clientePaqueteId				varchar(1) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
	IF(@clientePaqueteId = '')
	BEGIN
	IF(@nombre = '*')
	BEGIN
		SELECT c.ci, c.nombre, c.apellidos, c.empresaId, c.estado,isnull((select isnull(e.nombre,'-') from [vip].[Empresa] e where e.id = c.empresaId),'-') empresa, c.nombre + ' ' + c.apellidos nombreCompleto, cp.id , (select p.nombre from [vip].[Paquete] p where p.id = cp.paqueteId) nombrePaquete
		FROM [vip].[Cliente] c, [vip].[ClientePaquete] cp
		WHERE
		c.id = cp.clienteId and
		c.correo like '%' + @correo + '%'
		and c.estado like '%' + @estado + '%'
		ORDER BY c.nombre asc 
		RETURN
	END
	ELSE
	BEGIN
		SELECT c.ci, c.nombre, c.apellidos, c.empresaId, c.estado,isnull((select isnull(e.nombre,'-') from [vip].[Empresa] e where e.id = c.empresaId),'-') empresa, c.nombre + ' ' + c.apellidos nombreCompleto, cp.id , (select p.nombre from [vip].[Paquete] p where p.id = cp.paqueteId) paqueteNombre
		FROM [vip].[Cliente] c, [vip].[ClientePaquete] cp
		WHERE
		c.id = cp.clienteId and
		c.apellidos + c.nombre like '%' + @nombre + '%' 
		and c.correo like '%' + @correo + '%'
		or c.ci like '%' + @ci + '%'
		and c.estado like '%' + @estado + '%'
		ORDER BY c.nombre asc 
		RETURN
	END
	END
	ELSE
	BEGIN
		IF(@nombre = '*')
		BEGIN
			SELECT c.ci, c.nombre, c.apellidos, c.empresaId, c.estado,isnull((select isnull(e.nombre,'-') from [vip].[Empresa] e where e.id = c.empresaId),'-') empresa, c.nombre + ' ' + c.apellidos nombreCompleto, cp.id , (select p.nombre from [vip].[Paquete] p where p.id = cp.paqueteId) paqueteNombre
			FROM [vip].[Cliente] c, [vip].[ClientePaquete] cp
			WHERE
			c.id = cp.clienteId and
			cp.id = @clientePaqueteId and
			c.correo like '%' + @correo + '%'
			and c.estado like '%' + @estado + '%'
			ORDER BY c.nombre asc 
			RETURN
		END
		ELSE
		BEGIN
			SELECT c.ci, c.nombre, c.apellidos, c.empresaId, c.estado,isnull((select isnull(e.nombre,'-') from [vip].[Empresa] e where e.id = c.empresaId),'-') empresa, c.nombre + ' ' + c.apellidos nombreCompleto, cp.id , (select p.nombre from [vip].[Paquete] p where p.id = cp.paqueteId) paqueteNombre
			FROM [vip].[Cliente] c, [vip].[ClientePaquete] cp
			WHERE
			c.id = cp.clienteId and
			cp.id = @clientePaqueteId and
			c.apellidos + c.nombre like '%' + @nombre + '%' 
			and c.correo like '%' + @correo + '%'
			or c.ci like '%' + @ci + '%'
			and c.estado like '%' + @estado + '%'
			ORDER BY c.nombre asc 
			RETURN
		END
	END
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_TraerXOrCriterioPaquetesReporte]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_TraerXOrCriterioPaquetesReporte] 
END
GO

CREATE PROCEDURE [vip].[Cliente_TraerXOrCriterioPaquetesReporte] 
	@nombre			varchar(100) = '',
	@correo				varchar(150) = '',
	@ci					varchar(15) = '',
	@estado				varchar(1) = '',
	@clientePaqueteId				varchar(1) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
	IF(@clientePaqueteId = '')
	BEGIN
	IF(@nombre = '*')
	BEGIN
		SELECT c.ci, c.nombre, c.apellidos, c.empresaId, c.estado,isnull((select isnull(e.nombre,'-') from [vip].[Empresa] e where e.id = c.empresaId),'-') empresa, c.nombre + ' ' + c.apellidos nombreCompleto, cp.id , (select p.nombre from [vip].[Paquete] p where p.id = cp.paqueteId) nombrePaquete
		FROM [vip].[Cliente] c, [vip].[ClientePaquete] cp, [vip].[Licencia] l
		WHERE
		l.clientePaqueteId = cp.id and
		c.id = cp.clienteId and
		c.correo like '%' + @correo + '%'
		and c.estado like '%' + @estado + '%'
		ORDER BY c.nombre asc 
		RETURN
	END
	ELSE
	BEGIN
		SELECT c.ci, c.nombre, c.apellidos, c.empresaId, c.estado,isnull((select isnull(e.nombre,'-') from [vip].[Empresa] e where e.id = c.empresaId),'-') empresa, c.nombre + ' ' + c.apellidos nombreCompleto, cp.id , (select p.nombre from [vip].[Paquete] p where p.id = cp.paqueteId) paqueteNombre
		FROM [vip].[Cliente] c, [vip].[ClientePaquete] cp, [vip].[Licencia] l
		WHERE
		l.clientePaqueteId = cp.id and
		c.id = cp.clienteId and
		c.apellidos + c.nombre like '%' + @nombre + '%' 
		and c.correo like '%' + @correo + '%'
		or c.ci like '%' + @ci + '%'
		and c.estado like '%' + @estado + '%'
		ORDER BY c.nombre asc 
		RETURN
	END
	END
	ELSE
	BEGIN
		IF(@nombre = '*')
		BEGIN
			SELECT c.ci, c.nombre, c.apellidos, c.empresaId, c.estado,isnull((select isnull(e.nombre,'-') from [vip].[Empresa] e where e.id = c.empresaId),'-') empresa, c.nombre + ' ' + c.apellidos nombreCompleto, cp.id , (select p.nombre from [vip].[Paquete] p where p.id = cp.paqueteId) paqueteNombre
			FROM [vip].[Cliente] c, [vip].[ClientePaquete] cp, [vip].[Licencia] l
			WHERE
			l.clientePaqueteId = cp.id and
			c.id = cp.clienteId and
			cp.id = @clientePaqueteId and
			c.correo like '%' + @correo + '%'
			and c.estado like '%' + @estado + '%'
			ORDER BY c.nombre asc 
			RETURN
		END
		ELSE
		BEGIN
			SELECT c.ci, c.nombre, c.apellidos, c.empresaId, c.estado,isnull((select isnull(e.nombre,'-') from [vip].[Empresa] e where e.id = c.empresaId),'-') empresa, c.nombre + ' ' + c.apellidos nombreCompleto, cp.id , (select p.nombre from [vip].[Paquete] p where p.id = cp.paqueteId) paqueteNombre
			FROM [vip].[Cliente] c, [vip].[ClientePaquete] cp, [vip].[Licencia] l
			WHERE
			l.clientePaqueteId = cp.id and
			c.id = cp.clienteId and
			cp.id = @clientePaqueteId and
			c.apellidos + c.nombre like '%' + @nombre + '%' 
			and c.correo like '%' + @correo + '%'
			or c.ci like '%' + @ci + '%'
			and c.estado like '%' + @estado + '%'
			ORDER BY c.nombre asc 
			RETURN
		END
	END
	END
END
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[MovimientoCaja_TraerXObservacion]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[MovimientoCaja_TraerXObservacion]
END
GO

CREATE PROCEDURE [vip].[MovimientoCaja_TraerXObservacion] 
	@fechaDesde			datetime = null,
	@fechaHasta			datetime = null,
	@cajeroId		uniqueidentifier = null,
	-- TIPO
	-- 0 = Todas
	-- 1 = Sin Observación
	-- 2 = Observadas
	@tipo			char(1) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	
	IF @tipo = '0'
	BEGIN
		SELECT *
		FROM [vip].[MovimientoCaja] m 
		INNER JOIN [vip].[Caja] c ON c.id = m.cajaId 
		INNER JOIN [dbo].[aspnet_Users] u ON u.UserId = c.cajeroId
		WHERE (c.cajeroId = @cajeroId or @cajeroId is null)
		AND (m.fechaHoraCierre >= @fechaDesde or @fechaHasta is null or m.fechaHoraCierre = null) 
		AND (m.fechaHoraCierre <= @fechaHasta or @fechaHasta is null or m.fechaHoraCierre = null) 
		ORDER BY m.fechaHoraCierre desc 
		RETURN
	END	
	IF @tipo = '1'
	BEGIN
		SELECT *
		FROM [vip].[MovimientoCaja] m 
		INNER JOIN [vip].[Caja] c ON c.id = m.cajaId 
		INNER JOIN [dbo].[aspnet_Users] u ON u.UserId = c.cajeroId
		WHERE (c.cajeroId = @cajeroId or @cajeroId is null)
		AND (m.fechaHoraCierre >= @fechaDesde or @fechaHasta is null or m.fechaHoraCierre = null) 
		AND (m.fechaHoraCierre <= @fechaHasta or @fechaHasta is null or m.fechaHoraCierre = null) 
		AND (m.observacion is null or m.observacion = '')  
		ORDER BY m.fechaHoraCierre desc 
		RETURN
	END	
	IF @tipo = '2'
	BEGIN
		SELECT *
		FROM [vip].[MovimientoCaja] m 
		INNER JOIN [vip].[Caja] c ON c.id = m.cajaId 
		INNER JOIN [dbo].[aspnet_Users] u ON u.UserId = c.cajeroId
		WHERE (c.cajeroId = @cajeroId or @cajeroId is null)
		AND (m.fechaHoraCierre >= @fechaDesde or @fechaHasta is null or m.fechaHoraCierre = null) 
		AND (m.fechaHoraCierre <= @fechaHasta or @fechaHasta is null or m.fechaHoraCierre = null) 
		AND (m.observacion is not null 
		and m.observacion <> '')
		ORDER BY m.fechaHoraCierre desc 
		RETURN
	END		
END
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

ALTER PROCEDURE [vip].[Grupo_TraerXCriterio] 
	@nombre				varchar(100) = '',
	@servicioId			varchar(150) = '',
	@estado				varchar(10) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT g.*,(select h.horaInicio + '-' + h.horaFin  from [vip].[Horario] h where h.id = g.horarioId) horario, 
		(select h.finDeSemana  from [vip].[Horario] h where h.id = g.horarioId) finDeSemana, 
		(select s.nombre from [vip].[Servicio] s where s.id = g.servicioId ) nombreServicio,(select s.nombre from [vip].[Sala] s, [vip].[Horario] h where h.id = g.horarioId and s.id = h.salaId) sala
		FROM [vip].[Grupo] g, [vip].[Servicio] ss
		WHERE 
		ss.id = g.servicioid 
		and ss.nombre like '%' + @nombre + '%' 
		and g.servicioId like '%' + @servicioId + '%'
		and (select CAST(g.estado AS char(10))) like '%' + @estado + '%'
		ORDER BY Id asc 
		RETURN
	END
END
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

ALTER TABLE [vip].[Caja] ALTER COLUMN numero int null 
GO

ALTER PROCEDURE [vip].[Caja_Insertar]
	@id				int OUTPUT,
	@cajeroId		varchar(100),
	@fechaCreacion	datetime,
	@estado	bit
AS
BEGIN
	
	INSERT INTO [vip].[Caja](cajeroId, fechaCreacion,estado) 
	VALUES (@cajeroId, @fechaCreacion,@estado) 
	SET @Id = SCOPE_IDENTITY() 
	UPDATE [vip].[Caja] SET numero = @ID where id = @Id
END
GO 

ALTER PROCEDURE [vip].[Caja_Actualizar]
	@id				int,
	@cajeroId		varchar(100),
	@fechaCreacion	datetime,
	@estado	bit
AS
BEGIN

	UPDATE [vip].[Caja] 
	SET cajeroId = @cajeroId,
	--fechaCreacion = @fechaCreacion,
	estado = @estado
	WHERE Id = @id
	
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Caja_TraerUltimoID]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Caja_TraerUltimoID]
END

GO

CREATE PROCEDURE [vip].[Caja_TraerUltimoID] 
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT max(numero)
		FROM [vip].[Caja] 
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_Insertar]
END
GO

CREATE PROCEDURE [vip].[PagoCliente_Insertar]
	@id				int OUTPUT,
	@clientePaqueteId	int	,
	@concepto	varchar(250)	,
	@formaPago	char(2)	,
	@numeroFactura	int	,
	@digitosTarjeta_12	varchar(12)	,
	@numeroAprobacionPOS	varchar(20)	,
	@numeroCheque	varchar(20)	,
	@nombreBancoCheque	varchar(50)	,
	@numeroCuentaTransferencia	varchar(20)	,
	@nombreBancoTransferencia	varchar(50)	,
	@intercambioId	int	,
	@nroPago	int	,
	@fechaPeriodoInicio	datetime	,
	@fechaPeriodoFin	datetime	,
	@monto	decimal(8, 2)	,
	@fechaPago	datetime	,
	@estado	bit	,
	@usuarioId	uniqueidentifier	,
	@fecha	datetime,
	@ClienteId	int
AS
BEGIN
	declare @nroPagoUltimo	int;
	set @nroPagoUltimo = 0;
	/*set @nroPagoUltimo = (
	CASE WHEN (select cp.adicional 
	from [vip].[PagoCliente] cc, [vip].[ClientePaquete] cp 
	where cc.ClientePaqueteId = cp.id 
	and cp.clienteId = @ClienteId) = "-1"
	THEN
	(SELECT isnull(MAX(cc.nroPago),0)+1
	from [vip].[PagoCliente] cc, [vip].[ClientePaquete] cp 
	where cc.ClientePaqueteId = cp.id 
	and cp.clienteId = @ClienteId)
	ELSE
	(SELECT isnull(MAX(cc.nroPago),0)+1
	from [vip].[PagoCliente] cc, [vip].[ClientePaquete] cp 
	where cc.ClientePaqueteId = cp.id 
	and cp.clienteId = @ClienteId)
	END
	);
	*/
	if(@numeroFactura='')
	BEGIN
		set @numeroFactura = NULL
	END
	if(@digitosTarjeta_12='')
	BEGIN
		set @digitosTarjeta_12 = NULL
	END
	if(@numeroAprobacionPOS='')
	BEGIN
		set @numeroAprobacionPOS = NULL
	END
	if(@numeroCheque='')
	BEGIN
		set @numeroCheque = NULL
	END
	if(@nombreBancoCheque='')
	BEGIN
		set @nombreBancoCheque = NULL
	END
	if(@numeroCuentaTransferencia='')
	BEGIN
		set @numeroCuentaTransferencia = NULL
	END
	if(@nombreBancoTransferencia='')
	BEGIN
		set @nombreBancoTransferencia = NULL
	END
	if(@intercambioId='0')
	BEGIN
		set @digitosTarjeta_12 = NULL
	END
	
	INSERT INTO [vip].[PagoCliente](clientePaqueteId, concepto, formaPago,numeroFactura,digitosTarjeta_12,numeroAprobacionPOS,numeroCheque,nombreBancoCheque,numeroCuentaTransferencia,intercambioId,nroPago,fechaPeriodoInicio,fechaPeriodoFin,monto,fechaPago,estado,usuarioId,fecha) 
	VALUES (@clientePaqueteId, @concepto, @formaPago,@numeroFactura,@digitosTarjeta_12,@numeroAprobacionPOS,@numeroCheque,@nombreBancoCheque,@numeroCuentaTransferencia,@intercambioId,@nroPagoUltimo,@fechaPeriodoInicio,@fechaPeriodoFin,@monto,@fechaPago,@estado,@usuarioId,@fecha) 
	SET @Id = SCOPE_IDENTITY() 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_Actualizar]
END
GO

CREATE PROCEDURE [vip].[PagoCliente_Actualizar]
	@id				int,
	@clientePaqueteId	int	,
	@concepto	varchar(250)	,
	@formaPago	char(2)	,
	@numeroFactura	int	,
	@digitosTarjeta_12	varchar(12)	,
	@numeroAprobacionPOS	varchar(20)	,
	@numeroCheque	varchar(20)	,
	@nombreBancoCheque	varchar(50)	,
	@numeroCuentaTransferencia	varchar(20)	,
	@nombreBancoTransferencia	varchar(50)	,
	@intercambioId	int	,
	@nroPago	int	,
	@fechaPeriodoInicio	datetime	,
	@fechaPeriodoFin	datetime	,
	@monto	decimal(8, 2)	,
	@fechaPago	datetime	,
	@estado	bit	,
	@usuarioId	uniqueidentifier	,
	@fecha	datetime	
AS
BEGIN

	UPDATE [vip].[PagoCliente]
	SET clientePaqueteId = @clientePaqueteId,
	concepto = @concepto,
	formaPago = @formaPago,
	numeroFactura = @numeroFactura,
	digitosTarjeta_12 = @digitosTarjeta_12,
	numeroAprobacionPOS = @numeroAprobacionPOS,
	numeroCheque = @numeroCheque,
	nombreBancoCheque = @nombreBancoCheque,
	numeroCuentaTransferencia = @numeroCuentaTransferencia,
	nombreBancoTransferencia = @nombreBancoTransferencia,
	intercambioId = @intercambioId,
	nroPago = @nroPago,
	fechaPeriodoInicio = @fechaPeriodoInicio,
	fechaPeriodoFin = @fechaPeriodoFin,
	monto = @monto,
	fechaPago = @fechaPago,
	estado = @estado,
	usuarioId = @usuarioId,
	fecha = @fecha
	WHERE Id = @id	
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_Eliminar]
END
GO

CREATE PROCEDURE [vip].[PagoCliente_Eliminar]
	@Id					int 
AS
BEGIN
    DELETE FROM [vip].[PagoCliente]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_TraerXId] 
END
GO

CREATE PROCEDURE [vip].[PagoCliente_TraerXId] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[PagoCliente]
		WHERE id = @id
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_TraerXIdPaquete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_TraerXIdPaquete] 
END
GO

CREATE PROCEDURE [vip].[PagoCliente_TraerXIdPaquete] 
	@id	int,
	@ClientePaqueteId	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[PagoCliente]
		WHERE 
		clientePaqueteId = @ClientePaqueteId
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_TraerXIdPaqueteCliente]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_TraerXIdPaqueteCliente] 
END
GO

CREATE PROCEDURE [vip].[PagoCliente_TraerXIdPaqueteCliente] 
	@id	int,
	@ClientePaqueteId	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT p.*, (SELECT CONVERT(VARCHAR(10), p.fechaPago,103)) fechaPagoSinHora
		FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] c
		WHERE 
		p.clientePaqueteId = c.id
		and c.clienteId = @ClientePaqueteId
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_TraerXIdPaqueteRecibo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_TraerXIdPaqueteRecibo] 
END
GO

CREATE PROCEDURE [vip].[PagoCliente_TraerXIdPaqueteRecibo] 
	@id	int,
	@ClientePaqueteId	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT p.*, cl.nombre + ' ' + cl.apellidos nombreCompleto, ([vip].[CantidadConLetra](p.monto)) MontoLiteral,
		(p.monto - (pa.precio-ISNULL((select pr.montoDescuento from [vip].[Promocion] pr, [vip].[PromocionCliente] prc where pr.id = prc.promocionId),0))) Cancelado,
		(p.monto - (pa.precio-ISNULL((select pr.montoDescuento from [vip].[Promocion] pr, [vip].[PromocionCliente] prc where pr.id = prc.promocionId),0))) Total,
		(select pr.montoDescuento from [vip].[Promocion] pr, [vip].[PromocionCliente] prc where pr.id = prc.promocionId) ,
		(SELECT SUBSTRING(CONVERT(VARCHAR(8), c.fechaRegistro, 5), 0, 3)) DiaPago,
		(SELECT SUBSTRING(CONVERT(VARCHAR(8), p.fechaPago, 5), 4, 2)) MesPago,
		(SELECT SUBSTRING(CONVERT(VARCHAR(10), c.fechaRegistro, 105), 7, 10)) AnoPago
		FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] c, [vip].[Cliente] cl, [vip].[Paquete] pa
		WHERE 
		c.clienteId = cl.id
		and pa.id = c.paqueteId
		and p.clientePaqueteId = c.id
		and p.id = @ClientePaqueteId
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoEmpresa_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoEmpresa_Insertar]
END
GO

CREATE PROCEDURE [vip].[PagoEmpresa_Insertar]
	@id				int OUTPUT,
	@empresaId				int ,
	@clientePaqueteId	int	,
	@concepto	varchar(250)	,
	@formaPago	char(2)	,
	@numeroFactura	int	,
	@digitosTarjeta_12	varchar(12)	,
	@numeroAprobacionPOS	varchar(20)	,
	@numeroCheque	varchar(20)	,
	@nombreBancoCheque	varchar(50)	,
	@numeroCuentaTransferencia	varchar(20)	,
	@nombreBancoTransferencia	varchar(50)	,
	@intercambioId	int	,
	@nroPago	int	,
	@fechaPeriodoInicio	datetime	,
	@fechaPeriodoFin	datetime	,
	@monto	decimal(8, 2)	,
	@fechaPago	datetime	,
	@estado	bit	,
	@usuarioId	uniqueidentifier	,
	@fecha	datetime	
AS
BEGIN
	if(@numeroFactura='')
	BEGIN
		set @numeroFactura = NULL
	END
	if(@digitosTarjeta_12='')
	BEGIN
		set @digitosTarjeta_12 = NULL
	END
	if(@numeroAprobacionPOS='')
	BEGIN
		set @numeroAprobacionPOS = NULL
	END
	if(@numeroCheque='')
	BEGIN
		set @numeroCheque = NULL
	END
	if(@nombreBancoCheque='')
	BEGIN
		set @nombreBancoCheque = NULL
	END
	if(@numeroCuentaTransferencia='')
	BEGIN
		set @numeroCuentaTransferencia = NULL
	END
	if(@nombreBancoTransferencia='')
	BEGIN
		set @nombreBancoTransferencia = NULL
	END
	if(@intercambioId='0')
	BEGIN
		set @digitosTarjeta_12 = NULL
	END
	INSERT INTO [vip].[PagoEmpresa](empresaId,clientePaqueteId, concepto, formaPago,numeroFactura,digitosTarjeta_12,numeroAprobacionPOS,numeroCheque,nombreBancoCheque,numeroCuentaTransferencia,intercambioId,nroPago,fechaPeriodoInicio,fechaPeriodoFin,monto,fechaPago,estado,usuarioId,fecha) 
	VALUES (@empresaId, @clientePaqueteId, @concepto, @formaPago,@numeroFactura,@digitosTarjeta_12,@numeroAprobacionPOS,@numeroCheque,@nombreBancoCheque,@numeroCuentaTransferencia,@intercambioId,@nroPago,@fechaPeriodoInicio,@fechaPeriodoFin,@monto,@fechaPago,@estado,@usuarioId,@fecha) 
	SET @id = SCOPE_IDENTITY() 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoEmpresa_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoEmpresa_Actualizar]
END
GO

CREATE PROCEDURE [vip].[PagoEmpresa_Actualizar]
	@id				int,
	@empresaId				int,
	@clientePaqueteId	int	,
	@concepto	varchar(250)	,
	@formaPago	char(2)	,
	@numeroFactura	int	,
	@digitosTarjeta_12	varchar(12)	,
	@numeroAprobacionPOS	varchar(20)	,
	@numeroCheque	varchar(20)	,
	@nombreBancoCheque	varchar(50)	,
	@numeroCuentaTransferencia	varchar(20)	,
	@nombreBancoTransferencia	varchar(50)	,
	@intercambioId	int	,
	@nroPago	int	,
	@fechaPeriodoInicio	datetime	,
	@fechaPeriodoFin	datetime	,
	@monto	decimal(8, 2)	,
	@fechaPago	datetime	,
	@estado	bit	,
	@usuarioId	uniqueidentifier	,
	@fecha	datetime	
AS
BEGIN

	UPDATE [vip].[PagoEmpresa]
	SET empresaId = @empresaId,
	clientePaqueteId = @clientePaqueteId,
	concepto = @concepto,
	formaPago = @formaPago,
	numeroFactura = @numeroFactura,
	digitosTarjeta_12 = @digitosTarjeta_12,
	numeroAprobacionPOS = @numeroAprobacionPOS,
	numeroCheque = @numeroCheque,
	nombreBancoCheque = @nombreBancoCheque,
	numeroCuentaTransferencia = @numeroCuentaTransferencia,
	nombreBancoTransferencia = @nombreBancoTransferencia,
	intercambioId = @intercambioId,
	nroPago = @nroPago,
	fechaPeriodoInicio = @fechaPeriodoInicio,
	fechaPeriodoFin = @fechaPeriodoFin,
	monto = @monto,
	fechaPago = @fechaPago,
	estado = @estado,
	usuarioId = @usuarioId,
	fecha = @fecha
	WHERE Id = @id	
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoEmpresa_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoEmpresa_Eliminar]
END
GO

CREATE PROCEDURE [vip].[PagoEmpresa_Eliminar]
	@Id					int 
AS
BEGIN
    DELETE FROM [vip].[PagoEmpresa]
	WHERE empresaId = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoEmpresa_EliminarPago]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoEmpresa_EliminarPago]
END
GO

CREATE PROCEDURE [vip].[PagoEmpresa_EliminarPago]
	@Id					int,
	@fechaPago			datetime 
AS
BEGIN
    DELETE FROM [vip].[PagoEmpresa]
	WHERE empresaId = @Id 
	and fechaPago = @fechaPago
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoEmpresa_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoEmpresa_TraerXId] 
END
GO

CREATE PROCEDURE [vip].[PagoEmpresa_TraerXId] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[PagoEmpresa]
		WHERE id = @id
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoEmpresa_TraerXIdPaqueteRecibo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoEmpresa_TraerXIdPaqueteRecibo] 
END
GO

CREATE PROCEDURE [vip].[PagoEmpresa_TraerXIdPaqueteRecibo] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT p.*, cl.nombre + ' ' + cl.apellidos nombreCompleto, ([vip].[CantidadConLetra](p.monto)) MontoLiteral,
		(p.monto - (pa.precio-ISNULL((select pr.montoDescuento from [vip].[Promocion] pr, [vip].[PromocionCliente] prc where pr.id = prc.promocionId),0))) Cancelado,
		(p.monto - (pa.precio-ISNULL((select pr.montoDescuento from [vip].[Promocion] pr, [vip].[PromocionCliente] prc where pr.id = prc.promocionId),0))) Total,
		(select pr.montoDescuento from [vip].[Promocion] pr, [vip].[PromocionCliente] prc where pr.id = prc.promocionId) ,
		(SELECT SUBSTRING(CONVERT(VARCHAR(8), c.fechaRegistro, 5), 0, 3)) DiaPago,
		(SELECT SUBSTRING(CONVERT(VARCHAR(8), p.fechaPago, 5), 4, 2)) MesPago,
		(SELECT SUBSTRING(CONVERT(VARCHAR(10), c.fechaRegistro, 105), 7, 10)) AnoPago
		FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] c, [vip].[Cliente] cl, [vip].[Paquete] pa
		WHERE 
		c.clienteId = cl.id
		and pa.id = c.paqueteId
		and p.clientePaqueteId = c.id
		and p.id = @id
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[DistribucionPago_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[DistribucionPago_Insertar]
END
GO

CREATE PROCEDURE [vip].[DistribucionPago_Insertar]
	@id				int OUTPUT,
	@clienteId		int,
	@porcentaje		int,
	@usuarioId		nvarchar(100),
	@fecha	datetime,
	@estado	bit
AS
BEGIN

	INSERT INTO [vip].[DistribucionPago](clienteId, porcentaje, usuarioId,fecha,estado) 
	VALUES (@clienteId, @porcentaje, @usuarioId,@fecha,@estado) 
	SET @Id = SCOPE_IDENTITY() 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[DistribucionPago_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[DistribucionPago_Actualizar]
END
GO

CREATE PROCEDURE [vip].[DistribucionPago_Actualizar]
	@id				int,
	@clienteId		int,
	@porcentaje		int,
	@usuarioId		nvarchar(100),
	@fecha	datetime,
	@estado	bit
AS
BEGIN

	UPDATE [vip].[DistribucionPago]
	SET clienteId = @clienteId,
	porcentaje = @porcentaje,
	usuarioId = @usuarioId,
	fecha = @fecha,
	estado = @estado
	WHERE Id = @id	
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[DistribucionPago_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[DistribucionPago_Eliminar]
END
GO

CREATE PROCEDURE [vip].[DistribucionPago_Eliminar]
	@Id					int 
AS
BEGIN
    DELETE FROM [vip].[DistribucionPago]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[DistribucionPago_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[DistribucionPago_TraerXId] 
END
GO

CREATE PROCEDURE [vip].[DistribucionPago_TraerXId] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[DistribucionPago]
		WHERE id = @id
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[DistribucionPago_TraerXIdCliente]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[DistribucionPago_TraerXIdCliente] 
END
GO

CREATE PROCEDURE [vip].[DistribucionPago_TraerXIdCliente] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[DistribucionPago]
		WHERE clienteId = @id
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[DistribucionPago_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[DistribucionPago_TraerXCriterio] 
END
GO

CREATE PROCEDURE [vip].[DistribucionPago_TraerXCriterio] 
	@porcentajeInicio	int = 0,
	@porcentajeFin 	int = 100,
	@cliente	varchar(100) = '',
	@empresaId	varchar(100) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT d.*, c.nombre + ' '+ c.apellidos as nombreCliente, e.nombre as nombreEmpresa
		FROM [vip].[DistribucionPago]d, [vip].[Cliente] c, [vip].[Empresa] e
		WHERE
		e.id = c.empresaId and
		c.id = d.clienteId and
		d.porcentaje >= @porcentajeInicio 
		and d.porcentaje <= @porcentajeFin 
		--(select CAST(isnull(d.porcentaje,'') AS char(100))) like '%' + @porcentaje + '%'
		and (c.nombre like '%' + @cliente + '%' or c.apellidos like '%' + @cliente + '%') 
		and e.id like '%' + @empresaId + '%' 
		--and (select CAST(isnull(d.clienteId,'') AS char(100))) like '%' + @clienteId + '%'		
		ORDER BY d.Id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_TraerXCriterioSinEmpresa]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_TraerXCriterioSinEmpresa] 
END
GO

CREATE PROCEDURE [vip].[Cliente_TraerXCriterioSinEmpresa] 
	@nombre			varchar(100) = '',
	@correo				varchar(150) = '',
	@ci					varchar(15) = '',
	@estado				varchar(1) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
	IF(@nombre = '*')
	BEGIN
		SELECT c.apellidos,c.celular,c.correo,c.correoTrabajo,c.direccion,c.empresaId,c.estado,c.estadoCivil,c.fecha
		,c.fechaIngreso,c.fechaNacimiento,c.genero,c.id,c.lugarTrabajo,c.nombre,c.numeroCliente,c.numeroHijos,c.ocupacion
		,c.recibirNotificaciones,c.telefono,c.telefonoTrabajo,c.tieneHijos,c.usuarioId, ([VIP].[TraerTextoTexto] (c.ci)) ciCi,
		([VIP].[TraerNumeroTexto] (c.ci)) ci,isnull((select isnull(e.nombre,'-') from [vip].[Empresa] e where e.id = c.empresaId),'-') empresa, c.nombre + ' ' + c.apellidos nombreCompleto 
		FROM [vip].[Cliente] c
		WHERE
		/*c.correo like '%' + @correo + '%'
		and c.estado like '%' + @estado + '%'
		and */ isnull(c.empresaId,'')<>''
		and c.id not in (select d.clienteId from [vip].[DistribucionPago] d)
		ORDER BY c.nombre asc 
		RETURN
	END
	ELSE
	BEGIN
		SELECT c.apellidos,c.celular,c.correo,c.correoTrabajo,c.direccion,c.empresaId,c.estado,c.estadoCivil,c.fecha
		,c.fechaIngreso,c.fechaNacimiento,c.genero,c.id,c.lugarTrabajo,c.nombre,c.numeroCliente,c.numeroHijos,c.ocupacion
		,c.recibirNotificaciones,c.telefono,c.telefonoTrabajo,c.tieneHijos,c.usuarioId, ([VIP].[TraerTextoTexto] (c.ci)) ciCi,
		([VIP].[TraerNumeroTexto] (c.ci)) ci,isnull((select isnull(e.nombre,'-') from [vip].[Empresa] e where e.id = c.empresaId),'-') empresa, c.nombre + ' ' + c.apellidos nombreCompleto 
		FROM [vip].[Cliente] c
		WHERE
		c.apellidos + c.nombre like '%' + @nombre + '%' 
		
		/*and c.correo like '%' + @correo + '%'
		and c.ci like '%' + @ci + '%'
		and c.estado like '%' + @estado + '%'*/
		and isnull(c.empresaId,'')<>''
		and c.id not in (select d.clienteId from [vip].[DistribucionPago] d)
		ORDER BY c.nombre asc 
		RETURN
	END
	END
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Caja_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Caja_Insertar]
END
GO

CREATE PROCEDURE [vip].[Caja_Insertar]
	@id				int OUTPUT,
	@numero			int,
	@cajeroId		varchar(100),
	@fechaCreacion	datetime,
	@estado	bit
AS
BEGIN

	INSERT INTO [vip].[Caja](numero, cajeroId, fechaCreacion,estado) 
	VALUES (@numero, @cajeroId, @fechaCreacion,@estado) 
	SET @Id = SCOPE_IDENTITY() 

END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Caja_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Caja_Actualizar]
END
GO

CREATE PROCEDURE [vip].[Caja_Actualizar]
	@id				int,
	@numero			int,
	@cajeroId		varchar(100),
	@fechaCreacion	datetime,
	@estado	bit
AS
BEGIN

	UPDATE [vip].[Caja]
	SET numero = @numero,
	cajeroId = @cajeroId,
	--fechaCreacion = @fechaCreacion,
	estado = @estado
	WHERE Id = @id
	
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Caja_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Caja_Eliminar]
END
GO

CREATE PROCEDURE [vip].[Caja_Eliminar]
	@Id					int 
AS
BEGIN
    DELETE FROM [vip].[Caja]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Caja_Cerrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Caja_Cerrar]
END
GO

CREATE PROCEDURE [vip].[Caja_Cerrar]
	@id				int,
	@estado	bit
AS
BEGIN

	UPDATE [vip].[Caja]
	SET 
	estado = @estado
	WHERE Id = @id
	
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Caja' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[Caja]
	ALTER COLUMN fechaCreacion DateTime
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Caja_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Caja_TraerXId] 
END
GO

CREATE PROCEDURE [vip].[Caja_TraerXId] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Caja]
		WHERE id = @id
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Caja_EstaAbierto]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Caja_EstaAbierto] 
END
GO

CREATE PROCEDURE [vip].[Caja_EstaAbierto] 
	@cajeroId	varchar(100)
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Caja]
		WHERE cajeroId = @cajeroId
		and estado = 'true'
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Caja_EstaAsignada]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Caja_EstaAsignada] 
END
GO

CREATE PROCEDURE [vip].[Caja_EstaAsignada] 
	@cajeroId	varchar(100)
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Caja]
		WHERE cajeroId = @cajeroId
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Caja_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Caja_TraerXCriterio] 
END
GO

CREATE PROCEDURE [vip].[Caja_TraerXCriterio] 
	@numero				varchar(100) = '',
	@cajeroId	varchar(100) = '',
	@estado				varchar(10) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
	if(@estado='')
	BEGIN
		SELECT *
		FROM [vip].[Caja]
		WHERE
		numero like '%' + @numero + '%' 
		and (select CAST(isnull(cajeroId,'') AS char(100))) like '%' + @cajeroId + '%'
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		ORDER BY Id asc 
		RETURN
	END
	IF(@estado = 'True')
	BEGIN
		SELECT *
		FROM [vip].[Caja]
		WHERE
		numero like '%' + @numero + '%' 
		and (select CAST(isnull(cajeroId,'') AS char(100))) like '%' + @cajeroId + '%'
		and estado = 'true'

		ORDER BY Id asc 
	END
	IF(@estado = 'False')
	BEGIN
		SELECT *
		FROM [vip].[Caja]
		WHERE
		numero like '%' + @numero + '%' 
		and (select CAST(isnull(cajeroId,'') AS char(100))) like '%' + @cajeroId + '%'
		and estado = 'false'

		ORDER BY Id asc 
	END
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[MovimientoCaja_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[MovimientoCaja_Insertar]
END
GO

CREATE PROCEDURE [vip].[MovimientoCaja_Insertar]
	@id					int OUTPUT,
	@cajaId				int,
	@fechaHoraApertura	datetime,
	@montoAperturaBob	decimal(8,2),
	@montoAperturaSus	decimal(8,2),
	@tipoCambio			decimal(8,2),
	@usuarioId			varchar(100),
	@fecha				datetime,
	@estado				bit
AS
BEGIN

	INSERT INTO [vip].[MovimientoCaja](cajaId, fechaHoraApertura, 
	montoAperturaBob, montoAperturaSus, tipoCambio, usuarioId, fecha, estado) 
	VALUES (@cajaId, @fechaHoraApertura, @montoAperturaBob, 
	@montoAperturaSus, @tipoCambio, @usuarioId, @fecha, @estado) 
	SET @Id = SCOPE_IDENTITY() 

END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[MovimientoCaja_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[MovimientoCaja_Actualizar]
END
GO

CREATE PROCEDURE [vip].[MovimientoCaja_Actualizar]
	@id				int,
	@cajaId				int,
	@fechaHoraCierre	datetime,
	@montoCierreBob		decimal(8,2),
	@montoCierreSus		decimal(8,2),
	@montoAdministracionBob  decimal(8,2),
	@montoAdministracionSus  decimal(8,2),
	@observacion		varchar(500),
	@usuarioId			varchar(100),
	@fecha				datetime,
	@estado				bit
AS
BEGIN

	UPDATE [vip].[MovimientoCaja]
	SET cajaId = @cajaId,
	fechaHoraCierre = @fechaHoraCierre,
	montoCierreBob = @montoCierreBob,
	montoCierreSus = @montoCierreSus,
	montoAdministracionBob = @montoAdministracionBob,
	montoAdministracionSus = @montoAdministracionSus,
	observacion = @observacion, 
	usuarioId = @usuarioId,
	fecha = @fecha,
	estado = @estado

	WHERE Id = @id
	
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[MovimientoCaja_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[MovimientoCaja_Eliminar]
END
GO

CREATE PROCEDURE [vip].[MovimientoCaja_Eliminar]
	@Id					int 
AS
BEGIN
    DELETE FROM [vip].[MovimientoCaja]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[MovimientoCaja_Cerrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[MovimientoCaja_Cerrar]
END
GO

CREATE PROCEDURE [vip].[MovimientoCaja_Cerrar]
	@id				int,
	@estado	bit
AS
BEGIN

	UPDATE [vip].[MovimientoCaja]
	SET 
	estado = @estado
	WHERE Id = @id
	
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[MovimientoCaja_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[MovimientoCaja_TraerXId] 
END
GO

CREATE PROCEDURE [vip].[MovimientoCaja_TraerXId] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[MovimientoCaja]
		WHERE id = @id
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[MovimientoCaja_EstaAbierto]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[MovimientoCaja_EstaAbierto] 
END
GO

CREATE PROCEDURE [vip].[MovimientoCaja_EstaAbierto] 
	@cajaId	varchar(100)
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[MovimientoCaja]
		WHERE cajaId = @cajaId
		and estado = 'true'
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[MovimientoCaja_UltimoCierre]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[MovimientoCaja_UltimoCierre] 
END
GO

CREATE PROCEDURE [vip].[MovimientoCaja_UltimoCierre] 
	@cajaId	varchar(100)
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT top 1 m.*
		FROM [vip].[MovimientoCaja] m
		WHERE m.cajaId = @cajaId
		ORDER BY m.fechaHoraCierre desc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[MovimientoCaja_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[MovimientoCaja_TraerXCriterio] 
END
GO

CREATE PROCEDURE [vip].[MovimientoCaja_TraerXCriterio] 
	@usuarioId				varchar(100) = '',
	@cajaId	varchar(100) = '',
	@estado				varchar(10) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
	if(@estado='')
	BEGIN
		SELECT *
		FROM [vip].[MovimientoCaja]
		WHERE
		usuarioId like '%' + @usuarioId + '%' 
		and (select CAST(isnull(cajaId,'') AS char(100))) like '%' + @cajaId + '%'
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		ORDER BY Id asc 
		RETURN
	END
	IF(@estado = 'True')
	BEGIN
		SELECT *
		FROM [vip].[MovimientoCaja]
		WHERE
		usuarioId like '%' + @usuarioId + '%' 
		and (select CAST(isnull(cajaId,'') AS char(100))) like '%' + @cajaId + '%'
		and estado = 'true'

		ORDER BY Id asc 
	END
	IF(@estado = 'False')
	BEGIN
		SELECT *
		FROM [vip].[MovimientoCaja]
		WHERE
		usuarioId like '%' + @usuarioId + '%' 
		and (select CAST(isnull(cajaId,'') AS char(100))) like '%' + @cajaId + '%'
		and estado = 'false'

		ORDER BY Id asc 
	END
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Unidad_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Unidad_TraerXId] 
END
GO

CREATE PROCEDURE [vip].[Unidad_TraerXId] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Unidad]
		WHERE id = @id
		ORDER BY id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Paquete_TraerSinAdicional]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Paquete_TraerSinAdicional] 
END
GO

CREATE PROCEDURE [vip].[Paquete_TraerSinAdicional] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT p.id, p.nombre
		FROM [vip].[Paquete] p, [vip].[ClientePaquete] cp
		WHERE p.id = cp.paqueteId
		and cp.clienteId = @id
		/*and cp.adicional = -1*/
		ORDER BY p.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Paquete_TraerAdicional]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Paquete_TraerAdicional] 
END
GO

CREATE PROCEDURE [vip].[Paquete_TraerAdicional] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT p.id, p.nombre
		FROM [vip].[Paquete] p, [vip].[ClientePaquete] cp
		WHERE p.id = cp.paqueteId
		and cp.id = @id
		union
		SELECT p.id, p.nombre
		FROM [vip].[Paquete] p, [vip].[ClientePaquete] cp
		WHERE p.id = cp.paqueteId
		and cp.adicional = @id
		ORDER BY p.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Paquete_TraerAdicionalPadre]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Paquete_TraerAdicionalPadre] 
END
GO

CREATE PROCEDURE [vip].[Paquete_TraerAdicionalPadre] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT cp.id, p.nombre
		FROM [vip].[Paquete] p, [vip].[ClientePaquete] cp
		WHERE p.id = cp.paqueteId
		and cp.id = @id
		union
		SELECT cp.id, p.nombre
		FROM [vip].[Paquete] p, [vip].[ClientePaquete] cp
		WHERE p.id = cp.paqueteId
		and cp.adicional = @id
		ORDER BY cp.id desc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Promocion_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Promocion_Insertar]
END
GO

CREATE PROCEDURE [vip].[Promocion_Insertar]
	@id				int OUTPUT,
	@fechaInicio	datetime,
	@fechaFin	datetime,
	@montoDescuento	decimal(8, 2),
	@usuarioId	uniqueidentifier,
	@fecha		datetime,
	@estado	bit,
	@nombre		varchar(100)
AS
BEGIN

	INSERT INTO [vip].[Promocion](fechaInicio, fechaFin,montoDescuento,usuarioId,fecha,estado,nombre) 
	VALUES (@fechaInicio, @fechaFin, @montoDescuento,@usuarioId, @fecha,@estado,@nombre) 
	SET @Id = SCOPE_IDENTITY() 

END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Promocion_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Promocion_Actualizar]
END
GO

CREATE PROCEDURE [vip].[Promocion_Actualizar]
	@id				int,
	@fechaInicio	datetime,
	@fechaFin	datetime,
	@montoDescuento	decimal(8, 2),
	@usuarioId	uniqueidentifier,
	@fecha		datetime,
	@estado	bit,
	@nombre		varchar(100)
AS
BEGIN

	UPDATE [vip].[Promocion]
	SET fechaInicio = @fechaInicio,
	fechaFin = @fechaFin,
	montoDescuento = @montoDescuento,
	usuarioId = @usuarioId,
	fecha = @fecha,
	estado = @estado,
	nombre = @nombre
	WHERE Id = @id
	
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Promocion_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Promocion_Eliminar]
END
GO

CREATE PROCEDURE [vip].[Promocion_Eliminar]
	@Id					int 
AS
BEGIN
    DELETE FROM [vip].[Promocion]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Promocion_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Promocion_TraerXCriterio] 
END
GO

CREATE PROCEDURE [vip].[Promocion_TraerXCriterio] 
	@fechaInicio				varchar(10) = '',
	@fechaFin					varchar(100) = '',
	@estado						varchar(10) = '',
	@nombre						varchar(100) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
	if(@fechaInicio='' and @fechaFin='')
	BEGIN
	if(@estado='')
	BEGIN
		SELECT *
		FROM [vip].[Promocion]
		WHERE
		nombre like '%' + @nombre + '%' 
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		ORDER BY Id asc 
		RETURN
	END
	IF(@estado = 'True')
	BEGIN
		SELECT *
		FROM [vip].[Promocion]
		WHERE
		nombre like '%' + @nombre + '%' 
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		and estado = 'true'

		ORDER BY Id asc 
	END
	IF(@estado = 'False')
	BEGIN
		SELECT *
		FROM [vip].[Promocion]
		WHERE
		nombre like '%' + @nombre + '%' 
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		and estado = 'false'

		ORDER BY Id asc 
	END
	END
	ELSE
	
	BEGIN
	if(@estado='')
	BEGIN
		SELECT *
		FROM [vip].[Promocion]
		WHERE
		fechaInicio BETWEEn @fechaInicio and @fechaFin 
		or fechaFin BETWEEn @fechaInicio and @fechaFin 
		and nombre like '%' + @nombre + '%' 
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		ORDER BY Id asc 
		RETURN
	END
	IF(@estado = 'True')
	BEGIN
		SELECT *
		FROM [vip].[Promocion]
		WHERE
		fechaInicio BETWEEn @fechaInicio and @fechaFin 
		or fechaFin BETWEEn @fechaInicio and @fechaFin 
		and nombre like '%' + @nombre + '%' 
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		and estado = 'true'

		ORDER BY Id asc 
	END
	IF(@estado = 'False')
	BEGIN
		SELECT *
		FROM [vip].[Promocion]
		WHERE
		fechaInicio BETWEEn @fechaInicio and @fechaFin 
		or fechaFin BETWEEn @fechaInicio and @fechaFin 
		and nombre like '%' + @nombre + '%' 
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		and estado = 'false'

		ORDER BY Id asc 
	END
	END
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Promocion_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Promocion_TraerXId]
END
GO

CREATE PROCEDURE [vip].[Promocion_TraerXId]
	@Id					int 
AS
BEGIN
    SELECT * FROM [vip].[Promocion]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Licencia_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Licencia_Insertar]
END
GO

CREATE PROCEDURE [vip].[Licencia_Insertar]
	@id				int OUTPUT,
	@descripcion	varchar(100),
	@clientePaqueteId	int,
	@fechaSolicitud	datetime,
	@fechaInicioLicencia	datetime,
	@usuarioId	uniqueidentifier,
	@fecha		datetime,
	@estado	bit,
	@fechaFinLicencia	datetime
AS
BEGIN

	INSERT INTO [vip].[Licencia](descripcion,clientePaqueteId,fechaSolicitud,fechaInicioLicencia,fechaFinLicencia,usuarioId,fecha,estado) 
	VALUES (@descripcion,@clientePaqueteId,@fechaSolicitud, @fechaInicioLicencia, @fechaFinLicencia,@usuarioId, @fecha,@estado) 
	SET @Id = SCOPE_IDENTITY() 

END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Licencia_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Licencia_Actualizar]
END
GO

CREATE PROCEDURE [vip].[Licencia_Actualizar]
	@id				int,
	@descripcion	varchar(100),
	@clientePaqueteId	int,
	@fechaSolicitud	datetime,
	@fechaInicioLicencia	datetime,
	@usuarioId	uniqueidentifier,
	@fecha		datetime,
	@estado	bit,
	@fechaFinLicencia	datetime
AS
BEGIN

	UPDATE [vip].[Licencia]
	SET 
	descripcion = @descripcion,
	clientePaqueteId = @clientePaqueteId,
	fechaSolicitud = @fechaSolicitud,
	fechaInicioLicencia = @fechaInicioLicencia,
	usuarioId = @usuarioId,
	fecha = @fecha,
	estado = @estado,
	fechaFinLicencia = @fechaFinLicencia
	WHERE Id = @id
	
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Licencia_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Licencia_Eliminar]
END
GO

CREATE PROCEDURE [vip].[Licencia_Eliminar]
	@Id					int 
AS
BEGIN
    DELETE FROM [vip].[Licencia]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Licencia_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Licencia_TraerXCriterio] 
END
GO

CREATE PROCEDURE [vip].[Licencia_TraerXCriterio] 
	@descripcion					varchar(100),
	@clientePaqueteId				int,
	@fechaInicioLicencia					varchar(10) = '',
	@estado						varchar(10) = '',
	@fechaFinLicencia						varchar(10) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	IF(@clientePaqueteId = 0)
	BEGIN
		BEGIN
	if(@fechaInicioLicencia='' and @fechaFinLicencia='')
	BEGIN
	if(@estado='')
	BEGIN
		SELECT *
		FROM [vip].[Licencia]
		WHERE
		descripcion like '%' +  @descripcion + '%'
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		ORDER BY Id asc 
		RETURN
	END
	IF(@estado = 'True')
	BEGIN
		SELECT *
		FROM [vip].[Licencia]
		WHERE
		descripcion like '%' +  @descripcion + '%'
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		and estado = 'true'

		ORDER BY Id asc 
	END
	IF(@estado = 'False')
	BEGIN
		SELECT *
		FROM [vip].[Licencia]
		WHERE
		descripcion like '%' +  @descripcion + '%'
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		and estado = 'false'

		ORDER BY Id asc 
	END
	END
	ELSE
	
	BEGIN
	if(@estado='')
	BEGIN
		SELECT *
		FROM [vip].[Licencia]
		WHERE
		fechaInicioLicencia BETWEEn @fechaInicioLicencia and @fechaFinLicencia 
		or fechaFinLicencia BETWEEn @fechaInicioLicencia and @fechaFinLicencia 
		and descripcion like '%' +  @descripcion + '%'
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		ORDER BY Id asc 
		RETURN
	END
	IF(@estado = 'True')
	BEGIN
		SELECT *
		FROM [vip].[Licencia]
		WHERE
		fechaInicioLicencia BETWEEn @fechaInicioLicencia and @fechaFinLicencia 
		or fechaFinLicencia BETWEEn @fechaInicioLicencia and @fechaFinLicencia 
		and descripcion like '%' +  @descripcion + '%'
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		and estado = 'true'

		ORDER BY Id asc 
	END
	IF(@estado = 'False')
	BEGIN
		SELECT *
		FROM [vip].[Licencia]
		WHERE
		fechaInicioLicencia BETWEEn @fechaInicioLicencia and @fechaFinLicencia 
		or fechaFinLicencia BETWEEn @fechaInicioLicencia and @fechaFinLicencia 
		and descripcion like '%' +  @descripcion + '%'
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		and estado = 'false'

		ORDER BY Id asc 
	END
	END
	END
	END
	ELSE
	BEGIN
	if(@fechaInicioLicencia='' and @fechaFinLicencia='')
	BEGIN
	if(@estado='')
	BEGIN
		SELECT *
		FROM [vip].[Licencia]
		WHERE
		clientePaqueteId = @clientePaqueteId
		and descripcion like '%' +  @descripcion + '%'
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		ORDER BY Id asc 
		RETURN
	END
	IF(@estado = 'True')
	BEGIN
		SELECT *
		FROM [vip].[Licencia]
		WHERE
		clientePaqueteId = @clientePaqueteId 
		and descripcion like '%' +  @descripcion + '%'
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		and estado = 'true'

		ORDER BY Id asc 
	END
	IF(@estado = 'False')
	BEGIN
		SELECT *
		FROM [vip].[Licencia]
		WHERE
		clientePaqueteId = @clientePaqueteId 
		and descripcion like '%' +  @descripcion + '%'
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		and estado = 'false'

		ORDER BY Id asc 
	END
	END
	ELSE
	
	BEGIN
	if(@estado='')
	BEGIN
		SELECT *
		FROM [vip].[Licencia]
		WHERE
		fechaInicioLicencia BETWEEn @fechaInicioLicencia and @fechaFinLicencia 
		or fechaFinLicencia BETWEEn @fechaInicioLicencia and @fechaFinLicencia 
		and clientePaqueteId = @clientePaqueteId 
		and descripcion like '%' +  @descripcion + '%'
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		ORDER BY Id asc 
		RETURN
	END
	IF(@estado = 'True')
	BEGIN
		SELECT *
		FROM [vip].[Licencia]
		WHERE
		fechaInicioLicencia BETWEEn @fechaInicioLicencia and @fechaFinLicencia 
		or fechaFinLicencia BETWEEn @fechaInicioLicencia and @fechaFinLicencia 
		and clientePaqueteId = @clientePaqueteId 
		and descripcion like '%' +  @descripcion + '%'
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		and estado = 'true'

		ORDER BY Id asc 
	END
	IF(@estado = 'False')
	BEGIN
		SELECT *
		FROM [vip].[Licencia]
		WHERE
		fechaInicioLicencia BETWEEn @fechaInicioLicencia and @fechaFinLicencia 
		or fechaFinLicencia BETWEEn @fechaInicioLicencia and @fechaFinLicencia 
		and clientePaqueteId = @clientePaqueteId 
		and descripcion like '%' +  @descripcion + '%'
		and (select CAST(estado AS char(10))) like '%' + @estado + '%'
		and estado = 'false'

		ORDER BY Id asc 
	END
	END
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Licencia_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Licencia_TraerXId]
END
GO

CREATE PROCEDURE [vip].[Licencia_TraerXId]
	@Id					int 
AS
BEGIN
    SELECT * FROM [vip].[Licencia]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Licencia_TraerXIdImp]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Licencia_TraerXIdImp]
END
GO

CREATE PROCEDURE [vip].[Licencia_TraerXIdImp]
	@Id					int 
AS
BEGIN
    SELECT id,clientePaqueteId,(SELECT CONVERT(VARCHAR(10), fechaSolicitud,103)) fechaSolicitud,(SELECT CONVERT(VARCHAR(10), fechaInicioLicencia,103)) fechaInicioLicencia, (SELECT CONVERT(VARCHAR(10), fechaFinLicencia,103)) fechaFinLicencia,estado,usuarioId,fecha,descripcion, (select c.nombre +' '+ c.apellidos from [vip].[ClientePaquete] cp, [vip].[Cliente] c where c.id = cp.clienteId and cp.id = clientePaqueteId) NombreCliente
		,(SELECT CONVERT(VARCHAR(10), (SELECT DATEADD(DAY, 1, fechaFinLicencia)),103)) fechaReincorporacion
		,(DATEDIFF(DAY,fechaInicioLicencia,fechaFinLicencia))+1 CantidadDias
    FROM [vip].[Licencia]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_DarLicencia]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_DarLicencia]
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_DarLicencia]
	@id					int,
	@fechaInicioLicencia	DATETIME,
	@fechaFinLicencia		DATETIME
AS
BEGIN
	DECLARE @FechaPaquete DATETIME
	
	DECLARE db_cursor CURSOR FOR  
	(SELECT id, fechaRegistro
	FROM [vip].[ClientePaquete]
	WHERE id = @id
	union
	SELECT id, fechaRegistro
	FROM [vip].[ClientePaquete]
	WHERE adicional = @id
	)
	
	OPEN db_cursor   
	FETCH NEXT FROM db_cursor INTO @id, @FechaPaquete

	WHILE @@FETCH_STATUS = 0   
	BEGIN   
		UPDATE [vip].[ClientePaquete]
		SET fechaRegistro = (SELECT DATEADD(day, DATEDIFF(day,@fechaInicioLicencia,@fechaFinLicencia), @FechaPaquete))
		WHERE id = @id
	
	FETCH NEXT FROM db_cursor INTO @id, @FechaPaquete   
	END   

	CLOSE db_cursor   
	DEALLOCATE db_cursor
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_DarLicencia]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_DarLicencia]
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_DarLicencia]
	@id					int,
	@fechaInicioLicencia	DATETIME,
	@fechaFinLicencia		DATETIME
AS
BEGIN
	DECLARE @FechaPaquete DATETIME
	
	DECLARE db_cursor CURSOR FOR  
	(SELECT id, fechaRegistro
	FROM [vip].[ClientePaquete]
	WHERE id = @id
	union
	SELECT id, fechaRegistro
	FROM [vip].[ClientePaquete]
	WHERE adicional = @id
	)
	
	OPEN db_cursor   
	FETCH NEXT FROM db_cursor INTO @id, @FechaPaquete

	WHILE @@FETCH_STATUS = 0   
	BEGIN   
		UPDATE [vip].[ClientePaquete]
		SET fechaRegistro = (SELECT DATEADD(day, DATEDIFF(day,@fechaInicioLicencia,@fechaFinLicencia), @FechaPaquete))
		WHERE id = @id
	
	FETCH NEXT FROM db_cursor INTO @id, @FechaPaquete   
	END   

	CLOSE db_cursor   
	DEALLOCATE db_cursor
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_QuitarLicencia]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_QuitarLicencia]
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_QuitarLicencia]
	@id					int
AS
BEGIN
	DECLARE @FechaPaquete DATETIME
	DECLARE @FechaInicioLicencia DATETIME
	DECLARE @FechaFinLicencia DATETIME
	DECLARE @dias			int
	DECLARE @clientePaqueteId			int
	BEGIN
		SELECT @FechaInicioLicencia = (SELECT l.fechaInicioLicencia
		FROM [vip].[Licencia] l
		WHERE l.id = @id)
		SELECT @FechaFinLicencia = (SELECT l.fechaFinLicencia
		FROM [vip].[Licencia] l
		WHERE l.id = @id)
		SELECT @clientePaqueteId = (SELECT l.clientePaqueteId
		FROM [vip].[Licencia] l
		WHERE l.id = @id)
	END
	DECLARE db_cursor CURSOR FOR  
	(SELECT id, fechaRegistro
	FROM [vip].[ClientePaquete]
	WHERE id = @clientePaqueteId
	union
	SELECT id, fechaRegistro
	FROM [vip].[ClientePaquete]
	WHERE adicional = @clientePaqueteId
	)
	
	OPEN db_cursor   
	FETCH NEXT FROM db_cursor INTO @id, @FechaPaquete

	WHILE @@FETCH_STATUS = 0   
	BEGIN   
		set @dias = (DATEDIFF(day,@fechaFinLicencia,@fechaInicioLicencia))
		if (@dias =0)
		begin
			set @dias = -1
		end 
		
		UPDATE [vip].[ClientePaquete]
		SET fechaRegistro = (SELECT DATEADD(day, @dias, @FechaPaquete))
		WHERE id = @id
	
	FETCH NEXT FROM db_cursor INTO @id, @FechaPaquete   
	END   

	CLOSE db_cursor   
	DEALLOCATE db_cursor
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_TraerXOrCriterioPaquetes]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_TraerXOrCriterioPaquetes] 
END
GO

CREATE PROCEDURE [vip].[Cliente_TraerXOrCriterioPaquetes] 
	@nombre			varchar(100) = '',
	@correo				varchar(150) = '',
	@ci					varchar(15) = '',
	@estado				varchar(1) = '',
	@clientePaqueteId				varchar(1) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
	IF(@clientePaqueteId = '')
	BEGIN
	IF(@nombre = '*')
	BEGIN
		SELECT c.ci, c.nombre, c.apellidos, c.empresaId, c.estado,isnull((select isnull(e.nombre,'-') from [vip].[Empresa] e where e.id = c.empresaId),'-') empresa, c.nombre + ' ' + c.apellidos nombreCompleto, cp.id , (select p.nombre from [vip].[Paquete] p where p.id = cp.paqueteId) nombrePaquete
		FROM [vip].[Cliente] c, [vip].[ClientePaquete] cp
		WHERE
		c.id = cp.clienteId and
		c.correo like '%' + @correo + '%'
		and c.estado like '%' + @estado + '%'
		ORDER BY c.nombre asc 
		RETURN
	END
	ELSE
	BEGIN
		SELECT c.ci, c.nombre, c.apellidos, c.empresaId, c.estado,isnull((select isnull(e.nombre,'-') from [vip].[Empresa] e where e.id = c.empresaId),'-') empresa, c.nombre + ' ' + c.apellidos nombreCompleto, cp.id , (select p.nombre from [vip].[Paquete] p where p.id = cp.paqueteId) paqueteNombre
		FROM [vip].[Cliente] c, [vip].[ClientePaquete] cp
		WHERE
		c.id = cp.clienteId and
		c.apellidos + c.nombre like '%' + @nombre + '%' 
		and c.correo like '%' + @correo + '%'
		or c.ci like '%' + @ci + '%'
		and c.estado like '%' + @estado + '%'
		ORDER BY c.nombre asc 
		RETURN
	END
	END
	ELSE
	BEGIN
		IF(@nombre = '*')
		BEGIN
			SELECT c.ci, c.nombre, c.apellidos, c.empresaId, c.estado,isnull((select isnull(e.nombre,'-') from [vip].[Empresa] e where e.id = c.empresaId),'-') empresa, c.nombre + ' ' + c.apellidos nombreCompleto, cp.id , (select p.nombre from [vip].[Paquete] p where p.id = cp.paqueteId) paqueteNombre
			FROM [vip].[Cliente] c, [vip].[ClientePaquete] cp
			WHERE
			c.id = cp.clienteId and
			cp.id = @clientePaqueteId and
			c.correo like '%' + @correo + '%'
			and c.estado like '%' + @estado + '%'
			ORDER BY c.nombre asc 
			RETURN
		END
		ELSE
		BEGIN
			SELECT c.ci, c.nombre, c.apellidos, c.empresaId, c.estado,isnull((select isnull(e.nombre,'-') from [vip].[Empresa] e where e.id = c.empresaId),'-') empresa, c.nombre + ' ' + c.apellidos nombreCompleto, cp.id , (select p.nombre from [vip].[Paquete] p where p.id = cp.paqueteId) paqueteNombre
			FROM [vip].[Cliente] c, [vip].[ClientePaquete] cp
			WHERE
			c.id = cp.clienteId and
			cp.id = @clientePaqueteId and
			c.apellidos + c.nombre like '%' + @nombre + '%' 
			and c.correo like '%' + @correo + '%'
			or c.ci like '%' + @ci + '%'
			and c.estado like '%' + @estado + '%'
			ORDER BY c.nombre asc 
			RETURN
		END
	END
	END
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PromocionCliente_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PromocionCliente_Insertar]
END
GO

CREATE PROCEDURE [vip].[PromocionCliente_Insertar]
	@id				int OUTPUT,
	@clientePaqueteId	int,
	@promocionId	int,
	@fechaAsignacion	datetime,
	@usuarioId	uniqueidentifier,
	@fecha		datetime,
	@estado	bit
AS
BEGIN

	INSERT INTO [vip].[PromocionCliente](clientePaqueteId, promocionId,fechaAsignacion,usuarioId,fecha,estado) 
	VALUES (@clientePaqueteId, @promocionId,@fechaAsignacion,@usuarioId, @fecha,@estado) 
	SET @Id = SCOPE_IDENTITY() 

END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PromocionCliente_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PromocionCliente_Actualizar]
END
GO

CREATE PROCEDURE [vip].[PromocionCliente_Actualizar]
	@id				int,
	@clientePaqueteId	int,
	@promocionId	int,
	@fechaAsignacion	datetime,
	@usuarioId	uniqueidentifier,
	@fecha		datetime,
	@estado	bit
AS
BEGIN

	UPDATE [vip].[PromocionCliente]
	SET clientePaqueteId = @clientePaqueteId,
	promocionId = @promocionId,
	fechaAsignacion = @fechaAsignacion,
	usuarioId = @usuarioId,
	fecha = @fecha,
	estado = @estado
	WHERE Id = @id
	
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PromocionCliente_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PromocionCliente_Eliminar]
END
GO

CREATE PROCEDURE [vip].[PromocionCliente_Eliminar]
	@Id					int 
AS
BEGIN
    DELETE FROM [vip].[PromocionCliente]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PromocionCliente_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PromocionCliente_TraerXCriterio] 
END
GO

CREATE PROCEDURE [vip].[PromocionCliente_TraerXCriterio] 
	@fechaInicio				varchar(10) = '',
	@fechaFin					varchar(100) = '',
	@estado						varchar(10) = '',
	@nombre						varchar(100) = ''
AS
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PromocionCliente_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PromocionCliente_TraerXId]
END
GO

CREATE PROCEDURE [vip].[PromocionCliente_TraerXId]
	@Id					int 
AS
BEGIN
    SELECT * FROM [vip].[PromocionCliente]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PromocionCliente_TraerXIdClientePaquete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PromocionCliente_TraerXIdClientePaquete]
END
GO

CREATE PROCEDURE [vip].[PromocionCliente_TraerXIdClientePaquete]
	@Id					int 
AS
BEGIN
    SELECT p.* FROM [vip].[PromocionCliente] p, [vip].[ClientePaquete] c
	WHERE c.clienteId = @Id 
	and p.clientePaqueteId = c.id
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PromocionCliente_TraerXIdClientePaquetePago]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PromocionCliente_TraerXIdClientePaquetePago]
END
GO

CREATE PROCEDURE [vip].[PromocionCliente_TraerXIdClientePaquetePago]
	@Id					int 
AS
BEGIN
    SELECT p.* FROM [vip].[PromocionCliente] p, [vip].[ClientePaquete] c, [vip].[PagoCliente] pc
	WHERE c.clienteId = @Id
	and c.id = pc.clientePaqueteId
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PromocionCliente_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PromocionCliente_TraerXId]
END
GO

CREATE PROCEDURE [vip].[PromocionCliente_TraerXId]
	@Id					int 
AS
BEGIN
    SELECT * FROM [vip].[PromocionCliente]
	WHERE Id = @Id 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoEmpresa_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoEmpresa_TraerXCriterio]
END
GO

CREATE PROCEDURE [vip].[PagoEmpresa_TraerXCriterio] 
	@nombre	varchar(20) = '',
	@nombrePersonaContacto	varchar(100) = '',
	@correo		varchar(150) = '',
	@estado		varchar(10) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
	if(@estado='')
	BEGIN
		SELECT e.*, (SELECT CONVERT(VARCHAR(23), p.fechaPago, 103)) fechaPago2,(SELECT CONVERT(VARCHAR(23), p.fechaPago, 126)) fechaPago, SUM(p.monto) montoTotal
		FROM [vip].[Empresa] e, [vip].[PagoEmpresa] p
		WHERE
		e.nombre like '%' + @nombre + '%' 
		and e.nombrePersonaContacto like '%' + @nombrePersonaContacto + '%'
		and e.correo like '%' + @correo + '%'
		and (select CAST(e.estado AS char(10))) like '%' + @estado + '%'
		and e.id = p.empresaId
		and p.estado = 'true'
		group by p.empresaId, p.concepto, p.fechaPago, e.correo, e.descripcion,e.direccion
		,e.estado, e.fecha, e.fechaRegistro, e.id, e.nombre, e.nombrePersonaContacto, e.telefono
		,e.usuarioId
		ORDER BY e.id asc 
		RETURN
	END
	IF(@estado = 'True')
	BEGIN
		SELECT e.*, (SELECT CONVERT(VARCHAR(23), p.fechaPago, 103)) fechaPago2, (SELECT CONVERT(VARCHAR(23), p.fechaPago, 126)) fechaPago, SUM(p.monto) montoTotal
		FROM [vip].[Empresa] e, [vip].[PagoEmpresa] p
		WHERE
		e.nombre like '%' + @nombre + '%' 
		and e.nombrePersonaContacto like '%' + @nombrePersonaContacto + '%'
		and e.correo like '%' + @correo + '%'
		and e.estado = 'true'
		and  e.id = p.empresaId
		and p.estado = 'true'
		group by p.empresaId, p.concepto, p.fechaPago, e.correo, e.descripcion,e.direccion
		,e.estado, e.fecha, e.fechaRegistro, e.id, e.nombre, e.nombrePersonaContacto, e.telefono
		,e.usuarioId
		ORDER BY e.id asc 
	END
	IF(@estado = 'False')
	BEGIN
		SELECT e.*, (SELECT CONVERT(VARCHAR(23), p.fechaPago, 103)) fechaPago2,(SELECT CONVERT(VARCHAR(23), p.fechaPago, 126)) fechaPago, SUM(p.monto) montoTotal
		FROM [vip].[Empresa] e, [vip].[PagoEmpresa] p
		WHERE
		e.nombre like '%' + @nombre + '%' 
		and e.nombrePersonaContacto like '%' + @nombrePersonaContacto + '%'
		and e.correo like '%' + @correo + '%'
		and e.estado = 'false'
		and  e.id = p.empresaId
		and p.estado = 'true'
		group by p.empresaId, p.concepto, p.fechaPago, e.correo, e.descripcion,e.direccion
		,e.estado, e.fecha, e.fechaRegistro, e.id, e.nombre, e.nombrePersonaContacto, e.telefono
		,e.usuarioId
		ORDER BY Id asc 
	END
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[CantidadConLetra]'))
BEGIN
	DROP FUNCTION [vip].[CantidadConLetra]
END
GO

CREATE FUNCTION [vip].[CantidadConLetra]
(
    @Numero             Decimal(18,2)
)
RETURNS Varchar(180)
AS
BEGIN
    DECLARE @ImpLetra Varchar(180)
        DECLARE @lnEntero INT,
                        @lcRetorno VARCHAR(512),
                        @lnTerna INT,
                        @lcMiles VARCHAR(512),
                        @lcCadena VARCHAR(512),
                        @lnUnidades INT,
                        @lnDecenas INT,
                        @lnCentenas INT,
                        @lnFraccion INT
        SELECT  @lnEntero = CAST(@Numero AS INT),
                        @lnFraccion = (@Numero - @lnEntero) * 100,
                        @lcRetorno = '',
                        @lnTerna = 1
  WHILE @lnEntero > 0
  BEGIN /* WHILE */
            -- Recorro terna por terna
            SELECT @lcCadena = ''
            SELECT @lnUnidades = @lnEntero % 10
            SELECT @lnEntero = CAST(@lnEntero/10 AS INT)
            SELECT @lnDecenas = @lnEntero % 10
            SELECT @lnEntero = CAST(@lnEntero/10 AS INT)
            SELECT @lnCentenas = @lnEntero % 10
            SELECT @lnEntero = CAST(@lnEntero/10 AS INT)
            -- Analizo las unidades
            SELECT @lcCadena =
            CASE /* UNIDADES */
              WHEN @lnUnidades = 1 THEN 'UN ' + @lcCadena
              WHEN @lnUnidades = 2 THEN 'DOS ' + @lcCadena
              WHEN @lnUnidades = 3 THEN 'TRES ' + @lcCadena
              WHEN @lnUnidades = 4 THEN 'CUATRO ' + @lcCadena
              WHEN @lnUnidades = 5 THEN 'CINCO ' + @lcCadena
              WHEN @lnUnidades = 6 THEN 'SEIS ' + @lcCadena
              WHEN @lnUnidades = 7 THEN 'SIETE ' + @lcCadena
              WHEN @lnUnidades = 8 THEN 'OCHO ' + @lcCadena
              WHEN @lnUnidades = 9 THEN 'NUEVE ' + @lcCadena
              ELSE @lcCadena
            END /* UNIDADES */
            -- Analizo las decenas
            SELECT @lcCadena =
            CASE /* DECENAS */
              WHEN @lnDecenas = 1 THEN
                CASE @lnUnidades
                  WHEN 0 THEN 'DIEZ '
                  WHEN 1 THEN 'ONCE '
                  WHEN 2 THEN 'DOCE '
                  WHEN 3 THEN 'TRECE '
                  WHEN 4 THEN 'CATORCE '
                  WHEN 5 THEN 'QUINCE '
                  WHEN 6 THEN 'DIEZ Y SEIS '
                  WHEN 7 THEN 'DIEZ Y SIETE '
                  WHEN 8 THEN 'DIEZ Y OCHO '
                  WHEN 9 THEN 'DIEZ Y NUEVE '
                END
              WHEN @lnDecenas = 2 THEN
              CASE @lnUnidades
                WHEN 0 THEN 'VEINTE '
                ELSE 'VEINTI' + @lcCadena
              END
              WHEN @lnDecenas = 3 THEN
              CASE @lnUnidades
                WHEN 0 THEN 'TREINTA '
                ELSE 'TREINTA Y ' + @lcCadena
              END
              WHEN @lnDecenas = 4 THEN
                CASE @lnUnidades
                    WHEN 0 THEN 'CUARENTA'
                    ELSE 'CUARENTA Y ' + @lcCadena
                END
              WHEN @lnDecenas = 5 THEN
                CASE @lnUnidades
                    WHEN 0 THEN 'CINCUENTA '
                    ELSE 'CINCUENTA Y ' + @lcCadena
                END
              WHEN @lnDecenas = 6 THEN
                CASE @lnUnidades
                    WHEN 0 THEN 'SESENTA '
                    ELSE 'SESENTA Y ' + @lcCadena
                END
              WHEN @lnDecenas = 7 THEN
                 CASE @lnUnidades
                    WHEN 0 THEN 'SETENTA '
                    ELSE 'SETENTA Y ' + @lcCadena
                 END
              WHEN @lnDecenas = 8 THEN
                CASE @lnUnidades
                    WHEN 0 THEN 'OCHENTA '
                    ELSE  'OCHENTA Y ' + @lcCadena
                END
              WHEN @lnDecenas = 9 THEN
                CASE @lnUnidades
                    WHEN 0 THEN 'NOVENTA '
                    ELSE 'NOVENTA Y ' + @lcCadena
                END
              ELSE @lcCadena
            END /* DECENAS */
            -- Analizo las centenas
            SELECT @lcCadena =
            CASE /* CENTENAS */
              WHEN @lnCentenas = 1 THEN 'CIENTO ' + @lcCadena
              WHEN @lnCentenas = 2 THEN 'DOSCIENTOS ' + @lcCadena
              WHEN @lnCentenas = 3 THEN 'TRESCIENTOS ' + @lcCadena
              WHEN @lnCentenas = 4 THEN 'CUATROCIENTOS ' + @lcCadena
              WHEN @lnCentenas = 5 THEN 'QUINIENTOS ' + @lcCadena
              WHEN @lnCentenas = 6 THEN 'SEISCIENTOS ' + @lcCadena
              WHEN @lnCentenas = 7 THEN 'SETECIENTOS ' + @lcCadena
              WHEN @lnCentenas = 8 THEN 'OCHOCIENTOS ' + @lcCadena
              WHEN @lnCentenas = 9 THEN 'NOVECIENTOS ' + @lcCadena
              ELSE @lcCadena
            END /* CENTENAS */
            -- Analizo la terna
            SELECT @lcCadena =
            CASE /* TERNA */
              WHEN @lnTerna = 1 THEN @lcCadena
              WHEN @lnTerna = 2 THEN @lcCadena + 'MIL '
              WHEN @lnTerna = 3 THEN @lcCadena + 'MILLONES '
              WHEN @lnTerna = 4 THEN @lcCadena + 'MIL '
              ELSE ''
            END /* TERNA */
            -- Armo el retorno terna a terna
            SELECT @lcRetorno = @lcCadena  + @lcRetorno
            SELECT @lnTerna = @lnTerna + 1
   END /* WHILE */
   IF @lnTerna = 1
       SELECT @lcRetorno = 'CERO'
   DECLARE @sFraccion VARCHAR(15)
   SET @sFraccion = '00' + LTRIM(CAST(@lnFraccion AS varchar))
   SELECT @ImpLetra = RTRIM(@lcRetorno) + ' BS ' + SUBSTRING(@sFraccion,LEN(@sFraccion)-1,2) + '/100 BS'

   RETURN @ImpLetra
END
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_TraerXCriterio]
END
GO

CREATE PROCEDURE [vip].[PagoCliente_TraerXCriterio] 
	@fechaPagoInicio	datetime, 
	@fechaPagoFin	datetime, 
	@cajeroId varchar(100)  
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT * 
		FROM [vip].[PagoCliente] pc
		WHERE pc.fechaPago >= @fechaPagoInicio 
		AND pc.fechaPago <= @fechaPagoFin 
		AND pc.usuarioId = @cajeroId
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoEmpresa_TraerXCriterioCaja]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoEmpresa_TraerXCriterioCaja]
END
GO

CREATE PROCEDURE [vip].[PagoEmpresa_TraerXCriterioCaja] 
	@fechaPagoInicio	datetime, 
	@fechaPagoFin	datetime, 
	@cajeroId varchar(100)  
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT * 
		FROM [vip].[PagoEmpresa] pe
		WHERE pe.fechaPago >= @fechaPagoInicio 
		AND pe.fechaPago <= @fechaPagoFin 
		AND pe.usuarioId = @cajeroId
	END
END
GO


IF NOT EXISTS (SELECT * FROM   sys.columns WHERE  object_id = OBJECT_ID(N'[vip].[MovimientoCaja]') AND name = 'montoCorreccion')
	ALTER TABLE [vip].[MovimientoCaja] 
	ADD montoCorreccion decimal(8,2) not null default 0
GO

IF NOT EXISTS (SELECT * FROM   sys.columns WHERE  object_id = OBJECT_ID(N'[vip].[MovimientoCaja]') AND name = 'observado')
	ALTER TABLE [vip].[MovimientoCaja] 
	ADD observado bit not null default 0
GO

IF NOT EXISTS (SELECT * FROM   sys.columns WHERE  object_id = OBJECT_ID(N'[vip].[MovimientoCaja]') AND name = 'observacionAdm')
	ALTER TABLE [vip].[MovimientoCaja] 
	ADD observacionAdm varchar(500) not null default ''
GO

IF NOT EXISTS (SELECT * FROM   sys.columns WHERE  object_id = OBJECT_ID(N'[vip].[MovimientoCaja]') AND name = 'montoCorreccionSus')
	ALTER TABLE [vip].[MovimientoCaja] 
	ADD montoCorreccionSus decimal(8,2) not null default 0
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[MovimientoCaja_TraerXObservacion]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[MovimientoCaja_TraerXObservacion]
END
GO

CREATE PROCEDURE [vip].[MovimientoCaja_TraerXObservacion] 
	@fechaDesde			datetime = null,
	@fechaHasta			datetime = null,
	@cajeroId		uniqueidentifier = null,
	-- TIPO
	-- 0 = Todas
	-- 1 = Sin Observación
	-- 2 = Observadas
	@tipo			char(1) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	
	IF @tipo = '0'
	BEGIN
		SELECT *
		FROM [vip].[MovimientoCaja] m 
		INNER JOIN [vip].[Caja] c ON c.id = m.cajaId 
		INNER JOIN [dbo].[aspnet_Users] u ON u.UserId = c.cajeroId
		WHERE (c.cajeroId = @cajeroId or @cajeroId is null)
		AND (m.fechaHoraCierre >= @fechaDesde or @fechaHasta is null or m.fechaHoraCierre = null) 
		AND (m.fechaHoraCierre <= @fechaHasta or @fechaHasta is null or m.fechaHoraCierre = null) 
		ORDER BY m.fechaHoraCierre desc 
		RETURN
	END	
	IF @tipo = '1'
	BEGIN
		SELECT *
		FROM [vip].[MovimientoCaja] m 
		INNER JOIN [vip].[Caja] c ON c.id = m.cajaId 
		INNER JOIN [dbo].[aspnet_Users] u ON u.UserId = c.cajeroId
		WHERE (c.cajeroId = @cajeroId or @cajeroId is null)
		AND (m.fechaHoraCierre >= @fechaDesde or @fechaHasta is null or m.fechaHoraCierre = null) 
		AND (m.fechaHoraCierre <= @fechaHasta or @fechaHasta is null or m.fechaHoraCierre = null) 
		--AND (m.observacion is null or m.observacion = '')  
		AND (m.observado = 0)  
		ORDER BY m.fechaHoraCierre desc 
		RETURN
	END	
	IF @tipo = '2'
	BEGIN
		SELECT *
		FROM [vip].[MovimientoCaja] m 
		INNER JOIN [vip].[Caja] c ON c.id = m.cajaId 
		INNER JOIN [dbo].[aspnet_Users] u ON u.UserId = c.cajeroId
		WHERE (c.cajeroId = @cajeroId or @cajeroId is null)
		AND (m.fechaHoraCierre >= @fechaDesde or @fechaHasta is null or m.fechaHoraCierre = null) 
		AND (m.fechaHoraCierre <= @fechaHasta or @fechaHasta is null or m.fechaHoraCierre = null) 
		--AND (m.observacion is not null and m.observacion <> '')
		AND (m.observado = 1) 
		ORDER BY m.fechaHoraCierre desc 
		RETURN
	END		
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[MovimientoCaja_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[MovimientoCaja_Actualizar]
END
GO

CREATE PROCEDURE [vip].[MovimientoCaja_Actualizar]
	@id				int,
	@cajaId				int,
	@fechaHoraCierre	datetime,
	@montoCierreBob		decimal(8,2),
	@montoCierreSus		decimal(8,2),
	@montoAdministracionBob  decimal(8,2),
	@montoAdministracionSus  decimal(8,2),
	@observacion		varchar(500),
	@usuarioId			varchar(100),
	@fecha				datetime,
	@estado				bit, 
	@observado			bit, 
	@montoCorregido		decimal(8,2),
	@montoCorregidoSus	decimal(8,2), 
	@observacionAdm		varchar(500)
AS
BEGIN

	UPDATE [vip].[MovimientoCaja]
	SET cajaId = @cajaId,
	fechaHoraCierre = @fechaHoraCierre,
	montoCierreBob = @montoCierreBob,
	montoCierreSus = @montoCierreSus,
	montoAdministracionBob = @montoAdministracionBob,
	montoAdministracionSus = @montoAdministracionSus,
	observacion = @observacion, 
	usuarioId = @usuarioId,
	fecha = @fecha,
	estado = @estado, 
	observado = @observado, 
	montoCorreccion = @montoCorregido, 
	montoCorreccionSus = @montoCorregidoSus, 
	observacionAdm = @observacionAdm 
	WHERE Id = @id
END
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_TraerXFechaPago]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_TraerXFechaPago]
END
GO

CREATE PROCEDURE [vip].[PagoCliente_TraerXFechaPago] 
	@fechaPagoInicio	datetime, 
	@fechaPagoFin	datetime
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		UNION
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		--WHERE fechaPago >= convert(datetime, '2012-07-01', 101) 
		--AND fechaPago <= convert(datetime, '2012-07-31', 101)
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Promocion_TraerDatosTodos]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Promocion_TraerDatosTodos]
END
GO

CREATE PROCEDURE [vip].[Promocion_TraerDatosTodos] 
	@fecha	datetime
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT paq.nombre as paquete, c.nombre, c.apellidos, p.nombre as promocion, p.montodescuento, p.fechainicio, p.fechafin, pc.fechaAsignacion
		FROM [vip].[Promocion] p, [vip].[PromocionCliente] pc, 
		[vip].[Cliente] c, [vip].[ClientePaquete] cp, [vip].[Paquete] paq 
		WHERE p.id = pc. promocionId 
		AND cp.id = pc.clientePaqueteId 
		AND c.id = cp.clienteId 
		AND cp.paqueteId = paq.id 
		AND pc.estado = 1 
		AND p.fechainicio <= @fecha 
		AND p.fechafin >= @fecha
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[DistribucionPago_TraerXPendientes]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[DistribucionPago_TraerXPendientes]
END
GO

CREATE PROCEDURE [vip].[DistribucionPago_TraerXPendientes] 
	@clienteId	varchar(100) = '',
	@empresaId	varchar(100) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT c.nombre + ' '+ c.apellidos as nombreCliente, e.nombre as nombreEmpresa, c.ci, c.fechaIngreso, c.fecha as fechaRegistro
		FROM [vip].[Cliente] c, [vip].[Empresa] e
		WHERE e.id = c.empresaId 
		AND c.empresaId is not null 
		--and (c.nombre like '%' + @cliente + '%' or c.apellidos like '%' + @cliente + '%') 
		and c.id like '%' + @clienteId + '%' 
		and e.id like '%' + @empresaId + '%' 
		and c.id not in (SELECT dp.clienteId FROM [vip].[DistribucionPago] dp WHERE dp.estado = 1)
		ORDER BY c.nombre asc, c.apellidos asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[DistribucionPago_TraerXCriterioPago]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[DistribucionPago_TraerXCriterioPago]
END
GO

CREATE PROCEDURE [vip].[DistribucionPago_TraerXCriterioPago] 
	@porcentajeInicio	int = 0,
	@porcentajeFin 	int = 100,
	@clienteId	varchar(100) = '',
	@empresaId	varchar(100) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT d.porcentaje, d.fecha as fechaAsignacion, c.nombre + ' '+ c.apellidos as nombreCliente, e.nombre as nombreEmpresa, c.ci, c.fechaIngreso, c.fecha as fechaRegistro
		FROM [vip].[DistribucionPago]d, [vip].[Cliente] c, [vip].[Empresa] e
		WHERE
		e.id = c.empresaId and
		c.id = d.clienteId and
		d.porcentaje >= @porcentajeInicio 
		and d.porcentaje <= @porcentajeFin 
		and c.id like '%' + @clienteId + '%' 
		and e.id like '%' + @empresaId + '%' 
		ORDER BY d.Id asc 
		RETURN

	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_TraerConEmpresa]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_TraerConEmpresa]
END
GO

CREATE PROCEDURE [vip].[Cliente_TraerConEmpresa] 
	@cliente	varchar(100) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT c.id, c.nombre + ' '+ c.apellidos as nombreCliente 
		FROM [vip].[Cliente] c
		WHERE c.empresaId is not null 
		AND c.id in (SELECT dp.clienteId FROM [vip].[DistribucionPago] dp) 
		AND (c.nombre like '%' + @cliente + '%' or c.apellidos like '%' + @cliente + '%')
		RETURN

	END
END
GO


IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Cliente' AND xtype='U')
	ALTER TABLE [vip].[Cliente]
	ALTER COLUMN fechaNacimiento datetime NULL 
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_Insertar]
END
GO

CREATE PROCEDURE [vip].[Cliente_Insertar]
	@id				int OUTPUT,
	@nombre	varchar(50),
	@apellidos	varchar(100),
	@direccion	varchar(250)	,
	@telefono	varchar(10)	,
	@celular	varchar(10),
	@celular2	varchar(10),
	@ci	varchar(15)	,
	@correo	varchar(150)	,
	@ocupacion	varchar(150)	,
	@lugarTrabajo	varchar(250)	,
	@telefonoTrabajo	varchar(10)	,
	@correoTrabajo	varchar(150)	,
	@fechaNacimiento	datetime = null	,
	@genero	char(1)	,
	@estadoCivil	char(1)	,
	@tieneHijos	bit	,
	@numeroHijos	int	,
	@fechaIngreso	datetime	,
	@numeroCliente	int	,
	@recibirNotificaciones	bit	,
	@empresaId	int	,
	@usuarioId	uniqueidentifier	,
	@fecha	datetime	,
	@estado	char(1)
AS
SET QUOTED_IDENTIFIER ON
BEGIN
	DECLARE @num int;
	set @num = 0;
	set @num = (SELECT isnull(MAX(cc.numeroCliente),0)+1 from [vip].[Cliente] cc);
	if(@empresaId = '0')
	BEGIN
		if(@ci = '')
		BEGIN
			INSERT INTO [vip].[Cliente](nombre, apellidos, direccion,telefono,celular,celular2,ci,correo,ocupacion,lugarTrabajo,telefonoTrabajo,correoTrabajo,fechaNacimiento,genero,estadoCivil,tieneHijos,numeroHijos,fechaIngreso,numeroCliente,recibirNotificaciones,empresaId,usuarioId,fecha,estado) 
			VALUES (@nombre, @apellidos, @direccion,@telefono,@celular,@celular2,NULL,@correo,@ocupacion,@lugarTrabajo,@telefonoTrabajo,@correoTrabajo,@fechaNacimiento,@genero,@estadoCivil,@tieneHijos,@numeroHijos,@fechaIngreso,@num,@recibirNotificaciones,NULL,@usuarioId,@fecha,@estado) 
			SET @Id = SCOPE_IDENTITY() 
		END
		ELSE
		BEGIN
			INSERT INTO [vip].[Cliente](nombre, apellidos, direccion,telefono,celular,celular2,ci,correo,ocupacion,lugarTrabajo,telefonoTrabajo,correoTrabajo,fechaNacimiento,genero,estadoCivil,tieneHijos,numeroHijos,fechaIngreso,numeroCliente,recibirNotificaciones,empresaId,usuarioId,fecha,estado) 
			VALUES (@nombre, @apellidos, @direccion,@telefono,@celular,@celular2,@ci,@correo,@ocupacion,@lugarTrabajo,@telefonoTrabajo,@correoTrabajo,@fechaNacimiento,@genero,@estadoCivil,@tieneHijos,@numeroHijos,@fechaIngreso,@num,@recibirNotificaciones,NULL,@usuarioId,@fecha,@estado) 
			SET @Id = SCOPE_IDENTITY() 
		END
	END
	ELSE
	BEGIN
		if(@ci = '')
		BEGIN
			INSERT INTO [vip].[Cliente](nombre, apellidos, direccion,telefono,celular,celular2,ci,correo,ocupacion,lugarTrabajo,telefonoTrabajo,correoTrabajo,fechaNacimiento,genero,estadoCivil,tieneHijos,numeroHijos,fechaIngreso,numeroCliente,recibirNotificaciones,empresaId,usuarioId,fecha,estado) 
			VALUES (@nombre, @apellidos, @direccion,@telefono,@celular,@celular2,NULL,@correo,@ocupacion,@lugarTrabajo,@telefonoTrabajo,@correoTrabajo,@fechaNacimiento,@genero,@estadoCivil,@tieneHijos,@numeroHijos,@fechaIngreso,@num,@recibirNotificaciones,@empresaId,@usuarioId,@fecha,@estado) 
			SET @Id = SCOPE_IDENTITY() 
		END
		ELSE
		BEGIN
			INSERT INTO [vip].[Cliente](nombre, apellidos, direccion,telefono,celular,celular2,ci,correo,ocupacion,lugarTrabajo,telefonoTrabajo,correoTrabajo,fechaNacimiento,genero,estadoCivil,tieneHijos,numeroHijos,fechaIngreso,numeroCliente,recibirNotificaciones,empresaId,usuarioId,fecha,estado) 
			VALUES (@nombre, @apellidos, @direccion,@telefono,@celular,@celular2,@ci,@correo,@ocupacion,@lugarTrabajo,@telefonoTrabajo,@correoTrabajo,@fechaNacimiento,@genero,@estadoCivil,@tieneHijos,@numeroHijos,@fechaIngreso,@num,@recibirNotificaciones,@empresaId,@usuarioId,@fecha,@estado) 
			SET @Id = SCOPE_IDENTITY() 
		END
	END
END
SET QUOTED_IDENTIFIER OFF
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_Actualizar]
END
GO

CREATE PROCEDURE [vip].[Cliente_Actualizar]
	@id				int,
	@nombre	varchar(50),
	@apellidos	varchar(100),
	@direccion	varchar(250)	,
	@telefono	varchar(10)	,
	@celular	varchar(10),
	@celular2	varchar(10),
	@ci	varchar(15)	,
	@correo	varchar(150)	,
	@ocupacion	varchar(150)	,
	@lugarTrabajo	varchar(250)	,
	@telefonoTrabajo	varchar(10)	,
	@correoTrabajo	varchar(150)	,
	@fechaNacimiento	datetime = null	,
	@genero	char(1)	,
	@estadoCivil	char(1)	,
	@tieneHijos	bit	,
	@numeroHijos	int	,
	@fechaIngreso	datetime	,
	@numeroCliente	int	,
	@recibirNotificaciones	bit	,
	@empresaId	int	,
	@usuarioId	uniqueidentifier	,
	@fecha	datetime	,
	@estado	char(1)
AS
BEGIN
	if(@empresaId = '0')
	BEGIN
	IF(@ci = '')
	BEGIN
	UPDATE [vip].[Cliente]
	SET nombre = @nombre,
	apellidos = @apellidos,
	direccion = @direccion,
	telefono = @telefono,
	celular = @celular,
	celular2 = @celular2,
	ci = NULL,
	correo = @correo,
	ocupacion = @ocupacion,
	lugarTrabajo = @lugarTrabajo,
	telefonoTrabajo = @telefonoTrabajo,
	correoTrabajo = @correoTrabajo,
	fechaNacimiento = @fechaNacimiento,
	genero = @genero,
	estadoCivil = @estadoCivil,
	tieneHijos = @tieneHijos,
	numeroHijos = @numeroHijos,
	fechaIngreso = @fechaIngreso,
	numeroCliente = @numeroCliente,
	recibirNotificaciones = @recibirNotificaciones,
	empresaId = NULL,
	usuarioId = @usuarioId,
	fecha = @fecha,
	estado = @estado
	WHERE Id = @id
	END
	ELSE
	BEGIN
	UPDATE [vip].[Cliente]
	SET nombre = @nombre,
	apellidos = @apellidos,
	direccion = @direccion,
	telefono = @telefono,
	celular = @celular,
	celular2 = @celular2,
	ci = @ci,
	correo = @correo,
	ocupacion = @ocupacion,
	lugarTrabajo = @lugarTrabajo,
	telefonoTrabajo = @telefonoTrabajo,
	correoTrabajo = @correoTrabajo,
	fechaNacimiento = @fechaNacimiento,
	genero = @genero,
	estadoCivil = @estadoCivil,
	tieneHijos = @tieneHijos,
	numeroHijos = @numeroHijos,
	fechaIngreso = @fechaIngreso,
	numeroCliente = @numeroCliente,
	recibirNotificaciones = @recibirNotificaciones,
	empresaId = NULL,
	usuarioId = @usuarioId,
	fecha = @fecha,
	estado = @estado
	WHERE Id = @id
	END
	END
	else
	BEGIN
	IF(@ci = '')
	BEGIN
	UPDATE [vip].[Cliente]
	SET nombre = @nombre,
	apellidos = @apellidos,
	direccion = @direccion,
	telefono = @telefono,
	celular = @celular,
	celular2 = @celular2,
	ci = NULL,
	correo = @correo,
	ocupacion = @ocupacion,
	lugarTrabajo = @lugarTrabajo,
	telefonoTrabajo = @telefonoTrabajo,
	correoTrabajo = @correoTrabajo,
	fechaNacimiento = @fechaNacimiento,
	genero = @genero,
	estadoCivil = @estadoCivil,
	tieneHijos = @tieneHijos,
	numeroHijos = @numeroHijos,
	fechaIngreso = @fechaIngreso,
	numeroCliente = @numeroCliente,
	recibirNotificaciones = @recibirNotificaciones,
	empresaId = @empresaId,
	usuarioId = @usuarioId,
	fecha = @fecha,
	estado = @estado
	WHERE Id = @id
	END
	ELSE
	BEGIN
	UPDATE [vip].[Cliente]
	SET nombre = @nombre,
	apellidos = @apellidos,
	direccion = @direccion,
	telefono = @telefono,
	celular = @celular,
	celular2 = @celular2,
	ci = @ci,
	correo = @correo,
	ocupacion = @ocupacion,
	lugarTrabajo = @lugarTrabajo,
	telefonoTrabajo = @telefonoTrabajo,
	correoTrabajo = @correoTrabajo,
	fechaNacimiento = @fechaNacimiento,
	genero = @genero,
	estadoCivil = @estadoCivil,
	tieneHijos = @tieneHijos,
	numeroHijos = @numeroHijos,
	fechaIngreso = @fechaIngreso,
	numeroCliente = @numeroCliente,
	recibirNotificaciones = @recibirNotificaciones,
	empresaId = @empresaId,
	usuarioId = @usuarioId,
	fecha = @fecha,
	estado = @estado
	WHERE Id = @id
	END
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_ValidarDatos]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_ValidarDatos] 
END
GO

CREATE PROCEDURE [vip].[Cliente_ValidarDatos] 
	@nombre			varchar(100) = '',
	@apellidos				varchar(150) = '',
	@ci					varchar(15) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT c.*,isnull((select isnull(e.nombre,'-') from [vip].[Empresa] e where e.id = c.empresaId),'-') empresa, c.nombre + ' ' + c.apellidos nombreCompleto 
		FROM [vip].[Cliente] c
		WHERE
		c.nombre like '%' + @nombre + '%'
		and c.ci like '%' + @ci + '%'
		and c.apellidos like '%' + @apellidos + '%'
		ORDER BY c.nombre asc 
		RETURN
	END
END
GO




SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Users_ObtenerUsuarioADM]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Users_ObtenerUsuarioADM] 
END
GO

CREATE PROCEDURE [vip].[Users_ObtenerUsuarioADM] 
	@UserId UNIQUEIDENTIFIER OUTPUT 
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT @UserId = UserId 
		FROM dbo.aspnet_Users 
		WHERE UserName = 'admin'
	END
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'PagoCliente' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[PagoCliente]
	ALTER COLUMN numeroFactura varchar(20)
END
GO



IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'PagoEmpresa' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[PagoEmpresa]
	ALTER COLUMN numeroFactura varchar(20)
END
GO




SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Intercambio_TraerTodos]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Intercambio_TraerTodos] 
END
GO

CREATE PROCEDURE [vip].[Intercambio_TraerTodos] 
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Intercambio] p
		ORDER BY p.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Intercambio_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Intercambio_TraerXId] 
END
GO

CREATE PROCEDURE [vip].[Intercambio_TraerXId] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Intercambio] p
		WHERE p.id = @id
		ORDER BY p.id asc 
		RETURN
	END
END
GO





IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_TiempoMeses]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_TiempoMeses]
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_TiempoMeses] 
	@clienteId				int
AS
BEGIN		

	declare @concaConceptos nvarchar(4000) 
	SET @concaConceptos = '';
	declare @Conceptos nvarchar(4000) 
	/*declare cursor_prueba cursor for
		
		select s.nombre +' '+ h.horaInicio+' '+h.horaFin 
		from [vip].[Inscripcion] i, [vip].[Grupo] g, [vip].[Horario] h, [vip].[Servicio] s,
		[vip].[ClientePaquete] c
		WHERE i.grupoId = g.id
		and g.horarioId= h.id
		and g.servicioId = s.id
		and i.clientePaqueteId = c.id
		and c.clienteid = @clienteId
		and c.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)

		open cursor_prueba


		fetch next from cursor_prueba 
		into @Conceptos


		while @@fetch_status = 0
		begin
		IF(@concaConceptos = '')
		BEGIN
			set @concaConceptos = @Conceptos
		END
		ELSE
		BEGIN
			set @concaConceptos = @concaConceptos +', '+ @Conceptos
		END
		fetch next from cursor_prueba
		into @Conceptos

		end 
		close cursor_prueba 
		deallocate cursor_prueba 
	*/
	/*begin
	SELECT @concaConceptos =  COALESCE(@concaConceptos+ ', ', '') + s.nombre +' '+ h.horaInicio+'-'+h.horaFin 
		from [vip].[Inscripcion] i, [vip].[Grupo] g, [vip].[Horario] h, [vip].[Servicio] s,
		[vip].[ClientePaquete] cc
		WHERE i.grupoId = g.id
		and g.horarioId= h.id
		and g.servicioId = s.id
		and i.clientePaqueteId = cc.id
		and cc.clienteid = @clienteId
		and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
	end*/
	SELECT C.id, 
	(SELECT CONVERT(VARCHAR(10), c.fechaRegistro,103)) fechaRegistro,
	(SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' then (select dateadd(day,-1,(select dateadd(month,p.tiempo,c.fechaRegistro))))  else (cast(c.fechaRegistro as datetime) +(case(p.unidadId)
			when '2' then p.tiempo * 7 when '3' then p.tiempo end)) end),103)) fechaFin,
	DATEDIFF(month, c.fechaRegistro,  (case(p.unidadId) when '1 ' then (select dateadd(day,-1,(select dateadd(month,p.tiempo,c.fechaRegistro))))  else (cast(c.fechaRegistro as datetime) +(case(p.unidadId)
			when '2' then p.tiempo * 7 when '3' then p.tiempo end)) end)) numeroMeses
	, p.nombre nombrePaquete 
	,(case when isnull(cl.empresaId,'0') = 0 then (CASE WHEN c.adicional = '-1' then ((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*p.precio)/(100)
	ELSE
	((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*p.precio)/(100) - (SELECT pp.precio FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp where cp.paqueteId = pp.id and cp.id = c.adicional)
	END
	)
	else
	(CASE WHEN c.adicional = '-1' then ((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*(select ep.costo from [vip].[EmpresaPaquete] ep where ep.paqueteId = p.id and ep.empresaId = cl.EmpresaId))/(100)
	ELSE
	((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*p.precio)/(100) - (SELECT ep.costo FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp, [vip].[EmpresaPaquete] ep where ep.EmpresaId = cl.EmpresaId and ep.paqueteId = pp.id and cp.paqueteId = pp.id and cp.id = c.adicional)
	END
	)
	end) precioPaquete,
	(case when isnull(cl.empresaId,0) = 0 then
	(CASE WHEN c.adicional = '-1' then ((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*p.precio)/(100)
	ELSE
	((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*p.precio)/(100) - (SELECT pp.precio FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp where cp.paqueteId = pp.id and cp.id = c.adicional)
	END
	)
	else
	(CASE WHEN c.adicional = '-1' then ((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*(select ep.costo from [vip].[EmpresaPaquete] ep where ep.paqueteId = p.id and ep.empresaId = cl.EmpresaId))/(100)
	ELSE
	((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*(select ep.costo from [vip].[EmpresaPaquete] ep where ep.paqueteId = p.id and ep.empresaId = cl.EmpresaId))/(100) - (SELECT ep.costo FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp, [vip].[EmpresaPaquete] ep where ep.empresaId = cl.empresaId and ep.paqueteId = pp.id and cp.paqueteId = pp.id and cp.id = c.adicional)
	END
	)
	end
	) - isnull((
	SELECT pro.montoDescuento FROM [vip].[Promocion] pro, [vip].[PromocionCliente] pr, [vip].[ClientePaquete] cc, [vip].[Paquete] pa
	WHERE cc.id = c.id
	and pro.id = pr.promocionId
	and pr.clientePaqueteId = cc.id
	and cc.paqueteId = pa.id
	and pa.unidadId = 1
	and pa.tiempo = 1
	),0) Total,
	
	isnull((
	SELECT pro.montoDescuento FROM [vip].[Promocion] pro, [vip].[PromocionCliente] pr, [vip].[ClientePaquete] cc, [vip].[Paquete] pa
	WHERE cc.id = c.id 
	and pro.id = pr.promocionId
	and pr.clientePaqueteId = cc.id
	and cc.paqueteId = pa.id
	and pa.unidadId = 1
	and pa.tiempo = 1
	),0) Descuento,
	/*@concaConceptos
	Concepto,*/
	(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
		from [vip].[Inscripcion] i, [vip].[Grupo] g, [vip].[Horario] h, [vip].[Servicio] s,
		[vip].[ClientePaquete] cc
		WHERE i.grupoId = g.id
		and g.horarioId= h.id
		and g.servicioId = s.id
		and i.clientePaqueteId = cc.id
		and cc.clienteid = @clienteId
		and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
		and cc.id = c.id 
		ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
		FOR XML PATH('') 
		) Concepto
	from [vip].[ClientePaquete] c, [vip].[Paquete] p,[vip].[Cliente] cl
	WHERE c.clienteId = @clienteId
	and c.clienteId = cl.id
	and c.paqueteId = p.id
	and c.estado = 'true'
	AND c.id not in (
	(select pc.clientePaqueteId 
	from [vip].[PagoCliente] pc 
	where pc.clientePaqueteId = c.id  and pc.estado = 'true' )
	)
	order by c.id ASC
	
end
GO





IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_TraerXIdPrecioReal]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_TraerXIdPrecioReal] 
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_TraerXIdPrecioReal] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	declare @precio decimal(18,2)
	set @precio = isnull((SELECT CASE WHEN P.adicional = -1 THEN 0 ELSE P.adicional END
		FROM [vip].[ClientePaquete] p,[vip].[Paquete] pa
		WHERE p.id = @id
		and pa.id = p.paqueteId),0)
		
	BEGIN
	IF(@precio=0)
	BEGIN
		SELECT isnull((((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = p.clienteId),100))*pa.precio)/(100)),0) Precio,
		isnull((((isnull((select d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = p.clienteId),100))*pa.precio)/(100)),0) PrecioEmpresa
		FROM [vip].[ClientePaquete] p,[vip].[Paquete] pa
		WHERE p.id = @id
		and pa.id = p.paqueteId
		ORDER BY p.id asc 
		RETURN
	END
	ELSE
	BEGIN
		SELECT (isnull((((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = p.clienteId),100))*pa.precio)/(100)),0)) - (SELECT isnull((((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = p.clienteId),100))*pa.precio)/(100)),0) Precio
		FROM [vip].[ClientePaquete] p,[vip].[Paquete] pa
		WHERE p.id = @precio
		and pa.id = p.paqueteId) Precio,
		isnull((((isnull((select d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = p.clienteId),100))*pa.precio)/(100)),0) PrecioEmpresa
		FROM [vip].[ClientePaquete] p,[vip].[Paquete] pa
		WHERE p.id = @id
		and pa.id = p.paqueteId

		RETURN 
	END
	END
END
GO



IF NOT EXISTS(select * from sys.columns where Name = N'nroRecibo' and Object_ID = Object_ID(N'[vip].[PagoCliente]'))
BEGIN
	ALTER TABLE [vip].[PagoCliente] 
	ADD nroRecibo int not null default 0	
END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_TraerMaximoRecibo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_TraerMaximoRecibo] 
END
GO

CREATE PROCEDURE [vip].[PagoCliente_TraerMaximoRecibo] 
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT isnull(MAX(p.nroRecibo),0)+1
		FROM [vip].[PagoCliente] p
		RETURN
	END
END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_Insertar]
END
GO

CREATE PROCEDURE [vip].[PagoCliente_Insertar]
	@id				int OUTPUT,
	@clientePaqueteId	int	,
	@concepto	varchar(250)	,
	@formaPago	char(2)	,
	@numeroFactura	int	,
	@digitosTarjeta_12	varchar(12)	,
	@numeroAprobacionPOS	varchar(20)	,
	@numeroCheque	varchar(20)	,
	@nombreBancoCheque	varchar(50)	,
	@numeroCuentaTransferencia	varchar(20)	,
	@nombreBancoTransferencia	varchar(50)	,
	@intercambioId	int	,
	@nroPago	int	,
	@fechaPeriodoInicio	datetime	,
	@fechaPeriodoFin	datetime	,
	@monto	decimal(8, 2)	,
	@fechaPago	datetime	,
	@estado	bit	,
	@usuarioId	uniqueidentifier	,
	@fecha	datetime,
	@ClienteId	int,
	@nroRecibo	int
AS
BEGIN
	declare @nroPagoUltimo	int;
	set @nroPagoUltimo = 0;
	set @nroPagoUltimo = (
	CASE WHEN (select TOP 1 cp.adicional 
	from [vip].[PagoCliente] cc, [vip].[ClientePaquete] cp 
	where cc.ClientePaqueteId = cp.id 
	and cp.clienteId = @ClienteId GROUP by cp.clienteId, cp.adicional) = -1
	THEN
	(SELECT isnull(MAX(cc.nroPago),0)+1
	from [vip].[PagoCliente] cc, [vip].[ClientePaquete] cp 
	where cc.ClientePaqueteId = cp.id 
	and cp.clienteId = @ClienteId GROUP by cp.clienteId)
	WHEN ISNULL((select cp.adicional 
	from [vip].[PagoCliente] cc, [vip].[ClientePaquete] cp 
	where cc.ClientePaqueteId = cp.id 
	and cp.clienteId = @ClienteId GROUP by cp.clienteId, cp.adicional),0) = 0
	THEN 1
	ELSE
	(SELECT isnull(MAX(cc.nroPago),0)+1
	from [vip].[PagoCliente] cc, [vip].[ClientePaquete] cp 
	where cc.ClientePaqueteId = cp.id 
	and cp.clienteId = @ClienteId GROUP by cp.clienteId)
	END
	);
	
	if(@numeroFactura='')
	BEGIN
		set @numeroFactura = NULL
	END
	if(@digitosTarjeta_12='')
	BEGIN
		set @digitosTarjeta_12 = NULL
	END
	if(@numeroAprobacionPOS='')
	BEGIN
		set @numeroAprobacionPOS = NULL
	END
	if(@numeroCheque='')
	BEGIN
		set @numeroCheque = NULL
	END
	if(@nombreBancoCheque='')
	BEGIN
		set @nombreBancoCheque = NULL
	END
	if(@numeroCuentaTransferencia='')
	BEGIN
		set @numeroCuentaTransferencia = NULL
	END
	if(@nombreBancoTransferencia='')
	BEGIN
		set @nombreBancoTransferencia = NULL
	END
	if(@intercambioId='0')
	BEGIN
		set @digitosTarjeta_12 = NULL
	END
	
	INSERT INTO [vip].[PagoCliente](clientePaqueteId, concepto, formaPago,numeroFactura,digitosTarjeta_12,numeroAprobacionPOS,numeroCheque,nombreBancoCheque,numeroCuentaTransferencia,intercambioId,nroPago,fechaPeriodoInicio,fechaPeriodoFin,monto,fechaPago,estado,usuarioId,fecha,nroRecibo) 
	VALUES (@clientePaqueteId, @concepto, @formaPago,@numeroFactura,@digitosTarjeta_12,@numeroAprobacionPOS,@numeroCheque,@nombreBancoCheque,@numeroCuentaTransferencia,@intercambioId,@nroPagoUltimo,@fechaPeriodoInicio,@fechaPeriodoFin,@monto,@fechaPago,@estado,@usuarioId,@fecha,@nroRecibo) 
	SET @Id = SCOPE_IDENTITY() 
END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_TraerRecibos]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_TraerRecibos] 
END
GO

CREATE PROCEDURE [vip].[PagoCliente_TraerRecibos] 
	@ClientePaqueteId	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		
		declare @nroRecibo int 
		declare @concaConceptos nvarchar(1000) 
		set @nroRecibo = (SELECT top 1 p.nroRecibo
		FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] c
		WHERE 
		p.clientePaqueteId = c.id
		and c.clienteId = @ClientePaqueteId
		GROUP BY p.nroRecibo,p.fechaPago)

		declare cursor_prueba cursor for
		select p.concepto from [vip].[PagoCliente] p where p.nroRecibo = @nroRecibo

		declare @conceptos nvarchar(1000)

		open cursor_prueba


		fetch next from cursor_prueba 
		into @conceptos


		while @@fetch_status = 1
		begin
		set @conceptos = @conceptos +', '+@conceptos
		fetch next from cursor_prueba
		into @conceptos

		end 

		close cursor_prueba 
		deallocate cursor_prueba 

		SELECT p.nroRecibo id, p.nroRecibo nroRecibo, sum(p.monto) monto, (SELECT CONVERT(VARCHAR(10), p.fechaPago,103)) fechaPagoSinHora,
		/*@conceptos concepto*/
		(select pP.concepto + '' from [vip].[PagoCliente] pP where pP.nroRecibo = p.nroRecibo 
		ORDER BY LEN(pP.concepto)
		FOR XML PATH('')) concepto
		FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] c
		WHERE 
		p.clientePaqueteId = c.id
		and c.clienteId = @ClientePaqueteId
		GROUP BY p.nroRecibo, p.fechaPago
		RETURN
	END
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_TraerXIdPaqueteRecibo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_TraerXIdPaqueteRecibo] 
END
GO

CREATE PROCEDURE [vip].[PagoCliente_TraerXIdPaqueteRecibo] 
	@id	decimal(8,2),
	@ClientePaqueteId	int
AS
BEGIN		
	SET NOCOUNT ON;

	BEGIN
		set @id = null
		declare @concaConceptos nvarchar(1000) 
		declare cursor_prueba cursor for
		select p.concepto from [vip].[PagoCliente] p where p.nroRecibo = @ClientePaqueteId

		declare @conceptos nvarchar(1000)

		open cursor_prueba


		fetch next from cursor_prueba 
		into @conceptos


		while @@fetch_status = 1
		begin
		set @conceptos = @conceptos +', '+@conceptos
		fetch next from cursor_prueba
		into @conceptos

		end 

		close cursor_prueba 
		deallocate cursor_prueba 

		
		select @id = m.tipoCambio from [vip].[MovimientoCaja] m WHERE M.fecha IN (SELECT MAX(mc.fecha) FROM [vip].[MovimientoCaja] mc GROUP BY mc.fecha);
		set @id = ISNULL(@id,6.86)
 		SELECT p.nroRecibo, cl.nombre + ' ' + cl.apellidos nombreCompleto, ([vip].[CantidadConLetra](sum(p.monto))) MontoLiteral,
		(select convert(decimal(12,2),sum(p.monto))) Total,
		(select convert(decimal(12,2),sum(p.monto))) Cancelado,
		(select convert(decimal(12,2),(sum(p.monto))/@id)) montoTipoCambio,
		@id tipoCambio,
		(SELECT SUBSTRING(CONVERT(VARCHAR(8), p.fechaPago, 5), 0, 3)) DiaPago,
		(SELECT SUBSTRING(CONVERT(VARCHAR(8), p.fechaPago, 5), 4, 2)) MesPago,
		(SELECT SUBSTRING(CONVERT(VARCHAR(10), p.fechaPago, 105), 7, 10)) AnoPago,
		(select p.concepto + '' from [vip].[PagoCliente] p where p.nroRecibo = @ClientePaqueteId
		ORDER BY LEN(p.concepto)
		FOR XML PATH('') 
		) concepto
		FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] c, [vip].[Cliente] cl, [vip].[Paquete] pa
		WHERE 
		c.clienteId = cl.id
		and pa.id = c.paqueteId
		and p.clientePaqueteId = c.id
		and p.nroRecibo = @ClientePaqueteId
		group by p.nroRecibo,cl.nombre, cl.apellidos, p.fechaPago, p.monto
		RETURN
	END
END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Grupo_TraerHorario]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Grupo_TraerHorario] 
END
GO

CREATE PROCEDURE [vip].[Grupo_TraerHorario] 
	@grupoId	int,
	@clientePaqueteId	int,
	@fecha				datetime
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT g.id, ss.nombre nombreSala, h.horaInicio + '-' + h.horaFin Hora, se.nombre nombreServicio
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 1 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoLunes
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 2 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoMartes
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 3 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoMiercoles
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 4 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoJueves
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 5 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoViernes
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 6 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoSabado
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 7 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoDomingo
		, (case (isnull(se.cupo,0)) when 0 then '-' else se.cupo - (select count(*) from [vip].[Inscripcion] i, [vip].[ClientePaquete] cp where i.clientePaqueteId = cp.id and i.grupoId = g.id and i.estado = 'true' and datepart(MM,cp.fechaRegistro) = datepart(MM,@fecha) and datepart(YYYY,cp.fechaRegistro) = datepart(YYYY,@fecha)) end) cupo
		FROM [vip].[Horario] h, [vip].[Sala] ss, [vip].[Grupo] g, [vip].[Servicio] se
		WHERE se.id = @grupoId
		and g.servicioId = se.id
		and g.horarioId = h.id
		and h.salaId = ss.id
		and h.id not in (select hh.id 
		from [vip].[Horario] hh, [vip].[Grupo] gg, [vip].[Inscripcion] i
		where hh.id = gg.horarioId
		and i.grupoId = gg.id
		and gg.id = @grupoId
		--and i.clientePaqueteId = @clientePaqueteId
		)
		ORDER BY h.id, ss.nombre asc 
		RETURN
	END
END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Grupo_TraerHorarioIn]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Grupo_TraerHorarioIn] 
END
GO

CREATE PROCEDURE [vip].[Grupo_TraerHorarioIn] 
	@grupoId	int,
	@clientePaqueteId	int,
	@fecha				datetime
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT g.id, ss.nombre nombreSala, h.horaInicio + '-' + h.horaFin Hora, se.nombre nombreServicio
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 1 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoLunes
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 2 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoMartes
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 3 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoMiercoles
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 4 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoJueves
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 5 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoViernes
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 6 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoSabado
		,case (isnull((select count(gd.id) from [vip].[GrupoDia] gd, [vip].[Grupo] g, [vip].[Servicio] s where g.horarioId = h.id and  gd.diaId = 7 and g.servicioId = s.id and gd.grupoId = g.id), '0')) when 0 then 'False' else 'true' end grupoDomingo
		, (case (isnull(se.cupo,0)) when 0 then '-' else se.cupo - (select count(*) from [vip].[Inscripcion] i, [vip].[ClientePaquete] cp where i.clientePaqueteId = cp.id and i.grupoId = g.id and i.estado = 'true' and datepart(MM,cp.fechaRegistro) = datepart(MM,@fecha) and datepart(YYYY,cp.fechaRegistro) = datepart(YYYY,@fecha)) end) cupo
		FROM [vip].[Horario] h, [vip].[Sala] ss, [vip].[Grupo] g, [vip].[Servicio] se
		WHERE se.id = @grupoId
		and g.servicioId = se.id
		and g.horarioId = h.id
		and h.salaId = ss.id
		ORDER BY h.id, ss.nombre asc 
		RETURN
	END
END
GO

IF NOT EXISTS(select * from sys.columns where Name = N'mensual' and Object_ID = Object_ID(N'[vip].[Promocion]'))
BEGIN
	ALTER TABLE [vip].[Promocion] 
	ADD mensual bit not null default 'false'
END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Promocion_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Promocion_Insertar]
END
GO

CREATE PROCEDURE [vip].[Promocion_Insertar]
	@id				int OUTPUT,
	@fechaInicio	datetime,
	@fechaFin	datetime,
	@montoDescuento	decimal(8, 2),
	@usuarioId	uniqueidentifier,
	@fecha		datetime,
	@estado	bit,
	@nombre		varchar(100),
	@mensual		bit
AS
BEGIN

	INSERT INTO [vip].[Promocion](fechaInicio, fechaFin,montoDescuento,usuarioId,fecha,estado,nombre,mensual) 
	VALUES (@fechaInicio, @fechaFin, @montoDescuento,@usuarioId, @fecha,@estado,@nombre,@mensual) 
	SET @Id = SCOPE_IDENTITY() 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Promocion_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Promocion_Actualizar]
END
GO

CREATE PROCEDURE [vip].[Promocion_Actualizar]
	@id				int,
	@fechaInicio	datetime,
	@fechaFin	datetime,
	@montoDescuento	decimal(8, 2),
	@usuarioId	uniqueidentifier,
	@fecha		datetime,
	@estado	bit,
	@nombre		varchar(100),
	@mensual		bit
AS
BEGIN
	UPDATE [vip].[Promocion]
	SET fechaInicio = @fechaInicio,
	fechaFin = @fechaFin,
	montoDescuento = @montoDescuento,
	usuarioId = @usuarioId,
	fecha = @fecha,
	estado = @estado,
	nombre = @nombre,
	mensual = @mensual
	WHERE Id = @id	
END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PromocionCliente_TraerXIdClientePaquete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PromocionCliente_TraerXIdClientePaquete]
END
GO

CREATE PROCEDURE [vip].[PromocionCliente_TraerXIdClientePaquete]
	@Id					int 
AS
BEGIN
    SELECT p.* FROM [vip].[PromocionCliente] p, [vip].[ClientePaquete] c,
    [vip].[Promocion] pro
	WHERE c.clienteId = @Id 
	and p.clientePaqueteId = c.id
	and p.promocionId = pro.id
	and p.estado = 'true'
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PromocionCliente_TraerXIdPaqueteCliente]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PromocionCliente_TraerXIdPaqueteCliente]
END
GO

CREATE PROCEDURE [vip].[PromocionCliente_TraerXIdPaqueteCliente]
	@Id					int 
AS
BEGIN
    SELECT p.* FROM [vip].[PromocionCliente] p,
    [vip].[Promocion] pro
	WHERE p.clientePaqueteId = @Id 
	and pro.id = p.promocionId
	and p.estado = 'true'
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PromocionCliente_TraerXIdClientePaqueteMensual]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PromocionCliente_TraerXIdClientePaqueteMensual]
END
GO

CREATE PROCEDURE [vip].[PromocionCliente_TraerXIdClientePaqueteMensual]
	@Id					int 
AS
BEGIN
    SELECT p.* FROM [vip].[PromocionCliente] p, [vip].[ClientePaquete] c,
    [vip].[Promocion] pro
	WHERE c.clienteId = @Id 
	and p.clientePaqueteId = c.id
	and p.promocionId = pro.id
	and p.estado = 'true'
	and datepart(MM, p.fechaAsignacion) = datepart(MM, GETDATE())
	and datepart(YYYY, p.fechaAsignacion) = datepart(YYYY, GETDATE())
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PromocionCliente_TraerXIdClientePaqueteValidando]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PromocionCliente_TraerXIdClientePaqueteValidando]
END
GO

CREATE PROCEDURE [vip].[PromocionCliente_TraerXIdClientePaqueteValidando]
	@Id					int 
AS
BEGIN
    SELECT p.* FROM [vip].[PromocionCliente] p, [vip].[ClientePaquete] c, [vip].[Paquete] pa
	WHERE c.clienteId = @Id 
	and p.clientePaqueteId = c.id
	and c.paqueteId = pa.id
	and pa.unidadId = 1
	and pa.tiempo = 1
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[EmpresaPaquete_TraerXEmpresaId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[EmpresaPaquete_TraerXEmpresaId] 
END
GO

CREATE PROCEDURE [vip].[EmpresaPaquete_TraerXEmpresaId] 
	@id	nvarchar(15)
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		IF(@id='0')
		BEGIN
		SELECT P.id, P.nombre,p.precio
		costo
		FROM [vip].[Paquete] p
		ORDER BY p.ID asc 
		END
		ELSE
		BEGIN
		declare cursor_prueba cursor for
		SELECT P.id, P.nombre,isnull((select ep.costo from [vip].[EmpresaPaquete] ep 
		WHERE ep.paqueteId = p.id and ep.empresaId = @id),p.precio)
		costo
		FROM [vip].[Paquete] p
		ORDER BY p.ID asc 
		
		declare @idpaquete int,
		@nombre varchar(200),
		@costo decimal(18,2),
		@conteo int
		open cursor_prueba
		fetch next from cursor_prueba 
		into @idpaquete, @nombre, @costo
		while @@fetch_status = 0
		begin
		set @conteo = (select count(ep.empresaId) from [vip].[EmpresaPaquete] ep WHERE ep.paqueteId = @idpaquete and ep.empresaId = @id)
		if(@conteo=0)
		BEGIN
		insert into [vip].[EmpresaPaquete](empresaId,paqueteId,costo)VALUES(@id,@idpaquete,@costo)
		END
		ELSE
		BEGIN
		print convert(varchar(10),@idpaquete) +' '+  @nombre +' '+ convert(varchar(10),@costo)
		END
		fetch next from cursor_prueba
		into @idpaquete, @nombre, @costo
		end 
		close cursor_prueba 
		deallocate cursor_prueba
		
		SELECT P.id, P.nombre,isnull((select ep.costo from [vip].[EmpresaPaquete] ep 
		WHERE ep.paqueteId = p.id and ep.empresaId = @id),p.precio)
		costo
		FROM [vip].[Paquete] p
		
		
		RETURN
		END
	END
END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[EmpresaPaquete_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[EmpresaPaquete_Actualizar]
END
GO

CREATE PROCEDURE [vip].[EmpresaPaquete_Actualizar]
	@empresaId	int,
	@paqueteId	datetime,
	@costo	decimal(8, 2)
AS
BEGIN
	UPDATE [vip].[EmpresaPaquete]
	SET 
	costo = @costo
	WHERE empresaId = @empresaId
	and
	paqueteId = @paqueteId
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[EmpresaPaquete_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[EmpresaPaquete_Insertar]
END
GO

CREATE PROCEDURE [vip].[EmpresaPaquete_Insertar]
	@empresaId				int,
	@paqueteId	int,
	@costo	decimal(18,2)
AS
BEGIN

	INSERT INTO [vip].[EmpresaPaquete](empresaId, paqueteId,costo) 
	VALUES (@empresaId, @paqueteId,@costo) 
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_TraerXIdPrecioReal]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_TraerXIdPrecioReal] 
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_TraerXIdPrecioReal] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT isnull((((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = p.clienteId),100))*
		(
		case when isnull((
		SELECT ep.costo 
		FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp, [vip].[EmpresaPaquete] ep
		where cp.paqueteId = pp.id
		and ep.paqueteId = cp.paqueteId
		and cp.id = p.id
		and ep.empresaId = (select top 1 cl.empresaId from [vip].[Cliente] cl where cl.id = p.clienteId)
		),0)=0 then pa.precio 
		ELSE
		(SELECT ep.costo 
		FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp, [vip].[EmpresaPaquete] ep
		where cp.paqueteId = pp.id 
		and ep.paqueteId = cp.paqueteId
		and cp.id = p.id
		and ep.empresaId = (select top 1 cl.empresaId from [vip].[Cliente] cl where cl.id = p.clienteId))
		END
		)
		)/(100)),0) Precio,
		isnull((((isnull((select d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = p.clienteId),100))*(
		case when isnull((
		SELECT ep.costo 
		FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp, [vip].[EmpresaPaquete] ep
		where cp.paqueteId = pp.id
		and ep.paqueteId = cp.paqueteId
		and cp.id = p.id
		and ep.empresaId = (select top 1 cl.empresaId from [vip].[Cliente] cl where cl.id = p.clienteId)
		),0)=0 then pa.precio 
		ELSE
		(SELECT ep.costo 
		FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp, [vip].[EmpresaPaquete] ep
		where cp.paqueteId = pp.id 
		and ep.paqueteId = cp.paqueteId
		and cp.id = p.id
		and ep.empresaId = (select top 1 cl.empresaId from [vip].[Cliente] cl where cl.id = p.clienteId))
		END
		))/(100)),0) PrecioEmpresa
		FROM [vip].[ClientePaquete] p,[vip].[Paquete] pa
		WHERE p.id = @id
		and pa.id = p.paqueteId
		ORDER BY p.id asc 
		RETURN
	END
END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_TraerXIdPrecioRealPaquete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_TraerXIdPrecioRealPaquete] 
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_TraerXIdPrecioRealPaquete] 
	@id	int,
	@paquete int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT isnull((((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = @id),100))*
		(
		case when isnull((
		SELECT ep.costo 
		FROM [vip].[Paquete] pp, [vip].[EmpresaPaquete] ep
		where 
		pp.id = ep.paqueteId
		and pp.id = pa.id
		and ep.empresaId = (select top 1 cl.empresaId from [vip].[Cliente] cl where cl.id = @id) 
		),0)=0 then pa.precio 
		ELSE
		(SELECT ep.costo 
		FROM [vip].[Paquete] pp, [vip].[EmpresaPaquete] ep
		where 
		pp.id = ep.paqueteId
		and pp.id = pa.id
		and ep.empresaId = (select top 1 cl.empresaId from [vip].[Cliente] cl where cl.id = @id))
		END
		)
		)/(100)),0) Precio,
		isnull((((isnull((select d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = @id),100))*
		(
		case when isnull((
		SELECT ep.costo 
		FROM [vip].[Paquete] pp, [vip].[EmpresaPaquete] ep
		where 
		pp.id = ep.paqueteId
		and pp.id = pa.id
		and ep.empresaId = (select top 1 cl.empresaId from [vip].[Cliente] cl where cl.id = @id) 
		),0)=0 then pa.precio 
		ELSE
		(SELECT ep.costo 
		FROM [vip].[Paquete] pp, [vip].[EmpresaPaquete] ep
		where 
		pp.id = ep.paqueteId
		and pp.id = pa.id
		and ep.empresaId = (select top 1 cl.empresaId from [vip].[Cliente] cl where cl.id = @id))
		END
		)
		)/(100)),0) PrecioEmpresa
		FROM [vip].[Paquete] pa
		WHERE 
		pa.id = @paquete
		ORDER BY pa.id asc 
		RETURN
	END
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_TiempoMesesEmpresa]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_TiempoMesesEmpresa]
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_TiempoMesesEmpresa] 
	@clienteId				int,
	@Mes					int,
	@Ano					int
AS
BEGIN		

	SELECT C.id, 
	(SELECT CONVERT(VARCHAR(10), c.fechaRegistro,103)) fechaRegistro,
	(SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' then (select dateadd(day,-1,(select dateadd(month,p.tiempo,c.fechaRegistro))))  else (cast(c.fechaRegistro as datetime) +(case(p.unidadId)
			when '2' then p.tiempo * 7 when '3' then p.tiempo end)) end),103)) fechaFin,
	DATEDIFF(month, c.fechaRegistro,  (case(p.unidadId) when '1 ' then (select dateadd(day,-1,(select dateadd(month,p.tiempo,c.fechaRegistro))))  else (cast(c.fechaRegistro as datetime) +(case(p.unidadId)
			when '2' then p.tiempo * 7 when '3' then p.tiempo end)) end)) numeroMeses
	, p.nombre nombrePaquete 
	,(CASE WHEN c.adicional = '-1' then ((isnull((select d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*
	(
		case when isnull((
		SELECT ep.costo 
		FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp, [vip].[EmpresaPaquete] ep
		where cp.paqueteId = pp.id
		and ep.paqueteId = cp.paqueteId
		and cp.paqueteId = p.id
		and cp.id = c.id
		and ep.empresaId = (select top 1 cl.empresaId from [vip].[Cliente] cl where cl.id = c.clienteId)
		),0)=0 then p.precio 
		ELSE
		(SELECT ep.costo 
		FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp, [vip].[EmpresaPaquete] ep
		where cp.paqueteId = pp.id 
		and ep.paqueteId = cp.paqueteId
		and cp.paqueteId = p.id
		and cp.id = c.id
		and ep.empresaId = (select top 1 cl.empresaId from [vip].[Cliente] cl where cl.id = c.clienteId))
		END
		)
	)/(100)
	ELSE
	((isnull((select d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*
	(
		case when isnull((
		SELECT ep.costo 
		FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp, [vip].[EmpresaPaquete] ep
		where cp.paqueteId = pp.id
		and ep.paqueteId = cp.paqueteId
		and cp.paqueteId = p.id
		and cp.id = c.id
		and ep.empresaId = (select top 1 cl.empresaId from [vip].[Cliente] cl where cl.id = c.clienteId)
		),0)=0 then p.precio 
		ELSE
		(SELECT ep.costo 
		FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp, [vip].[EmpresaPaquete] ep
		where cp.paqueteId = pp.id 
		and ep.paqueteId = cp.paqueteId
		and cp.paqueteId = p.id
		and cp.id = c.id
		and ep.empresaId = (select top 1 cl.empresaId from [vip].[Cliente] cl where cl.id = c.clienteId))
		END
		)
	)/(100) 
	END
	) precioPaquete,
	cl.nombre + ' ' + cl.apellidos nombreCliente
	from [vip].[ClientePaquete] c, [vip].[Paquete] p, [vip].[Empresa] e, [vip].[Cliente] cl
	WHERE e.id = @clienteId 
	and cl.id = c.clienteId
	and cl.empresaId = e.id
	and c.paqueteId = p.id
	and c.estado = 'true'
	AND c.id not in (
	(select pc.clientePaqueteId 
	from [vip].[PagoEmpresa] pc 
	where pc.clientePaqueteId = c.id  and pc.estado = 'true' )
	)
	and (SELECT SUBSTRING(CONVERT(VARCHAR(8), c.fechaRegistro, 5), 4, 2)) = @Mes
	and (SELECT SUBSTRING(CONVERT(VARCHAR(10), c.fechaRegistro, 105), 7, 10)) = @Ano
	order by c.fechaRegistro ASC
end
GO


/*
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_TiempoMeses]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_TiempoMeses]
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_TiempoMeses] 
	@clienteId				int
AS
BEGIN		

	SELECT C.id, 
	(SELECT CONVERT(VARCHAR(10), c.fechaRegistro,103)) fechaRegistro,
	(SELECT CONVERT(VARCHAR(10),(cast(c.fechaRegistro as datetime) +(case(p.unidadId)
	when '1' then p.tiempo * 30 when '2' then p.tiempo * 7 when '3' then p.tiempo end)),103)) fechaFin,
	DATEDIFF(month, c.fechaRegistro,  (cast(c.fechaRegistro as datetime) +(case(p.unidadId)
	when '1' then p.tiempo * 30 when '2' then p.tiempo * 7 when '3' then p.tiempo end))) numeroMeses
	, p.nombre nombrePaquete 
	,(CASE WHEN c.adicional = '-1' then ((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*p.precio)/(100)
	ELSE
	((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*p.precio)/(100) - (SELECT pp.precio FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp where cp.paqueteId = pp.id and cp.id = c.adicional)
	END
	) precioPaquete,
	(select s.nombre +' '+ h.horaInicio+' '+h.horaFin 
	from [vip].[Inscripcion] i, [vip].[Grupo] g, [vip].[Horario] h, [vip].[Servicio] s
	WHERE i.grupoId = g.id
	and g.horarioId= h.id
	and g.servicioId = s.id
	and i.clientePaqueteId = c.id
	)
	Concepto,
	isnull((
	SELECT pro.montoDescuento FROM [vip].[Promocion] pro, [vip].[PromocionCliente] pr, [vip].[ClientePaquete] cc, [vip].[Paquete] pa
	WHERE cc.id = c.id 
	and pro.id = pr.promocionId
	and pr.clientePaqueteId = cc.id
	and cc.paqueteId = pa.id
	and pa.unidadId = 1
	and pa.tiempo = 1
	),0) Descuento
	,
	
	(CASE WHEN c.adicional = '-1' then ((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*(case when isnull((select case ep.costo when 0 then p.precio else ep.costo end  from [vip].[EmpresaPaquete] ep where ep.empresaId = cl.empresaId and ep.paqueteId = p.id),0)= 0 
	then p.precio 
	else (select ep.costo from [vip].[EmpresaPaquete] ep where ep.empresaId = cl.empresaId and ep.paqueteId = p.id) 
	end))/(100)
	ELSE
	((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*(case when isnull((select case ep.costo when 0 then p.precio else ep.costo end  from [vip].[EmpresaPaquete] ep where ep.empresaId = cl.empresaId and ep.paqueteId = p.id),0)= 0 
	then p.precio 
	else (select ep.costo from [vip].[EmpresaPaquete] ep where ep.empresaId = cl.empresaId and ep.paqueteId = p.id) 
	end))/(100) - (
	case when isnull((
	SELECT ep.costo 
	FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp, [vip].[EmpresaPaquete] ep
	where cp.paqueteId = pp.id and cp.id = c.adicional
	and ep.paqueteId = cp.paqueteId
	and ep.empresaId = cl.empresaId
	),0)=0 then p.precio 
	ELSE
	(SELECT ep.costo 
	FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp, [vip].[EmpresaPaquete] ep
	where cp.paqueteId = pp.id and cp.id = c.adicional
	and ep.paqueteId = cp.paqueteId
	and ep.empresaId = cl.empresaId)
	END
	)
	END
	) - isnull((
	SELECT pro.montoDescuento FROM [vip].[Promocion] pro, [vip].[PromocionCliente] pr, [vip].[ClientePaquete] cc, [vip].[Paquete] pa
	WHERE cc.id = c.id
	and pro.id = pr.promocionId
	and pr.clientePaqueteId = cc.id
	and cc.paqueteId = pa.id
	and pa.unidadId = 1
	and pa.tiempo = 1
	),0) Total
	from [vip].[ClientePaquete] c, [vip].[Paquete] p, [vip].[Cliente] cl
	WHERE c.clienteId = @clienteId
	and c.clienteId = cl.id
	and c.paqueteId = p.id
	and c.estado = 'true'
	AND c.id not in (
	(select pc.clientePaqueteId 
	from [vip].[PagoCliente] pc 
	where pc.clientePaqueteId = c.id  and pc.estado = 'true' )
	)
	order by c.id ASC
	
end
GO
*/


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoEmpresa_TraerXIdClientePaquete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoEmpresa_TraerXIdClientePaquete] 
END
GO

CREATE PROCEDURE [vip].[PagoEmpresa_TraerXIdClientePaquete] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[PagoEmpresa] p
		WHERE p.clientePaqueteId = @id
		ORDER BY p.id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoEmpresa_TraerXIdEmpresa]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoEmpresa_TraerXIdEmpresa] 
END
GO

CREATE PROCEDURE [vip].[PagoEmpresa_TraerXIdEmpresa] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[PagoEmpresa] p
		WHERE p.empresaId = @id
		ORDER BY p.id asc 
		RETURN
	END
END
GO

/*IF NOT EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'fk_Empresa_EmpresaPaquete' AND xtype='C')
BEGIN
	ALTER TABLE [vip].[EmpresaPaquete] 
	ADD CONSTRAINT 	fk_Empresa_EmpresaPaquete FOREIGN KEY (empresaId) REFERENCES [vip].[Empresa](id) ON DELETE CASCADE
END
GO
*/

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'EmpresaPaquete' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[EmpresaPaquete] DROP CONSTRAINT fk_EmpresaPaquete_Empresa
	ALTER TABLE [vip].[EmpresaPaquete] ADD CONSTRAINT fk_EmpresaPaquete_Empresa FOREIGN KEY (empresaId) REFERENCES [VIP].[Empresa](id) ON DELETE CASCADE
END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_DarLicencia]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_DarLicencia]
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_DarLicencia]
	@id					int,
	@fechaInicioLicencia	DATETIME,
	@fechaFinLicencia		DATETIME
AS
BEGIN
	DECLARE @FechaPaquete DATETIME
	
	DECLARE db_cursor CURSOR FOR  
	(SELECT id, fechaRegistro
	FROM [vip].[ClientePaquete]
	WHERE id = @id
	union
	SELECT id, fechaRegistro
	FROM [vip].[ClientePaquete]
	WHERE adicional = @id
	)
	
	OPEN db_cursor   
	FETCH NEXT FROM db_cursor INTO @id, @FechaPaquete

	WHILE @@FETCH_STATUS = 0   
	BEGIN   
		/*UPDATE [vip].[ClientePaquete]
		SET fechaRegistro = (SELECT DATEADD(day, DATEDIFF(day,@fechaInicioLicencia,@fechaFinLicencia), @FechaPaquete))
		WHERE id = @id
		*/
	FETCH NEXT FROM db_cursor INTO @id, @FechaPaquete   
	END   

	CLOSE db_cursor   
	DEALLOCATE db_cursor
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Licencia_TraerXClientePaqueteId2]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Licencia_TraerXClientePaqueteId2]
END
GO

CREATE PROCEDURE [vip].[Licencia_TraerXClientePaqueteId2]
	@Id					int 
AS
BEGIN
    SELECT *
    from [vip].[Licencia] l
	WHERE l.clientePaqueteId = @Id 
END
GO

	

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[DiferenciaFechaLicencia]'))
BEGIN
	DROP FUNCTION [vip].[DiferenciaFechaLicencia]
END
GO

CREATE FUNCTION [vip].[DiferenciaFechaLicencia]
(
    @Numero             int
)
RETURNS int
AS
BEGIN
	DECLARE @cantidad int
	DECLARE @cantidadfinal int
	DECLARE @inicio DATETIME
	DECLARE @fin DATETIME
	set @cantidadfinal = 0
	DECLARE db_cursor CURSOR FOR  
	(
    select (DATEDIFF(DAY, l.fechaInicioLicencia, l.fechaFinLicencia))
    from [vip].[Licencia] l
	WHERE l.clientePaqueteId = @Numero 
    )
    OPEN db_cursor   
	FETCH NEXT FROM db_cursor INTO @cantidad

	WHILE @@FETCH_STATUS = 0   
	BEGIN   
		set @cantidadfinal = @cantidadfinal + @cantidad
	FETCH NEXT FROM db_cursor INTO @cantidad   
	END   

	CLOSE db_cursor   
	DEALLOCATE db_cursor    
   RETURN @cantidadfinal
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_TraerHistorial]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_TraerHistorial] 
END
GO

CREATE PROCEDURE [vip].[ClientePaquete_TraerHistorial] 
	@clienteId			int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
	
		SELECT c.id, p.nombre, c.fechaRegistro, c.estado, p.precio, isnull((select top 1 cc.id  from [vip].[ClientePaquete] cc where cc.adicional = c.id),'-1') adicional,
		(case(p.unidadId) when '1 ' then (select dateadd(day,-1 + ([vip].[DiferenciaFechaLicencia](c.id)),(select dateadd(month,p.tiempo,c.fechaRegistro))))  else (cast(c.fechaRegistro as datetime) +(case(p.unidadId)
			when '2' then p.tiempo * 7 + ([vip].[DiferenciaFechaLicencia](c.id)) when '3' then p.tiempo + ([vip].[DiferenciaFechaLicencia](c.id)) end)) end) fechaFin
		
		from [vip].[ClientePaquete] c, [vip].[Paquete] p
		WHERE c.clienteId = @clienteId
		and c.paqueteId = p.id
		/*and c.adicional = -1*/
	END
END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_TraerRecibosCaja]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_TraerRecibosCaja] 
END
GO

CREATE PROCEDURE [vip].[PagoCliente_TraerRecibosCaja] 
	@ClientePaqueteId	uniqueidentifier
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		
		declare @nroRecibo int 
		declare @concaConceptos nvarchar(1000) 
		set @nroRecibo = (SELECT TOP 1 p.nroRecibo
		FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] c
		WHERE 
		p.clientePaqueteId = c.id
		and c.usuarioid = @ClientePaqueteId
		GROUP BY p.nroRecibo,p.fechaPago)

		declare cursor_prueba cursor for
		select p.concepto from [vip].[PagoCliente] p where p.nroRecibo = @nroRecibo

		declare @conceptos nvarchar(1000)

		open cursor_prueba


		fetch next from cursor_prueba 
		into @conceptos


		while @@fetch_status = 1
		begin
		set @conceptos = @conceptos +', '+@conceptos
		fetch next from cursor_prueba
		into @conceptos

		end 

		close cursor_prueba 
		deallocate cursor_prueba 

		SELECT p.nroRecibo id, p.nroRecibo nroRecibo, sum(p.monto) monto, (SELECT CONVERT(VARCHAR(10), p.fechaPago,103)) fechaPagoSinHora,
		@conceptos concepto
		FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] c
		WHERE 
		p.clientePaqueteId = c.id
		and c.usuarioid= @ClientePaqueteId
		GROUP BY p.nroRecibo, p.fechaPago
		RETURN
	END
END
GO	


IF EXISTS (SELECT name FROM VIPCENTER..sysindexes WHERE name = 'i_ClienteCi') 
BEGIN
	DROP INDEX [vip].[vClienteCi].i_ClienteCi
END
GO



IF EXISTS(select * FROM sys.views where name = 'vClienteCi')
BEGIN
	DROP VIEW [vip].[vClienteCi]
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [vip].[vClienteCi] WITH SCHEMABINDING AS

SELECT ci FROM [vip].[Cliente]
WHERE ci IS NOT NULL;
GO


CREATE UNIQUE CLUSTERED INDEX i_ClienteCi 
  ON [vip].[vClienteCi](ci)
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


IF EXISTS (SELECT * FROM sys.triggers WHERE parent_class = 0 AND name = 'trgClienteCi')
BEGIN
	DROP TRIGGER [vip].[trgClienteCi]
END
GO


CREATE TRIGGER trgClienteCi ON [vip].[vClienteCi]
INSTEAD OF INSERT
AS
BEGIN
        INSERT
        INTO    [vip].[vClienteCi]
        SELECT  *
        FROM    inserted
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[TraerTextoTexto]'))
BEGIN
	DROP FUNCTION [vip].[TraerTextoTexto]
END
GO

CREATE FUNCTION [vip].[TraerTextoTexto]
(
    @thestring             varchar(50) 
)
RETURNS Varchar(50)
AS
BEGIN
		declare @final varchar(50) 
		set @final = '' 

		select @final = @final + x.thenum 
		from 
		( 
			select substring(@thestring, number, 1) as thenum, number 
			from master..spt_values 
			where substring(@thestring, number, 1) like '[A-Z,a-z]' and type='P'
		) x 
		order by x.number 
    RETURN @final
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[TraerNumeroTexto]'))
BEGIN
	DROP FUNCTION [vip].[TraerNumeroTexto]
END
GO

CREATE FUNCTION [vip].[TraerNumeroTexto]
(
    @thestring             varchar(50) 
)
RETURNS Varchar(50)
AS
BEGIN
		declare @final varchar(50) 
		set @final = '' 

		select @final = @final + x.thenum 
		from 
		( 
			select substring(@thestring, number, 1) as thenum, number 
			from master..spt_values 
			where substring(@thestring, number, 1) like '[0-9]' and type='P'
		) x 
		order by x.number 
    RETURN @final
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_ExisteCi]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_ExisteCi] 
END
GO

CREATE PROCEDURE [vip].[Cliente_ExisteCi] 
	@ci	nvarchar(20)
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT c.apellidos,c.celular,c.correo,c.correoTrabajo,c.direccion,c.empresaId,c.estado,c.estadoCivil,c.fecha
		,c.fechaIngreso,c.fechaNacimiento,c.genero,c.id,c.lugarTrabajo,c.nombre,c.numeroCliente,c.numeroHijos,c.ocupacion
		,c.recibirNotificaciones,c.telefono,c.telefonoTrabajo,c.tieneHijos,c.usuarioId, ([VIP].[TraerTextoTexto] (c.ci)) ciCi,
		([VIP].[TraerNumeroTexto] (c.ci)) ci
		FROM [vip].[Cliente] c
		WHERE c.ci = @ci
		ORDER BY c.id asc 
		RETURN
	END
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_EliminarSinPagos]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_EliminarSinPagos] 
END
GO

SET ANSI_NULLS, QUOTED_IDENTIFIER ON;
GO

CREATE PROCEDURE [vip].[Cliente_EliminarSinPagos] 

AS
BEGIN		

	DELETE	FROM [vip].[Cliente]
	WHERE id not in (select cp.clienteId from [vip].[ClientePaquete] cp
	)
	AND id not in (select d.clienteId from [vip].[DistribucionPago] d)
	and fechaingreso > '2013-02-02 12:00:00.000'
END
GO


SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Grupo_TraerValidandoCrucesHorario]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Grupo_TraerValidandoCrucesHorario] 
END
GO

CREATE PROCEDURE [vip].[Grupo_TraerValidandoCrucesHorario] 
	@id			int,
	@id2			int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
	
		
		
SELECT convert(datetime,convert(varchar(17), GETdate(), 101) + ' ' + h.horaInicio, 101), 
convert(datetime,convert(varchar(17), GETdate(), 101) + ' ' + h.horaFin, 101)
		FROM [vip].[Horario] h, [vip].[Grupo] g
		WHERE g.id = @id
		and g.horarioId = h.id
		and  
		(
		convert(datetime,convert(varchar(17), GETdate(), 101) + ' ' + h.horaInicio, 101) >=
		(
			SELECT convert(datetime,convert(varchar(17), GETdate(), 101) + ' ' + hh.horaInicio, 101)
		FROM [vip].[Horario] hh, [vip].[Grupo] gg
		WHERE gg.id = @id2
		and gg.horarioId = hh.id
		)
		and  convert(datetime,convert(varchar(17), GETdate(), 101) + ' ' + h.horaInicio, 101) <
		(
			SELECT convert(datetime,convert(varchar(17), GETdate(), 101) + ' ' + hr.horaFin, 101)
		FROM [vip].[Horario] hr, [vip].[Grupo] gr
		WHERE gr.id = @id2
		and gr.horarioId = hr.id
		)
		or
		convert(datetime,convert(varchar(17), GETdate(), 101) + ' ' + h.horaFin, 101) >
		(
			SELECT convert(datetime,convert(varchar(17), GETdate(), 101) + ' ' + hh.horaInicio, 101)
		FROM [vip].[Horario] hh, [vip].[Grupo] gg
		WHERE gg.id = @id2
		and gg.horarioId = hh.id
		)
		and  convert(datetime,convert(varchar(17), GETdate(), 101) + ' ' + h.horaFin, 101) <=
		(
			SELECT convert(datetime,convert(varchar(17), GETdate(), 101) + ' ' + hr.horaFin, 101)
		FROM [vip].[Horario] hr, [vip].[Grupo] gr
		WHERE gr.id = @id2
		and gr.horarioId = hr.id
		)
		
		)
		
		
	END
END
GO




IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_TraerXCriterio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_TraerXCriterio] 
END
GO

CREATE PROCEDURE [vip].[Cliente_TraerXCriterio] 
	@nombre			varchar(100) = '',
	@correo				varchar(150) = '',
	@ci					varchar(15) = '',
	@estado				varchar(1) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
	IF(@nombre = '*')
	BEGIN
		SELECT c.apellidos,c.celular,c.correo,c.correoTrabajo,c.direccion,c.empresaId,c.estado,c.estadoCivil,c.fecha
		,c.fechaIngreso,c.fechaNacimiento,c.genero,c.id,c.lugarTrabajo,c.nombre,c.numeroCliente,c.numeroHijos,c.ocupacion
		,c.recibirNotificaciones,c.telefono,c.telefonoTrabajo,c.tieneHijos,c.usuarioId, ([VIP].[TraerTextoTexto] (c.ci)) ciCi,
		([VIP].[TraerNumeroTexto] (c.ci)) ci,isnull((select isnull(e.nombre,'-') from [vip].[Empresa] e where e.id = c.empresaId),'-') empresa, c.nombre + ' ' + c.apellidos nombreCompleto 
		FROM [vip].[Cliente] c
		WHERE
		c.correo like '%' + @correo + '%'
		and isnull(c.ci,'') like '%' + @ci + '%'
		and c.estado like '%' + @estado + '%'
		ORDER BY c.nombre asc 
		RETURN
	END
	ELSE
	BEGIN
		SELECT c.apellidos,c.celular,c.correo,c.correoTrabajo,c.direccion,c.empresaId,c.estado,c.estadoCivil,c.fecha
		,c.fechaIngreso,c.fechaNacimiento,c.genero,c.id,c.lugarTrabajo,c.nombre,c.numeroCliente,c.numeroHijos,c.ocupacion
		,c.recibirNotificaciones,c.telefono,c.telefonoTrabajo,c.tieneHijos,c.usuarioId, ([VIP].[TraerTextoTexto] (c.ci)) ciCi,
		([VIP].[TraerNumeroTexto] (c.ci)) ci,isnull((select isnull(e.nombre,'-') from [vip].[Empresa] e where e.id = c.empresaId),'-') empresa, c.nombre + ' ' + c.apellidos nombreCompleto 
		FROM [vip].[Cliente] c
		WHERE
		c.apellidos + c.nombre like '%' + @nombre + '%' 
		
		and c.correo like '%' + @correo + '%'
		and isnull(c.ci,'') like '%' + @ci + '%'
		and c.estado like '%' + @estado + '%'
		ORDER BY c.nombre asc 
		RETURN
	END
	END
END
GO



ALTER PROCEDURE [vip].[Horario_TraerXCriterio] 
	@salaId int, 
	
	@horaInicio varchar(5) = '', 
	@horaFin varchar(5) = '' 	
	
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		DECLARE @HI varchar(40)
		SET @HI = convert(varchar(17), GETdate(), 101) + ' ' + @horaInicio
		SET @HI = convert(datetime,@HI,101)
		
		DECLARE @HF varchar(40)
		SET @HF = convert(varchar(17), GETdate(), 101) + ' ' + @horaFin
		SET @HF = convert(datetime,@HF,101)
	
		SELECT id, salaId, horaInicio, horaFin, finDeSemana, estado
		FROM [vip].[Horario]
		WHERE (salaId = @salaId or @salaId = 0 )
		AND @HI <= convert(datetime,convert(varchar(17), GETdate(), 101) + ' ' + horaInicio, 101)
		AND @HF >= convert(datetime,convert(varchar(17), GETdate(), 101) + ' ' + horaFin, 101) 
		ORDER BY Id asc 
		RETURN
	END
END
GO


IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'ck_PagoCliente_Monto' AND xtype='C')
BEGIN
	ALTER TABLE [vip].[PagoCliente] DROP CONSTRAINT ck_PagoCliente_Monto
END
GO


IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'ck_PagoEmpresa_Monto' AND xtype='C')
BEGIN
	ALTER TABLE [vip].[PagoEmpresa] DROP CONSTRAINT ck_PagoEmpresa_Monto
END
GO



IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Parametro' AND xtype='U')
	DROP TABLE [vip].[Parametro]
GO
	
CREATE TABLE [vip].[Parametro]
(
	id varchar(200) NOT NULL, 
	nombre varchar(100) NOT NULL,
	valor varchar(250),  
	visible bit not null,
	-- INFORMACION DE LOGS
	usuarioId uniqueidentifier NOT NULL, 
	fecha datetime NOT NULL DEFAULT GETdate(),
	estado bit not null,
	CONSTRAINT un_Parametro_id UNIQUE (id), 	
	CONSTRAINT fk_Parametro_Usuario FOREIGN KEY (usuarioId) REFERENCES [DBO].[aspnet_Users](UserId)
)
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Parametro_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Parametro_Insertar]
END
GO

CREATE PROCEDURE [vip].[Parametro_Insertar]
	@id				varchar(200),
	@nombre	varchar(100),
	@valor	varchar(250),
	@visible bit,
	@usuarioId uniqueidentifier, 
	@fecha datetime,
	@estado bit
AS
BEGIN

	INSERT INTO [vip].[Parametro](nombre,valor,visible,usuarioId,fecha,estado) 
	VALUES (@nombre, @valor,@visible,@usuarioId,@fecha,@estado)  
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Parametro_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Parametro_Actualizar]
END
GO

CREATE PROCEDURE [vip].[Parametro_Actualizar]
	@id				varchar(200),
	@nombre	varchar(100),
	@valor	varchar(250),
	@visible bit,
	@usuarioId uniqueidentifier, 
	@fecha datetime,
	@estado bit
AS
BEGIN
	UPDATE [vip].[Parametro]
	SET nombre = @nombre,
	valor = @valor,
	visible = @visible,
	usuarioId = @usuarioId,
	fecha = @fecha,
	estado = @estado
	WHERE Id = @id	
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Parametro_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Parametro_Eliminar]
END
GO

CREATE PROCEDURE [vip].[Parametro_Eliminar]
	@Id					varchar(200) 
AS
BEGIN
    DELETE FROM [vip].[Parametro]
	WHERE Id = @Id 
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Parametro_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Parametro_TraerXId] 
END
GO

CREATE PROCEDURE [vip].[Parametro_TraerXId] 
	@id	varchar(200) 
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Parametro] p
		WHERE p.id = @id
		ORDER BY p.id asc 
		RETURN
	END
END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Paquete_TraerSinAdicional2]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Paquete_TraerSinAdicional2] 
END
GO

CREATE PROCEDURE [vip].[Paquete_TraerSinAdicional2] 
	@id	int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
	declare @codigo int
	set @codigo = (select isnull(c.empresaId,0) from [vip].[Cliente] c where c.id = @id)
	if(@codigo = 0)
	begin
		SELECT p.id, p.nombre
		FROM [vip].[Paquete] p
		ORDER BY p.id asc 
		RETURN
	end
	else
	begin
	SELECT p.id, p.nombre
		FROM [vip].[Paquete] p, [vip].[EmpresaPaquete] ep
		WHERE 
		ep.paqueteId = p.id
		and ep.empresaId = @codigo
		and ep.costo > 0
		ORDER BY p.id asc 
	end
	print @codigo	
	END
END
GO




IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'ClienteFecha' AND xtype='U')
	DROP TABLE [vip].[ClienteFecha]
GO

CREATE TABLE [vip].[ClienteFecha]
(
	clienteId int NOT NULL, 
	fechaInicio datetime NOT NULL, 
	estado bit not null,
	fecha	datetime not null,
	usuarioId uniqueidentifier not null
	CONSTRAINT fk_ClienteFecha_Cliente FOREIGN KEY (clienteId) REFERENCES [VIP].[Cliente](id),
	CONSTRAINT un_ClienteFecha_id UNIQUE (clienteId)
)
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClienteFecha_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClienteFecha_Actualizar]
END
GO

CREATE PROCEDURE [vip].[ClienteFecha_Actualizar]
	@clienteId	int,
	@fechaInicio	datetime,
	@estado			bit,
	@fecha			datetime,
	@usuarioId uniqueidentifier
AS
BEGIN
	UPDATE [vip].[ClienteFecha]
	SET 
	fechaInicio = @fechaInicio,
	estado = @estado,
	fecha = @fecha,
	usuarioId = @usuarioId
	WHERE clienteId = @clienteId

END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClienteFecha_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClienteFecha_Insertar]
END
GO

CREATE PROCEDURE [vip].[ClienteFecha_Insertar]
	@clienteId	int,
	@fechaInicio	datetime,
	@estado			bit,
	@fecha			datetime,
	@usuarioId		uniqueidentifier
AS
BEGIN

	INSERT INTO [vip].[ClienteFecha](clienteId, fechaInicio, estado, fecha, usuarioId) 
	VALUES (@clienteId, @fechaInicio, @estado, @fecha, @usuarioId) 
END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClienteFecha_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClienteFecha_Eliminar]
END
GO

CREATE PROCEDURE [vip].[ClienteFecha_Eliminar]
	@Id					int
AS
BEGIN
    DELETE FROM [vip].[ClienteFecha]
	WHERE clienteId = @Id 
END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClienteFecha_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClienteFecha_TraerXId] 
END
GO

CREATE PROCEDURE [vip].[ClienteFecha_TraerXId] 
	@id	 int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[ClienteFecha] p
		WHERE p.clienteId = @id
		ORDER BY p.clienteId asc 
		RETURN
	END
END
GO




IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Consulta_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Consulta_Insertar]
END
GO

CREATE PROCEDURE [vip].[Consulta_Insertar]
	@id	int	output,
	@clienteId	int,
	@fechaConsulta	datetime,
	@peso	decimal(8, 2),
	@talla	decimal(8, 2),
	@imc	decimal(8, 2),
	@pa	decimal(8, 2),
	@fr	decimal(8, 2),
	@fc	decimal(8, 2),
	@pulso	decimal(8, 2),
	@cabeza	varchar(250),
	@cardioPulmonar	varchar(250),
	@abdomen	varchar(250),
	@genitoUrinario	varchar(250),
	@extremidades	varchar(250),
	@antPatologicos	varchar(500),
	@enfermedadesActuales	varchar(500),
	@tabaco	bit	,
	@alcohol	char(1)	,
	@medicamentos	varchar(500)	,
	@estiloActividad	char(1)	,
	@descripcionActividad	varchar(2500)	,
	@tipoActividad	varchar(250)	,
	@conclusion	varchar(500)	,
	@estado	bit	,
	@usuarioId	uniqueidentifier	,
	@fecha	datetime	
AS
BEGIN

	INSERT INTO [vip].[Consulta](clienteId, fechaConsulta,peso,talla,imc,pa,fr,fc,pulso,
	cabeza,cardioPulmonar,abdomen,genitoUrinario,extremidades,antPatologicos,enfermedadesActuales,
	tabaco,alcohol,medicamentos,estiloActividad,descripcionActividad,tipoActividad,
	conclusion,estado,usuarioId,fecha) 
	VALUES (@clienteId, @fechaConsulta,@peso,@talla,@imc,@pa,@fr,@fc,@pulso,
	@cabeza,@cardioPulmonar,@abdomen,@genitoUrinario,@extremidades,@antPatologicos,@enfermedadesActuales,
	@tabaco,@alcohol,@medicamentos,@estiloActividad,@descripcionActividad,@tipoActividad,
	@conclusion,@estado,@usuarioId,@fecha) 
	SET @Id = SCOPE_IDENTITY() 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Consulta_Actualizar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Consulta_Actualizar]
END
GO

CREATE PROCEDURE [vip].[Consulta_Actualizar]
	@id				int,
	@clienteId	int,
	@fechaConsulta	datetime,
	@peso	decimal(8, 2),
	@talla	decimal(8, 2),
	@imc	decimal(8, 2),
	@pa	decimal(8, 2),
	@fr	decimal(8, 2),
	@fc	decimal(8, 2),
	@pulso	decimal(8, 2),
	@cabeza	varchar(250),
	@cardioPulmonar	varchar(250),
	@abdomen	varchar(250),
	@genitoUrinario	varchar(250),
	@extremidades	varchar(250),
	@antPatologicos	varchar(500),
	@enfermedadesActuales	varchar(500),
	@tabaco	bit	,
	@alcohol	char(1)	,
	@medicamentos	varchar(500)	,
	@estiloActividad	char(1)	,
	@descripcionActividad	varchar(2500)	,
	@tipoActividad	varchar(250)	,
	@conclusion	varchar(500)	,
	@estado	bit	,
	@usuarioId	uniqueidentifier	,
	@fecha	datetime	
AS
BEGIN
	UPDATE [vip].[Consulta]
	SET clienteId = @clienteId,
	fechaConsulta = @fechaConsulta,
	peso = @peso,
	talla = @talla,
	imc = @imc,
	pa = @pa,
	fr = @fr,
	fc = @fc,
	pulso = @pulso,
	cabeza = @cabeza,
	cardioPulmonar = @cardioPulmonar,
	abdomen = @abdomen,
	genitoUrinario = @genitoUrinario,
	extremidades = @extremidades,
	antPatologicos = @antPatologicos,
	enfermedadesActuales = @enfermedadesActuales,
	tabaco = @tabaco,
	alcohol = @alcohol,
	medicamentos = @medicamentos,
	estiloActividad = @estiloActividad,
	descripcionActividad = @descripcionActividad,
	tipoActividad = @tipoActividad,
	conclusion = @conclusion,
	estado = @estado,
	usuarioId = @usuarioId,
	fecha = @fecha
	WHERE Id = @id	
END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Consulta_TraerXId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Consulta_TraerXId]
END
GO

CREATE PROCEDURE [vip].[Consulta_TraerXId]
	@Id					int 
AS
BEGIN
    SELECT p.* 
    FROM [vip].[Consulta] p
	WHERE p.id = @Id 
	and p.estado = 'true'
END
GO




IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Consulta_Eliminar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Consulta_Eliminar]
END
GO

CREATE PROCEDURE [vip].[Consulta_Eliminar]
	@Id					int 
AS
BEGIN
    delete
    FROM [vip].[Consulta] 
	WHERE id = @Id 
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_DeshabilitarNoPagados]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_DeshabilitarNoPagados]
END
GO

CREATE PROCEDURE [vip].[Cliente_DeshabilitarNoPagados]
AS
BEGIN
begin
    update [vip].[Cliente] set estado = 'v' where id in (SELECT     c.id
	FROM         vip.Cliente c, vip.ClientePaquete cp
	where c.id = cp.clienteId and cp.id not in (select pc.ClientePaqueteId from vip.PagoCliente pc)
	and cp.FechaRegistro <= getdate() /* and c.id not in (select dp.clienteId from vip.DistribucionPago dp)*/
	and isnull(c.empresaId,0)=0)
end
begin
	update [vip].[Cliente] set estado = 'v' where id in (SELECT     c.id
	FROM         vip.Cliente c, vip.ClientePaquete cp
	where c.id = cp.clienteId and cp.id not in (select pc.ClientePaqueteId from vip.PagoCliente pc)
	and ((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' then (select dateadd(day,-1,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
			when '2' then p.tiempo * 7 when '3' then p.tiempo end)) end),103) from [vip].[Paquete] p
	where p.id = cp.paqueteId)) <= getdate() /*and c.id in (select dp.clienteId from vip.DistribucionPago dp)*/
	and isnull(c.empresaId,0)<>0)
end
END
GO





ALTER PROCEDURE [vip].[Horario_TraerXCriterio] 
	@salaId int, 
	
	@horaInicio varchar(5) = '', 
	@horaFin varchar(5) = '' 	
	
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		DECLARE @HI varchar(40)
		SET @HI = convert(varchar(17), GETdate(), 101) + ' ' + @horaInicio
		SET @HI = convert(datetime,@HI,101)
		
		DECLARE @HF varchar(40)
		SET @HF = convert(varchar(17), GETdate(), 101) + ' ' + @horaFin
		SET @HF = convert(datetime,@HF,101)
	
		SELECT id, salaId, horaInicio, horaFin, finDeSemana, estado
		FROM [vip].[Horario]
		WHERE (salaId = @salaId or @salaId = 0 )
		AND @HI <= convert(datetime,convert(varchar(17), GETdate(), 101) + ' ' + horaInicio, 101)
		AND @HF >= convert(datetime,convert(varchar(17), GETdate(), 101) + ' ' + horaFin, 101) 
		ORDER BY Id asc 
		RETURN
	END
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_TraerXCaja]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_TraerXCaja] 
END
GO

CREATE PROCEDURE [vip].[PagoCliente_TraerXCaja] 
	@fechaCaja	datetime, 
	@usuarioId	uniqueidentifier
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		,ca.numero caja, mc.montoAperturaBob apertura, mc.montoAperturaSus aperturaSus, mc.montoAdministracionBob,montoAdministracionSus, p.nombreBancoCheque cheque, p.numeroCuentaTransferencia transferencia, p.nombreBancoTransferencia bancoTransferencia
		FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq
		,[vip].[Caja] ca, [vip].[MovimientoCaja] mc
		WHERE (SELECT CONVERT(VARCHAR(10), fechaPago, 103)) = (SELECT CONVERT(VARCHAR(10), @fechaCaja, 103))  
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		and ca.cajeroId = p.usuarioId
		and ca.id = mc.cajaId
		and p.usuarioId = @usuarioId
		AND (SELECT CONVERT(VARCHAR(10), mc.fechaHoraApertura, 103)) = (SELECT CONVERT(VARCHAR(10), @fechaCaja, 103))
		UNION
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		,ca.numero caja, mc.montoAperturaBob apertura, mc.montoAperturaSus aperturaSus, mc.montoAdministracionBob,montoAdministracionSus, p.nombreBancoCheque cheque, p.numeroCuentaTransferencia transferencia, p.nombreBancoTransferencia bancoTransferencia
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq
		,[vip].[Caja] ca, [vip].[MovimientoCaja] mc
		WHERE (SELECT CONVERT(VARCHAR(10), fechaPago, 103)) = (SELECT CONVERT(VARCHAR(10), @fechaCaja, 103))  
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		and ca.cajeroId = p.usuarioId
		and ca.id = mc.cajaId
		and p.usuarioId = @usuarioId
		AND (SELECT CONVERT(VARCHAR(10), mc.fechaHoraApertura, 103)) = (SELECT CONVERT(VARCHAR(10), @fechaCaja, 103))
		--WHERE fechaPago >= convert(datetime, '2012-07-01', 101) 
		--AND fechaPago <= convert(datetime, '2012-07-31', 101)
	END
END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Caja_UltimaCaja]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Caja_UltimaCaja] 
END
GO

CREATE PROCEDURE [vip].[Caja_UltimaCaja] 
	@cajeroId	varchar(100)
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT top 1 * 
		FROM [vip].[Caja]
		WHERE cajeroId = @cajeroId
		and estado = 'false'
		ORDER BY id desc 
		RETURN
	END
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Inscripcion_TraerXClienteGrupo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Inscripcion_TraerXClienteGrupo] 
END
GO

CREATE PROCEDURE [vip].[Inscripcion_TraerXClienteGrupo] 
	@clientePaqueteId	int,
	@grupoId			int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT *
		FROM [vip].[Inscripcion] g
		WHERE
		g.clientePaqueteId = @clientePaqueteId
		and g.grupoId = @grupoId
		ORDER BY Id asc 
		RETURN
	END
END
GO


IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Cliente' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[Cliente]
	ALTER COLUMN correo varchar(150) null
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_TraerXFiltro]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_TraerXFiltro]
END
GO

CREATE PROCEDURE [vip].[PagoCliente_TraerXFiltro] 
	@clienteId	nvarchar(10), 
	@fechaPagoInicio	datetime, 
	@fechaPagoFin	datetime,
	@empresaId		nvarchar(10),
	@grupoId		nvarchar(10),
	@formaPago		nvarchar(2),
	@paqueteId		nvarchar(10)
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		if(@clienteId='')
		begin
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND isnull(c.empresaId,'') LIKE '%' + @empresaId + '%'
		UNION
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND isnull(c.empresaId,'') LIKE '%' + @empresaId + '%'
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		--WHERE fechaPago >= convert(datetime, '2012-07-01', 101) 
		--AND fechaPago <= convert(datetime, '2012-07-31', 101)
		end
		else
		begin
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND isnull(c.empresaId,'') LIKE '%' + @empresaId + '%'
		AND c.id = @clienteId
		UNION
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND isnull(c.empresaId,'') LIKE '%' + @empresaId + '%'
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND c.id = @clienteId
		end
	END
END
GO



ALTER PROCEDURE [vip].[Grupo_TraerXCriterio] 
	@nombre				varchar(100) = '',
	@servicioId			varchar(150) = '',
	@estado				varchar(10) = ''
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT g.*,(select h.horaInicio + '-' + h.horaFin  from [vip].[Horario] h where h.id = g.horarioId) horario, 
		(select h.finDeSemana  from [vip].[Horario] h where h.id = g.horarioId) finDeSemana, 
		(select s.nombre from [vip].[Servicio] s where s.id = g.servicioId ) nombreServicio,(select s.nombre from [vip].[Sala] s, [vip].[Horario] h where h.id = g.horarioId and s.id = h.salaId) sala,
		(select s.nombre from [vip].[Servicio] s where s.id = g.servicioId ) +' '+(select h.horaInicio + '-' + h.horaFin  from [vip].[Horario] h where h.id = g.horarioId) nombreServicioHorario
		FROM [vip].[Grupo] g, [vip].[Servicio] ss
		WHERE 
		ss.id = g.servicioid 
		and ss.nombre like '%' + @nombre + '%' 
		and g.servicioId like '%' + @servicioId + '%'
		and (select CAST(g.estado AS char(10))) like '%' + @estado + '%'
		ORDER BY Id asc 
		RETURN
	END
END
GO





IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Inscripcion_TraerTiempo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Inscripcion_TraerTiempo]
END
GO

CREATE PROCEDURE [vip].[Inscripcion_TraerTiempo] 
@clientePaqueteId	int,
@fecha				datetime
AS
BEGIN		
DECLARE @FECHITA	DATETIME
	SET NOCOUNT ON;
	BEGIN
		if(ISNULL((SELECT top 1 isnull(P.diasValidez,0) valor
		from [vip].[ClientePaquete] c, [vip].[Paquete] p
		WHERE c.id = @clientePaqueteId
		and c.paqueteId = p.id
		and c.estado = 'true'
		order by c.id desc),0)=0)
		begin 
		SELECT TOP 1
		(case(p.unidadId) when '1 ' then (select dateadd(day,-1,(select dateadd(month,p.tiempo,c.fechaRegistro))))  else (cast(c.fechaRegistro as datetime) +(case(p.unidadId)
			when '2' then p.tiempo * 7 when '3' then p.tiempo end)) end) tiempo 
		from [vip].[ClientePaquete] c, [vip].[Paquete] p
		WHERE c.id = @clientePaqueteId
		and c.paqueteId = p.id
		and c.estado = 'true'
		order by c.id desc
		set @fechita = (SELECT TOP 1
		(case(p.unidadId) when '1 ' then (select dateadd(day,-1,(select dateadd(month,p.tiempo,c.fechaRegistro))))  else (cast(c.fechaRegistro as datetime) +(case(p.unidadId)
			when '2' then p.tiempo * 7 when '3' then p.tiempo end)) end) tiempo 
		from [vip].[ClientePaquete] c, [vip].[Paquete] p
		WHERE c.id = @clientePaqueteId
		and c.paqueteId = p.id
		and c.estado = 'true'
		order by c.id desc)
		print @fechita
		end
		else
		begin
			SELECT TOP 1 (cast(c.fechaRegistro as  datetime)+ p.diasValidez) tiempo
			from [vip].[ClientePaquete] c, [vip].[Paquete] p
			WHERE c.id = @clientePaqueteId
			and c.paqueteId = p.id
			and c.estado = 'true'
			order by c.id desc
			set @fechita = (SELECT TOP 1 (cast(c.fechaRegistro as  datetime)+ p.diasValidez) tiempo
			from [vip].[ClientePaquete] c, [vip].[Paquete] p
			WHERE c.id = @clientePaqueteId
			and c.paqueteId = p.id
			and c.estado = 'true'
			order by c.id desc)
		end
	END
END
GO




ALTER PROCEDURE [vip].[ClientePaquete_TraerHistorial] 
	@clienteId			int
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
	
		SELECT c.id, p.nombre, c.fechaRegistro, c.estado, /*p.precio*/
		(case when isnull(cl.empresaId,0) = 0 then
		(CASE WHEN c.adicional = '-1' then ((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*p.precio)/(100)
		ELSE
		((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*p.precio)/(100) - (SELECT pp.precio FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp where cp.paqueteId = pp.id and cp.id = c.adicional)
		END
		)
		else
		(CASE WHEN c.adicional = '-1' then ((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*(select ep.costo from [vip].[EmpresaPaquete] ep where ep.paqueteId = p.id and ep.empresaId = cl.EmpresaId))/(100)
		ELSE
		((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*(select ep.costo from [vip].[EmpresaPaquete] ep where ep.paqueteId = p.id and ep.empresaId = cl.EmpresaId))/(100) - (SELECT ep.costo FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp, [vip].[EmpresaPaquete] ep where ep.empresaId = cl.empresaId and ep.paqueteId = pp.id and cp.paqueteId = pp.id and cp.id = c.adicional)
		END
		)
		end
		) - isnull((
		SELECT pro.montoDescuento FROM [vip].[Promocion] pro, [vip].[PromocionCliente] pr, [vip].[ClientePaquete] cc, [vip].[Paquete] pa
		WHERE cc.id = c.id
		and pro.id = pr.promocionId
		and pr.clientePaqueteId = cc.id
		and cc.paqueteId = pa.id
		and pa.unidadId = 1
		and pa.tiempo = 1
		),0) Precio
		, isnull((select top 1 cc.id  from [vip].[ClientePaquete] cc where cc.adicional = c.id),'-1') adicional,
		(select top 1 cc.id  from [vip].[ClientePaquete] cc where cc.adicional = c.id) adicionalCodigo,
		(case(p.unidadId) when '1 ' then (select dateadd(day,-1 + ([vip].[DiferenciaFechaLicencia](c.id)),(select dateadd(month,p.tiempo,c.fechaRegistro))))  else (cast(c.fechaRegistro as datetime) +(case(p.unidadId)
			when '2' then p.tiempo * 7 + ([vip].[DiferenciaFechaLicencia](c.id)) when '3' then p.tiempo + ([vip].[DiferenciaFechaLicencia](c.id)) end)) end) fechaFin
		
		from [vip].[ClientePaquete] c, [vip].[Paquete] p, [vip].[Cliente] cl
		WHERE c.clienteId = @clienteId
		and c.paqueteId = p.id
		and c.clienteId = cl.id
		/*and c.adicional = -1*/
	END
END
GO




ALTER PROCEDURE [vip].[PagoCliente_TraerXCaja] 
@fechaCaja datetime, 
@fechaCierreCaja datetime, 
@usuarioId uniqueidentifier,
@id			int
AS
BEGIN 
SET NOCOUNT ON;
BEGIN
SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
,ca.numero caja, mc.montoAperturaBob apertura, mc.montoAperturaSus aperturaSus, mc.montoAdministracionBob,montoAdministracionSus, p.nombreBancoCheque cheque, p.numeroCuentaTransferencia transferencia, p.nombreBancoTransferencia bancoTransferencia
FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq
,[vip].[Caja] ca, [vip].[MovimientoCaja] mc
WHERE (SELECT CONVERT(VARCHAR(10), fechaPago, 103)) between (SELECT CONVERT(VARCHAR(10), @fechaCaja, 103))  
and (SELECT CONVERT(VARCHAR(10), @fechaCierreCaja, 103)) 
AND p.clientePaqueteId = cp.id 
AND cp.clienteId = c.id 
AND paq.id = cp.paqueteId
and ca.cajeroId = p.usuarioId
and ca.id = mc.cajaId
and p.usuarioId = @usuarioId
and mc.id = @id
/*AND (SELECT CONVERT(VARCHAR(10), mc.fechaHoraApertura, 103)) = (SELECT CONVERT(VARCHAR(10), @fechaCaja, 103))*/
UNION
SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
,ca.numero caja, mc.montoAperturaBob apertura, mc.montoAperturaSus aperturaSus, mc.montoAdministracionBob,montoAdministracionSus, p.nombreBancoCheque cheque, p.numeroCuentaTransferencia transferencia, p.nombreBancoTransferencia bancoTransferencia
FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq
,[vip].[Caja] ca, [vip].[MovimientoCaja] mc
WHERE (SELECT CONVERT(VARCHAR(10), fechaPago, 103)) between (SELECT CONVERT(VARCHAR(10), @fechaCaja, 103))  
and (SELECT CONVERT(VARCHAR(10), @fechaCierreCaja, 103)) 
AND p.clientePaqueteId = cp.id 
AND cp.clienteId = c.id 
AND paq.id = cp.paqueteId
and ca.cajeroId = p.usuarioId
and ca.id = mc.cajaId
and p.usuarioId = @usuarioId
and mc.id = @id
/*AND (SELECT CONVERT(VARCHAR(10), mc.fechaHoraApertura, 103)) = (SELECT CONVERT(VARCHAR(10), @fechaCaja, 103))*/
--WHERE fechaPago >= convert(datetime, '2012-07-01', 101) 
--AND fechaPago <= convert(datetime, '2012-07-31', 101)
END
END
GO




IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_TraerXFiltro]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_TraerXFiltro]
END
GO

CREATE PROCEDURE [vip].[PagoCliente_TraerXFiltro] 
	@clienteId	nvarchar(10), 
	@fechaPagoInicio	datetime, 
	@fechaPagoFin	datetime,
	@empresaId		nvarchar(10),
	@grupoId		nvarchar(10),
	@formaPago		nvarchar(2),
	@paqueteId		nvarchar(10),
	@servicioId		nvarchar(10),
	@promocionId	nvarchar(10)
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		if(@promocionId='')
		BEGIN
		if(@clienteId='')
		begin
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId = g.id
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		AND isnull(c.empresaId,'') LIKE '%' + @empresaId + '%'
		UNION
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND isnull(c.empresaId,'') LIKE '%' + @empresaId + '%'
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId = g.id
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		--WHERE fechaPago >= convert(datetime, '2012-07-01', 101) 
		--AND fechaPago <= convert(datetime, '2012-07-31', 101)
		end
		else
		begin
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId = g.id
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		AND isnull(c.empresaId,'') LIKE '%' + @empresaId + '%'
		AND c.id = @clienteId
		UNION
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND ins.grupoId = g.id
		AND isnull(c.empresaId,'') LIKE '%' + @empresaId + '%'
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		AND c.id = @clienteId
		end
		END
		ELSE
		BEGIN
		/*ELSE PROMOCION*/
		if(@clienteId='')
		begin
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g, [vip].[PromocionCliente] pc
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId = g.id
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		AND isnull(c.empresaId,'') LIKE '%' + @empresaId + '%'
		AND cp.id = pc.clientePaqueteId
		AND pc.id LIKE '%' + @promocionId + '%'
		UNION
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g, [vip].[PromocionCliente] pc
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND isnull(c.empresaId,'') LIKE '%' + @empresaId + '%'
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId = g.id
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		AND cp.id = pc.clientePaqueteId
		AND pc.id LIKE '%' + @promocionId + '%'
		--WHERE fechaPago >= convert(datetime, '2012-07-01', 101) 
		--AND fechaPago <= convert(datetime, '2012-07-31', 101)
		end
		else
		begin
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g, [vip].[PromocionCliente] pc
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId = g.id
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		AND isnull(c.empresaId,'') LIKE '%' + @empresaId + '%'
		AND c.id = @clienteId
		AND cp.id = pc.clientePaqueteId
		AND pc.id LIKE '%' + @promocionId + '%'
		UNION
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g, [vip].[PromocionCliente] pc
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND ins.grupoId = g.id
		AND isnull(c.empresaId,'') LIKE '%' + @empresaId + '%'
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		AND c.id = @clienteId
		AND cp.id = pc.clientePaqueteId
		AND pc.id LIKE '%' + @promocionId + '%'
		end
		END
	END
END
GO



IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Cliente' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[Cliente]
	ALTER COLUMN numeroCliente int null
END
GO




SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Cliente_Insertar]
END
GO

CREATE PROCEDURE [vip].[Cliente_Insertar]
	@id				int OUTPUT,
	@nombre	varchar(50),
	@apellidos	varchar(100),
	@direccion	varchar(250)	,
	@telefono	varchar(10)	,
	@celular	varchar(10),
	@celular2	varchar(10),
	@ci	varchar(15)	,
	@correo	varchar(150)	,
	@ocupacion	varchar(150)	,
	@lugarTrabajo	varchar(250)	,
	@telefonoTrabajo	varchar(10)	,
	@correoTrabajo	varchar(150)	,
	@fechaNacimiento	datetime = null	,
	@genero	char(1)	,
	@estadoCivil	char(1)	,
	@tieneHijos	bit	,
	@numeroHijos	int	,
	@fechaIngreso	datetime	,
	@numeroCliente	int	,
	@recibirNotificaciones	bit	,
	@empresaId	int	,
	@usuarioId	uniqueidentifier	,
	@fecha	datetime	,
	@estado	char(1)
AS
SET QUOTED_IDENTIFIER ON
BEGIN
	DECLARE @num int;
	set @num = 0;
	set @num = (SELECT isnull(MAX(cc.numeroCliente),0)+1 from [vip].[Cliente] cc);
	if(@empresaId = '0')
	BEGIN
		if(@ci = '')
		BEGIN
			INSERT INTO [vip].[Cliente](nombre, apellidos, direccion,telefono,celular,celular2,ci,correo,ocupacion,lugarTrabajo,telefonoTrabajo,correoTrabajo,fechaNacimiento,genero,estadoCivil,tieneHijos,numeroHijos,fechaIngreso,numeroCliente,recibirNotificaciones,empresaId,usuarioId,fecha,estado) 
			VALUES (@nombre, @apellidos, @direccion,@telefono,@celular,@celular2,NULL,@correo,@ocupacion,@lugarTrabajo,@telefonoTrabajo,@correoTrabajo,@fechaNacimiento,@genero,@estadoCivil,@tieneHijos,@numeroHijos,@fechaIngreso,null,@recibirNotificaciones,NULL,@usuarioId,@fecha,@estado) 
			SET @Id = SCOPE_IDENTITY() 
		END
		ELSE
		BEGIN
			INSERT INTO [vip].[Cliente](nombre, apellidos, direccion,telefono,celular,celular2,ci,correo,ocupacion,lugarTrabajo,telefonoTrabajo,correoTrabajo,fechaNacimiento,genero,estadoCivil,tieneHijos,numeroHijos,fechaIngreso,numeroCliente,recibirNotificaciones,empresaId,usuarioId,fecha,estado) 
			VALUES (@nombre, @apellidos, @direccion,@telefono,@celular,@celular2,@ci,@correo,@ocupacion,@lugarTrabajo,@telefonoTrabajo,@correoTrabajo,@fechaNacimiento,@genero,@estadoCivil,@tieneHijos,@numeroHijos,@fechaIngreso,null,@recibirNotificaciones,NULL,@usuarioId,@fecha,@estado) 
			SET @Id = SCOPE_IDENTITY() 
		END
	END
	ELSE
	BEGIN
		if(@ci = '')
		BEGIN
			INSERT INTO [vip].[Cliente](nombre, apellidos, direccion,telefono,celular,celular2,ci,correo,ocupacion,lugarTrabajo,telefonoTrabajo,correoTrabajo,fechaNacimiento,genero,estadoCivil,tieneHijos,numeroHijos,fechaIngreso,numeroCliente,recibirNotificaciones,empresaId,usuarioId,fecha,estado) 
			VALUES (@nombre, @apellidos, @direccion,@telefono,@celular,@celular2,NULL,@correo,@ocupacion,@lugarTrabajo,@telefonoTrabajo,@correoTrabajo,@fechaNacimiento,@genero,@estadoCivil,@tieneHijos,@numeroHijos,@fechaIngreso,@num,@recibirNotificaciones,@empresaId,@usuarioId,@fecha,@estado) 
			SET @Id = SCOPE_IDENTITY() 
		END
		ELSE
		BEGIN
			INSERT INTO [vip].[Cliente](nombre, apellidos, direccion,telefono,celular,celular2,ci,correo,ocupacion,lugarTrabajo,telefonoTrabajo,correoTrabajo,fechaNacimiento,genero,estadoCivil,tieneHijos,numeroHijos,fechaIngreso,numeroCliente,recibirNotificaciones,empresaId,usuarioId,fecha,estado) 
			VALUES (@nombre, @apellidos, @direccion,@telefono,@celular,@celular2,@ci,@correo,@ocupacion,@lugarTrabajo,@telefonoTrabajo,@correoTrabajo,@fechaNacimiento,@genero,@estadoCivil,@tieneHijos,@numeroHijos,@fechaIngreso,@num,@recibirNotificaciones,@empresaId,@usuarioId,@fecha,@estado) 
			SET @Id = SCOPE_IDENTITY() 
		END
	END
END
SET QUOTED_IDENTIFIER OFF
GO





IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_Insertar]
END
GO



CREATE PROCEDURE [vip].[PagoCliente_Insertar]
	@id				int OUTPUT,
	@clientePaqueteId	int	,
	@concepto	varchar(250)	,
	@formaPago	char(2)	,
	@numeroFactura	int	,
	@digitosTarjeta_12	varchar(12)	,
	@numeroAprobacionPOS	varchar(20)	,
	@numeroCheque	varchar(20)	,
	@nombreBancoCheque	varchar(50)	,
	@numeroCuentaTransferencia	varchar(20)	,
	@nombreBancoTransferencia	varchar(50)	,
	@intercambioId	int	,
	@nroPago	int	,
	@fechaPeriodoInicio	datetime	,
	@fechaPeriodoFin	datetime	,
	@monto	decimal(8, 2)	,
	@fechaPago	datetime	,
	@estado	bit	,
	@usuarioId	uniqueidentifier	,
	@fecha	datetime,
	@ClienteId	int,
	@nroRecibo	int
AS
BEGIN
	declare @nroPagoUltimo	int;
	DECLARE @num int;
	DECLARE @cliId int;
	set @num = 0;
	set @num = (SELECT isnull(MAX(cc.numeroCliente),0)+1 from [vip].[Cliente] cc);
	
	set @cliId = isnull((SELECT isnull(cc.numeroCliente,'0') from [vip].[Cliente] cc where cc.id = @ClienteId),0);
	if(@cliId='0')
	begin
		update [vip].[Cliente] set numeroCliente = @num where id = @ClienteId;
	end
	
	set @nroPagoUltimo = 0;
	set @nroPagoUltimo = (
	CASE WHEN (select TOP 1 cp.adicional 
	from [vip].[PagoCliente] cc, [vip].[ClientePaquete] cp 
	where cc.ClientePaqueteId = cp.id 
	and cp.clienteId = @ClienteId GROUP by cp.clienteId, cp.adicional) = -1
	THEN
	(SELECT isnull(MAX(cc.nroPago),0)+1
	from [vip].[PagoCliente] cc, [vip].[ClientePaquete] cp 
	where cc.ClientePaqueteId = cp.id 
	and cp.clienteId = @ClienteId GROUP by cp.clienteId)
	WHEN ISNULL((select cp.adicional 
	from [vip].[PagoCliente] cc, [vip].[ClientePaquete] cp 
	where cc.ClientePaqueteId = cp.id 
	and cp.clienteId = @ClienteId GROUP by cp.clienteId, cp.adicional),0) = 0
	THEN 1
	ELSE
	(SELECT isnull(MAX(cc.nroPago),0)+1
	from [vip].[PagoCliente] cc, [vip].[ClientePaquete] cp 
	where cc.ClientePaqueteId = cp.id 
	and cp.clienteId = @ClienteId GROUP by cp.clienteId)
	END
	);
	
	if(@numeroFactura='')
	BEGIN
		set @numeroFactura = NULL
	END
	if(@digitosTarjeta_12='')
	BEGIN
		set @digitosTarjeta_12 = NULL
	END
	if(@numeroAprobacionPOS='')
	BEGIN
		set @numeroAprobacionPOS = NULL
	END
	if(@numeroCheque='')
	BEGIN
		set @numeroCheque = NULL
	END
	if(@nombreBancoCheque='')
	BEGIN
		set @nombreBancoCheque = NULL
	END
	if(@numeroCuentaTransferencia='')
	BEGIN
		set @numeroCuentaTransferencia = NULL
	END
	if(@nombreBancoTransferencia='')
	BEGIN
		set @nombreBancoTransferencia = NULL
	END
	if(@intercambioId='0')
	BEGIN
		set @digitosTarjeta_12 = NULL
	END
	
	INSERT INTO [vip].[PagoCliente](clientePaqueteId, concepto, formaPago,numeroFactura,digitosTarjeta_12,numeroAprobacionPOS,numeroCheque,nombreBancoCheque,numeroCuentaTransferencia,intercambioId,nroPago,fechaPeriodoInicio,fechaPeriodoFin,monto,fechaPago,estado,usuarioId,fecha,nroRecibo) 
	VALUES (@clientePaqueteId, @concepto, @formaPago,@numeroFactura,@digitosTarjeta_12,@numeroAprobacionPOS,@numeroCheque,@nombreBancoCheque,@numeroCuentaTransferencia,@intercambioId,@nroPagoUltimo,@fechaPeriodoInicio,@fechaPeriodoFin,@monto,@fechaPago,@estado,@usuarioId,@fecha,@nroRecibo) 
	SET @Id = SCOPE_IDENTITY() 
END
GO




IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_PagosPorVencer]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_PagosPorVencer]
END
GO



CREATE PROCEDURE [vip].[PagoCliente_PagosPorVencer]
	
AS
BEGIN
	SELECT     c.numeroCliente,c.id,(((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' then (select dateadd(day,-1,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
			when '2' then p.tiempo * 7 when '3' then p.tiempo end)) end),103) from [vip].[Paquete] p
	where p.id = cp.paqueteId))) fechaFin, pp.nombre nombrePaquete, cp.fechaRegistro,
	c.nombre + ' ' + c.apellidos nombreCliente, c.ci, c.telefono, c.celular, c.correo
	FROM         vip.Cliente c, vip.ClientePaquete cp, vip.Paquete pp
	--where c.id = cp.clienteId and cp.id in (select top 1 pc.ClientePaqueteId from vip.PagoCliente pc order by pc.id desc)
	where c.id = cp.clienteId and cp.id in (select top 1 pc.ClientePaqueteId from vip.PagoCliente pc where pc.clientepaqueteid = cp.id order by pc.id desc)
	and ((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' then (select dateadd(day,-4,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
			when '2' then (p.tiempo * 7)-4 when '3' then (p.tiempo)-4 end)) end),103) from [vip].[Paquete] p
	where p.id = cp.paqueteId)) = (SELECT CONVERT(VARCHAR(10), (DateAdd(day, 0, GetDate())),103)) /*and c.id in (select dp.clienteId from vip.DistribucionPago dp)*/
	--and isnull(c.empresaId,0)<>0
	and pp.id = cp.paqueteid
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_PagosPorVencerCliente3]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_PagosPorVencerCliente3]
END
GO



CREATE PROCEDURE [vip].[PagoCliente_PagosPorVencerCliente3]
	
AS
BEGIN
	SELECT     c.numeroCliente,c.id,(((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' then (select dateadd(day,-1,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
			when '2' then p.tiempo * 7 when '3' then p.tiempo end)) end),103) from [vip].[Paquete] p
	where p.id = cp.paqueteId))) fechaFin, pp.nombre nombrePaquete, cp.fechaRegistro,
	c.nombre + ' ' + c.apellidos nombreCliente, c.ci, c.telefono, c.celular, c.correo
	FROM         vip.Cliente c, vip.ClientePaquete cp, vip.Paquete pp
	--where c.id = cp.clienteId and cp.id in (select top 1 pc.ClientePaqueteId from vip.PagoCliente pc order by pc.id desc)
	where c.id = cp.clienteId and cp.id in (select top 1 pc.ClientePaqueteId from vip.PagoCliente pc where pc.clientepaqueteid = cp.id order by pc.id desc)
	and ((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' then (select dateadd(day,-4,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
			when '2' then (p.tiempo * 7)-4 when '3' then (p.tiempo)-4 end)) end),103) from [vip].[Paquete] p
	where p.id = cp.paqueteId)) = (SELECT CONVERT(VARCHAR(10), (DateAdd(day, 0, GetDate())),103)) /*and c.id in (select dp.clienteId from vip.DistribucionPago dp)*/
	--and isnull(c.empresaId,0)<>0
	and pp.id = cp.paqueteid
END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_PagosPorVencerCliente2]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_PagosPorVencerCliente2]
END
GO



CREATE PROCEDURE [vip].[PagoCliente_PagosPorVencerCliente2]
	
AS
BEGIN
	SELECT     c.numeroCliente,c.id,(((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' then (select dateadd(day,-1,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
			when '2' then p.tiempo * 7 when '3' then p.tiempo end)) end),103) from [vip].[Paquete] p
	where p.id = cp.paqueteId))) fechaFin, pp.nombre nombrePaquete, cp.fechaRegistro,
	c.nombre + ' ' + c.apellidos nombreCliente, c.ci, c.telefono, c.celular, c.correo
	FROM         vip.Cliente c, vip.ClientePaquete cp, vip.Paquete pp
	--where c.id = cp.clienteId and cp.id in (select top 1 pc.ClientePaqueteId from vip.PagoCliente pc order by pc.id desc)
	where c.id = cp.clienteId and cp.id in (select top 1 pc.ClientePaqueteId from vip.PagoCliente pc where pc.clientepaqueteid = cp.id order by pc.id desc)
	and ((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' then (select dateadd(day,-3,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
			when '2' then (p.tiempo * 7)-3 when '3' then (p.tiempo)-3 end)) end),103) from [vip].[Paquete] p
	where p.id = cp.paqueteId)) = (SELECT CONVERT(VARCHAR(10), (DateAdd(dd, 0, GetDate())),103)) /*and c.id in (select dp.clienteId from vip.DistribucionPago dp)*/
	--and isnull(c.empresaId,0)<>0
	and pp.id = cp.paqueteid
END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_PagosPorVencerCliente]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_PagosPorVencerCliente]
END
GO



CREATE PROCEDURE [vip].[PagoCliente_PagosPorVencerCliente]
	
AS
BEGIN
	SELECT     c.numeroCliente,c.id,(((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' then (select dateadd(day,-1,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
			when '2' then p.tiempo * 7 when '3' then p.tiempo end)) end),103) from [vip].[Paquete] p
	where p.id = cp.paqueteId))) fechaFin, pp.nombre nombrePaquete, cp.fechaRegistro,
	c.nombre + ' ' + c.apellidos nombreCliente, c.ci, c.telefono, c.celular, c.correo
	FROM         vip.Cliente c, vip.ClientePaquete cp, vip.Paquete pp
	--where c.id = cp.clienteId and cp.id in (select top 1 pc.ClientePaqueteId from vip.PagoCliente pc order by pc.id desc)
	where c.id = cp.clienteId and cp.id in (select top 1 pc.ClientePaqueteId from vip.PagoCliente pc where pc.clientepaqueteid = cp.id order by pc.id desc)
	and ((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' then (select dateadd(day,-2,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
			when '2' then (p.tiempo * 7)-2 when '3' then p.tiempo-2 end)) end),103) from [vip].[Paquete] p
	where p.id = cp.paqueteId)) = (SELECT CONVERT(VARCHAR(10), (DateAdd(dd, 0, GetDate())),103)) /*and c.id in (select dp.clienteId from vip.DistribucionPago dp)*/
	--and isnull(c.empresaId,0)<>0
	and pp.id = cp.paqueteid
END
GO





IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[ClientePaquete_TiempoMeses]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[ClientePaquete_TiempoMeses]
END
GO



CREATE PROCEDURE [vip].[ClientePaquete_TiempoMeses] 
	@clienteId				int
AS
BEGIN		

declare @concaConceptos nvarchar(4000) 
	SET @concaConceptos = '';
	declare @Conceptos nvarchar(4000) 
	/*declare cursor_prueba cursor for
		
		select s.nombre +' '+ h.horaInicio+' '+h.horaFin 
		from [vip].[Inscripcion] i, [vip].[Grupo] g, [vip].[Horario] h, [vip].[Servicio] s,
		[vip].[ClientePaquete] c
		WHERE i.grupoId = g.id
		and g.horarioId= h.id
		and g.servicioId = s.id
		and i.clientePaqueteId = c.id
		and c.clienteid = @clienteId
		and c.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)

		open cursor_prueba


		fetch next from cursor_prueba 
		into @Conceptos


		while @@fetch_status = 0
		begin
		IF(@concaConceptos = '')
		BEGIN
			set @concaConceptos = @Conceptos
		END
		ELSE
		BEGIN
			set @concaConceptos = @concaConceptos +', '+ @Conceptos
		END
		fetch next from cursor_prueba
		into @Conceptos

		end 
		close cursor_prueba 
		deallocate cursor_prueba 
	*/
	/*begin
	SELECT @concaConceptos =  COALESCE(@concaConceptos+ ', ', '') + s.nombre +' '+ h.horaInicio+'-'+h.horaFin 
		from [vip].[Inscripcion] i, [vip].[Grupo] g, [vip].[Horario] h, [vip].[Servicio] s,
		[vip].[ClientePaquete] cc
		WHERE i.grupoId = g.id
		and g.horarioId= h.id
		and g.servicioId = s.id
		and i.clientePaqueteId = cc.id
		and cc.clienteid = @clienteId
		and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
	end*/
	SELECT C.id, 
	(SELECT CONVERT(VARCHAR(10), c.fechaRegistro,103)) fechaRegistro,
	(SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' then (select dateadd(day,-1,(select dateadd(month,p.tiempo,c.fechaRegistro))))  else (cast(c.fechaRegistro as datetime) +(case(p.unidadId)
			when '2' then p.tiempo * 7 when '3' then p.tiempo end)) end),103)) fechaFin,
	DATEDIFF(month, c.fechaRegistro,  (case(p.unidadId) when '1 ' then (select dateadd(day,-1,(select dateadd(month,p.tiempo,c.fechaRegistro))))  else (cast(c.fechaRegistro as datetime) +(case(p.unidadId)
			when '2' then p.tiempo * 7 when '3' then p.tiempo end)) end)) numeroMeses
	, p.nombre nombrePaquete 
	,(case when isnull(cl.empresaId,'0') = 0 then (CASE WHEN c.adicional = '-1' then ((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*p.precio)/(100)
	ELSE
	((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*p.precio)/(100) - (SELECT pp.precio FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp where cp.paqueteId = pp.id and cp.id = c.adicional)
	END
	)
	else
	(CASE WHEN c.adicional = '-1' then ((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*(select ep.costo from [vip].[EmpresaPaquete] ep where ep.paqueteId = p.id and ep.empresaId = cl.EmpresaId))/(100)
	ELSE
	((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*p.precio)/(100) - (SELECT ep.costo FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp, [vip].[EmpresaPaquete] ep where ep.EmpresaId = cl.EmpresaId and ep.paqueteId = pp.id and cp.paqueteId = pp.id and cp.id = c.adicional)
	END
	)
	end) precioPaquete,
	(case when (
	((case when isnull(cl.empresaId,0) = 0 then
	(CASE WHEN c.adicional = '-1' then ((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*p.precio)/(100)
	ELSE
	((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*p.precio)/(100) - (SELECT pp.precio FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp where cp.paqueteId = pp.id and cp.id = c.adicional)
	END
	)
	else
	(CASE WHEN c.adicional = '-1' then ((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*(select ep.costo from [vip].[EmpresaPaquete] ep where ep.paqueteId = p.id and ep.empresaId = cl.EmpresaId))/(100)
	ELSE
	((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*(select ep.costo from [vip].[EmpresaPaquete] ep where ep.paqueteId = p.id and ep.empresaId = cl.EmpresaId))/(100) - (SELECT ep.costo FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp, [vip].[EmpresaPaquete] ep where ep.empresaId = cl.empresaId and ep.paqueteId = pp.id and cp.paqueteId = pp.id and cp.id = c.adicional)
	END
	)
	end
	) - isnull(
	(case when (SELECT count(pro.montoDescuento)
	FROM [vip].[Promocion] pro, [vip].[PromocionCliente] pr, [vip].[ClientePaquete] cc, [vip].[Paquete] pa
	,[vip].[Cliente] clien
	WHERE cc.id = c.id
	and pro.id = pr.promocionId
	and pr.clientePaqueteId in( select clip.id from [vip].[ClientePaquete] clip where clip.clienteid = cl.id) 
	and cc.paqueteId = pa.id
	and pa.unidadId = 1
	and pro.mensual = 0
	and pa.tiempo = 1) > 1 then 
	
	(SELECT (pro.montoDescuento)
	FROM [vip].[Promocion] pro, [vip].[PromocionCliente] pr, [vip].[ClientePaquete] cc, [vip].[Paquete] pa
	WHERE cc.id = c.id
	and pro.id = pr.promocionId
	and pr.clientePaqueteId in( select clip.id from [vip].[ClientePaquete] clip where clip.clienteid = cl.id) 
	and cc.paqueteId = pa.id
	and pa.unidadId = 1
	and pro.mensual = 0
	and pa.tiempo = 1)
		
	else 
	(
	SELECT pro.montoDescuento FROM [vip].[Promocion] pro, [vip].[PromocionCliente] pr, [vip].[ClientePaquete] cc, [vip].[Paquete] pa
	WHERE cc.id = c.id
	and pro.id = pr.promocionId
	and pr.clientePaqueteId = cc.id
	and cc.paqueteId = pa.id
	and pa.unidadId = 1
	and pa.tiempo = 1
	)
	 end)
	,0))) < 0 then
	
	0
	
	else
	
	((case when isnull(cl.empresaId,0) = 0 then
	(CASE WHEN c.adicional = '-1' then ((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*p.precio)/(100)
	ELSE
	((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*p.precio)/(100) - (SELECT pp.precio FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp where cp.paqueteId = pp.id and cp.id = c.adicional)
	END
	)
	else
	(CASE WHEN c.adicional = '-1' then ((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*(select ep.costo from [vip].[EmpresaPaquete] ep where ep.paqueteId = p.id and ep.empresaId = cl.EmpresaId))/(100)
	ELSE
	((isnull((select 100-d.porcentaje from [vip].[DistribucionPago] d where d.clienteId = c.clienteId),100))*(select ep.costo from [vip].[EmpresaPaquete] ep where ep.paqueteId = p.id and ep.empresaId = cl.EmpresaId))/(100) - (SELECT ep.costo FROM [vip].[Paquete] pp, [vip].[ClientePaquete] cp, [vip].[EmpresaPaquete] ep where ep.empresaId = cl.empresaId and ep.paqueteId = pp.id and cp.paqueteId = pp.id and cp.id = c.adicional)
	END
	)
	end
	) - isnull(
	(case when (SELECT count(pro.montoDescuento)
	FROM [vip].[Promocion] pro, [vip].[PromocionCliente] pr, [vip].[ClientePaquete] cc, [vip].[Paquete] pa
	,[vip].[Cliente] clien
	WHERE cc.id = c.id
	and pro.id = pr.promocionId
	and pr.clientePaqueteId in( select clip.id from [vip].[ClientePaquete] clip where clip.clienteid = cl.id) 
	and cc.paqueteId = pa.id
	and pa.unidadId = 1
	and pro.mensual = 0
	and pa.tiempo = 1) > 1 then 
	
	(SELECT (pro.montoDescuento)
	FROM [vip].[Promocion] pro, [vip].[PromocionCliente] pr, [vip].[ClientePaquete] cc, [vip].[Paquete] pa
	WHERE cc.id = c.id
	and pro.id = pr.promocionId
	and pr.clientePaqueteId in( select clip.id from [vip].[ClientePaquete] clip where clip.clienteid = cl.id) 
	and cc.paqueteId = pa.id
	and pa.unidadId = 1
	and pro.mensual = 0
	and pa.tiempo = 1)
		
	else 
	(
	SELECT pro.montoDescuento FROM [vip].[Promocion] pro, [vip].[PromocionCliente] pr, [vip].[ClientePaquete] cc, [vip].[Paquete] pa
	WHERE cc.id = c.id
	and pro.id = pr.promocionId
	and pr.clientePaqueteId = cc.id
	and cc.paqueteId = pa.id
	and pa.unidadId = 1
	and pa.tiempo = 1
	)
	 end)
	,0))
	
	end
	)
	
	 Total,
	 
	/*isnull((
	SELECT pro.montoDescuento FROM [vip].[Promocion] pro, [vip].[PromocionCliente] pr, [vip].[ClientePaquete] cc, [vip].[Paquete] pa
	WHERE cc.id = c.id 
	and pro.id = pr.promocionId
	and pr.clientePaqueteId = cc.id
	and cc.paqueteId = pa.id
	and pa.unidadId = 1
	and pa.tiempo = 1
	),0)*/
	isnull(
	(case when (SELECT count(pro.montoDescuento)
	FROM [vip].[Promocion] pro, [vip].[PromocionCliente] pr, [vip].[ClientePaquete] cc, [vip].[Paquete] pa
	,[vip].[Cliente] clien
	WHERE cc.id = c.id
	and pro.id = pr.promocionId
	and pr.clientePaqueteId in( select clip.id from [vip].[ClientePaquete] clip where clip.clienteid = cl.id) 
	and cc.paqueteId = pa.id
	and pa.unidadId = 1
	and pro.mensual = 0
	and pa.tiempo = 1) > 1 then 
	
	(SELECT (pro.montoDescuento)
	FROM [vip].[Promocion] pro, [vip].[PromocionCliente] pr, [vip].[ClientePaquete] cc, [vip].[Paquete] pa
	WHERE cc.id = c.id
	and pro.id = pr.promocionId
	and pr.clientePaqueteId in( select clip.id from [vip].[ClientePaquete] clip where clip.clienteid = cl.id) 
	and cc.paqueteId = pa.id
	and pa.unidadId = 1
	and pro.mensual = 0
	and pa.tiempo = 1)
		
	else 
	(
	SELECT pro.montoDescuento FROM [vip].[Promocion] pro, [vip].[PromocionCliente] pr, [vip].[ClientePaquete] cc, [vip].[Paquete] pa
	WHERE cc.id = c.id
	and pro.id = pr.promocionId
	and pr.clientePaqueteId = cc.id
	and cc.paqueteId = pa.id
	and pa.unidadId = 1
	and pa.tiempo = 1
	)
	 end)
	,0)
	 Descuento,
	

	/*@concaConceptos
	Concepto,*/
	(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
		from [vip].[Inscripcion] i, [vip].[Grupo] g, [vip].[Horario] h, [vip].[Servicio] s,
		[vip].[ClientePaquete] cc
		WHERE i.grupoId = g.id
		and g.horarioId= h.id
		and g.servicioId = s.id
		and i.clientePaqueteId = cc.id
		and cc.clienteid = @clienteId
		and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
		and cc.id = c.id 
		ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
		FOR XML PATH('') 
		) Concepto
	from [vip].[ClientePaquete] c, [vip].[Paquete] p,[vip].[Cliente] cl
	WHERE c.clienteId = @clienteId
	and c.clienteId = cl.id
	and c.paqueteId = p.id
	and c.estado = 'true'
	AND c.id not in (
	(select pc.clientePaqueteId 
	from [vip].[PagoCliente] pc 
	where pc.clientePaqueteId = c.id  and pc.estado = 'true' )
	)
	order by c.id ASC
	
END
GO





IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PromocionCliente_TraerXIdClientePaqueteNoMensual]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PromocionCliente_TraerXIdClientePaqueteNoMensual]
END
GO



create PROCEDURE [vip].[PromocionCliente_TraerXIdClientePaqueteNoMensual]
	@Id					int 
AS
BEGIN
    SELECT p.* FROM [vip].[PromocionCliente] p, [vip].[ClientePaquete] c,
    [vip].[Promocion] pro
	WHERE c.clienteid = @Id 
	and p.clientePaqueteId = c.id
	and p.promocionId = pro.id
	and p.estado = 'true'
	and pro.mensual = 'false'
	/*and datepart(MM, p.fechaAsignacion) = datepart(MM, GETDATE())
	and datepart(YYYY, p.fechaAsignacion) = datepart(YYYY, GETDATE())*/
END
GO




IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_TraerXCaja]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_TraerXCaja]
END
GO




CREATE PROCEDURE [vip].[PagoCliente_TraerXCaja] 
@fechaCaja datetime, 
@fechaCierreCaja datetime, 
@usuarioId uniqueidentifier,
@id			int
AS
BEGIN 
SET NOCOUNT ON;
BEGIN
SELECT p.id, c.numeroCliente, p.nroRecibo, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, (case when isnull(c.empresaId,'0')=0 then 'Particular' else 'Empresa' end)as tipo  
,ca.numero caja, mc.montoAperturaBob apertura, mc.montoAperturaSus aperturaSus, mc.montoAdministracionBob,montoAdministracionSus, p.nombreBancoCheque cheque, p.numeroCuentaTransferencia transferencia, p.nombreBancoTransferencia bancoTransferencia
, (select e.nombre from [vip].[Empresa] e where e.id = c.empresaId) empresa
FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq
,[vip].[Caja] ca, [vip].[MovimientoCaja] mc
WHERE (SELECT CONVERT(VARCHAR(10), fechaPago, 103)) between (SELECT CONVERT(VARCHAR(10), @fechaCaja, 103))  
and (SELECT CONVERT(VARCHAR(10), @fechaCierreCaja, 103)) 
AND p.clientePaqueteId = cp.id 
AND cp.clienteId = c.id 
AND paq.id = cp.paqueteId
and ca.cajeroId = p.usuarioId
and ca.id = mc.cajaId
and p.usuarioId = @usuarioId
and mc.id = @id
/*AND (SELECT CONVERT(VARCHAR(10), mc.fechaHoraApertura, 103)) = (SELECT CONVERT(VARCHAR(10), @fechaCaja, 103))*/
UNION
SELECT p.id, c.numeroCliente, '', c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Empresa' as tipo  
,ca.numero caja, mc.montoAperturaBob apertura, mc.montoAperturaSus aperturaSus, mc.montoAdministracionBob,montoAdministracionSus, p.nombreBancoCheque cheque, p.numeroCuentaTransferencia transferencia, p.nombreBancoTransferencia bancoTransferencia
, (select e.nombre from [vip].[Empresa] e where e.id = c.empresaId) empresa
FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq
,[vip].[Caja] ca, [vip].[MovimientoCaja] mc
WHERE (SELECT CONVERT(VARCHAR(10), fechaPago, 103)) between (SELECT CONVERT(VARCHAR(10), @fechaCaja, 103))  
and (SELECT CONVERT(VARCHAR(10), @fechaCierreCaja, 103)) 
AND p.clientePaqueteId = cp.id 
AND cp.clienteId = c.id 
AND paq.id = cp.paqueteId
and ca.cajeroId = p.usuarioId
and ca.id = mc.cajaId
and p.usuarioId = @usuarioId
and mc.id = @id
/*AND (SELECT CONVERT(VARCHAR(10), mc.fechaHoraApertura, 103)) = (SELECT CONVERT(VARCHAR(10), @fechaCaja, 103))*/
--WHERE fechaPago >= convert(datetime, '2012-07-01', 101) 
--AND fechaPago <= convert(datetime, '2012-07-31', 101)
END
END
GO


/****** Object:  StoredProcedure [vip].[PagoCliente_TraerXFechaPago]    Script Date: 02/13/2013 22:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoCliente_TraerXFechaPago]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoCliente_TraerXFechaPago]
END
GO



CREATE PROCEDURE [vip].[PagoCliente_TraerXFechaPago] 
	@fechaPagoInicio	datetime, 
	@fechaPagoFin	datetime
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT p.id, c.numeroCliente, p.nroRecibo, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		UNION
		SELECT p.id, c.numeroCliente, '', c.nombre, c.apellidos, paq.nombre as paquete, /*p.concepto*/
		((SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
		from [vip].[Inscripcion] i, [vip].[Grupo] g, [vip].[Horario] h, [vip].[Servicio] s,
		[vip].[ClientePaquete] cc
		WHERE i.grupoId = g.id
		and g.horarioId= h.id
		and g.servicioId = s.id
		and i.clientePaqueteId = cc.id
		and cc.id = cp.id
		ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
		FOR XML PATH('') 
		))
		, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		--WHERE fechaPago >= convert(datetime, '2012-07-01', 101) 
		--AND fechaPago <= convert(datetime, '2012-07-31', 101)
	END
END
GO


/****** Object:  StoredProcedure [vip].[MovimientoCaja_UltimoCierre]    Script Date: 02/15/2013 22:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[MovimientoCaja_UltimaApertura]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[MovimientoCaja_UltimaApertura]
END
GO



CREATE PROCEDURE [vip].[MovimientoCaja_UltimaApertura] 
	@cajaId	varchar(100)
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT top 1 m.*
		FROM [vip].[MovimientoCaja] m
		WHERE m.cajaId = @cajaId
		ORDER BY m.fechaHoraApertura desc 
		RETURN
	END
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[sec].[Privileges_TraerXPrivilege]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [sec].[Privileges_TraerXPrivilege]
END
GO


CREATE PROCEDURE [sec].[Privileges_TraerXPrivilege]
    @privilegeId	int 
AS
BEGIN
	SELECT distinct m.Email   
	FROM [SEC].[RolesInPrivileges] rp 
	JOIN [SEC].[Privileges] p ON rp.privilegeId = p.id 
	JOIN [DBO].[aspnet_Roles] r ON r.RoleName = rp.roleName
	JOIN [DBO].[aspnet_UsersInRoles] ur ON ur.RoleId = r.RoleId 
	JOIN [DBO].[aspnet_Membership] m ON m.UserId = ur.UserId
	WHERE p.Id = @privilegeId;
END
GO




IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Clientes_Activos]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Clientes_Activos]
END
GO

CREATE PROCEDURE [vip].[Clientes_Activos]
    @clienteId	nvarchar(10), 
	@fechaPagoInicio	datetime, 
	@fechaPagoFin	datetime,
	@empresaId		nvarchar(10),
	@grupoId		nvarchar(10),
	@formaPago		nvarchar(2),
	@paqueteId		nvarchar(10),
	@servicioId		nvarchar(10),
	@promocionId	nvarchar(10),
	@estado	nvarchar(10),
	@estadonr	nvarchar(10),
	@estadopago	nvarchar(10)
AS
BEGIN
	IF(@estado = 'a')
	BEGIN
	IF (@promocionId = '')
	BEGIN
	IF (@empresaId = '')
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g,
				[vip].[PagoCliente] pc
				
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		/*AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin*/
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		/*
		AND		((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) <= (SELECT CONVERT(VARCHAR(10), (DateAdd(day, 0, GetDate())),103))
		AND cp.id in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		*/
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) between (SELECT CONVERT(datetime, @fechaPagoInicio,103)) and (SELECT CONVERT(datetime, @fechaPagoFin,103))
		
		AND cp.id in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'
		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular]
		ORDER BY C.NUMEROcliente
	END
	ELSE
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g,
				[vip].[Empresa] em,
				[vip].[PagoCliente] pc
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		/*AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin*/
		/*AND		(CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END) between @fechaPagoInicio and @fechaPagoFin*/
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		AND		c.empresaId = em.id
		/*
		AND		((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) <= (SELECT CONVERT(VARCHAR(10), (DateAdd(day, 0, GetDate())),103))
		*/
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) between (SELECT CONVERT(datetime, @fechaPagoInicio,103)) and (SELECT CONVERT(datetime, @fechaPagoFin,103))
		
		AND cp.id in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'
		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular]
		ORDER BY C.NUMEROcliente
	END
	END
	ELSE
	BEGIN
	IF (@empresaId = '')
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g
				, [vip].[PromocionCliente] pr
				, [vip].[PagoCliente] pc
				
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		/*AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin*/
		/*AND		(CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END) between @fechaPagoInicio and @fechaPagoFin*/
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		AND		cp.id = pr.clientePaqueteId
		AND		pr.promocionId = @promocionId
		/*
		AND		((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) <= (SELECT CONVERT(VARCHAR(10), (DateAdd(day, 0, GetDate())),103))
		*/
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) between (SELECT CONVERT(datetime, @fechaPagoInicio,103)) and (SELECT CONVERT(datetime, @fechaPagoFin,103))
		
		AND cp.id in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'
		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular]
		ORDER BY C.NUMEROcliente
	END
	ELSE
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g,
				[vip].[Empresa] em,
				[vip].[PagoCliente] pc
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		--AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		AND		c.empresaId = em.id
		/*
		AND		((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) <= (SELECT CONVERT(VARCHAR(10), (DateAdd(day, 0, GetDate())),103))
		*/
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) between (SELECT CONVERT(datetime, @fechaPagoInicio,103)) and (SELECT CONVERT(datetime, @fechaPagoFin,103))
		
		AND cp.id in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'
		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular]
		ORDER BY C.NUMEROcliente
	END
	END
	END
	/*ELSE ESTADO*/
	ELSE
	BEGIN
	IF (@promocionId = '')
	BEGIN
	IF (@empresaId = '')
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g,
				[vip].[PagoCliente] pc
				
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		--AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		/*
		AND		((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) > (SELECT CONVERT(VARCHAR(10), (DateAdd(day, 0, GetDate())),103))
		*/
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) between (SELECT CONVERT(datetime, @fechaPagoInicio,103)) and (SELECT CONVERT(datetime, @fechaPagoFin,103))
		
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) <= (SELECT CONVERT(datetime, getdate(),103)) 
		
		AND cp.id in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'
		
		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular]
		UNION
		 
		SELECT '' fechaRegistro, '' paqueteNombre, 0 precio,0 tiempo, '' unidadNombre,  
		'' FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, '' tipoPaquete,
		'' concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,'' promocion
			,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      '' estadonr
		FROM [vip].[Cliente] C
	WHERE id not in (select cp.clienteId from [vip].[ClientePaquete] cp
	)
	
	END
	ELSE
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g,
				[vip].[Empresa] em,
				[vip].[PagoCliente] pc
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		/*AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin*/
		/*AND		(CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END) between @fechaPagoInicio and @fechaPagoFin*/
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		AND		c.empresaId = em.id
		/*
		AND		((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) > (SELECT CONVERT(VARCHAR(10), (DateAdd(day, 0, GetDate())),103))
		*/
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) between (SELECT CONVERT(datetime, @fechaPagoInicio,103)) and (SELECT CONVERT(datetime, @fechaPagoFin,103))
		
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) <= (SELECT CONVERT(datetime, getdate(),103)) 
		
		AND cp.id in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'
		
		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
		,c.[celular]
		UNION
		 
		SELECT '' fechaRegistro, '' paqueteNombre, 0 precio,0 tiempo, '' unidadNombre,  
		'' FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, '' tipoPaquete,
		'' concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,'' promocion
			,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      '' estadonr
		FROM [vip].[Cliente] C
	WHERE id not in (select cp.clienteId from [vip].[ClientePaquete] cp
	)
	
	
	END
	END
	ELSE
	BEGIN
	IF (@empresaId = '')
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g
				, [vip].[PromocionCliente] pr
				, [vip].[PagoCliente] pc
				
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		/*AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin*/
		/*AND		(CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END) between @fechaPagoInicio and @fechaPagoFin*/
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		AND		cp.id = pr.clientePaqueteId
		AND		pr.promocionId = @promocionId
		/*
		AND		((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) > (SELECT CONVERT(VARCHAR(10), (DateAdd(day, 0, GetDate())),103))
		*/
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) between (SELECT CONVERT(datetime, @fechaPagoInicio,103)) and (SELECT CONVERT(datetime, @fechaPagoFin,103))
		
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) <= (SELECT CONVERT(datetime, getdate(),103)) 
		
		AND cp.id in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'
		
		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular]
		UNION
		 
		SELECT '' fechaRegistro, '' paqueteNombre, 0 precio,0 tiempo, '' unidadNombre,  
		'' FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, '' tipoPaquete,
		'' concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,'' promocion
			,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      '' estadonr
		FROM [vip].[Cliente] C
	WHERE id not in (select cp.clienteId from [vip].[ClientePaquete] cp
	)
	
	
	END
	ELSE
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g,
				[vip].[Empresa] em,
				[vip].[PagoCliente] pc
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		--AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		AND		c.empresaId = em.id
		/*AND		((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) > (SELECT CONVERT(VARCHAR(10), (DateAdd(day, 0, GetDate())),103))
		*/
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) between (SELECT CONVERT(datetime, @fechaPagoInicio,103)) and (SELECT CONVERT(datetime, @fechaPagoFin,103))
		
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) <= (SELECT CONVERT(datetime, getdate(),103)) 
		
		AND cp.id in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'
		
		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
	,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular]
		UNION
		 
		SELECT '' fechaRegistro, '' paqueteNombre, 0 precio,0 tiempo, '' unidadNombre,  
		'' FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, '' tipoPaquete,
		'' concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,'' promocion
			,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      '' estadonr
		FROM [vip].[Cliente] C
	WHERE id not in (select cp.clienteId from [vip].[ClientePaquete] cp
	)
	
	
	END
	END
	END
END
GO






IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Clientes_Activos2]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Clientes_Activos2]
END
GO

CREATE PROCEDURE [vip].[Clientes_Activos2]
    @clienteId	nvarchar(10), 
	@fechaPagoInicio	datetime, 
	@fechaPagoFin	datetime,
	@empresaId		nvarchar(10),
	@grupoId		nvarchar(10),
	@formaPago		nvarchar(2),
	@paqueteId		nvarchar(10),
	@servicioId		nvarchar(10),
	@promocionId	nvarchar(10),
	@estado	nvarchar(10),
	@estadonr	nvarchar(10),
	@estadopago	nvarchar(10)
AS
BEGIN
	IF(@estadopago = 'd')
	BEGIN
	IF (@promocionId = '')
	BEGIN
	IF (@empresaId = '')
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g,
				[vip].[PagoCliente] pc
				
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		/*AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin*/
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		
		AND		((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) >= (SELECT CONVERT(DATETIME, GetDate(),103))
		
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) between (SELECT CONVERT(datetime, @fechaPagoInicio,103)) and (SELECT CONVERT(datetime, @fechaPagoFin,103))
		
		AND cp.id in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'
		
		
		AND pc.clientepaqueteid in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular]
		ORDER BY C.NUMEROcliente
	END
	ELSE
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g,
				[vip].[Empresa] em,
				[vip].[PagoCliente] pc
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		/*AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin*/
		/*AND		(CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END) between @fechaPagoInicio and @fechaPagoFin*/
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		AND		c.empresaId = em.id
		
		AND		((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) >= (SELECT CONVERT(DATETIME, GetDate(),103))
		
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) between (SELECT CONVERT(datetime, @fechaPagoInicio,103)) and (SELECT CONVERT(datetime, @fechaPagoFin,103))
		
		
		AND cp.id in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'
		
		
		AND pc.clientepaqueteid in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular]
		ORDER BY C.NUMEROcliente
	END
	END
	ELSE
	BEGIN
	IF (@empresaId = '')
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g
				, [vip].[PromocionCliente] pr
				, [vip].[PagoCliente] pc
				
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		/*AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin*/
		/*AND		(CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END) between @fechaPagoInicio and @fechaPagoFin*/
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		AND		cp.id = pr.clientePaqueteId
		AND		pr.promocionId = @promocionId
		
		AND		((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) >= (SELECT CONVERT(DATETIME, GetDate(),103))
		
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) between (SELECT CONVERT(datetime, @fechaPagoInicio,103)) and (SELECT CONVERT(datetime, @fechaPagoFin,103))
		
		AND cp.id in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'
		
		AND pc.clientepaqueteid in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular]
		ORDER BY C.NUMEROcliente
	END
	ELSE
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g,
				[vip].[Empresa] em,
				[vip].[PagoCliente] pc
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		--AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		AND		c.empresaId = em.id
		
		AND		((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) >= (SELECT CONVERT(DATETIME, GetDate(),103))
		
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) between (SELECT CONVERT(datetime, @fechaPagoInicio,103)) and (SELECT CONVERT(datetime, @fechaPagoFin,103))
		
		AND cp.id in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'

		
		AND pc.clientepaqueteid in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular]
		ORDER BY C.NUMEROcliente
	END
	END
	END
	/*ELSE ESTADO*/
	ELSE
	BEGIN
	IF (@promocionId = '')
	BEGIN
	IF (@empresaId = '')
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g,
				[vip].[PagoCliente] pc
				
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		--AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		--and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		
		AND		((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) < (SELECT CONVERT(DATETIME, GetDate(),103))
		
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) between (SELECT CONVERT(datetime, @fechaPagoInicio,103)) and (SELECT CONVERT(datetime, @fechaPagoFin,103))
		
		
		AND cp.id in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'


		and cp.id not in (select pcc.clientepaqueteid from vip.pagocliente pcc)	
		
		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular]
		/*UNION
		 
		SELECT '' fechaRegistro, '' paqueteNombre, 0 precio,0 tiempo, '' unidadNombre,  
		'' FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, '' tipoPaquete,
		'' concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,'' promocion
			,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      '' estadonr
		FROM [vip].[Cliente] C
	WHERE id not in (select cp.clienteId from [vip].[ClientePaquete] cp
	)
	*/
	END
	ELSE
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g,
				[vip].[Empresa] em,
				[vip].[PagoCliente] pc
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		/*AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin*/
		/*AND		(CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END) between @fechaPagoInicio and @fechaPagoFin*/
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		--and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		AND		c.empresaId = em.id
		
		AND		((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) < (SELECT CONVERT(DATETIME, GetDate(),103))
		
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) between (SELECT CONVERT(datetime, @fechaPagoInicio,103)) and (SELECT CONVERT(datetime, @fechaPagoFin,103))
		
	
		
		AND cp.id in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'
		

		and cp.id not in (select pcc.clientepaqueteid from vip.pagocliente pcc)	

		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
		,c.[celular]
	/*	UNION
		 
		SELECT '' fechaRegistro, '' paqueteNombre, 0 precio,0 tiempo, '' unidadNombre,  
		'' FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, '' tipoPaquete,
		'' concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,'' promocion
			,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      '' estadonr
		FROM [vip].[Cliente] C
	WHERE id not in (select cp.clienteId from [vip].[ClientePaquete] cp
	)
	*/
	
	END
	END
	ELSE
	BEGIN
	IF (@empresaId = '')
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g
				, [vip].[PromocionCliente] pr
				, [vip].[PagoCliente] pc
				
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		/*AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin*/
		/*AND		(CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END) between @fechaPagoInicio and @fechaPagoFin*/
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		--and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		AND		cp.id = pr.clientePaqueteId
		AND		pr.promocionId = @promocionId
		
		AND		((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) < (SELECT CONVERT(DATETIME, GetDate(),103))
		
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) between (SELECT CONVERT(datetime, @fechaPagoInicio,103)) and (SELECT CONVERT(datetime, @fechaPagoFin,103))
		
		
		AND cp.id in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'
		
		
		and cp.id not in (select pcc.clientepaqueteid from vip.pagocliente pcc)	
		
		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular]
		/*
		UNION
		 
		SELECT '' fechaRegistro, '' paqueteNombre, 0 precio,0 tiempo, '' unidadNombre,  
		'' FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, '' tipoPaquete,
		'' concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,'' promocion
			,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      '' estadonr
		FROM [vip].[Cliente] C
	WHERE id not in (select cp.clienteId from [vip].[ClientePaquete] cp
	)
	
	*/
	END
	ELSE
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g,
				[vip].[Empresa] em,
				[vip].[PagoCliente] pc
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		--AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		--and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		AND		c.empresaId = em.id
		AND		((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) < (SELECT CONVERT(DATETIME, GetDate(),103))
		
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) between (SELECT CONVERT(datetime, @fechaPagoInicio,103)) and (SELECT CONVERT(datetime, @fechaPagoFin,103))
		
		
		AND cp.id in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'
		

		and cp.id not in (select pcc.clientepaqueteid from vip.pagocliente pcc)	

		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
	,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular]
		/*UNION
		 
		SELECT '' fechaRegistro, '' paqueteNombre, 0 precio,0 tiempo, '' unidadNombre,  
		'' FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, '' tipoPaquete,
		'' concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,'' promocion
			,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      '' estadonr
		FROM [vip].[Cliente] C
	WHERE id not in (select cp.clienteId from [vip].[ClientePaquete] cp
	)
	
	*/
	END
	END
	END
END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Clientes_Activos3]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Clientes_Activos3]
END
GO

CREATE PROCEDURE [vip].[Clientes_Activos3]
    @clienteId	nvarchar(10), 
	@fechaPagoInicio	datetime, 
	@fechaPagoFin	datetime,
	@empresaId		nvarchar(10),
	@grupoId		nvarchar(10),
	@formaPago		nvarchar(2),
	@paqueteId		nvarchar(10),
	@servicioId		nvarchar(10),
	@promocionId	nvarchar(10),
	@estado	nvarchar(10),
	@estadonr	nvarchar(10),
	@estadopago	nvarchar(10)
AS
BEGIN
	IF(@estadopago = 'd')
	BEGIN
	IF (@promocionId = '')
	BEGIN
	IF (@empresaId = '')
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g,
				[vip].[PagoCliente] pc
				
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		/*AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin*/
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		
		
		AND (SELECT CONVERT(datetime, @fechaPagoInicio,103))
		between (SELECT CONVERT(datetime, cp.fechaRegistro,103)) and		((SELECT CONVERT(datetime,(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) 
		
		--AND cp.id in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'
		
		
		--AND pc.clientepaqueteid in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular]
		ORDER BY C.NUMEROcliente
	END
	ELSE
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g,
				[vip].[Empresa] em,
				[vip].[PagoCliente] pc
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		/*AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin*/
		/*AND		(CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END) between @fechaPagoInicio and @fechaPagoFin*/
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		AND		c.empresaId = em.id
		
		AND (SELECT CONVERT(datetime, @fechaPagoInicio,103))
		between (SELECT CONVERT(datetime, cp.fechaRegistro,103)) and		((SELECT CONVERT(datetime,(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) 
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'
		
		
		--AND pc.clientepaqueteid in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular]
		ORDER BY C.NUMEROcliente
	END
	END
	ELSE
	BEGIN
	IF (@empresaId = '')
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g
				, [vip].[PromocionCliente] pr
				, [vip].[PagoCliente] pc
				
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		/*AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin*/
		/*AND		(CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END) between @fechaPagoInicio and @fechaPagoFin*/
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		AND		cp.id = pr.clientePaqueteId
		AND		pr.promocionId = @promocionId
		
		AND (SELECT CONVERT(datetime, @fechaPagoInicio,103))
		between (SELECT CONVERT(datetime, cp.fechaRegistro,103)) and		((SELECT CONVERT(datetime,(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) 
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'
		
		--AND pc.clientepaqueteid in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular]
		ORDER BY C.NUMEROcliente
	END
	ELSE
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g,
				[vip].[Empresa] em,
				[vip].[PagoCliente] pc
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		--AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		AND		c.empresaId = em.id
		
		AND (SELECT CONVERT(datetime, @fechaPagoInicio,103))
		between (SELECT CONVERT(datetime, cp.fechaRegistro,103)) and		((SELECT CONVERT(datetime,(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) 
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'

		
		--AND pc.clientepaqueteid in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular]
		ORDER BY C.NUMEROcliente
	END
	END
	END
	/*ELSE ESTADO*/
	ELSE
	BEGIN
	IF (@promocionId = '')
	BEGIN
	IF (@empresaId = '')
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g,
				[vip].[PagoCliente] pc
				
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		--AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		--and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		
		AND		((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) < (SELECT CONVERT(DATETIME, GetDate(),103))
		
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) between (SELECT CONVERT(datetime, @fechaPagoInicio,103)) and (SELECT CONVERT(datetime, @fechaPagoFin,103))
		
		
		AND cp.id in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'


		and cp.id not in (select pcc.clientepaqueteid from vip.pagocliente pcc)	
		
		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular]
		/*UNION
		 
		SELECT '' fechaRegistro, '' paqueteNombre, 0 precio,0 tiempo, '' unidadNombre,  
		'' FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, '' tipoPaquete,
		'' concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,'' promocion
			,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      '' estadonr
		FROM [vip].[Cliente] C
	WHERE id not in (select cp.clienteId from [vip].[ClientePaquete] cp
	)
	*/
	END
	ELSE
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g,
				[vip].[Empresa] em,
				[vip].[PagoCliente] pc
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		/*AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin*/
		/*AND		(CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END) between @fechaPagoInicio and @fechaPagoFin*/
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		--and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		AND		c.empresaId = em.id
		
		AND		((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) < (SELECT CONVERT(DATETIME, GetDate(),103))
		
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) between (SELECT CONVERT(datetime, @fechaPagoInicio,103)) and (SELECT CONVERT(datetime, @fechaPagoFin,103))
		
	
		
		AND cp.id in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'
		

		and cp.id not in (select pcc.clientepaqueteid from vip.pagocliente pcc)	

		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
		,c.[celular]
	/*	UNION
		 
		SELECT '' fechaRegistro, '' paqueteNombre, 0 precio,0 tiempo, '' unidadNombre,  
		'' FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, '' tipoPaquete,
		'' concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,'' promocion
			,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      '' estadonr
		FROM [vip].[Cliente] C
	WHERE id not in (select cp.clienteId from [vip].[ClientePaquete] cp
	)
	*/
	
	END
	END
	ELSE
	BEGIN
	IF (@empresaId = '')
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g
				, [vip].[PromocionCliente] pr
				, [vip].[PagoCliente] pc
				
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		/*AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin*/
		/*AND		(CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END) between @fechaPagoInicio and @fechaPagoFin*/
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		--and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		AND		cp.id = pr.clientePaqueteId
		AND		pr.promocionId = @promocionId
		
		AND		((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) < (SELECT CONVERT(DATETIME, GetDate(),103))
		
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) between (SELECT CONVERT(datetime, @fechaPagoInicio,103)) and (SELECT CONVERT(datetime, @fechaPagoFin,103))
		
		
		AND cp.id in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'
		
		
		and cp.id not in (select pcc.clientepaqueteid from vip.pagocliente pcc)	
		
		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular]
		/*
		UNION
		 
		SELECT '' fechaRegistro, '' paqueteNombre, 0 precio,0 tiempo, '' unidadNombre,  
		'' FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, '' tipoPaquete,
		'' concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,'' promocion
			,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      '' estadonr
		FROM [vip].[Cliente] C
	WHERE id not in (select cp.clienteId from [vip].[ClientePaquete] cp
	)
	
	*/
	END
	ELSE
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      (case (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) when 'R' then 'Renovación'  when 'N' THEN 'Nuevo' when 'I' then 'Reingreso' else '' end) estadonr
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g,
				[vip].[Empresa] em,
				[vip].[PagoCliente] pc
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */
		--AND		cp.fechaRegistro between @fechaPagoInicio and @fechaPagoFin
		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		--and		pc.clientePaqueteId = cp.id
		AND		c.id LIKE '%' + @clienteId + '%'
		AND		g.id LIKE '%' + @grupoId + '%'
		AND		p.id LIKE '%' + @paqueteId + '%'
		AND		g.servicioId LIKE '%' + @servicioId + '%'
		AND		c.empresaId = em.id
		AND		((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) < (SELECT CONVERT(DATETIME, GetDate(),103))
		
		AND		((SELECT CONVERT(datetime,(case(p.unidadId) when '1' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) between (SELECT CONVERT(datetime, @fechaPagoInicio,103)) and (SELECT CONVERT(datetime, @fechaPagoFin,103))
		
		
		AND cp.id in (select top 1 cpp.id from vip.ClientePaquete cpp where c.id = cpp.clienteId order by cpp.fechaRegistro desc)
		
		
		and (isnull([vip].[Cliente_Historial2](c.id, cp.id),'')) like '%' + @estadonr + '%'
		

		and cp.id not in (select pcc.clientepaqueteid from vip.pagocliente pcc)	

		
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id
	,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular]
		/*UNION
		 
		SELECT '' fechaRegistro, '' paqueteNombre, 0 precio,0 tiempo, '' unidadNombre,  
		'' FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, '' tipoPaquete,
		'' concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,'' promocion
			,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      ,c.[genero]
      ,c.[celular2]
      ,c.[celular],
      '' estadonr
		FROM [vip].[Cliente] C
	WHERE id not in (select cp.clienteId from [vip].[ClientePaquete] cp
	)
	
	*/
	END
	END
	END
END
GO
















IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Clientes_Datos]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Clientes_Datos]
END
GO

CREATE PROCEDURE [vip].[Clientes_Datos]
	@estado	nvarchar(10)
AS
BEGIN
	IF (@estado = 'r')
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
			,(select nombre from vip.empresa emp where emp.id = c.empresaId) as nombreEmpresa
			,c.celular2, c.genero, c.celular
			,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g,
				[vip].[PagoCliente] pc
				
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */

		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		and		pc.clientePaqueteId = cp.id
		AND		((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) <= (SELECT CONVERT(VARCHAR(10), (DateAdd(day, 0, GetDate())),103))
		and [vip].[Cliente_Historial2](c.id, cp.id) = 'R'
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id,c.empresaId,c.celular2, c.genero, c.celular
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
		ORDER BY C.NUMEROcliente
	END
	if(@estado = 'n')
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
			,(select nombre from vip.empresa emp where emp.id = c.empresaId) as nombreEmpresa
			,c.celular2, c.genero, c.celular
			,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g,
				[vip].[PagoCliente] pc
				
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */

		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		and		pc.clientePaqueteId = cp.id
		AND		cp.fecharegistro between (SELECT CONVERT(VARCHAR(10), (DateAdd(month, -1, GetDate())),103)) and (SELECT CONVERT(VARCHAR(10), (DateAdd(day, 0, GetDate())),103))
		and [vip].[Cliente_Historial2](c.id, cp.id) = 'N'
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id,c.empresaId,c.celular2, c.genero,c.celular
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
      
      UNION
		 
		select '' fechaRegistro, '' paqueteNombre, 0 precio, 0 tiempo, '' unidadNombre,  
		'' FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, ''tipoPaquete,
		'' concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,'' promocion
			,(select nombre from vip.empresa emp where emp.id = c.empresaId) as nombreEmpresa
			,c.celular2, c.genero, c.celular
			,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
		FROM [vip].[Cliente] C
	WHERE id not in (select cp.clienteId from [vip].[ClientePaquete] cp
	)
      
		ORDER BY C.NUMEROcliente
	END
	IF (@estado = 'i')
	BEGIN
		SELECT cp.fechaRegistro, p.nombre paqueteNombre, p.precio, p.tiempo, u.nombre unidadNombre,  
		CASE 
			WHEN u.nombre = 'Mes' THEN DateADD(month, p.tiempo, cp.fechaRegistro)
			WHEN u.nombre = 'Semana' THEN DateADD(day, p.tiempo * 7, cp.fechaRegistro)
			WHEN u.nombre = 'Sesión' THEN DateADD(day, p.tiempo, cp.fechaRegistro)
			ELSE cp.fechaRegistro
		END as FechaFinalizacion, c.nombre, c.apellidos, c.numerocliente, tp.nombre tipoPaquete,
		(SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
			from [vip].[Inscripcion] i, [vip].[Grupo] gg, [vip].[Horario] h, [vip].[Servicio] s,
			[vip].[ClientePaquete] cc
			WHERE i.grupoId = gg.id
			and gg.horarioId= h.id
			and gg.servicioId = s.id
			and i.clientePaqueteId = cc.id
			and cc.clienteid = c.id 
			/*and cc.id not in (select pc.clientePaqueteId from [vip].[PagoCliente] pc)
			and cc.id = c.id*/ 
			ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
			FOR XML PATH('') 
			) concepto,
			c.direccion, c.telefono, c.correo, c.ci
			,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
			,(select nombre from vip.empresa emp where emp.id = c.empresaId) as nombreEmpresa
			,c.celular2, c.genero, c.celular
			,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
		FROM	[vip].[ClientePaquete] cp, 
				[vip].[Paquete] p, 
				[vip].[Cliente] c, 
				[vip].[TipoPaquete] tp, 
				[vip].[Unidad] u, 
				[vip].[Inscripcion] ins,
				[vip].[Grupo] g,
				[vip].[PagoCliente] pc
				
		WHERE   cp.paqueteId = p.id 
		AND		p.unidadId = u.id 
		AND		c.Id = cp.clienteId
		AND		tp.Id = p.tipoPaqueteId 
		/*AND		cp.fechaRegistro <= GETDATE() */

		AND		cp.id = ins.clientePaqueteId
		AND		ins.grupoId = g.id
		and		pc.clientePaqueteId = cp.id
		AND		((SELECT CONVERT(VARCHAR(10),(case(p.unidadId) when '1 ' 
		then (select dateadd(day,0,(select dateadd(month,p.tiempo,cp.fechaRegistro))))  
		else (cast(cp.fechaRegistro as datetime) +(case(p.unidadId)
		when '2' then (p.tiempo * 7) when '3' then (p.tiempo) end)) end),103) from [vip].[Paquete] p
		where p.id = cp.paqueteId)) <= (SELECT CONVERT(VARCHAR(10), (DateAdd(day, 0, GetDate())),103))
		and [vip].[Cliente_Historial2](c.id, cp.id) = 'I'
		GROUP BY c.id, cp.fechaRegistro, p.nombre, p.precio, p.tiempo, u.nombre, c.nombre, c.apellidos, c.numerocliente, tp.nombre,c.direccion, c.telefono, c.correo, c.ci, cp.id,c.empresaId,c.celular2, c.genero, c.celular
		,c.[ocupacion]
      ,c.[lugarTrabajo]
      ,c.[telefonoTrabajo]
      ,c.[correoTrabajo]
      ,c.[fechaNacimiento]
		ORDER BY C.NUMEROcliente
	END
END
GO





IF NOT EXISTS (SELECT * FROM SEC.Privileges WHERE nombre = 'ReportePagosEmpresa')
BEGIN
	SET IDENTITY_INSERT sec.Privileges ON
	INSERT INTO SEC.Privileges (id, nombre, descripcion) values(27, 'ReportePagosEmpresa','Reporte de pagos de empresa.')
	INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  VALUES ('Administrator', 27)
	SET IDENTITY_INSERT sec.Privileges OFF
END
GO




IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoEmpresa_TraerXFiltro]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoEmpresa_TraerXFiltro]
END
GO

CREATE PROCEDURE [vip].[PagoEmpresa_TraerXFiltro] 
	@clienteId	nvarchar(10), 
	@fechaPagoInicio	datetime, 
	@fechaPagoFin	datetime,
	@grupoId		nvarchar(10),
	@formaPago		nvarchar(2),
	@paqueteId		nvarchar(10),
	@servicioId		nvarchar(10),
	@promocionId	nvarchar(10)
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		if(@promocionId='')
		BEGIN
		if(@clienteId='')
		begin
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo , em.nombre empresa, em.nombrePersonaContacto contacto, em.telefono, em.correo, em.direccion
		,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g,  [vip].[Empresa] em
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId = g.id
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		and p.empresaId = em.id
		UNION
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  , em.nombre empresa, em.nombrePersonaContacto contacto, em.telefono, em.correo, em.direccion
		,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g,  [vip].[Empresa] em
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId = g.id
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		and p.empresaId = em.id
		--WHERE fechaPago >= convert(datetime, '2012-07-01', 101) 
		--AND fechaPago <= convert(datetime, '2012-07-31', 101)
		end
		else
		begin
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  , em.nombre empresa
		,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g,  [vip].[Empresa] em
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId = g.id
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		AND em.id = @clienteId
		and p.empresaId = em.id
		UNION
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  , em.nombre empresa
		,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g,  [vip].[Empresa] em
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND ins.grupoId = g.id
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		AND em.id = @clienteId
		and p.empresaId = em.id
		end
		END
		ELSE
		BEGIN
		/*ELSE PROMOCION*/
		if(@clienteId='')
		begin
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  , em.nombre empresa
		,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g, [vip].[PromocionCliente] pc,  [vip].[Empresa] em
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId = g.id
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		AND cp.id = pc.clientePaqueteId
		AND pc.id LIKE '%' + @promocionId + '%'
		and p.empresaId = em.id
		UNION
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  , em.nombre empresa
		,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g, [vip].[PromocionCliente] pc,  [vip].[Empresa] em
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId = g.id
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		AND cp.id = pc.clientePaqueteId
		AND pc.id LIKE '%' + @promocionId + '%'
		and p.empresaId = em.id
		--WHERE fechaPago >= convert(datetime, '2012-07-01', 101) 
		--AND fechaPago <= convert(datetime, '2012-07-31', 101)
		end
		else
		begin
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  , em.nombre empresa
		,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g, [vip].[PromocionCliente] pc,  [vip].[Empresa] em
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId = g.id
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		AND em.id = @clienteId
		AND cp.id = pc.clientePaqueteId
		AND pc.id LIKE '%' + @promocionId + '%'
		and p.empresaId = em.id
		UNION
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  , em.nombre empresa
		,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g, [vip].[PromocionCliente] pc,  [vip].[Empresa] em
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND ins.grupoId = g.id
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		AND em.id = @clienteId
		AND cp.id = pc.clientePaqueteId
		AND pc.id LIKE '%' + @promocionId + '%'
		and p.empresaId = em.id
		end
		END
	END
END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Cliente_Historial2]'))
BEGIN
	DROP FUNCTION [vip].[Cliente_Historial2]
END
GO

CREATE FUNCTION [vip].[Cliente_Historial2] (@idsearch int, @clientePaquete int)
--@clientType varchar(1) output
returns VARCHAR(1)  
AS
BEGIN 
	DECLARE @clientType VARCHAR(1)  
	DECLARE @datereturn DATETIME, @dateanterior DATETIME 
	DECLARE @valores int 
	BEGIN
		SET @datereturn = 
		(
			SELECT TOP(1) fecharegistro 
			FROM [VIPCENTER].[vip].[ClientePaquete] 
			WHERE clienteId=@idsearch 
			--and id = @clientePaquete
			ORDER BY fecha DESC
		)
		SET @dateanterior = 
		(
			SELECT TOP(1) fecharegistro 
			FROM [VIPCENTER].[vip].[ClientePaquete] 
			WHERE clienteId=@idsearch 
			--and id = @clientePaquete
			and fecharegistro != @datereturn 
			ORDER BY fecha DESC
		)
	END 
	
	IF @dateanterior IS NULL 
		SET @clientType = 'N' 
	ELSE
		BEGIN
			IF DATEADD(month, 1, @dateanterior) = @datereturn
				SET @clientType = 'R' 
			ELSE
				SET @clientType = 'I'
		END
	RETURN @clientType
END
GO

ALTER PROCEDURE [vip].[PagoCliente_TraerXCaja] 
@fechaCaja datetime, 
@fechaCierreCaja datetime, 
@usuarioId uniqueidentifier,
@id			int
AS
BEGIN 
SET NOCOUNT ON;

BEGIN
SELECT [vip].[Cliente_Historial2](c.id, cp.id) as tipocliente, p.id, c.numeroCliente, p.nroRecibo, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, (case when isnull(c.empresaId,'0')=0 then 'Particular' else 'Empresa' end)as tipo  
,ca.numero caja, mc.montoAperturaBob apertura, mc.montoAperturaSus aperturaSus, mc.montoAdministracionBob,montoAdministracionSus, p.nombreBancoCheque cheque, p.numeroCuentaTransferencia transferencia, p.nombreBancoTransferencia bancoTransferencia
, (select e.nombre from [vip].[Empresa] e where e.id = c.empresaId) empresa
FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq
,[vip].[Caja] ca, [vip].[MovimientoCaja] mc
WHERE (SELECT CONVERT(VARCHAR(10), fechaPago, 103)) between (SELECT CONVERT(VARCHAR(10), @fechaCaja, 103))  
and (SELECT CONVERT(VARCHAR(10), @fechaCierreCaja, 103)) 
AND p.clientePaqueteId = cp.id 
AND cp.clienteId = c.id 
AND paq.id = cp.paqueteId
and ca.cajeroId = p.usuarioId
and ca.id = mc.cajaId
and p.usuarioId = @usuarioId
and mc.id = @id
/*AND (SELECT CONVERT(VARCHAR(10), mc.fechaHoraApertura, 103)) = (SELECT CONVERT(VARCHAR(10), @fechaCaja, 103))*/
UNION
SELECT [vip].[Cliente_Historial2](c.id, cp.id) as tipocliente, p.id, c.numeroCliente, '', c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Empresa' as tipo  
,ca.numero caja, mc.montoAperturaBob apertura, mc.montoAperturaSus aperturaSus, mc.montoAdministracionBob,montoAdministracionSus, p.nombreBancoCheque cheque, p.numeroCuentaTransferencia transferencia, p.nombreBancoTransferencia bancoTransferencia
, (select e.nombre from [vip].[Empresa] e where e.id = c.empresaId) empresa
FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq
,[vip].[Caja] ca, [vip].[MovimientoCaja] mc
WHERE (SELECT CONVERT(VARCHAR(10), fechaPago, 103)) between (SELECT CONVERT(VARCHAR(10), @fechaCaja, 103))  
and (SELECT CONVERT(VARCHAR(10), @fechaCierreCaja, 103)) 
AND p.clientePaqueteId = cp.id 
AND cp.clienteId = c.id 
AND paq.id = cp.paqueteId
and ca.cajeroId = p.usuarioId
and ca.id = mc.cajaId
and p.usuarioId = @usuarioId
and mc.id = @id
/*AND (SELECT CONVERT(VARCHAR(10), mc.fechaHoraApertura, 103)) = (SELECT CONVERT(VARCHAR(10), @fechaCaja, 103))*/
--WHERE fechaPago >= convert(datetime, '2012-07-01', 101) 
--AND fechaPago <= convert(datetime, '2012-07-31', 101)
END
END
GO

ALTER PROCEDURE [vip].[PagoCliente_TraerXFechaPago] 
	@fechaPagoInicio	datetime, 
	@fechaPagoFin	datetime
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT [vip].[Cliente_Historial2](c.id, cp.id) as tipocliente, p.id, c.numeroCliente, p.nroRecibo, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		UNION
		SELECT [vip].[Cliente_Historial2](c.id, cp.id) as tipocliente, p.id, c.numeroCliente, '', c.nombre, c.apellidos, paq.nombre as paquete, /*p.concepto*/
		((SELECT  s.nombre +' '+ h.horaInicio+'-'+h.horaFin + ', '
		from [vip].[Inscripcion] i, [vip].[Grupo] g, [vip].[Horario] h, [vip].[Servicio] s,
		[vip].[ClientePaquete] cc
		WHERE i.grupoId = g.id
		and g.horarioId= h.id
		and g.servicioId = s.id
		and i.clientePaqueteId = cc.id
		and cc.id = cp.id
		ORDER BY LEN(s.nombre +' '+ h.horaInicio+'-'+h.horaFin)
		FOR XML PATH('') 
		))
		, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		--WHERE fechaPago >= convert(datetime, '2012-07-01', 101) 
		--AND fechaPago <= convert(datetime, '2012-07-31', 101)
	END
END
GO

ALTER PROCEDURE [vip].[PagoCliente_TraerXCaja] 
@fechaCaja datetime, 
@fechaCierreCaja datetime, 
@usuarioId uniqueidentifier,
@id			int
AS
BEGIN 
SET NOCOUNT ON;

BEGIN
SELECT [vip].[Cliente_Historial2](c.id, cp.id) as tipocliente, p.id, c.numeroCliente, p.nroRecibo, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, (case when isnull(c.empresaId,'0')=0 then 'Particular' else 'Empresa' end)as tipo  
,ca.numero caja, mc.montoAperturaBob apertura, mc.montoAperturaSus aperturaSus, mc.montoAdministracionBob,montoAdministracionSus, p.nombreBancoCheque cheque, p.numeroCuentaTransferencia transferencia, p.nombreBancoTransferencia bancoTransferencia
, (select e.nombre from [vip].[Empresa] e where e.id = c.empresaId) empresa
FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq
,[vip].[Caja] ca, [vip].[MovimientoCaja] mc
WHERE (SELECT CONVERT(VARCHAR(10), fechaPago, 103)) between (SELECT CONVERT(VARCHAR(10), @fechaCaja, 103))  
and (SELECT CONVERT(VARCHAR(10), @fechaCierreCaja, 103)) 
AND p.clientePaqueteId = cp.id 
AND cp.clienteId = c.id 
AND paq.id = cp.paqueteId
and ca.cajeroId = p.usuarioId
and ca.id = mc.cajaId
and p.usuarioId = @usuarioId
and mc.id = @id
/*AND (SELECT CONVERT(VARCHAR(10), mc.fechaHoraApertura, 103)) = (SELECT CONVERT(VARCHAR(10), @fechaCaja, 103))*/
UNION
SELECT [vip].[Cliente_Historial2](c.id, cp.id) as tipocliente, p.id, c.numeroCliente, '', c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Empresa' as tipo  
,ca.numero caja, mc.montoAperturaBob apertura, mc.montoAperturaSus aperturaSus, mc.montoAdministracionBob,montoAdministracionSus, p.nombreBancoCheque cheque, p.numeroCuentaTransferencia transferencia, p.nombreBancoTransferencia bancoTransferencia
, (select e.nombre from [vip].[Empresa] e where e.id = c.empresaId) empresa
FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq
,[vip].[Caja] ca, [vip].[MovimientoCaja] mc
WHERE (SELECT CONVERT(VARCHAR(10), fechaPago, 103)) between (SELECT CONVERT(VARCHAR(10), @fechaCaja, 103))  
and (SELECT CONVERT(VARCHAR(10), @fechaCierreCaja, 103)) 
AND p.clientePaqueteId = cp.id 
AND cp.clienteId = c.id 
AND paq.id = cp.paqueteId
and ca.cajeroId = p.usuarioId
and ca.id = mc.cajaId
and p.usuarioId = @usuarioId
and mc.id = @id
/*AND (SELECT CONVERT(VARCHAR(10), mc.fechaHoraApertura, 103)) = (SELECT CONVERT(VARCHAR(10), @fechaCaja, 103))*/
--WHERE fechaPago >= convert(datetime, '2012-07-01', 101) 
--AND fechaPago <= convert(datetime, '2012-07-31', 101)
END
END
GO

ALTER PROCEDURE [vip].[PagoCliente_TraerXFiltro] 
	@clienteId	nvarchar(10), 
	@fechaPagoInicio	datetime, 
	@fechaPagoFin	datetime,
	@empresaId		nvarchar(10),
	@grupoId		nvarchar(10),
	@formaPago		nvarchar(2),
	@paqueteId		nvarchar(10),
	@servicioId		nvarchar(10),
	@promocionId	nvarchar(10)
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		if(@promocionId='')
		BEGIN
		if(@clienteId='')
		begin
		SELECT [vip].[Cliente_Historial2](c.id, cp.id) as tipocliente, p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId = g.id
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		AND isnull(c.empresaId,'') LIKE '%' + @empresaId + '%'
		UNION
		SELECT [vip].[Cliente_Historial2](c.id, cp.id) as tipocliente, p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND isnull(c.empresaId,'') LIKE '%' + @empresaId + '%'
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId = g.id
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		--WHERE fechaPago >= convert(datetime, '2012-07-01', 101) 
		--AND fechaPago <= convert(datetime, '2012-07-31', 101)
		end
		else
		begin
		SELECT [vip].[Cliente_Historial2](c.id, cp.id) as tipocliente, p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId = g.id
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		AND isnull(c.empresaId,'') LIKE '%' + @empresaId + '%'
		AND c.id = @clienteId
		UNION
		SELECT [vip].[Cliente_Historial2](c.id, cp.id) as tipocliente, p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND ins.grupoId = g.id
		AND isnull(c.empresaId,'') LIKE '%' + @empresaId + '%'
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		AND c.id = @clienteId
		end
		END
		ELSE
		BEGIN
		/*ELSE PROMOCION*/
		if(@clienteId='')
		begin
		SELECT [vip].[Cliente_Historial2](c.id, cp.id) as tipocliente, p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g, [vip].[PromocionCliente] pc
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId = g.id
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		AND isnull(c.empresaId,'') LIKE '%' + @empresaId + '%'
		AND cp.id = pc.clientePaqueteId
		AND pc.id LIKE '%' + @promocionId + '%'
		UNION
		SELECT [vip].[Cliente_Historial2](c.id, cp.id) as tipocliente, p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g, [vip].[PromocionCliente] pc
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND isnull(c.empresaId,'') LIKE '%' + @empresaId + '%'
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId = g.id
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		AND cp.id = pc.clientePaqueteId
		AND pc.id LIKE '%' + @promocionId + '%'
		--WHERE fechaPago >= convert(datetime, '2012-07-01', 101) 
		--AND fechaPago <= convert(datetime, '2012-07-31', 101)
		end
		else
		begin
		SELECT [vip].[Cliente_Historial2](c.id, cp.id) as tipocliente, p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoCliente] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g, [vip].[PromocionCliente] pc
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId = g.id
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		AND isnull(c.empresaId,'') LIKE '%' + @empresaId + '%'
		AND c.id = @clienteId
		AND cp.id = pc.clientePaqueteId
		AND pc.id LIKE '%' + @promocionId + '%'
		UNION
		SELECT [vip].[Cliente_Historial2](c.id, cp.id) as tipocliente, p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g, [vip].[PromocionCliente] pc
		WHERE fechaPago >= @fechaPagoInicio 
		AND fechaPago <= @fechaPagoFin 
		AND p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND ins.grupoId = g.id
		AND isnull(c.empresaId,'') LIKE '%' + @empresaId + '%'
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId LIKE '%' + @grupoId + '%'
		AND p.formaPago LIKE '%' + @formaPago + '%'
		AND cp.paqueteId LIKE '%' + @paqueteId + '%'
		AND g.servicioId LIKE '%' + @servicioId + '%'
		AND c.id = @clienteId
		AND cp.id = pc.clientePaqueteId
		AND pc.id LIKE '%' + @promocionId + '%'
		end
		END
	END
END
GO






IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoEmpresa_TraerPago]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoEmpresa_TraerPago]
END
GO

CREATE PROCEDURE [vip].[PagoEmpresa_TraerPago] 
	@id	nvarchar(10)
AS
BEGIN		
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo , em.nombre empresa, em.nombrePersonaContacto contacto, em.telefono, em.correo, em.direccion
		,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g,  [vip].[Empresa] em
		WHERE 
		p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId = g.id
		and p.empresaId = em.id
		and p.id = @id
		UNION
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  , em.nombre empresa, em.nombrePersonaContacto contacto, em.telefono, em.correo, em.direccion
		,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g,  [vip].[Empresa] em
		WHERE 
		 p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId = g.id
		and p.empresaId = em.id
		and p.id = @id
end
GO





IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[PagoEmpresa_TraerPagoFecha]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[PagoEmpresa_TraerPagoFecha]
END
GO

CREATE PROCEDURE [vip].[PagoEmpresa_TraerPagoFecha] 
	@id	nvarchar(10),
	@fecha datetime
AS
BEGIN		
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo , em.nombre empresa, em.nombrePersonaContacto contacto, em.telefono, em.correo, em.direccion
		,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g,  [vip].[Empresa] em
		WHERE 
		p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId = g.id
		and p.empresaId = em.id
		and p.empresaid = @id
		and p.fechapago = @fecha
		UNION
		SELECT p.id, c.nombre, c.apellidos, paq.nombre as paquete, p.concepto, p.formapago, p.numerofactura, p.nroPago, p.fechaPeriodoInicio, p.fechaPeriodoFin, p.monto, p.fechaPago, p.estado, p.usuarioId, p.fecha, 'Particular' as tipo  , em.nombre empresa, em.nombrePersonaContacto contacto, em.telefono, em.correo, em.direccion
		,(select pro.nombre from [vip].[PromocionCliente] pc, [vip].[Promocion] pro where pc.promocionid= pro.id and pc.clientePaqueteId = cp.id) promocion
		FROM [vip].[PagoEmpresa] p, [vip].[ClientePaquete] cp, [vip].[Cliente] c, [vip].[Paquete] paq, [vip].[Inscripcion] ins
		,[vip].[Grupo] g,  [vip].[Empresa] em
		WHERE 
		 p.clientePaqueteId = cp.id 
		AND cp.clienteId = c.id 
		AND paq.id = cp.paqueteId
		AND cp.id = ins.clientePaqueteId
		AND ins.grupoId = g.id
		and p.empresaId = em.id
		and p.empresaid = @id
		and p.fechapago = @fecha
end
GO