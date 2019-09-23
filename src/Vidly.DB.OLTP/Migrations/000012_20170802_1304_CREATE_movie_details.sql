-- <Migration ID="24fa5167-169d-443d-a33c-b58ceb57ef23" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.08.02
** CREATION:     Create movie details table.
**************************************************************************/
CREATE TABLE dbo.movie_details
(
	movie_id INTEGER NOT NULL
	,imdb_url VARCHAR(MAX) NULL
	,summary VARCHAR(MAX) NULL
	,story_line VARCHAR(MAX) NULL
	,active_flag BIT NOT NULL CONSTRAINT DF_movie_details_active_flag DEFAULT (1)
	,create_user INTEGER NOT NULL CONSTRAINT DF_movie_details_create_user DEFAULT(1)
	,create_date DATETIME NOT NULL CONSTRAINT DF_movie_details_create_dttm DEFAULT(GETDATE())
	,update_user INTEGER NOT NULL CONSTRAINT DF_movie_details_update_user DEFAULT(1)
	,update_date DATETIME NOT NULL CONSTRAINT DF_movie_details_update_dttm DEFAULT(GETDATE())	
	,CONSTRAINT PK_movie_details PRIMARY KEY CLUSTERED(movie_id ASC)
	,CONSTRAINT FK_movie_movie_details FOREIGN KEY (movie_id) REFERENCES dbo.movies (movie_id)
)