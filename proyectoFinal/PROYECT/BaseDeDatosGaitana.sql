create database  Gaitana
go
use Gaitana
go	
create table Usuario(

codigo bigint primary key identity(1,1),
numero_id bigint unique not null,
nombre_completo varchar(100)not null,
direccion varchar(100)not null,
cargo varchar(20)not null,
ciudad varchar(30)not null,
e_mail varchar(100)not null,
foto varbinary (max),
profesion varchar(30)not null,
años_experiencia smallint not null,
genero char(1),
titulo varbinary(max),
hoja_de_vida varbinary(max),
clave varchar(100) not null,
registrado_por bigint foreign key references Usuario(codigo),
estado char(1) not null,
PAS char(1)not null
)
select*from Usuario
go
create table detalles_TelefonoUsuario(
codigo bigint primary key identity(1,1),
telefono bigint not null,
num_id bigint foreign key references Usuario(codigo)
)
go
insert into Usuario(numero_id,nombre_completo,direccion,cargo,ciudad,e_mail,profesion,años_experiencia,genero,clave,registrado_por,estado,PAS)values
(123,'Juan Felipe Rodriguez Galindo','cale 1','Administrador','Bogotá','juancholoco2000.61@gmail.com','futbolista',8,'m','123',1,'A','S')
go
insert into detalles_TelefonoUsuario(telefono,num_id)values(1232132,1)
go
create table Jugador (
numero_id bigint primary key,
nombre_completo varchar(100)not null,
telefono bigint not null,
talla real not null,
peso real not null,
direccion varchar(100)not null,
fecha_nacimiento date not null,
foto varbinary (max),
registrado_por bigint foreign key references Usuario(codigo))
go
create table Equipo(
codigo bigint primary key identity(1,1),
nombre varchar(50)not null,
descripcion varchar(200)not null,
registrado_por bigint foreign key references Usuario(codigo)
)
go
select * from Equipo
go
create table Matricula(
codigo bigint primary key identity(1,1),
carnet_eps varbinary (max) not null,
examen_medico varbinary (max) not null,
ficha_deportista varbinary (max) not null,
carta_transferencia varbinary(max),
ti_jugador bigint foreign key references Jugador(numero_id),
codigo_usuario bigint foreign key references Usuario(codigo),
codigo_equipo bigint foreign key references Equipo(codigo)
)
go
create table Test (
codigo tinyint primary key identity(1,1),
nombre varchar(100)not null,
dato_a_pedir varchar(30) not null,
puntaje_prom tinyint not null,
puntaje_min tinyint not null,
Puntaje_max tinyint not null,
codigo_usuario bigint foreign key references Usuario(codigo)
)
go 
create table Seguimiento(
codigo bigint primary key identity(1,1),
tipo varchar(50)not null,
valoracion varchar(100)not null,
puntaje real not null,
codigo_matricula bigint foreign key references Matricula(codigo),
codigo_test tinyint foreign key references test (codigo),
registradopor bigint foreign key references Usuario(codigo)
)
go

-- Fin definicion de Tablas
go 
--procedimientos almacenados
go
--Consulta Telefonos
create proc TELS
@cod bigint
as
select codigo as 'Código',telefono as 'Teléfono',num_id as 'Identificación' from detalles_TelefonoUsuario 
go
--Consulta Log In
	create proc Log_In	
	@usuario bigint,
	@Clave varchar(100),
	@Cargo varchar(20)
	as 
	select * from Usuario where numero_id=@usuario and  clave=@Clave and Cargo=@Cargo and estado= 'A'
go 
--cambio Clave De Usuario
go
create proc CCUPAS
@claven varchar (100),
@PAS char(1),
@numero_id bigint
as
update usuario set clave=@claven , PAS=@PAS where numero_id=@numero_id
go
--consulta primer acceso
create proc PAS
@codigo bigint
as
select * from Usuario where PAS='S' and numero_id=@codigo
go
--Consulta Recovery
create proc RecoveryClave
@codigo bigint
as
select e_mail from Usuario where codigo=@codigo
go
--Consulta foto
create proc consulta_pbx
@cod bigint
as
select foto from Usuario where numero_id = @cod
go
--Procedimientos Almacenados Usuario
--__________________________________________
--_________________________________________________
go
--PA Consulta correo usuario
go
create proc Email_u
@codigo bigint
as
select e_mail,clave from Usuario where numero_id=@codigo 
go
-- PA Insertar Usuario
create proc insertar_u
@numero_id bigint, 
@nombre_completo varchar(100),
@direccion varchar(100),
@cargo varchar(20),
@ciudad varchar(30),
@e_mail varchar(100),
@foto varbinary(max),
@profesion varchar(30),
@años_experiencia smallint, 
@genero char(1),
@titulo varbinary(max),
@hoja_de_vida varbinary(max),
@clave varchar(100), 
@registrado_por bigint,
@estado char(1),
@PA char(1)
as
insert into usuario(numero_id,nombre_completo,direccion,cargo,ciudad,e_mail,foto,profesion,años_experiencia,genero,titulo,hoja_de_vida,clave,registrado_por,estado,PAS)values
(@numero_id,@nombre_completo,@direccion,@cargo,@ciudad,@e_mail,@foto,@profesion,@años_experiencia,@genero,@titulo,@hoja_de_vida,@clave,@registrado_por,@estado,@PA)
go
-- PA Consulta general Usuario inhabilitado
create proc ConsultaG_UD
as
select codigo as 'Codigo', numero_id as'Identificacion', nombre_completo as'Nombre completo',direccion as'Direccion',cargo as'Rol',ciudad as'Ciudad',e_mail as'correo electronico',profesion as'carrera',años_experiencia as'años de experiencia',genero as'sexo' from Usuario where estado='I'

go
-- PA Consulta general Usuario
create proc ConsultaG_u
as
select codigo as 'Codigo', numero_id as'Identificacion', nombre_completo as'Nombre completo',direccion as'Direccion',cargo as'Rol',ciudad as'Ciudad',e_mail as'correo electronico',profesion as'carrera',años_experiencia as'años de experiencia',genero as'sexo' from Usuario where estado='A'
go
-- PA Consultar Nombre de forma especifica por coincidencias numero de identificacion
create proc ConsultaENLOL
@id bigint
as 
select nombre_completo from Usuario where numero_id=@id
go
create proc CCUlol
@id bigint
as
select nombre_completo from Usuario where  codigo=@id
go
-- PA Consultar todos los datos de forma especifica por coincidencias codigo
create proc ConsultaECC_u
@codigo bigint
as 
select * from Usuario where codigo=@codigo and estado='A'

go
--PA consulta especifica identificacion
create proc consultarCEI_u
@id bigint
as
select * from Usuario where numero_id=@id and estado='A'
go
create proc consultarCEIm_u
@id bigint
as
select * from Usuario where numero_id=@id and estado='A'
go 
--PA consulta especifica codigo
create proc ConsultarEC_u
@codigo bigint
as
select * from Usuario where codigo=@codigo and estado='A'
go 
--PA consulta especifica codigo
create proc Ccn
@codigo bigint
as
select codigo from Usuario where numero_id=@codigo
go
-- PA consultar todos los datos de forma especifica por nombre
create proc ConsultaEn_u
@nombre varchar (100)
as
select * from Usuario where Nombre_Completo  like @nombre + '%' and estado='A'

go
-- PA Actualizar usuarios
create proc actualizar_usuario 
@numero_id bigint,
@codpost varchar(100),
@ciudad varchar(30),
@e_mail varchar(100),
@rol varchar(20),
@carrera varchar(30),
@AEXP smallint,
@genero char(1)
as
update usuario set direccion=@codpost,ciudad=@ciudad,e_mail=@e_mail,cargo=@rol,profesion=@carrera,años_experiencia=@AEXP,genero=@genero 
where numero_id=@numero_id
go
--PA Eliminar usuario (se actualiza estado) 
create proc eliminar_empleados
@numero_id bigint,
@estado char(1)
as
update usuario set estado=@estado where codigo=@numero_id
go
--PA Insertar telefono usuario
create proc InsertarTelefono_u
@telefono bigint,
@RP bigint
as
insert into detalles_TelefonoUsuario (telefono,num_id)
values (@telefono,@RP)
go

--Procedimientos Almacenados Matricula
--_________________________________________
--_________________________________________________

go
create proc reg_mat
@EPS varbinary(max),
@EM varbinary(max),
@FD varbinary(max),
@CT varbinary(max),
@TI bigint,
@CU bigint,
@CE bigint
as
insert into Matricula(carnet_eps,examen_medico,ficha_deportista,carta_transferencia,ti_jugador,codigo_usuario,codigo_equipo)values
(@EPS,@EM,@FD,@CT,@TI,@CU,@CE)
go

--Procedimientos Almacenados Jugador
--_________________________________________
--_________________________________________________
go
--PA Insertar jugador 
create proc Insertar_j
@ID bigint,
@nombre varchar(100),
@telefono bigint,
@talla real,
@peso real,
@direccion varchar(100),
@fechanac date,
@foto varbinary(max),	
@registradopor bigint
as
insert into Jugador(numero_id,nombre_completo,telefono,talla,peso,direccion,fecha_nacimiento,foto,registrado_por)
values (@ID,@nombre,@telefono,@talla,@peso,@direccion,@fechanac,@foto,@registradopor)
go
--PA Consulta codigo con numero_id
create proc ConsultaECLL_J
as
select numero_id as 'identificación', nombre_completo as 'nombre',telefono as 'Telefono',talla as 'Estatura',peso as 'Peso', direccion as 'Direccón' from Jugador 
go
--PA Consulta codigo con numero_id
create proc ConsultaECU_J
as
select numero_id from Jugador 
go
--PA Consulta general de todos los registros
create proc ConsultarG_j
as
select * from Jugador
go
--PA consulta especifica por nombre 
create proc consultarEN_j
@nombre varchar(100)
as 
select * from Jugador where nombre_completo like @nombre + '%'
go
--PA consulta general
create proc consultarEJPS
as 
select numero_id , nombre_completo ,foto  from Jugador 
go
--PA consulta especifica por coincidencias por nombre
create proc consultarECN_j
@nombre varchar(100)
as 
select * from Jugador where nombre_completo like @nombre+'%'
go
--PA consulta especifica por coincidencias codigo
create proc consultarECC_j
@codigo bigint
as
select * from Jugador where numero_id like @codigo+ '%'
go
--PA consulta especifica codigo
create Proc ConsultarEC_j
@id bigint
as 
select * from Jugador where numero_id=@id
go
--PA Actualizar jugador
create proc Actualizar_j
@Cod bigint,
@direccion varchar (50),
@talla real,
@peso real,
@tel bigint
as
update Jugador set  direccion=@direccion, talla=@talla, peso=@peso, telefono=@tel where numero_id = @Cod
go
--Procedimientos almacenados Equipo
--_____________________________________
--______________________________________________

go
--PA Insertar Equipo
create proc Insertar_E
@nombre varchar(50),
@descripcion varchar (200),
@registradopor bigint
as
insert into Equipo(nombre,descripcion,registrado_por)
values (@nombre,@descripcion,@registradopor)
go
--PA Consulta general de todos los registros
create proc ConsultarGN_E
as
select nombre from Equipo
go
--PA Consulta general de todos los registros
create proc ConsultarG_E
as
select * from Equipo
go
--PA consulta especifica por nombre 
create proc consultarEN_E
@nombre varchar(50)
as 
select * from Equipo where nombre = @nombre
go
--PA consulta especifica por nombre 
create proc consultarcod
@nombre bigint
as 
select * from Equipo where codigo = @nombre
go
--PA consulta especifica por nombre 
create proc consultarENU_E
@nombre varchar(50)
as 
select codigo from Equipo where nombre = @nombre
go
--PA consulta especifica por coincidencias por nombre
create proc consultarECN_E
@nombre varchar(100)
as 
select * from Equipo where nombre like @nombre+'%'
go
--PA consulta especifica por coincidencias codigo
create proc consultarECC_E
@codigo bigint
as
select * from Equipo where codigo like @codigo+ '%'
go
--PA consulta especifica codigo
create Proc ConsultarEC_E
@codigo bigint
as 
select * from Equipo where codigo=@codigo
go
--PA Actualizar Equipo
create proc Actualizar_E
@codigo bigint,
@nombre varchar(50),
@descripcion varchar (200)
as
update Equipo set  nombre=@nombre, descripcion=@descripcion where codigo = @codigo
go
--Procedimientos almacenados Matricula
--_____________________________________
--______________________________________________

go
--PA Insertar Matricula
create proc Insertar_M
@ceps varbinary(max),
@emed varbinary(max),
@fdep varbinary(max),
@cartat varbinary(max),
@ti bigint,
@codu bigint,
@code bigint
as
insert into Matricula(carnet_eps,examen_medico,ficha_deportista,carta_transferencia,ti_jugador,codigo_usuario,codigo_equipo)
values (@ceps,@emed,@fdep,@cartat,@ti,@codu,@code)
go
--PA Consulta general de todos los registros Matricula
create proc CMAT
as
select codigo from Matricula
go
--PA Consulta general de todos los registros Matricula
create proc ConsultarG_M
as
select * from Matricula
go
--PA consulta especifica codigo Matricula
create Proc ConsultarEC_M
@id bigint
as 
select * from Matricula where codigo=@id
go
--PA consulta especifica codigo Matricula
create Proc ConsultarECTI_M
@codigo bigint
as 
select * from Matricula where ti_jugador=@codigo
go
--PA consulta especifica id Matricula
create Proc ConsultarEID_M
@id bigint
as
select codigo from Matricula where ti_jugador=@id

go
--PA Actualizar Matricula
create proc Actualizar_M
@codigo bigint,
@columna varchar (50),
@datonuevo varchar(100)
as
update Matricula set  @columna=@datonuevo where codigo = @codigo
go
--PA Busqueda antes de registro
create proc BAI
@id bigint
as
select * from Matricula where ti_jugador=@id
GO
--Procedimientos almacenados Test
--_____________________________________
--______________________________________________
go 
--PA Insertar Test
create proc Insertar_T
@nombre varchar(100),
@dato varchar(30),
@min tinyint,
@max tinyint,
@prom tinyint,
@codigouser bigint
as
insert into Test(nombre,dato_a_pedir,puntaje_prom,puntaje_min,Puntaje_max,codigo_usuario)
values(@nombre,@dato,@prom,@min,@max,@codigouser)
go
--PA Consulta general Test
create proc CT
as
select codigo from Test 
go
--PA Consulta general Test
create proc ConsultarG_T
as
select * from Test 
go
--Consulta especifica Test nombre
create proc consultarE_T
@nombre varchar(100) 
as
select * from Test where nombre like @nombre +'%'
go
--Consulta especifica por coincidencia nombre
create proc ConsultarEnC_T
@nombre varchar(100)
as
select * from Test where nombre = @nombre + '%' 
go
--Consulta especifica por dato a pedir
create proc ConsultarED_T
@test varchar(30)
as
select * from Test where dato_a_pedir=@test
go
--Consulta especifica codigo
create proc ConsultarEC_T
@codigo bigint
as
select * from Test where codigo=@codigo
go
--Consulta especifica por coincidencias codigo
create proc ConsultarECC_T
@codigo bigint
as
select * from Test where codigo=@codigo+'%'
go
--PA Actualizar test
create proc Actualizar_t
@codigo bigint,
@dato varchar(30),
@PMinimo tinyint,
@PP tinyint,
@Pmax tinyint
as
update Test set dato_a_pedir=@dato, puntaje_min=@PMinimo,puntaje_prom=@PP,Puntaje_max=@Pmax where codigo = @codigo
go
--Consulta General Test nombre
go
create proc CTnnnnn
as
select nombre from Test
go
--Consulta Previa
create proc CPT
@nom varchar(30)	
as
select * from Test where nombre=@nom
go
--Procedimientos almacenados Seguimiento
--_____________________________________
--______________________________________________
go 
--PA Insertar Seguimiento
create proc Insertar_S
@tipo varchar(50),
@valoracion varchar(100),
@puntaje real,
@codM bigint,
@codT bigint,
@cod bigint
as
insert into Seguimiento(tipo,valoracion,puntaje,codigo_matricula,codigo_test,registradopor)
values(@tipo,@valoracion,@puntaje,@codM,@codT,@cod)
go
--PA Consulta general Seguimiento
create proc ConsultarG_S
as
select codigo,tipo,valoracion,puntaje,codigo_matricula,codigo_test from Seguimiento
go
--PA Consulta especifica Seguimiento codigo
create proc ConsultarEC
@cod bigint
as
select codigo,tipo,valoracion,puntaje,codigo_matricula,codigo_test from Seguimiento where codigo=@cod
go
--PA Consulta especifica Seguimiento Codigo Matricula
create proc ConsultarEM
@cod bigint
as
select codigo,tipo,valoracion,puntaje,codigo_matricula,codigo_test from Seguimiento where codigo_matricula=@cod
go
--PA Consulta especifica Seguimiento codigo test
create proc ConsultarECT
@cod bigint
as
select codigo,tipo,valoracion,puntaje,codigo_matricula,codigo_test from Seguimiento where codigo_test=@cod
go
--Consulta especifica Tipo Seguimiento
create proc consultarET_S
@Tipo varchar(50)
as
select * from Seguimiento where tipo=@Tipo
go
--Consulta especifica por coincidencia Seguimientoe
create proc Consultar_codigotest
@codigo_test bigint
as
select * from Seguimiento where codigo_test=@codigo_test
go
--Consulta especifica codigo
create proc ConsultarEC_S
@codigo bigint
as
select * from Seguimiento where codigo=@codigo
go
--Consulta especifica por coincidencias codigo
create proc ConsultarECC_S
@codigo bigint
as
select * from Seguimiento where codigo=@codigo+'%'
go
--PA Actualizar Seguimiento
create proc Actualizar_S
@cod bigint,
@tipo varchar(50),
@valoracion varchar(100),
@puntaje real,
@codM bigint,
@codT bigint
as
update Seguimiento set tipo=@tipo,valoracion=@valoracion,puntaje=@puntaje,codigo_matricula=@codM,codigo_test=@codT where codigo = @cod
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
go
create proc consulta_telefonousuariosss
@numero_id bigint
as
select Usuario.nombre_completo , detalles_TelefonoUsuario.codigo , detalles_TelefonoUsuario.telefono,detalles_TelefonoUsuario.num_id from detalles_TelefonoUsuario inner join Usuario 
on Usuario.codigo=detalles_TelefonoUsuario.num_id and detalles_TelefonoUsuario.num_id=@numero_id
go
create proc actualizar_telefonosusuario 
@telid bigint,
@tel bigint
as
update detalles_telefonousuario set telefono=@tel 
where  codigo=@telid
go
select * from detalles_TelefonoUsuario
----------------------------------------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------
--tests predeterminados
go
insert into Test(nombre,dato_a_pedir,puntaje_prom,puntaje_min,Puntaje_max,codigo_usuario)
VALUES ('Flexion anterior del tronco','Centímetros',50,10,100,1)
go
insert into Test(nombre,dato_a_pedir,puntaje_prom,puntaje_min,Puntaje_max,codigo_usuario)
VALUES ('salto vertical','Centímetros',50,10,100,1)
go
insert into Test(nombre,dato_a_pedir,puntaje_prom,puntaje_min,Puntaje_max,codigo_usuario)
VALUES ('Tres Bolillos','Centímetros',50,10,100,1)
go
insert into Test(nombre,dato_a_pedir,puntaje_prom,puntaje_min,Puntaje_max,codigo_usuario)
VALUES ('40 metros','Segundos',50,10,100,1)
go
insert into Test(nombre,dato_a_pedir,puntaje_prom,puntaje_min,Puntaje_max,codigo_usuario)
VALUES ('Abdominales en 1 minuto','Repeticiones',50,10,100,1)
go
insert into Test(nombre,dato_a_pedir,puntaje_prom,puntaje_min,Puntaje_max,codigo_usuario)
VALUES ('Test de cooper','Metros',50,10,100,1)
go
insert into Test(nombre,dato_a_pedir,puntaje_prom,puntaje_min,Puntaje_max,codigo_usuario)
VALUES ('Dominio de balon','Repeticiones',50,10,100,1)
go
insert into Test(nombre,dato_a_pedir,puntaje_prom,puntaje_min,Puntaje_max,codigo_usuario)
VALUES ('Autopase y tiro','Repeticiones',50,10,100,1)
go
insert into Test(nombre,dato_a_pedir,puntaje_prom,puntaje_min,Puntaje_max,codigo_usuario)
VALUES ('Conducción','Segundos',50,10,100,1) 
go
insert into Test(nombre,dato_a_pedir,puntaje_prom,puntaje_min,Puntaje_max,codigo_usuario)
VALUES ('Saque de esquina','Repeticiones',50,10,100,1)
go
insert into Test(nombre,dato_a_pedir,puntaje_prom,puntaje_min,Puntaje_max,codigo_usuario)
VALUES ('Autopase conduccion','Segundos',50,10,100,1)
go
insert into Test(nombre,dato_a_pedir,puntaje_prom,puntaje_min,Puntaje_max,codigo_usuario)
VALUES ('Golpeos','Repeticiones',50,10,100,1)
go
insert into Test(nombre,dato_a_pedir,puntaje_prom,puntaje_min,Puntaje_max,codigo_usuario)
VALUES ('tiro penalty','Repeticiones',50,10,100,1)
go
select * from  Test
go
select * from Seguimiento
go 
create proc mejor
as
select * from seguimiento order by puntaje
go 
create proc bajo
as
select * from seguimiento order by puntaje desc
go
create proc Consultarmejoresss
as
select codigo,tipo,valoracion,puntaje,codigo_matricula,codigo_test from Seguimiento order by puntaje asc 
go
create proc Consultarbajos
@cod bigint
as
select codigo,tipo,valoracion,puntaje,codigo_matricula,codigo_test from Seguimiento where codigo_test=@cod order by puntaje desc
