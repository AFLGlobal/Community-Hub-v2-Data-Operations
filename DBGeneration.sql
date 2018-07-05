USE CommunityV2

-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

DROP TABLE [WorkOpportunityForEmployee];
GO


DROP TABLE [WorkOpportunity];
GO


DROP TABLE [Employee];
GO


DROP TABLE [Project];
GO


DROP TABLE [ServiceType];
GO


DROP TABLE [Waiver];
GO


DROP TABLE [Location];
GO


--************************************** [ServiceType]

CREATE TABLE [ServiceType]
(
 [ServiceTypeID] BIGINT IDENTITY (1, 1) NOT NULL ,
 [ServiceType]   NVARCHAR(MAX) NOT NULL ,

 CONSTRAINT [PK_ServiceType] PRIMARY KEY CLUSTERED ([ServiceTypeID] ASC)
);
GO



--************************************** [Waiver]

CREATE TABLE [Waiver]
(
 [WaiverID]   BIGINT IDENTITY (1, 1) NOT NULL ,
 [WaiverText] NVARCHAR(MAX) NOT NULL ,
 [WaiverURL]  NVARCHAR(MAX) NOT NULL ,

 CONSTRAINT [PK_Waiver] PRIMARY KEY CLUSTERED ([WaiverID] ASC)
);
GO



--************************************** [Location]

CREATE TABLE [Location]
(
 [LocationID]      BIGINT IDENTITY (1, 1) NOT NULL ,
 [LocationName]    NVARCHAR(50) NOT NULL ,
 [LocationCountry] NVARCHAR(50) NOT NULL ,

 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED ([LocationID] ASC)
);
GO



--************************************** [Employee]

CREATE TABLE [Employee]
(
 [EmployeeID]               BIGINT IDENTITY (1, 1) NOT NULL ,
 [EmployeeFirstName]        NVARCHAR(50) NOT NULL ,
 [EmployeeLastName]         NVARCHAR(50) NOT NULL ,
 [LocationID]               BIGINT NOT NULL ,
 [EmployeeEmail]            NVARCHAR(MAX) NULL ,
 [EmployeePhone]            NVARCHAR(50) NULL ,
 [EmployeeCellPhone]        NVARCHAR(50) NULL ,
 [TItle]                    NVARCHAR(100) NULL ,
 [EmployeeMiddleName]       NVARCHAR(50) NULL ,
 [EmployeeAlternateEmail]   NVARCHAR(50) NULL ,
 [EmployeeStreet]           NVARCHAR(MAX) NULL ,
 [EmployeeCity]             NVARCHAR(50) NULL ,
 [EmployeeState]            NVARCHAR(10) NULL ,
 [EmployeeZip]              NVARCHAR(10) NULL ,
 [EmployeePayGroup]         INT NULL ,
 [M_ID]                     INT NULL ,
 [Deleted]                  BIT NOT NULL ,
 [IsAdmin]                  BIT NOT NULL ,
 [IsLocked]                 BIT NOT NULL ,
 [LastAccessDateTime]       DATETIME NOT NULL ,
 [CanCreate]                BIT NOT NULL ,
 [AdminCommunityService]    BIT NOT NULL ,
 [AdminAssociateManagement] BIT NOT NULL ,
 [AdminUnitedWay]           BIT NOT NULL ,
 [AdminReporting]           BIT NOT NULL ,
 [UseActiveDirectory]       BIT NOT NULL ,
 [EmployeePassword]         TEXT NULL ,

 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([EmployeeID] ASC),
 CONSTRAINT [FK_79] FOREIGN KEY ([LocationID])
  REFERENCES [Location]([LocationID])
);
GO


--SKIP Index: [fkIdx_79]


--************************************** [Project]

CREATE TABLE [Project]
(
 [ProjectID]          BIGINT IDENTITY (1, 1) NOT NULL ,
 [LocationID]         BIGINT NOT NULL ,
 [ProjectName]        NVARCHAR(MAX) NOT NULL ,
 [ProjectDescription] TEXT NULL ,
 [TShirtRequired]     BIT NOT NULL ,
 [Completed]          BIT NOT NULL ,
 [Deleted]            BIT NOT NULL ,
 [DateEmailSent]      DATETIME NULL ,
 [WaiverID]           BIGINT NOT NULL ,
 [ServiceTypeID]      BIGINT NOT NULL ,

 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED ([ProjectID] ASC),
 CONSTRAINT [FK_43] FOREIGN KEY ([LocationID])
  REFERENCES [Location]([LocationID]),
 CONSTRAINT [FK_53] FOREIGN KEY ([WaiverID])
  REFERENCES [Waiver]([WaiverID]),
 CONSTRAINT [FK_62] FOREIGN KEY ([ServiceTypeID])
  REFERENCES [ServiceType]([ServiceTypeID])
);
GO


--SKIP Index: [fkIdx_43]

--SKIP Index: [fkIdx_53]

--SKIP Index: [fkIdx_62]


--************************************** [WorkOpportunity]

CREATE TABLE [WorkOpportunity]
(
 [WorkOpportunityID]            BIGINT IDENTITY (1, 1) NOT NULL ,
 [ProjectID]                    BIGINT NOT NULL ,
 [WorkOpportunityStartDateTime] DATETIME NOT NULL ,
 [WorkOpportunityStopDateTime]  DATETIME NOT NULL ,
 [WorkOpportunityHours]         FLOAT NOT NULL ,
 [Description]                  TEXT NULL ,
 [LunchAvailable]               BIT NOT NULL ,
 [MaxVolunteers]                INT NULL ,
 [AllowGuests ]                 BIT NOT NULL ,

 CONSTRAINT [PK_WorkOpportunity] PRIMARY KEY CLUSTERED ([WorkOpportunityID] ASC),
 CONSTRAINT [FK_100] FOREIGN KEY ([ProjectID])
  REFERENCES [Project]([ProjectID])
);
GO


--SKIP Index: [fkIdx_100]


--************************************** [WorkOpportunityForEmployee]

CREATE TABLE [WorkOpportunityForEmployee]
(
 [WorkOpportunityForEmployeeID] BIGINT IDENTITY (1, 1) NOT NULL ,
 [EmployeeID]                   BIGINT NOT NULL ,
 [WorkOpportunityID]            BIGINT NOT NULL ,
 [EmployeeDateSignedUp]         DATETIME NOT NULL ,
 [ActualHours]                  FLOAT NOT NULL ,
 [Comments]                     NVARCHAR(MAX) NULL ,
 [WantsLunch]                   BIT NOT NULL ,
 [TShirtSize]                   NVARCHAR(50) NULL ,
 [Guests]                       INT NOT NULL ,

 CONSTRAINT [PK_WorkOpportunityForEmployee] PRIMARY KEY CLUSTERED ([WorkOpportunityForEmployeeID] ASC),
 CONSTRAINT [FK_115] FOREIGN KEY ([EmployeeID])
  REFERENCES [Employee]([EmployeeID]),
 CONSTRAINT [FK_119] FOREIGN KEY ([WorkOpportunityID])
  REFERENCES [WorkOpportunity]([WorkOpportunityID])
);
GO


--SKIP Index: [fkIdx_115]

--SKIP Index: [fkIdx_119]


