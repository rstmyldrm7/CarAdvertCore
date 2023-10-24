# CarAdvertCore Web API - README

This README provides instructions for setting up and running the CarAdvertCore Web API project, which is responsible for providing back-end services for a mobile application collecting and publishing vehicle adverts. The project includes integration with Apache Kafka and Docker containerization for the web API and database.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Docker Setup](#docker-setup)
- [Running the Application](#running-the-application)
- [Endpoints](#endpoints)

## Prerequisites

Before you start, ensure you have the following prerequisites installed:

- [Docker](https://www.docker.com/)
- [.NET Core SDK](https://dotnet.microsoft.com/download)

## Docker Setup

#### Clone this repository to your local machine.
open the command shell -> git clone <(https://github.com/rstmyldrm7/CarAdvertCore.git>

#### Change your working directory to the project folder.
-> cd CarAdvertCore

#### Build the Docker containers for your web API, database, and Kafka by running the following command:
-> docker-compose up --build -d

This command will build and start the Docker containers for your project, including the web API, the chosen database, and Apache Kafka.

## Running the Application

The CarAdvertCore Web API should now be up and running in a Docker container.

The API is accessible at http://localhost:8080 

## Endpoints

#### Endpoint 1: Query Adverts
URL: /advert/all
HTTP Method: GET
Filtering Fields:  categoryId, price, gear, fuel, page
Sorting Fields: price, year, km
SampleRequestExample : https://localhost:8080/advert/all?filteringFields.categoryId=14578&filteringFields.PriceFrom=50&filteringFields.PriceTo=150&filteringFields.gears=0&filteringFields.gears=1&filteringFields.fuel=0&filteringFields.fuel=1&Field=0&Direction=0&PageSize=1&PageNumber=10

Sample Response:

json
{
  "total": 100,
  "page": 1,
  "adverts": [
    {
      "id": "16030353",
      // ... (advert details)
    },
    {
      "id": "15501819",
      // ... (advert details)
    }
  ]
}

#### Endpoint 2: Query Adverts
URL: /advert/get
HTTP Method: GET
SampleRequestExample : http://localhost:8080/advert/get?Id=11600515
Filtering Fields:  categoryId, price, gear, fuel, page
Sorting Fields: price, year, km

This endpoint is also using kafka queue to record track of visit an advert to insert the record in Visits table async way.

Sample Response:
json
{
  "id": "15763767",
  // ... (advert details)
}

#### Endpoint 3: Record IP Visits

- URL: /advert/visit
- HTTP Method: POST

This endpoint allows to create a visit record directly to database by using Orm dapper async method. IP information of the record visit is gotten from header.
  
- Request Body:
json
{
  "advertId": "15763767"
}

HTTP response codes:

| Code | Reason |
| ---- | ------ |
| 201  | visit created |
| 500  | Internal error occurred |
