
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/15/2019 20:33:12
-- Generated from EDMX file: C:\Users\Alejandro\source\repos\SistemaWeb\SistemaWeb\Contexto\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [sistema_horario];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_cod_dpto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[carrera] DROP CONSTRAINT [FK_cod_dpto];
GO
IF OBJECT_ID(N'[dbo].[FK_cod_dptos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aula] DROP CONSTRAINT [FK_cod_dptos];
GO
IF OBJECT_ID(N'[dbo].[FK_cod_faculta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[dpto] DROP CONSTRAINT [FK_cod_faculta];
GO
IF OBJECT_ID(N'[dbo].[FK_aula_tipoaula]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aula] DROP CONSTRAINT [FK_aula_tipoaula];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_grupo_pensum]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[grupo] DROP CONSTRAINT [FK_grupo_pensum];
GO
IF OBJECT_ID(N'[dbo].[FK_horario_aula]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[horario] DROP CONSTRAINT [FK_horario_aula];
GO
IF OBJECT_ID(N'[dbo].[FK_horario_pensum]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[horario] DROP CONSTRAINT [FK_horario_pensum];
GO
IF OBJECT_ID(N'[dbo].[FK_horario_periodo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[horario] DROP CONSTRAINT [FK_horario_periodo];
GO
IF OBJECT_ID(N'[dbo].[FK_horario_profesores]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[horario] DROP CONSTRAINT [FK_horario_profesores];
GO
IF OBJECT_ID(N'[dbo].[FK_inportarcion_carrera]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[inportarcion] DROP CONSTRAINT [FK_inportarcion_carrera];
GO
IF OBJECT_ID(N'[dbo].[FK_inportarcion_dpto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[inportarcion] DROP CONSTRAINT [FK_inportarcion_dpto];
GO
IF OBJECT_ID(N'[dbo].[FK_inportarcion_materia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[inportarcion] DROP CONSTRAINT [FK_inportarcion_materia];
GO
IF OBJECT_ID(N'[dbo].[FK_inportarcion_profesores]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[inportarcion] DROP CONSTRAINT [FK_inportarcion_profesores];
GO
IF OBJECT_ID(N'[dbo].[FK_pensum_materia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[pensum] DROP CONSTRAINT [FK_pensum_materia];
GO
IF OBJECT_ID(N'[dbo].[FK_pensum_Plans]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[pensum] DROP CONSTRAINT [FK_pensum_Plans];
GO
IF OBJECT_ID(N'[dbo].[FK_Plans_carrera]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Plans] DROP CONSTRAINT [FK_Plans_carrera];
GO
IF OBJECT_ID(N'[dbo].[FK_profesores_dpto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[profesores] DROP CONSTRAINT [FK_profesores_dpto];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[anolectivo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[anolectivo];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[aula]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aula];
GO
IF OBJECT_ID(N'[dbo].[carrera]', 'U') IS NOT NULL
    DROP TABLE [dbo].[carrera];
GO
IF OBJECT_ID(N'[dbo].[dia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dia];
GO
IF OBJECT_ID(N'[dbo].[dpto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dpto];
GO
IF OBJECT_ID(N'[dbo].[faculta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[faculta];
GO
IF OBJECT_ID(N'[dbo].[grupo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[grupo];
GO
IF OBJECT_ID(N'[dbo].[horario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[horario];
GO
IF OBJECT_ID(N'[dbo].[inportarcion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[inportarcion];
GO
IF OBJECT_ID(N'[dbo].[materia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[materia];
GO
IF OBJECT_ID(N'[dbo].[pensum]', 'U') IS NOT NULL
    DROP TABLE [dbo].[pensum];
GO
IF OBJECT_ID(N'[dbo].[periodo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[periodo];
GO
IF OBJECT_ID(N'[dbo].[Plans]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Plans];
GO
IF OBJECT_ID(N'[dbo].[profesores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[profesores];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[tipoaula]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tipoaula];
GO
IF OBJECT_ID(N'[sistema_horarioModelStoreContainer].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [sistema_horarioModelStoreContainer].[Usuarios];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'anolectivoes'
CREATE TABLE [dbo].[anolectivoes] (
    [cod_ano] int IDENTITY(1,1) NOT NULL,
    [ano] varchar(4)  NOT NULL
);
GO

-- Creating table 'aulas'
CREATE TABLE [dbo].[aulas] (
    [cod_aula] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(45)  NOT NULL,
    [ubicasion] varchar(45)  NOT NULL,
    [ac] varchar(45)  NOT NULL,
    [capacidad] int  NOT NULL,
    [n_equipo] int  NULL,
    [cod_tipoaula] int  NOT NULL,
    [cod_dpto] int  NOT NULL
);
GO

-- Creating table 'carreras'
CREATE TABLE [dbo].[carreras] (
    [cod_carrera] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(100)  NOT NULL,
    [tipo_carrera] varchar(50)  NOT NULL,
    [modalidad] varchar(45)  NOT NULL,
    [cod_dpto] int  NOT NULL
);
GO

-- Creating table 'dptoes'
CREATE TABLE [dbo].[dptoes] (
    [cod_dpto] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(100)  NOT NULL,
    [cod_faculta] int  NOT NULL
);
GO

-- Creating table 'facultas'
CREATE TABLE [dbo].[facultas] (
    [cod_faculta] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(100)  NOT NULL,
    [telefono] varchar(8)  NOT NULL,
    [direccion] varchar(80)  NOT NULL
);
GO

-- Creating table 'grupoes'
CREATE TABLE [dbo].[grupoes] (
    [cod_grupo] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(45)  NOT NULL,
    [capacidad] int  NOT NULL,
    [tipo_ciclo] varchar(45)  NOT NULL,
    [cod_asig] int  NOT NULL
);
GO

-- Creating table 'horarios'
CREATE TABLE [dbo].[horarios] (
    [cod_horario] int IDENTITY(1,1) NOT NULL,
    [cod_periodo] int  NULL,
    [fecha_ini] varchar(45)  NULL,
    [cod_asig] int  NOT NULL,
    [cod_aula] int  NOT NULL,
    [cod_grupo] nvarchar(5)  NOT NULL,
    [inss] varchar(45)  NOT NULL,
    [cod_dias] int  NULL
);
GO

-- Creating table 'materias'
CREATE TABLE [dbo].[materias] (
    [cod_materia] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(100)  NOT NULL
);
GO

-- Creating table 'pensums'
CREATE TABLE [dbo].[pensums] (
    [cod_asig] int IDENTITY(1,1) NOT NULL,
    [N_credito] int  NOT NULL,
    [ciclo] int  NOT NULL,
    [anio_est] varchar(4)  NULL,
    [prerrequisito1] varchar(100)  NULL,
    [prerrequisito2] varchar(100)  NULL,
    [cod_plan] int  NOT NULL,
    [cod_materia] int  NOT NULL,
    [total_horas] int  NOT NULL
);
GO

-- Creating table 'periodoes'
CREATE TABLE [dbo].[periodoes] (
    [cod_periodo] int IDENTITY(1,1) NOT NULL,
    [periodo1] varchar(20)  NOT NULL
);
GO

-- Creating table 'Plans'
CREATE TABLE [dbo].[Plans] (
    [cod_plan] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(100)  NOT NULL,
    [total_credito] int  NOT NULL,
    [fecha_ini] datetime  NULL,
    [fecha_fin] datetime  NULL,
    [Nciclos] int  NULL,
    [cod_carrera] int  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'tipoaulas'
CREATE TABLE [dbo].[tipoaulas] (
    [cod_tipoaula] int IDENTITY(1,1) NOT NULL,
    [nombre_tipo] varchar(100)  NOT NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [correo] varchar(40)  NOT NULL,
    [nombre] varchar(45)  NOT NULL,
    [apellido] varchar(45)  NOT NULL,
    [foto] varchar(45)  NULL,
    [pass] varchar(45)  NOT NULL
);
GO

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'inportarcions'
CREATE TABLE [dbo].[inportarcions] (
    [id] int IDENTITY(1,1) NOT NULL,
    [inss] varchar(45)  NOT NULL,
    [cod_dpto] int  NULL,
    [cod_asignatura] int  NULL,
    [cod_carrera] int  NOT NULL,
    [grupo] varchar(10)  NOT NULL,
    [hora_grupo] int  NOT NULL,
    [tipo_ciclo] varchar(2)  NOT NULL,
    [tipo_grupo] varchar(10)  NULL
);
GO

-- Creating table 'profesores'
CREATE TABLE [dbo].[profesores] (
    [inss] varchar(45)  NOT NULL,
    [cedula] varchar(45)  NOT NULL,
    [nombre] varchar(60)  NOT NULL,
    [apellido] varchar(60)  NOT NULL,
    [telefono] int  NULL,
    [direccion] varchar(100)  NULL,
    [foto_ruta] varchar(200)  NULL,
    [cod_dpto] int  NOT NULL
);
GO

-- Creating table 'dias'
CREATE TABLE [dbo].[dias] (
    [id] int IDENTITY(1,1) NOT NULL,
    [dias] varchar(20)  NOT NULL
);
GO

-- Creating table 'horario_generacion'
CREATE TABLE [dbo].[horario_generacion] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [cod_carrera] int  NOT NULL,
    [tipo_ciclo] nvarchar(max)  NOT NULL,
    [fecha_ini] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [cod_ano] in table 'anolectivoes'
ALTER TABLE [dbo].[anolectivoes]
ADD CONSTRAINT [PK_anolectivoes]
    PRIMARY KEY CLUSTERED ([cod_ano] ASC);
GO

-- Creating primary key on [cod_aula] in table 'aulas'
ALTER TABLE [dbo].[aulas]
ADD CONSTRAINT [PK_aulas]
    PRIMARY KEY CLUSTERED ([cod_aula] ASC);
GO

-- Creating primary key on [cod_carrera] in table 'carreras'
ALTER TABLE [dbo].[carreras]
ADD CONSTRAINT [PK_carreras]
    PRIMARY KEY CLUSTERED ([cod_carrera] ASC);
GO

-- Creating primary key on [cod_dpto] in table 'dptoes'
ALTER TABLE [dbo].[dptoes]
ADD CONSTRAINT [PK_dptoes]
    PRIMARY KEY CLUSTERED ([cod_dpto] ASC);
GO

-- Creating primary key on [cod_faculta] in table 'facultas'
ALTER TABLE [dbo].[facultas]
ADD CONSTRAINT [PK_facultas]
    PRIMARY KEY CLUSTERED ([cod_faculta] ASC);
GO

-- Creating primary key on [cod_grupo] in table 'grupoes'
ALTER TABLE [dbo].[grupoes]
ADD CONSTRAINT [PK_grupoes]
    PRIMARY KEY CLUSTERED ([cod_grupo] ASC);
GO

-- Creating primary key on [cod_horario] in table 'horarios'
ALTER TABLE [dbo].[horarios]
ADD CONSTRAINT [PK_horarios]
    PRIMARY KEY CLUSTERED ([cod_horario] ASC);
GO

-- Creating primary key on [cod_materia] in table 'materias'
ALTER TABLE [dbo].[materias]
ADD CONSTRAINT [PK_materias]
    PRIMARY KEY CLUSTERED ([cod_materia] ASC);
GO

-- Creating primary key on [cod_asig] in table 'pensums'
ALTER TABLE [dbo].[pensums]
ADD CONSTRAINT [PK_pensums]
    PRIMARY KEY CLUSTERED ([cod_asig] ASC);
GO

-- Creating primary key on [cod_periodo] in table 'periodoes'
ALTER TABLE [dbo].[periodoes]
ADD CONSTRAINT [PK_periodoes]
    PRIMARY KEY CLUSTERED ([cod_periodo] ASC);
GO

-- Creating primary key on [cod_plan] in table 'Plans'
ALTER TABLE [dbo].[Plans]
ADD CONSTRAINT [PK_Plans]
    PRIMARY KEY CLUSTERED ([cod_plan] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [cod_tipoaula] in table 'tipoaulas'
ALTER TABLE [dbo].[tipoaulas]
ADD CONSTRAINT [PK_tipoaulas]
    PRIMARY KEY CLUSTERED ([cod_tipoaula] ASC);
GO

-- Creating primary key on [correo], [nombre], [apellido], [pass] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([correo], [nombre], [apellido], [pass] ASC);
GO

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'inportarcions'
ALTER TABLE [dbo].[inportarcions]
ADD CONSTRAINT [PK_inportarcions]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [inss] in table 'profesores'
ALTER TABLE [dbo].[profesores]
ADD CONSTRAINT [PK_profesores]
    PRIMARY KEY CLUSTERED ([inss] ASC);
GO

-- Creating primary key on [id] in table 'dias'
ALTER TABLE [dbo].[dias]
ADD CONSTRAINT [PK_dias]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'horario_generacion'
ALTER TABLE [dbo].[horario_generacion]
ADD CONSTRAINT [PK_horario_generacion]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [cod_dpto] in table 'aulas'
ALTER TABLE [dbo].[aulas]
ADD CONSTRAINT [FK_cod_dptos]
    FOREIGN KEY ([cod_dpto])
    REFERENCES [dbo].[dptoes]
        ([cod_dpto])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_cod_dptos'
CREATE INDEX [IX_FK_cod_dptos]
ON [dbo].[aulas]
    ([cod_dpto]);
GO

-- Creating foreign key on [cod_tipoaula] in table 'aulas'
ALTER TABLE [dbo].[aulas]
ADD CONSTRAINT [FK_aula_tipoaula]
    FOREIGN KEY ([cod_tipoaula])
    REFERENCES [dbo].[tipoaulas]
        ([cod_tipoaula])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_aula_tipoaula'
CREATE INDEX [IX_FK_aula_tipoaula]
ON [dbo].[aulas]
    ([cod_tipoaula]);
GO

-- Creating foreign key on [cod_aula] in table 'horarios'
ALTER TABLE [dbo].[horarios]
ADD CONSTRAINT [FK_horario_aula]
    FOREIGN KEY ([cod_aula])
    REFERENCES [dbo].[aulas]
        ([cod_aula])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_horario_aula'
CREATE INDEX [IX_FK_horario_aula]
ON [dbo].[horarios]
    ([cod_aula]);
GO

-- Creating foreign key on [cod_dpto] in table 'carreras'
ALTER TABLE [dbo].[carreras]
ADD CONSTRAINT [FK_cod_dpto]
    FOREIGN KEY ([cod_dpto])
    REFERENCES [dbo].[dptoes]
        ([cod_dpto])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_cod_dpto'
CREATE INDEX [IX_FK_cod_dpto]
ON [dbo].[carreras]
    ([cod_dpto]);
GO

-- Creating foreign key on [cod_carrera] in table 'Plans'
ALTER TABLE [dbo].[Plans]
ADD CONSTRAINT [FK_Plans_carrera]
    FOREIGN KEY ([cod_carrera])
    REFERENCES [dbo].[carreras]
        ([cod_carrera])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Plans_carrera'
CREATE INDEX [IX_FK_Plans_carrera]
ON [dbo].[Plans]
    ([cod_carrera]);
GO

-- Creating foreign key on [cod_faculta] in table 'dptoes'
ALTER TABLE [dbo].[dptoes]
ADD CONSTRAINT [FK_cod_faculta]
    FOREIGN KEY ([cod_faculta])
    REFERENCES [dbo].[facultas]
        ([cod_faculta])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_cod_faculta'
CREATE INDEX [IX_FK_cod_faculta]
ON [dbo].[dptoes]
    ([cod_faculta]);
GO

-- Creating foreign key on [cod_asig] in table 'grupoes'
ALTER TABLE [dbo].[grupoes]
ADD CONSTRAINT [FK_grupo_pensum]
    FOREIGN KEY ([cod_asig])
    REFERENCES [dbo].[pensums]
        ([cod_asig])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_grupo_pensum'
CREATE INDEX [IX_FK_grupo_pensum]
ON [dbo].[grupoes]
    ([cod_asig]);
GO

-- Creating foreign key on [cod_asig] in table 'horarios'
ALTER TABLE [dbo].[horarios]
ADD CONSTRAINT [FK_horario_pensum]
    FOREIGN KEY ([cod_asig])
    REFERENCES [dbo].[pensums]
        ([cod_asig])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_horario_pensum'
CREATE INDEX [IX_FK_horario_pensum]
ON [dbo].[horarios]
    ([cod_asig]);
GO

-- Creating foreign key on [cod_periodo] in table 'horarios'
ALTER TABLE [dbo].[horarios]
ADD CONSTRAINT [FK_horario_periodo]
    FOREIGN KEY ([cod_periodo])
    REFERENCES [dbo].[periodoes]
        ([cod_periodo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_horario_periodo'
CREATE INDEX [IX_FK_horario_periodo]
ON [dbo].[horarios]
    ([cod_periodo]);
GO

-- Creating foreign key on [cod_materia] in table 'pensums'
ALTER TABLE [dbo].[pensums]
ADD CONSTRAINT [FK_pensum_materia]
    FOREIGN KEY ([cod_materia])
    REFERENCES [dbo].[materias]
        ([cod_materia])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_pensum_materia'
CREATE INDEX [IX_FK_pensum_materia]
ON [dbo].[pensums]
    ([cod_materia]);
GO

-- Creating foreign key on [cod_plan] in table 'pensums'
ALTER TABLE [dbo].[pensums]
ADD CONSTRAINT [FK_pensum_Plans]
    FOREIGN KEY ([cod_plan])
    REFERENCES [dbo].[Plans]
        ([cod_plan])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_pensum_Plans'
CREATE INDEX [IX_FK_pensum_Plans]
ON [dbo].[pensums]
    ([cod_plan]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRole]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUser]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUser'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUser]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- Creating foreign key on [cod_carrera] in table 'inportarcions'
ALTER TABLE [dbo].[inportarcions]
ADD CONSTRAINT [FK_inportarcion_carrera]
    FOREIGN KEY ([cod_carrera])
    REFERENCES [dbo].[carreras]
        ([cod_carrera])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_inportarcion_carrera'
CREATE INDEX [IX_FK_inportarcion_carrera]
ON [dbo].[inportarcions]
    ([cod_carrera]);
GO

-- Creating foreign key on [cod_dpto] in table 'inportarcions'
ALTER TABLE [dbo].[inportarcions]
ADD CONSTRAINT [FK_inportarcion_dpto]
    FOREIGN KEY ([cod_dpto])
    REFERENCES [dbo].[dptoes]
        ([cod_dpto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_inportarcion_dpto'
CREATE INDEX [IX_FK_inportarcion_dpto]
ON [dbo].[inportarcions]
    ([cod_dpto]);
GO

-- Creating foreign key on [cod_dpto] in table 'profesores'
ALTER TABLE [dbo].[profesores]
ADD CONSTRAINT [FK_profesores_dpto]
    FOREIGN KEY ([cod_dpto])
    REFERENCES [dbo].[dptoes]
        ([cod_dpto])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_profesores_dpto'
CREATE INDEX [IX_FK_profesores_dpto]
ON [dbo].[profesores]
    ([cod_dpto]);
GO

-- Creating foreign key on [inss] in table 'horarios'
ALTER TABLE [dbo].[horarios]
ADD CONSTRAINT [FK_horario_profesores]
    FOREIGN KEY ([inss])
    REFERENCES [dbo].[profesores]
        ([inss])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_horario_profesores'
CREATE INDEX [IX_FK_horario_profesores]
ON [dbo].[horarios]
    ([inss]);
GO

-- Creating foreign key on [cod_asignatura] in table 'inportarcions'
ALTER TABLE [dbo].[inportarcions]
ADD CONSTRAINT [FK_inportarcion_materia]
    FOREIGN KEY ([cod_asignatura])
    REFERENCES [dbo].[materias]
        ([cod_materia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_inportarcion_materia'
CREATE INDEX [IX_FK_inportarcion_materia]
ON [dbo].[inportarcions]
    ([cod_asignatura]);
GO

-- Creating foreign key on [inss] in table 'inportarcions'
ALTER TABLE [dbo].[inportarcions]
ADD CONSTRAINT [FK_inportarcion_profesores]
    FOREIGN KEY ([inss])
    REFERENCES [dbo].[profesores]
        ([inss])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_inportarcion_profesores'
CREATE INDEX [IX_FK_inportarcion_profesores]
ON [dbo].[inportarcions]
    ([inss]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------