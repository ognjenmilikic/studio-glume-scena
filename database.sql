USE [master]
GO
/****** Object:  Database [StudioGlumeScena]    Script Date: 24.3.2021. 20:05:50 ******/
CREATE DATABASE [StudioGlumeScena]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudioGlumeScena', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\StudioGlumeScena.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StudioGlumeScena_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\StudioGlumeScena_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [StudioGlumeScena] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudioGlumeScena].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudioGlumeScena] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudioGlumeScena] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudioGlumeScena] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudioGlumeScena] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudioGlumeScena] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudioGlumeScena] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudioGlumeScena] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudioGlumeScena] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudioGlumeScena] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudioGlumeScena] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudioGlumeScena] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudioGlumeScena] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudioGlumeScena] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudioGlumeScena] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudioGlumeScena] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StudioGlumeScena] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudioGlumeScena] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudioGlumeScena] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudioGlumeScena] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudioGlumeScena] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudioGlumeScena] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudioGlumeScena] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudioGlumeScena] SET RECOVERY FULL 
GO
ALTER DATABASE [StudioGlumeScena] SET  MULTI_USER 
GO
ALTER DATABASE [StudioGlumeScena] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudioGlumeScena] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudioGlumeScena] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudioGlumeScena] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StudioGlumeScena] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'StudioGlumeScena', N'ON'
GO
ALTER DATABASE [StudioGlumeScena] SET QUERY_STORE = OFF
GO
USE [StudioGlumeScena]
GO
/****** Object:  Table [dbo].[Grupa]    Script Date: 24.3.2021. 20:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grupa](
	[BrojGrupe] [int] IDENTITY(1,1) NOT NULL,
	[VremeCasa] [nvarchar](50) NOT NULL,
	[DanOdrzavanjaCasa] [nvarchar](50) NOT NULL,
	[AktivniZadatak] [nvarchar](max) NOT NULL,
	[JMBGp] [nvarchar](50) NOT NULL,
	[NazivOpstine] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Grupa] PRIMARY KEY CLUSTERED 
(
	[BrojGrupe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lokacija]    Script Date: 24.3.2021. 20:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lokacija](
	[NazivOpsite] [nvarchar](50) NOT NULL,
	[Adresa] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Lokacija] PRIMARY KEY CLUSTERED 
(
	[NazivOpsite] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 24.3.2021. 20:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesor](
	[JMBGp] [nvarchar](50) NOT NULL,
	[Ime] [nvarchar](50) NOT NULL,
	[Prezime] [nvarchar](50) NOT NULL,
	[GodRodjenja] [int] NOT NULL,
	[BrTelefona] [nvarchar](50) NOT NULL,
	[Adresa] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Profesor] PRIMARY KEY CLUSTERED 
(
	[JMBGp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ucenik]    Script Date: 24.3.2021. 20:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ucenik](
	[JMBGu] [nvarchar](50) NOT NULL,
	[Ime] [nvarchar](50) NOT NULL,
	[Prezime] [nvarchar](50) NOT NULL,
	[GodinaRodjenja] [int] NOT NULL,
	[BrTelefona] [nvarchar](50) NOT NULL,
	[Adresa] [nvarchar](50) NOT NULL,
	[PoslednjaPlacenaClanarina] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[BrojGrupe] [int] NOT NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Ucenik] PRIMARY KEY CLUSTERED 
(
	[JMBGu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Grupa] ON 

INSERT [dbo].[Grupa] ([BrojGrupe], [VremeCasa], [DanOdrzavanjaCasa], [AktivniZadatak], [JMBGp], [NazivOpstine]) VALUES (1, N'14:00h', N'Subota', N'Spremiti imitacije jedne domace, jedne divlje zivotinje i jedne ptice. ', N'0209987720016', N'Rakovica')
INSERT [dbo].[Grupa] ([BrojGrupe], [VremeCasa], [DanOdrzavanjaCasa], [AktivniZadatak], [JMBGp], [NazivOpstine]) VALUES (2, N'16:00h', N'Subota', N'Spremiti dramski monolog iz nekog Cehovljevog dela. Tekst nauciti napamet i spremiti izvedbu do 3 minuta', N'2106988710015', N'Rakovica')
INSERT [dbo].[Grupa] ([BrojGrupe], [VremeCasa], [DanOdrzavanjaCasa], [AktivniZadatak], [JMBGp], [NazivOpstine]) VALUES (3, N'18:00h', N'Subota', N'Spremiti komican monolog iz nekog Nusicevog dela. Nauciti tekst napamet i spremiti izvedbu do 3 minuta', N'1203990720016', N'Vozdovac')
INSERT [dbo].[Grupa] ([BrojGrupe], [VremeCasa], [DanOdrzavanjaCasa], [AktivniZadatak], [JMBGp], [NazivOpstine]) VALUES (4, N'11:00h', N'Nedelja', N'Spremiti 5 imitacija ljudi iz tvog okruzenja. Pozeljno je da budu raznih starosnih dobi.', N'0506987710015', N'Vozdovac')
INSERT [dbo].[Grupa] ([BrojGrupe], [VremeCasa], [DanOdrzavanjaCasa], [AktivniZadatak], [JMBGp], [NazivOpstine]) VALUES (5, N'16:00h', N'Nedelja', N'Pripremiti 5 imitacija ljudi iz okruzenja', N'0209987720016', N'Zemun')
INSERT [dbo].[Grupa] ([BrojGrupe], [VremeCasa], [DanOdrzavanjaCasa], [AktivniZadatak], [JMBGp], [NazivOpstine]) VALUES (6, N'19:00h', N'Nedelja', N'Spremiti recitaciju odredjene turbo folk pesme. Nauciti tekst napamet i spremiti izvedbu do 2 minuta', N'2106988710015', N'Zemun')
SET IDENTITY_INSERT [dbo].[Grupa] OFF
GO
INSERT [dbo].[Lokacija] ([NazivOpsite], [Adresa]) VALUES (N'Rakovica', N'Miska Kranjca 31')
INSERT [dbo].[Lokacija] ([NazivOpsite], [Adresa]) VALUES (N'Vozdovac', N'Ustanicka 55')
INSERT [dbo].[Lokacija] ([NazivOpsite], [Adresa]) VALUES (N'Zemun', N'Cara Dusana 26')
GO
INSERT [dbo].[Profesor] ([JMBGp], [Ime], [Prezime], [GodRodjenja], [BrTelefona], [Adresa], [Email], [Password]) VALUES (N'0209987720016', N'Mihajlo', N'Popovic', 1987, N'064/323-985', N'Stanka Paunovica 35', N'mihajlop@gmail.com', N'stolica123')
INSERT [dbo].[Profesor] ([JMBGp], [Ime], [Prezime], [GodRodjenja], [BrTelefona], [Adresa], [Email], [Password]) VALUES (N'0506987710015', N'Katarina', N'Dimitrijevic', 1987, N'062/377-388', N'Cara Dusana 77', N'katarinadim@gmail.com', N'pikslapiksla')
INSERT [dbo].[Profesor] ([JMBGp], [Ime], [Prezime], [GodRodjenja], [BrTelefona], [Adresa], [Email], [Password]) VALUES (N'1203990720016', N'Danijel', N'Mikic', 1990, N'066/9552-322', N'Timocke divizije 5', N'dmikic@gmail.com', N'mojasifra')
INSERT [dbo].[Profesor] ([JMBGp], [Ime], [Prezime], [GodRodjenja], [BrTelefona], [Adresa], [Email], [Password]) VALUES (N'2106988710015', N'Bojana', N'Grabovac', 1988, N'063/2234-323', N'Vojislava Ilica 11', N'bojanag88@gmail.com', N'najjacasifra')
GO
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'0101005889016', N'Uros', N'Maric', 2005, N'066/999-872', N'Bulevar kralja Aleksandra 200', N'Mart', N'urosmaric@gmail.com', 6, N'kompijuter')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'0502002115016', N'Olivera', N'Drakic', 2002, N'062/227-3227', N'Jurija Gagarina 202', N'Februar', N'oliveradrakic@gmail.com', 5, N'stekara22')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'0505002789016', N'Nikola', N'Mijatovic', 2002, N'063/377-555', N'Marijane Gregoran 23', N'Mart', N'nikolamijat@gmail.com', 4, N'sevroletnubira')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'0505999012015', N'Goran', N'Markovic', 1999, N'066/777-0012', N'Drajzerova 66', N'Mart', N'goranmark@gmail.com', 2, N'ilijadaodiseja')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'0506998099015', N'Tamara', N'Markic', 1998, N'064/3225-255', N'Cara Dusana 24', N'Mart', N'mtamara@gmail.com', 2, N'tamarasamara')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'0606999885016', N'Branislav', N'Radic', 1999, N'066/222-3255', N'Husinjskih rudara 33', N'Mart', N'bradic@gmail.com', 4, N'studioglumescena')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'0702999889015', N'Viktor', N'Hadzic', 1999, N'063/112-775', N'Vidikovacki venac 44', N'Mart', N'hadzicv@gmail.com', 6, N'vidikovac')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'0912003660015', N'Milos', N'Popovic', 2003, N'062/1212-101', N'Vojvode Stepe 122', N'Februar', N'miloscar@gmail.com', 2, N'helikopteri')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'1002003111015', N'Iskra', N'Maric', 2003, N'062/1223-223', N'Borska 12', N'Mart', N'iskramaric@gmail.com', 3, N'iskraivatra')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'1010999012012', N'Zora', N'Nedic', 1999, N'066/221-3345', N'Ljutice Bogdana 12', N'Mart', N'zoranedic@gmail.com', 5, N'zorajesvanula')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'1111000999015', N'Milos', N'Burdzic', 2000, N'063/002-003', N'Neznanog junaka 44', N'Mart', N'milosburdz@gmail.com', 5, N'burdziccar')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'1202003112015', N'Nevena', N'Mitrovic', 2003, N'066/192-2939', N'Rebeke Vest 74', N'Mart', N'nevenamm@gmail.com', 5, N'mitrovicccc')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'1209004783017', N'Vukasin', N'Randjelovic', 2004, N'062/877-1124', N'Borska 66', N'Mart', N'vukasinran@gmail.com', 5, N'borovasuma')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'1212006144016', N'Katarina', N'Veljovic', 2006, N'066/111-333', N'Borska 44', N'Mart', N'kacav06@gmail.com', 3, N'miljakovacmkc')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'2008999715115', N'Nevena', N'Mitrovic', 1999, N'064/3304-322', N'Rebeke Vest 74c', N'Mart', N'nevenna@gmail.com', 6, N'ognjenlegenda')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'2201001988015', N'Milos', N'Ralic', 2001, N'062/992-822', N'Ustanicka 22', N'Februar', N'milosmilosra@gmail.com', 6, N'ralicralic')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'2204002992220', N'Zoran', N'Pavic', 2002, N'062/1122003', N'Borska 94', N'Februar', N'mpavicc@gmail.com', 2, N'miloradmilorad')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'2205997122017', N'Katarina', N'Zukic', 1997, N'062/122-322', N'Venizelsova 22', N'Mart', N'katarinazukic@gmail.com', 1, N'roletne33')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'2210003144015', N'Nadja', N'Marcetic', 2003, N'062/233-7789', N'Borska 44', N'Mart', N'maceticn@gmail.com', 6, N'nadjasladja')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'2211002111015', N'Sanja', N'Petrovic', 2002, N'066/3939-102', N'Bulevar oslobodjenja 122', N'Mart', N'sanjappp@gmail.com', 2, N'rozehaljina2')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'2312000122011`', N'Andjela', N'Andjelic', 2000, N'066/122-999', N'Sumadijske divizije 12', N'Mart', N'andjandj@gmail.com', 6, N'andjelcic')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'2312000788012', N'Milos', N'Zaric', 2000, N'064/555-1775', N'Sretena Mladenovica Mike 42', N'Mart', N'milosz@gmail.com', 1, N'stolicaisto')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'2312006122015', N'Milica', N'Milicic', 2006, N'066/664-777', N'Vojvode Stepe 412', N'Februar', N'mimica@gmail.com', 4, N'ozbiljnasifra')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'2502001988015', N'Zoran', N'Mikic', 2001, N'066/222-255', N'Drajzerova 55', N'Mart', N'zoranmikic@gmail.com', 1, N'lampalampa')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'250700665015', N'Sava', N'Milosevic', 2006, N'062/122-7564', N'Vidikovacki venac 55', N'Mart', N'savamilosevic@gmail.com', 1, N'miloseviccar')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'2508002888014', N'Milos', N'Milosevic', 2002, N'062/333-8985', N'Vojvode Stepe 313', N'Mart', N'milosm@gmail.com', 3, N'sifrasifra')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'2509005124015', N'Sofija', N'Kostic', 2005, N'062/123-000', N'Pozeska 64', N'Mart', N'sofijakost@gmail.com', 4, N'balerinica')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'2701002122015', N'Milica', N'Radic', 2002, N'062/622-7764', N'Pozeska 22', N'Mart', N'milicaradic@gmail.com', 1, N'zvucnici2')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'3006999120015', N'Tonja', N'Gacina', 1999, N'066/987-222', N'Mirijevski bulevar 33', N'Mart', N'gacinat@gmail.com', 4, N'tonjinasifra')
INSERT [dbo].[Ucenik] ([JMBGu], [Ime], [Prezime], [GodinaRodjenja], [BrTelefona], [Adresa], [PoslednjaPlacenaClanarina], [Email], [BrojGrupe], [Password]) VALUES (N'3107999120015', N'Katarina', N'Janjusevic', 1999, N'065/325-9999', N'Miljakovacke staze 12', N'Mart', N'kacaj@gmail.com', 3, N'volan232')
GO
ALTER TABLE [dbo].[Grupa]  WITH CHECK ADD  CONSTRAINT [FK_Grupa_Lokacija] FOREIGN KEY([NazivOpstine])
REFERENCES [dbo].[Lokacija] ([NazivOpsite])
GO
ALTER TABLE [dbo].[Grupa] CHECK CONSTRAINT [FK_Grupa_Lokacija]
GO
ALTER TABLE [dbo].[Grupa]  WITH CHECK ADD  CONSTRAINT [FK_Grupa_Profesor] FOREIGN KEY([JMBGp])
REFERENCES [dbo].[Profesor] ([JMBGp])
GO
ALTER TABLE [dbo].[Grupa] CHECK CONSTRAINT [FK_Grupa_Profesor]
GO
ALTER TABLE [dbo].[Ucenik]  WITH CHECK ADD  CONSTRAINT [FK_Ucenik_Grupa] FOREIGN KEY([BrojGrupe])
REFERENCES [dbo].[Grupa] ([BrojGrupe])
GO
ALTER TABLE [dbo].[Ucenik] CHECK CONSTRAINT [FK_Ucenik_Grupa]
GO
USE [master]
GO
ALTER DATABASE [StudioGlumeScena] SET  READ_WRITE 
GO
