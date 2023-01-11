IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230111025146_InitialMigration')
BEGIN
    CREATE TABLE [Employees] (
        [EmployeeId] int NOT NULL IDENTITY,
        [EmployeeName] nvarchar(max) NOT NULL,
        [EmployeeDescription] nvarchar(100) NULL,
        CONSTRAINT [PK_Employees] PRIMARY KEY ([EmployeeId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230111025146_InitialMigration')
BEGIN
    CREATE TABLE [Departments] (
        [DepartmentId] int NOT NULL IDENTITY,
        [DepartmentName] nvarchar(max) NOT NULL,
        [DepartmentDescription] nvarchar(250) NULL,
        [EmployeesId] int NOT NULL,
        CONSTRAINT [PK_Departments] PRIMARY KEY ([DepartmentId]),
        CONSTRAINT [FK_Departments_Employees_EmployeesId] FOREIGN KEY ([EmployeesId]) REFERENCES [Employees] ([EmployeeId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230111025146_InitialMigration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'DepartmentId', N'DepartmentDescription', N'DepartmentName', N'EmployeesId') AND [object_id] = OBJECT_ID(N'[Departments]'))
        SET IDENTITY_INSERT [Departments] ON;
    INSERT INTO [Departments] ([DepartmentId], [DepartmentDescription], [DepartmentName], [EmployeesId])
    VALUES (1, N'Software team working on smart tooling.', N'IT', 0),
    (2, N'Making Designs of products according to customer requirment.', N'Design', 0),
    (3, N'Field working at client place to resolve machine problems.', N'Service', 0),
    (4, N'Bringing clients to purchase the product.', N'Sales', 0),
    (5, N'Office work.', N'Managment', 0);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'DepartmentId', N'DepartmentDescription', N'DepartmentName', N'EmployeesId') AND [object_id] = OBJECT_ID(N'[Departments]'))
        SET IDENTITY_INSERT [Departments] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230111025146_InitialMigration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EmployeeId', N'EmployeeDescription', N'EmployeeName') AND [object_id] = OBJECT_ID(N'[Employees]'))
        SET IDENTITY_INSERT [Employees] ON;
    INSERT INTO [Employees] ([EmployeeId], [EmployeeDescription], [EmployeeName])
    VALUES (1, N'IT Department Head', N'Kapil Bhudhia'),
    (2, N'Product Lead Industry 4.0', N'Sagar Shende'),
    (3, N'Product Lead Industry 4.0', N'Amit Tilekar'),
    (4, N'Senior Software Engineer', N'Prashant Deshmukh'),
    (5, N'Junior Software Engineer', N'Omkar Kadam');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EmployeeId', N'EmployeeDescription', N'EmployeeName') AND [object_id] = OBJECT_ID(N'[Employees]'))
        SET IDENTITY_INSERT [Employees] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230111025146_InitialMigration')
BEGIN
    CREATE INDEX [IX_Departments_EmployeesId] ON [Departments] ([EmployeesId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230111025146_InitialMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230111025146_InitialMigration', N'3.0.0');
END;

GO

