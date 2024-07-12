USE master; 
GO
IF EXISTS(SELECT name FROM sys.databases
     WHERE name = 'ProjectPRN')
     DROP DATABASE ProjectPRN 

GO  
CREATE DATABASE [ProjectPRN];
GO  
USE [ProjectPRN];
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account] (
    [id] INT IDENTITY(1,1) PRIMARY KEY,
    [user] VARCHAR(255) NOT NULL,
    [pass] VARCHAR(255) NOT NULL,
    [email] VARCHAR(255) NOT NULL,
    [phone] VARCHAR(255),
    [role] INT NOT NULL
);
GO

CREATE TABLE [dbo].[Question] (
    [id] INT IDENTITY(1,1) PRIMARY KEY,
    [create_by] INT NOT NULL,
    [question_prompt] NVARCHAR(MAX) NOT NULL,
    [content] NVARCHAR(MAX) NOT NULL,
    [Answers1] NVARCHAR(MAX) NOT NULL,
    [Answers2] NVARCHAR(MAX) NOT NULL,
    [Answers3] NVARCHAR(MAX) NOT NULL,
    [Answers4] NVARCHAR(MAX) NOT NULL,
    [ResultNum] INT NOT NULL,
    FOREIGN KEY ([create_by]) REFERENCES [dbo].[Account]([id])
);
GO

CREATE TABLE [dbo].[Exam] (
    [id] INT IDENTITY(1,1) PRIMARY KEY,
    [name] NVARCHAR(MAX) NOT NULL,
    [Date] DATE NOT NULL,
    [numQuestion] INT NOT NULL,
    [timeline] NVARCHAR(MAX) NOT NULL
);
GO

CREATE TABLE [dbo].[ExamQuestions] (
    [id] INT IDENTITY(1,1),
    [ExamId] INT NOT NULL,
    [QuestionId] INT NOT NULL,
    PRIMARY KEY ([id],[ExamId], [QuestionId]),
    FOREIGN KEY ([ExamId]) REFERENCES [dbo].[Exam]([id]),
    FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question]([id])
);
GO

CREATE TABLE [dbo].[Score] (
    [id] INT IDENTITY(1,1) PRIMARY KEY,
    [accountId] INT NOT NULL,
    [examId] INT NOT NULL,
    [date] DATE NOT NULL,
    [mark] FLOAT NOT NULL,
    FOREIGN KEY ([accountId]) REFERENCES [dbo].[Account]([id]),
    FOREIGN KEY ([examId]) REFERENCES [dbo].[Exam]([id])
);
GO

CREATE TABLE [dbo].[UserAnswers] (
    [id] INT IDENTITY(1,1) PRIMARY KEY,
    [accountId] INT NOT NULL,
    [examId] INT NOT NULL,
    [questionId] INT NOT NULL,
    [selectedAnswer] NVARCHAR(MAX) NOT NULL,
    FOREIGN KEY ([accountId]) REFERENCES [dbo].[Account]([id]),
    FOREIGN KEY ([examId]) REFERENCES [dbo].[Exam]([id]),
    FOREIGN KEY ([questionId]) REFERENCES [dbo].[Question]([id])
);
GO
SET IDENTITY_INSERT [dbo].[Account] ON 
INSERT [dbo].[Account] ([id], [user], [pass],[email] ,[phone], [role]) VALUES
(1, N'admin', N'123456', N'admin1@gmail.com', N'0123456789', 1),
(2, N'user1', N'123456', N'user1@gmail.com', N'0987654321', 0),
(3, N'user2', N'123456', N'user2@gmail.com', N'0123654789', 0)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
INSERT INTO [dbo].[Question]([create_by],[question_prompt],[content],[Answers1],[Answers2],[Answers3],[Answers4],[ResultNum])VALUES
(1, N'Chọn từ đồng nghĩa', N'I didn’t think his the comments were very "appropriate" at the time.', N'correct', N'right', N'exact', N'suitable', 4),
(1, N'Chọn từ đồng nghĩa', N'The weather forecast said it would be "sunny" all week.', N'rainy', N'cloudy', N'sunny', N'windy', 3),
(1, N'Chọn từ đồng nghĩa', N'She has a very "pleasant" personality.', N'nice', N'unpleasant', N'angry', N'rude', 1),
(1, N'Chọn từ đồng nghĩa', N'This movie is based on a "true" story.', N'false', N'unreal', N'true', N'fictitious', 3),
(1, N'Chọn từ đồng nghĩa', N'They "arrived" at the airport early in the morning.', N'left', N'arrived', N'departed', N'waited', 2),
(1, N'Chọn từ đồng nghĩa', N'The students "studied" hard for the exam.', N'played', N'rested', N'studied', N'slept', 3),
(1, N'Chọn từ đồng nghĩa', N'The new restaurant downtown is "popular" among locals.', N'empty', N'popular', N'unknown', N'disliked', 2),
(1, N'Chọn từ đồng nghĩa', N'His speech was very "inspiring".', N'boring', N'confusing', N'inspiring', N'disappointing', 3),
(1, N'Chọn từ đồng nghĩa', N'She "enjoys" reading books in her free time.', N'dislikes', N'hates', N'enjoys', N'ignores', 3),
(1, N'Chọn từ đồng nghĩa', N'The company "offers" a wide range of products.', N'takes', N'offers', N'receives', N'buy', 2),
(1, N'Chọn từ trái nghĩa', N'The weather forecast said it would be "sunny" all week.', N'rainy', N'cloudy', N'sunny', N'windy', 1),
(1, N'Chọn từ trái nghĩa', N'She has a very "pleasant" personality.', N'nice', N'unpleasant', N'angry', N'rude', 2),
(1, N'Chọn từ trái nghĩa', N'This movie is based on a "true" story.', N'false', N'unreal', N'true', N'fictitious', 4),
(1, N'Chọn từ trái nghĩa', N'They "arrived" at the airport early in the morning.', N'left', N'arrived', N'departed', N'waited', 1),
(1, N'Chọn từ trái nghĩa', N'The students "studied" hard for the exam.', N'played', N'rested', N'studied', N'slept', 2),
(1, N'Chọn từ trái nghĩa', N'The new restaurant downtown is "popular" among locals.', N'empty', N'popular', N'unknown', N'disliked', 1),
(1, N'Chọn từ trái nghĩa', N'His speech was very "inspiring".', N'boring', N'confusing', N'inspiring', N'disappointing', 1),
(1, N'Chọn từ trái nghĩa', N'She "enjoys" reading books in her free time.', N'dislikes', N'hates', N'enjoys', N'ignores', 4),
(1, N'Chọn từ trái nghĩa', N'The company "offers" a wide range of products.', N'takes', N'offers', N'receives', N'buy', 3),
(1, N'Chọn từ trái nghĩa', N'The cake tastes "delicious".', N'terrible', N'delicious', N'awful', N'bitter', 1),
(1, N'Tìm câu nghĩa tương đương', N'The weather forecast said it would be "sunny" all week.', N'The weather forecast predicted a week of clear skies.', N'The weather forecast predicted a week of rain.', N'The weather forecast predicted a week of windy weather.', N'The weather forecast predicted a week of cloudy weather.', 1),
(1, N'Tìm câu nghĩa tương đương', N'She has a very "pleasant" personality.', N'She has a very nice personality.', N'She has a very unpleasant personality.', N'She has a very rude personality.', N'She has a very angry personality.', 1),
(1, N'Tìm câu nghĩa tương đương', N'This movie is based on a "true" story.', N'This movie is based on a real story.', N'This movie is based on a fictional story.', N'This movie is based on an untrue story.', N'This movie is based on a fantasy story.', 1),
(1, N'Tìm câu nghĩa tương đương', N'They "arrived" at the airport early in the morning.', N'They arrived at the airport at dawn.', N'They left the airport early in the morning.', N'They departed from the airport early in the morning.', N'They waited at the airport early in the morning.', 1),
(1, N'Tìm câu nghĩa tương đương', N'The students "studied" hard for the exam.', N'The students worked diligently for the exam.', N'The students played hard before the exam.', N'The students rested before the exam.', N'The students slept before the exam.', 1),
(1, N'Tìm câu nghĩa tương đương', N'The new restaurant downtown is "popular" among locals.', N'The new restaurant downtown is well-liked by locals.', N'The new restaurant downtown is unknown among locals.', N'The new restaurant downtown is disliked by locals.', N'The new restaurant downtown is empty among locals.', 1),
(1, N'Tìm câu nghĩa tương đương', N'His speech was very "inspiring".', N'His speech was very motivating.', N'His speech was very boring.', N'His speech was very disappointing.', N'His speech was very confusing.', 1),
(1, N'Tìm câu nghĩa tương đương', N'She "enjoys" reading books in her free time.', N'She loves reading books in her free time.', N'She hates reading books in her free time.', N'She dislikes reading books in her free time.', N'She ignores reading books in her free time.', 1),
(1, N'Tìm câu nghĩa tương đương', N'The company "offers" a wide range of products.', N'The company provides a wide range of products.', N'The company buys a wide range of products.', N'The company sells a wide range of products.', N'The company receives a wide range of products.', 1),
(1, N'Tìm lỗi sai trong câu', N'Developing new technologies are time-consuming and expensive.', N'developing', N'technologies', N'are', N'time-consuming', 3),
(1, N'Tìm lỗi sai trong câu', N'I have visited to London many times.', N'I', N'have', N'visited', N'to', 3),
(1, N'Tìm lỗi sai trong câu', N'The book was wrote by a famous author.', N'The', N'book', N'was', N'wrote', 4),
(1, N'Tìm lỗi sai trong câu', N'He don’t like pineapple on pizza.', N'He', N'don’t', N'like', N'pineapple', 2),
(1, N'Tìm lỗi sai trong câu', N'Mary and her sister plays tennis every weekend.', N'Mary', N'and', N'her', N'plays', 4),
(1, N'Tìm lỗi sai trong câu', N'The meeting has been canceled because the boss was sick.', N'The', N'meeting', N'has', N'been', 3),
(1, N'Tìm lỗi sai trong câu', N'She usually don’t drink coffee in the evening.', N'She', N'usually', N'don’t', N'drink', 3),
(1, N'Tìm lỗi sai trong câu', N'The dog wagged it’s tail happily.', N'The', N'dog', N'wagged', N'it’s', 4),
(1, N'Tìm lỗi sai trong câu', N'Mark is the taller than his brother.', N'Mark', N'is', N'the', N'taller', 3),
(1, N'Tìm lỗi sai trong câu', N'They hasn’t been to the theater in months.', N'They', N'hasn’t', N'been', N'theater', 1),
(1, N'Chọn từ thích hợp điền vào chỗ trống', N'When we went back to the bookstore, the bookseller _______ the book we wanted.', N'sold', N'had sold', N'sells', N'has sold', 2),
(1, N'Chọn từ thích hợp điền vào chỗ trống', N'By the end of last summer, the farmers _______ all the crop.', N'harvested', N'had harvested', N'harvest', N'are harvested', 2),
(1, N'Chọn từ thích hợp điền vào chỗ trống', N'The director _______ for the meeting by the time I got to his office.', N'left', N'leaves', N'had left', N'will leave', 3),
(1, N'Chọn từ thích hợp điền vào chỗ trống', N'Susan _______ her family after she had taken the university entrance examination.', N'phoned', N'had phoned', N'phones', N'is phoning', 1),
(1, N'Chọn từ thích hợp điền vào chỗ trống', N'Miss Jane _______ typing the report when her boss came in.', N'didn’t finish', N'doesn’t finish', N'can’t finish', N'hadn’t finished', 4),
(1, N'Chọn từ thích hợp điền vào chỗ trống', N'Peter was in New York last week; he _______ in Washington D.C. three days earlier.', N'was', N'is', N'had been', N'was being', 3),
(1, N'Chọn từ thích hợp điền vào chỗ trống', N'Three women, none of whom we _______ before, _______ out of the hall.', N'saw-had come', N'had seen-had come', N'saw-came', N'had seen-came', 4),
(1, N'Chọn từ thích hợp điền vào chỗ trống', N'They _______ through horrible times during the war years.', N'lived', N'had lived', N'live', N'are living', 1)


