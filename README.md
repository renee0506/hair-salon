# Hair Salon Management App
#### _A web app that helps manage hair salon_

#### By _**Renee Mei**_

## Description

This website will allow users to view current stylists in a hair salon, current clients of each stylists and also allow users to add new client, delete client and change information for client.

## Setup/Installation Requirements

* Requires DNU, DNX, and Mono
* Clone to local machine
* Use command "dnu restore" in commandline
* In SQLCMD:

      CREATE DATABASE hair_salon;
      GO
      USE hair_salon;
      GO
      CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255));
      CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255), age INT, bio VARCHAR(255));
      GO
      ALTER TABLE clients ADD stylist_id INT;
      GO
* Use command "dnx kestrel" to start server
* Navigate to http://localhost:5004 in web browser of choice

## Specifications

Example Clients:

| Object | Name | Stylist |id|
|---|---|---|
|  Client1 | Jennifer  | Roy  |1|
|  Client2 | Kathy  | Roy |2|

Example Sylists:

| Object | Name | Age |Bio|id|
|---|---|---|
|  Stylist1 | Roy  | 22  | 5 year experience|1|
|  Stylist2 | Joe  | 18 | just graduated from fashion school|2|

**The GetAll method will return an empty list if the list of stylist is empty in the beginning**
* Example Input: function call
* Example Output: List<Stylist>{ }

**The Assert.Equal method will return true if two stylist has the exactly same name, age, and bio**
* Example Input: Stylist1, Stylist1
* Example Output: true

**The Save method will save the information of a new stylist to the database**
* Example Input: Stylist1
* Example Output: Stylist1 saved to table: stylists

**The Save method will save the information of a new stylist to the database, and the new stylist should have an id assigned**
* Example Input: Stylist1
* Example Output: Stylist1 has an id

**The DeleteAll method will clear all content in the database**
* Example Input: DeleteAll( )
* Example Output: Table: stylists is empty

**The Find method will find a specific stylist in the database by its id**
* Example Input: 1
* Example Output: Stylist1

**The GetClients method will find all the clients of the same stylist.**
* Example Input: Stylist1.GetClients( )
* Example Output: List<Client>{Client1, Client2}

**The GetAll method will return an empty list if the list of clients is empty in the beginning**
* Example Input: Client.GetAll( )
* Example Output: List<Client>{ }

**The Assert.Equal method will return true if two clients has the exactly same name**
* Example Input: Client1, Client1
* Example Output: true

**The Save method will save the information of a new client to the database**
* Example Input: Client1.Save( )
* Example Output: Client1 saved to table: clients

**The Save method will save the information of a new client to the database, and the new client should have an id assigned**
* Example Input: Client1.Save( )
* Example Output: Client1 has an id

**The DeleteAll method will clear all content in the database**
* Example Input: Client.DeleteAll( )
* Example Output: Table: clients is empty

**The Find method will find a specific client in the database by its id**
* Example Input: 1
* Example Output: Client1

**The Update method will update the name of a client**
* Example Input: Client1.Update("Patria")
* Example Output: Client1.GetName = "Patria"

**The Delete method will delete the entry of client from database**
* Example Input: Client1.Delete( )
* Example Output: Table: clients does not have Client1's information anymore

## Support and contact details

Please contact Renee Mei at dontemailme@dontemailme.com with any questions, concerns, or suggestions.

## Technologies Used

This web application uses:
* Nancy
* Mono
* DNVM
* C#
* Razor
* Microsoft SQL Command
* Microsoft SQL Server Management Studio

### License

*This project is licensed under the MIT license.*

Copyright (c) 2017 **_Renee Mei_**
