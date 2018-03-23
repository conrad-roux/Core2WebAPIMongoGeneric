# Core2WebAPIMongoGeneric
A WebAPI app done in .Net Core 2.0, using Mongodb as the repository with generic repo calls to the db

I created as this as I was looking for implementations on ways to do generic Reporistories for MongoDB. There are a lot of different ways
people are doing these repos, so I thought I would do one with WebAPI in a more formal way.

The pattern I used is - Controller makes a call to the Service Interface that calls a Model service. This calls the generic Repository
that connects to Mongo and returns the values to the Model Service.

Controller -> Service (IService) -> (Specific) Model -> (Generic) Repository -> (Generic) DB Content

Setup required
1. Create a database in mongodb using shell or any tool like Robo 3T
2. Database name must be - UserTest (case sensitive)
3. Create a collection named - users (case sensitive)

Usage of the API is as follows:

query all users -> (GET) http://localhost:port/api/users

query a user by ID -> (GET) http://localhost:port/api/users/{userid from mongo}

insert a user -> (POST) http://localhost:port/api/users     body = {"name" : "","email" : "","lastname" : ""}

Delete a user by ID -> (DELETE) http://localhost:port/api/users/{userid from mongo}

This project is licensed under the terms of the MIT license. See Licence file.
