CREATE TABLE "User" (
	UserID SERIAL PRIMARY KEY,
	Username VARCHAR (50) NOT NULL,
	Email VARCHAR(255) UNIQUE NOT NULL,
	UserPassword VARCHAR(255) NOT NULL,
	IsAdmin BOOL
);

CREATE TABLE Channel (
	ChannelID SERIAL PRIMARY KEY,
	ChannelName VARCHAR(255) NOT NULL,
	CreatorUserID INT REFERENCES "User"(UserID)
);

CREATE TABLE ChannelMessage (
	ChannelMessageID SERIAL PRIMARY KEY,
	ChannelID INT REFERENCES Channel(ChannelID),
	UserSender INT REFERENCES "User"(UserID),
	UserReceiver INT REFERENCES "User"(UserID),
	MessageContent VARCHAR(1000) NOT NULL,
	MessageTime TIMESTAMP
);

CREATE TABLE PrivateMessage (
	PrivateMessageID SERIAL PRIMARY KEY,
	UserSenderID INT REFERENCES "User"(UserID),
	UserReceiverID INT REFERENCES "User"(UserID),
	MessageContent VARCHAR(1000) NOT NULL,
	MessageTime TIMESTAMP
);