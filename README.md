📦 Projet API - Gestion des demandes de congé
Cette API est développée en ASP.NET Core suivant une architecture en couches et adaptée à une logique microservices. Elle permet de gérer des demandes de congé avec les opérations CRUD, des filtres avancés, des règles métiers, et un reporting résumé.

🏗️ Architecture du projet
Data : contient AppDbContext.cs pour la configuration EF Core.

Controllers : expose les endpoints HTTP.

Repositories : contient les interfaces et implémentations pour accéder aux données (Pattern Repository).

Models : contient les entités (ex. LeaveRequest, Employee, etc.).

DTOs : gère les objets de transfert de données (ex. LeaveRequestDto).

🗃️ Configuration Base de Données
Étapes :
Créer dossier Data/ et ajouter AppDbContext.cs.

Configurer la connexion dans appsettings.json :

json
Copier
Modifier
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=LeaveDb;Trusted_Connection=True;"
}
Configurer dans Program.cs :

csharp
Copier
Modifier
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
Commandes EF Core :

bash
Copier
Modifier
dotnet ef migrations add InitialCreate
dotnet ef database update
Ajouter un employé test :

sql
Copier
Modifier
INSERT INTO Employees (FullName, Department, JoiningDate)
VALUES ('John Doe', 'Engineering', '2023-05-15');
🧩 Enumérations utilisées
LeaveType :

0 → Annual

1 → Sick

2 → Other

Status :

0 → Pending

1 → Approved

2 → Rejected

🌐 Endpoints API
➕ POST /api/leaverequests
Créer une nouvelle demande de congé

Body JSON exemple :

json
Copier
Modifier
{
  "employeeId": 1,
  "leaveType": 0,
  "startDate": "2025-05-01",
  "endDate": "2025-05-10",
  "reason": "Vacances annuelles"
}
📄 GET /api/leaverequests
Récupérer toutes les demandes de congé

🔍 GET /api/leaverequests/{id}
Récupérer les détails d'une demande spécifique

✏️ PUT /api/leaverequests/{id}
Modifier une demande existante

Body JSON exemple :

json
Copier
Modifier
{
  "leaveType": 1,
  "startDate": "2025-06-01",
  "endDate": "2025-06-05",
  "reason": "Congé maladie"
}
❌ DELETE /api/leaverequests/{id}
Supprimer une demande

🧠 GET /api/leaverequests/filter
Filtrage dynamique des demandes

Paramètres de requête possibles :

leaveType : 0, 1, 2

status : 0, 1, 2

employeeId : ID d’un employé

startDate / endDate : date de début ou de fin

Exemple :

bash
Copier
Modifier
/api/leaverequests/filter?status=1&leaveType=0&employeeId=3
📊 GET /api/leaverequests/report
Retourne un rapport résumé (statistiques par type de congé, par statut, etc.)

✅ POST /api/leaverequests/{id}/approve
Approuver une demande si son statut est Pending (0).

Si la demande est déjà approuvée ou rejetée, l'API retourne une erreur.

🛠️ Règles Métiers
Seules les demandes avec un statut "Pending" peuvent être approuvées.

Les statuts sont immuables une fois approuvés/rejetés.

Un employé ne peut pas avoir deux congés qui se chevauchent (à implémenter éventuellement).



















# backend.NET

Base de Données:
1/Creer le dossier data pour  configuration de la bd qui contient "AppDBContext" puis ajouter les params dans "appsettings.json" et "program.cs"
2/Lancer la cmd de migration pour la creation de la bd et les tables à partir des entités
.dotnet ef migrations add InitialCreate
.dotnet ef database update

3/Creer un employer dans sql server :
INSERT INTO Employees (FullName, Department, JoiningDate)
VALUES ('John Doe', 'Engineering', '2023-05-15');

Pour respecter l'architecture microservices j'ai adapté cette squelete pour mon projet :
Ce projet est une API Web développée avec ASP.NET Core.
L'architecture interne est structurée en différentes couches pour une meilleure séparation des responsabilités,
incluant notamment un dossier "Controllers" pour la gestion des requêtes HTTP et un dossier "Repositories" suggérant l'implémentation du Repository Pattern pour l'abstraction de l'accès aux données.
![image](https://github.com/user-attachments/assets/3a25b9fc-1adb-4d6d-9a47-17ab43a8e320)

maintenant je vais commencer par:

l'api API AddRequest : ajouter demande
![image](https://github.com/user-attachments/assets/f192a45e-0958-49e1-973a-1d8e9dc2e341)


Api GET Request : Afficher tous 
![image](https://github.com/user-attachments/assets/70bca482-2323-4bf3-ad5e-49145be4ccd2)



Api Get Request by ID  : afficher une demande 
![image](https://github.com/user-attachments/assets/6875987d-22c2-4420-932d-3d3ddd8bcbd6)


Api PUT Request : modifier une demande 
![image](https://github.com/user-attachments/assets/49220f44-8dd5-4ece-9a80-501051e065fe)


Api Delete Request : supprimer une demande
![image](https://github.com/user-attachments/assets/01183063-ddfb-4b67-a82f-c2c5db94a8fa)


API Filter : filtrer une demande et api métier 
![image](https://github.com/user-attachments/assets/d79a2253-6af1-4be2-9133-f88cdcbe3867)
![image](https://github.com/user-attachments/assets/d3b39e99-25d7-47dd-bb84-ccb91f29f8b0)
![image](https://github.com/user-attachments/assets/3de83d95-4806-4d4e-b127-21c2888ffb70)
LeaveType =0 annual , leaveType=1 Sick , leaveType=2 other 
Status = 0 pending , status = 1 approved , status = 2 rejected 


Api leaverequests : Rapport des demandes 
![image](https://github.com/user-attachments/assets/b38109a1-6e82-4013-a072-564cf7d04167)


Api approver les demandes avec le statut pending et si le statut est different on ne peux pas l'approver une autre fois 

![image](https://github.com/user-attachments/assets/9ee63c59-7b67-4b97-a537-02171de6cec4)

![image](https://github.com/user-attachments/assets/fac95545-87af-45de-81d4-07db0441ca2a)


















