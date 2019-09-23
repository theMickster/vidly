-- <Migration ID="f03e1f73-79c2-47da-9e25-65e2b441bbb4" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.07.23
** CREATION:     Create asp.net identity tables
**************************************************************************/
CREATE TABLE dbo.AspNetRoles
(
	Id NVARCHAR(128) NOT NULL
	,Name NVARCHAR(MAX) NOT NULL
	,CONSTRAINT PK_AspNetRoles PRIMARY KEY CLUSTERED(Id ASC)	
)
CREATE TABLE dbo.AspNetUserClaims
(
	Id INT IDENTITY(1, 1) NOT NULL
	,ClaimType NVARCHAR(MAX) NULL
	,ClaimValue NVARCHAR(MAX) NULL
	,User_Id NVARCHAR(128) NOT NULL
	,CONSTRAINT PK_AspNetUserClaims PRIMARY KEY CLUSTERED(Id ASC)
)
CREATE TABLE dbo.AspNetUserLogins
(
	UserId NVARCHAR(128) NOT NULL
	,LoginProvider NVARCHAR(128) NOT NULL
	,ProviderKey NVARCHAR(128) NOT NULL
	,CONSTRAINT PK_AspNetUserLogins PRIMARY KEY CLUSTERED(UserId ASC,LoginProvider ASC,ProviderKey ASC)
);
CREATE TABLE dbo.AspNetUserRoles
(
	UserId NVARCHAR(128) NOT NULL
	,RoleId NVARCHAR(128) NOT NULL
	,CONSTRAINT PK_AspNetUserRoles PRIMARY KEY CLUSTERED ( UserId ASC, RoleId ASC)	
);
CREATE TABLE dbo.AspNetUsers
(
	Id NVARCHAR(128) NOT NULL
	,UserName NVARCHAR(MAX) NULL
	,PasswordHash NVARCHAR(MAX) NULL
	,SecurityStamp NVARCHAR(MAX) NULL
	,Discriminator NVARCHAR(128) NOT NULL
	,CONSTRAINT PK_AspNetUsers PRIMARY KEY CLUSTERED(Id ASC)
)
CREATE NONCLUSTERED INDEX IX_User_Id ON dbo.AspNetUserClaims(User_Id ASC)
CREATE NONCLUSTERED INDEX IX_UserId ON dbo.AspNetUserLogins(UserId ASC)
CREATE NONCLUSTERED INDEX IX_RoleId ON dbo.AspNetUserRoles(RoleId ASC)
CREATE NONCLUSTERED INDEX IX_UserId ON dbo.AspNetUserRoles(UserId ASC)

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
