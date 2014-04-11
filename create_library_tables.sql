CREATE TABLE borrower (
	card_no varchar(10),
	fname   varchar(25),
	lname   varchar(25),
	address varchar(35),
	phone   varchar(15),
	PRIMARY KEY (card_no)
);

CREATE TABLE library_branch (
	branch_id   int(5),
	branch_name varchar(25),
	address     varchar(35),
	PRIMARY KEY (branch_id)
);


CREATE TABLE book (
	book_id varchar(15),
	title   varchar(100),
	PRIMARY KEY (book_id)
);

CREATE TABLE book_authors (
	book_id     varchar(15),
	author_name varchar(30),
	PRIMARY KEY (book_id, author_name),
	FOREIGN KEY (book_id) REFERENCES book(book_id)
);

CREATE TABLE book_copies (
	book_id     varchar(15),
	branch_id   int(5),
	no_of_copies int(5),
	PRIMARY KEY (book_id, branch_id),
	FOREIGN KEY (book_id) REFERENCES book(book_id),
	FOREIGN KEY (branch_id) REFERENCES library_branch(branch_id)
);

CREATE TABLE book_loans (
	book_id     varchar(15),
	branch_id   int(5),
	card_no     varchar(10),
	date_out    date,
	due_date    date,
	PRIMARY KEY (book_id, branch_id, card_no),
	FOREIGN KEY (book_id) REFERENCES book(book_id),
	FOREIGN KEY (branch_id) REFERENCES library_branch(branch_id),
	FOREIGN KEY (card_no) REFERENCES borrower(card_no)
);

create table fine (
card_no varchar(10),
book_id varchar(15),
branch_id int(5),
Fine float(5,2),
primary key (card_no,book_id,branch_id));

create table history (
card_no varchar (10),
book_id varchar (15),
branch_id int(5),
cout_date date,
cin_date date,
primary key (card_no,book_id,branch_id));

