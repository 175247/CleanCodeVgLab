# CleanCodeVgLab

Simon Tillström


Använt design pattern:
Repository pattern.
Detta var för att jag använde Entity Framework och jag ville att klasserna skulle vara lösare kopplade.
Om jag använder EF nu men om en stund bestämmer mig för att prova på något annat så behöver jag bara ändra koden på väldigt få ställen, och resten av programmet kommer fungera som vanligt. Det har alltså abstraherats bort mer. Repositoryt gör sitt jobb - hur den gör det är inte relevant för resten av programmet. Resterande program kör sitt race.


Kunde använt:
Visitor pattern.
Objekt ändras på många gånger, och Visitor hade kunnat göra det lätt och bra.
Det valdes inte för att jag valde att fokusera på Repository Pattern då det används mer för bl.a. data access, loose coupling och reducering av repeterad kod med IQueryable, även om det kändes som lite overengineering för detta projekt.
