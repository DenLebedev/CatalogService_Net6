INSERT INTO `catalogservice`.`categories`
(`Name`,
`Image`,
`ParentCategoryId`)
VALUES
("Books",
"https://rare-gallery.com/524648-book-stack-books.html",
null),
("Grocery",
"https://www.thestreet.com/.image/t_share/MTgwNTk4MTYyMDQ4Njg5MjQw/exotic-foods-market-grocery-sh.jpg",
null),
("Fruit",
"https://pixnio.com/free-images/2017/07/15/2017-07-15-10-46-53.jpg",
2);

INSERT INTO `catalogservice`.`items`
(`Name`,
`Description`,
`Image`,
`CategoryId`,
`Price`,
`Amount`)
VALUES
("Banana",
"A banana is an elongated, edible fruit –Description__efmigrationshistoryMigrationIdProductVersion botanically a berry...",
"https://www.ecwausa.org/wp-content/uploads/2019/09/Banana.jpg",
3,
40,
120),
("Strawberrie",
"The garden strawberry (or simply strawberry; Fragaria × ananassa) is a widely grown hybrid species of the genus Fragaria...",
"https://fedoskinolife.ru/wp-content/uploads/f/0/5/f059b6a70d12325b17c622bddf02d61b.png",
3,
26.6,
300),
("The Book of Lost Tales 1: Book 1",
"J. R. R. Tolkien / The first of a two-book set that contains the early myths and legends which led to the writing of Tolkien’s epic tale of war, The Silmarillion.",
"https://m.media-amazon.com/images/I/51M3l7OXFsL._SX498_BO1,204,203,200_.jpg",
1,
125.38,
12);