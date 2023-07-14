# Health Care

Health Care is a web application that provides appointment reminder, patient management, and appointment scheduling services for health care providers and patients. Users can create profiles, add and manage patients, schedule and cancel appointments, and receive reminders via email or SMS. The project is built with .NET 6, a cross-platform framework for building web applications.
## Features

- CRUD operations using MediatR
- Object to Relational Mapping using Npgsql.EntityFrameworkCore.PostgreSQL
- Mapping operations using AutoMapper
- Appointment reminder using Quartz
- Using IMemoryCache service  
- PostgreSQL database using Docker
- IExcetionHandler interface catching up with exception
- Logging operations using SERILOG


To install Health Care, you need to have .NET 6 SDK installed on your system. You also need to clone this repository to your local machine using the following command :
```
git clone https://github.com/talhabuyukkose/HealthCare.git
```
Then, navigate to the project directory and run the following command to restore the dependencies:
```
dotnet restore
```

Save the following script a file type yml
```
version: '3.1'

services:
  mypostgre:
    container_name: healthcare
    image: postgres:latest
    restart: always
    ports:
      - 9433:5432
    environment:
      - POSTGRES_PASSWORD=passpass
      - POSTGRES_USER=root
      - POSTGRES_DB=healthcaredb
      - PGDATA=/var/lib/postgresql/data/pgdata
    volumes:
      - C:\ProgramData\DockerDesktop\Postgre\HealthCare:/var/lib/postgresql/data
```

Run the following command to start the Redis server using Docker:

```
docker-compose up -d
```
