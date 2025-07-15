CREATE TABLE Users(
   UserId uniqueidentifier,
   EmailAdress VARCHAR(50) NOT NULL,
   FirstName VARCHAR(50) NOT NULL,
   LastName VARCHAR(50) NOT NULL,
   Entity VARCHAR(50) NOT NULL,
   StartDate DATE,
   EndDate DATE,
   ProfilePicture VARCHAR(50),
   Role VARCHAR(50) NOT NULL,
   Supervisor uniqueidentifier NOT NULL,
   PRIMARY KEY(UserId),
   FOREIGN KEY(Supervisor) REFERENCES Users(UserId)
);

CREATE TABLE BriefNote(
   BriefNoteId uniqueidentifier,
   TypeNote INT NOT NULL,
   UpdateDate DATETIME,
   CreateDate DATETIME NOT NULL,
   TextNote VARCHAR(MAX),
   UserId uniqueidentifier NOT NULL,
   PRIMARY KEY(BriefNoteId),
   FOREIGN KEY(UserId) REFERENCES Users(UserId)
);

CREATE TABLE Week(
   WeekId uniqueidentifier,
   WeekNumber INT NOT NULL,
   PeriodNumber INT NOT NULL,
   StartDateWeek DATE NOT NULL,
   EndDateWeek DATE NOT NULL,
   UserId uniqueidentifier NOT NULL,
   PRIMARY KEY(WeekId),
   FOREIGN KEY(UserId) REFERENCES Users(UserId)
);

CREATE TABLE TaskPlanning(
   TaskId uniqueidentifier,
   Titled VARCHAR(MAX) NOT NULL,
   PRIMARY KEY(TaskId)
);

CREATE TABLE SignedContract(
   SignedContractId uniqueidentifier,
   TypeContract INT NOT NULL,
   WeekId uniqueidentifier NOT NULL,
   PRIMARY KEY(SignedContractId),
   FOREIGN KEY(WeekId) REFERENCES Week(WeekId)
);

CREATE TABLE Classes(
   ClassId uniqueidentifier,
   ClassName VARCHAR(MAX) NOT NULL,
   PRIMARY KEY(ClassId)
);

CREATE TABLE HalfDayPlanning(
   HalfDayId uniqueidentifier,
   HalfDayTime bit,
   WeekId uniqueidentifier NOT NULL,
   TaskId uniqueidentifier NOT NULL,
   PRIMARY KEY(HalfDayId),
   UNIQUE(WeekId),
   FOREIGN KEY(WeekId) REFERENCES Week(WeekId),
   FOREIGN KEY(TaskId) REFERENCES TaskPlanning(TaskId)
);

CREATE TABLE Document(
   DocumentId uniqueidentifier,
   PDFFile VARCHAR(MAX) NOT NULL,
   Title VARCHAR(50) NOT NULL,
   CreateDate DATETIME NOT NULL,
   UpdateDate DATETIME,
   CreateBy uniqueidentifier,
   UpdateBy uniqueidentifier NOT NULL,
   ClassId uniqueidentifier NOT NULL,
   PRIMARY KEY(DocumentId),
   FOREIGN KEY(CreateBy) REFERENCES Users(UserId),
   FOREIGN KEY(UpdateBy) REFERENCES Users(UserId),
   FOREIGN KEY(ClassId) REFERENCES Classes(ClassId)
);
