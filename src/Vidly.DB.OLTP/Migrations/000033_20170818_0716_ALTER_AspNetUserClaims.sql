-- <Migration ID="4071f183-27b3-41c1-9987-5ecc91d1447d" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.08.17
** CREATION:     Update AspNetUserClaims
**************************************************************************/
ALTER TABLE dbo.AspNetUserClaims DROP COLUMN user_id;
GO
ALTER TABLE dbo.AspNetUserClaims 
ADD CONSTRAINT FK_AspNetUserClaimsAspNetUsers_UserId
	FOREIGN KEY(UserId)
	REFERENCES dbo.AspNetUsers(Id)ON DELETE CASCADE;

ALTER TABLE dbo.AspNetUserClaims CHECK CONSTRAINT FK_AspNetUserClaimsAspNetUsers_UserId;