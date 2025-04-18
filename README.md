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


![image](https://github.com/user-attachments/assets/11c1e0b4-7297-479e-a7aa-496571171354)



 ## ⚙️ Technologies utilisées

- ASP.NET Core
- Entity Framework Core
- SQL Server


## 🚀 Setup du projet

### 1. Cloner le dépôt


git clone https://github.com/eya-mejri/backend.NET.git
cd TechnicalAssesments



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
![image](https://github.com/user-attachments/assets/3591af2c-55f3-47d7-8f1b-f77ceb5f5187)
partie metier ne peux pas ajouter deux date au mm temps
![image](https://github.com/user-attachments/assets/09bba086-a220-4fed-ac97-90dbc276e0a7)


### 📋 Lister toutes les demandes
GET /api/leaverequests
![image](https://github.com/user-attachments/assets/4a6c2263-5f7e-459d-aedb-7f9d00d97864)


### 🔍 Récupérer une demande par ID
GET /api/leaverequests/{id}
![image](https://github.com/user-attachments/assets/b1784aa7-9aec-4d85-9525-892cf8a68fa2)


### ✏️ Modifier une demande
PUT /api/leaverequests/{id}

![image](https://github.com/user-attachments/assets/4038bf41-02f3-4759-9684-ca89841651ff)

### ❌ Supprimer une demande
DELETE /api/leaverequests/{id}
![image](https://github.com/user-attachments/assets/594f5900-1466-4ce3-8f7c-65825bd5bb6c)


### 🔎 Filtrer les demandes
GET /api/leaverequests/filter?employeeId=&leaveType=&status=
![image](https://github.com/user-attachments/assets/f441d810-605b-436a-a98e-bcf830d5c640)

les demandes ne dépassent pas 20 jours 
![image](https://github.com/user-attachments/assets/0b7db076-8eb8-4022-b33e-f56c915642df)


### 📊 Rapport global des demandes
GET /api/leaverequests/report
![image](https://github.com/user-attachments/assets/b689d36d-ad0d-41b7-a527-81923a673235)


### ✔️ Approuver une demande
PUT /api/leaverequests/approve/{id}
![image](https://github.com/user-attachments/assets/3ebe0272-9e35-41fa-9a3a-134bd13ee514)

ne peux pas approuver qui est déja approuvé ou rejeté 
![image](https://github.com/user-attachments/assets/e0984719-33ee-4f9c-ba79-688f94b31eee)


## 📘 Règles métier
### LeaveType
0 : Congé annuel

1 : Congé maladie

2 : Autre

### Status
0 : En attente (Pending)

1 : Approuvé (Approved)

2 : Rejeté (Rejected)

