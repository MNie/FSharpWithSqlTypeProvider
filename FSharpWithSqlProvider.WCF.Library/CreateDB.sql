CREATE DATABASE Airport
GO
CREATE LOGIN AirportUser WITH PASSWORD = 'aaAA11!!'
USE [Airport]
CREATE USER AirUser FOR LOGIN AirportUser
GO
ALTER ROLE db_datawriter ADD MEMBER AirUser
GO
ALTER ROLE db_datareader ADD MEMBER AirUser
GO
CREATE TABLE [dbo].[AircraftSchedule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlaneNumber] [nvarchar](128) NOT NULL,
	[Operator] [nvarchar](128) NOT NULL,
	[Area] [int] NOT NULL,
	[Type] [nvarchar](255) NOT NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_AircraftSchedule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO