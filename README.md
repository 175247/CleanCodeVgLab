# CleanCodeLab3
 Gjort av Alexander Molnar och Simon Tillström.
 
 Motivation till val av design patterns:
 
 1. Singleton (Menu)
 Vi resonerade att restauranger (generellt) bara använder sig av en meny, framför allt
 om det är en online-mat-beställnings-app eller liknande (Foodora t.ex.), och därför ville vi
 följa det mönstret.
 
 2. Builder (PizzaBuilder)
 När du gör en pizza så "bygger" du pizzan, och vi tänkte att vi skulle göra samma sak i vår kod.
 
 3. Factory (DrinkFactory, PizzaFactory)
Vi ville ha ett objekt som bara returnerade pizzorna, men vi ville abstrahera en portion av logiken,
men fortfarande använda vår builder, då man bygger pizzan.



* Ett annat val var att använda oss av Visitor-pattern för att räkna ut priset på vår order (Drink och Pizza),
* då Drink- och Pizza-objekten bara ska hålla data men inte sköta några beräkningar.
* Vi valde dock att ha kvar Builder och Factory då vi tyckte att det blev en coolare process.