# backend.NET
Base de Données:
1/Creer le dossier data pour  configuration de la bd qui contient "AppDBContext" puis ajouter les params dans "appsettings.json" et "program.cs"
2/Lancer la cmd de migration pour la creation de la bd et les tables à partir des entités
.dotnet ef migrations add InitialCreate
.dotnet ef database update

3/Creer un employer dans sql server :
CREATE TABLE Employee (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100),
    Department NVARCHAR(20)
);

Pour respecter l'architecture microservices j'ai adapté cette squelete pour mon projet :
Ce projet est une API Web développée avec ASP.NET Core.
L'architecture interne est structurée en différentes couches pour une meilleure séparation des responsabilités,
incluant notamment un dossier "Controllers" pour la gestion des requêtes HTTP et un dossier "Repositories" suggérant l'implémentation du Repository Pattern pour l'abstraction de l'accès aux données.
![image](https://github.com/user-attachments/assets/3a25b9fc-1adb-4d6d-9a47-17ab43a8e320)# backend.NET







