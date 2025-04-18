# 🛠️ Leave Management API (.NET Core)

**Leave Management API** est une application Web API développée avec **ASP.NET Core** qui permet de gérer les demandes de congés des employés. Elle offre une gestion complète : ajout, modification, suppression, approbation, filtrage, et reporting.

---

## 👩‍💻 Auteure

**Eya Mejri**  
Développeuse .NET — passionnée par le clean code, les APIs REST et les architectures modulaires.  
📧 [eya.mejri@esprit.tn](mailto:mejri.eya97@gmail.com)

---

## 🧱 Architecture 

Le projet suit une **architecture en couches** avec séparation claire des responsabilités :

- `Controllers` : gestion des requêtes HTTP.
- `Services` : logique métier et règles de validation.
- `Repositories` : accès aux données via Entity Framework Core.
- `DTOs` : objets de transfert entre client ↔ serveur.
- `Entities` : modèles de base de données.
- `Data` : configuration du `DbContext`.
- `Migrations` : migrations EF Core générées automatiquement.

---

## 🗂️ Structure du projet

LeaveManagementAPI/
 ├── Controllers/ 
 ├── Data/
 ├── DTOs/
 ├── Entities/ 
 ├── Migrations/ 
 ├── Repositories/ 
 ├── Services/
 ├── appsettings.json 
 ├── Program.cs 
 └── README.md


 ## ⚙️ Technologies utilisées

- ASP.NET Core
- Entity Framework Core
- SQL Server
- Swagger (Swashbuckle)
- LINQ, Async/Await


## 🚀 Setup du projet

### 1. Cloner le dépôt


git clone https://github.com/eya-mejri/LeaveManagementAPI.git
cd LeaveManagementAPI



### 2. Restaurer les packages NuGet
dotnet restore


### 3. Configurer la base de données
Vérifie ou modifie ta chaîne de connexion dans appsettings.json :
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=LeaveManagementDB;Trusted_Connection=True;"
}


### 4. Créer la base de données avec EF Core
dotnet ef migrations add InitialCreate
dotnet ef database update



###  5. Démarrer le projet
dotnet run


# 📚 Documentation API
https://localhost:{port}/
🔌 Endpoints API


### ➕ Ajouter une demande
POST /api/leaverequests


### 📋 Lister toutes les demandes
GET /api/leaverequests


### 🔍 Récupérer une demande par ID
GET /api/leaverequests/{id}


### ✏️ Modifier une demande
PUT /api/leaverequests/{id}


### ❌ Supprimer une demande
DELETE /api/leaverequests/{id}


### 🔎 Filtrer les demandes
GET /api/leaverequests/filter?employeeId=&leaveType=&status=


### 📊 Rapport global des demandes
GET /api/leaverequests/report


### ✔️ Approuver une demande
PUT /api/leaverequests/approve/{id}


## 📘 Règles métier
### LeaveType
0 : Congé annuel

1 : Congé maladie

2 : Autre

### Status
0 : En attente (Pending)

1 : Approuvé (Approved)

2 : Rejeté (Rejected)

