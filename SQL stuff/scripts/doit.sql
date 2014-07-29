# Erzeuge Datenbank für Schedule3
drop database if exists schedule;

# Erzeuge Tabellen
CREATE DATABASE schedule CHARACTER SET utf8;

USE schedule;

CREATE TABLE appointment (
	id BIGINT NOT NULL PRIMARY KEY AUTO_INCREMENT,
	startDate DATETIME,
	endDate DATETIME,
	occured BOOLEAN,
	label TINYTEXT,
	treatmentId BIGINT,
	invoiceId BIGINT	
);
	
CREATE TABLE treatment (
	id BIGINT NOT NULL PRIMARY KEY AUTO_INCREMENT,
	patientId BIGINT,
	diagnosis TEXT,
	roomId BIGINT,
	healerId BIGINT 
);

CREATE TABLE invoiceItem (
	id BIGINT NOT NULL PRIMARY KEY AUTO_INCREMENT,
	description TINYTEXT,
	tariffMain INT,
	tariffSub INT,
	invoiceID BIGINT
);

CREATE TABLE invoiceGroup (
	id BIGINT NOT NULL PRIMARY KEY AUTO_INCREMENT,
	label TINYTEXT
);

CREATE TABLE groupitems (
	id BIGINT NOT NULL PRIMARY KEY AUTO_INCREMENT,
	invoiceItemId BIGINT,
	invoiceGroupId BIGINT
			
);

CREATE TABLE invoice (
	id BIGINT NOT NULL PRIMARY KEY AUTO_INCREMENT,
	invoiced DATETIME,
	paid DATETIME,
	dunningLetterId BIGINT 
);

CREATE TABLE dunningLetter (
	id BIGINT NOT NULL PRIMARY KEY AUTO_INCREMENT,
	dunningLevel INT,
	dunningDate DATETIME
);

CREATE TABLE room (
	id BIGINT NOT NULL PRIMARY KEY AUTO_INCREMENT,
	label TINYTEXT
);

CREATE TABLE healer (
	id BIGINT NOT NULL PRIMARY KEY AUTO_INCREMENT,
	name TINYTEXT,
	colorR INT,
	colorG INT,
	colorB INT
);

CREATE TABLE patient (
	id BIGINT NOT NULL PRIMARY KEY AUTO_INCREMENT,
	dateOfBirth DATETIME,
	dateOfDeath DATETIME,
	comments TEXT,
	male BOOLEAN,
	title TINYTEXT,
	firstName TINYTEXT,
	lastName TINYTEXT,
	occupation TINYTEXT,
	InsuranceId BIGINT,
	methodOfPayment INT, 
	publicComments TEXT,
	healerId BIGINT
);

CREATE TABLE address (
	id BIGINT NOT NULL PRIMARY KEY AUTO_INCREMENT,
	patientId BIGINT,
	street TINYTEXT,
	additionalInfo TINYTEXT,
	postcode TINYTEXT,
	place TINYTEXT,
	country TINYTEXT,
	useforinvoice BOOL
);

CREATE TABLE contacts (
	id BIGINT NOT NULL PRIMARY KEY AUTO_INCREMENT,
	patientId BIGINT,
	label TINYTEXT,
	contactInfo TINYTEXT
);

CREATE TABLE insurance (
	id BIGINT NOT NULL PRIMARY KEY AUTO_INCREMENT,
	label TINYTEXT
);

CREATE TABLE fee (
	id BIGINT NOT NULL PRIMARY KEY AUTO_INCREMENT, #notwendig?
	invoiceItemId BIGINT,
	insuranceId BIGINT,
	fee DOUBLE
);

CREATE TABLE treatedWith (
	id BIGINT NOT NULL PRIMARY KEY AUTO_INCREMENT, #notwendig?
	treatmentId BIGINT,
	invoiceGroupId BIGINT,
	invoiceItemId BIGINT
);


CREATE TABLE methodOfPayment(
	id BIGINT NOT NULL PRIMARY KEY AUTO_INCREMENT, 
	label TINYTEXT,
	alreadyPaid BOOLEAN
);
# Ende der Tabellen-Erstellung

# Erzeuge Views
CREATE VIEW dayview AS
SELECT 
	a.id, startDate, endDate, a.label, a.treatmentId, a.occured,
	colorR, colorG, colorB, firstname, lastname

FROM appointment AS a
	LEFT JOIN treatment AS t ON t.id = a.treatmentid 
	LEFT JOIN healer AS h ON t.healerid = h.id
	LEFT JOIN patient AS p ON t.patientid = p.id
;
# Ende der View-Erstellung
	
# Füllen mit Standard-Daten
INSERT INTO healer (name) VALUES ('Default');

INSERT INTO methodOfPayment (label, alreadyPaid) VALUES ("Bar", true);
INSERT INTO methodOfPayment (label, alreadyPaid) VALUES ("auf Rechnung", false);
INSERT INTO methodOfPayment (label, alreadyPaid) VALUES ("Lastschrift", true);
	
	