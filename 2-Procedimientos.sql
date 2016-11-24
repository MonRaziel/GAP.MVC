--*********************************************************************************
--ARTICLE
--*********************************************************************************
CREATE PROCEDURE usp_CreateArticle
	@Description	VARCHAR(255),
	@Price			NUMERIC(22,2),
	@Total_in_shelf	NUMERIC(20,0),
	@Total_in_vault	NUMERIC(20,0),
	@Store_Id		NUMERIC(20,0)
AS
BEGIN
	INSERT INTO [dbo].[tbArticles]
           ([Description]
           ,[Price]
           ,[Total_in_shelf]
           ,[Total_in_vault]
           ,[Store_Id])
     VALUES
           (@Description
           , @Price
           , @Total_in_shelf
           , @Total_in_vault 
           , @Store_Id)
END
GO 

CREATE PROCEDURE usp_UpdateArticle
	@Article_Id		NUMERIC(20,0),
	@Description	VARCHAR(255),
	@Price			NUMERIC(22,2),
	@Total_in_shelf	NUMERIC(20,0),
	@Total_in_vault	NUMERIC(20,0),
	@Store_Id		NUMERIC(20,0)
AS
BEGIN
	UPDATE [dbo].[tbArticles]
   SET [Description] = @Description
      ,[Price] = @Price
      ,[Total_in_shelf] = @Total_in_shelf
      ,[Total_in_vault] = @Total_in_vault
      ,[Store_Id] = @Store_Id
	WHERE Article_Id = @Article_Id
END
GO


CREATE PROCEDURE usp_DeleteArticle
	@Article_Id		NUMERIC(20,0)
AS
BEGIN
	DELETE FROM [dbo].[tbArticles]
	WHERE Article_Id = @Article_Id
END
GO

CREATE PROCEDURE usp_ReadArticles
	@Article_Id		NUMERIC(20,0) = NULL,
	@Store_Id		NUMERIC(20,0) = NULL
AS
BEGIN
	SELECT A.*
		, s.Name AS NameStore
	FROM [dbo].[tbArticles] A
	INNER JOIN [dbo].[tbStores] S ON A.Store_Id = S.Store_Id
	WHERE (Article_Id = @Article_Id OR @Article_Id IS NULL)
	AND (A.Store_Id = @Store_Id OR @Store_Id IS NULL)
END
GO





--*********************************************************************************
--STORE
--*********************************************************************************
CREATE PROCEDURE usp_CreateStore
	@Name		VARCHAR(255),
	@Address	VARCHAR(255)
AS
BEGIN
	INSERT INTO [dbo].[tbStores]
           ([Name]
           ,[Address])
     VALUES
           (@Name
           ,@Address)
END
GO 

CREATE PROCEDURE usp_UpdateStore
	@Store_Id	NUMERIC(20,0),
	@Name		VARCHAR(255),
	@Address	VARCHAR(255)
AS
BEGIN
	UPDATE [dbo].[tbStores]
   SET [Name] = @Name
      ,[Address] = @Address
	WHERE Store_Id = @Store_Id
END
GO


CREATE PROCEDURE usp_DeleteStore
	@Store_Id		NUMERIC(20,0)
AS
BEGIN
	DELETE FROM [dbo].[tbStores]
	WHERE Store_Id = @Store_Id
END
GO

CREATE PROCEDURE usp_ReadStore
	@Store_Id		NUMERIC(20,0) = NULL
AS
BEGIN
	SELECT * 
	FROM [dbo].[tbStores] S
	WHERE (S.Store_Id = @Store_Id OR @Store_Id IS NULL)
END
