# Projekt Wizyty Stomatologiczne

Prosta aplikacja Windows Forms do umawiania wizyt u stomatologa. Aplikacja wykorzystuje bazę danych SQLite.

## Funkcje

- Logowanie jako lekarz lub pacjent
- Lekarz może dodawać i usuwać pacjentów oraz usuwać wizyty
- Pacjent może umawiać i odwoływać własne wizyty

## Struktura projektu

Kod źródłowy znajduje się w katalogu `DentistApp`.

## Budowanie

Wymagane jest środowisko .NET 6 z obsługą Windows Forms. Aby zbudować aplikację:

```bash
dotnet build DentistApp.csproj
```

## Uruchamianie

```bash
dotnet run --project DentistApp.csproj
```

Przy pierwszym uruchomieniu zostanie utworzona baza danych `dentist.db`.
