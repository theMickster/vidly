-- <Migration ID="a257c838-b8f1-4a53-96d2-f4cf280d1bef" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.08.16
** CREATION:     Add a description attribute to the aspnetroles table. 
**************************************************************************/
ALTER TABLE dbo.AspNetRoles ADD RoleDescription VARCHAR(255) NULL;