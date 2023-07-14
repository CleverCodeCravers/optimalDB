# optimalDb

optimalDb is a project to help us with sql server based tasks as well as creating c# classes for several problems that we face at our workingplace.

The software loads a list of connection strings and allows for easy access to the databases and database objects within. 

## Setting Up a Testing Environment

In this guide, we will walk you through setting up a local Microsoft SQL Server Express and installing the AdventureWorks sample database. 

### Step 1: Installing Microsoft SQL Server Express

1. Visit the official [Microsoft SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) download page.
2. Click on the "Download now" button under the SQL Server 2019 Express.
3. Once the download completes, open the installer.
4. In the SQL Server installation center, click on the "Basic" installation type.
5. Accept the license terms and click "Install".
6. Wait for the installation to complete.
7. Upon completion, make note of the server name (you will use this to connect to the server), and then click "Close".

### Step 2: Installing SQL Server Management Studio (SSMS)

SQL Server Management Studio (SSMS) is a software application first launched with Microsoft SQL Server 2005 that is used for configuring, managing, and administering all components within Microsoft SQL Server.

1. Visit the official [SSMS](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms) download page.
2. Click on the "Download SQL Server Management Studio (SSMS)" button.
3. Once downloaded, run the installer and follow the on-screen instructions to install SSMS.

### Step 3: Installing the AdventureWorks Sample Database

1. Visit the [AdventureWorks Sample Databases](https://docs.microsoft.com/en-us/sql/samples/adventureworks-install-configure) on Microsoft's website.
2. Download the `AdventureWorks2019.bak` file.
3. Open SSMS and connect to your SQL Server instance.
4. Right-click "Databases" and then select "Restore Database".
5. Select "Device" and then click on the "..." button to browse for the `AdventureWorks2019.bak` file you downloaded.
6. Click "OK" to start the restore process.
7. Once the restore is complete, you should see the AdventureWorks database in your list of databases in SSMS.

