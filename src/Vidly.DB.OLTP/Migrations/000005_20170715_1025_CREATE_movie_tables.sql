-- <Migration ID="dc1ee758-3289-4c55-b819-511f014f152e" />
GO
CREATE TABLE codes.movie_rating_codes
(
	movie_rating_code_id INTEGER IDENTITY(1,1) NOT NULL
	,movie_rating_desc VARCHAR(5) NOT NULL
	,active_flag BIT NOT NULL CONSTRAINT DF_movie_rating_codes_active_flag DEFAULT (1)
	,create_user INTEGER NOT NULL CONSTRAINT DF_movie_rating_codes_create_user DEFAULT(1)
	,create_date DATETIME NOT NULL CONSTRAINT DF_movie_rating_codes_create_dttm DEFAULT(GETDATE())
	,update_user INTEGER NOT NULL CONSTRAINT DF_movie_rating_codes_update_user DEFAULT(1)
	,update_date DATETIME NOT NULL CONSTRAINT DF_movie_rating_codes_update_dttm DEFAULT(GETDATE())	
	,CONSTRAINT PK_movie_ratings PRIMARY KEY CLUSTERED (movie_rating_code_id)
)

SET IDENTITY_INSERT codes.movie_rating_codes ON; 
INSERT INTO codes.movie_rating_codes(movie_rating_code_id,movie_rating_desc,active_flag,create_user,create_date,update_user,update_date)
VALUES (1, 'G', 1, 1, GETDATE(), 1, GETDATE()), (2, 'PG', 1, 1, GETDATE(), 1, GETDATE()), (3, 'PG-13', 1, 1, GETDATE(), 1, GETDATE()), (4, 'R', 1, 1, GETDATE(), 1, GETDATE())
,(5, 'NC-17', 1, 1, GETDATE(), 1, GETDATE()), (6, 'NR', 1, 1, GETDATE(), 1, GETDATE())
SET IDENTITY_INSERT codes.movie_rating_codes OFF; 

CREATE TABLE codes.movie_genre_codes
(
	movie_genre_code_id INTEGER IDENTITY(1,1) NOT NULL
	,movie_genre_desc VARCHAR(50) NOT NULL 
	,active_flag BIT NOT NULL CONSTRAINT DF_movie_genre_codes_active_flag DEFAULT (1)
	,create_user INTEGER NOT NULL CONSTRAINT DF_movie_genre_codes_create_user DEFAULT(1)
	,create_date DATETIME NOT NULL CONSTRAINT DF_movie_genre_codes_create_dttm DEFAULT(GETDATE())
	,update_user INTEGER NOT NULL CONSTRAINT DF_movie_genre_codes_update_user DEFAULT(1)
	,update_date DATETIME NOT NULL CONSTRAINT DF_movie_genre_codes_update_dttm DEFAULT(GETDATE())	
	,CONSTRAINT PK_movie_genre_codes PRIMARY KEY CLUSTERED (movie_genre_code_id)
)
SET IDENTITY_INSERT codes.movie_genre_codes ON; 
INSERT INTO codes.movie_genre_codes (movie_genre_code_id, movie_genre_desc,active_flag,create_user,create_date,update_user,update_date)
VALUES	(1,'Action', 1, 1,GETDATE(),1,GETDATE()), (2,'Adventure', 1, 1,GETDATE(),1,GETDATE()), (3,'Comedy', 1, 1,GETDATE(),1,GETDATE()), (4,'Crime', 1, 1,GETDATE(),1,GETDATE())
, (5,'Drama', 1, 1,GETDATE(),1,GETDATE()), (6,'Fantasy', 1, 1,GETDATE(),1,GETDATE()), (7,'Historical', 1, 1,GETDATE(),1,GETDATE()), (8,'Horror', 1, 1,GETDATE(),1,GETDATE())
, (9,'Mystery', 1, 1,GETDATE(),1,GETDATE()), (10,'Political', 1, 1,GETDATE(),1,GETDATE()), (11,'Romance', 1, 1,GETDATE(),1,GETDATE()), (12,'Satire', 1, 1,GETDATE(),1,GETDATE())
, (13,'Science Fiction', 1, 1,GETDATE(),1,GETDATE()), (14,'Thriller', 1, 1,GETDATE(),1,GETDATE()), (15,'Western', 1, 1,GETDATE(),1,GETDATE()), (16,'Animated', 1, 1,GETDATE(),1,GETDATE())
SET IDENTITY_INSERT codes.movie_genre_codes OFF; 

CREATE TABLE dbo.movies
(
	movie_id INTEGER IDENTITY(1,1) NOT NULL
	,movie_name VARCHAR(100) NOT NULL
	,release_date DATETIME NULL
	,movie_rating_code_id INTEGER NULL CONSTRAINT FK_movies_movie_rating_codes FOREIGN KEY REFERENCES codes.movie_rating_codes (movie_rating_code_id)
	,runtime INTEGER NULL
	,movie_desc VARCHAR(500) NULL
	,movie_plot_summary VARCHAR(MAX) NULL
	,create_user INTEGER NOT NULL CONSTRAINT DF_movies_create_user DEFAULT(1)
	,create_date DATETIME NOT NULL CONSTRAINT DF_movies_create_dttm DEFAULT(GETDATE())
	,update_user INTEGER NOT NULL CONSTRAINT DF_movies_update_user DEFAULT(1)
	,update_date DATETIME NOT NULL CONSTRAINT DF_movies_update_dttm DEFAULT(GETDATE())
	,CONSTRAINT PK_movies PRIMARY KEY CLUSTERED (movie_id)
)

CREATE TABLE dbo.movie_directors
(
	movie_director_id INTEGER IDENTITY(1,1) NOT NULL 
	,movie_id INTEGER NOT NULL CONSTRAINT FK_movie_directors_movies FOREIGN KEY REFERENCES dbo.movies (movie_id)
	,people_id INTEGER NOT NULL CONSTRAINT FK_movie_directors_people FOREIGN KEY REFERENCES dbo.people (people_id)
	,create_user INTEGER NOT NULL CONSTRAINT DF_movie_directors_create_user DEFAULT(1)
	,create_date DATETIME NOT NULL CONSTRAINT DF_movie_directors_create_dttm DEFAULT(GETDATE())
	,update_user INTEGER NOT NULL CONSTRAINT DF_movie_directors_update_user DEFAULT(1)
	,update_date DATETIME NOT NULL CONSTRAINT DF_movie_directors_update_dttm DEFAULT(GETDATE())
)



