CREATE TABLE Tbl_Category (
	Ca_ID INT IDENTITY (1,1) NOT NULL,
	Ca_Name NVARCHAR (50) NOT NULL,
	CONSTRAINT PK_Tbl_Category PRIMARY KEY CLUSTERED (Ca_ID ASC)
);

CREATE TABLE Tbl_Location (
	Lo_ID INT IDENTITY (1,1) NOT NULL,
	Lo_Name NVARCHAR (50) NOT NULL,
	CONSTRAINT PK_Tbl_Location PRIMARY KEY CLUSTERED (Lo_ID ASC)
);

CREATE TABLE Tbl_Object (
	Ob_ID INT IDENTITY (1,1) NOT NULL,
	FK_Ca_ID INT NOT NULL,
	Ob_Name NVARCHAR (50) NOT NULL,
	Ob_Purchase_Date DATE,
	Ob_Est_Value FLOAT,
	Ob_Description NVARCHAR (280)
	CONSTRAINT PK_Tbl_Object PRIMARY KEY CLUSTERED (Ob_ID ASC),
	FOREIGN KEY (FK_Ca_ID) REFERENCES Tbl_Category (Ca_ID)
);

CREATE TABLE Tbl_Object_Location (
    Ob_ID INT NOT NULL,
    Lo_ID  INT NOT NULL,
	Qty    INT NOT NULL,
    CONSTRAINT [PK_Object_Location] PRIMARY KEY CLUSTERED ([Ob_ID] ASC, [Lo_ID] ASC),
    FOREIGN KEY ([Ob_ID]) REFERENCES [Tbl_Object] ([Ob_Id]),
    FOREIGN KEY ([Lo_ID]) REFERENCES [Tbl_Location] ([Lo_ID])
);

INSERT INTO Tbl_Location (Lo_Name)
VALUES ('Vardagsrum'),('Sovrum'),('Badrum'),('Kök'),('Förråd');

INSERT INTO Tbl_Category (Ca_Name)
VALUES ('Stolar'),('Bord'),('Elektronik'),('Förvaring'),('Textilier'),('Kläder');

INSERT INTO Tbl_Object (FK_Ca_ID, Ob_Name, Ob_Purchase_Date, Ob_Est_Value, Ob_Description)
VALUES (1, 'Pinnstol', '2017-03-04', NULL, NULL),(2, 'Matbord', NULL, 1500, 'Där man äter mat'), (3, 'TV', '2018-10-30', 10000, 'En dumburk');