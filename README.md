# EF.Ejemplo

Para crear Migration el comando es   
==================================

Dentro de la carpeta EF.Infraestructure Ejecutar

dotnet ef migrations add [NombreDeMigration1]
dotnet ef migrations add [NombreDeMigration2]

Para aplicar las Migration
==========================
dotnet ef database update

Para volver atras una migration
================================
dotnet ef database update [NombreDeMigration1]
dotnet ef migration remove

