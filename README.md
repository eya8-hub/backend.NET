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


















