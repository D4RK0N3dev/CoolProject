
# CoolProject
## Opis projektu
CoolProject to aplikacja backendowa w C#, implementuj¹ca Onion Architecture. Aplikacja obs³uguje rejestracjê i logowanie u¿ytkowników przez API z JWT, posiada rolê u¿ytkownika i administratora oraz po³¹czenie z baz¹ danych. Zawiera 4 encje, z czego 2 s¹ ze sob¹ powi¹zane.
## Wymagania
- .NET 6.0+
-	Entity Framework Core
-	SQL Server
-	JWT (do autoryzacji)
-	Swagger (do dokumentacji API)
## Instalacja
- Sklonuj repozytorium:
``` git clone https://github.com/D4RK0N3dev/CoolProject.git```
- Zainstaluj zale¿noœci:
dotnet restore
-	Skonfiguruj po³¹czenie z baz¹ danych w appsettings.json.
-	Uruchom migracje:
``` dotnet ef database update```
-	Uruchom aplikacjê:
``` dotnet run --project CoolProject.API```
## Struktura projektu
Projekt jest zgodny z Onion Architecture i podzielony na nastêpuj¹ce warstwy:
-	CoolProject.API: Warstwa prezentacji, obs³uguj¹ca ¿¹dania HTTP oraz autoryzacjê JWT.
-	Application: Logika biznesowa.
-	Domain: Zawiera modele i encje.
-	Infrastructure: Zarz¹dzanie danymi i konfiguracja baz danych.
## Encje
-	User: Reprezentuje u¿ytkownika aplikacji (relacja z rol¹).
-	Role: Przechowuje role u¿ytkowników (user, admin).
-	Product: Przyk³ad powi¹zanej encji z u¿ytkownikiem (np. produkty u¿ytkownika)
-	Order: Przyk³ad encji zwi¹zanej z produktem i u¿ytkownikiem (zamówienia).
## Przyk³ady u¿ycia
### Autoryzacja
-	POST /api/auth/register – Rejestracja nowego u¿ytkownika.
-	POST /api/auth/login – Logowanie (JWT).
### Endpointy API
-	GET /api/products – Pobiera listê produktów (role: user, admin).
-	POST /api/products – Tworzy nowy produkt (tylko admin).
### Role u¿ytkowników
-	User: Mo¿e przegl¹daæ produkty.
-	Admin: Ma pe³ne uprawnienia do zarz¹dzania danymi.



