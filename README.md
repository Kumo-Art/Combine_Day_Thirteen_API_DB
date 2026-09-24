###SQLite & Entity Framework Core(ef core)

## What is a database

A database is where our application permanently stores information
This allows our information to stay saved even when our API stops

##SQLite

SQLite is a simple database that stores all of its data inside a file

unlike SQL Server SQLite does not require us to have a seperate Database server running

## Entity Framework Core

ef Core, allows our c# application to communicate with a database

* Instead of writing SQL ourselves, we can work with our database using C#

C# API -> Ef Core -> SQLite Database

## AppDbContext class

This is the main connection between our app and database

it tells Ef core which models we want to store in our database

each DBset inside of our AppDbContext represents a table

## What is a migration

A Migration is EF cores way of keeping track of changes we want to make in our Database

any migrations after the initial can be named anything
* dotnet ef database update


## Updating the Database

Creating a migration does not auto update database

we still need to run our DB update

*dotnet ef database update*

Model -> MIgration -> DAtaBase update ->Database


## Common LINQ Methods

FirstOrDefault() - finds the first matching record, if nothing is found returns null

Where() - filters records based on a condition (we would store result in variable)

ToList() -gets multiple records and returns them as a list


## SaveChanges

EF core keeps track of changes we make to our data\

when we add, update, or remove those changes need to be saved to DB

* SaveChanges() * Tells EF core