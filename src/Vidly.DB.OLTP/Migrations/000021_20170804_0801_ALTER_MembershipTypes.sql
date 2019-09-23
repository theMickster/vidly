-- <Migration ID="b20a07c1-dd43-4caf-8b86-eb94aa4c36e4" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.08.04
** CREATION:     Rename membership types
**************************************************************************/
DECLARE @name NVARCHAR(128)
		,@sql NVARCHAR(500)

SET @name = (SELECT	name
			FROM	sys.foreign_keys
			WHERE	parent_object_id = OBJECT_ID('customers')
					AND referenced_object_id = (SELECT object_id FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('dbo.MembershipType')))

SET @sql = 'ALTER TABLE dbo.customers DROP CONSTRAINT ' + @name
EXECUTE sp_executesql @sql

EXECUTE sp_rename @objname = 'MembershipType', @newname = 'MembershipTypes'
GO
ALTER TABLE dbo.customers ADD CONSTRAINT FK_Customers_MembershipTypes FOREIGN KEY (MembershipTypeId) REFERENCES dbo.MembershipTypes (MembershipTypeId);