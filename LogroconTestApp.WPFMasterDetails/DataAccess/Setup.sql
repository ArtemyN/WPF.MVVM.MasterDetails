CREATE TABLE [dbo].[Cities] (
    [Number]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (50) NOT NULL,
    [Region]         NVARCHAR (50) NOT NULL,
    [IsRegionCenter] BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Number] ASC)
);

CREATE TABLE [dbo].[Streets] (
    [Number]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    [CityNumber] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Number] ASC),
    FOREIGN KEY ([CityNumber]) REFERENCES [dbo].[Cities] ([Number]) ON DELETE CASCADE
);

--если в базе уже что-то было и было затем удалено то индексы городов будут начинаться не с 0
insert into Cities (Name, Region, IsRegionCenter)
values
('Kaluga', 'Kaluga region', 1),
('Moscow', 'Moscow region', 1),
('Suhinichi', 'Kaluga region', 0),
('NY', 'USA', 1),
('Gorod', 'Oblastb', 0);


insert into Streets (Name, CityNumber)
values
('Lenina', 1),
('Kirova', 1),
('Kashtanovaya street', 1),
('General Popov', 1),
('Lenina', 2),
('Kirova', 2),
('Kashtanovaya street', 2),
('General Popov', 2),
('Lenina', 3),
('Kirova', 3),
('Kashtanovaya street', 3),
('General Popov', 3),
('Lenina', 4),
('Kirova', 4),
('Kashtanovaya street', 4),
('General Popov', 4),
('Lenina', 0),
('Kirova', 0),
('Kashtanovaya street', 0),
('General Popov', 0);
