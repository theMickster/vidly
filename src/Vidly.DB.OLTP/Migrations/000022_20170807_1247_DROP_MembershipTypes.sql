-- <Migration ID="3ac0cb3c-a215-43a7-b504-68b0914a7357" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.08.07
** CREATION:     Drop membership types table. Not needed. 
**************************************************************************/
ALTER TABLE dbo.customers DROP CONSTRAINT FK_Customers_MembershipTypes;
ALTER TABLE dbo.customers DROP COLUMN MembershipTypeId;
DROP TABLE MembershipTypes;