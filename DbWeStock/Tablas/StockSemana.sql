CREATE TABLE [dbo].[StockSemana]
(
	[IdStockSemana] INT NOT NULL PRIMARY KEY IDENTITY,
	[IdSemana] INT NOT NULL,
	[StockFuturo] INT NULL,
	CONSTRAINT [FK_StockSemana_Semana] FOREIGN KEY ([IdSemana]) REFERENCES [dbo].[Semanas] ([IdSemana])
)
