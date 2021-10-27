create table if not exists sales (
id int auto_increment,
name varchar (150) not null,
quantity int not null,
price double null,
date_of_sale datetime not null,
primary key(id)
);
