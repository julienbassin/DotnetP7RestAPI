CREATE TABLE BidList (
  BidListId int NOT NULL,
  account VARCHAR(30) NOT NULL,
  type VARCHAR(30) NOT NULL,
  bidQuantity decimal,
  askQuantity decimal,
  bid decimal ,
  ask decimal,
  benchmark VARCHAR(125),
  bidListDate DATETIME,
  commentary VARCHAR(125),
  security VARCHAR(125),
  status VARCHAR(10),
  trader VARCHAR(125),
  book VARCHAR(125),
  creationName VARCHAR(125),
  creationDate DATETIME ,
  revisionName VARCHAR(125),
  revisionDate DATETIME ,
  dealName VARCHAR(125),
  dealType VARCHAR(125),
  sourceListId VARCHAR(125),
  side VARCHAR(125),

  PRIMARY KEY (BidListId)
)

CREATE TABLE Trade (
  TradeId int NOT NULL,
  account VARCHAR(30) NOT NULL,
  type VARCHAR(30) NOT NULL,
  buyQuantity decimal,
  sellQuantity decimal,
  buyPrice decimal ,
  sellPrice decimal,
  tradeDate DATETIME,
  security VARCHAR(125),
  status VARCHAR(10),
  trader VARCHAR(125),
  benchmark VARCHAR(125),
  book VARCHAR(125),
  creationName VARCHAR(125),
  creationDate DATETIME ,
  revisionName VARCHAR(125),
  revisionDate DATETIME ,
  dealName VARCHAR(125),
  dealType VARCHAR(125),
  sourceListId VARCHAR(125),
  side VARCHAR(125),

  PRIMARY KEY (TradeId)
)

CREATE TABLE CurvePoint (
  Id int NOT NULL,
  CurveId tinyint,
  asOfDate DATETIME,
  term decimal ,
  value decimal ,
  creationDate DATETIME ,

  PRIMARY KEY (Id)
)

CREATE TABLE Rating (
  Id int NOT NULL,
  moodysRating VARCHAR(125),
  sandPRating VARCHAR(125),
  fitchRating VARCHAR(125),
  orderNumber int,

  PRIMARY KEY (Id)
)

CREATE TABLE RuleName (
  Id int NOT NULL,
  name VARCHAR(125),
  description VARCHAR(125),
  json VARCHAR(125),
  template VARCHAR(512),
  sqlStr VARCHAR(125),
  sqlPart VARCHAR(125),

  PRIMARY KEY (Id)
)

CREATE TABLE Users (
  Id int NOT NULL,
  username VARCHAR(125),
  password VARCHAR(125),
  fullname VARCHAR(125),
  role VARCHAR(125),
  PRIMARY KEY (Id)
)
GO


INSERT into BidList(BidListId, account, type) VALUES(1, 'julien', 'test')

SET IDENTITY_INSERT dbo.Users ON


INSERT into Users(Id,fullname, username, password, role) VALUES(1,'Administrator', 'admin', '$2a$10$pBV8ILO/s/nao4wVnGLrh.sa/rnr5pDpbeC4E.KNzQWoy8obFZdaa', 'ADMIN')
INSERT into Users(Id,fullname, username, password, role) VALUES(2, 'User', 'user', '$2a$10$pBV8ILO/s/nao4wVnGLrh.sa/rnr5pDpbeC4E.KNzQWoy8obFZdaa', 'USER')