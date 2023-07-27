# moonsite-HouseholdingManeger
## C# .net framework 4.7.2 and umbraco cms (not suitable for mac)

This is the householdingManger project, it allows you to manage your tenant payments in a digital system, and get a report for each month and payment status, allso you can fill in your tenant payment information, and your database will be updated as needed. 

Main Page:


Report Page:


Toolkit popup nice feature:



## Running the Samples From the Command Line
* Clone this repository:
```
    $ git clone https://github.com/romanbishof/moonsite-HouseholdingManeger.git
```
* Include the nuget packages(https://github.com/AuthorizeNet/sdk-dotnet):
```
    under moonsiteHouseholderManager.web click on reference -> manage nuget packages
    choose:  umbraco.sqlserverce, umbracocms, umbracocms.core, umbracocmsweb

    under moonsiteHouseholderManager.web click on reference -> manage nuget packages
    choose:  umbraco.sqlserverce, umbracocms.core, umbracocms.web

```
 * Build the project 
```
     dotnet build
```
* Run the project
```
     dotnet run
```
