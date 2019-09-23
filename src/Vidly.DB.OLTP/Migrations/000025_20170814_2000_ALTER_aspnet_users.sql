-- <Migration ID="883f9468-7056-48df-8bc7-5526df1a193b" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.08.14
** CREATION:     Add drivers license ID to the aspnet users table.
**************************************************************************/
ALTER TABLE dbo.AspNetUsers ADD DriversLicenseId VARCHAR(25) NULL;
