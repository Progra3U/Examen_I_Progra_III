USE [master]
GO
/****** Object:  Database [ExamenIPrograIII]    Script Date: 7/4/2018 6:38:17 PM ******/
CREATE DATABASE [ExamenIPrograIII]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ExamenIPrograIII', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLSERVER\MSSQL\DATA\ExamenIPrograIII.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ExamenIPrograIII_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLSERVER\MSSQL\DATA\ExamenIPrograIII_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ExamenIPrograIII] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ExamenIPrograIII].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ExamenIPrograIII] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ExamenIPrograIII] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ExamenIPrograIII] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ExamenIPrograIII] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ExamenIPrograIII] SET ARITHABORT OFF 
GO
ALTER DATABASE [ExamenIPrograIII] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ExamenIPrograIII] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ExamenIPrograIII] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ExamenIPrograIII] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ExamenIPrograIII] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ExamenIPrograIII] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ExamenIPrograIII] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ExamenIPrograIII] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ExamenIPrograIII] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ExamenIPrograIII] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ExamenIPrograIII] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ExamenIPrograIII] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ExamenIPrograIII] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ExamenIPrograIII] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ExamenIPrograIII] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ExamenIPrograIII] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ExamenIPrograIII] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ExamenIPrograIII] SET RECOVERY FULL 
GO
ALTER DATABASE [ExamenIPrograIII] SET  MULTI_USER 
GO
ALTER DATABASE [ExamenIPrograIII] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ExamenIPrograIII] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ExamenIPrograIII] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ExamenIPrograIII] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ExamenIPrograIII] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ExamenIPrograIII', N'ON'
GO
ALTER DATABASE [ExamenIPrograIII] SET QUERY_STORE = OFF
GO
USE [ExamenIPrograIII]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [ExamenIPrograIII]
GO
/****** Object:  Table [dbo].[Perfiles]    Script Date: 7/4/2018 6:38:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfiles](
	[codPerfil] [int] NOT NULL,
	[nombrePerfil] [nvarchar](50) NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_Perfiles] PRIMARY KEY CLUSTERED 
(
	[codPerfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegistroPersonal]    Script Date: 7/4/2018 6:38:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistroPersonal](
	[codEntrada] [int] IDENTITY(1,1) NOT NULL,
	[nombreEmpleado] [nvarchar](50) NOT NULL,
	[identificacion] [int] NOT NULL,
	[posicion] [nvarchar](50) NOT NULL,
	[area] [nvarchar](50) NOT NULL,
	[fechaEntrada] [nvarchar](50) NULL,
	[horaEntrada] [nvarchar](50) NULL,
	[fechaSalida] [nvarchar](50) NULL,
	[horaSalida] [nvarchar](50) NULL,
 CONSTRAINT [PK_RegistroPersonal_1] PRIMARY KEY CLUSTERED 
(
	[codEntrada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegistroPersonas]    Script Date: 7/4/2018 6:38:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistroPersonas](
	[identificacion] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[apellido] [nvarchar](50) NOT NULL,
	[edad] [int] NOT NULL,
	[correo] [nvarchar](50) NOT NULL,
	[tetefono] [int] NOT NULL,
	[pais] [nvarchar](50) NOT NULL,
	[ciudad] [nvarchar](50) NOT NULL,
	[detalles] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RegistroPersonas] PRIMARY KEY CLUSTERED 
(
	[identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 7/4/2018 6:38:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[nombreUsuario] [nvarchar](50) NOT NULL,
	[pass] [nvarchar](50) NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[nombreUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuariosxPerfiles]    Script Date: 7/4/2018 6:38:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuariosxPerfiles](
	[nombreUsuario] [nvarchar](50) NOT NULL,
	[codPerfil] [int] NOT NULL,
 CONSTRAINT [PK_UsuariosxPerfiles] PRIMARY KEY CLUSTERED 
(
	[nombreUsuario] ASC,
	[codPerfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Perfiles] ([codPerfil], [nombrePerfil], [activo]) VALUES (1, N'administracion', 1)
INSERT [dbo].[Perfiles] ([codPerfil], [nombrePerfil], [activo]) VALUES (2, N'proveduria', 1)
INSERT [dbo].[Perfiles] ([codPerfil], [nombrePerfil], [activo]) VALUES (3, N'mantenimiento', 1)
SET IDENTITY_INSERT [dbo].[RegistroPersonal] ON 

INSERT [dbo].[RegistroPersonal] ([codEntrada], [nombreEmpleado], [identificacion], [posicion], [area], [fechaEntrada], [horaEntrada], [fechaSalida], [horaSalida]) VALUES (14, N'Marcela Lopez', 789456563, N'rrhh', N'rrhh', N'', N'', N'', N'')
INSERT [dbo].[RegistroPersonal] ([codEntrada], [nombreEmpleado], [identificacion], [posicion], [area], [fechaEntrada], [horaEntrada], [fechaSalida], [horaSalida]) VALUES (15, N'Luis Flores', 741258966, N'rrhh', N'rrhh', N'', N'', N'', N'')
INSERT [dbo].[RegistroPersonal] ([codEntrada], [nombreEmpleado], [identificacion], [posicion], [area], [fechaEntrada], [horaEntrada], [fechaSalida], [horaSalida]) VALUES (16, N'Marco Obando', 963221155, N'rrhh', N'rrhh', N'', N'', N'', N'')
INSERT [dbo].[RegistroPersonal] ([codEntrada], [nombreEmpleado], [identificacion], [posicion], [area], [fechaEntrada], [horaEntrada], [fechaSalida], [horaSalida]) VALUES (29, N'Marcela Lopez', 789456563, N'rrhh', N'rrhh', N'03/07/2018', N'09:56', N'03/07/2018', N'10:20')
INSERT [dbo].[RegistroPersonal] ([codEntrada], [nombreEmpleado], [identificacion], [posicion], [area], [fechaEntrada], [horaEntrada], [fechaSalida], [horaSalida]) VALUES (30, N'Luis Flores', 741258966, N'rrhh', N'rrhh', N'03/07/2018', N'09:56', N'03/07/2018', N'09:57')
INSERT [dbo].[RegistroPersonal] ([codEntrada], [nombreEmpleado], [identificacion], [posicion], [area], [fechaEntrada], [horaEntrada], [fechaSalida], [horaSalida]) VALUES (31, N'Marco Obando', 963221155, N'rrhh', N'rrhh', N'03/07/2018', N'09:56', N'03/07/2018', N'10:19')
INSERT [dbo].[RegistroPersonal] ([codEntrada], [nombreEmpleado], [identificacion], [posicion], [area], [fechaEntrada], [horaEntrada], [fechaSalida], [horaSalida]) VALUES (32, N'Julio Madriz', 452155422, N'Administracion', N'Administracion', N'', N'', N'', N'')
INSERT [dbo].[RegistroPersonal] ([codEntrada], [nombreEmpleado], [identificacion], [posicion], [area], [fechaEntrada], [horaEntrada], [fechaSalida], [horaSalida]) VALUES (33, N'Julio Madriz', 452155422, N'Administracion', N'Administracion', N'03/07/2018', N'10:14', N'03/07/2018', N'10:17')
INSERT [dbo].[RegistroPersonal] ([codEntrada], [nombreEmpleado], [identificacion], [posicion], [area], [fechaEntrada], [horaEntrada], [fechaSalida], [horaSalida]) VALUES (34, N'Julio Madriz', 452155422, N'Administracion', N'Administracion', N'03/07/2018', N'10:15', N'03/07/2018', N'10:19')
SET IDENTITY_INSERT [dbo].[RegistroPersonal] OFF
INSERT [dbo].[RegistroPersonas] ([identificacion], [nombre], [apellido], [edad], [correo], [tetefono], [pais], [ciudad], [detalles]) VALUES (56565, N'Sofia', N'Montes', 52, N'sofia@gmail.com', 85236987, N'Venezuela', N'Venezuela', N'ni idea')
INSERT [dbo].[RegistroPersonas] ([identificacion], [nombre], [apellido], [edad], [correo], [tetefono], [pais], [ciudad], [detalles]) VALUES (23652145, N'Martha', N'Dias', 32, N'martha@yahoo.es', 741258963, N'España', N'Madrid', N'Frente a la plaza de toros de Madrid')
INSERT [dbo].[RegistroPersonas] ([identificacion], [nombre], [apellido], [edad], [correo], [tetefono], [pais], [ciudad], [detalles]) VALUES (45698723, N'Pedro', N'Sanchez', 45, N'hdjsh@dfsjlksdfj.com', 74125896, N'Salvador', N'Salvador', N'Los Santos')
INSERT [dbo].[RegistroPersonas] ([identificacion], [nombre], [apellido], [edad], [correo], [tetefono], [pais], [ciudad], [detalles]) VALUES (54634636, N'Sergio', N'Lopez', 65, N'sergio@ice.cr.co', 45445454, N'Costa Rica', N'Puntarenas', N'Frente al super el puerto en Chacarita')
INSERT [dbo].[RegistroPersonas] ([identificacion], [nombre], [apellido], [edad], [correo], [tetefono], [pais], [ciudad], [detalles]) VALUES (78965412, N'Julio', N'Monge', 31, N'julio@gmail.com', 85236989, N'Costa Rica', N'Heredia', N'Frente al mega Super de barva')
INSERT [dbo].[RegistroPersonas] ([identificacion], [nombre], [apellido], [edad], [correo], [tetefono], [pais], [ciudad], [detalles]) VALUES (85232222, N'Marco', N'Lopez', 45, N'marco@hotmail.com', 85285236, N'Costa Rica', N'Limon', N'Frente a ferreteria el Mar')
INSERT [dbo].[Usuarios] ([nombreUsuario], [pass], [activo]) VALUES (N'goku', N'1234', 1)
INSERT [dbo].[Usuarios] ([nombreUsuario], [pass], [activo]) VALUES (N'judas', N'1234', 1)
INSERT [dbo].[Usuarios] ([nombreUsuario], [pass], [activo]) VALUES (N'martha', N'1234', 1)
INSERT [dbo].[Usuarios] ([nombreUsuario], [pass], [activo]) VALUES (N'sofi', N'1234', 1)
INSERT [dbo].[UsuariosxPerfiles] ([nombreUsuario], [codPerfil]) VALUES (N'goku', 3)
INSERT [dbo].[UsuariosxPerfiles] ([nombreUsuario], [codPerfil]) VALUES (N'judas', 1)
INSERT [dbo].[UsuariosxPerfiles] ([nombreUsuario], [codPerfil]) VALUES (N'judas', 2)
INSERT [dbo].[UsuariosxPerfiles] ([nombreUsuario], [codPerfil]) VALUES (N'judas', 3)
INSERT [dbo].[UsuariosxPerfiles] ([nombreUsuario], [codPerfil]) VALUES (N'martha', 2)
INSERT [dbo].[UsuariosxPerfiles] ([nombreUsuario], [codPerfil]) VALUES (N'sofi', 1)
ALTER TABLE [dbo].[UsuariosxPerfiles]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosxPerfiles_Perfiles] FOREIGN KEY([codPerfil])
REFERENCES [dbo].[Perfiles] ([codPerfil])
GO
ALTER TABLE [dbo].[UsuariosxPerfiles] CHECK CONSTRAINT [FK_UsuariosxPerfiles_Perfiles]
GO
ALTER TABLE [dbo].[UsuariosxPerfiles]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosxPerfiles_Usuarios] FOREIGN KEY([nombreUsuario])
REFERENCES [dbo].[Usuarios] ([nombreUsuario])
GO
ALTER TABLE [dbo].[UsuariosxPerfiles] CHECK CONSTRAINT [FK_UsuariosxPerfiles_Usuarios]
GO
USE [master]
GO
ALTER DATABASE [ExamenIPrograIII] SET  READ_WRITE 
GO
