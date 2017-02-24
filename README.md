# Hair Salon Management App
#### _A web app that helps manage hair salon_

#### By _**Renee Mei**_

## Description

This website will allow users to view current stylists in a hair salon, current clients of each stylists and also allow users to add new client, delete client and change information for client.

## Setup/Installation Requirements

* Requires DNU, DNX, and Mono
* Clone to local machine
* Use command "dnu restore" in command prompt/shell
* Use command "dnx kestrel" to start server
* Navigate to http://localhost:5004 in web browser of choice

## Specifications

**The GetAll method will return an empty list if the list of stylist is empty in the beginning**
* Example Input: Stylist.GetAll()
* Example Output: List<Stylist>{}

**The Assert.Equal method will return true if two stylist has the exactly same name, age, and bio**
* Example Input: "Jennifer Yang, 28, 5 years in the fashion industry"
* Example Output: "Jennifer Yang, 28, 5 years in the fashion industry"

**The Save method will save the information of a new stylist to the database**
* Example Input:
* Example Output:

**The Save method will save the information of a new stylist to the database, and the new stylist should have an id assigned**
* Example Input:
* Example Output:

**The DeleteAll method will clear all content in the database**
* Example Input:
* Example Output:

**The Find method will find a specific stylist in the database by its id**
* Example Input:
* Example Output:

**The GetClients method will find all the clients of the same stylist.**
* Example Input:
* Example Output:

**The GetAll method will return an empty list if the list of clients is empty in the beginning**
* Example Input: Stylist.GetAll()
* Example Output: List<Stylist>{}

**The Assert.Equal method will return true if two clients has the exactly same name**
* Example Input: "Jennifer Yang, 28, 5 years in the fashion industry"
* Example Output: "Jennifer Yang, 28, 5 years in the fashion industry"

**The Save method will save the information of a new client to the database**
* Example Input:
* Example Output:

**The Save method will save the information of a new client to the database, and the new client should have an id assigned**
* Example Input:
* Example Output:

**The DeleteAll method will clear all content in the database**
* Example Input:
* Example Output:

**The Find method will find a specific client in the database by its id**
* Example Input:
* Example Output:

**The Update method will update the name of a client**
* Example Input:
* Example Output:

**The Delete method will delete the entry of client from database**
* Example Input:
* Example Output:

## Support and contact details

Please contact Renee Mei at dontemailme@dontemailme.com with any questions, concerns, or suggestions.

## Technologies Used

This web application uses:
* Nancy
* Mono
* DNVM
* C#
* Razor

### License

*This project is licensed under the MIT license.*

Copyright (c) 2017 **_Renee Mei_**
