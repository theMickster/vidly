-- <Migration ID="c4eb12cc-4e1d-43bb-b255-d732f90bc6dd" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.08.02
** CREATION:     Create movie inventory table.
**************************************************************************/
CREATE TABLE dbo.movie_inventory
(
	movie_inventory_id INTEGER IDENTITY(1,1) NOT NULL
	,movie_id INTEGER NOT NULL 	
	,barcode INTEGER NOT NULL
	,added_to_inventory_date DATE NOT NULL
	,active_flag BIT NOT NULL CONSTRAINT DF_movie_inventory_active_flag DEFAULT (1)
	,create_user INTEGER NOT NULL CONSTRAINT DF_movie_inventory_create_user DEFAULT(1)
	,create_date DATETIME NOT NULL CONSTRAINT DF_movie_inventory_create_dttm DEFAULT(GETDATE())
	,update_user INTEGER NOT NULL CONSTRAINT DF_movie_inventory_update_user DEFAULT(1)
	,update_date DATETIME NOT NULL CONSTRAINT DF_movie_inventory_update_dttm DEFAULT(GETDATE())	
	,CONSTRAINT PK_movie_inventory PRIMARY KEY CLUSTERED(movie_inventory_id ASC)
	,CONSTRAINT FK_movies_movie_inventory FOREIGN KEY (movie_id) REFERENCES dbo.movies (movie_id)
)