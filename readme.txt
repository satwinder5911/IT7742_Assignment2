--------------------------CustomerApp-----------------------------------

This project is a small customer management system made in C#.
It was created to show how the Model-View-Controller (MVC) design works.
The program can add, edit, delete, and show customer records.
The data is stored in a small list inside the program, not in a real database.

--------Project Structure-----------------------------------------------

Model - Has CustomerData.cs which stores customer ID and name.

Controller - Has CustomerManager.cs which does all the logic.

View - Has CustomerView.cs which is the form that users can see and use.

Program.cs - Starts the form and connects everything.

CustomerAppTests  Has test files to check that all methods work properly.

------How It Works-------------------------------------------------------

Customer Management System
--------------------------

When the Customer App ( Project1) is build , the form opens.
The user can add, edit, or delete a customer.
The form sends these actions to the controller.
The controller updates the data in the list and sends the new data back to show on the form.

Unit Tests
-----------

There are  test files to check that deposit, withdraw, and info methods work correctly.
Build abd right click on MSTests.cs > runtests OR open View in Visual Studio (2022) > Open test Explorer > press (green) Play Button to build and run tests
All tests were run using MSTest in Visual Studio, and all passed.
