-- <Migration ID="147bf54a-bc8a-4986-bc6c-c789906af183" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.08.14
** CREATION:     Create users, roles, and user roles....
**************************************************************************/
ALTER TABLE dbo.AspNetUserClaims DROP CONSTRAINT FK_AspNetUserClaimsAspNetUsers_User_Id;
ALTER TABLE dbo.AspNetUserLogins DROP CONSTRAINT FK_AspNetUserLoginsAspNetUsers_UserId;
ALTER TABLE dbo.AspNetUserRoles DROP CONSTRAINT FK_AspNetUserRolesAspNetRoles_RoleId;
ALTER TABLE dbo.AspNetUserRoles DROP CONSTRAINT FK_AspNetUserRolesAspNetUsers_UserId;
DROP TABLE dbo.AspNetUsers;

CREATE TABLE dbo.AspNetUsers
(
	Id NVARCHAR(128) NOT NULL
	,Email NVARCHAR(256) NULL
	,EmailConfirmed BIT NOT NULL
	,PasswordHash NVARCHAR(MAX) NULL
	,SecurityStamp NVARCHAR(MAX) NULL
	,PhoneNumber NVARCHAR(MAX) NULL
	,PhoneNumberConfirmed BIT NOT NULL
	,TwoFactorEnabled BIT NOT NULL
	,LockoutEndDateUtc DATETIME NULL
	,LockoutEnabled BIT NOT NULL
	,AccessFailedCount INT NOT NULL
	,UserName NVARCHAR(256) NOT NULL
	,CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED(Id ASC)	
)

GO

INSERT dbo.AspNetRoles ([Id],[Name])
VALUES('8C0EA7AA-3892-4B51-83CF-8F3A5BE6D8A3','GLOBAL ADMINISTRATOR')
,('2BD650E1-A3E6-4D95-953B-191C7723DA42','MANAGE CODE TABLES')
,('8E4B7C2F-5C2F-46E0-9779-3EFEA5E32FF6','MANAGE CUSTOMERS')
,('0C53A927-FE97-4010-AE00-94D078A470DE','MANAGE MOVIES')

/* Passwrod => Mick1985! */
INSERT dbo.AspNetUsers (Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName)
VALUES('71B92F40-CFA8-4E26-828D-C4BDC31B9C75','mick.tosk@gmail.com',0,'ADssD68xzV70+b+0FZbGj42CV9URHMB77d+UtAIx9fA8KzbZS2M19HpQwMgAc+s1Zw==','9960db17-28fc-48b4-b25d-96bb50194f6a',NULL,0,0,NULL,1,0,'mick.tosk@gmail.com');

INSERT INTO dbo.AspNetUserRoles (UserId,RoleId)
VALUES ('71B92F40-CFA8-4E26-828D-C4BDC31B9C75' ,'8C0EA7AA-3892-4B51-83CF-8F3A5BE6D8A3')
,('71B92F40-CFA8-4E26-828D-C4BDC31B9C75' ,'2BD650E1-A3E6-4D95-953B-191C7723DA42')
,('71B92F40-CFA8-4E26-828D-C4BDC31B9C75' ,'8E4B7C2F-5C2F-46E0-9779-3EFEA5E32FF6')
,('71B92F40-CFA8-4E26-828D-C4BDC31B9C75' ,'0C53A927-FE97-4010-AE00-94D078A470DE')

ALTER TABLE dbo.AspNetUserClaims WITH CHECK
ADD CONSTRAINT FK_AspNetUserClaimsAspNetUsers_User_Id
	FOREIGN KEY(User_Id)
	REFERENCES dbo.AspNetUsers(Id)ON DELETE CASCADE;

ALTER TABLE dbo.AspNetUserClaims CHECK CONSTRAINT FK_AspNetUserClaimsAspNetUsers_User_Id;

ALTER TABLE dbo.AspNetUserLogins WITH CHECK
ADD CONSTRAINT FK_AspNetUserLoginsAspNetUsers_UserId
	FOREIGN KEY(UserId)
	REFERENCES dbo.AspNetUsers(Id)ON DELETE CASCADE;

ALTER TABLE dbo.AspNetUserLogins CHECK CONSTRAINT FK_AspNetUserLoginsAspNetUsers_UserId;

ALTER TABLE dbo.AspNetUserRoles WITH CHECK
ADD CONSTRAINT FK_AspNetUserRolesAspNetRoles_RoleId
	FOREIGN KEY(RoleId)
	REFERENCES dbo.AspNetRoles(Id)ON DELETE CASCADE;

ALTER TABLE dbo.AspNetUserRoles CHECK CONSTRAINT FK_AspNetUserRolesAspNetRoles_RoleId;

ALTER TABLE dbo.AspNetUserRoles WITH CHECK
ADD CONSTRAINT FK_AspNetUserRolesAspNetUsers_UserId
	FOREIGN KEY(UserId)
	REFERENCES dbo.AspNetUsers(Id)ON DELETE CASCADE;

ALTER TABLE dbo.AspNetUserRoles CHECK CONSTRAINT FK_AspNetUserRolesAspNetUsers_UserId;