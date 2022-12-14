USE [master]
GO
/****** Object:  Database [PruebaAlbatros]    Script Date: 11/13/2022 7:51:39 PM ******/
CREATE DATABASE [PruebaAlbatros]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PruebaAlbatros', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PruebaAlbatros.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PruebaAlbatros_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PruebaAlbatros_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PruebaAlbatros] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PruebaAlbatros].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PruebaAlbatros] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PruebaAlbatros] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PruebaAlbatros] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PruebaAlbatros] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PruebaAlbatros] SET ARITHABORT OFF 
GO
ALTER DATABASE [PruebaAlbatros] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PruebaAlbatros] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PruebaAlbatros] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PruebaAlbatros] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PruebaAlbatros] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PruebaAlbatros] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PruebaAlbatros] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PruebaAlbatros] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PruebaAlbatros] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PruebaAlbatros] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PruebaAlbatros] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PruebaAlbatros] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PruebaAlbatros] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PruebaAlbatros] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PruebaAlbatros] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PruebaAlbatros] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PruebaAlbatros] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PruebaAlbatros] SET RECOVERY FULL 
GO
ALTER DATABASE [PruebaAlbatros] SET  MULTI_USER 
GO
ALTER DATABASE [PruebaAlbatros] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PruebaAlbatros] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PruebaAlbatros] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PruebaAlbatros] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PruebaAlbatros] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PruebaAlbatros] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PruebaAlbatros', N'ON'
GO
ALTER DATABASE [PruebaAlbatros] SET QUERY_STORE = OFF
GO
USE [PruebaAlbatros]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 11/13/2022 7:51:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](150) NOT NULL,
	[rtn] [nvarchar](20) NOT NULL,
	[direccion] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 11/13/2022 7:51:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[id_factura] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[total_impuesto] [float] NOT NULL,
	[total_factura] [float] NOT NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[id_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura_detalle]    Script Date: 11/13/2022 7:51:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura_detalle](
	[id_detalle] [int] NOT NULL,
	[id_factura] [int] NOT NULL,
	[id_producto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio] [float] NOT NULL,
 CONSTRAINT [PK_Factura_detalle] PRIMARY KEY CLUSTERED 
(
	[id_detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Impuesto]    Script Date: 11/13/2022 7:51:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Impuesto](
	[id_impuesto] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](50) NOT NULL,
	[precio] [float] NOT NULL,
 CONSTRAINT [PK_Impuesto] PRIMARY KEY CLUSTERED 
(
	[id_impuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 11/13/2022 7:51:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[id_impuesto] [int] NOT NULL,
	[descripcion] [nvarchar](150) NOT NULL,
	[precio] [float] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([id_cliente], [nombre], [rtn], [direccion]) VALUES (1, N'Luis Martinez', N'080120001547', N'Col San Jorge')
INSERT [dbo].[Clientes] ([id_cliente], [nombre], [rtn], [direccion]) VALUES (2, N'Jhefer Pavon', N'080120054788', N'Villa Corinto')
INSERT [dbo].[Clientes] ([id_cliente], [nombre], [rtn], [direccion]) VALUES (5, N'Luis Padilla', N'080120015789', N'Villa Oriente')
INSERT [dbo].[Clientes] ([id_cliente], [nombre], [rtn], [direccion]) VALUES (6, N'Luis Padilla', N'08012001547', N'Vill Corinto')
INSERT [dbo].[Clientes] ([id_cliente], [nombre], [rtn], [direccion]) VALUES (7, N'Julio Perez', N'08012001547892', N'Vill Sol nuevo')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Impuesto] ON 

INSERT [dbo].[Impuesto] ([id_impuesto], [descripcion], [precio]) VALUES (1, N'Industria', 0.1)
INSERT [dbo].[Impuesto] ([id_impuesto], [descripcion], [precio]) VALUES (2, N'Comercio', 0.12)
INSERT [dbo].[Impuesto] ([id_impuesto], [descripcion], [precio]) VALUES (3, N'Servicio', 0.15)
SET IDENTITY_INSERT [dbo].[Impuesto] OFF
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([id_producto], [id_impuesto], [descripcion], [precio]) VALUES (10, 2, N'Disco ssd', 1200)
INSERT [dbo].[Productos] ([id_producto], [id_impuesto], [descripcion], [precio]) VALUES (11, 1, N'Disco hdd ', 980)
INSERT [dbo].[Productos] ([id_producto], [id_impuesto], [descripcion], [precio]) VALUES (12, 2, N'Computadora Dell ICore 7', 2255.4)
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[Clientes] ([id_cliente])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_cliente]
GO
ALTER TABLE [dbo].[Factura_detalle]  WITH CHECK ADD  CONSTRAINT [FK_Factura_detalle_producto] FOREIGN KEY([id_producto])
REFERENCES [dbo].[Productos] ([id_producto])
GO
ALTER TABLE [dbo].[Factura_detalle] CHECK CONSTRAINT [FK_Factura_detalle_producto]
GO
ALTER TABLE [dbo].[Factura_detalle]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Factura_detalle] FOREIGN KEY([id_factura])
REFERENCES [dbo].[Factura] ([id_factura])
GO
ALTER TABLE [dbo].[Factura_detalle] CHECK CONSTRAINT [FK_Factura_Factura_detalle]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Impuestos] FOREIGN KEY([id_impuesto])
REFERENCES [dbo].[Impuesto] ([id_impuesto])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Impuestos]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarCliente]    Script Date: 11/13/2022 7:51:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarCliente](@id_cliente as int, @nombre as nvarchar(150), @rtn as nvarchar(20), @direccion as nvarchar(150))

AS BEGIN
	UPDATE [dbo].[Clientes] SET [nombre] = @nombre, [rtn] = @rtn, [direccion] = @direccion WHERE [id_cliente] = @id_cliente
END
GO
/****** Object:  StoredProcedure [dbo].[BuscarProducto]    Script Date: 11/13/2022 7:51:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BuscarProducto](@descripcion as nvarchar(150))

AS BEGIN

	select p.descripcion, p.precio, i.precio as impuesto
	from [dbo].[Productos] p join [dbo].[Impuesto] i on p.id_impuesto = i.id_impuesto
	where p.descripcion = @descripcion
END
GO
/****** Object:  StoredProcedure [dbo].[EditarProducto]    Script Date: 11/13/2022 7:51:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarProducto](@id_producto as int, @descripcion as nvarchar(150), @precio as float, @id_impuesto as int)

AS BEGIN
	UPDATE [dbo].[Productos] SET descripcion = @descripcion, precio = @precio, id_impuesto = @id_impuesto
	WHERE id_producto = @id_producto
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarCliente]    Script Date: 11/13/2022 7:51:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarCliente](@id_cliente as int)

AS BEGIN
	DELETE from [dbo].[Clientes] where id_cliente = @id_cliente
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarProducto]    Script Date: 11/13/2022 7:51:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarProducto](@id_producto as int)

AS BEGIN
	DELETE FROM [dbo].[Productos] where id_producto = @id_producto
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarClientes]    Script Date: 11/13/2022 7:51:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarClientes](@nombre as nvarchar(150), @rtn as nvarchar(20), @direccion as nvarchar(150))

AS BEGIN

INSERT INTO Clientes([nombre],[rtn],[direccion]) VALUES(@nombre, @rtn, @direccion)

END
GO
/****** Object:  StoredProcedure [dbo].[InsertarProductos]    Script Date: 11/13/2022 7:51:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarProductos](@descripcion as nvarchar(150), @precio as float, @id_impuesto as int)

AS BEGIN

INSERT INTO [dbo].[Productos](descripcion, precio, id_impuesto) VALUES(@descripcion, @precio, @id_impuesto)

END
GO
/****** Object:  StoredProcedure [dbo].[VerificarExistenciaCliente]    Script Date: 11/13/2022 7:51:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerificarExistenciaCliente] @rtn as nvarchar(20)

AS BEGIN
	IF EXISTS(select rtn from [dbo].[Clientes] where rtn = @rtn)
		select COUNT(*) as Existente from [dbo].[Clientes] where rtn = @rtn
	ELSE
		select 0 as Existente

END
GO
USE [master]
GO
ALTER DATABASE [PruebaAlbatros] SET  READ_WRITE 
GO
