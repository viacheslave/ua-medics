# UA.Medics

A playground for medics open data from Ukranian [https://data.gov.ua](https://data.gov.ua) portal. 

The tools download the following data sets:
- legal entities and divisions
- medics
- medics statistics of declarations by age

Plans:
- track medics that are available to sign declarations.
- track most valuable medics based on a number of declaractions held.
- track new medics, resigned medics.

## Components

### UA.Medics.SyncWorker 
Grabs data from the portal and imports it into into database.

### UA.Medics.WebApi
Provides data for clients.

### Database instance
Postgres instance (dockerized).

## Prerequisites

- Windows / Linux
- Docker

## Stack

- .NET 5
- EF Core
- PostgresSQL

## Run

```
docker-compose up
```

## Features

- UA.Medics.SyncWorker triggers data sync on startup.
- UA.Medics.WebApi swagger is available.
- Dockerized postgres database uses mounted external data folder for persistence.
