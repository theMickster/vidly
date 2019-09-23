-- <Migration ID="ab4f1fa6-16de-4897-adb8-ed8543821e28" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.08.02
** CREATION:     Add genre to movie tables
**************************************************************************/
ALTER TABLE dbo.movies ADD movie_genre_code_id INTEGER NULL CONSTRAINT FK_movies_movie_genre_codes FOREIGN KEY (movie_genre_code_id) REFERENCES codes.movie_genre_codes (movie_genre_code_id);