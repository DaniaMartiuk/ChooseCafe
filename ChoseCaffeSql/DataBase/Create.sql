create table locations(
	id int primary key identity(1,1),
	x int,
	y int 
);

create table kitchens(
	id int  primary key identity(1,1),
	full_name varchar,
	short_name varchar(2) 
);

create table owners(
	id int  primary key identity(1,1),
	login varchar(20),
	password varchar(20),
	name varchar(20),
	surname varchar(20) 
);

create table products(
	id int  primary key identity(1,1),
	name varchar(12),
	kkal int,
	price int 
);

create table visitors(
	id int  primary key identity(1,1),
	password varchar(20),
	name varchar(20),
	sur_name varchar(20),
	location_id int foreign key references locations(id) on delete set null,
	login varchar(20) unique
);

create table bankcards(
	id int primary key identity(1,1),
	number  varchar(16),
	cvv int,
	vadality date,
	balance int,
	visitor_id int foreign key references visitors(id) on delete set null 
);

create table restaurants(
	id int  primary key identity(1,1),
	name varchar(16),
	location_id int foreign key references locations(id) on delete set null,
	owner_id int foreign key references owners(id) on delete set null,
);

create table foods(
	id int  primary key identity(1,1),
	name varchar(1),
	prise int,
	kitchen_id int foreign key references kitchens(id) on delete set null,
	restaurant_id int foreign key references restaurants(id) on delete set null 
);
create table recipes(
	id int  primary key identity(1,1),
	product_id int foreign key references products(id) on delete set null,
	weight float,
	si varchar(2), 
	food_id int foreign key references foods(id) on delete set null
);

create table orders(
	id int  primary key identity(1,1),
	total int,
	restaurant_id int foreign key references restaurants(id) on delete set null,
	visitor_id int foreign key references visitors(id) on delete set null,
	bankcard_id int foreign key references bankcards(id) on delete set null 
);

create table list_foods(
	id int  primary key identity(1,1),
	food_id int foreign key references foods(id) on delete set null,
	count int,
	order_id int foreign key references orders(id) on delete set NULL
);

