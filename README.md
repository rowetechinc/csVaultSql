# csVaultSql

A C# Vault interface using a PostgreSQL DB.

Vault is our internal testing and archive of all test results.

The original Vault is a Golang backend with a MongoDB frontend.  The MongoDB has never been modified, so the DB will
be porited to a PostgreSQL DB.  This will ease the data querying.  The Frontend uses React to view the
data and a WPF application to modify the data.  

This will now use ASP.NET to consolidate the frontend and backend to a single interface,
so the data can be viewed and modified.  The C# applications to add and modify data can 
remain so all test software will just store the data to a new DB with a new but similar schema.

# Pull Data from Database

## Create DbContext to the Postgres SQL server
In Package Manager Console
```
dotnet ef dbcontext scaffold "Host=192.168.1.xxx;Database=Vault;Username=postgres;Password=my_pass" npgsql.EntityFrameworkCore.PostgreSQL
```

## Create ConnectionString
In appsettings.jon
```
"ConnectionStrings": {
    "VaultContext": "Host=192.168.1.XXX;Database=Vault;Username=postgres;Password=my_pass"
}
```

## Create Startup to DB Connection
In startup.cs.  VaultContext is defined in the ConnectionStrings in appsettings.json.
```
services.AddDbContext<VaultContext>(options => options.UseNpgsql(Configuration.GetConnectionString("VaultContext")));
```

## Scaffold
Use Scaffolding to create the DbContext file, and HTML and Razor file for the Model file created.
* Create a folder Pages\Adcp
* Right click on the folder Add-> New Scaffold Item
** Select the Model object created

All the files will be generated.  Create a Data folder and move the DbContext file to the folder.


# Update the Database if Model modified
In Package Manager Console
```
Add-Migration DescriptionOfChanges
Update-Database
```
Changes will be made in the database so the Model and Table schema match.

# Export MongoDB data to Postgres
* Export the Mongo DB Table to a CSV file.
* Create the Table in Postgres
* Lost the CSV to Postgres

## Export MongoDB
Install the Mongo Tools in Ubuntu
```
mongoexport  --host 192.168.0.XXX:32768 --db Vault --collection adcps --type=csv --out adcps.csv --fields name,created,SerialNumber,Customer,OrderNumber,RmaNumber,DepthRating,HeadType,Hardware,ConnectorType,Frequency,Firmware,Software,TemperaturePresent,PressureSensorPresent,PressureSensorRating,EthernetInstalled,RecorderSize,RecorderFormatted,SystemType,Application,NumBatts,ProductNumber,ScaleFactor,IsVesselMount,IsRiverSystem,BoardOrientation,HousingType,CableLength,IsTriggerOut,IsTriggerIn,Modified
```
I had to open the file in Libre Writer and save again to fix the UTF-8 issue.  The export exported the CSV to a binary file and not ASCII.  Libre Writer can read the binary file and when it is saved, it saves it to ASCII.

## Create the Table in Postgres
```
CREATE TABLE adcps (id SERIAL PRIMARY KEY, name VARCHAR, created TIMESTAMP, SerialNumber VARCHAR, Customer VARCHAR, OrderNumber VARCHAR, DepthRating VARCHAR, HeadType VARCHAR, Hardware VARCHAR, ConnectorType VARCHAR, Frequency VARCHAR, Firmware VARCHAR, Software VARCHAR, TemperaturePresent BOOLEAN, PressureSensorPresent BOOLEAN, PressureSensorRating VARCHAR, EthernetInstalled BOOLEAN, RecorderSize VARCHAR, RecorderFormatted BOOLEAN, SystemType VARCHAR, Application VARCHAR, NumBatts VARCHAR, ProductNumber VARCHAR, ScaleFactor VARCHAR, IsVesselMount BOOLEAN, IsRiverSystem BOOLEAN, BoardOrientation VARCHAR, HousingType VARCHAR, CableLength VARCHAR, IsTriggerOut BOOLEAN, IsTriggerIn BOOLEAN, Modified TIMESTAMP);
```


## Copy the CSV file to Postgres
Start Postgres
```
su - postgres
psql -U postgres
copy adcps(name,created,SerialNumber,Customer,OrderNumber,RmaNumber,DepthRating,HeadType,Hardware,ConnectorType,Frequency,Firmware,Software,TemperaturePresent,PressureSensorPresent,PressureSensorRating,EthernetInstalled,RecorderSize,RecorderFormatted,SystemType,Application,NumBatts,ProductNumber,ScaleFactor,IsVesselMount,IsRiverSystem,BoardOrientation,HousingType,CableLength,IsTriggerOut,IsTriggerIn,Modified) FROM '/home/rico/Documents/vault/adcp.csv' DELIMITER ',' CSV HEADER;
```