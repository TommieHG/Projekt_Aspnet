CREATE TABLE [dbo].[Tbl_Object] (
    [Ob_ID]            INT            IDENTITY (1, 1) NOT NULL,
    [FK_Ca_ID]         INT            NOT NULL,
	[FK_Lo_ID]         INT            NOT NULL,
    [Ob_Name]          NVARCHAR (50)  NOT NULL,
    [Ob_Purchase_Date] DATE           NULL,
    [Ob_Est_Value]     FLOAT (53)     NULL,
    [Ob_Description]   NVARCHAR (280) NULL,
    [Ob_Quantity]      INT            DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Tbl_Object] PRIMARY KEY CLUSTERED ([Ob_ID] ASC),
    FOREIGN KEY ([FK_Ca_ID]) REFERENCES [dbo].[Tbl_Category] ([Ca_ID]),
	FOREIGN KEY ([FK_Lo_ID]) REFERENCES [dbo].[Tbl_Location] ([Lo_ID])
);

