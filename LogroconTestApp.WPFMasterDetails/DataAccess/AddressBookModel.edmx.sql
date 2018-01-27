
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/27/2018 21:16:27
-- Generated from EDMX file: C:\Users\Art\source\repos\LogroconTestApp.WPFMasterDetails\DataAccess\AddressBookModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TheAddressBook];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Streets_ToSities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Streets] DROP CONSTRAINT [FK_Streets_ToSities];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Cities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cities];
GO
IF OBJECT_ID(N'[dbo].[Streets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Streets];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Cities'
CREATE TABLE [dbo].[Cities] (
    [Number] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Region] nvarchar(50)  NOT NULL,
    [IsRegionCenter] bit  NOT NULL
);
GO

-- Creating table 'Streets'
CREATE TABLE [dbo].[Streets] (
    [Number] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [CityNumber] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Number] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [PK_Cities]
    PRIMARY KEY CLUSTERED ([Number] ASC);
GO

-- Creating primary key on [Number] in table 'Streets'
ALTER TABLE [dbo].[Streets]
ADD CONSTRAINT [PK_Streets]
    PRIMARY KEY CLUSTERED ([Number] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CityNumber] in table 'Streets'
ALTER TABLE [dbo].[Streets]
ADD CONSTRAINT [FK_Streets_ToSities]
    FOREIGN KEY ([CityNumber])
    REFERENCES [dbo].[Cities]
        ([Number])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Streets_ToSities'
CREATE INDEX [IX_FK_Streets_ToSities]
ON [dbo].[Streets]
    ([CityNumber]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------