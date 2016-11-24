--DROP TABLE tbArticles
--DROP TABLE tbStores
CREATE TABLE tbArticles
(
	Article_Id		NUMERIC(20,0) NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Description]	VARCHAR(255),
	Price			NUMERIC(22,2),
	Total_in_shelf	NUMERIC(20,0),
	Total_in_vault	NUMERIC(20,0),
	Store_Id		NUMERIC(20,0)
)
GO

CREATE TABLE tbStores
(
	Store_Id	NUMERIC(20,0) NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name		VARCHAR(255),
	[Address]	VARCHAR(255)
)
GO

ALTER TABLE tbArticles
ADD CONSTRAINT FK_tbArticles_tbStores
FOREIGN KEY (Store_Id)
REFERENCES tbStores (Store_Id)