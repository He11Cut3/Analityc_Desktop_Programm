use Analytic_db
go


create table Analityc_Main
(
Analityc_Main_id int primary key identity(1,1),
Analityc_Stock_id int,
Analityc_Plan_id int,
Analityc_Order_id int,
Analityc_Recipe_id int,
Analityc_Finished_Products_id int,
)

create table Analityc_Recipe
(
Analityc_Recipe_id int primary key identity (1,1),
Analityc_Recipe_Name nvarchar(50),
Analityc_Recipe_Ingredients_One nvarchar(50),
Analityc_Recipe_Ingredients_Two nvarchar(50),
Analityc_Recipe_Ingredients_Three nvarchar(50),
Analityc_Recipe_Ingredients_Four nvarchar(50),
)


create table Analityc_User
(
Analityc_User_id int primary key identity(1,1),
Analityc_User_Login nvarchar(50),
Analityc_User_First_Name nvarchar(50),
Analityc_User_Last_Name nvarchar(50),
Analityc_User_Patronymic nvarchar(50),
Analityc_User_Password nvarchar(50),
)
create table Analityc_Stock
(
Analityc_Stock_id int primary key identity(1,1),
Analityc_Stock_Name nvarchar(50),
Analityc_Stock_Feature nvarchar(50),
Analityc_Stock_Weight nvarchar(50),
Analityc_Stock_Description nvarchar(50),
Analityc_Stock_Date nvarchar(50),
Analityc_Stock_Status nvarchar(50),
)
create table Analityc_Plan
(
Analityc_Plan_id int primary key identity(1,1),
Analityc_Plan_Day_id int,
Analityc_Plan_Week_id int,
Analityc_Plan_Month_id int,
)

create table Analityc_Plan_Day
(
Analityc_Plan_Day_id int primary key identity(1,1),
Analityc_Plan_Day_Nomenclature nvarchar(50),
Analityc_Plan_Day_Date nvarchar(50),
Analityc_Plan_Day_Volume nvarchar(50),
Analityc_Plan_Day_Note nvarchar(50),
Analityc_Plan_Day_Status nvarchar(50),
)

create table Analityc_Plan_Week
(
Analityc_Plan_Week_id int primary key identity(1,1),
Analityc_Plan_Week_Nomenclature nvarchar(50),
Analityc_Plan_Week_Date nvarchar(50),
Analityc_Plan_Week_Volume nvarchar(50),
Analityc_Plan_Week_Note nvarchar(50),
Analityc_Plan_Week_Status nvarchar(50),
)
create table Analityc_Plan_Month
(
Analityc_Plan_Month_id int primary key identity(1,1),
Analityc_Plan_Month_Nomenclature nvarchar(50),
Analityc_Plan_Month_Date nvarchar(50),
Analityc_Plan_Month_Volume nvarchar(50),
Analityc_Plan_Month_Note nvarchar(50),
Analityc_Plan_Month_Status nvarchar(50),
)
create table Analityc_Order
(
Analityc_Order_id int primary key identity(1,1),
Analityc_Order_Name nvarchar(50),
Analityc_Order_Vendor_Code nvarchar(50),
Analityc_Order_Weight nvarchar(50),
Analityc_Order_Number_Boxes nvarchar(50),
Analityc_Order_Date nvarchar(50),
Analityc_Order_Status nvarchar(50),
)
create table Analityc_Finished_Products
(
Analityc_Finished_Products_id int primary key identity(1,1),
Analityc_Finished_Products_Name nvarchar(50),
Analityc_Finished_Products_Weight nvarchar(50),
Analityc_Finished_Products_Number_Boxes nvarchar(50),
Analityc_Finished_Products_Description nvarchar(50),
Analityc_Finished_Products_Date nvarchar(50),
Analityc_Finished_Products_Status nvarchar(50),
)
