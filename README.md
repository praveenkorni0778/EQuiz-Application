# EQuiz-Application
Quiz Application for an educational Institute

Operations to be performed in application:
1. Admin can add, update, delete, enable and disable any quiz at any point of time.
2. Admin can add, update, delete, enable and disable qustions at any point of time for an existing quiz.
3. Apart from the Admin, rest of the users can only SEE the quiz and questions.

Aim:
1. Model Database which satisfies user, quiz, questions, tags, answers, explanations.
2. Create REST api's to create, read, update and delete various resources.
3. Create postman collection.
4. Add postman collection test Automation for sanity checking the end-points.

Tech Stack:
Asp.NET Web application with MVC Architecture for creating REST api and views.
Microsoft SQL Server Management studio for creating and maintaining databases.

Build:
1. Data Access:
  - Connects to database using object of connectivity string in web.config file.
  - Gets and Manipulates data from database using query string for all the api controllers (has different class for different api).
  - For put/ post -> gets the data in the form of object of model from api controller and executes it by a query string.
  - For Delete -> gets id to be deleted and performs delete operation.
  
2. Api's
  - Quiz api, Question api, Answer api, Explanation api.
  - Quiz api controller:
    - Developement - Done
    - All CRUD operations for Viewing, Inserting, Updating and Deleting Quiz records in Database.
    - Gets data from DataAccess and binds it with model for all the GET operations.
      - Gets the Data in the form of DataTable 
      - Using foreach loop, binds each Row in the DataTable with Model object
      - Adds all of them into a List and returns the list. 
    - Put and Post Operations:
      - Gets parameters from uri -> Model object 
      - method to put data in DataAccess
      - Returns a string of Succes or Failure
    - Delete Operations:
      - Gets parameters from uri -> id (to be deleted)
      - passes a method to DataAccess to perform delete operation.
      
  - Question api controller:
    - Similar to Quiz api controller, build in progress.
    
  - Answer api controller:
    - Similar to Quiz api controller, build in progress.
    
   - Explanation api controller:
    - Similar to Quiz api controller, build in progress.
      
3. View :
  - Currently avaliable as EditQuiz.cshtml(to be renamed as AdminView).
  - UserView.cshtml(to be build)
  
  - EditQuiz.cshtml
    - View of the admin from where admin can easily perform all the operations.
    - Build using html, css, jQuery
    - 4 Tables for Quiz, Question, Answer, Explanation respectively.
    - by using jQueru, DevExtreme we perform all the operations with ease.
    - Reason for using DevExtreme -> All crud operations can be done easily by the user in the table itself.
    
  - UserView.cshtml
    - For user
    - User can ONLY SEE all the quizes and the questions affiliated with it.
    
  
