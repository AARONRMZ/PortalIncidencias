
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/21/2015 15:26:19
-- Generated from EDMX file: C:\Users\mmontenegro\documents\visual studio 2013\Projects\PortalIncidencias\adsincidencias.entities\adsincidenciasDBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [adsincidenciasDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UsuarioEmpresa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_UsuarioEmpresa];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO
IF OBJECT_ID(N'[dbo].[Empresas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empresas];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [usrNombre] nvarchar(max)  NOT NULL,
    [usrCorreo] nvarchar(max)  NOT NULL,
    [usrNombreUsusario] nvarchar(max)  NOT NULL,
    [usrContrasena] nvarchar(max)  NOT NULL,
    [usrEmpresaID] int  NOT NULL
);
GO

-- Creating table 'Empresas'
CREATE TABLE [dbo].[Empresas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [empNombre] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Empresas'
ALTER TABLE [dbo].[Empresas]
ADD CONSTRAINT [PK_Empresas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [usrEmpresaID] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK_UsuarioEmpresa]
    FOREIGN KEY ([usrEmpresaID])
    REFERENCES [dbo].[Empresas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioEmpresa'
CREATE INDEX [IX_FK_UsuarioEmpresa]
ON [dbo].[Usuarios]
    ([usrEmpresaID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------