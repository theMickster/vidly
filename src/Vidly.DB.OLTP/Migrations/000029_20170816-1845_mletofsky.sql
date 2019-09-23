-- <Migration ID="f5d180f1-e271-41b6-b6ca-cbead5271c61" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.08.16
** CREATION:     Add a Discriminator attribute to the asp net identity roles & users tables. 
**************************************************************************/
ALTER TABLE dbo.AspNetRoles ADD Discriminator VARCHAR(128) NULL;
ALTER TABLE dbo.AspNetUsers ADD Discriminator VARCHAR(128) NULL;