# Creating Folder Structure
mkdir src

cd src

# Adding Global Dontet Version
dotnet new globaljson --sdk-version 6.0.126
git add .
git commit -m "Create Global.Json File"

# Creating Solution
dotnet new sln -n CMS

# Creating Projects
dotnet new classlib -o CMS.Domain
dotnet new classlib -o CMS.Application
dotnet new classlib -o CMS.Infrastrucutre
dotnet new webapi -o CMS.Presentation.Api


# Adding Projects to Soluiton
dotnet sln add ./*

git add .
git commit -m "Creating and Adding projects to solution"

# Adding Projects References

# Api Projects
dotnet add CMS.Presentation.Api/ reference CMS.Infrastrucutre CMS.Application CMS.Domain

# Infrastructure Projects
dotnet add CMS.Infrastrucutre reference CMS.Application CMS.Domain

# Application Projects
dotnet add CMS.Application reference CMS.Domain

git add .
git commit -m "Adding Project References"

# Adding Nuget Packages
dotnet add CMS.Infrastrucutre package Microsoft.Extensions.Options -v 6.0.0
dotnet add CMS.Infrastrucutre package Microsoft.EntityFrameworkCore.Sqlite --version 6.0.16
dotnet add CMS.Infrastrucutre package System.Data.SQLite  -v 1.0.117
dotnet add CMS.Infrastrucutre package Microsoft.Extensions.Hosting -v 6.0.1
dotnet add CMS.Application/ package MediatR.Extensions.Microsoft.DependencyInjection --version 11.1.0


# Restoring Packages 
dotnet restore CMS.sln

git add .
git commit -m "Adding Nuget Packages"
