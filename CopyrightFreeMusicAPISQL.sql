CREATE DATABASE CopyrightFreeMusic;

USE CopyrightFreeMusic;
CREATE TABLE Artists(
	ArtistsId INT NOT NULL auto_increment,
    Name VARCHAR(5000) NOT NULL,
    Commission BOOL,
    PRIMARY KEY (ArtistsId)
);

CREATE TABLE Genres(
	GenresId INT NOT NULL auto_increment,
    Name VARCHAR(1000) NOT NULL,
    Popularity INT NOT NULL,
    CHECK(Popularity BETWEEN 1 AND 10),
    PRIMARY KEY (GenresId)
);

CREATE TABLE Musics(
	MusicsId INT NOT NULL auto_increment,
    Name VARCHAR(5000) NOT NULL,
    Link VARCHAR(10000) NOT NULL,
    PRIMARY KEY (MusicsId)
);

ALTER TABLE Musics ADD COLUMN ArtistsId INT;
ALTER TABLE Musics ADD CONSTRAINT FK_MusicArtist FOREIGN KEY (ArtistsId) REFERENCES Artists(ArtistsId);

ALTER TABLE Musics ADD COLUMN GenresId INT;
ALTER TABLE Musics ADD CONSTRAINT FK_MusicGenre FOREIGN KEY (GenresId) REFERENCES Genres(GenresId);

INSERT INTO Genres (Name, Popularity) VALUES ("Classical", 5);
INSERT INTO Genres (Name, Popularity) VALUES ("Jazz", 7);
INSERT INTO Genres (Name, Popularity) VALUES ("Pop", 8);

INSERT INTO Artists (Name, Commission) VALUES ("Scott Holmes", TRUE);
INSERT INTO Musics (Name, Link, ArtistsId, GenresId) 
	VALUES ("Against All Odds", 
			"https://freemusicarchive.org/music/Scott_Holmes/crime-background-music-micro-scores-1/against-all-odds/",
            1, 1);
INSERT INTO Musics (Name, Link, ArtistsId, GenresId)
	VALUES ("Aspire",
			"https://freemusicarchive.org/music/Scott_Holmes/royalty-free-corporatemotivational-music/Aspire_1241/",
            1, 3);

INSERT INTO Artists (Name, Commission) VALUES ("Paweł Feszczuk", FALSE);
INSERT INTO Musics (Name, Link, ArtistsId, GenresId) 
	VALUES ("Mansion of His Majesty", 
			"https://freemusicarchive.org/music/pawel-feszczuk/single/mansion-of-his-majesty/",
            2, 1);
INSERT INTO Musics (Name, Link, ArtistsId, GenresId)
	VALUES ("Sixth Floor",
			"https://freemusicarchive.org/music/pawel-feszczuk/walking-next-to-the-playing-piano/sixth-floor/",
            2, 3);
            
INSERT INTO Artists (Name, Commission) VALUES ("Dee Yan-Key", TRUE);
INSERT INTO Musics (Name, Link, ArtistsId, GenresId) 
	VALUES ("rainday", 
			"https://freemusicarchive.org/music/Dee_Yan-Key/a-day-at-the-sea/rainday/",
            3, 1);
INSERT INTO Musics (Name, Link, ArtistsId, GenresId)
	VALUES ("Didn´t My Lord Deliver Daniel",
			"https://freemusicarchive.org/music/Dee_Yan-Key/go-down-moses/didnt-my-lord-deliver-daniel/",
            3, 2);

INSERT INTO Artists (Name, Commission) VALUES ("Julia Felix", FALSE);
INSERT INTO Musics (Name, Link, ArtistsId, GenresId)
	VALUES ("Foeniculum Vulgare",
			"https://freemusicarchive.org/music/julia-felix/single/foeniculum-vulgare/",
            4, 2);
INSERT INTO Musics (Name, Link, ArtistsId, GenresId)
	VALUES ("Could what, become before why?",
			"https://freemusicarchive.org/music/julia-felix/single/could-what-become-before-why/",
            4, 2);


            


