-- <Migration ID="6c562d8a-aab2-4e2d-9da3-c6ec1c2edcbe" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.08.18
** CREATION:     Add new column to AspNetUserRoles
**************************************************************************/
ALTER TABLE dbo.AspNetUserRoles ADD Discriminator VARCHAR(128) NULL;
GO
UPDATE dbo.AspNetUserRoles SET Discriminator = 'ApplicationUserRole';