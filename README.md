# CleanCodeVgLab
 Bygger på labb 3 gjord av Alexander Molnar och Simon Tillström.
 
 Motivation till val av design patterns (labb 3 bas):
 
 1. Singleton (Menu)
 Vi resonerade att restauranger (generellt) bara använder sig av en meny, framför allt
 om det är en online-mat-beställnings-app eller liknande (Foodora t.ex.), och därför ville vi
 följa det mönstret.
 
 2. Builder (PizzaBuilder)
 När du gör en pizza så "bygger" du pizzan, och vi tänkte att vi skulle göra samma sak i vår kod.
 
 3. Factory (DrinkFactory, PizzaFactory)
Vi ville ha ett objekt som bara returnerade pizzorna, men vi ville abstrahera en portion av logiken,
men fortfarande använda vår builder, då man bygger pizzan.
