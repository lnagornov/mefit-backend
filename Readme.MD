<div align="center">
    <h1>Noroff Assignment 7: Web API in ASP.NET Core</h1>
    <img src="https://i.ibb.co/6PtHsnw/pngwing-com.png" width="128" alt="API">
</div>

[![license](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![standard-readme compliant](https://img.shields.io/badge/readme%20style-standard-brightgreen.svg?style=flat-square)](https://github.com/RichardLitt/standard-readme)

## ME FIT CASE WEB API

This WEB RESTful API app is created with Entity Framework and an ASP.NET Core in C# and comprise of a database made with Postgres. 

(More info about the project here....)

Created by Lev Nagornov, Rik Dortmans & Ayoub Auolad ali

## Table of Contents

- [Install](#install)
- [Usage](#usage)
- [Maintainers](#maintainers)
- [Contributing](#contributing)
- [License](#license)

## Install

1. Clone the repository using:

```
git clone git@gitlab.com:AyoubAuolad/mefitcase_assignment.git
```

2. Download and install: 
* [PostgreSQL 14.3 or later](https://www.enterprisedb.com/downloads/postgres-postgresql-downloads)
* [.Net 6.0 or later](https://dotnet.microsoft.com/en-us/download/dotnet)

Please remember **username** and **password** for PostgreSQL, you will need to place them into **appsettings.json**

3. Change **PostgresLocalDbConnection** string in **appsettings.json** file in a project folder.

Your **appsettings.json** should look like this:

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "PostgresLocalDbConnection": "Server=localhost;Port=5432;Database=MeFitCaseDB;Username=postgres;Password=12345678"
  }
}
```

This connection sting allows the app connect to PostgreSQL to create and manipulate database.

4. Apply migrations using 

```
dotnet ef database update
```

It will create a database with tables and initial data.

## Usage

1. Run the the **Program.cs** file, it should start server and open browser on localhost with **Swagger** documentation.

2. Pick an action and press **Execute**. For some actions you also need to provide json filled with data.


## Maintainers

[@lnagornov](https://gitlab.com/lnagornov)
[@rikdortmans](https://gitlab.com/rikdortmans)
[@ayoubauolad](https://gitlab.com/ayoubauolad)

## Contributing

PRs accepted.

Small note: If editing the Readme, please conform to the [standard-readme](https://github.com/RichardLitt/standard-readme) specification.

## License

[MIT © Lev Nagornov, Rik Dortmans & Ayoub Auolad ali](../LICENSE)
