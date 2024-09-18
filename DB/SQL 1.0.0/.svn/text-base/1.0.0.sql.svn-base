-- =============================================
-- Autor:		Diego Zalles - Oliver Menacho
-- Fecha:		06/08/2012
-- Descripción:	Base de datos VIPCENTER
-- Versión:		1.0.0
-- =============================================

PRINT 'INICIANDO CREACION DE LA BASE DE DATOS: VIPCENTER'

USE master;
GO

--IF EXISTS(SELECT name FROM sys.databases WHERE name = 'VIPCENTER')
--	DROP DATABASE VIPCENTER
--GO

IF NOT EXISTS(SELECT name FROM sys.databases WHERE name = 'VIPCENTER')
	CREATE DATABASE VIPCENTER;
GO

USE VIPCENTER
GO

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'vip')
	Exec('CREATE SCHEMA vip')
GO

PRINT 'BASE DE DATOS CREADA'

PRINT 'INICIANDO ELIMINACION DE FOREIGN KEYS [SI LA BASE DE DATOS YA EXISTIA]'

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Empresa' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[Empresa] DROP CONSTRAINT fk_Empresa_Usuario
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Cliente' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[Cliente] DROP CONSTRAINT fk_Cliente_Empresa
	ALTER TABLE [vip].[Cliente] DROP CONSTRAINT fk_Cliente_Usuario
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Paquete' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[Paquete] DROP CONSTRAINT fk_Paquete_Unidad
	ALTER TABLE [vip].[Paquete] DROP CONSTRAINT fk_Paquete_TipoPaquete
	ALTER TABLE [vip].[Paquete] DROP CONSTRAINT fk_Paquete_Usuario
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'ClientePaquete' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[ClientePaquete] DROP CONSTRAINT fk_ClientePaquete_Cliente
	ALTER TABLE [vip].[ClientePaquete] DROP CONSTRAINT fk_ClientePaquete_Paquete
	ALTER TABLE [vip].[ClientePaquete] DROP CONSTRAINT fk_ClientePaquete_Usuario
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'DistribucionPago' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[DistribucionPago] DROP CONSTRAINT fk_DistribucionPago_Cliente
	ALTER TABLE [vip].[DistribucionPago] DROP CONSTRAINT fk_DistribucionPago_Usuario
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Horario' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[Horario] DROP CONSTRAINT fk_Horario_Sala
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Servicio' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[Servicio] DROP CONSTRAINT fk_Servicio_Usuario
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Grupo' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[Grupo] DROP CONSTRAINT fk_Grupo_Horario
	ALTER TABLE [vip].[Grupo] DROP CONSTRAINT fk_Grupo_Servicio
	ALTER TABLE [vip].[Grupo] DROP CONSTRAINT fk_Grupo_Usuario
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'GrupoDia' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[GrupoDia] DROP CONSTRAINT fk_GrupoDia_Grupo
	ALTER TABLE [vip].[GrupoDia] DROP CONSTRAINT fk_GrupoDia_Dia
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Inscripcion' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[Inscripcion] DROP CONSTRAINT fk_Inscripcion_ClientePaquete
	ALTER TABLE [vip].[Inscripcion] DROP CONSTRAINT fk_Inscripcion_Grupo
	ALTER TABLE [vip].[Inscripcion] DROP CONSTRAINT fk_Inscripcion_Usuario
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Licencia' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[Licencia] DROP CONSTRAINT fk_Licencia_ClientePaquete
	ALTER TABLE [vip].[Licencia] DROP CONSTRAINT fk_Licencia_Usuario
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'PagoCliente' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[PagoCliente] DROP CONSTRAINT fk_PagoCliente_ClientePaquete
	ALTER TABLE [vip].[PagoCliente] DROP CONSTRAINT fk_PagoCliente_Usuario
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'PagoEmpresa' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[PagoEmpresa] DROP CONSTRAINT fk_PagoEmpresa_Empresa
	ALTER TABLE [vip].[PagoEmpresa] DROP CONSTRAINT fk_PagoEmpresa_ClientePaquete
	ALTER TABLE [vip].[PagoEmpresa] DROP CONSTRAINT fk_PagoEmpresa_Usuario
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Promocion' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[Promocion] DROP CONSTRAINT fk_Promocion_Usuario
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'PromocionCliente' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[PromocionCliente] DROP CONSTRAINT fk_PromocionCliente_ClientePaquete
	ALTER TABLE [vip].[PromocionCliente] DROP CONSTRAINT fk_PromocionCliente_Promocion
	ALTER TABLE [vip].[PromocionCliente] DROP CONSTRAINT fk_PromocionCliente_Usuario
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Caja' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[Caja] DROP CONSTRAINT fk_Caja_Cajero
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'MovimientoCaja' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[MovimientoCaja] DROP CONSTRAINT fk_MovimientoCaja_Caja
	ALTER TABLE [vip].[MovimientoCaja] DROP CONSTRAINT fk_MovimientoCaja_Usuario
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Asistencia' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[Asistencia] DROP CONSTRAINT fk_Asistencia_Grupo
	ALTER TABLE [vip].[Asistencia] DROP CONSTRAINT fk_Asistencia_Cliente
	ALTER TABLE [vip].[Asistencia] DROP CONSTRAINT fk_Asistencia_Usuario
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Consulta' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[Consulta] DROP CONSTRAINT fk_Consulta_Cliente
	ALTER TABLE [vip].[Consulta] DROP CONSTRAINT fk_Consulta_Usuario
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Seguimiento' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[Seguimiento] DROP CONSTRAINT fk_Seguimiento_Cliente
	ALTER TABLE [vip].[Seguimiento] DROP CONSTRAINT fk_Seguimiento_Usuario
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'DetalleDieta' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[DetalleDieta] DROP CONSTRAINT fk_DetalleDieta_Dieta
	ALTER TABLE [vip].[DetalleDieta] DROP CONSTRAINT fk_DetalleDieta_TipoComida
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'RegistroDieta' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[RegistroDieta] DROP CONSTRAINT fk_RegistroDieta_Dieta
	ALTER TABLE [vip].[RegistroDieta] DROP CONSTRAINT fk_RegistroDieta_Cliente
	ALTER TABLE [vip].[RegistroDieta] DROP CONSTRAINT fk_RegistroDieta_Usuario
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'PruebaEsfuerzo' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[PruebaEsfuerzo] DROP CONSTRAINT fk_PruebaEsfuerzo_Cliente
	ALTER TABLE [vip].[PruebaEsfuerzo] DROP CONSTRAINT fk_PruebaEsfuerzo_Usuario
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'CapacidadPrueba' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[CapacidadPrueba] DROP CONSTRAINT fk_CapacidadPrueba_Capacidad
	ALTER TABLE [vip].[CapacidadPrueba] DROP CONSTRAINT fk_CapacidadPrueba_Prueba
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'PruebaEtapas' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[PruebaEtapas] DROP CONSTRAINT fk_PruebaEtapas_Prueba
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Ejercicio' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[Ejercicio] DROP CONSTRAINT fk_Ejercicio_Grupo
	ALTER TABLE [vip].[Ejercicio] DROP CONSTRAINT fk_Ejercicio_Area
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Rutina' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[Rutina] DROP CONSTRAINT fk_Rutina_Cliente
	ALTER TABLE [vip].[Rutina] DROP CONSTRAINT fk_Rutina_Usuario
END
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'AsignacionRutina' AND xtype='U')
BEGIN
	ALTER TABLE [vip].[AsignacionRutina] DROP CONSTRAINT fk_AsignacionRutina_Rutina
	ALTER TABLE [vip].[AsignacionRutina] DROP CONSTRAINT fk_AsignacionRutina_Ejercicio
	ALTER TABLE [vip].[AsignacionRutina] DROP CONSTRAINT fk_AsignacionRutina_Usuario
END
GO

PRINT 'FIN ELIMINACION DE FOREIGN KEYS'

PRINT 'INICIANDO CREACION DE TABLAS'

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Empresa' AND xtype='U')
	DROP TABLE [vip].[Empresa]
GO
	
CREATE TABLE [vip].[Empresa]
(
	id int identity(1,1) NOT NULL, 
	nombre varchar(100) NOT NULL,
	descripcion varchar(250),  
	nombrePersonaContacto varchar(100) NOT NULL,
	telefono varchar(10), 
	correo varchar(150) NOT NULL,
	direccion varchar(250) NOT NULL, 
	--  Fecha en la cual se comenzó a trabajar con la empresa
	fechaRegistro datetime, 
	/*  Indica si la empresa está activa o inactiva
		* 1 si está activa
		* 0 si no no está activa
	*/
	estado bit NOT NULL,
	-- INFORMACION DE LOGS
	usuarioId uniqueidentifier NOT NULL, 
	fecha datetime NOT NULL DEFAULT GETdate(), 
	CONSTRAINT fk_Empresa_Usuario FOREIGN KEY (usuarioId) REFERENCES [DBO].[aspnet_Users](UserId),
	CONSTRAINT un_Empresa_Nombre UNIQUE (nombre), 	
	CONSTRAINT pk_Empresa PRIMARY KEY (id)	
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Cliente' AND xtype='U')
	DROP TABLE [vip].[Cliente]
	
CREATE TABLE [vip].[Cliente] 
(
	-- Código del cliente secuencial
	id int identity(1,1) NOT NULL, 
	nombre varchar(50) NOT NULL, 
	apellidos varchar(100) NOT NULL, 
	direccion varchar(250) NOT NULL, 
	telefono varchar(10) NOT NULL, 
	celular varchar(10), 
	ci varchar(15), 
	correo varchar(150) NOT NULL, 
	ocupacion varchar(150), 
	lugarTrabajo varchar(250), 
	telefonoTrabajo varchar(10), 
	correoTrabajo varchar(150), 
	fechaNacimiento datetime NOT NULL,
	genero char(1) NOT NULL, 
	estadoCivil char(1) NOT NULL, 
	/*  Almacena si el cliente tiene hijos
		* 1 si tiene hijos 
		* 0 si no tiene hijos
	*/
	tieneHijos bit NOT NULL, 
	numeroHijos int NOT NULL, 
	fechaIngreso datetime NOT NULL, 
	/* Validar si el número de cliente se utilizará
		* Posible uso para correlación con su sistema contable o registro manual
	*/ 
	numeroCliente int NOT NULL, 
	-- Estado del cliente
	estado char(1) NOT NULL, 
	/* Indica si el cliente desea recibir notificaciones por correo
		* a Significa Activo		
		* v Significa Vencido: Los vencidos son los que su pago vencio más de 1 día
		* i Significa Inactivo: Son los clientes que se registraron dados de baja
	*/	
	recibirNotificaciones bit NOT NULL, 
	/* Indica si el cliente viene por alguna empresa
		* Si no tiene empresa este campo tiene valor NULO
	*/
	empresaId int, 
	-- INFORMACION DE LOGS
	usuarioId uniqueidentifier NOT NULL, 
	fecha datetime NOT NULL DEFAULT GETdate(), 
	CONSTRAINT fk_Cliente_Usuario FOREIGN KEY (usuarioId) REFERENCES [DBO].[aspnet_Users](UserId),
	CONSTRAINT ck_Cliente_Genero CHECK (genero IN ('m','f')), 
	CONSTRAINT ck_Cliente_EstadoCivil CHECK (estadoCivil IN ('s','c','d','v')), 
	CONSTRAINT ck_Cliente_NroHijos CHECK (numeroHijos >= 0), 	
	CONSTRAINT ck_Cliente_Estado CHECK (estado IN ('a','i','v')),
	CONSTRAINT pk_Cliente PRIMARY KEY (id), 
	CONSTRAINT fk_Cliente_Empresa FOREIGN KEY (empresaId) REFERENCES [VIP].[Empresa](id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Unidad' AND xtype='U')
	DROP TABLE [vip].[Unidad]
	
CREATE TABLE [vip].[Unidad]
(
	id int identity(1,1) NOT NULL, 
	nombre varchar(100) NOT NULL,
	estado bit NOT NULL,
	CONSTRAINT un_Unidad_Nombre UNIQUE (nombre), 
	CONSTRAINT pk_Unidad PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'TipoPaquete' AND xtype='U')
	DROP TABLE [vip].[TipoPaquete]
	
CREATE TABLE [vip].[TipoPaquete]
(
	id int identity(1,1) NOT NULL, 
	nombre varchar(100) NOT NULL,
	/* LimiteServicios indica si este tipo de paquete limita la cantidad de servicios 
	*  que el cliente pueda contratar
		* NULL Si el tipo de paquete no limita la cantidad de servicios
		* Otro número indicaría cuantos servicios tiene permitidos este tipo de paquete
	*/
	limiteServicios int, 
	estado bit NOT NULL,
	CONSTRAINT ck_TipoPaquete_Limite CHECK (limiteServicios > 0), 
	CONSTRAINT un_TipoPaquete_Nombre UNIQUE (nombre), 
	CONSTRAINT pk_TipoPaquete PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Paquete' AND xtype='U')
	DROP TABLE [vip].[Paquete]
	
CREATE TABLE [vip].[Paquete]
(
	id int identity(1,1) NOT NULL, 
	nombre varchar(100) NOT NULL,
	unidadId int NOT NULL,  
	tiempo int NOT NULL, 
	tipoPaqueteId int NOT NULL, 
	precio decimal(8,2) NOT NULL,  
	/* DiasValidez indica cuantos días se puede usar un paquete antes de que venza. 
		* NULL Si el tipo de paquete no tiene cantidad de días de validez
		* Otro número indicaría cuantos días se puede usar el paquete antes de que venza
	*/
	diasValidez int, 
	fechaRegistro datetime, 
	/*  Indica si el PAQUETE está activo o inactivo
		* 1 si está activo
		* 0 si no no está activo
	*/
	estado bit NOT NULL, 
	-- INFORMACION DE LOGS
	usuarioId uniqueidentifier NOT NULL, 
	fecha datetime NOT NULL DEFAULT GETdate(), 
	CONSTRAINT fk_Paquete_Usuario FOREIGN KEY (usuarioId) REFERENCES [DBO].[aspnet_Users](UserId),
	CONSTRAINT ck_Paquete_Precio CHECK (precio >= 0), 
	CONSTRAINT ck_Paquete_Validez CHECK (diasValidez > 0), 
	CONSTRAINT un_Paquete_Nombre UNIQUE (nombre), 
	CONSTRAINT pk_Paquete PRIMARY KEY (id), 
	CONSTRAINT fk_Paquete_Unidad FOREIGN KEY (unidadId) REFERENCES [VIP].[Unidad](id), 
	CONSTRAINT fk_Paquete_TipoPaquete FOREIGN KEY (tipoPaqueteId) REFERENCES [VIP].[TipoPaquete](id)	
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'ClientePaquete' AND xtype='U')
	DROP TABLE [vip].[ClientePaquete]
	
CREATE TABLE [vip].[ClientePaquete]
(
	id int identity(1,1) NOT NULL, 
	clienteId int NOT NULL,
	paqueteId int NOT NULL,
	-- Fecha de inscripción del cliente al servicio.
	fechaRegistro datetime, 
	/*  Indica si la SUSCRIPCION está activa o inactiva
		* 1 si está activa
		* 0 si no no está activa
	*/
	estado bit NOT NULL,
	-- INFORMACION DE LOGS
	usuarioId uniqueidentifier NOT NULL, 
	fecha datetime NOT NULL DEFAULT GETdate(), 
	CONSTRAINT fk_ClientePaquete_Usuario FOREIGN KEY (usuarioId) REFERENCES [DBO].[aspnet_Users](UserId),
	CONSTRAINT pk_ClientePaquete PRIMARY KEY (id), 
	CONSTRAINT fk_ClientePaquete_Cliente FOREIGN KEY (clienteId) REFERENCES [VIP].[Cliente](id), 
	CONSTRAINT fk_ClientePaquete_Paquete FOREIGN KEY (paqueteId) REFERENCES [VIP].[Paquete](id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'DistribucionPago' AND xtype='U')
	DROP TABLE [vip].[DistribucionPago]
	
CREATE TABLE [vip].[DistribucionPago]
(
	id int identity(1,1) NOT NULL, 
	clienteId int NOT NULL,
	porcentaje int NOT NULL, 
	/*  Indica si la DISTRIBUCIONPAGO está activa o inactiva
		* 1 si está activa
		* 0 si no no está activa
	*/
	estado bit NOT NULL,
	-- INFORMACION DE LOGS
	usuarioId uniqueidentifier NOT NULL, 
	fecha datetime NOT NULL DEFAULT GETdate(), 
	CONSTRAINT fk_DistribucionPago_Usuario FOREIGN KEY (usuarioId) REFERENCES [DBO].[aspnet_Users](UserId),
	CONSTRAINT un_DistribucionPago_Cliente UNIQUE (clienteId),
	CONSTRAINT ck_DistribucionPago_Porcentaje CHECK (porcentaje > 0 AND porcentaje <= 100), 
	CONSTRAINT fk_DistribucionPago_Cliente FOREIGN KEY (clienteId) REFERENCES [VIP].[Cliente](id),
	CONSTRAINT pk_DistribucionPago PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Sala' AND xtype='U')
	DROP TABLE [vip].[Sala]
	
CREATE TABLE [vip].[Sala]
(
	id int identity(1,1) NOT NULL, 
	nombre varchar(100) NOT NULL,
	/*  Indica si la SALA está activa o inactiva
		* 1 si está activa
		* 0 si no no está activa
	*/
	estado bit NOT NULL,
	CONSTRAINT un_Sala_Nombre UNIQUE (nombre), 
	CONSTRAINT pk_Sala PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Horario' AND xtype='U')
	DROP TABLE [vip].[Horario]
	
CREATE TABLE [vip].[Horario]
(
	id int identity(1,1) NOT NULL, 
	horaInicio varchar(5) NOT NULL, 
	horaFin varchar(5) NOT NULL, 
	salaId int NOT NULL, 
	/*  Indica si el HORARIO está activo o inactivo
		* 1 si está activo
		* 0 si no no está activo
	*/
	estado bit NOT NULL,
	CONSTRAINT fk_Horario_Sala FOREIGN KEY (salaId) REFERENCES [VIP].[Sala](id),
	CONSTRAINT pk_Horario PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Servicio' AND xtype='U')
	DROP TABLE [vip].[Servicio]
	
CREATE TABLE [vip].[Servicio]
(
	id int identity(1,1) NOT NULL, 
	nombre varchar(50) NOT NULL, 
	restriccionHorario bit NOT NULL, 
	/*  Indica si el SERVICIO tiene un máximo de clientes que pueden tomar 
	*   el servicio en el mismo horario
		* NULL si no tiene un cupo máximo
		* Otro número si tiene un cupo máximo
	*/
	cupo int, 
	/*  Indica si el SERVICIO está activo o inactivo
		* 1 si está activo
		* 0 si no no está activo
	*/
	estado bit NOT NULL,
	-- INFORMACION DE LOGS
	usuarioId uniqueidentifier NOT NULL, 
	fecha datetime NOT NULL DEFAULT GETdate(), 
	CONSTRAINT fk_Servicio_Usuario FOREIGN KEY (usuarioId) REFERENCES [DBO].[aspnet_Users](UserId),
	CONSTRAINT ck_Servicio_Cupo CHECK (cupo > 0), 
	CONSTRAINT pk_Servicio PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Grupo' AND xtype='U')
	DROP TABLE [vip].[Grupo]
	
CREATE TABLE [vip].[Grupo]
(
	id int identity(1,1) NOT NULL, 
	nombre varchar(50) NOT NULL, 
	horarioId int NOT NULL,
	servicioId int NOT NULL,  
	/*  Indica si el GRUPO está activo o inactivo
		* 1 si está activo
		* 0 si no no está activo
	*/
	estado bit NOT NULL,
	-- INFORMACION DE LOGS
	usuarioId uniqueidentifier NOT NULL, 
	fecha datetime NOT NULL DEFAULT GETdate(), 
	CONSTRAINT fk_Grupo_Usuario FOREIGN KEY (usuarioId) REFERENCES [DBO].[aspnet_Users](UserId),
	CONSTRAINT un_Grupo_Nombre UNIQUE (nombre), 
	CONSTRAINT fk_Grupo_Horario FOREIGN KEY (horarioId) REFERENCES [VIP].[Horario](id),
	CONSTRAINT fk_Grupo_Servicio FOREIGN KEY (servicioId) REFERENCES [VIP].[Servicio](id),
	CONSTRAINT pk_Grupo PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Dia' AND xtype='U')
	DROP TABLE [vip].[Dia]
	
CREATE TABLE [vip].[Dia]
(
	id int identity(1,1) NOT NULL, 
	nombre varchar(50) NOT NULL, 
	CONSTRAINT un_Dia_Nombre UNIQUE (nombre),
	CONSTRAINT pk_Dia PRIMARY KEY (id)
) 

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'GrupoDia' AND xtype='U')
	DROP TABLE [vip].[GrupoDia]
	
CREATE TABLE [vip].[GrupoDia]
(
	id int identity(1,1) NOT NULL, 
	grupoId int NOT NULL, 
	diaId int NOT NULL,
	CONSTRAINT un_GrupoDia_GrupoDia UNIQUE (grupoId, diaId), 
	CONSTRAINT fk_GrupoDia_Grupo FOREIGN KEY (grupoId) REFERENCES [VIP].[Grupo](id),
	CONSTRAINT fk_GrupoDia_Dia FOREIGN KEY (diaId) REFERENCES [VIP].[Dia](id),
	CONSTRAINT pk_GrupoDia PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Inscripcion' AND xtype='U')
	DROP TABLE [vip].[Inscripcion]

-- INDICA QUE SERVICIO TOMO EL CLIENTE PARA EL PAQUETE CONTRATADO.
CREATE TABLE [vip].[Inscripcion]
(
	id int identity(1,1) NOT NULL, 
	clientePaqueteId int NOT NULL, 
	grupoId int NOT NULL, 
	/*  Indica si la INSCRIPCION está activa o inactiva
		* 1 si está activa
		* 0 si no está activa
	*/
	estado bit NOT NULL,
	-- INFORMACION DE LOGS
	usuarioId uniqueidentifier NOT NULL, 
	fecha datetime NOT NULL DEFAULT GETdate(), 
	CONSTRAINT fk_Inscripcion_Usuario FOREIGN KEY (usuarioId) REFERENCES [DBO].[aspnet_Users](UserId),
	CONSTRAINT fk_Inscripcion_ClientePaquete FOREIGN KEY (clientePaqueteId) REFERENCES [VIP].[ClientePaquete](id) ON DELETE CASCADE,
	CONSTRAINT fk_Inscripcion_Grupo FOREIGN KEY (grupoId) REFERENCES [VIP].[Grupo](id),
	CONSTRAINT pk_Inscripcion PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Licencia' AND xtype='U')
	DROP TABLE [vip].[Licencia]

CREATE TABLE [vip].[Licencia]
(
	id int identity(1,1) NOT NULL, 
	clientePaqueteId int NOT NULL, 
	fechaSolicitud datetime NOT NULL, 
	fechaInicioLicencia datetime NOT NULL, 
	fechaFinLicencia datetime NOT NULL, 
	/*  Indica si la LICENCIA está activa o inactiva
		* 1 si está activa
		* 0 si no está activa
	*/
	estado bit NOT NULL,
	-- INFORMACION DE LOGS
	usuarioId uniqueidentifier NOT NULL, 
	fecha datetime NOT NULL DEFAULT GETdate(), 
	CONSTRAINT fk_Licencia_Usuario FOREIGN KEY (usuarioId) REFERENCES [DBO].[aspnet_Users](UserId),
	CONSTRAINT fk_Licencia_ClientePaquete FOREIGN KEY (clientePaqueteId) REFERENCES [VIP].[ClientePaquete](id),
	CONSTRAINT pk_Licencia PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Intercambio' AND xtype='U')
	DROP TABLE [vip].[Intercambio]
	
CREATE TABLE [vip].[Intercambio]
(
	id int identity(1,1) NOT NULL, 
	nombre varchar(50) NOT NULL, 
	CONSTRAINT un_Intercambio_Nombre UNIQUE (nombre), 
	CONSTRAINT pk_Intercambio PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'PagoCliente' AND xtype='U')
	DROP TABLE [vip].[PagoCliente]

CREATE TABLE [vip].[PagoCliente]
(
	id int identity(1,1) NOT NULL, 
	clientePaqueteId int NOT NULL, 
	concepto varchar(250) NOT NULL, 
	formaPago char(2) NOT NULL, 
	numeroFactura int, 
	digitosTarjeta_12 varchar(12), 
	numeroAprobacionPOS varchar(20), 
	numeroCheque varchar(20), 
	nombreBancoCheque varchar(50), 
	numeroCuentaTransferencia varchar(20),
	nombreBancoTransferencia varchar(50),
	/* Las formas de pago aceptadas son
		* ef: Efectivo
		* ta: Tarjeta de crédito
		* ch: Cheque
		* tr: Transferencia bancaria
		* in: Intercambio
	*/
	intercambioId int, 
	-- Nro secuencial de pago para cada Cliente (ClientePaquete)
	-- Básicamente muestra el número de mensualidad a la que corresponde.
	nroPago int NOT NULL, 
	-- fecha de inicio de cuando corresponde el pago
	fechaPeriodoInicio datetime NOT NULL, 
	-- fecha de fin de cuando corresponde el pago
	fechaPeriodoFin datetime NOT NULL, 
	monto decimal(8,2) NOT NULL, 
	-- Fecha en la cual realizó el pago	
	fechaPago datetime NOT NULL, 	
	/*  Indica si el PAGO está activo o inactivo
		* 1 si está activo
		* 0 si no está activo
	*/
	estado bit NOT NULL,
	-- INFORMACION DE LOGS
	usuarioId uniqueidentifier NOT NULL, 
	fecha datetime NOT NULL DEFAULT GETdate(), 
	CONSTRAINT fk_PagoCliente_Usuario FOREIGN KEY (usuarioId) REFERENCES [DBO].[aspnet_Users](UserId),
	CONSTRAINT ck_PagoCliente_Monto CHECK (monto > 0),	
	CONSTRAINT ck_PagoCliente_FormaPago CHECK (formaPago IN ('ef','ta','ch','tr','in')),
	CONSTRAINT fk_PagoCliente_ClientePaquete FOREIGN KEY (clientePaqueteId) REFERENCES [VIP].[ClientePaquete](id),
	CONSTRAINT pk_PagoCliente PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'PagoEmpresa' AND xtype='U')
	DROP TABLE [vip].[PagoEmpresa]
	
CREATE TABLE [vip].[PagoEmpresa]
(
	id int identity(1,1) NOT NULL, 	
	empresaId int NOT NULL, 
	clientePaqueteId int NOT NULL, 
	concepto varchar(250) NOT NULL, 
	formaPago char(2) NOT NULL, 
	numeroFactura int, 
	digitosTarjeta_12 varchar(12), 
	numeroAprobacionPOS varchar(20), 
	numeroCheque varchar(20), 
	nombreBancoCheque varchar(50), 
	numeroCuentaTransferencia varchar(20),
	nombreBancoTransferencia varchar(50),
	/* Las formas de pago aceptadas son
		* ef: Efectivo
		* ta: Tarjeta de crédito
		* ch: Cheque
		* tr: Transferencia bancaria
		* in: Intercambio
	*/
	intercambioId int, 
	-- Nro secuencial de pago para cada Cliente (ClientePaquete)
	-- Básicamente muestra el número de mensualidad a la que corresponde.
	nroPago int NOT NULL, 
	-- fecha de inicio de cuando corresponde el pago
	fechaPeriodoInicio datetime NOT NULL, 
	-- fecha de fin de cuando corresponde el pago
	fechaPeriodoFin datetime NOT NULL, 
	monto decimal(8,2) NOT NULL, 
	-- Fecha en la cual realizó el pago	
	fechaPago datetime NOT NULL, 	
	/*  Indica si el PAGO está activo o inactivo
		* 1 si está activo
		* 0 si no está activo
	*/
	estado bit NOT NULL,
	-- INFORMACION DE LOGS
	usuarioId uniqueidentifier NOT NULL, 
	fecha datetime NOT NULL DEFAULT GETdate(), 
	CONSTRAINT fk_PagoEmpresa_Usuario FOREIGN KEY (usuarioId) REFERENCES [DBO].[aspnet_Users](UserId),
	CONSTRAINT ck_PagoEmpresa_Monto CHECK (monto > 0), 
	CONSTRAINT ck_PagoEmpresa_FormaPago CHECK (formaPago IN ('ef','ta','ch','tr','in')),
	CONSTRAINT fk_PagoEmpresa_Empresa FOREIGN KEY (empresaId) REFERENCES [VIP].[Empresa](id),
	CONSTRAINT fk_PagoEmpresa_ClientePaquete FOREIGN KEY (clientePaqueteId) REFERENCES [VIP].[ClientePaquete](id),
	CONSTRAINT pk_PagoEmpresa PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Promocion' AND xtype='U')
	DROP TABLE [vip].[Promocion]

CREATE TABLE [vip].[Promocion]
(
	id int identity(1,1) NOT NULL, 
	fechaInicio datetime NOT NULL, 
	fechaFin datetime NOT NULL, 
	montoDescuento decimal(8,2) NOT NULL, 
	/*  Indica si la PROMOCION está activa o inactiva
		* 1 si está activa
		* 0 si no está activa
	*/
	estado bit NOT NULL,
	-- INFORMACION DE LOGS
	usuarioId uniqueidentifier NOT NULL, 
	fecha datetime NOT NULL DEFAULT GETdate(), 
	CONSTRAINT fk_Promocion_Usuario FOREIGN KEY (usuarioId) REFERENCES [DBO].[aspnet_Users](UserId),
	CONSTRAINT ck_Promocion_Monto CHECK (montoDescuento > 0),
	CONSTRAINT pk_Promocion PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'PromocionCliente' AND xtype='U')
	DROP TABLE [vip].[PromocionCliente]

CREATE TABLE [vip].[PromocionCliente]
(
	id int identity(1,1) NOT NULL, 
	clientePaqueteId int NOT NULL, 
	promocionId int NOT NULL, 
	fechaAsignacion datetime NOT NULL, 
	/*  Indica si la PROMOCION del CLIENTE está activa o inactiva
		* 1 si está activa
		* 0 si no está activa
	*/
	estado bit NOT NULL,
	-- INFORMACION DE LOGS
	usuarioId uniqueidentifier NOT NULL, 
	fecha datetime NOT NULL DEFAULT GETdate(), 
	CONSTRAINT fk_PromocionCliente_Usuario FOREIGN KEY (usuarioId) REFERENCES [DBO].[aspnet_Users](UserId),
	CONSTRAINT fk_PromocionCliente_ClientePaquete FOREIGN KEY (clientePaqueteId) REFERENCES [VIP].[ClientePaquete](id),
	CONSTRAINT fk_PromocionCliente_Promocion FOREIGN KEY (promocionId) REFERENCES [VIP].[Promocion](id),
	CONSTRAINT pk_PromocionCliente PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Caja' AND xtype='U')
	DROP TABLE [vip].[Caja]

CREATE TABLE [vip].[Caja]
(
	id int identity(1,1) NOT NULL, 
	numero int NOT NULL, 
	-- El cajero debe estar vinculado a algun usuario de ROL: CAJERO
	cajeroId uniqueidentifier NOT NULL, 
	fechaCreacion datetime NOT NULL, 
	/*  Indica si la PROMOCION del CLIENTE está activa o inactiva
		* 1 si está activa
		* 0 si no está activa
	*/
	estado bit NOT NULL,
	CONSTRAINT un_Caja_Numero UNIQUE (numero),
	CONSTRAINT ck_Caja_Numero CHECK (numero > 0), 
	CONSTRAINT fk_Caja_Cajero FOREIGN KEY (cajeroId) REFERENCES [DBO].[aspnet_Users](UserId),
	CONSTRAINT pk_Caja PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'MovimientoCaja' AND xtype='U')
	DROP TABLE [vip].[MovimientoCaja]

CREATE TABLE [vip].[MovimientoCaja]
(
	id int identity(1,1) NOT NULL, 
	cajaId int NOT NULL, 
	fechaHoraApertura datetime NOT NULL, 
	montoApertura decimal(8,2) NOT NULL,
	fechaHoraCierre datetime, 
	montoCierre decimal(8,2) NOT NULL, 
	-- Monto entregado a Administración
	montoAdministracion decimal(8,2) NOT NULL,	 
	/*  Indica si la CAJA del CAJERO está abierta o cerrada
		* 1 si está cerrada
		* 0 si está abierta
	*/
	estado bit NOT NULL,
	-- INFORMACION DE LOGS
	usuarioId uniqueidentifier NOT NULL, 
	fecha datetime NOT NULL DEFAULT GETdate(), 
	CONSTRAINT fk_MovimientoCaja_Usuario FOREIGN KEY (usuarioId) REFERENCES [DBO].[aspnet_Users](UserId),
	CONSTRAINT ck_MovimientoCaja_MontoApertura CHECK (montoApertura >= 0),
	CONSTRAINT ck_MovimientoCaja_MontoCierre CHECK (montoCierre >= 0),
	CONSTRAINT ck_MovimientoCaja_MontoAdministracion CHECK (montoAdministracion >= 0 AND montoAdministracion <= montoCierre),
	CONSTRAINT fk_MovimientoCaja_Caja FOREIGN KEY (cajaId) REFERENCES [VIP].[Caja](id),
	CONSTRAINT pk_MovimientoCaja PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Asistencia' AND xtype='U')
	DROP TABLE [vip].[Asistencia]

CREATE TABLE [vip].[Asistencia]
(
	id int identity(1,1) NOT NULL, 
	grupoId int NOT NULL, 
	clienteId int NOT NULL, 
	/*  Indica si el tipo de inscripción fue manual o biométrico
		* 1 si fue manual
		* 0 si fue biométrico
	*/
	tipoRegistro bit NOT NULL, 	
	-- IP del equipo biométrico
	ipEquipo varchar(20), 
	fechaRegistro datetime NOT NULL, 	
	/*  Indica si la ASISTENCIA está activa o inactiva
		* 1 si está activa
		* 0 si no está activa
	*/
	estado bit NOT NULL,
	-- INFORMACION DE LOGS
	usuarioId uniqueidentifier NOT NULL, 
	fecha datetime NOT NULL DEFAULT GETdate(), 
	CONSTRAINT fk_Asistencia_Usuario FOREIGN KEY (usuarioId) REFERENCES [DBO].[aspnet_Users](UserId),
	CONSTRAINT fk_Asistencia_Grupo FOREIGN KEY (grupoId) REFERENCES [VIP].[Grupo](id),
	CONSTRAINT fk_Asistencia_Cliente FOREIGN KEY (clienteId) REFERENCES [VIP].[Cliente](id),
	CONSTRAINT pk_Asistencia PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Consulta' AND xtype='U')
	DROP TABLE [vip].[Consulta]

CREATE TABLE [vip].[Consulta]
(
	id int identity(1,1) NOT NULL, 
	clienteId int NOT NULL,
	fechaConsulta datetime NOT NULL, 	
	peso decimal(8,2) NOT NULL, 
	talla decimal(8,2) NOT NULL, 
	imc decimal(8,2) NOT NULL, 
	pa decimal(8,2) NOT NULL, 
	fr decimal(8,2) NOT NULL, 
	fc decimal(8,2) NOT NULL, 
	pulso decimal(8,2) NOT NULL, 
	cabeza varchar(250) NOT NULL,
	cardioPulmonar varchar(250) NOT NULL,
	abdomen varchar(250) NOT NULL,
	genitoUrinario varchar(250) NOT NULL,
	extremidades varchar(250) NOT NULL,
	antPatologicos varchar(500) NOT NULL,
	enfermedadesActuales varchar(500) NOT NULL,
	tabaco bit NOT NULL, 
	/*  Indica si el cliente consume alcohol
		* s: SI
		* a: A veces
		* s: Socialmente
		* n: Nunca
	*/
	alcohol char(1) NOT NULL, 
	medicamentos varchar(500) NOT NULL,
	/*  Indica el tipo de actividad que realizá el cliente
		* s: Sedentarismo
		* l: Leve
		* n: Normal
		* m: Mucha
	*/
	estiloActividad char(1) NOT NULL,
	descripcionActividad varchar(2500) NOT NULL,
	-- Registra si realiza Spinning, Aparatos, Aerobicos, Otros
	tipoActividad varchar(250) NOT NULL,
	conclusion varchar(500) NOT NULL,
	/*  Indica si la ASISTENCIA está activa o inactiva
		* 1 si está activa
		* 0 si no está activa
	*/
	estado bit NOT NULL,
	-- INFORMACION DE LOGS
	usuarioId uniqueidentifier NOT NULL, 
	fecha datetime NOT NULL DEFAULT GETdate(), 
	CONSTRAINT fk_Consulta_Usuario FOREIGN KEY (usuarioId) REFERENCES [DBO].[aspnet_Users](UserId),
	CONSTRAINT ck_Consulta_Alcohol CHECK (alcohol IN('s','a','s','n')),
	CONSTRAINT ck_Consulta_EstiloActividad CHECK (estiloActividad IN('s','l','n','m')),
	CONSTRAINT fk_Consulta_Cliente FOREIGN KEY (clienteId) REFERENCES [VIP].[Cliente](id),
	CONSTRAINT pk_Consulta PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Seguimiento' AND xtype='U')
	DROP TABLE [vip].[Seguimiento]

CREATE TABLE [vip].[Seguimiento]
(
	id int identity(1,1) NOT NULL, 
	clienteId int NOT NULL, 
	peso decimal(8,2) NOT NULL,
	cuello decimal(8,2) NOT NULL,
	cintura decimal(8,2) NOT NULL,
	pecho decimal(8,2) NOT NULL,
	brazoIzq decimal(8,2) NOT NULL,
	brazoDer decimal(8,2) NOT NULL,
	muneca decimal(8,2) NOT NULL,
	musloIzq decimal(8,2) NOT NULL,
	musloDer decimal(8,2) NOT NULL,
	cadera decimal(8,2) NOT NULL,
	pantorrillaIzq decimal(8,2) NOT NULL,
	pantorrillaDer decimal(8,2) NOT NULL,
	gluteos decimal(8,2) NOT NULL,	
	estatura decimal(8,2) NOT NULL,	
	ritmoCardiaco decimal(8,2) NOT NULL,	
	presionAlterial decimal(8,2) NOT NULL,	
	grasaCorporal decimal(8,2) NOT NULL,	
	imc decimal(8,2) NOT NULL,	
	fechaSeguimiento datetime NOT NULL, 	
	/*  Indica si el SEGUIMIENTO está activo o inactivo
		* 1 si está activo
		* 0 si no está activo
	*/
	estado bit NOT NULL,
	-- INFORMACION DE LOGS
	usuarioId uniqueidentifier NOT NULL, 
	fecha datetime NOT NULL DEFAULT GETdate(), 
	CONSTRAINT fk_Seguimiento_Usuario FOREIGN KEY (usuarioId) REFERENCES [DBO].[aspnet_Users](UserId),
	CONSTRAINT ck_Seguimiento_Peso CHECK (peso > 0),
	CONSTRAINT fk_Seguimiento_Cliente FOREIGN KEY (clienteId) REFERENCES [VIP].[Cliente](id),
	CONSTRAINT pk_Seguimiento PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Dieta' AND xtype='U')
	DROP TABLE [vip].[Dieta]

CREATE TABLE [vip].[Dieta]
(
	id int identity(1,1) NOT NULL, 
	nombre varchar(50) NOT NULL,	
	/*  Indica si la ASISTENCIA está activa o inactiva
		* 1 si está activa
		* 0 si no está activa
	*/
	estado bit NOT NULL,
	CONSTRAINT un_Dieta_Nombre UNIQUE (nombre),
	CONSTRAINT pk_Dieta PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'TipoComida' AND xtype='U')
	DROP TABLE [vip].[TipoComida]

CREATE TABLE [vip].[TipoComida]
(
	id int identity(1,1) NOT NULL,
	nombre varchar(50) NOT NULL, 		
	/*  Indica si la ASISTENCIA está activa o inactiva
		* 1 si está activa
		* 0 si no está activa
	*/
	estado bit NOT NULL,
	CONSTRAINT un_TipoComida_Nombre UNIQUE (nombre),
	CONSTRAINT pk_TipoComida PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'DetalleDieta' AND xtype='U')
	DROP TABLE [vip].[DetalleDieta]

CREATE TABLE [vip].[DetalleDieta]
(
	id int identity(1,1) NOT NULL,
	dietaId int NOT NULL, 
	/* Indica en que día de la semana debe realizar la dieta
		* lu: Lunes
		* ma: Martes
		* mi: Miércoles
		* ju: Jueves
		* vi: Viernes
		* sa: Sábado
		* do: Domingo
	*/
	dia char(2) NOT NULL,
	tipoComidaId int NOT NULL, 
	alimento varchar(250) NOT NULL, 
	cantidad varchar(500) NOT NULL, 
	preparacion varchar(1000),	
	/*  Indica si la ASISTENCIA está activa o inactiva
		* 1 si está activa
		* 0 si no está activa
	*/
	estado bit NOT NULL,
	CONSTRAINT ck_DetalleDieta_Dia CHECK (dia IN('lu','ma','mi','ju','vi','sa','do')),
	CONSTRAINT fk_DetalleDieta_Dieta FOREIGN KEY (dietaId) REFERENCES [VIP].[Dieta](id),
	CONSTRAINT fk_DetalleDieta_TipoComida FOREIGN KEY (tipoComidaId) REFERENCES [VIP].[TipoComida](id),
	CONSTRAINT pk_DetalleDieta PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'RegistroDieta' AND xtype='U')
	DROP TABLE [vip].[RegistroDieta]

CREATE TABLE [vip].[RegistroDieta]
(
	id int identity(1,1) NOT NULL,
	pesoMeta decimal(8,2) NOT NULL, 		
	objetivo varchar(500) NOT NULL,
	sugerencias varchar(500),
	preparaciones varchar(500),
	recomendaciones varchar(500),
	fechaInicio datetime NOT NULL,
	fechaFin datetime NOT NULL,
	dietaId int NOT NULL,
	clienteId int NOT NULL,
	fechaRegistro datetime NOT NULL,
	/*  Indica si la ASIGNACION de la DIETA está activa o inactiva
		* 1 si está activa
		* 0 si no está activa
	*/
	estado bit NOT NULL,
	-- INFORMACION DE LOGS
	usuarioId uniqueidentifier NOT NULL, 
	fecha datetime NOT NULL DEFAULT GETdate(), 
	CONSTRAINT fk_RegistroDieta_Usuario FOREIGN KEY (usuarioId) REFERENCES [DBO].[aspnet_Users](UserId),
	CONSTRAINT ck_RegistroDieta_Peso CHECK (pesoMeta > 0),
	CONSTRAINT fk_RegistroDieta_Dieta FOREIGN KEY (dietaId) REFERENCES [VIP].[Dieta](id),
	CONSTRAINT fk_RegistroDieta_Cliente FOREIGN KEY (clienteId) REFERENCES [VIP].[Cliente](id),
	CONSTRAINT pk_RegistroDieta PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'PruebaEsfuerzo' AND xtype='U')
	DROP TABLE [vip].[PruebaEsfuerzo]

CREATE TABLE [vip].[PruebaEsfuerzo]
(
	id int identity(1,1) NOT NULL,
	clienteId int NOT NULL,
	fechaRegistro datetime NOT NULL,
	informe varchar(1000),
	sugerencia varchar(1000),
	paFinal varchar(250),
	fcFinal varchar(250),
	frFinal varchar(250),
	/*  Indica si la PRUEBA DE ESFUERZO está activa o inactiva
		* 1 si está activa
		* 0 si no está activa
	*/
	estado bit NOT NULL,
	-- INFORMACION DE LOGS
	usuarioId uniqueidentifier NOT NULL, 
	fecha datetime NOT NULL DEFAULT GETdate(), 
	CONSTRAINT fk_PruebaEsfuerzo_Usuario FOREIGN KEY (usuarioId) REFERENCES [DBO].[aspnet_Users](UserId),
	CONSTRAINT fk_PruebaEsfuerzo_Cliente FOREIGN KEY (clienteId) REFERENCES [VIP].[Cliente](id),
	CONSTRAINT pk_PruebaEsfuerzo PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'CapacidadFuncional' AND xtype='U')
	DROP TABLE [vip].[CapacidadFuncional]

CREATE TABLE [vip].[CapacidadFuncional]
(
	id int identity(1,1) NOT NULL,
	nombre varchar(250) NOT NULL,
	/*  Indica si la PRUEBA DE ESFUERZO está activa o inactiva
		* 1 si está activa
		* 0 si no está activa
	*/
	estado bit NOT NULL,
	CONSTRAINT un_CapacidadFuncional_Nombre UNIQUE (nombre),
	CONSTRAINT pk_CapacidadFuncional PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'CapacidadPrueba' AND xtype='U')
	DROP TABLE [vip].[CapacidadPrueba]

CREATE TABLE [vip].[CapacidadPrueba]
(
	id int identity(1,1) NOT NULL,
	capacidadId int NOT NULL,
	pruebaId int NOT NULL,
	CONSTRAINT fk_CapacidadPrueba_Capacidad FOREIGN KEY (capacidadId) REFERENCES [VIP].[CapacidadFuncional](id),
	CONSTRAINT fk_CapacidadPrueba_Prueba FOREIGN KEY (pruebaId) REFERENCES [VIP].[PruebaEsfuerzo](id),
	CONSTRAINT pk_CapacidadPrueba PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'PruebaEtapas' AND xtype='U')
	DROP TABLE [vip].[PruebaEtapas]

CREATE TABLE [vip].[PruebaEtapas]
(
	id int identity(1,1) NOT NULL,
	pruebaId int NOT NULL,
	etapa varchar(50) NOT NULL,
	tiempo varchar(50) NOT NULL,
	fc varchar(50) NOT NULL,
	velocidad varchar(50) NOT NULL, 
	inclinacion varchar(50) NOT NULL,
	calorias varchar(50) NOT NULL,
	CONSTRAINT fk_PruebaEtapas_Prueba FOREIGN KEY (pruebaId) REFERENCES [VIP].[PruebaEsfuerzo](id),
	CONSTRAINT pk_PruebaEtapas PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Area' AND xtype='U')
	DROP TABLE [vip].[Area]

CREATE TABLE [vip].[Area]
(
	id int identity(1,1) NOT NULL,
	nombre varchar(50) NOT NULL, 		
	/*  Indica si el AREA está activa o inactiva
		* 1 si está activa
		* 0 si no está activa
	*/
	estado bit NOT NULL,
	CONSTRAINT un_Area_Nombre UNIQUE (nombre),
	CONSTRAINT pk_Area PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'GrupoMuscular' AND xtype='U')
	DROP TABLE [vip].[GrupoMuscular]

CREATE TABLE [vip].[GrupoMuscular]
(
	id int identity(1,1) NOT NULL,
	nombre varchar(50) NOT NULL, 		
	/*  Indica si el GRUPO MUSCULAR está activo o inactivo
		* 1 si está activo
		* 0 si no está activo
	*/
	estado bit NOT NULL,
	CONSTRAINT un_GrupoMuscular_Nombre UNIQUE (nombre),
	CONSTRAINT pk_GrupoMuscular PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Ejercicio' AND xtype='U')
	DROP TABLE [vip].[Ejercicio]

CREATE TABLE [vip].[Ejercicio]
(
	id int identity(1,1) NOT NULL,
	-- Ejemplo: Brazo, Tronco anterior, Pierna
	grupoId int NOT NULL, 
	-- Ejemplo: Biceps, Triceps, Pectorales
	areaId int NOT NULL,	
	estado bit NOT NULL,
	CONSTRAINT fk_Ejercicio_Grupo FOREIGN KEY (grupoId) REFERENCES [VIP].[GrupoMuscular](id),
	CONSTRAINT fk_Ejercicio_Area FOREIGN KEY (areaId) REFERENCES [VIP].[Area](id),
	CONSTRAINT pk_Ejercicio PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Rutina' AND xtype='U')
	DROP TABLE [vip].[Rutina]

CREATE TABLE [vip].[Rutina]
(
	id int identity(1,1) NOT NULL,	
	clienteId int NOT NULL, 
	fechaRegistro datetime NOT NULL,	
	objetivo varchar(250) NOT NULL,		
	observaciones varchar(250),	
	estado bit NOT NULL,
	-- INFORMACION DE LOGS
	usuarioId uniqueidentifier NOT NULL, 
	fecha datetime NOT NULL DEFAULT GETdate(), 
	CONSTRAINT fk_Rutina_Usuario FOREIGN KEY (usuarioId) REFERENCES [DBO].[aspnet_Users](UserId),
	CONSTRAINT fk_Rutina_Cliente FOREIGN KEY (clienteId) REFERENCES [VIP].[Cliente](id),
	CONSTRAINT pk_Rutina PRIMARY KEY (id)
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'AsignacionRutina' AND xtype='U')
	DROP TABLE [vip].[AsignacionRutina]

CREATE TABLE [vip].[AsignacionRutina]
(
	id int identity(1,1) NOT NULL,
	rutinaId int NOT NULL,
	ejercicioId int NOT NULL, 
	semana int NOT NULL, 
	series decimal(8,2) NOT NULL, 
	repeticiones decimal(8,2) NOT NULL, 
	cargas decimal(8,2) NOT NULL, 
	estado bit NOT NULL,
	-- INFORMACION DE LOGS
	usuarioId uniqueidentifier NOT NULL, 
	fecha datetime NOT NULL DEFAULT GETdate(), 
	CONSTRAINT fk_AsignacionRutina_Usuario FOREIGN KEY (usuarioId) REFERENCES [DBO].[aspnet_Users](UserId),
	CONSTRAINT ck_AsignacionRutina_Series CHECK (series > 0),
	CONSTRAINT ck_AsignacionRutina_Repeticiones CHECK (repeticiones > 0),
	CONSTRAINT ck_AsignacionRutina_Cargas CHECK (cargas > 0),
	CONSTRAINT ck_AsignacionRutina_Semana CHECK (semana IN (1,2,3,4)),
	CONSTRAINT fk_AsignacionRutina_Rutina FOREIGN KEY (rutinaId) REFERENCES [VIP].[Rutina](id),
	CONSTRAINT fk_AsignacionRutina_Ejercicio FOREIGN KEY (ejercicioId) REFERENCES [VIP].[Ejercicio](id),
	CONSTRAINT pk_AsignacionRutina PRIMARY KEY (id)
)

PRINT 'FIN CREACION DE TABLAS'
/* 4. CONFIGURACION DE USUARIOS */

IF NOT EXISTS (SELECT * FROM master.dbo.syslogins WHERE loginname = N'vip')
	CREATE LOGIN [vip] WITH PASSWORD = 'vip'
GO

CREATE USER [vip] FOR LOGIN [vip] WITH DEFAULT_SCHEMA=[dbo]
GO

GRANT CONNECT TO [vip]
GO

EXEC sp_addrolemember N'db_datareader', N'vip'
GO
EXEC sp_addrolemember N'db_datawriter', N'vip'
GO

GRANT EXECUTE ON SCHEMA:: DBO TO [vip]
GO 

GRANT EXECUTE ON SCHEMA:: VIP TO [vip]
GO

ALTER AUTHORIZATION ON DATABASE::VIPCENTER TO [sa];
GO

USE [VIPCENTER]
GO

/* 1. ELIMINACION DE DATOS ANTERIORES */

BEGIN TRANSACTION

DELETE FROM [vip].[AsignacionRutina]
DELETE FROM [vip].[Rutina]
DELETE FROM [vip].[Ejercicio]
DELETE FROM [vip].[GrupoMuscular]
DELETE FROM [vip].[Area]
DELETE FROM [vip].[PruebaEtapas]
DELETE FROM [vip].[CapacidadPrueba]
DELETE FROM [vip].[CapacidadFuncional]
DELETE FROM [vip].[PruebaEsfuerzo]
DELETE FROM [vip].[RegistroDieta]
DELETE FROM [vip].[DetalleDieta]
DELETE FROM [vip].[TipoComida]
DELETE FROM [vip].[Dieta]
DELETE FROM [vip].[Seguimiento]
DELETE FROM [vip].[Consulta]
DELETE FROM [vip].[Asistencia]
DELETE FROM [vip].[MovimientoCaja]
DELETE FROM [vip].[Caja]
DELETE FROM [vip].[PromocionCliente]
DELETE FROM [vip].[Promocion]
DELETE FROM [vip].[PagoEmpresa]
DELETE FROM [vip].[PagoCliente]
DELETE FROM [vip].[Intercambio]
DELETE FROM [vip].[Licencia]
DELETE FROM [vip].[Inscripcion]
DELETE FROM [vip].[GrupoDia]
DELETE FROM [vip].[Dia]
DELETE FROM [vip].[Grupo]
DELETE FROM [vip].[Servicio]
DELETE FROM [vip].[Horario]
DELETE FROM [vip].[Sala]
DELETE FROM [vip].[DistribucionPago]
DELETE FROM [vip].[ClientePaquete]
DELETE FROM [vip].[Paquete]
DELETE FROM [vip].[TipoPaquete]
DELETE FROM [vip].[Unidad]
DELETE FROM [vip].[Cliente]
DELETE FROM [vip].[Empresa]

/* 2. CARGA DE DATOS BASE */

-- UNIDAD
INSERT INTO VIP.Unidad (nombre, estado) values('Mes',1)
INSERT INTO VIP.Unidad (nombre, estado) values('Semana',1)
INSERT INTO VIP.Unidad (nombre, estado) values('Sesión',1)

-- TIPO PAQUETE
SET IDENTITY_INSERT VIP.TipoPaquete ON
GO
INSERT INTO VIP.TipoPaquete (id, nombre, limiteServicios, estado) values(1,'Pase libre',NULL ,1)
INSERT INTO VIP.TipoPaquete (id, nombre, limiteServicios, estado) values(2,'1 Disciplina',1 ,1)
SET IDENTITY_INSERT VIP.TipoPaquete OFF
GO
-- DIA
SET IDENTITY_INSERT VIP.Dia ON
GO
INSERT INTO VIP.Dia (id, nombre) values(1, 'Lunes')
INSERT INTO VIP.Dia (id, nombre) values(2, 'Martes')
INSERT INTO VIP.Dia (id, nombre) values(3, 'Miércoles')
INSERT INTO VIP.Dia (id, nombre) values(4, 'Jueves')
INSERT INTO VIP.Dia (id, nombre) values(5, 'Viernes')
INSERT INTO VIP.Dia (id, nombre) values(6, 'Sábado')
INSERT INTO VIP.Dia (id, nombre) values(7, 'Domingo')
SET IDENTITY_INSERT VIP.Dia OFF
GO

-- INTERCAMBIO
INSERT INTO VIP.Intercambio (nombre) values('Publicidad')
INSERT INTO VIP.Intercambio (nombre) values('Producto')
INSERT INTO VIP.Intercambio (nombre) values('Otro servicio')

-- TIPO COMIDA
INSERT INTO VIP.TipoComida (nombre, estado) values('Desayuno',1)
INSERT INTO VIP.TipoComida (nombre, estado) values('Merienda',1)
INSERT INTO VIP.TipoComida (nombre, estado) values('Almuerzo',1)
INSERT INTO VIP.TipoComida (nombre, estado) values('Te',1)
INSERT INTO VIP.TipoComida (nombre, estado) values('Cena',1)

-- CAPACIDAD FUNCIONAL
INSERT INTO VIP.CapacidadFuncional (nombre, estado) values('Frecuencia Cardiaca esperada',1)
INSERT INTO VIP.CapacidadFuncional (nombre, estado) values('Dolor precordial',1)
INSERT INTO VIP.CapacidadFuncional (nombre, estado) values('Fatiga muscular',1)
INSERT INTO VIP.CapacidadFuncional (nombre, estado) values('Debilidad',1)
INSERT INTO VIP.CapacidadFuncional (nombre, estado) values('Dolor de piernas',1)
INSERT INTO VIP.CapacidadFuncional (nombre, estado) values('Palidez',1)
INSERT INTO VIP.CapacidadFuncional (nombre, estado) values('Diaforesis',1)
INSERT INTO VIP.CapacidadFuncional (nombre, estado) values('Mareos',1)
INSERT INTO VIP.CapacidadFuncional (nombre, estado) values('Muy buena',1)
INSERT INTO VIP.CapacidadFuncional (nombre, estado) values('Buena',1)
INSERT INTO VIP.CapacidadFuncional (nombre, estado) values('Aceptable',1)
INSERT INTO VIP.CapacidadFuncional (nombre, estado) values('Regular',1)

-- AREA
INSERT INTO VIP.Area (nombre, estado) values('Biceps',1)
INSERT INTO VIP.Area (nombre, estado) values('Triceps',1)
INSERT INTO VIP.Area (nombre, estado) values('Pectorales',1)
INSERT INTO VIP.Area (nombre, estado) values('Gemelos',1)

-- GRUPO MUSCULAR
INSERT INTO VIP.GrupoMuscular (nombre, estado) values('Brazo',1)
INSERT INTO VIP.GrupoMuscular (nombre, estado) values('Tronco anterior',1)
INSERT INTO VIP.GrupoMuscular (nombre, estado) values('Pierna',1)

COMMIT

USE VIPCENTER
GO

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'sec')
	Exec('CREATE SCHEMA sec')
GO

/* 1. ELIMINACION DE FOREIGN KEYS SI LAS TABLAS YA EXISTEN */

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'RolesInPrivileges' AND xtype='U')
BEGIN
	ALTER TABLE [sec].[RolesInPrivileges] DROP CONSTRAINT fk_RolesInPrivileges_Privilege
END
GO

/* 2. CREACION DE TABLAS */

USE VIPCENTER;
GO

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Privileges' AND xtype='U')
	DROP TABLE [sec].[Privileges]
GO
	
CREATE TABLE [sec].[Privileges]
(
	id int identity(1,1) NOT NULL, 
	nombre varchar(100) NOT NULL,	
	descripcion varchar(250) NOT NULL,	
	CONSTRAINT un_Privileges_Nombre UNIQUE (nombre), 	
	CONSTRAINT pk_Privileges PRIMARY KEY (id)	
)

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'RolesInPrivileges' AND xtype='U')
	DROP TABLE [sec].[RolesInPrivileges]

CREATE TABLE [sec].[RolesInPrivileges]
(
	id int identity(1,1) NOT NULL, 
	roleName varchar(256) NOT NULL, 
	privilegeId int NOT NULL,
	CONSTRAINT fk_RolesInPrivileges_Privilege FOREIGN KEY (privilegeId) REFERENCES [sec].[Privileges](id), 
	CONSTRAINT pk_RolesInPrivileges PRIMARY KEY (id)	
)

/* 3. ASIGNACION DE SEGURIDAD AL ESQUEMA SEC */

GRANT EXECUTE ON SCHEMA:: SEC TO [vip]
GO 

IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Cliente' AND xtype='U')
	ALTER TABLE [vip].[Cliente] 
	ADD celular2 varchar(10) null default ''
GO

USE [VIPCENTER]
GO

/* 1. ELIMINACION DE DATOS ANTERIORES */

BEGIN TRANSACTION

DELETE FROM [sec].[RolesInPrivileges]
DELETE FROM [sec].[Privileges]
DELETE FROM [dbo].[aspnet_Profile]
DELETE FROM [dbo].[aspnet_Membership]
DELETE FROM [dbo].[aspnet_UsersInRoles]
DELETE FROM [dbo].[aspnet_Users]
DELETE FROM [dbo].[aspnet_Roles]
DELETE FROM [dbo].[aspnet_Applications]

/* 2. CARGA DE DATOS BASE */

SET IDENTITY_INSERT sec.Privileges ON
GO

DECLARE @ApplicationID uniqueidentifier 
SET @ApplicationID = NEWID()

DECLARE @UserID uniqueidentifier
SET @UserID = NEWID()

-- APLICATIONS
INSERT INTO DBO.aspnet_Applications (ApplicationName, LoweredApplicationName, ApplicationId, Description) 
VALUES ('/', '/', @ApplicationID, null)

-- USERS
INSERT INTO DBO.aspnet_Users (ApplicationId, UserId, UserName, LoweredUserName, MobileAlias, IsAnonymous, LastActivitydate) 
VALUES (@ApplicationID, @UserID, 'admin', 'admin', null, 0, GETdate())

-- MEMBERSHIP
INSERT INTO DBO.aspnet_Membership (ApplicationId, UserId, Password, PasswordFormat, PasswordSalt, MobilePIN, Email,
									LoweredEmail, PasswordQuestion, PasswordAnswer, IsApproved, IsLockedOut, Createdate, 
									LastLogindate, LastPasswordChangeddate, LastLockoutdate, FailedPasswordAttemptCount, FailedPasswordAttemptWindowStart, 
									FailedPasswordAnswerAttemptCount, FailedPasswordAnswerAttemptWindowStart, Comment) 
VALUES (@ApplicationID, @UserID, '2MvPv9Qqr1RfaMAAevtEvwledf0=', 1, 'n506J2Z+t3jQ+QFIkAAB+Q==', null, 'diego.zalles@gmail.com',  
		'diego.zalles@gmail.com', 'Nombre del sistema', 'X9N9P7ZUfekNMgQ3a3ioIwHVD88=', 1, 0, GETdate(), GETdate(), GETdate(), dateADD(YEAR, -5, GETdate()), 2, 
		GETdate(), 0, DATEADD(YEAR, -5, GETdate()), null)
/******* EL USUARIO ADMIN DEL SISTEMA TIENE LA CONTRASEÑA: rootUser ******/

DECLARE @RoleID uniqueidentifier
SET @RoleID = NEWID()

-- ROLES
INSERT INTO DBO.aspnet_Roles (ApplicationId, RoleId, RoleName, LoweredRoleName, Description)  
VALUES (@ApplicationID, @RoleID, 'Administrator', 'administrator', null)

-- USERSINROLES
INSERT INTO DBO.aspnet_UsersInRoles(UserId, RoleId)  
VALUES (@UserID, @RoleID)

-- PRIVILEGES
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(1, 'Roles','Administración de los roles del sistema')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(2, 'Usuarios','Administración de los usuarios del sistema')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(3, 'ConfiguracionCajas','Configuracion de las cajas del sistema')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(4, 'Coberturas','Administración de los tipos de paquetes a ofertar')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(5, 'Paquetes','Administración de los paquetes de servicios del gimnasio')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(6, 'Caja','Apertura y Cierre de caja')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(7, 'Salas','Administración de salas')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(8, 'Horarios','Administración de los horarios disponibles para cada sala')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(9, 'Servicios','Administración de los servicios del gimnasio')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(10, 'Clientes','Administración de los clientes del gimnasio')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(11, 'Empresas','Administración de empresas')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(12, 'EmpresasEliminacion','Eliminación de empresas')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(13, 'rHorarios','Reporte de las disciplinas del gimnasio indicando su sala y horario')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(14, 'DiferenciaCaja','Revisión y corrección de las diferencias en cierre de cajas')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(15, 'Adm. Clientes','Administración de los clientes del gimnasio')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(16, 'Promociones','Administración de las promociones')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(17, 'DistribucionPago','Establecimiento de las distribuciones de pago de los clientes corporativos')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(18, 'PagosEmpresa','Pago de mensualidad de empresas.')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(19, 'ReportePagos','Reporte de pagos.')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(20, 'ReportePromociones','Reporte de promociones.')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(21, 'ReporteDistribucionesPendientes','Reporte de distribuciones de pagos pendientes para clientes corporativos.')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(22, 'ReporteDistribucionesPago','Reporte de distribuciones de pagos corporativas.')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(23, 'Test','Pruebas de configuraciones del sistema.')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(24, 'Parametros','Parámetros del sistema.')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(25, 'Consulta medica','Datos de la consulta médica.')
INSERT INTO SEC.Privileges (id, nombre, descripcion) values(26, 'ReporteClientesActivos','Reporte de clientes activos.')


-- ROLESINPRIVILEGES
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 1)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 2)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 3)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 4)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 5)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 6)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 7)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 8)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 9)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 10)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 11)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 12)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 13)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 14)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 15)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 16)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 17)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 18)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 19)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 20)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 21)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 22)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 23)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 24)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 25)
INSERT INTO SEC.RolesInPrivileges(roleName, privilegeId)  
VALUES ('Administrator', 26)

SET IDENTITY_INSERT sec.Privileges OFF
GO

COMMIT


IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'Version' AND xtype='U')
	DROP TABLE [vip].[Version]
GO
	
CREATE TABLE [vip].[Version]
(
	id int identity(1,1) NOT NULL, 
	-- Ejemplo de version: 1.0.0
	version varchar(20) NOT NULL,
	comentario varchar(200) NULL, 
	fecha datetime NOT NULL DEFAULT GETDATE(),
	constraint un_version unique (version)
)
GO




IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Version_Insertar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Version_Insertar]
END
GO

CREATE PROCEDURE [vip].[Version_Insertar]
	@id			int OUTPUT,
	@version	varchar(20), 
	@comentario	varchar(200)
AS
BEGIN
		INSERT INTO [vip].[Version](version, comentario) 
		VALUES (@version, @comentario)
		SET @Id = SCOPE_IDENTITY() 
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[vip].[Version_ObtenerUltimaVersion]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [vip].[Version_ObtenerUltimaVersion] 
END
GO

CREATE PROCEDURE [vip].[Version_ObtenerUltimaVersion] 
AS
BEGIN		
	SET NOCOUNT ON;
	BEGIN
		SELECT * 
		FROM [vip].[Version] v 
		ORDER BY v.fecha desc 
		RETURN
	END
END
GO



IF EXISTS(SELECT name FROM VIPCENTER..sysobjects WHERE name = N'EmpresaPaquete' AND xtype='U')
	DROP TABLE [vip].[EmpresaPaquete]
GO

CREATE TABLE [vip].[EmpresaPaquete]
(
	empresaId int NOT NULL, 
	paqueteId int NOT NULL, 
	costo decimal(18,2) NOT NULL
	CONSTRAINT fk_EmpresaPaquete_Empresa FOREIGN KEY (empresaId) REFERENCES [VIP].[Empresa](id),
	CONSTRAINT fk_EmpresaPaquete_Paquete FOREIGN KEY (paqueteId) REFERENCES [VIP].[Paquete](id)
)
GO




INSERT INTO [VIP].[Version](version, comentario) VALUES('1.0.0', 'Version Inicial')
GO