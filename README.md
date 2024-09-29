
# CoolProject
## Opis projektu
CoolProject to aplikacja backendowa w C#, implementująca Onion Architecture. Aplikacja obsługuje rejestrację i logowanie użytkowników przez API z JWT, posiada rolę użytkownika i administratora oraz połączenie z bazą danych. Zawiera 4 encje, z czego 2 są ze sobą powiązane.
## Wymagania
- .NET 6.0+
-	Entity Framework Core
-	SQL Server
-	JWT (do autoryzacji)
-	Swagger (do dokumentacji API)
## Instalacja
- Sklonuj repozytorium:
``` git clone https://github.com/D4RK0N3dev/CoolProject.git```
- Zainstaluj zależności:
dotnet restore
-	Skonfiguruj połączenie z bazą danych w appsettings.json.
-	Uruchom migracje:
``` dotnet ef database update```
-	Uruchom aplikację:
``` dotnet run --project CoolProject.API```
## Struktura projektu
Projekt jest zgodny z Onion Architecture i podzielony na następujące warstwy:
-	CoolProject.API: Warstwa prezentacji, obsługująca żądania HTTP oraz autoryzację JWT.
-	Application: Logika biznesowa.
-	Domain: Zawiera modele i encje.
-	Infrastructure: Zarządzanie danymi i konfiguracja baz danych.
## Encje
-	User: Reprezentuje użytkownika aplikacji (relacja z rolą).
-	Role: Przechowuje role użytkowników (user, admin).
-	Product: Przykład powiązanej encji z użytkownikiem (np. produkty użytkownika)
-	Order: Przykład encji związanej z produktem i użytkownikiem (zamówienia).
## Przykłady użycia
### Autoryzacja
-	POST /api/auth/register – Rejestracja nowego użytkownika.
-	POST /api/auth/login – Logowanie (JWT).
### Endpointy API
-	GET /api/products – Pobiera listę produktów (role: user, admin).
-	POST /api/products – Tworzy nowy produkt (tylko admin).
### Role użytkowników
-	User: Może przeglądać produkty.
-	Admin: Ma pełne uprawnienia do zarządzania danymi.



