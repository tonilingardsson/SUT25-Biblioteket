# Bibliotekssystem - Library Management System

## Beskrivning
Ett enkelt konsolbaserat biblioteksystem byggt i C# där användare kan logga in, se tillgängliga böcker att låna, låna och lämna tillbaka böcker. 

Detta projekt är en inlämningsuppgift för YH-programmet SUT25 på Campus Varberg, utvecklat för att demonstrera förståelse för: 

- Objektorienterad programmering med klasser och metoder
- Datahantering med arrays
- Input-validering och felhantering
- Användarinteraktion via konsol

### Hur man kör programmet
```bash
dotnet run
```

### Testanvändare
För att testa systemet, använd någon av dessa förinställda användare:

| Användarnamn | PIN  |
|--------------|------|
| Petter       | 1111 |
| Reidar       | 2222 |
| Sara         | 3333 |
| Pär          | 4444 |
| Antonio      | 5555 |

**Tips:** Prova att logga in med fel PIN 3 gånger för att se felhanteringen!

## Funktionalitet

### Inloggningssystem
- ✅ Säker inloggning med användarnamn och PIN-kod
- ✅ Tre inloggningsförsök innan systemet stängs
- ✅ Felmeddelanden vid felaktig inloggning
- ⚠️ **OBS:** Användarnamn är case-sensitive (Petter ≠ petter)

### Huvudmeny
Efter lyckad inloggning får användaren tillgång till:
1. Visa böcker
2. Låna bok
3. Lämna tillbaka bok
4. Mina lån
5. Logga ut

### Bokhantering
- **Visa böcker:** Listar alla böcker med ID, titel och antal tillgängliga exemplar
- **Låna bok:** Användaren väljer bok via ID med validering:
  - Kontrollerar om boken finns tillgänglig
  - Kontrollerar om användaren redan lånat max antal (3 böcker)
  - Bekräftar lyckad utlåning
- **Lämna tillbaka bok:** Användaren väljer vilken lånad bok att returnera via position (1, 2 eller 3)
- **Mina lån:** Visar alla böcker användaren har lånat just nu

### Validering och Felhantering
- ✅ Kontroll av ogiltiga bok-ID
- ✅ Kontroll av maxgräns för lån (3 böcker per användare)
- ✅ Felmeddelanden för ej tillgängliga böcker
- ✅ Input-validering för alla användarval


## Programstruktur och Designval

### Klassstruktur

Programmet är uppdelat i tre huvudklasser för att följa principen om **Separation of Concerns** (ansvarsfördelning):

**Book.cs**
- Hanterar all bokdata (ID, titel, antal kopior)
- Innehåller metoder för att visa bokinformation och beräkna tillgängliga exemplar
- **Motivering:** Genom att hålla boklogik separat blir koden lättare att underhålla och testa. Om jag behöver ändra hur böcker visas behöver jag bara ändra i Book-klassen.

**User.cs**
- Hanterar användardata (namn, PIN, lånade böcker)
- Innehåller metoder för att validera lånegränser och visa användarlån
- **Motivering:** Användare och böcker är olika typer av data med olika beteenden. Att separera dem gör koden mer modulär.

**Program.cs**
- Huvudprogram som koordinerar login och menyhantering
- Kopplar samman User och Book klasserna
- **Motivering:** Separerar användarinteraktion (UI) från datalogik. Om jag vill byta från konsol till GUI behöver jag bara ändra Program.cs, inte Book eller User.

**Alternativ:** Allt hade kunnat vara i en fil (Program.cs), men det skulle gjort koden svårare att navigera, högre risk för buggar, och svårare att återanvända kod i framtida projekt.

---

### Val av Datastrukturer

**Arrays istället för List<T>**

Jag valde `arrays` för både böcker och användare eftersom:
- Vi har ett **fast antal** objekt (5 böcker, 5 användare)
- Arrays är **enklare att förstå** som nybörjare och täcker grunderna i C#
- **Direktaccess** via index är effektivt för små dataset
- Det matchar vad vi lärt oss i kursen hittills

**Motivering:** För detta projekt med statisk data är arrays perfekt. I ett verkligt bibliotekssystem där böcker läggs till och tas bort dynamiskt skulle `List<T>` eller en databas vara bättre val.

**Framtida förbättringar:** När vi lärt oss objektorienterad programmering och collections i kommande kurser kan systemet uppgraderas till mer dynamiska datastrukturer.

---

### Design av borrowedBooks

Jag använder både en array och en räknare:

```csharp
public int[] borrowedBooks = new int[3];  // Array för att lagra bok-ID
public int borrowedCount = 0;              // Räknare för antal aktiva lån
```

**Varför behövs båda?**
- **Array:** Lagrar bok-ID:n (max 3 platser)
- **Räknare:** Håller reda på hur många platser som faktiskt används

**Exempel:**
```
Användare har lånat 2 böcker:
borrowedBooks = [5, 12, 0]  ← Sista platsen är tom
borrowedCount = 2            ← Endast 2 böcker aktiva
```

**Motivering:** 
- Räknaren gör det enkelt att validera om användaren kan låna fler böcker (`borrowedCount < 3`)
- Den hjälper också att hitta rätt position när bok returneras
- Utan räknare skulle vi inte veta om `0` i arrayen är ett tomt slot eller ett bok-ID

## Utmaningar och Lösningar

### Utmaning 1: Ta bort bok från användares lån
**Problem:** När användare returnerar en bok måste den tas bort från mitten av arrayen.
**Lösning:** Implementerade "array shifting" som flyttar alla element efter den returnerade boken ett steg till vänster.

### Utmaning 2: Validering av inloggning
**Problem:** Måste kontrollera ALLA användare innan man säger "fel inloggning".
**Lösning:** Loopa igenom hela users-arrayen FÖRST, sedan öka `loginAttempts` om ingen match hittades.

### Utmaning 3: Input-validering
**Problem:** Program kraschar om användaren skriver text istället för nummer.
**Lösning:** Använder `int.TryParse()` för säker konvertering och felhantering.

### Utmaning 4: Trötthet och felsökning
**Problem:** Efter flera timmars kodning blev det svårt att hitta små syntaxfel.
**Lösning:** Lärde mig att ta pauser och läsa felmeddelanden noggrant.

---

## Teknisk Information
- **Språk:** C# (.NET 8.0)
- **Utvecklingsmiljö:** VS Code
- **Datum:** 12 oktober 2025

---

**Utvecklad av:** Antonio Lingårdsson Luna