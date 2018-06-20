
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/17/2018 02:23:46
-- Generated from EDMX file: F:\29ПР31\ADO.NET\Урок 11 ModelFirst\Hometask\Hometask\ShopModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [NewShop];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DeptName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProductName] nvarchar(max)  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [Department_Id] int  NOT NULL
);
GO

-- Creating table 'Checks'
CREATE TABLE [dbo].[Checks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SaleDate] datetime  NOT NULL,
    [AllSumm] decimal(18,0)  NOT NULL,
    [Customer_Id] int  NOT NULL,
    [Seller_Id] int  NOT NULL
);
GO

-- Creating table 'Sellers'
CREATE TABLE [dbo].[Sellers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProductChecks'
CREATE TABLE [dbo].[ProductChecks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Count] int  NOT NULL,
    [Check_Id] int  NOT NULL,
    [Product_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Checks'
ALTER TABLE [dbo].[Checks]
ADD CONSTRAINT [PK_Checks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Sellers'
ALTER TABLE [dbo].[Sellers]
ADD CONSTRAINT [PK_Sellers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductChecks'
ALTER TABLE [dbo].[ProductChecks]
ADD CONSTRAINT [PK_ProductChecks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Customer_Id] in table 'Checks'
ALTER TABLE [dbo].[Checks]
ADD CONSTRAINT [FK_CustomerCheck]
    FOREIGN KEY ([Customer_Id])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerCheck'
CREATE INDEX [IX_FK_CustomerCheck]
ON [dbo].[Checks]
    ([Customer_Id]);
GO

-- Creating foreign key on [Department_Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_DepartmentProduct]
    FOREIGN KEY ([Department_Id])
    REFERENCES [dbo].[Departments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartmentProduct'
CREATE INDEX [IX_FK_DepartmentProduct]
ON [dbo].[Products]
    ([Department_Id]);
GO

-- Creating foreign key on [Seller_Id] in table 'Checks'
ALTER TABLE [dbo].[Checks]
ADD CONSTRAINT [FK_SellerCheck]
    FOREIGN KEY ([Seller_Id])
    REFERENCES [dbo].[Sellers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SellerCheck'
CREATE INDEX [IX_FK_SellerCheck]
ON [dbo].[Checks]
    ([Seller_Id]);
GO

-- Creating foreign key on [Check_Id] in table 'ProductChecks'
ALTER TABLE [dbo].[ProductChecks]
ADD CONSTRAINT [FK_CheckProductCheck]
    FOREIGN KEY ([Check_Id])
    REFERENCES [dbo].[Checks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CheckProductCheck'
CREATE INDEX [IX_FK_CheckProductCheck]
ON [dbo].[ProductChecks]
    ([Check_Id]);
GO

-- Creating foreign key on [Product_Id] in table 'ProductChecks'
ALTER TABLE [dbo].[ProductChecks]
ADD CONSTRAINT [FK_ProductProductCheck]
    FOREIGN KEY ([Product_Id])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductProductCheck'
CREATE INDEX [IX_FK_ProductProductCheck]
ON [dbo].[ProductChecks]
    ([Product_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------