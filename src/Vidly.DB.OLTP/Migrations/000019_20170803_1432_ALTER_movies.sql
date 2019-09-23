-- <Migration ID="e70ba778-59a9-49c8-93b1-5062f6b369b6" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.08.03
** CREATION:     Add installment and parent to movies
**************************************************************************/
ALTER TABLE dbo.movie_details ADD installment_id INTEGER NULL
	CONSTRAINT FK_movie_details_installment_codes FOREIGN KEY (installment_id) REFERENCES codes.installment_codes (installment_id);