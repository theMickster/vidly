-- <Migration ID="0ef8113c-2a57-44e2-b257-eb566ea48418" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.08.15
** CREATION:     Rename column in aspnet users tables
**************************************************************************/
EXECUTE sp_rename @objname = 'AspNetUserClaims.User_Id', @newname = 'AspNetUserClaims.UserId', @objtype= 'COLUMN'