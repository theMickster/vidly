-- <Migration ID="19507251-5773-48b1-b7d1-e81a6d3bb05c" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.08.15
** CREATION:     Rename build user claims table
**************************************************************************/
DROP TABLE dbo.AspNetUserClaims
CREATE TABLE dbo.AspNetUserClaims
(
	Id INT IDENTITY(1, 1) NOT NULL
	,ClaimType NVARCHAR(MAX) NULL
	,ClaimValue NVARCHAR(MAX) NULL
	,UserId NVARCHAR(128) NOT NULL
	,CONSTRAINT PK_AspNetUserClaims PRIMARY KEY CLUSTERED(Id ASC)
)