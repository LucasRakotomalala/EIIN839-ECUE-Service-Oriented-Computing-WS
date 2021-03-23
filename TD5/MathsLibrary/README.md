# Introduction to the ABC (Address, Binding, Contract) model in WCF (Windows Communication Foundation)

## SOAP Web Services

Pour pouvoir utiliser lancer le [`Client`](Client), il faut commenter la partie `REST` de [`App.config`](MathsLibrary/App.config) et décommenter la partie `SOAP`.

## REST Web Services

### Exemples d'URL

* Addition : `http://localhost:8733/Design_Time_Addresses/MathsLibrary/MathsOperations/Add?x=1&y=2`
* Multiplication : `http://localhost:8733/Design_Time_Addresses/MathsLibrary/MathsOperations/Multiply?x=10&y=2`
* Soustraction : `http://localhost:8733/Design_Time_Addresses/MathsLibrary/MathsOperations/Substract?x=5&y=3`
* Division : `http://localhost:8733/Design_Time_Addresses/MathsLibrary/MathsOperations/Divide?x=3&y=4`