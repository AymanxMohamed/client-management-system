# Client Management System

## Description

This is a sample CRUD Project used as a POC

## Prerequisets

1. you must have dotnet sdk version "6.0.126" installed
2. you must have node version 20.9.0 or higher installed
3. you must have angular CLI version: 17.0.3 or higher installed

## How to Run the project

* Clone the project

* Open 2 terminal windows in the repo folder

* Run these commands in the first terminal window to run the API

```bash
cd back-end/src/

dotnet run --project CMS.Presentation.Api/
```

* Run these commands in the second terminal window to run the Client Angular App

```bash
cd front-end

npm install

ng serve
```

## Notes

* If the emails didn't sent or if you face any problem in it you have to use your gmail account and get an app password from your google account then place it inside the EmailService.cs file in the API project.

## The backend Architecture

* The used architecture is the well known clean-architecture with domain-driven-design
* The back-end project is divided into 4 layers according to the clean-architecture guide-lines
* in the application layer used the MediatR and CQRS patterns

## Live Demo Link

[Live Demo](https://drive.google.com/file/d/1HqwPaB9uT1pZFyCLtBa0CsuaKbOwse8b/view?usp=sharing)
