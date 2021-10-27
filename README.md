# **CSharp-Project**

#### To use please fork, and clone to personal device. You will need Workbench, and visual-studios 2019.  
#### Nuget package manager will also need to be installed (in tools menu) type in "Install-Package MySql.Data" in the terminal in vs.  
#### Schema.sql properties have to be changed - set build action as "content", and copy to output directory to "copy always".  
#### Please also create sales database in workbench.  
#### Check mySqlUtils, if you need to change any settings.  
  
    
#### Date for sales input is set from 1900 - hundred years in the future - can change in controller.



##	Project Overview
You are tasked with creating a sales report console application which an end user can interact with via C sharp. A relational database (MySQL) should be used to store and persist the sales data.

### * Database Requirements
Your MySQL database requires a single Sales table containing the following fields:
- SaleID (INT) – Primary Key.
- Product Name (VARCHAR).
- Quantity (INT).
- Price (FLOAT/DECIMAL).
- SaleDate (DATE) – Should automatically default to the days date.
Ensure the database and its table are created with the appropriate names, data types and constraints.

### * Project Requirements
The following requirements are must haves:
Upon starting the application, the user must be presented with the following two options at a minimum:
- Data Entry
- Reports
If the user selects Data Entry, they must be able to add a new sales record to the sales table in the database.
If the user selects Reports, they must be presented with the following four options at a minimum:
- Sales by Year (e.g. List of all sales in the year 2020 printed to the console).
- Sales by Month and Year (e.g. List of all sales in January of 2020 printed to the console).
- Total Sales by Year (e.g. The total amount of sales for 2021, i.e. the sum of all the sales).
- Total Sales by Year and Month (e.g. The total amount of sales for January of 2021).
MySQL queries are required for each of the Reports options, your program will run these against the database and retrieve the data to build the relevant report for the end user.
**IMPORTANT**: 	Some reports would be filtered by the year the user enters, other reports require user to enter a month AND year to filter the reports.

### * Why are we doing this project?
- To be able to use C# to read from mySQL database.  
- To be able to use mySQL commands.  
- Connect to database.  
- Use single responsibility principle.  
- Use C# to get input from user and put in database.  
- Use encapsulation.  
- Debug code.  

### * How I expected the challenge to go
- I expected this to be a bit of a challenge, as the classes and method outputs for me were a hard concept to grasp.   

### * What went well?
- Read methods using enumable, using logical expressions to handle any errors.  
- The commands needed in the repository to access the database.  


### * What did not go as planned?
- Changing output on methods from enumerable to double.  
- Trying to handle all errors, next time will try to thing of errors as writing code, and not react to them after - will prevent as much refactoring.  


### * Possible improvements for the future
- Using interfaces for repository, and possibly the menu.  

### * Notable Mentions (i.e. anyone that may have helped/produced valuable input to your project)
 - Morgan Welsh QA tutor (https://github.com/MrWalshyType2).  
 - Microsoft Docs.  
 - C-sharpcorner.    
 - mysqltutorial.  
 - QA.   
 - stackoverflow.  
