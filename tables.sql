use db_rvezy;

CREATE TABLE IF NOT EXISTS listings (
    id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    listing_url varchar(300) not null,
    name varchar(60) not null,
    description varchar(180) not null, 
    property_type varchar(20) not null
);

CREATE TABLE IF NOT EXISTS calendar (
    id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    listing_id int NOT NULL,
    date_calendar date NOT NULL,
    available int NOT NULL,
    price varchar(10) NOT NULL,
    FOREIGN KEY (listing_id) REFERENCES listings(id)
);

CREATE TABLE IF NOT EXISTS reviews (
    id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    date_review date not null,
    reviewer_id int not null,
    reviewer_name varchar(30) not null,
    comments varchar(300) not null,
    listing_id int not null,
    FOREIGN KEY (listing_id) REFERENCES listings(id)
);