DROP TABLE IF EXISTS Data;
DROP TABLE IF EXISTS Mem_Cat;
DROP TABLE IF EXISTS Category;
DROP TABLE IF EXISTS Member;

CREATE TABLE Member (
	id SERIAL PRIMARY KEY,
	role TEXT,
	login TEXT UNIQUE,
	password TEXT
);

CREATE TABLE Category (
	id SERIAL PRIMARY KEY,
	name TEXT UNIQUE
);

CREATE TABLE Mem_Cat (
	id SERIAL PRIMARY KEY,
	member_id INT REFERENCES Member,
	category_id INT REFERENCES Category
);

CREATE TABLE Data (
	id SERIAL PRIMARY KEY,
	mem_cat_id INT REFERENCES Mem_Cat,
	day DATE,
	start_t TIME,
	end_t TIME
);