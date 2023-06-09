USE [master]
GO
/****** Object:  Database [DB_Ferreteria]    Script Date: 4/13/2023 12:16:04 AM ******/
CREATE DATABASE [DB_Ferreteria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_Ferreteria', FILENAME = N'/var/opt/mssql/data/DB_Ferreteria.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_Ferreteria_log', FILENAME = N'/var/opt/mssql/data/DB_Ferreteria_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DB_Ferreteria] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_Ferreteria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_Ferreteria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_Ferreteria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_Ferreteria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_Ferreteria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_Ferreteria] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_Ferreteria] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DB_Ferreteria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_Ferreteria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_Ferreteria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_Ferreteria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_Ferreteria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_Ferreteria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_Ferreteria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_Ferreteria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_Ferreteria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_Ferreteria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_Ferreteria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_Ferreteria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_Ferreteria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_Ferreteria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_Ferreteria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_Ferreteria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_Ferreteria] SET RECOVERY FULL 
GO
ALTER DATABASE [DB_Ferreteria] SET  MULTI_USER 
GO
ALTER DATABASE [DB_Ferreteria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_Ferreteria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_Ferreteria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_Ferreteria] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_Ferreteria] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_Ferreteria] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DB_Ferreteria] SET QUERY_STORE = OFF
GO
USE [DB_Ferreteria]
GO
/****** Object:  User [andres]    Script Date: 4/13/2023 12:16:05 AM ******/
CREATE USER [andres] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [andres]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [andres]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [andres]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [andres]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [andres]
GO
ALTER ROLE [db_datareader] ADD MEMBER [andres]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [andres]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [andres]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [andres]
GO
/****** Object:  Schema [Customers]    Script Date: 4/13/2023 12:16:05 AM ******/
CREATE SCHEMA [Customers]
GO
/****** Object:  Schema [Invoicing]    Script Date: 4/13/2023 12:16:05 AM ******/
CREATE SCHEMA [Invoicing]
GO
/****** Object:  Schema [PaymentMethods]    Script Date: 4/13/2023 12:16:05 AM ******/
CREATE SCHEMA [PaymentMethods]
GO
/****** Object:  Schema [Storage]    Script Date: 4/13/2023 12:16:05 AM ******/
CREATE SCHEMA [Storage]
GO
/****** Object:  Table [Customers].[Clientes]    Script Date: 4/13/2023 12:16:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Customers].[Clientes](
	[Codigo] [int] NOT NULL,
	[PrimerNombre] [varchar](20) NOT NULL,
	[SegundoNombre] [varchar](20) NULL,
	[PrimerApellido] [varchar](20) NOT NULL,
	[SegundoApellido] [varchar](20) NULL,
	[TipoDocumento] [int] NOT NULL,
	[NumeroDocumento] [varchar](15) NOT NULL,
	[CorreoElectronico] [varchar](50) NOT NULL,
	[Celular] [varchar](20) NOT NULL,
	[CodigoDireccion] [int] NOT NULL,
	[FechaCreacion] [smalldatetime] NOT NULL,
	[FechaActualizacion] [smalldatetime] NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Customers].[DireccionClientes]    Script Date: 4/13/2023 12:16:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Customers].[DireccionClientes](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Direccion] [varchar](30) NOT NULL,
	[Departamento] [varchar](20) NOT NULL,
	[Ciudad] [varchar](20) NOT NULL,
	[Barrio] [varchar](20) NOT NULL,
 CONSTRAINT [PK_DireccionClientes] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Customers].[TiposDocumento]    Script Date: 4/13/2023 12:16:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Customers].[TiposDocumento](
	[Codigo] [int] NOT NULL,
	[TipoDocumento] [varchar](10) NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
 CONSTRAINT [PK_TiposDocumento] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Invoicing].[Pedidos]    Script Date: 4/13/2023 12:16:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Invoicing].[Pedidos](
	[Codigo] [bigint] NOT NULL,
	[Factura] [bigint] NOT NULL,
	[FechaCreacion] [smalldatetime] NOT NULL,
	[FechaActualizacion] [smalldatetime] NULL,
	[FechaCierre] [smalldatetime] NULL,
	[IdCliente] [varchar](15) NOT NULL,
	[IdProducto] [int] NOT NULL,
	[CantidadProducto] [int] NOT NULL,
	[ValorTotal] [decimal](18, 2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [Storage].[EstadoFactura]    Script Date: 4/13/2023 12:16:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Storage].[EstadoFactura](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](15) NOT NULL,
 CONSTRAINT [PK_EstadoFactura] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Storage].[EstadoProductos]    Script Date: 4/13/2023 12:16:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Storage].[EstadoProductos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](10) NULL,
 CONSTRAINT [PK_EstadoProductos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Storage].[Inventario]    Script Date: 4/13/2023 12:16:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Storage].[Inventario](
	[Codigo] [bigint] NOT NULL,
	[PCodigo] [int] NOT NULL,
	[idEstado] [int] NOT NULL,
	[CantidadOriginal] [int] NOT NULL,
	[CantidadDisponible] [int] NOT NULL,
	[FechaCreacion] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Inventario] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Storage].[Productos]    Script Date: 4/13/2023 12:16:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Storage].[Productos](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[ValorUnitario] [decimal](8, 2) NOT NULL,
	[UnidadCodigo] [int] NOT NULL,
	[Peso] [decimal](5, 2) NOT NULL,
	[VolumenEmpaque] [decimal](5, 2) NOT NULL,
	[FechaCreacion] [smalldatetime] NOT NULL,
	[FechaActualizacion] [smalldatetime] NULL,
	[idEstado] [int] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Storage].[Unidades]    Script Date: 4/13/2023 12:16:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Storage].[Unidades](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Unidades] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [Storage].[EstadoFactura] ON 

INSERT [Storage].[EstadoFactura] ([Codigo], [Descripcion]) VALUES (1, N'Pagado')
INSERT [Storage].[EstadoFactura] ([Codigo], [Descripcion]) VALUES (2, N'Pendiente')
INSERT [Storage].[EstadoFactura] ([Codigo], [Descripcion]) VALUES (3, N'Anulado')
SET IDENTITY_INSERT [Storage].[EstadoFactura] OFF
GO
SET IDENTITY_INSERT [Storage].[EstadoProductos] ON 

INSERT [Storage].[EstadoProductos] ([id], [Descripcion]) VALUES (1, N'Activo')
INSERT [Storage].[EstadoProductos] ([id], [Descripcion]) VALUES (2, N'Inactivo')
SET IDENTITY_INSERT [Storage].[EstadoProductos] OFF
GO
SET IDENTITY_INSERT [Storage].[Productos] ON 

INSERT [Storage].[Productos] ([Codigo], [Nombre], [ValorUnitario], [UnidadCodigo], [Peso], [VolumenEmpaque], [FechaCreacion], [FechaActualizacion], [idEstado]) VALUES (1, N'Destornillador Pala', CAST(15000.00 AS Decimal(8, 2)), 4, CAST(5.00 AS Decimal(5, 2)), CAST(20.00 AS Decimal(5, 2)), CAST(N'2023-04-12T07:17:00' AS SmallDateTime), CAST(N'2023-04-12T07:17:00' AS SmallDateTime), 1)
SET IDENTITY_INSERT [Storage].[Productos] OFF
GO
SET IDENTITY_INSERT [Storage].[Unidades] ON 

INSERT [Storage].[Unidades] ([Codigo], [Descripcion]) VALUES (1, N'g')
INSERT [Storage].[Unidades] ([Codigo], [Descripcion]) VALUES (2, N'Kg')
INSERT [Storage].[Unidades] ([Codigo], [Descripcion]) VALUES (3, N'%')
INSERT [Storage].[Unidades] ([Codigo], [Descripcion]) VALUES (4, N'Numerico')
SET IDENTITY_INSERT [Storage].[Unidades] OFF
GO
ALTER TABLE [Customers].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_DireccionClientes] FOREIGN KEY([CodigoDireccion])
REFERENCES [Customers].[DireccionClientes] ([Codigo])
GO
ALTER TABLE [Customers].[Clientes] CHECK CONSTRAINT [FK_Clientes_DireccionClientes]
GO
ALTER TABLE [Customers].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_TiposDocumento] FOREIGN KEY([TipoDocumento])
REFERENCES [Customers].[TiposDocumento] ([Codigo])
GO
ALTER TABLE [Customers].[Clientes] CHECK CONSTRAINT [FK_Clientes_TiposDocumento]
GO
ALTER TABLE [Storage].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_EstadoProductos] FOREIGN KEY([idEstado])
REFERENCES [Storage].[EstadoProductos] ([id])
GO
ALTER TABLE [Storage].[Inventario] CHECK CONSTRAINT [FK_Inventario_EstadoProductos]
GO
ALTER TABLE [Storage].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Productos] FOREIGN KEY([PCodigo])
REFERENCES [Storage].[Productos] ([Codigo])
GO
ALTER TABLE [Storage].[Inventario] CHECK CONSTRAINT [FK_Inventario_Productos]
GO
ALTER TABLE [Storage].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_EstadoProductos] FOREIGN KEY([idEstado])
REFERENCES [Storage].[EstadoProductos] ([id])
GO
ALTER TABLE [Storage].[Productos] CHECK CONSTRAINT [FK_Productos_EstadoProductos]
GO
ALTER TABLE [Storage].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Unidades] FOREIGN KEY([UnidadCodigo])
REFERENCES [Storage].[Unidades] ([Codigo])
GO
ALTER TABLE [Storage].[Productos] CHECK CONSTRAINT [FK_Productos_Unidades]
GO
USE [master]
GO
ALTER DATABASE [DB_Ferreteria] SET  READ_WRITE 
GO
