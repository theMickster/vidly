-- <Migration ID="7bde8f96-e8d8-4791-ad36-0ea2b7d2d5e5" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.08.17
** CREATION:     Add a description attribute to the aspnetroles table. 
**************************************************************************/
ALTER TABLE dbo.AspNetUsers ADD FirstName VARCHAR(50) NULL;
ALTER TABLE dbo.AspNetUsers ADD LastName VARCHAR(50) NULL;