create database UpstackFaq;

CREATE TABLE Questions (
    ID INT NOT NULL PRIMARY KEY IDENTITY,
    Question VARCHAR(500) NOT NULL,
    Answer TEXT NULL
)