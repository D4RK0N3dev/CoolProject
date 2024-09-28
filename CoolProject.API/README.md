
# CoolProject
## Opis projektu
CoolProject to aplikacja backendowa w C#, implementuj�ca Onion Architecture. Aplikacja obs�uguje rejestracj� i logowanie u�ytkownik�w przez API z JWT, posiada rol� u�ytkownika i administratora oraz po��czenie z baz� danych. Zawiera 4 encje, z czego 2 s� ze sob� powi�zane.
## Wymagania
- .NET 6.0+
-	Entity Framework Core
-	SQL Server
-	JWT (do autoryzacji)
-	Swagger (do dokumentacji API)
## Instalacja
- Sklonuj repozytorium:
``` git clone https://github.com/D4RK0N3dev/CoolProject.git```
- Zainstaluj zale�no�ci:
dotnet restore
-	Skonfiguruj po��czenie z baz� danych w appsettings.json.
-	Uruchom migracje:
``` dotnet ef database update```
-	Uruchom aplikacj�:
``` dotnet run --project CoolProject.API```
## Struktura projektu
Projekt jest zgodny z Onion Architecture i podzielony na nast�puj�ce warstwy:
-	CoolProject.API: Warstwa prezentacji, obs�uguj�ca ��dania HTTP oraz autoryzacj� JWT.
-	Application: Logika biznesowa.
-	Domain: Zawiera modele i encje.
-	Infrastructure: Zarz�dzanie danymi i konfiguracja baz danych.
## Encje
-	User: Reprezentuje u�ytkownika aplikacji (relacja z rol�).
-	Role: Przechowuje role u�ytkownik�w (user, admin).
-	Product: Przyk�ad powi�zanej encji z u�ytkownikiem (np. produkty u�ytkownika)
-	Order: Przyk�ad encji zwi�zanej z produktem i u�ytkownikiem (zam�wienia).
## Przyk�ady u�ycia
### Autoryzacja
-	POST /api/auth/register � Rejestracja nowego u�ytkownika.
-	POST /api/auth/login � Logowanie (JWT).
### Endpointy API
-	GET /api/products � Pobiera list� produkt�w (role: user, admin).
-	POST /api/products � Tworzy nowy produkt (tylko admin).
### Role u�ytkownik�w
-	User: Mo�e przegl�da� produkty.
-	Admin: Ma pe�ne uprawnienia do zarz�dzania danymi.



