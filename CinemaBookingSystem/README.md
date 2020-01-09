# Project Name: CinemaBookingSystem

I had provided the entire  CinemaBookingSystem project to download with Sql server Script which contains tables and procedure, which are used in the preoject. 
This project is build using solid principle as mentioned below layers:-

	1. Cinema.DAL :- This is the data layer which consists the data models.It's reference is given inside the CinemaBookingSystem layer.
	2. Cinema.Repositories :- It is a generic reposistery interface. In which CRUD Method's are defined.
	3. CinemaBookingSystem :- This is the presentation layer which contains the layer which is visible to the user.
	4. CinemaUnitTest:- This layer contain's the all unit test cases.

## Database Part:

1. First things to do is to Create Database, an scripts file is placed inside the "DataBaseScripts" folder in the "CinemaBookingSystem" project solution with 
  name "DBScript1.sql" & name "DBScript2.sql".First Execute DBScript1.sql then execute the DBScript2.sql.

2. Open the Script file in the  SQL and execute the script. The script will automatically create the database with name "CinemaBookingDB".

3. It will also create all the required tables and store procedure which is used inside the project, along with some pre-entered data.

4. After Creating Database now make changes for the ConnectionStrings in appsettings.json file.

5. After this check the "appsettings.json" file and change the "DefaultConnection" connectionstring. Add your machines Data Source, User Id and Password.

6. Also check the "CinemaBookingDBContext.cs" file and change the "DefaultConnection" connectionstring inside "OnConfiguring" method. Add your machines Data Source, User Id and Password.


## Email:

To send the email functionality so that user get the confirmation mail after booking and un-booking the seats along with the key, Kindly follow the below mentioned steps :-

Go to "CommonMail.cs" page in the CinemaBookingSystem project solution and add the below mentioned parameters inside it :-

a. Add "SenderEmailAddress" value which is the sender email adderss from customer will receive the confrimation email.

b. Add "SenderEmailPassword" value which is the sender email address valid password.

c. Add "SenderSMTPPort" value of which is the smtp port number from which email service is getting used to send email.

If after adding valid credentials any error occur then enable your security login from your respective email id.

## CinemaUnitTest Project 

* If any error occur while executing the unit test cases, then check the properties of all the .json files.
* If "Copy to Output Directory" is not set to "Copy if newer" then make it "Copy if newer".

