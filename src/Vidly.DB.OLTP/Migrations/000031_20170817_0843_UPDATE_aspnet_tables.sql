-- <Migration ID="4560c92c-e4ff-4e88-bb53-19b3fa56ff6d" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.08.17
** CREATION:     Update Discriminator field 
**************************************************************************/
UPDATE dbo.AspNetUsers SET Discriminator = 'ApplicationUser';
UPDATE dbo.AspNetRoles SET Discriminator = 'ApplicationRole';