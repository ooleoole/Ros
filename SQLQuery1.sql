USE Ros

CREATE TABLE [Addresses]
(
    [Id]            INT IDENTITY PRIMARY KEY,
    [Country]       NVARCHAR(64) NOT NULL,
    [City]          NVARCHAR(64) NOT NULL,
    [Street]        NVARCHAR(256) NOT NULL,
    [ZipCode]       NVARCHAR(16) NOT NULL,
    [BoxNo]         INT NULL,
    [Type]          NVARCHAR(32) NOT NULL,
    CONSTRAINT [con_Addresses] UNIQUE ([Country], [City], [Street], [ZipCode], [Type]),
    [Active]        BIT DEFAULT 1 NOT NULL,
    [sa_Info]       NVARCHAR(512) NULL
);
GO

CREATE TABLE [Clubs]
(
    [Id]                INT IDENTITY PRIMARY KEY,
    [Name]              NVARCHAR(512) UNIQUE NOT NULL,
    [RegistrationDate]  DATETIME DEFAULT GETDATE(),
    [Logo]              NVARCHAR(1024) NULL,
    [HomePage]          NVARCHAR(1024) NULL,
    [Description]       NVARCHAR(MAX) NULL,
    [AddressId]         INT FOREIGN KEY REFERENCES [Addresses]([Id]),
    [Active]            BIT DEFAULT 1 NOT NULL,
    [sa_Info]           NVARCHAR(512) NULL
);
GO

CREATE TABLE [UserRoles]
(
    [Id]        INT IDENTITY PRIMARY KEY,
    [Type]      NVARCHAR(32) UNIQUE NOT NULL,
    [Active]    BIT DEFAULT 1 NOT NULL,
    [sa_Info]   NVARCHAR(512) NULL
);
GO

CREATE TABLE [PhoneNumbers]
(
    [Id]         INT IDENTITY PRIMARY KEY,
    [Value]      NVARCHAR(32) UNIQUE NOT NULL,
    [Type]       NVARCHAR (32)  NOT NULL,
    [Active]     BIT DEFAULT 1 NOT NULL,
    [sa_Info]    NVARCHAR(512) NULL
);
GO

CREATE TABLE [ClubPhoneNumbers]
(
    [ClubId]            INT FOREIGN KEY REFERENCES [Clubs]([Id]),
    [PhoneNumberId]     INT FOREIGN KEY REFERENCES [PhoneNumbers]([Id]),
    CONSTRAINT [pk_Clubs_PhoneNumbers] PRIMARY KEY ([ClubId], [PhoneNumberId]),
    [Active]            BIT DEFAULT 1 NOT NULL,
    [sa_Info]           NVARCHAR(512) NULL
)

CREATE TABLE [Users]
(
    [Id]                INT IDENTITY PRIMARY KEY,
    [Login]             NVARCHAR(128) UNIQUE NOT NULL,
    [Password]          NVARCHAR(32) NOT NULL,
    [FirstName]         NVARCHAR(128) NOT NULL,
    [LastName]          NVARCHAR(128) NOT NULL,
    [ICE_Name]           NVARCHAR(256) NULL,
    [ICE_PhoneNumber]    NVARCHAR(32) NULL,
    [PhoneNumberId]     INT FOREIGN KEY REFERENCES [PhoneNumbers]([Id]),
    [AddressId]         INT FOREIGN KEY REFERENCES [Addresses]([Id]),
    [Active]            BIT DEFAULT 1 NOT NULL,
    [sa_Info]           NVARCHAR(512) NULL
);
GO

CREATE TABLE [Boats]
(
    [Id]         INT IDENTITY PRIMARY KEY,
    [SailNo]     INT UNIQUE NOT NULL,
    [Name]       NVARCHAR(256) NOT NULL,
    [Type]       NVARCHAR(64) NOT NULL,
    [Handicap]   NVARCHAR(256) NULL,
    [Active]     BIT DEFAULT 1 NOT NULL,
    [sa_Info]    NVARCHAR(512) NULL
);

GO

CREATE TABLE [Entries]
(
    [Id]                    INT IDENTITY PRIMARY KEY,
    [EntryNo]               INT UNIQUE NOT NULL,
    [EntryName]             NVARCHAR(256) NOT NULL,
    [RegistrationDate]      DATETIME DEFAULT GETDATE(),
    [PaidAmount]            INT DEFAULT 0 NOT NULL, 
    [BoatId]                INT FOREIGN KEY REFERENCES [Boats]([Id]),
    [ResponsibleUserId]     INT FOREIGN KEY REFERENCES [Users]([Id]),
    [ClubRepresentationId]  INT FOREIGN KEY REFERENCES [Clubs]([Id]) NULL,
    [Active]                BIT DEFAULT 1 NOT NULL,
    [sa_Info]               NVARCHAR(512) NULL
);
GO

CREATE TABLE [RegisteredUsers]
(
    [Id]         INT IDENTITY PRIMARY KEY,
    [UserId]     INT FOREIGN KEY REFERENCES [Users]([Id]),
    [EntryId]    INT FOREIGN KEY REFERENCES [Entries]([Id]),
    [Active]     BIT DEFAULT 1 NOT NULL,
    [sa_Info]    NVARCHAR(512) NULL
);
GO

CREATE TABLE [Teams]
(
    [Id]         INT IDENTITY PRIMARY KEY,
    [TeamName]   NVARCHAR(512) UNIQUE NOT NULL,
    [SkipperId]  INT FOREIGN KEY REFERENCES [RegisteredUsers]([Id]),
    [EntryId]    INT FOREIGN KEY REFERENCES [Entries]([Id]),
    [TeamNo]     INT UNIQUE NOT NULL,
    [Active]     BIT DEFAULT 1 NOT NULL,
    [sa_Info]    NVARCHAR(512) NULL
);
GO

CREATE TABLE [Regattas]
(
    [Id]            INT IDENTITY PRIMARY KEY,
    [Name]          NVARCHAR (512) NOT NULL,
    [StartDate]     DATETIME NOT NULL,
    [EndDate]       DATETIME NOT NULL,
    [Fee]           INT DEFAULT 0 NOT NULL,
    [Description]   NVARCHAR (MAX) NULL,
    [ClubId]        INT FOREIGN KEY REFERENCES [Clubs]([Id]),
    [AddressId]     INT FOREIGN KEY REFERENCES [Addresses]([Id]),
    CONSTRAINT [con_Reg] UNIQUE ([Name], [StartDate]),
    [Active]        BIT DEFAULT 1 NOT NULL,
    [sa_Info]       NVARCHAR(512) NULL
);
GO

CREATE TABLE [Events]
(
    [Id]                INT IDENTITY PRIMARY KEY,
    [Name]              NVARCHAR (512) NOT NULL,
    [Location]          NVARCHAR (512) NOT NULL,
    [Fee]               INT DEFAULT 0 NOT NULL,
    [Description]       NVARCHAR (MAX) NULL,
    [StartDate]         DATETIME NOT NULL,
    [EndDate]           DATETIME NOT NULL,
    [MaxParticipants]   INT DEFAULT 0 NOT NULL,
    [RegattaId]         INT FOREIGN KEY REFERENCES [Regattas]([Id]),
    CONSTRAINT [con_Eve] UNIQUE ([Name], [StartDate]),
    [Active]            BIT DEFAULT 1 NOT NULL,
    [sa_Info]           NVARCHAR(512) NULL
);
GO

CREATE TABLE [RaceEvents]
(
    [Id]         INT IDENTITY PRIMARY KEY,
    [Class]      NVARCHAR(512) NOT NULL,
    [Type]       NVARCHAR(64) NOT NULL,
    [EventId]    INT FOREIGN KEY REFERENCES [Events]([Id]),
    [Active]     BIT DEFAULT 1 NOT NULL,
    [sa_Info]    NVARCHAR(512) NULL
);
GO

CREATE TABLE [Results]
(
    [Id]         INT IDENTITY PRIMARY KEY,
    [ResultNo]   INT UNIQUE NOT NULL,
    [Type]       NVARCHAR(64) NOT NULL,
    [Time]       INT NULL,
    [Distance]   INT NULL,
    [Penalty]    NVARCHAR(256) NULL,
    [RaceEventId]     INT FOREIGN KEY REFERENCES [RaceEvents]([Id]) NOT NULL,
    CONSTRAINT [con_Res] UNIQUE ([ResultNo], [RaceEventId]),
    [Active]     BIT DEFAULT 1 NOT NULL,
    [sa_Info]    NVARCHAR(512) NULL
);
GO

CREATE TABLE [Regattas_Entries]
(
    [EntryId]           INT FOREIGN KEY REFERENCES [Entries]([Id]),
    [RegattaId]         INT FOREIGN KEY REFERENCES [Regattas]([Id]),
    [RegattaEntryDate]  DATETIME DEFAULT GETDATE(),
    CONSTRAINT [pk_RegattaId_EntryId] PRIMARY KEY ([EntryId], [RegattaId]),
    [Active]            BIT DEFAULT 1 NOT NULL,
    [sa_Info]           NVARCHAR(512) NULL
);
GO

CREATE TABLE [Emails]
(
    [Id]        INT IDENTITY PRIMARY KEY,
    [Value]     NVARCHAR(128) UNIQUE NOT NULL,
    [Type]      NVARCHAR(32) NOT NULL,
    [ClubId]    INT FOREIGN KEY REFERENCES [Clubs]([Id]),
    [Active]    BIT DEFAULT 1 NOT NULL,
    [sa_Info]   NVARCHAR(512) NULL
);
GO

CREATE TABLE [SocialEvents]
(
    [Id]          INT IDENTITY PRIMARY KEY,
    [EventId]     INT FOREIGN KEY REFERENCES [Events]([Id]),
    [Active]      BIT DEFAULT 1 NOT NULL,
    [sa_Info]     NVARCHAR(512) NULL
);
GO

CREATE TABLE [Teams_RegisteredUsers]
(
    [TeamId]             INT FOREIGN KEY REFERENCES [Teams]([Id]),
    [RegisteredUserId]   INT FOREIGN KEY REFERENCES [RegisteredUsers]([Id]),
    CONSTRAINT [pk_TeamId_RegistratedUserId] PRIMARY KEY ([TeamId], [RegisteredUserId]),
    [Active]             BIT DEFAULT 1 NOT NULL,
    [sa_Info]            NVARCHAR(512) NULL
);
GO

CREATE TABLE [Boats_Teams_Results]
(
    [ResultId]   INT FOREIGN KEY REFERENCES [Results]([Id]), 
    [BoatId]     INT FOREIGN KEY REFERENCES [Boats]([Id]),
    [TeamId]     INT FOREIGN KEY REFERENCES [Teams]([Id]),    
    CONSTRAINT [pk_ResultId] PRIMARY KEY ([ResultId], [BoatId]),
    [Active]     BIT DEFAULT 1 NOT NULL,
    [sa_Info]    NVARCHAR(512) NULL
);
GO

CREATE TABLE [Teams_RaceEvents]
(
    [TeamId]     INT FOREIGN KEY REFERENCES [Teams]([Id]),
    [RaceEventId]     INT FOREIGN KEY REFERENCES [RaceEvents]([Id]),
    CONSTRAINT [pk_TeamId_RaceId] PRIMARY KEY ([TeamId], [RaceEventId]),
    [Active]     BIT DEFAULT 1 NOT NULL,
    [sa_Info]    NVARCHAR(512) NULL
);
GO

CREATE TABLE [RegisteredUsers_SocialEvents]
(
    [RegisteredUserId]  INT FOREIGN KEY REFERENCES [RegisteredUsers]([Id]),
    [SocialEventId]     INT FOREIGN KEY REFERENCES [SocialEvents]([Id]),
    [NoOfFriends]       INT DEFAULT 0 NOT NULL,
    [PaidAmount]        INT DEFAULT 0 NOT NULL,
    CONSTRAINT [pk_RegistratedUserId_SocialEventId] PRIMARY KEY ([RegisteredUserId], [SocialEventId]),
    [Active]            BIT DEFAULT 1 NOT NULL,
    [sa_Info]           NVARCHAR(512) NULL
);
GO

CREATE TABLE [Clubs_Users_UserRoles_Junctions]
(
    [ClubId]             INT FOREIGN KEY REFERENCES [Clubs]([Id]),
    [UserId]             INT FOREIGN KEY REFERENCES [Users]([Id]),
    [UserRoleId]         INT FOREIGN KEY REFERENCES [UserRoles]([Id]),
    [PhoneNumberId]      INT FOREIGN KEY REFERENCES [PhoneNumbers]([Id]),
    [EmailId]            INT FOREIGN KEY REFERENCES [Emails]([Id]),
    CONSTRAINT [pk_ClubId_UserId_UserRoleId_Junctions] PRIMARY KEY     ([ClubId], [UserId], [UserRoleId]),
    [Active]             BIT DEFAULT 1 NOT NULL,
    [sa_Info]            NVARCHAR(512) NULL
);
GO

CREATE TABLE [Events_Users_UserRoles_Junctions]
(
    [EventId]            INT FOREIGN KEY REFERENCES [Events]([Id]),
    [UserId]             INT FOREIGN KEY REFERENCES [Users]([Id]),
    [UserRoleId]         INT FOREIGN KEY REFERENCES [UserRoles]([Id]),
    [PhoneNumberId]      INT FOREIGN KEY REFERENCES [PhoneNumbers]([Id]),
    [EmailId]            INT FOREIGN KEY REFERENCES [Emails]([Id]),
    CONSTRAINT [pk_EventId_UserId_UserRoleId_Junctions] PRIMARY KEY ([EventId], [UserId], [UserRoleId]),
    [Active]             BIT DEFAULT 1 NOT NULL,
    [sa_Info]            NVARCHAR(512) NULL
);
GO

CREATE TABLE [Regattas_Users_UserRoles_Junctions]
(
    [RegattaId]         INT FOREIGN KEY REFERENCES [Regattas]([Id]),
    [UserId]            INT FOREIGN KEY REFERENCES [Users]([Id]),
    [UserRoleId]        INT FOREIGN KEY REFERENCES [UserRoles]([Id]),
    [PhoneNumberId]     INT FOREIGN KEY REFERENCES [PhoneNumbers]([Id]),
    [EmailId]           INT FOREIGN KEY REFERENCES [Emails]([Id]),
    CONSTRAINT [pk_RegattaId_UserId_UserRoleId_Junctions] PRIMARY     KEY ([RegattaId], [UserId], [UserRoleId]),
    [Active]            BIT DEFAULT 1 NOT NULL,
    [sa_Info]           NVARCHAR(512) NULL
);
GO