-- IMPORTANTE --
-- ESTE SCRIPT SOLO EJECUTARLO SI SE QUIERE CARGAR EL SISTEMA CON DATOS BASE --

USE VIPCENTER
GO

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
/*
DELETE FROM [sec].[RolesInPrivileges]
DELETE FROM [sec].[Privileges]
DELETE FROM [dbo].[aspnet_Profile]
DELETE FROM [dbo].[aspnet_Membership]
DELETE FROM [dbo].[aspnet_UsersInRoles]
DELETE FROM [dbo].[aspnet_Users]
DELETE FROM [dbo].[aspnet_Roles]
DELETE FROM [dbo].[aspnet_Applications]
*/

DECLARE @UsuarioID uniqueidentifier

EXEC [vip].[Users_ObtenerUsuarioADM]
    @UserId = @UsuarioID OUTPUT

SET IDENTITY_INSERT VIP.Unidad ON
INSERT INTO VIP.Unidad (id, nombre, estado) values(1, 'Mes',1)
INSERT INTO VIP.Unidad (id, nombre, estado) values(2, 'Semana',1)
INSERT INTO VIP.Unidad (id, nombre, estado) values(3, 'Sesión',1)
SET IDENTITY_INSERT VIP.Unidad OFF

SET IDENTITY_INSERT VIP.TipoPaquete ON
INSERT INTO VIP.TipoPaquete (id, nombre, limiteServicios, estado) values(1,'Pase libre',NULL ,1)
INSERT INTO VIP.TipoPaquete (id, nombre, limiteServicios, estado) values(2,'1 Disciplina',1 ,1)
SET IDENTITY_INSERT VIP.TipoPaquete OFF

SET IDENTITY_INSERT VIP.Dia ON
INSERT INTO VIP.Dia (id, nombre) values(1, 'Lunes')
INSERT INTO VIP.Dia (id, nombre) values(2, 'Martes')
INSERT INTO VIP.Dia (id, nombre) values(3, 'Miércoles')
INSERT INTO VIP.Dia (id, nombre) values(4, 'Jueves')
INSERT INTO VIP.Dia (id, nombre) values(5, 'Viernes')
INSERT INTO VIP.Dia (id, nombre) values(6, 'Sábado')
INSERT INTO VIP.Dia (id, nombre) values(7, 'Domingo')
SET IDENTITY_INSERT VIP.Dia OFF

SET IDENTITY_INSERT [vip].[Intercambio] ON
INSERT INTO VIP.Intercambio (id, nombre) values(1, 'Publicidad')
INSERT INTO VIP.Intercambio (id, nombre) values(2, 'Producto')
INSERT INTO VIP.Intercambio (id, nombre) values(3, 'Otro servicio')
SET IDENTITY_INSERT [vip].[Intercambio] OFF

SET IDENTITY_INSERT [vip].[TipoComida] ON
-- TIPO COMIDA
INSERT INTO VIP.TipoComida (id, nombre, estado) values(1, 'Desayuno',1)
INSERT INTO VIP.TipoComida (id, nombre, estado) values(2, 'Merienda',1)
INSERT INTO VIP.TipoComida (id, nombre, estado) values(3, 'Almuerzo',1)
INSERT INTO VIP.TipoComida (id, nombre, estado) values(4, 'Te',1)
INSERT INTO VIP.TipoComida (id, nombre, estado) values(5, 'Cena',1)
SET IDENTITY_INSERT [vip].[TipoComida] OFF

SET IDENTITY_INSERT [vip].[CapacidadFuncional] ON
INSERT INTO VIP.CapacidadFuncional (id, nombre, estado) values(1, 'Frecuencia Cardiaca esperada',1)
INSERT INTO VIP.CapacidadFuncional (id, nombre, estado) values(2, 'Dolor precordial',1)
INSERT INTO VIP.CapacidadFuncional (id, nombre, estado) values(3, 'Fatiga muscular',1)
INSERT INTO VIP.CapacidadFuncional (id, nombre, estado) values(4, 'Debilidad',1)
INSERT INTO VIP.CapacidadFuncional (id, nombre, estado) values(5, 'Dolor de piernas',1)
INSERT INTO VIP.CapacidadFuncional (id, nombre, estado) values(6, 'Palidez',1)
INSERT INTO VIP.CapacidadFuncional (id, nombre, estado) values(7, 'Diaforesis',1)
INSERT INTO VIP.CapacidadFuncional (id, nombre, estado) values(8, 'Mareos',1)
INSERT INTO VIP.CapacidadFuncional (id, nombre, estado) values(9, 'Muy buena',1)
INSERT INTO VIP.CapacidadFuncional (id, nombre, estado) values(10, 'Buena',1)
INSERT INTO VIP.CapacidadFuncional (id, nombre, estado) values(11, 'Aceptable',1)
INSERT INTO VIP.CapacidadFuncional (id, nombre, estado) values(12, 'Regular',1)
SET IDENTITY_INSERT [vip].[CapacidadFuncional] OFF

SET IDENTITY_INSERT [vip].[Area] ON
INSERT INTO VIP.Area (id, nombre, estado) values(1, 'Biceps',1)
INSERT INTO VIP.Area (id, nombre, estado) values(2, 'Triceps',1)
INSERT INTO VIP.Area (id, nombre, estado) values(3, 'Pectorales',1)
INSERT INTO VIP.Area (id, nombre, estado) values(4, 'Gemelos',1)
SET IDENTITY_INSERT [vip].[Area] OFF

SET IDENTITY_INSERT [vip].[GrupoMuscular] ON
INSERT INTO VIP.GrupoMuscular (id, nombre, estado) values(1, 'Brazo',1)
INSERT INTO VIP.GrupoMuscular (id, nombre, estado) values(2, 'Tronco anterior',1)
INSERT INTO VIP.GrupoMuscular (id, nombre, estado) values(3, 'Pierna',1)
SET IDENTITY_INSERT [vip].[GrupoMuscular] OFF

SET IDENTITY_INSERT [vip].[Sala] ON
INSERT [vip].[Sala] ([id], [nombre], [estado]) VALUES (1, N'Aerobics', 1)
INSERT [vip].[Sala] ([id], [nombre], [estado]) VALUES (2, N'Spinning', 1)
INSERT [vip].[Sala] ([id], [nombre], [estado]) VALUES (3, N'Aparatos y Cardiovascular', 1)
INSERT [vip].[Sala] ([id], [nombre], [estado]) VALUES (31, N'Circuit training', 1)
SET IDENTITY_INSERT [vip].[Sala] OFF

SET IDENTITY_INSERT [vip].[Horario] ON
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (11, N'06:30', N'07:30', 1, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (12, N'07:30', N'08:30', 1, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (13, N'08:30', N'09:30', 1, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (14, N'12:30', N'13:30', 1, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (15, N'17:00', N'17:45', 1, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (16, N'17:45', N'18:45', 1, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (17, N'18:45', N'19:30', 1, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (18, N'19:30', N'20:15', 1, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (19, N'20:15', N'21:15', 1, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (20, N'06:15', N'07:00', 2, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (21, N'07:00', N'07:45', 2, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (22, N'09:30', N'10:15', 2, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (23, N'12:30', N'13:15', 2, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (24, N'13:15', N'14:00', 2, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (25, N'19:00', N'19:45', 2, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (26, N'19:45', N'20:30', 2, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (27, N'07:15', N'07:50', 31, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (28, N'12:30', N'13:05', 31, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (29, N'13:15', N'13:50', 31, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (30, N'18:00', N'18:35', 31, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (31, N'19:00', N'19:35', 31, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (32, N'20:00', N'20:35', 31, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (33, N'06:00', N'22:00', 3, 1, 0)
INSERT [vip].[Horario] ([id], [horaInicio], [horaFin], [salaId], [estado], [finDeSemana]) VALUES (34, N'09:00', N'13:00', 3, 1, 1)
SET IDENTITY_INSERT [vip].[Horario] OFF

SET IDENTITY_INSERT [vip].[Servicio] ON
INSERT [vip].[Servicio] ([id], [nombre], [restriccionHorario], [cupo], [estado], [usuarioId], [fecha]) VALUES (1, N'Aerobics', 1, 30, 1, @UsuarioID, GETdate())
INSERT [vip].[Servicio] ([id], [nombre], [restriccionHorario], [cupo], [estado], [usuarioId], [fecha]) VALUES (2, N'Aparatos', 1, NULL, 1, @UsuarioID, GETdate())
INSERT [vip].[Servicio] ([id], [nombre], [restriccionHorario], [cupo], [estado], [usuarioId], [fecha]) VALUES (3, N'Spinning', 1, 20, 1, @UsuarioID, GETdate())
INSERT [vip].[Servicio] ([id], [nombre], [restriccionHorario], [cupo], [estado], [usuarioId], [fecha]) VALUES (4, N'Taebo', 1, 20, 1, @UsuarioID, GETdate())
SET IDENTITY_INSERT [vip].[Servicio] OFF

SET IDENTITY_INSERT [vip].[Paquete] ON
INSERT [vip].[Paquete] ([id], [nombre], [unidadId], [tiempo], [tipoPaqueteId], [precio], [diasValidez], [fechaRegistro], [estado], [usuarioId], [fecha]) VALUES (6, N'1 Disciplina', 1, 1, 2, CAST(320.00 AS Decimal(8, 2)), NULL, GETdate(), 1, @UsuarioID, GETdate())
INSERT [vip].[Paquete] ([id], [nombre], [unidadId], [tiempo], [tipoPaqueteId], [precio], [diasValidez], [fechaRegistro], [estado], [usuarioId], [fecha]) VALUES (7, N'Pase libre', 1, 1, 1, CAST(400.00 AS Decimal(8, 2)), NULL, GETdate(), 1, @UsuarioID, GETdate())
INSERT [vip].[Paquete] ([id], [nombre], [unidadId], [tiempo], [tipoPaqueteId], [precio], [diasValidez], [fechaRegistro], [estado], [usuarioId], [fecha]) VALUES (8, N'Vip plata simple', 1, 3, 2, CAST(840.00 AS Decimal(8, 2)), NULL, GETdate(), 1, @UsuarioID, GETdate())
INSERT [vip].[Paquete] ([id], [nombre], [unidadId], [tiempo], [tipoPaqueteId], [precio], [diasValidez], [fechaRegistro], [estado], [usuarioId], [fecha]) VALUES (9, N'Vip plata ilimitado', 1, 3, 1, CAST(1020.00 AS Decimal(8, 2)), NULL, GETdate(), 1, @UsuarioID, GETdate())
INSERT [vip].[Paquete] ([id], [nombre], [unidadId], [tiempo], [tipoPaqueteId], [precio], [diasValidez], [fechaRegistro], [estado], [usuarioId], [fecha]) VALUES (10, N'Vip oro simple', 1, 6, 2, CAST(1560.00 AS Decimal(8, 2)), NULL, GETdate(), 1, @UsuarioID, GETdate())
INSERT [vip].[Paquete] ([id], [nombre], [unidadId], [tiempo], [tipoPaqueteId], [precio], [diasValidez], [fechaRegistro], [estado], [usuarioId], [fecha]) VALUES (11, N'Vip oro ilimitado', 1, 6, 1, CAST(1920.00 AS Decimal(8, 2)), NULL, GETdate(), 1, @UsuarioID, GETdate())
INSERT [vip].[Paquete] ([id], [nombre], [unidadId], [tiempo], [tipoPaqueteId], [precio], [diasValidez], [fechaRegistro], [estado], [usuarioId], [fecha]) VALUES (12, N'Vip platinum simple', 1, 12, 2, CAST(3000.00 AS Decimal(8, 2)), NULL, GETdate(), 1, @UsuarioID, GETdate())
INSERT [vip].[Paquete] ([id], [nombre], [unidadId], [tiempo], [tipoPaqueteId], [precio], [diasValidez], [fechaRegistro], [estado], [usuarioId], [fecha]) VALUES (13, N'Vip platinum ilimitado', 1, 12, 1, CAST(3600.00 AS Decimal(8, 2)), NULL, GETdate(), 1, @UsuarioID, GETdate())
INSERT [vip].[Paquete] ([id], [nombre], [unidadId], [tiempo], [tipoPaqueteId], [precio], [diasValidez], [fechaRegistro], [estado], [usuarioId], [fecha]) VALUES (14, N'1 semana', 2, 1, 1, CAST(120.00 AS Decimal(8, 2)), 7, GETdate(), 1, @UsuarioID, GETdate())
INSERT [vip].[Paquete] ([id], [nombre], [unidadId], [tiempo], [tipoPaqueteId], [precio], [diasValidez], [fechaRegistro], [estado], [usuarioId], [fecha]) VALUES (15, N'10 sesiones', 3, 10, 1, CAST(200.00 AS Decimal(8, 2)), 30, GETdate(), 1, @UsuarioID, GETdate())
INSERT [vip].[Paquete] ([id], [nombre], [unidadId], [tiempo], [tipoPaqueteId], [precio], [diasValidez], [fechaRegistro], [estado], [usuarioId], [fecha]) VALUES (16, N'15 sesiones', 3, 15, 1, CAST(300.00 AS Decimal(8, 2)), 45, GETdate(), 1, @UsuarioID, GETdate())
INSERT [vip].[Paquete] ([id], [nombre], [unidadId], [tiempo], [tipoPaqueteId], [precio], [diasValidez], [fechaRegistro], [estado], [usuarioId], [fecha]) VALUES (17, N'30', 3, 30, 1, CAST(540.00 AS Decimal(8, 2)), 60, GETdate(), 1, @UsuarioID, GETdate())
SET IDENTITY_INSERT [vip].[Paquete] OFF

SET IDENTITY_INSERT [vip].[Grupo] ON
INSERT [vip].[Grupo] ([id], [nombre], [horarioId], [servicioId], [estado], [usuarioId], [fecha]) VALUES (11, N'', 19, 4, 1, @UsuarioID, GETdate())
INSERT [vip].[Grupo] ([id], [nombre], [horarioId], [servicioId], [estado], [usuarioId], [fecha]) VALUES (12, N'', 17, 4, 1, @UsuarioID, GETdate())
INSERT [vip].[Grupo] ([id], [nombre], [horarioId], [servicioId], [estado], [usuarioId], [fecha]) VALUES (13, N'', 18, 1, 1, @UsuarioID, GETdate())
INSERT [vip].[Grupo] ([id], [nombre], [horarioId], [servicioId], [estado], [usuarioId], [fecha]) VALUES (14, N'', 11, 1, 1, @UsuarioID, GETdate())
INSERT [vip].[Grupo] ([id], [nombre], [horarioId], [servicioId], [estado], [usuarioId], [fecha]) VALUES (15, N'', 33, 2, 1, @UsuarioID, GETdate())
SET IDENTITY_INSERT [vip].[Grupo] OFF

SET IDENTITY_INSERT [vip].[GrupoDia] ON
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (39, 11, 1)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (40, 11, 2)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (41, 11, 3)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (42, 11, 4)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (43, 11, 5)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (44, 12, 1)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (45, 12, 2)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (46, 12, 3)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (47, 12, 4)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (48, 12, 5)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (49, 13, 1)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (50, 13, 2)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (51, 13, 3)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (52, 13, 4)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (53, 13, 5)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (54, 14, 1)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (55, 14, 2)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (56, 14, 3)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (57, 14, 4)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (58, 14, 5)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (59, 15, 1)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (60, 15, 2)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (61, 15, 3)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (62, 15, 4)
INSERT [vip].[GrupoDia] ([id], [grupoId], [diaId]) VALUES (63, 15, 5)
SET IDENTITY_INSERT [vip].[GrupoDia] OFF
GO


delete from [vip].[Parametro]
GO

DECLARE @UsuarioID2 uniqueidentifier
EXEC [vip].[Users_ObtenerUsuarioADM]
    @UserId = @UsuarioID2 OUTPUT

INSERT INTO [vip].[Parametro] (id, nombre, valor, visible, usuarioId, fecha, estado) values('Contable.TipoCambio', 'Tipo de cambio', '6,96', 'true',@UsuarioID2,getdate(),'true')
GO



COMMIT