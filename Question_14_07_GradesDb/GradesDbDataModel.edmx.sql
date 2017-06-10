
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/02/2017 14:30:09
-- Generated from EDMX file: C:\Projects\CrakingTheCodingInterview\Question_14_07_GradesDb\GradesDbDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GradesDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProfessorCourses]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Courses] DROP CONSTRAINT [FK_ProfessorCourses];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentEnrollment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Enrollments] DROP CONSTRAINT [FK_StudentEnrollment];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseEnrollment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Enrollments] DROP CONSTRAINT [FK_CourseEnrollment];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Students]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Students];
GO
IF OBJECT_ID(N'[dbo].[Courses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Courses];
GO
IF OBJECT_ID(N'[dbo].[Enrollments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Enrollments];
GO
IF OBJECT_ID(N'[dbo].[Professors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Professors];
GO

-- --------------------------------------------------
-- Dropping existing procedures
-- --------------------------------------------------

DROP PROC IF EXISTS [dbo].[sp_Purge] ;
GO

DROP PROC IF EXISTS [dbo].[sp_GetTop10PercentPerformingStudents];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Students'
CREATE TABLE [dbo].[Students] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NULL
);
GO

-- Creating table 'Courses'
CREATE TABLE [dbo].[Courses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ProfessorId] int  NOT NULL
);
GO

-- Creating table 'Enrollments'
CREATE TABLE [dbo].[Enrollments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Grade] float  NOT NULL,
    [Term] int  NOT NULL,
    [StudentId] int  NOT NULL,
    [CourseId] int  NOT NULL
);
GO

-- Creating table 'Professors'
CREATE TABLE [dbo].[Professors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [PK_Students]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [PK_Courses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Enrollments'
ALTER TABLE [dbo].[Enrollments]
ADD CONSTRAINT [PK_Enrollments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Professors'
ALTER TABLE [dbo].[Professors]
ADD CONSTRAINT [PK_Professors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProfessorId] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [FK_ProfessorCourses]
    FOREIGN KEY ([ProfessorId])
    REFERENCES [dbo].[Professors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfessorCourses'
CREATE INDEX [IX_FK_ProfessorCourses]
ON [dbo].[Courses]
    ([ProfessorId]);
GO

-- Creating foreign key on [StudentId] in table 'Enrollments'
ALTER TABLE [dbo].[Enrollments]
ADD CONSTRAINT [FK_StudentEnrollment]
    FOREIGN KEY ([StudentId])
    REFERENCES [dbo].[Students]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentEnrollment'
CREATE INDEX [IX_FK_StudentEnrollment]
ON [dbo].[Enrollments]
    ([StudentId]);
GO

-- Creating foreign key on [CourseId] in table 'Enrollments'
ALTER TABLE [dbo].[Enrollments]
ADD CONSTRAINT [FK_CourseEnrollment]
    FOREIGN KEY ([CourseId])
    REFERENCES [dbo].[Courses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseEnrollment'
CREATE INDEX [IX_FK_CourseEnrollment]
ON [dbo].[Enrollments]
    ([CourseId]);
GO

-- Creating stored procedures
CREATE PROCEDURE [dbo].[sp_Purge]
AS
	DELETE FROM Enrollments
	DELETE FROM Courses
	DELETE FROM Professors
	DELETE FROM Students
GO

CREATE PROCEDURE [dbo].[sp_GetTop10PercentPerformingStudents]
AS
	DECLARE @gpaCutoff float;
		
	SELECT @gpaCutoff = MIN(AvgGPA.GPA)
	FROM
		(SELECT TOP 10 PERCENT Enrollments.StudentId, AVG(Enrollments.Grade) as GPA
		 FROM Enrollments
		 GROUP BY Enrollments.StudentId
		 ORDER BY GPA desc) AvgGPA

	/*SELECT @gpaCutoff as 'minGPA'*/
	
	SELECT Students.Name, AVG(Enrollments.Grade) as GPA
	FROM Students INNER JOIN Enrollments
	ON Students.Id = Enrollments.StudentId
	GROUP BY Students.Id, Students.Name
	HAVING AVG(Enrollments.Grade) >= @gpaCutOff
	ORDER BY GPA desc
GO
-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------