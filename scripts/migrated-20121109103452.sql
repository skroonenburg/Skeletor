/* Using Database sqlserver2008 and Connection String Data Source=localhost;Initial Catalog=Grayskull;Integrated Security=true */
/* Beginning Transaction */
/* VersionMigration migrating ================================================ */

/* CreateTable VersionInfo */
CREATE TABLE [dbo].[VersionInfo] ([Version] BIGINT NOT NULL)

/* VersionMigration migrated */

/* VersionUniqueMigration migrating ========================================== */

/* CreateIndex VersionInfo (Version) */
CREATE UNIQUE CLUSTERED INDEX [UC_Version] ON [dbo].[VersionInfo] ([Version] ASC)

/* AlterTable VersionInfo */
/* No SQL statement executed. */

/* CreateColumn VersionInfo AppliedOn DateTime */
ALTER TABLE [dbo].[VersionInfo] ADD [AppliedOn] DATETIME

/* VersionUniqueMigration migrated */

/* 201210031600: CreateUserTable migrating =================================== */

/* CreateTable User */
CREATE TABLE [dbo].[User] ([UserId] UNIQUEIDENTIFIER NOT NULL, [IsDeleted] BIT NOT NULL CONSTRAINT DF_User_IsDeleted DEFAULT 0, [RowVersion] INT NOT NULL, [CreatedByUserId] UNIQUEIDENTIFIER, [CreatedUtcDate] DATETIME, [ModifiedByUserId] UNIQUEIDENTIFIER, [ModifiedUtcDate] DATETIME, [UserName] NVARCHAR(200) NOT NULL, [FirstName] NVARCHAR(200) NOT NULL, [LastName] NVARCHAR(200) NOT NULL, [Email] NVARCHAR(255) NOT NULL, [IsSystem] BIT NOT NULL CONSTRAINT DF_User_IsSystem DEFAULT 0, [IsActive] BIT NOT NULL CONSTRAINT DF_User_IsActive DEFAULT 0, [IsLockedOut] BIT NOT NULL CONSTRAINT DF_User_IsLockedOut DEFAULT 0, [LastLockoutUtcDate] DATETIME, [PasswordHash] NVARCHAR(200) NOT NULL, [Salt] NVARCHAR(100) NOT NULL, [PasswordExpiry] DATETIME NOT NULL, CONSTRAINT [PK_User] PRIMARY KEY ([UserId]))

/* 201210031600: CreateUserTable migrated */

INSERT INTO [dbo].[VersionInfo] ([Version], [AppliedOn]) VALUES (201210031600, '2012-11-09T02:34:53')
/* 201210041920: CreateRoleTable migrating =================================== */

/* CreateTable Role */
CREATE TABLE [dbo].[Role] ([RoleId] UNIQUEIDENTIFIER NOT NULL, [IsDeleted] BIT NOT NULL CONSTRAINT DF_Role_IsDeleted DEFAULT 0, [RowVersion] INT NOT NULL, [CreatedByUserId] UNIQUEIDENTIFIER, [CreatedUtcDate] DATETIME, [ModifiedByUserId] UNIQUEIDENTIFIER, [ModifiedUtcDate] DATETIME, [Name] NVARCHAR(200) NOT NULL, [IsActive] BIT NOT NULL CONSTRAINT DF_Role_IsActive DEFAULT 0, CONSTRAINT [PK_Role] PRIMARY KEY ([RoleId]))

/* 201210041920: CreateRoleTable migrated */

INSERT INTO [dbo].[VersionInfo] ([Version], [AppliedOn]) VALUES (201210041920, '2012-11-09T02:34:53')
/* 201210041930: CreateUserRoleTable migrating =============================== */

/* CreateTable [UserRole] */
CREATE TABLE [dbo].[UserRole] ([RoleId] UNIQUEIDENTIFIER NOT NULL, [UserId] UNIQUEIDENTIFIER NOT NULL)

/* CreateConstraint Pk_UserRole_RoleIdUserId */
ALTER TABLE [dbo].[UserRole] ADD CONSTRAINT [Pk_UserRole_RoleIdUserId] PRIMARY KEY ([RoleId], [UserId])

/* CreateForeignKey Fk_UserRole_UserId [UserRole](UserId) [User](UserId) */
ALTER TABLE [dbo].[UserRole] ADD CONSTRAINT [Fk_UserRole_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])

/* CreateForeignKey Fk_UserRole_RoleId [UserRole](RoleId) [Role](RoleId) */
ALTER TABLE [dbo].[UserRole] ADD CONSTRAINT [Fk_UserRole_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId])

/* 201210041930: CreateUserRoleTable migrated */

INSERT INTO [dbo].[VersionInfo] ([Version], [AppliedOn]) VALUES (201210041930, '2012-11-09T02:34:53')
/* 201210041940: CreatePermissionTable migrating ============================= */

/* CreateTable [Permission] */
CREATE TABLE [dbo].[Permission] ([PermissionId] UNIQUEIDENTIFIER NOT NULL, [Name] NVARCHAR(200) NOT NULL, [PasswordExpiry] DATETIME NOT NULL, [CreatedByUserId] UNIQUEIDENTIFIER, [CreatedUtcDate] DATETIME, [ModifiedByUserId] UNIQUEIDENTIFIER, [ModifiedUtcDate] DATETIME, CONSTRAINT [PK_[Permission]]] PRIMARY KEY ([PermissionId]))

/* 201210041940: CreatePermissionTable migrated */

INSERT INTO [dbo].[VersionInfo] ([Version], [AppliedOn]) VALUES (201210041940, '2012-11-09T02:34:53')
/* 201210181600: CreateRolePermissionTable migrating ========================= */

/* CreateTable [RolePermission] */
CREATE TABLE [dbo].[RolePermission] ([RoleId] UNIQUEIDENTIFIER NOT NULL, [PermissionId] UNIQUEIDENTIFIER NOT NULL)

/* CreateConstraint Pk_RolePermission_RoleIdUserId */
ALTER TABLE [dbo].[RolePermission] ADD CONSTRAINT [Pk_RolePermission_RoleIdUserId] PRIMARY KEY ([RoleId], [PermissionId])

/* CreateForeignKey Fk_RolePermission_UserId [RolePermission](PermissionId) [Permission](PermissionId) */
ALTER TABLE [dbo].[RolePermission] ADD CONSTRAINT [Fk_RolePermission_UserId] FOREIGN KEY ([PermissionId]) REFERENCES [dbo].[Permission] ([PermissionId])

/* CreateForeignKey Fk_RolePermission_RoleId [RolePermission](RoleId) [Role](RoleId) */
ALTER TABLE [dbo].[RolePermission] ADD CONSTRAINT [Fk_RolePermission_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId])

/* 201210181600: CreateRolePermissionTable migrated */

INSERT INTO [dbo].[VersionInfo] ([Version], [AppliedOn]) VALUES (201210181600, '2012-11-09T02:34:53')
/* 201210181601: CreateAuditTable migrating ================================== */

/* CreateTable Audit */
CREATE TABLE [dbo].[Audit] ([AuditId] UNIQUEIDENTIFIER NOT NULL, [Description] NVARCHAR(500) NOT NULL, [CreatedUtcDate] DATETIME NOT NULL, [CreatedBy] UNIQUEIDENTIFIER NOT NULL, CONSTRAINT [PK_Audit] PRIMARY KEY ([AuditId]))

/* 201210181601: CreateAuditTable migrated */

INSERT INTO [dbo].[VersionInfo] ([Version], [AppliedOn]) VALUES (201210181601, '2012-11-09T02:34:53')
/* 201210181605: CreateAuditActionTypeTable migrating ======================== */

/* CreateTable AuditActionType */
CREATE TABLE [dbo].[AuditActionType] ([AuditActionTypeId] UNIQUEIDENTIFIER NOT NULL, [Name] NVARCHAR(50) NOT NULL, CONSTRAINT [PK_AuditActionType] PRIMARY KEY ([AuditActionTypeId]))

/* 201210181605: CreateAuditActionTypeTable migrated */

INSERT INTO [dbo].[VersionInfo] ([Version], [AppliedOn]) VALUES (201210181605, '2012-11-09T02:34:53')
/* 201210181610: CreateAuditDetailTable migrating ============================ */

/* CreateTable AuditDetail */
CREATE TABLE [dbo].[AuditDetail] ([AuditDetailId] UNIQUEIDENTIFIER NOT NULL, [AuditId] UNIQUEIDENTIFIER NOT NULL, [EntityType] NVARCHAR(50) NOT NULL, [EntityKey] NVARCHAR(50) NOT NULL, [AuditActionTypeId] UNIQUEIDENTIFIER NOT NULL, [PropertyName] NVARCHAR(100) NOT NULL, [OriginalValue] NVARCHAR(MAX), [CurrentValue] NVARCHAR(MAX), CONSTRAINT [PK_AuditDetail] PRIMARY KEY ([AuditDetailId]))

/* CreateForeignKey Fk_AuditActionDetail_AuditActionTypeId [AuditDetail](AuditActionTypeId) [AuditActionType](AuditActionTypeId) */
ALTER TABLE [dbo].[AuditDetail] ADD CONSTRAINT [Fk_AuditActionDetail_AuditActionTypeId] FOREIGN KEY ([AuditActionTypeId]) REFERENCES [dbo].[AuditActionType] ([AuditActionTypeId])

/* CreateForeignKey Fk_AuditDetail_AuditId [AuditDetail](AuditId) [Audit](AuditId) */
ALTER TABLE [dbo].[AuditDetail] ADD CONSTRAINT [Fk_AuditDetail_AuditId] FOREIGN KEY ([AuditId]) REFERENCES [dbo].[Audit] ([AuditId])

/* 201210181610: CreateAuditDetailTable migrated */

INSERT INTO [dbo].[VersionInfo] ([Version], [AppliedOn]) VALUES (201210181610, '2012-11-09T02:34:53')
/* 201210311611: CreateDefaultData migrating ================================= */

INSERT INTO [dbo].[Role] ([RoleId], [Name], [IsActive], [RowVersion], [CreatedByUserId], [CreatedUtcDate]) VALUES ('a781a9d2-3105-4f9a-a1f2-cf8f9b6e2789', 'Administrator', 1, 1, '00000000-0000-0000-0000-000000000000', '2012-11-09T02:34:53')
INSERT INTO [dbo].[AuditActionType] ([AuditActionTypeId], [Name]) VALUES ('750e895c-f0a6-45ab-85e4-abcf98caf470', 'Create')
INSERT INTO [dbo].[AuditActionType] ([AuditActionTypeId], [Name]) VALUES ('750e895c-f0a6-45ab-85e4-abcf98caf471', 'Update')
INSERT INTO [dbo].[AuditActionType] ([AuditActionTypeId], [Name]) VALUES ('750e895c-f0a6-45ab-85e4-abcf98caf472', 'Delete')
INSERT INTO [dbo].[AuditActionType] ([AuditActionTypeId], [Name]) VALUES ('750e895c-f0a6-45ab-85e4-abcf98caf473', 'Soft Delete')
/* -> 5 Insert operations completed in 00:00:00.0020000 taking an average of 00:00:00.0004000 */
/* 201210311611: CreateDefaultData migrated */

INSERT INTO [dbo].[VersionInfo] ([Version], [AppliedOn]) VALUES (201210311611, '2012-11-09T02:34:53')
/* Committing Transaction */
/* Task completed. */
