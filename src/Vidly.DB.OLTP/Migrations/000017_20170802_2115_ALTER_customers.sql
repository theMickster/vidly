-- <Migration ID="e5429bf5-48e7-49ea-893d-9fdaf7b77caa" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.08.02
** CREATION:     Add new field to customers table.
**************************************************************************/
ALTER TABLE dbo.customers ADD is_subscribed_to_newsletter BIT NOT NULL CONSTRAINT DF_customers_is_subscribed_to_newsletter DEFAULT (0);