# moonsite-HouseholdingManeger
## C# .net framework 4.7.2 and umbraco cms (not suitable for mac)

This is the householdingManger project, it allows you to manage your tenant payments in a digital system, and get a report for each month and payment status, allso you can fill in your tenant payment information, and your database will be updated as needed. 

* Main Page:

![image](https://github.com/romanbishof/moonsite-HouseholdingManeger/assets/76264579/c61e02a2-9b1d-475f-9cbd-a380b91cd5d9)


* Report Page:

![image](https://github.com/romanbishof/moonsite-HouseholdingManeger/assets/76264579/c84c5761-65ff-4929-8ea6-4cb6a4b63fad)



![image](https://github.com/romanbishof/moonsite-HouseholdingManeger/assets/76264579/03662341-f147-4ad4-92f6-6c79ecfafdee)



* Toolkit popup nice feature:

![image](https://github.com/romanbishof/moonsite-HouseholdingManeger/assets/76264579/2b9744db-00a4-4819-afbc-674aa34027e3)


* Sending email feature:
located at - RecieptController.cs and web.config

Right now the email is created in the local folder - future development will be done 


![image](https://github.com/romanbishof/moonsite-HouseholdingManeger/assets/76264579/fc4646f2-0194-4577-9450-664c92e85bb0)

![image](https://github.com/romanbishof/moonsite-HouseholdingManeger/assets/76264579/02f0a55c-a018-4cfa-9718-ed1fa5b8f767)



## Running the Samples From the Command Line
* Clone this repository:
```
    $ git clone https://github.com/romanbishof/moonsite-HouseholdingManeger.git
```

* Open the folder via your code editor (I used visual studio):
```
   =)
```

* Include the Nuget packages:
```
    under moonsiteHouseholderManager.web click on reference -> manage nuget packages
    choose:  umbraco.sqlserverce, umbracocms, umbracocms.core, umbracocmsweb

    under moonsiteHouseholderManager.web click on reference -> manage nuget packages
    choose:  umbraco.sqlserverce, umbracocms.core, umbracocms.web

    if the file doesn't exists:
    Project -> Manage Nuget Packages ->Install the necessary 

```
* Please create a folder:
  ```
  c:\temp\mail
  ```
* Run the project
```
     right click on "moonsiteHouseholdeManager.web" -> debug -> start new instance
```


# Uploading the database
1. via SQL server object explorer create a new empty database named: MoonsiteHouseholdManeger
2. right-click on it and chose Publish data-tier application
3. browse to  DataBaseBackup folder select housholddata.dacpac file and click on publish (press "yes" whether a popup shows up)
   ![image](https://github.com/romanbishof/moonsite-HouseholdingManeger/assets/76264579/edf85ee2-f392-4d2e-8356-a54bb9996991)
4. wait for data to be published
   ![image](https://github.com/romanbishof/moonsite-HouseholdingManeger/assets/76264579/39ca90f9-7c13-4fea-829e-0820fe13079a)
   ![image](https://github.com/romanbishof/moonsite-HouseholdingManeger/assets/76264579/5f782ba4-c19d-4e39-b1d5-c4e171544eb8)

 
# Troubleshutting:
  if error Could not find the  file ... bin\roslyn\csc.exe accrues
  open the Nuget console and run: 
  ```
  Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
  ```

# Routing
The webpage automatically will be opened on the "payment page" and there is a field on the top of the screen to navigate to the reciepts page
