CREATE TABLE [dbo].[StudentCourse] (
    [StudentId] INT NOT NULL,
    [CourseId]  INT NOT NULL,
    CONSTRAINT [PK_dbo.StudentCourse] PRIMARY KEY CLUSTERED ([StudentId] ASC, [CourseId] ASC),
    CONSTRAINT [FK_dbo.StudentCourse_dbo.Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Courses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.StudentCourse_dbo.Students_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_StudentId]
    ON [dbo].[StudentCourse]([StudentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CourseId]
    ON [dbo].[StudentCourse]([CourseId] ASC);

