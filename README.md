# Nullability in C#

This repository contains sample code for an upcoming series of articles about nullability, nullable reference types, and the various null operators in C# (null conditional, null coalescing, and null forgiving).  

---

## Articles  
*Links will be added as the articles are completed.*

* [Nullability in C# - What it is and what it is not](https://jeremybytes.blogspot.com/2022/07/nullability-in-c-what-it-is-and-what-it.html)
* Null Conditional operators in C# - ?. & ?[]
* Null Forgiving operator in C# - !
* Null Coalescing operators in C# - ?? & ??=

---  

## Sample Code  
The sample code is take from the resources for "I'll Get Back to You: Task, Await, and Asynchronous Methods in C#" (Repository: [using-task-dotnet6](https://github.com/jeremybytes/using-task-dotnet6)).  

The "**StartingCode**" folder contains the original code without null checks or nullability enabled.

The "**FinishedCode**" folder contains the completed code with nullability enabled as well as null checks and various uses of the null operators.

---

## Running the Application  
If you would like to follow along with the code and steps shown in the articles, you can run the sample application with the following:

The **.NET service** must be started before the main application can be run. One way is to start the service from the command line and then leave it running while debugging the main application in Visual Studio.  

To start the service from the command line, navigate to the ".../People.Service" directory and type `dotnet run`. This provides endpoint at the following location:

* http://localhost:9874/people  
Provides a list of "Person" objects. This service will delay for 3 seconds before responding. Sample result:

```json
[{"id":1,"givenName":"John","familyName":"Koenig","startDate":"1975-10-17T00:00:00-07:00","rating":6,"formatString":null},  
{"id":2,"givenName":"Dylan","familyName":"Hunt","startDate":"2000-10-02T00:00:00-07:00","rating":8,"formatString":null}, 
{...}]
```

With the service running, you can run the desktop application (UsingTask.UI) from Visual Studio by pressing F5 (or using the menu or toolbar) to start debugging. 

---

## Relevant Files  
The following lists the relevant files where you can find the code used in the articles.  

### Project Files

* [StartingCode/UsingTask.UI/UsingTask.UI.csproj](/StartingCode/UsingTask.UI/UsingTask.UI.csproj)  
The project file for the desktop application. This version does **not** have nullability enabled.  

* StartingCode/UsingTask.Library/UsingTask.Library.csproj  
The project file for the code library. This version does **not** have nullability enabled.  

* FinishedCode/UsingTask.UI/UsingTask.UI.csproj  
The project file for the desktop application. This version **does** have nullability enabled.  

* FinishedCode/UsingTask.Library/UsingTask.Library.csproj  
The project file for the code library. This version **does** have nullability enabled.  

### Code Files

* StartingCode/UsingTask.UI/MainWindow.xaml.cs  
NO NULL CHECKS - The code-behind for the application (where the application code lives)  

* StartingCode/UsingTask.Library/PersonReader.cs  
NO NULL CHECKS - The asynchronous code that gets data from a web service  

* FinishedCode/UsingTask.UI/MainWindow.xaml.cs  
NULL CHECKS - The code-behind for the application (where the application code lives)  

* FinishedCode/UsingTask.Library/PersonReader.cs  
NULL CHECKS - The asynchronous code that gets data from a web service  

---  

