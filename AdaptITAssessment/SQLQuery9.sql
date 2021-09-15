Create Database AdaptItAcademy

CREATE TABLE Course (
ID int IDENTITY(1,1) PRIMARY KEY  not null,
CourseCode varchar(255) not null,
CourseName varchar(255)not null,
CourseDescription varchar(255)not null,
TrainingTotalAmount decimal
);

CREATE TABLE Delegate (
ID int IDENTITY(1,1) PRIMARY KEY  not null,
FirstName varchar(255) not null,
LastName varchar(255) not null,
PhoneNumber varchar(255) not null,
Email varchar(255) not null,
DietaryRequirements varchar(255) not null,
CompanyName varchar(255) not null,
PhysicalAddress varchar(255) not null,
PostalAddress varchar(255) not null
);

CREATE TABLE Training (
ID int IDENTITY(1,1) PRIMARY KEY  not null,
TrainingDate datetime not null,
TrainingVenue varchar(255) not null,
NumberOfSeats int not null,
TrainingCost decimal not null,
RegistrationClosingDate datetime not null,
PaymentRequired bit not null,
CourseID int FOREIGN KEY REFERENCES Course(ID) not null,
TotalTrainingCostPaid decimal not null
);

CREATE TABLE TrainingRegistration (
ID int IDENTITY(1,1) PRIMARY KEY,
TrainingID int FOREIGN KEY REFERENCES Training(ID)  not null,
DelegateID int FOREIGN KEY REFERENCES Delegate(ID) not null
);



