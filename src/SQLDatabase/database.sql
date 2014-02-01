-- =========================================
-- Create table template SQL Azure Database 
-- =========================================

IF OBJECT_ID('[dbo].[Employees]', 'U') IS NOT NULL
  DROP TABLE [dbo].[Employees]
GO

CREATE TABLE [dbo].[Employees]
(
	[EmployeeID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[FirstName] [nvarchar](10) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,	
	[Email] [nvarchar](30) NULL,
	[Country] [nvarchar](15) NULL,
	[Created] [datetime] NULL
)
GO
