USE [master]
GO
/****** Object:  Database [convenience-store]    Script Date: 28-May-24 8:34:59 PM ******/
CREATE DATABASE [convenience-store]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'convenience-store', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\convenience-store.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'convenience-store_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\convenience-store_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [convenience-store] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [convenience-store].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [convenience-store] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [convenience-store] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [convenience-store] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [convenience-store] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [convenience-store] SET ARITHABORT OFF 
GO
ALTER DATABASE [convenience-store] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [convenience-store] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [convenience-store] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [convenience-store] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [convenience-store] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [convenience-store] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [convenience-store] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [convenience-store] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [convenience-store] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [convenience-store] SET  DISABLE_BROKER 
GO
ALTER DATABASE [convenience-store] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [convenience-store] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [convenience-store] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [convenience-store] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [convenience-store] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [convenience-store] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [convenience-store] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [convenience-store] SET RECOVERY FULL 
GO
ALTER DATABASE [convenience-store] SET  MULTI_USER 
GO
ALTER DATABASE [convenience-store] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [convenience-store] SET DB_CHAINING OFF 
GO
ALTER DATABASE [convenience-store] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [convenience-store] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [convenience-store] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [convenience-store] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'convenience-store', N'ON'
GO
ALTER DATABASE [convenience-store] SET QUERY_STORE = ON
GO
ALTER DATABASE [convenience-store] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [convenience-store]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] NOT NULL,
	[CategName] [varchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Linker]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Linker](
	[ReceiptID] [int] NOT NULL,
	[SublistID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturer](
	[ID] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[CountryOfOrigin] [varchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Manufacturer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Barcode] [varchar](50) NOT NULL,
	[ExpirationDate] [date] NULL,
	[CategoryID] [int] NOT NULL,
	[ManufacturerID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductList]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductList](
	[ID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Subtotal] [float] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_ProductList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipt](
	[ID] [int] NOT NULL,
	[PaymentDate] [date] NOT NULL,
	[CashierID] [int] NOT NULL,
	[Total] [float] NULL,
	[IsActive] [bit] NOT NULL,
	[Finalized] [bit] NOT NULL,
 CONSTRAINT [PK_Receipt] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[ID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitOfMeasurement] [varchar](50) NOT NULL,
	[SupplyDate] [date] NOT NULL,
	[BasePrice] [float] NOT NULL,
	[SellingPrice] [float] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Role] [varchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Category_Product] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Category_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Manufacturer_Product] FOREIGN KEY([ManufacturerID])
REFERENCES [dbo].[Manufacturer] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Manufacturer_Product]
GO
ALTER TABLE [dbo].[ProductList]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductList] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[ProductList] CHECK CONSTRAINT [FK_Product_ProductList]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_User_Receipt] FOREIGN KEY([CashierID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_User_Receipt]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Product_Stock] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Product_Stock]
GO
/****** Object:  StoredProcedure [dbo].[AddCategory]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddCategory]
    @ID INT,
    @CategName VARCHAR(100),
    @IsActive BIT
AS
BEGIN
    SET NOCOUNT ON;
	 
	IF EXISTS (SELECT 1 FROM [Category] WHERE [CategName] = @CategName)
    BEGIN
        RAISERROR('Category with the given name already exists', 16, 1)
        RETURN;
    END

    INSERT INTO [Category] (ID, CategName, IsActive)
    VALUES (@ID, @CategName, @IsActive);
END;
GO
/****** Object:  StoredProcedure [dbo].[AddLink]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddLink]
    @First INT,  
    @Second INT  
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if ReceiptID is valid
    IF NOT EXISTS (SELECT 1 FROM [Receipt] WHERE [ID] = @First)
    BEGIN
        RAISERROR('Invalid ReceiptID.', 16, 1)
        RETURN;
    END

    -- Check if SublistID is valid
    IF NOT EXISTS (SELECT 1 FROM [ProductList] WHERE [ID] = @Second)
    BEGIN
        RAISERROR('Invalid SublistID.', 16, 1)
        RETURN;
    END

	  -- Check if the pair (ReceiptID, SublistID) already exists in the Linker table
    IF EXISTS (SELECT 1 FROM [Linker] WHERE [ReceiptID] = @First AND [SublistID] = @Second)
    BEGIN
		RAISERROR('Pair already exists.', 16, 1)
        RETURN;
    END
    -- Retrieve ProductID and Quantity from ProductList
    DECLARE @ProductID INT;
    DECLARE @Quantity INT;

    SELECT @ProductID = ProductID, @Quantity = Quantity
    FROM [ProductList]
    WHERE [ID] = @Second;

    -- Update the stock with the oldest SupplyDate
    DECLARE @RemainingQuantity INT = @Quantity;
    DECLARE @CurrentStockID INT;
    DECLARE @CurrentStockQuantity INT;

    WHILE @RemainingQuantity > 0
    BEGIN
        SELECT TOP 1 @CurrentStockID = ID, @CurrentStockQuantity = Quantity
        FROM [Stock]
        WHERE ProductID = @ProductID AND IsActive = 1
        ORDER BY SupplyDate;

        IF @CurrentStockID IS NULL
        BEGIN
            RAISERROR ('Not enough stock available.', 16, 1);
            RETURN;
        END

        IF @CurrentStockQuantity >= @RemainingQuantity
        BEGIN
            UPDATE [Stock]
            SET Quantity = Quantity - @RemainingQuantity
            WHERE ID = @CurrentStockID;

            IF @CurrentStockQuantity - @RemainingQuantity = 0
            BEGIN
                UPDATE [Stock]
                SET IsActive = 0
                WHERE ID = @CurrentStockID;
            END

            SET @RemainingQuantity = 0;
        END
        ELSE
        BEGIN
            UPDATE [Stock]
            SET Quantity = 0, IsActive = 0
            WHERE ID = @CurrentStockID;

            SET @RemainingQuantity = @RemainingQuantity - @CurrentStockQuantity;
        END
    END

    -- Insert into Linker table
    INSERT INTO [Linker] (ReceiptID, SublistID)
    VALUES (@First, @Second);
END

GO
/****** Object:  StoredProcedure [dbo].[AddManufacturer]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddManufacturer]
    @ID INT,
    @Name NVARCHAR(100),
    @CountryOfOrigin NVARCHAR(100),
    @IsActive BIT
AS
BEGIN
    SET NOCOUNT ON;

	 IF EXISTS (SELECT 1 FROM [Manufacturer] WHERE [Name] = @Name)
    BEGIN
        RAISERROR('Manufacturer with the given name already exists', 16, 1)
        RETURN;
    END

    INSERT INTO [Manufacturer] (ID, Name, CountryOfOrigin, IsActive)
    VALUES (@ID, @Name, @CountryOfOrigin, @IsActive);
END;

GO
/****** Object:  StoredProcedure [dbo].[AddProduct]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddProduct]
    @ID INT,
    @Name NVARCHAR(100),
    @Barcode NVARCHAR(50),
    @ExpirationDate DATE = NULL,
    @CategoryID INT,
    @ManufacturerID INT
AS
BEGIN
    SET NOCOUNT ON;

	IF EXISTS (SELECT 1 FROM [Product] WHERE [Name] = @Name)
    BEGIN
        RAISERROR('Product with the given name already exists', 16, 1)
        RETURN;
    END

    -- Check if CategoryID is valid
    IF NOT EXISTS (SELECT 1 FROM [Category] WHERE ID = @CategoryID)
    BEGIN
        RAISERROR('Invalid CategoryID', 16, 1)
        RETURN;
    END

    -- Check if ManufacturerID is valid
    IF NOT EXISTS (SELECT 1 FROM [Manufacturer] WHERE ID = @ManufacturerID)
    BEGIN
        RAISERROR('Invalid ManufacturerID', 16, 1)
        RETURN;
    END

    INSERT INTO [Product] (ID, Name, Barcode, ExpirationDate, CategoryID, ManufacturerID, IsActive)
    VALUES (@ID, @Name, @Barcode, @ExpirationDate, @CategoryID, @ManufacturerID, 1);
END

GO
/****** Object:  StoredProcedure [dbo].[AddProductList]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddProductList]
    @ID INT,
    @ProductID INT,
    @Quantity INT,
    @Subtotal FLOAT,
    @IsActive BIT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if ProductID exists and is active in the Product table
    IF NOT EXISTS (SELECT 1 FROM [Product] WHERE ID = @ProductID AND IsActive = 1)
    BEGIN
        RAISERROR ('ProductID does not exist or is not active', 16, 1);
        RETURN;
    END

    -- Check for expired products
    IF EXISTS (SELECT 1 FROM [Product] WHERE ID = @ProductID AND ExpirationDate < GETDATE())
    BEGIN
        RAISERROR ('ProductID is expired', 16, 1);
        RETURN;
    END

    -- Check if ProductID exists and is active in the Stock table
    IF NOT EXISTS (SELECT 1 FROM [Stock] WHERE ProductID = @ProductID AND IsActive = 1)
    BEGIN
        RAISERROR ('ProductID does not exist or is not active in the Stock table', 16, 1);
        RETURN;
    END

    -- Insert into ProductList
    INSERT INTO [ProductList] (ID, ProductID, Quantity, Subtotal, IsActive)
    VALUES (@ID, @ProductID, @Quantity, @Subtotal, @IsActive);
END
GO
/****** Object:  StoredProcedure [dbo].[AddStock]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddStock]
    @ID INT,
    @ProductID INT,
    @Quantity INT,
    @UnitOfMeasurement NVARCHAR(50),
    @SupplyDate DATETIME,
    @BasePrice FLOAT,
	@SellingPrice FLOAT,
    @IsActive BIT
AS
BEGIN
    -- Check if ProductID exists and is active
    IF EXISTS (SELECT 1 FROM [Product] WHERE ID = @ProductID AND IsActive = 1)
    BEGIN
        -- Insert into Stock table
        INSERT INTO [Stock] ([ID], [ProductID], [Quantity], [UnitOfMeasurement], [SupplyDate], [BasePrice], [SellingPrice], [IsActive])
        VALUES (@ID, @ProductID, @Quantity, @UnitOfMeasurement, @SupplyDate, @BasePrice, @SellingPrice, @IsActive);
    END
    ELSE
    BEGIN
        -- ProductID does not exist or is inactive
        RAISERROR ('ProductID does not exist or is inactive.', 16, 1);
    END
END

GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
    @ID INT,
    @Username NVARCHAR(100),
    @Password NVARCHAR(100),
    @Role NVARCHAR(50),
    @IsActive BIT
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [User] WHERE [Username] = @Username)
    BEGIN
        RAISERROR('Username already exists.', 16, 1)
        RETURN;
    END

    INSERT INTO [User] (ID, Username, Password, Role, IsActive)
    VALUES (@ID, @Username, @Password, @Role, @IsActive)
END

GO
/****** Object:  StoredProcedure [dbo].[CreateReceipt]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateReceipt]
    @ID INT,
    @PaymentDate DATETIME,
    @CashierID INT,
    @Total FLOAT,
    @IsActive BIT,
    @Finalized BIT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the CashierID exists and is active in the User table
    IF NOT EXISTS (SELECT 1 FROM [User] WHERE ID = @CashierID AND IsActive = 1)
    BEGIN
        RAISERROR ('CashierID does not exist or is not active', 16, 1);
        RETURN;
    END

    -- Insert the new receipt into the Receipt table
    INSERT INTO [Receipt] (ID, PaymentDate, CashierID, Total, IsActive, Finalized)
    VALUES (@ID, @PaymentDate, @CashierID, @Total, @IsActive, @Finalized);
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCategory]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCategory]
    @ID INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ErrorMessage NVARCHAR(200);

    -- Check if the category is active
    IF EXISTS (SELECT 1 FROM [Category] WHERE ID = @ID AND IsActive = 1)
    BEGIN
        -- Check if the category ID is not used in the Product table
        IF NOT EXISTS (SELECT 1 FROM [Product] WHERE CategoryID = @ID)
        BEGIN
            -- Make the category inactive
            UPDATE [Category]
            SET IsActive = 0
            WHERE ID = @ID;
        END
        ELSE
        BEGIN
            -- Set the error message
            SET @ErrorMessage = 'Cannot delete category because it is used in a product.';

            -- Raise an error
            RAISERROR (@ErrorMessage, 16, 1);
        END
    END
    ELSE
    BEGIN
        -- Set the error message
        SET @ErrorMessage = 'Cannot delete category because it is not active.';

        -- Raise an error
        RAISERROR (@ErrorMessage, 16, 1);
    END
END;

GO
/****** Object:  StoredProcedure [dbo].[DeleteManufacturer]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteManufacturer]
    @ID INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ErrorMessage NVARCHAR(200);

    -- Check if the manufacturer is active
    IF EXISTS (SELECT 1 FROM [Manufacturer] WHERE ID = @ID AND IsActive = 1)
    BEGIN
        -- Check if the manufacturer ID is not used in the Product table
        IF NOT EXISTS (SELECT 1 FROM [Product] WHERE ManufacturerID = @ID)
        BEGIN
            -- Deactivate the manufacturer instead of deleting
            UPDATE [Manufacturer]
            SET IsActive = 0
            WHERE ID = @ID;
        END
        ELSE
        BEGIN
            -- Set the error message
            SET @ErrorMessage = 'Cannot delete manufacturer because it is used in a product.';

            -- Raise an error
            RAISERROR (@ErrorMessage, 16, 1);
        END
    END
    ELSE
    BEGIN
        -- Set the error message
        SET @ErrorMessage = 'Cannot delete manufacturer because it is not active.';

        -- Raise an error
        RAISERROR (@ErrorMessage, 16, 1);
    END
END;

GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProduct]
    @ID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the product ID is not found in the ProductList table
    IF NOT EXISTS (SELECT 1 FROM [ProductList] WHERE ProductID = @ID)
    BEGIN
		UPDATE [Product] SET IsActive = 0 WHERE ID = @ID;
    END
    ELSE
    BEGIN
        RAISERROR('Product ID is found in the ProductList table', 16, 1)
        RETURN;
    END
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteProductList]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProductList]
    @ID INT
AS
BEGIN
    SET NOCOUNT ON;

	IF EXISTS (SELECT 1 FROM [Linker] WHERE SublistID = @ID)
    BEGIN
        RAISERROR ('Cannot deactivate ProductList because it is linked in the Linker table', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM [ProductList] WHERE ID = @ID AND IsActive = 1)
    BEGIN
        UPDATE [ProductList]
        SET IsActive = 0
        WHERE ID = @ID;
    END
    ELSE
    BEGIN
        RAISERROR ('ProductList is already inactive or does not exist', 16, 1);
    END
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteReceipt]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteReceipt]
    @ID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM [Receipt] WHERE ID = @ID AND IsActive = 1 AND Finalized = 0)
    BEGIN
        UPDATE [Receipt]
        SET IsActive = 0
        WHERE ID = @ID;
    END
    ELSE
    BEGIN
        RAISERROR ('Cannot deactivate receipt. Either it is not active or it is finalized.', 16, 1);
    END
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]
    @ID INT
AS
BEGIN
	DECLARE @ErrorMessage NVARCHAR(200);
    IF EXISTS (SELECT 1 FROM [User] WHERE ID = @ID AND IsActive = 1)
    BEGIN
        UPDATE [User] SET IsActive = 0 WHERE ID = @ID;
    END
    ELSE
    BEGIN
        SET @ErrorMessage = 'Cannot delete an inactive user or user not found';
		RAISERROR (@ErrorMessage, 16, 1);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[FinalizeReceipt]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FinalizeReceipt]
    @ID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM [Receipt] WHERE ID = @ID AND IsActive = 1 AND Finalized = 0)
    BEGIN
        -- Check if the ID exists in the Linker table
        IF EXISTS (SELECT 1 FROM [Linker] WHERE ReceiptID = @ID)
        BEGIN
            DECLARE @TotalAdd DECIMAL(18, 2) = 0;

            -- Calculate the total of all associated Subtotals
            SELECT @TotalAdd = @TotalAdd + s.Subtotal
            FROM [Linker] l
            INNER JOIN [ProductList] s ON l.SublistID = s.ID
            WHERE l.ReceiptID = @ID;

            -- Update the Receipt's Total
            UPDATE [Receipt]
            SET Total = Total + @TotalAdd,
                Finalized = 1
            WHERE ID = @ID;
        END
        ELSE
        BEGIN
            RAISERROR ('ReceiptID not found in the Linker table.', 16, 1);
        END
    END
    ELSE
    BEGIN
        RAISERROR ('Cannot finalize receipt. Either it is not active or it is already finalized.', 16, 1);
    END
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllCategories]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCategories]
AS
BEGIN
	SELECT * FROM [Category];
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllLinks]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllLinks]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ReceiptID, SublistID
    FROM [Linker];
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllManufacturers]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllManufacturers]
AS
BEGIN

	SELECT * FROM [Manufacturer];
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProductLists]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllProductLists]
AS
BEGIN
	SELECT * FROM [ProductList];
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProducts]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllProducts]
AS
BEGIN
	SELECT * FROM [Product];
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllReceipts]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllReceipts]
AS
BEGIN
	SELECT * FROM [Receipt];
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllStockInfo]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllStockInfo]
AS
BEGIN
	SELECT * FROM [Stock];
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
	SELECT * FROM [User];
END
GO
/****** Object:  StoredProcedure [dbo].[GetCategoryIdWithName]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategoryIdWithName]
    @Name NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ID INT;
    DECLARE @ErrorMessage NVARCHAR(200);

    -- Check if the category exists and is active
    SELECT @ID = ID
    FROM [Category]
    WHERE CategName = @Name AND IsActive = 1;

    IF @ID IS NOT NULL
    BEGIN
        -- Return the category ID
        SELECT @ID AS CategoryID, NULL AS ErrorMessage;
    END
    ELSE
    BEGIN
        -- Check if the category exists but is inactive
        IF EXISTS (SELECT 1 FROM [Category] WHERE CategName = @Name)
        BEGIN
            SET @ErrorMessage = 'Category is not active.';
        END
        ELSE
        BEGIN
            SET @ErrorMessage = 'Category not found.';
        END

        -- Return the error message
        SELECT NULL AS CategoryID, @ErrorMessage AS ErrorMessage;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[GetCategoryNameWithId]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategoryNameWithId]
    @ID INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Name NVARCHAR(100);
    DECLARE @ErrorMessage NVARCHAR(200);

    -- Check if the category exists and is active
    SELECT @Name = CategName
    FROM [Category]
    WHERE ID = @ID AND IsActive = 1;

    IF @Name IS NOT NULL
    BEGIN
        -- Return the category name
        SELECT @Name AS CategoryName, NULL AS ErrorMessage;
    END
    ELSE
    BEGIN
        -- Check if the category exists but is inactive
        IF EXISTS (SELECT 1 FROM [Category] WHERE ID = @ID)
        BEGIN
            SET @ErrorMessage = 'Category is not active.';
        END
        ELSE
        BEGIN
            SET @ErrorMessage = 'Category not found.';
        END

        -- Return the error message
        SELECT NULL AS CategoryName, @ErrorMessage AS ErrorMessage;
    END
END;

GO
/****** Object:  StoredProcedure [dbo].[GetIdOfUser]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetIdOfUser]
    @Username NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM [User] WHERE [Username] = @Username)
    BEGIN
        RAISERROR ('User with Username %s does not exist.', 16, 1, @Username);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM [User] WHERE [Username] = @Username AND [IsActive] = 1)
    BEGIN
        RAISERROR ('User with Username %s is not active.', 16, 1, @Username);
        RETURN;
    END

    SELECT [ID]
    FROM [User]
    WHERE [Username] = @Username AND [IsActive] = 1;
END

GO
/****** Object:  StoredProcedure [dbo].[GetListsFromReceipt]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetListsFromReceipt]
    @ID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the Linker table exists in the database
    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Linker')
    BEGIN
        RAISERROR('Table [Linker] does not exist.', 16, 1);
        RETURN;
    END

    -- Check if the ProductList table exists in the database
    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ProductList')
    BEGIN
        RAISERROR('Table [ProductList] does not exist.', 16, 1);
        RETURN;
    END

    BEGIN TRY
        -- Select the relevant ProductList information using the provided ReceiptID from the Linker table
        SELECT pl.ID, pl.ProductID, pl.Quantity, pl.Subtotal, pl.IsActive
        FROM [ProductList] pl
        INNER JOIN [Linker] l
        ON pl.ID = l.SublistID
        WHERE l.ReceiptID = @ID;
    END TRY
    BEGIN CATCH
        -- Handle errors
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[GetManufacturerIdWithName]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetManufacturerIdWithName]
    @Name NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ID INT;
    DECLARE @ErrorMessage NVARCHAR(200);

    -- Check if the manufacturer exists and is active
    SELECT @ID = ID
    FROM [Manufacturer]
    WHERE Name = @Name AND IsActive = 1;

    IF @ID IS NOT NULL
    BEGIN
        -- Return the manufacturer ID
        SELECT @ID AS ManufacturerID, NULL AS ErrorMessage;
    END
    ELSE
    BEGIN
        -- Check if the manufacturer exists but is inactive
        IF EXISTS (SELECT 1 FROM [Manufacturer] WHERE Name = @Name)
        BEGIN
            SET @ErrorMessage = 'Manufacturer is not active.';
        END
        ELSE
        BEGIN
            SET @ErrorMessage = 'Manufacturer not found.';
        END

        -- Return the error message
        SELECT NULL AS ManufacturerID, @ErrorMessage AS ErrorMessage;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[GetManufacturerNameWithId]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetManufacturerNameWithId]
    @ID INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Name NVARCHAR(100);
    DECLARE @ErrorMessage NVARCHAR(200);

    -- Check if the manufacturer exists and is active
    SELECT @Name = Name
    FROM [Manufacturer]
    WHERE ID = @ID AND IsActive = 1;

    IF @Name IS NOT NULL
    BEGIN
        -- Return the manufacturer name
        SELECT @Name AS ManufacturerName, NULL AS ErrorMessage;
    END
    ELSE
    BEGIN
        -- Check if the manufacturer exists but is inactive
        IF EXISTS (SELECT 1 FROM [Manufacturer] WHERE ID = @ID)
        BEGIN
            SET @ErrorMessage = 'Manufacturer is not active.';
        END
        ELSE
        BEGIN
            SET @ErrorMessage = 'Manufacturer not found.';
        END

        -- Return the error message
        SELECT NULL AS ManufacturerName, @ErrorMessage AS ErrorMessage;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[GetProductIdWithName]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductIdWithName]
    @Name NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ID INT;
    DECLARE @ErrorMessage NVARCHAR(200);

    -- Check if the product exists and is active
    SELECT @ID = ID
    FROM [Product]
    WHERE Name = @Name AND IsActive = 1;

    IF @ID IS NOT NULL
    BEGIN
        -- Return the product ID
        SELECT @ID AS ProductID, NULL AS ErrorMessage;
    END
    ELSE
    BEGIN
        -- Check if the product exists but is inactive
        IF EXISTS (SELECT 1 FROM [Product] WHERE Name = @Name)
        BEGIN
            SET @ErrorMessage = 'Product is not active.';
        END
        ELSE
        BEGIN
            SET @ErrorMessage = 'Product not found.';
        END

        -- Return the error message
        SELECT NULL AS ProductID, @ErrorMessage AS ErrorMessage;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[GetProductNameWithId]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductNameWithId]
    @ID INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Name NVARCHAR(100);
    DECLARE @ErrorMessage NVARCHAR(200);

    -- Check if the product exists and is active
    SELECT @Name = Name
    FROM [Product]
    WHERE ID = @ID AND IsActive = 1;

    IF @Name IS NOT NULL
    BEGIN
        -- Return the product name
        SELECT @Name AS ProductName, NULL AS ErrorMessage;
    END
    ELSE
    BEGIN
        -- Check if the product exists but is inactive
        IF EXISTS (SELECT 1 FROM [Product] WHERE ID = @ID)
        BEGIN
            SET @ErrorMessage = 'Product is not active.';
        END
        ELSE
        BEGIN
            SET @ErrorMessage = 'Product not found.';
        END

        -- Return the error message
        SELECT NULL AS ProductName, @ErrorMessage AS ErrorMessage;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[GetRoleOfUser]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRoleOfUser]
    @Username NVARCHAR(50),
    @Password NVARCHAR(50)
AS
BEGIN
    SELECT Role
    FROM [User]
    WHERE Username = @Username AND Password = @Password AND IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[GetSellingPriceOfProduct]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSellingPriceOfProduct]
    @ProductID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 SellingPrice
    FROM [Stock]
    WHERE ProductID = @ProductID
    ORDER BY SupplyDate ASC;
END

GO
/****** Object:  StoredProcedure [dbo].[GetSublistWithId]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSublistWithId]
    @ID INT
AS
BEGIN
    -- Select the ProductList with the specified ID
    SELECT 
        [ID],
        [ProductID],
        [Quantity],
        [Subtotal],
        [IsActive]
    FROM 
        [ProductList]
    WHERE 
        [ID] = @ID;
END

GO
/****** Object:  StoredProcedure [dbo].[GetUsernameWithId]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUsernameWithId]
    @ID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM [User] WHERE [ID] = @ID)
    BEGIN
        RAISERROR ('User with ID %d does not exist.', 16, 1, @ID);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM [User] WHERE [ID] = @ID AND [IsActive] = 1)
    BEGIN
        RAISERROR ('User with ID %d is not active.', 16, 1, @ID);
        RETURN;
    END

    SELECT [Username]
    FROM [User]
    WHERE [ID] = @ID AND [IsActive] = 1;
END

GO
/****** Object:  StoredProcedure [dbo].[ModifyCategory]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModifyCategory]
    @ID INT,
    @NewCategName NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ErrorMessage NVARCHAR(200);

    -- Check if the category is active
    IF EXISTS (SELECT 1 FROM [Category] WHERE ID = @ID AND IsActive = 1)
    BEGIN
        -- Check if the category ID is not used in the Product table
        IF NOT EXISTS (SELECT 1 FROM [Product] WHERE CategoryID = @ID)
        BEGIN
            -- Update the category
            UPDATE [Category]
            SET CategName = @NewCategName
            WHERE ID = @ID;
        END
        ELSE
        BEGIN
            -- Set the error message
            SET @ErrorMessage = 'Cannot modify category because it is used in a product.';

            -- Raise an error
            RAISERROR (@ErrorMessage, 16, 1);
        END
    END
    ELSE
    BEGIN
        -- Set the error message
        SET @ErrorMessage = 'Cannot modify category because it is not active.';

        -- Raise an error
        RAISERROR (@ErrorMessage, 16, 1);
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[ModifyManufacturer]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModifyManufacturer]
    @ID INT,
    @NewName NVARCHAR(100),
    @NewCountryOfOrigin NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ErrorMessage NVARCHAR(200);

    -- Check if the manufacturer is active
    IF EXISTS (SELECT 1 FROM [Manufacturer] WHERE ID = @ID AND IsActive = 1)
    BEGIN
        -- Check if the manufacturer ID is not used in the Product table
        IF NOT EXISTS (SELECT 1 FROM [Product] WHERE ManufacturerID = @ID)
        BEGIN
            -- Update the manufacturer
            UPDATE [Manufacturer]
            SET Name = @NewName, CountryOfOrigin = @NewCountryOfOrigin
            WHERE ID = @ID;
        END
        ELSE
        BEGIN
            -- Set the error message
            SET @ErrorMessage = 'Cannot modify manufacturer because it is used in a product.';

            -- Raise an error
            RAISERROR (@ErrorMessage, 16, 1);
        END
    END
    ELSE
    BEGIN
        -- Set the error message
        SET @ErrorMessage = 'Cannot modify manufacturer because it is not active.';

        -- Raise an error
        RAISERROR (@ErrorMessage, 16, 1);
    END
END;

GO
/****** Object:  StoredProcedure [dbo].[ModifyProduct]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModifyProduct]
    @ID INT,
    @Name NVARCHAR(100),
    @Barcode NVARCHAR(50),
    @ExpirationDate DATE = NULL,
    @CategoryID INT,
    @ManufacturerID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if CategoryID is valid
    IF NOT EXISTS (SELECT 1 FROM [Category] WHERE ID = @CategoryID)
    BEGIN
        RAISERROR('Invalid CategoryID', 16, 1)
        RETURN;
    END

    -- Check if ManufacturerID is valid
    IF NOT EXISTS (SELECT 1 FROM [Manufacturer] WHERE ID = @ManufacturerID)
    BEGIN
        RAISERROR('Invalid ManufacturerID', 16, 1)
        RETURN;
    END

    -- Check if the product is active
    IF NOT EXISTS (SELECT 1 FROM [Product] WHERE ID = @ID AND IsActive = 1)
    BEGIN
        RAISERROR('Product is not active', 16, 1)
        RETURN;
    END

    UPDATE [Product]
    SET Name = @Name,
        Barcode = @Barcode,
        ExpirationDate = @ExpirationDate,
        CategoryID = @CategoryID,
        ManufacturerID = @ManufacturerID
    WHERE ID = @ID;
END

GO
/****** Object:  StoredProcedure [dbo].[ModifyProductList]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModifyProductList]
    @ID INT,
    @ProductID INT,
    @Quantity INT,
    @Subtotal FLOAT
AS
BEGIN
    SET NOCOUNT ON;

	IF EXISTS (SELECT 1 FROM [Linker] WHERE SublistID = @ID)
    BEGIN
        RAISERROR ('Cannot modify ProductList because it is linked in the Linker table', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM [ProductList] WHERE ID = @ID AND IsActive = 1)
    BEGIN
		UPDATE [ProductList]
        SET ProductID = @ProductID, Quantity = @Quantity, Subtotal = @Subtotal
        WHERE ID = @ID;
    END
    ELSE
    BEGIN
        RAISERROR ('ProductList is not active or does not exist', 16, 1);
    END
END

GO
/****** Object:  StoredProcedure [dbo].[ModifyReceipt]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModifyReceipt]
    @ID INT,
    @PaymentDate DATETIME,
    @CashierID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM [Receipt] WHERE ID = @ID AND IsActive = 1 AND Finalized = 0)
    BEGIN
        UPDATE [Receipt]
        SET PaymentDate = @PaymentDate,
            CashierID = @CashierID
        WHERE ID = @ID;
    END
    ELSE
    BEGIN
        RAISERROR ('Cannot modify receipt. Either it is not active or it is finalized.', 16, 1);
    END
END

GO
/****** Object:  StoredProcedure [dbo].[ModifyStock]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModifyStock]
    @ID INT,
    @NewSellingPrice FLOAT
AS
BEGIN
    -- Declare variables to hold current values
    DECLARE @BasePrice FLOAT;
    DECLARE @IsActive BIT;

    -- Check if the stock item exists and is active, and get the current BasePrice
    SELECT @BasePrice = [BasePrice], @IsActive = [IsActive]
    FROM [Stock]
    WHERE [ID] = @ID;

    -- If stock item does not exist, raise an error
    IF @@ROWCOUNT = 0
    BEGIN
        RAISERROR ('Stock item with ID %d does not exist.', 16, 1, @ID);
        RETURN;
    END

    -- If stock item is not active, raise an error
    IF @IsActive = 0
    BEGIN
        RAISERROR ('Stock item with ID %d is not active.', 16, 1, @ID);
        RETURN;
    END

    -- If the new selling price is lower than the base price, raise an error
    IF @NewSellingPrice < @BasePrice
    BEGIN
        RAISERROR ('New selling price cannot be lower than the base price for stock item with ID %d.', 16, 1, @ID);
        RETURN;
    END

    -- Update the SellingPrice in the Stock table
    UPDATE [Stock]
    SET [SellingPrice] = @NewSellingPrice
    WHERE [ID] = @ID;
END

GO
/****** Object:  StoredProcedure [dbo].[ModifyUser]    Script Date: 28-May-24 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ModifyUser]
    @ID INT,
    @Username NVARCHAR(50),
    @Password NVARCHAR(50),
    @Role NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ErrorMessage NVARCHAR(200);

    -- Check if the user is active
    IF EXISTS (SELECT 1 FROM [User] WHERE ID = @ID AND IsActive = 1)
    BEGIN
        -- Update the user
        UPDATE [User]
        SET Username = @Username,
            Password = @Password,
            Role = @Role
        WHERE ID = @ID AND IsActive = 1;
    END
    ELSE
    BEGIN
        -- Set the error message
        SET @ErrorMessage = 'Cannot modify user because the user is not active.';

        -- Raise an error
        RAISERROR (@ErrorMessage, 16, 1);
    END
END;


GO
USE [master]
GO
ALTER DATABASE [convenience-store] SET  READ_WRITE 
GO
