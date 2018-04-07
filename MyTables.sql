CREATE TABLE [dbo].[Forums] (
    [ForumID] INT           IDENTITY (1, 1) NOT NULL,
    [Title]   NVARCHAR (30) NOT NULL,
    [AddedBy] NVARCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([ForumID] ASC)
);

CREATE TABLE [dbo].[Posts] (
    [PostID]    INT            IDENTITY (1, 1) NOT NULL,
    [Title]     NVARCHAR (200) NOT NULL,
    [AddedBy]   NVARCHAR (30)  NULL,
    [AddedDate] DATETIME       NULL,
    [Body]      NVARCHAR (500) NOT NULL,
    [ViewCount] INT            NULL,
    [Approved]  BIT            NOT NULL,
    [closed]    BIT            NOT NULL,
    [ForumID]   INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([PostID] ASC),
    FOREIGN KEY ([ForumID]) REFERENCES [dbo].[Forums] ([ForumID])
);

CREATE TABLE [dbo].[Comments] (
    [CommentID] INT            IDENTITY (1, 1) NOT NULL,
    [AddedDate] DATETIME       NULL,
    [Title]     NVARCHAR (200) NOT NULL,
    [Body]      NVARCHAR (500) NOT NULL,
    [Approved]  BIT            NOT NULL,
    [PostID]    INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([CommentID] ASC),
    FOREIGN KEY ([PostID]) REFERENCES [dbo].[Posts] ([PostID])
);

